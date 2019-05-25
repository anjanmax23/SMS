using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.NetworkInformation;

namespace SMS
{
    public partial class frmNewOrder : Form
    {
        string ConnString;
        public frmNewOrder()
        {
            InitializeComponent();
            Globals gb = new Globals();
            ConnString = gb.ConnString;
        }


        private void btnOne_Click(object sender, EventArgs e)
        {
            GetQuantity(btnOne);
        }

        private void GetQuantity(Button btn)
        {
            if ((float.Parse(txtQuantity.Text.Trim()) + float.Parse(btn.Text.Trim())) <= 999999)
            {
                if (txtQuantity.Text.Trim() == "")
                {
                    if (btn.Text.Trim() == "00" || btn.Text.Trim() == "0")
                        txtQuantity.Text = "0";
                    else
                        txtQuantity.Text = btn.Text.Trim();
                }
                else if (txtQuantity.Text.Trim() == "0")
                {
                    txtQuantity.Text = btn.Text.Trim();
                }
                else
                {
                    if ((float.Parse(txtQuantity.Text.Trim()) + float.Parse(btn.Text.Trim())) <= 999999)
                        txtQuantity.Text = txtQuantity.Text.Trim() + btn.Text.Trim();
                }
                CalculateItemPriceWithTax();
            }

        }

        private void CalculateItemPriceWithTax()
        {
            InventryOrder i = new InventryOrder();
            AppConfiguration a = new AppConfiguration();
            int unit = GetSelectedUnit();
            int IsOutsideUP = i.CustomerOutsideUP;
            float TotalTaxAmount = 0;
            float IGST = 0;
            float CGST = 0;
            float SGST = 0;
            float IGSTAmount = 0;
            float CGSTAmount = 0;
            float SGSTAmount = 0;
            float BaseAmount = 0;
            float InventryAmount = 0;
            if (unit == 1)
                BaseAmount = i.OrderItemBasePricePerKG;
            else if (unit == 0)
                BaseAmount = i.OrderItemBasePricePerPiece;
            if (txtQuantity.Text.Trim() != "" && txtQuantity.Text.Trim().Substring(0) != ".")
                InventryAmount = (float.Parse(txtQuantity.Text.Trim()) * BaseAmount);
            else
                InventryAmount = 0;

            if (IsOutsideUP == 1)
            {
                IGST = i.OrderIGST;
                CGST = 0;
                SGST = 0;
                IGSTAmount = (InventryAmount * IGST) / 100;
                CGSTAmount = 0;
                SGSTAmount = 0;
            }
            else
            {
                IGST = 0;
                CGST = i.OrderCGST;
                SGST = i.OrderSGST;
                IGSTAmount = 0;
                CGSTAmount = (InventryAmount * CGST) / 100;
                SGSTAmount = (InventryAmount * SGST) / 100;
            }
            TotalTaxAmount = IGSTAmount + CGSTAmount + SGSTAmount;

            lblCost.Text = "COST WITH TAX Rs. " +( Math.Round(InventryAmount,2) + Math.Round(TotalTaxAmount, 2));

            //if (rdoKG.Checked == true)
            //{
            //    lblCost.Text =""+ (float.Parse(txtQuantity.Text.Trim()) * io.OrderItemBasePricePerKG);
            //    lblCost.Text = "COST Rs. " + Math.Round(float.Parse(lblCost.Text) + (float.Parse(lblCost.Text) * 18) / 100, 2);
            //}

            //else if (rdoPIECE.Checked == true)
            //{
            //    lblCost.Text = ""+(float.Parse(txtQuantity.Text.Trim()) * io.OrderItemBasePricePerPiece);
            //    lblCost.Text = "COST Rs. " + Math.Round(float.Parse(lblCost.Text) + (float.Parse(lblCost.Text) * 18) / 100, 2);
            //}
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            GetQuantity(btnTwo);
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            GetQuantity(btnThree);
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            GetQuantity(btnFour);
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            GetQuantity(btnFive);
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            GetQuantity(btnSix);
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            GetQuantity(btnSeven);
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            GetQuantity(btnEight);
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            GetQuantity(btnNine);
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            GetQuantity(btnZero);
        }

