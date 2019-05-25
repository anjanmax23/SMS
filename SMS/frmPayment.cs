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

namespace SMS
{
    public partial class frmPayment : Form
    {
        string ConnString;
        public frmPayment()
        {
            InitializeComponent();
            Globals gb = new Globals();
            ConnString = gb.ConnString;
        }



        private void txtTokenNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtTokenNo.Text.Trim() != "")
                {
                    bool CanceledFlag = CheckCanceledStatus(Convert.ToInt64(txtTokenNo.Text.Trim()));
                    if (CanceledFlag == true)
                    {
                        MessageBox.Show("This order was canceled, please select another order !!","Alert Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        txtTokenNo.Text = "";
                        txtTokenNo.Focus();
                    }
                    else
                    {
                        Load_Order_data(Convert.ToInt32(txtTokenNo.Text.Trim()));
                        Load_Order_Predata(Convert.ToInt32(txtTokenNo.Text.Trim()));
                    }
                }
            }
        }


        private void Load_Order_data(int TokenNo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetOrderDetailsByOrderID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OrderID", TokenNo);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            dgv.DataSource = dt;
                            dgv.Columns[0].Width = 50;
                            dgv.Columns[1].Width = 150;
                            dgv.Columns[2].Width = 50;
                            dgv.Columns[3].Width = 50;
                            dgv.BackgroundColor = Color.White;
                            dgv.RowHeadersVisible = false;
                        }
                        else
                            dgv.DataSource = null;

                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.Font = new Font(dgv.Font.FontFamily, 9, FontStyle.Bold);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in dgv.Rows)
                            {
                                if ("" + row.Cells["ITEM"].Value == "TAXES")
                                {
                                    foreach (DataGridViewCell cell in row.Cells)
                                        cell.Style.ApplyStyle(style);
                                }
                                else if ("" + row.Cells["ITEM"].Value == "GRAND TOTAL")
                                {
                                    foreach (DataGridViewCell cell in row.Cells)
                                        cell.Style.ApplyStyle(style);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                dgv.DataSource = null;
            }
        }


        private void Load_Order_Predata(int TokenNo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("getOrderDetailsForCashier", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OrderID", TokenNo);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = (DataRow)dt.Rows[0];
                            lblCustomerName.Text = "Customer Name: " + dr["CustomerName"];
                            lblSalesmanName.Text = "Salesman Name: " + dr["Salesman"];
                            lblOrderTerminal.Text = "Order Terminal: " + dr["TerminalID"];
                            lblOrderCounter.Text = "Order Counter: " + dr["CounterID"];
                            lblOrderDate.Text = "Order Date: " + dr["OrderDate"];
                            txtTotalDueAmount.Text = "" + dr["TotalDueAmount"];
                            txtTotalPaidAmount.Text = "" + dr["TotalPaidAmount"];
                            txtTotalOutstandingAmount.Text = "" + dr["TotalOutstandingAmount"];
                            txtSettledDate.Text = "" + dr["SettledDate"];
                            if (!dr.IsNull("ExpectedDeleveryDate"))
                            {

                                string del = "" + dr["ExpectedDeleveryDate"];
                                dtpDeliveryDate.MinDate = Convert.ToDateTime(del);
                                dtpDeliveryDate.Value = Convert.ToDateTime(del);
                            }
                            if (!dr.IsNull("ExpectedDeleveryTime"))
                                dtpTime.Text = "" + dr["ExpectedDeleveryTime"];
                            if (!dr.IsNull("Email"))
                                txtEmail.Text = "" + dr["Email"];
                            else
                                txtEmail.Text = "";
                            if (!dr.IsNull("MobileNo"))
                                txtMobileNo.Text = "" + dr["MobileNo"];
                            else
                                txtMobileNo.Text = "";
                            if (!dr.IsNull("CareOf"))
                                txtCareOf.Text = "" + dr["CareOf"];
                            else
                                txtCareOf.Text = "";
                            if (!dr.IsNull("Address"))
                                txtAddress.Text = "" + dr["Address"];
                            else
                                txtAddress.Text = "";
                            if (!dr.IsNull("IsBulkOrder"))
                            {
                                if (Convert.ToInt32(dr["IsBulkOrder"]) == 1)
                                    chkBulkOrder.Checked = true;
                                else
                                    chkBulkOrder.Checked = false;
                            }
                            else
                                chkBulkOrder.Checked = false;
                            if (!dr.IsNull("BoxID"))
                                cmbBoxType.SelectedValue = "" + dr["BoxID"];
                            else
                                cmbBoxType.SelectedIndex = 0;

                            if (!dr.IsNull("Address"))
                                txtAddress.Text = "" + dr["Address"];
                            else
                                txtAddress.Text = "";


                            if (!dr.IsNull("ChequeNo"))
                                txtChequeNo.Text = "" + dr["ChequeNo"];
                            else
                                txtChequeNo.Text = "";
                            if (!dr.IsNull("ChequeBank"))
                                txtChequeBank.Text = "" + dr["ChequeBank"];
                            else
                                txtChequeBank.Text = "";
                            if (!dr.IsNull("ChequeDate"))
                                txtChequeDate.Text = "" + dr["ChequeDate"];
                            else
                                txtChequeDate.Text = "";
                            int PaymentType = 0;
                            if (!dr.IsNull("PaymentType"))
                                PaymentType = Convert.ToInt32(dr["PaymentType"]);
                            if (PaymentType == 1 || PaymentType == 0)
                                rdoFullSettlement.Checked = true;
                            else if (PaymentType == 2)
                                rdoOnCredit.Checked = true;
                            else if (PaymentType == 3)
                                rdoAdvanced.Checked = true;
                            int PaymentMode = 0;
                            if (!dr.IsNull("PaymentMode"))
                                PaymentMode = Convert.ToInt32(dr["PaymentMode"]);
                            if (PaymentMode == 1 || PaymentMode == 0)
                                rdoCash.Checked = true;
                            else if (PaymentMode == 2)
                                rdoCheque.Checked = true;
                            else if (PaymentMode == 3)
                                rdoCard.Checked = true;

                            if (!dr.IsNull("LastPaymentDate"))
                            {
                                txtLastPaymentDate.Text = "" + dr["LastPaymentDate"];
                                grpBulkOrder.Enabled = false;
                            }
                            else
                            {
                                txtLastPaymentDate.Text = "";
                                grpBulkOrder.Enabled = true;
                            }
                            if (txtSettledDate.Text == "")
                            {
                                if (rdoFullSettlement.Checked)
                                {
                                    txtCurrentTotalPaidAmount.Text = txtTotalOutstandingAmount.Text.Trim();
                                    txtCurrentTotalOutstandingAmount.Text = "" + (float.Parse(txtTotalOutstandingAmount.Text.Trim()) -
                                                                            float.Parse(txtCurrentTotalPaidAmount.Text.Trim()));
                                    txtCurrentTotalPaidAmount.Enabled = false;
                                    btnSubmitOrder.Focus();
                                }
                                else
                                    txtCurrentTotalPaidAmount.Enabled = true;

                                groupBox2.Enabled = true;
                                groupBox4.Enabled = true;
                                btnTaxInvoice.Enabled = false;
                            }
                            else
                            {
                                txtCurrentTotalPaidAmount.Enabled = false;
                                groupBox2.Enabled = false;
                                groupBox4.Enabled = false;
                                btnTaxInvoice.Enabled = true;
                            }

                            txtCurrentTotalPaidAmount.Focus();
                        }
                        else
                        {
                            lblCustomerName.Text = "Customer Name: ";
                            lblSalesmanName.Text = "Salesman Name: ";
                            lblOrderTerminal.Text = "Order Terminal: ";
                            lblOrderCounter.Text = "Order Counter: ";
                            lblOrderDate.Text = "Order Date: ";
                            txtTotalDueAmount.Text = "";
                            txtTotalPaidAmount.Text = "";
                            txtTotalOutstandingAmount.Text = "";
                            txtSettledDate.Text = "";
                            groupBox2.Enabled = false;
                            groupBox4.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgv.DataSource = null;
            }
        }


        private void frmPayment_Load(object sender, EventArgs e)
        {
            txtTokenNo.Focus();
            Globals gb = new Globals();
            gb.FillDropdownList(ConnString, "GetActiveBox", cmbBoxType, "BoxName", "BoxID");
            dtpDeliveryDate.MinDate = DateTime.Now.Date;
            //dtpDeliveryDate.Format = DateTimePickerFormat.Short;
            //dtpTime.Format = DateTimePickerFormat.Time;
            //dtpTime.ShowUpDown = true;
            if (rdoCheque.Checked == true)
                grpCheque.Enabled = true;
            else
                grpCheque.Enabled = false;
            this.WindowState = FormWindowState.Maximized;

        }

        private void chkBulkOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBulkOrder.Checked)
            {
                dtpDeliveryDate.Enabled = true;
                dtpTime.Enabled = true;
                cmbBoxType.Enabled = true;
                rdoAdvanced.Enabled = true;
            }
            else
            {
                dtpDeliveryDate.Enabled = false;
                dtpTime.Enabled = false;
                cmbBoxType.Enabled = false;
                rdoAdvanced.Enabled = false;

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            bool flag = CheckValidationData();
            if (flag == true)
            {
                Globals gb = new Globals();
                string ExpectedDeliveryDate = "";
                string ExpctedDeliveryTime = "";
                if (chkBulkOrder.Checked)
                {
                    ExpectedDeliveryDate = "" + dtpDeliveryDate.Value.ToString("yyyy-MM-dd");
                    ExpctedDeliveryTime = "" + dtpDeliveryDate.Value;
                }
                else
                {
                    ExpectedDeliveryDate = "";
                    ExpctedDeliveryTime = "";
                }
                int n = InsertOrderPaymentData(Convert.ToInt64(txtTokenNo.Text.Trim()), float.Parse(txtTotalOutstandingAmount.Text.Trim()),
                    float.Parse(txtCurrentTotalPaidAmount.Text.Trim()), float.Parse(txtCurrentTotalOutstandingAmount.Text.Trim()),
                    GetPaymentType(), GetPaymentMode(), txtChequeNo.Text.Trim(), txtChequeBank.Text.Trim(), txtChequeDate.Text.Trim(),
                    GetIsAdvanced(), txtMobileNo.Text.Trim(), txtEmail.Text.Trim(), txtCareOf.Text.Trim(), txtAddress.Text.Trim(),
                    GetIsBulkOrder(), ExpectedDeliveryDate, ExpctedDeliveryTime, gb.UserID);
                if (n > 0)
                {
                    MessageBox.Show("Payment has been sucessfully paid.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();

                }
            }
        }

        private void ClearData()
        {
            txtTokenNo.Text = "";
            lblCustomerName.Text = "Customer Name:";
            lblSalesmanName.Text = "Salesman Name:";
            lblOrderCounter.Text = "Order Counter:";
            lblOrderTerminal.Text = "Order Terminal:";
            lblOrderDate.Text = "Order Date:";
            chkBulkOrder.Checked = false;
            dtpDeliveryDate.Enabled = false;
            dtpTime.Enabled = false;
            cmbBoxType.SelectedIndex = 0;
            cmbBoxType.Enabled = false;
            txtChequeNo.Text = "";
            txtChequeBank.Text = "";
            txtChequeDate.Text = "";
            txtEmail.Text = "";
            txtMobileNo.Text = "";
            txtCareOf.Text = "";
            txtAddress.Text = "";
            txtTotalDueAmount.Text = "";
            txtTotalPaidAmount.Text = "";
            txtTotalOutstandingAmount.Text = "";
            txtSettledDate.Text = "";
            txtCurrentTotalPaidAmount.Text = "";
            txtCurrentTotalOutstandingAmount.Text = "";
            dgv.DataSource = null;
            groupBox2.Enabled = false;
            groupBox4.Enabled = false;
            txtTokenNo.Focus();
        }

        private int GetIsBulkOrder()
        {
            if (chkBulkOrder.Checked)
                return 1;
            else
                return 0;

        }

        private int GetIsAdvanced()
        {
            int n = GetPaymentType();
            if (n == 3)
                return 1;
            else
                return 0;
        }

        private int GetPaymentType()
        {
            if (rdoFullSettlement.Checked==true)
                return 1;
            else if (rdoOnCredit.Checked==true)
                return 2;
            else if (rdoAdvanced.Checked==true)
                return 3;
            else
                return 0;
        }

        private int GetPaymentMode()
        {
            if (rdoCash.Checked==true)
                return 1;
            else if (rdoCheque.Checked==true)
                return 2;
            else if (rdoCard.Checked==true)
                return 3;
            else
                return 0;

        }


        private bool CheckValidationData()
        {
            if (txtCurrentTotalPaidAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please enter current paid amount", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrentTotalPaidAmount.Focus();
                return false;
            }
            else if (txtCurrentTotalOutstandingAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please enter current total oustanding amount", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrentTotalOutstandingAmount.Focus();
                return false;
            }
            else if (chkBulkOrder.Checked)
            {
                if (dtpDeliveryDate.Text.Trim() == "")
                {
                    MessageBox.Show("Please select expected delivery date", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpDeliveryDate.Focus();
                    return false;

                }
                else if (dtpTime.Text.Trim() == "")
                {
                    MessageBox.Show("Please select expected delivery time", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpTime.Focus();
                    return false;
                }
                else if (txtMobileNo.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter mobile number", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMobileNo.Focus();
                    return false;
                }
                else if (txtCareOf.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter care of name", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCareOf.Focus();
                    return false;
                }
                //else if (txtAddress.Text.Trim() == "")
                //{
                //    MessageBox.Show("Please enter address", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtAddress.Focus();
                //    return false;
                //}
                else if (rdoCheque.Checked)
                {
                    if (txtChequeNo.Text.Trim() == "")
                    {
                        MessageBox.Show("Please enter cheque no", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtChequeNo.Focus();
                        return false;
                    }
                    else if (txtChequeBank.Text.Trim() == "")
                    {
                        MessageBox.Show("Please enter bank", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtChequeBank.Focus();
                        return false;
                    }
                    else if (txtChequeDate.Text.Trim() == "")
                    {
                        MessageBox.Show("Please select date.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtChequeBank.Focus();
                        return false;
                    }
                    else
                        return true;
                }

                else
                    return true;
            }
            else if (rdoCheque.Checked)
            {
                if (txtChequeNo.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter cheque no", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtChequeNo.Focus();
                    return false;
                }
                else if (txtChequeBank.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter bank", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtChequeBank.Focus();
                    return false;
                }
                else if (txtChequeDate.Text.Trim() == "")
                {
                    MessageBox.Show("Please select date.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtChequeBank.Focus();
                    return false;
                }
                else
                    return true;
            }
            else if (rdoFullSettlement.Checked == true)
            {
                if (float.Parse(txtTotalOutstandingAmount.Text.Trim()) != float.Parse(txtCurrentTotalPaidAmount.Text.Trim()))
                {
                    MessageBox.Show("Please enter correct paid amount,current total paid amount should equal to total outstanding amount.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTokenNo.Focus();
                    return false;
                }
                else
                    return true;
            }
            else if (rdoOnCredit.Checked == true)
            {
                if (float.Parse(txtCurrentTotalPaidAmount.Text.Trim()) >= float.Parse(txtTotalOutstandingAmount.Text.Trim()))
                {
                    MessageBox.Show("Please enter correct paid amount,current total paid amount should be higher than from total outstanding amount.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCurrentTotalPaidAmount.Focus();
                    return false;
                }
                else
                    return true;

            }
            else if (float.Parse(txtTotalOutstandingAmount.Text.Trim())-float.Parse(txtCurrentTotalPaidAmount.Text.Trim()) <0)
            {
                MessageBox.Show("Current total oustanding amount can not be negative, please enter correct amount.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrentTotalPaidAmount.Focus();
                return false;
            }
            else
                return true;
        }

        private int InsertOrderPaymentData(Int64 OrderID, float OutstandingAmount, float CollectedAmount, float OutstandingDueAmount, int PaymentType, int PaymentMode, string ChequeNo,
                                           string ChequeBank, string ChequeDate, int IsAdvanced, string MobileNo, string Email, string CareOf, string Address, int IsBulkOrder,
                                           string ExpectedDeleveryDate, string ExpectedDeleveryTime, int UserID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertOrderPayment", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OrderID", OrderID);
                        cmd.Parameters.AddWithValue("@OutstandingAmount", Math.Round(OutstandingAmount,2));
                        cmd.Parameters.AddWithValue("@CollectedAmount", Math.Round(CollectedAmount,2));
                        cmd.Parameters.AddWithValue("@OutstandingDueAmount", Math.Round(OutstandingDueAmount,2));
                        cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
                        cmd.Parameters.AddWithValue("@PaymentMode", PaymentMode);
                        cmd.Parameters.AddWithValue("@ChequeNo", ChequeNo);
                        cmd.Parameters.AddWithValue("@ChequeBank", ChequeBank);
                        cmd.Parameters.AddWithValue("@ChequeDate", ChequeDate);
                        cmd.Parameters.AddWithValue("@IsAdvanced", IsAdvanced);
                        cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@CareOf", CareOf);
                        cmd.Parameters.AddWithValue("@Address", Address);
                        cmd.Parameters.AddWithValue("@IsBulkOrder", IsBulkOrder);
                        cmd.Parameters.AddWithValue("@ExpectedDeleveryDate", ExpectedDeleveryDate);
                        cmd.Parameters.AddWithValue("@ExpectedDeleveryTime", ExpectedDeleveryTime);
                        cmd.Parameters.AddWithValue("@BoxID", cmbBoxType.SelectedValue);
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        int n = cmd.ExecuteNonQuery();
                        return n;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }


        private int OrderCanceled(Int64 OrderID, int UserID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("CanceledOrderByOrderID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OrderID", OrderID);
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        int n = cmd.ExecuteNonQuery();
                        return n;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }


        private bool CheckPaymentStatus(Int64 OrderID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetPaidStatus", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OrderID", OrderID);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private bool CheckCanceledStatus(Int64 OrderID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("CheckCanceledOrder", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OrderID", OrderID);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private void txtCurrentTotalPaidAmount_Leave(object sender, EventArgs e)
        {
            if (txtCurrentTotalPaidAmount.Text.Trim() != "")
            {
                float outstanding= (float.Parse(txtTotalOutstandingAmount.Text.Trim()) - float.Parse(txtCurrentTotalPaidAmount.Text.Trim()));
                txtCurrentTotalOutstandingAmount.Text = "" + Math.Round(outstanding,2);
            }
        }


        private void btnChequeDate_Click(object sender, EventArgs e)
        {
            if (monthChequeDate.Visible == false)
                monthChequeDate.Visible = true;
            else
                monthChequeDate.Visible = false;
        }

        private void monthChequeDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtChequeDate.Text = monthChequeDate.SelectionRange.Start.ToString("dd/MM/yyyy");
            monthChequeDate.Visible = false;
            txtEmail.Focus();
        }

        private void btnTaxInvoice_Click(object sender, EventArgs e)
        {
            if (txtTokenNo.Text == "")
            {
                MessageBox.Show("Please enter token no", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTokenNo.Focus();
                txtTokenNo.Focus();
            }
            else
            {
                bool PaymentStatusFlag = CheckPaymentStatus(Convert.ToInt64(txtTokenNo.Text.Trim()));
                if (PaymentStatusFlag == true)
                {
                    AppConfiguration a = new AppConfiguration();
                    a.OrderID = Convert.ToInt32(txtTokenNo.Text.Trim());
                    a.ReportNo = 1;

                    if (chkBulkOrder.Checked)
                    {
                        new frmPrintInvoiceCR().ShowDialog();
                    }
                    else
                    {
                        new frmPrintInvoice().ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Kindly make the payment first.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCurrentTotalPaidAmount.Focus();
                }
            }
        }

        private void btnCashMemo_Click(object sender, EventArgs e)
        {
            if (txtTokenNo.Text == "")
            {
                MessageBox.Show("Please enter token no");
                txtTokenNo.Focus();
                txtTokenNo.Focus();
            }
            else
            {
                bool PaymentStatusFlag = CheckPaymentStatus(Convert.ToInt64(txtTokenNo.Text.Trim()));
                if (PaymentStatusFlag == true)
                {
                    AppConfiguration a = new AppConfiguration();
                    a.OrderID = Convert.ToInt32(txtTokenNo.Text.Trim());
                    a.ReportNo = 2;

                    if (chkBulkOrder.Checked)
                    {
                        new frmPrintCashMemoCR().ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Kindly make the payment first.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCurrentTotalPaidAmount.Focus();
                }
            }
        }


        private void txtTokenNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtChequeNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtMobileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void rdoOnCredit_CheckedChanged(object sender, EventArgs e)
        {
            txtCurrentTotalPaidAmount.Text = "";
            txtCurrentTotalPaidAmount.Enabled = true;
            txtCurrentTotalPaidAmount.Focus();
            //txtCurrentTotalOutstandingAmount.Text = "" + (float.Parse(txtTotalOutstandingAmount.Text.Trim()) -
            //                            float.Parse(txtCurrentTotalPaidAmount.Text.Trim()));
        }

        private void rdoFullSettlement_CheckedChanged(object sender, EventArgs e)
        {
            //txtCurrentTotalOutstandingAmount.Text = "" + (float.Parse(txtTotalOutstandingAmount.Text.Trim()) -
            //                            float.Parse(txtCurrentTotalPaidAmount.Text.Trim()));
            txtCurrentTotalPaidAmount.Text = "" + float.Parse(txtTotalOutstandingAmount.Text.Trim());
            txtCurrentTotalPaidAmount.Enabled = false;
            btnSubmitOrder.Focus();
        }

        private void rdoAdvanced_CheckedChanged(object sender, EventArgs e)
        {
            txtCurrentTotalPaidAmount.Text = "";
            txtCurrentTotalPaidAmount.Enabled = true;
            txtCurrentTotalPaidAmount.Focus();
        }

        private void btnPaymentHistory_Click(object sender, EventArgs e)
        {
            if (txtTokenNo.Text.Trim() == "")
            {
                MessageBox.Show("Please enter token no.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTokenNo.Focus();
            }
            else
            {
                AppConfiguration a = new AppConfiguration();
                a.TokenNo = Convert.ToInt32(txtTokenNo.Text.Trim());
                new frmPaymentHistory().ShowDialog();
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            bool PaidFlag = CheckPaymentStatus(Convert.ToInt32(txtTokenNo.Text.Trim()));
            if (PaidFlag == true)
            {
                MessageBox.Show("The order cannot be cancelled since you have paid for it.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want to canceled the order?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Globals g = new Globals();
                    int n = OrderCanceled(Convert.ToInt64(txtTokenNo.Text.Trim()), g.UserID);
                    if (n > 0)
                    {
                        MessageBox.Show("The order has been successfully canceled.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearData();
                    }
                    else
                        MessageBox.Show("Failed to canceled order.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void rdoCheque_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCheque.Checked == true)
                grpCheque.Enabled = true;
            else
                grpCheque.Enabled = false;

        }

        private void rdoCash_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCheque.Checked == true)
                grpCheque.Enabled = true;
            else
                grpCheque.Enabled = false;

        }

        private void rdoCard_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCheque.Checked == true)
                grpCheque.Enabled = true;
            else
                grpCheque.Enabled = false;

        }

        private void btnSubmitOrder_MouseHover(object sender, EventArgs e)
        {
            if (txtCurrentTotalPaidAmount.Text.Trim() != "")
            {
                float outstanding = (float.Parse(txtTotalOutstandingAmount.Text.Trim()) - float.Parse(txtCurrentTotalPaidAmount.Text.Trim()));
                txtCurrentTotalOutstandingAmount.Text = "" + Math.Round(outstanding, 2);
            }
        }

        private void btnDuplicateToken_Click(object sender, EventArgs e)
        {
            if (txtTokenNo.Text == "")
            {
                MessageBox.Show("Please enter token no");
                txtTokenNo.Focus();
                txtTokenNo.Focus();
            }
            else
            {
                bool PaymentStatusFlag = CheckPaymentStatus(Convert.ToInt64(txtTokenNo.Text.Trim()));
                if (PaymentStatusFlag == true)
                {
                    AppConfiguration a = new AppConfiguration();
                    a.OrderID = Convert.ToInt32(txtTokenNo.Text.Trim());
                    a.ReportNo = 3;
                    new ViewReport().ShowDialog();
                }
                else
                {
                    MessageBox.Show("Kindly make the payment first.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCurrentTotalPaidAmount.Focus();
                }
            }
        }
    }
}