        private void btnDoubleZero_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text.Trim() == "0")
                txtQuantity.Text = "0";
            else
                txtQuantity.Text = txtQuantity.Text.Trim() + "00";
            CalculateItemPriceWithTax();
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            if (rdoPIECE.Checked == true)
                MessageBox.Show("Point is not applicable on PIECE", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                txtQuantity.Text = "" + txtQuantity.Text.Trim() + ".";
                btnPoint.Enabled = false;
                
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (float.Parse(txtQuantity.Text) > 0)
            {
                InventryOrder i = new InventryOrder();
                AppConfiguration a = new AppConfiguration();
                int unit = GetSelectedUnit();
                int IsOutsideUP = i.CustomerOutsideUP;
                float TotalTaxAmount = 0;
                float IGST = 0;
                float CGST = 0;
                float SGST = 0;
                float IGSTAmount = 0;
                float CGSTAmount = 0;
                float SGSTAmount = 0;
                float BaseAmount = 0;
                if (unit == 1)
                    BaseAmount = i.OrderItemBasePricePerKG;
                else if (unit == 0)
                    BaseAmount = i.OrderItemBasePricePerPiece;

                float InventryAmount = (float.Parse(txtQuantity.Text.Trim()) * BaseAmount);

                if (IsOutsideUP == 1)
                {
                    IGST = i.OrderIGST;
                    CGST = i.OrderCGST;
                    SGST = i.OrderSGST;
                    IGSTAmount = (InventryAmount * IGST) / 100;
                    CGSTAmount = 0;
                    SGSTAmount = 0;
                }
                else
                {
                    IGST = i.OrderIGST;
                    CGST = i.OrderCGST;
                    SGST = i.OrderSGST;
                    IGSTAmount = 0;
                    CGSTAmount = (InventryAmount * CGST) / 100;
                    SGSTAmount = (InventryAmount * SGST) / 100;
                }
                TotalTaxAmount = IGSTAmount + CGSTAmount + SGSTAmount;
                bool ExistFlag = CheckDataExists(i.OrderItemID,a.TerminalID);
                if (ExistFlag == true)
                    MessageBox.Show("This item is already exists in order!!", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    int n = INSERT_NewOrder_Temp_DATA(0, i.OrderItemID, unit, BaseAmount, float.Parse(txtQuantity.Text.Trim()), InventryAmount,
                        TotalTaxAmount, 0, a.CounterID, a.TerminalID, i.OrderCustomerID, GetMacAddress(),IGST,CGST,SGST,IGSTAmount,CGSTAmount,SGSTAmount,i.OrderCustomerName);
                    if (n > 0)
                    {
//                        MessageBox.Show("New order has been successfully saved.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Visible = false;
                        this.Hide();
                        this.Close();
                        if (Application.OpenForms.OfType<frmOrder>().Any())
                        {
                            frmOrder frm = new frmOrder();
                            frm.Hide();
                            frm.Close();
                        }
                        frmOrder frm1 = new frmOrder();
                        frm1.Show();
                    }
                    else
                        MessageBox.Show("Failed to saved new order", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            btnPoint.Enabled = true;
        }

        private string GetMacAddress()
        {
            string macAddresses = string.Empty;

            foreach (System.Net.NetworkInformation.NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            return macAddresses;
        }


        private int GetSelectedUnit()
        {
            if (rdoKG.Checked == true)
                return 1;
            else if (rdoPIECE.Checked == true)
                return 0;
            else
                return -1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new frmOrder().Visible = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtQuantity.Text = "0";
            lblCost.Text = "COST With TAX Rs. 0";
            btnPoint.Enabled = true;
        }


        private void frmNewOrder_Load(object sender, EventArgs e)
        {
            InventryOrder io = new InventryOrder();
            lblItemName.Text = "ITEM NAME: "+io.OrderItemName;
            lblItemNo.Text = "Item#: " + io.OrderItemID;
            lblCostumer.Text = "CUSTOMER: " + io.OrderCustomerName;

            if (io.OrderItemBasePricePerKG > 0)
            {
                rdoKG.Enabled = true;
                rdoKG.Checked = true;
                if (io.OrderItemBasePricePerPiece > 0)
                    rdoPIECE.Enabled = true;
                else
                    rdoPIECE.Enabled = false;
            }
            else if (io.OrderItemBasePricePerPiece > 0)
            {
                rdoPIECE.Enabled = true;
                rdoPIECE.Checked = true;
                if (io.OrderItemBasePricePerKG > 0)
                    rdoKG.Enabled = true;
                else
                    rdoKG.Enabled = false;
            }
            else
            {
                rdoPIECE.Enabled = false;
                rdoPIECE.Checked = false;
                rdoKG.Enabled = false;
                rdoKG.Checked = false;
            }


            if (rdoKG.Checked == true)
                lblSelectedUnit.Text = "Selected Unit: KG";
            if (rdoPIECE.Checked == true)
                lblSelectedUnit.Text = "Selected Unit: PIECE";

        }



        private void rdoKG_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoKG.Checked == true)
            {
                lblSelectedUnit.Text = "Selected Unit: KG";
                txtQuantity.Focus();
            }
            if (rdoPIECE.Checked == true)
            {
                lblSelectedUnit.Text = "Selected Unit: PIECE";
                txtQuantity.Focus();
            }
            //InventryOrder io = new InventryOrder();
            //if (rdoKG.Checked == true)
            //    lblCost.Text = "COST Rs. " + (Convert.ToInt32(txtQuantity.Text.Trim()) * io.OrderItemBasePricePerKG);
            //else if (rdoPIECE.Checked == true)
            //    lblCost.Text = "COST Rs. " + (Convert.ToInt32(txtQuantity.Text.Trim()) * io.OrderItemBasePricePerPiece);
            //btnPoint.Enabled = true;
            CalculateItemPriceWithTax();
        }

        private void rdoPIECE_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoKG.Checked == true)
                lblSelectedUnit.Text = "Selected Unit: KG";
            if (rdoPIECE.Checked == true)
                lblSelectedUnit.Text = "Selected Unit: PIECE";
            if (float.Parse(txtQuantity.Text.Trim()) > 0)
            {
                txtQuantity.Text =""+ Math.Truncate(Convert.ToDecimal(txtQuantity.Text.Trim()));
            }
            //InventryOrder io = new InventryOrder();
            //if (rdoKG.Checked == true)
            //    lblCost.Text = "COST Rs. " + (Convert.ToInt32(txtQuantity.Text.Trim()) * io.OrderItemBasePricePerKG);
            //else if (rdoPIECE.Checked == true)
            //    lblCost.Text = "COST Rs. " + (Convert.ToInt32(txtQuantity.Text.Trim()) * io.OrderItemBasePricePerPiece);
            CalculateItemPriceWithTax();

            btnPoint.Enabled = false;


        }

            /* Selecte Unit 1 for KG and 0 for Piece  */
        public int INSERT_NewOrder_Temp_DATA(decimal OrderID, int InventryID,int SelectedUnit, float InventryBasePrice, float Quanitity, float TotalAmountDue, 
            float TotalTaxAmount, int UserID, int CounterID, int TerminalID,int CustomerID,string MacID,float IGST,float CGST,float SGST,
            float IGSTAmount,float CGSTAmount,float SGSTAmount, string CustomerName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertTempOrderTrans", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OrderID", OrderID);
                        cmd.Parameters.AddWithValue("@InventryID", InventryID);
                        cmd.Parameters.AddWithValue("@MesurementTypeID", SelectedUnit);
                        cmd.Parameters.AddWithValue("@TotalBaseAmount", InventryBasePrice);
                        cmd.Parameters.AddWithValue("@Quantity", Quanitity);
                        cmd.Parameters.AddWithValue("@TotalAmountDue", TotalAmountDue);
                        cmd.Parameters.AddWithValue("@TotalTaxAmount", TotalTaxAmount);
                        cmd.Parameters.AddWithValue("@OrderBy", UserID);
                        cmd.Parameters.AddWithValue("@CounterID", CounterID);
                        cmd.Parameters.AddWithValue("@TerminalID", TerminalID);
                        cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                        cmd.Parameters.AddWithValue("@MacID", MacID);
                        cmd.Parameters.AddWithValue("@IGST", IGST);
                        cmd.Parameters.AddWithValue("@CGST", CGST);
                        cmd.Parameters.AddWithValue("@SGST", SGST);
                        cmd.Parameters.AddWithValue("@IGSTAmount", IGSTAmount);
                        cmd.Parameters.AddWithValue("@CGSTAmount", CGSTAmount);
                        cmd.Parameters.AddWithValue("@SGSTAmount", SGSTAmount);
                        cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        int n = cmd.ExecuteNonQuery();
                        return n;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }


        public bool CheckDataExists(int InventryID,int TerminalID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("CheckItemExistInOrder", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ItemID", InventryID);
                        cmd.Parameters.AddWithValue("@TerminalID", TerminalID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                            return true;
                        else
                            return false;
                    }
                }
            }
            catch (Exception )
            {
                return true;
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text.Trim() == "00" || txtQuantity.Text.Trim() == "0")
            {
                txtQuantity.Text = "0";
            }
            CalculateItemPriceWithTax();

        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rdoKG.Checked)
            {
                if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back))&& (e.KeyChar != '.'))  
                    e.Handled = true;
                else if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
            else if (rdoPIECE.Checked)
            {
                if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                    e.Handled = true;
            }
            else if (float.Parse(txtQuantity.Text.Trim()) > 999999)
            {
                e.Handled = true;
            }
  


        }
    }
}
