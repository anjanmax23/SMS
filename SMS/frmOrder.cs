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
using System.Drawing.Printing;
using System.IO;
using System.Printing;
using Neodynamic.SDK.Printing;

namespace SMS
{
    public partial class frmOrder : Form
    {
        string ConnString;
        public frmOrder()
        {
            InitializeComponent();
            Globals gb = new Globals();
            ConnString = gb.ConnString;
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            Globals g = new Globals();
            if (g.ConnString != "")
            {
                AppConfiguration c = new AppConfiguration();
                lblCounter.Text = "Counter#: " + c.CounterID;
                lblTerminal.Text = "Terminal#: " + c.TerminalID;
                Load_Terminal_Order(c.TerminalID);
                Load_Order_header(c.TerminalID);
                int TokenPrintStatus = Check_Token_Print_Status(c.TerminalID);

                if (TokenPrintStatus == 0 && dgv.Rows.Count > 0)
                {
                    btnPrintToken.Enabled = true;
                    btnSetCustomer.Enabled = true;
                    btnEditOrder.Enabled = true;
                }
                else
                {
                    btnPrintToken.Enabled = false;
                    btnSetCustomer.Enabled = false;
                    btnEditOrder.Enabled = false;
                }
                Application.DoEvents();
                this.Refresh();
            }
        }

        private void btnPrintToken_Click(object sender, EventArgs e)
        {
            AppConfiguration a = new AppConfiguration();
//            int n=InsertTempDataToMain(a.TerminalID);
            Load_Terminal_Order(a.TerminalID);
            Load_Order_header(a.TerminalID);
            this.Visible = false;
            this.Close();
            this.Hide();
            if (Application.OpenForms.OfType<frmSetEmployee>().Any())
            {
                frmSetEmployee frm = new frmSetEmployee();
                frm.Close();
            }
            frmSetEmployee frm1 = new frmSetEmployee();
            frm1.Show();
         //            new frmPrintToken().ShowDialog();
        }

        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
            if (Application.OpenForms.OfType<frmEditOrder>().Any())
            {
                frmEditOrder frm = new frmEditOrder();
                frm.Close();
            }
            frmEditOrder frm1 = new frmEditOrder();
            frm1.Show();
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show("Are you sure you want to generate new order !!", "Alert Message", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
            //if (dialogResult == DialogResult.Yes)
            //{
                //do something
                AppConfiguration a = new AppConfiguration();
                DeleteTempOrder_By_TerminalID(a.TerminalID);
                lblCounter.Text = "Counter#: " + a.CounterID;
                lblTerminal.Text = "Terminal#: " + a.TerminalID;
                Load_Terminal_Order(a.TerminalID);
                Load_Order_header(a.TerminalID);
                btnEditOrder.Enabled = true;
            //}

        }

        private int DeleteTempOrder_By_TerminalID(int TerminalID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteTempOrder", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TerminalID", TerminalID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        int n = cmd.ExecuteNonQuery();
                        return n;
                    }
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }




        private void btnSetCustomer_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
            if (Application.OpenForms.OfType<frmSetCustomer>().Any())
            {
                frmSetCustomer frm = new frmSetCustomer();
                frm.Close();
            }
            frmSetCustomer frm1 = new frmSetCustomer();
            frm1.Show();

        }

        private void btnReports_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var list = (from object item in groupSubCategory.Controls where item is Button select item as Control).ToList();
            list.ForEach(x => groupSubCategory.Controls.Remove(x));
            this.Visible = false;
            new frmHome().Visible = true;
            //AppConfiguration a = new AppConfiguration();
            //DeleteTempOrder_By_TerminalID(a.TerminalID);

        }

        public void LOAD_CATEGORY_BUTTON()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetAllActiveCategory", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        int cnt = 0;
                        int Left = 19;
                        int Top = 19;
                        int Repeat = 0;

                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                DataRow dr = (DataRow)dt.Rows[i];
                                if (cnt == 5)
                                {
                                    Left = 19;
                                    Top =Top+101 ;
                                    Repeat = +1;
                                    cnt = 0;
                                }
                                Button button = new Button();
                                button.BackColor= System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                                button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                button.Location= new System.Drawing.Point(Left, Top);
                                button.Name =""+ dr["CategoryName"];
                                button.Size = new System.Drawing.Size(141, 95);
                                button.TabIndex = i;
                                button.Text = "" + dr["CategoryName"].ToString().ToUpper();
                                button.UseVisualStyleBackColor = false;
                                groupCategory.Controls.Add(button);
                                cnt = cnt+1;
                                Left = Left + 147;
                                button.Click += delegate
                                {
                                    // Your code
                                    var list = (from object item in groupSubCategory.Controls where item is Button select item as Control).ToList();
                                    list.ForEach(x => groupSubCategory.Controls.Remove(x));

                                    String Category = button.Text;
                                    LOAD_SUB_CATEGORY_BUTTON(Category);
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void frmOrder_Activated(object sender, EventArgs e)
        {

            Globals g = new Globals();
            if (g.ConnString != "")
            { 
                LOAD_CATEGORY_BUTTON();
                AppConfiguration a = new AppConfiguration();
                int TokenPrintStatus = Check_Token_Print_Status(a.TerminalID);
                if (TokenPrintStatus == 0)
                    btnEditOrder.Enabled = true;
                else
                    btnEditOrder.Enabled = false;

                if (TokenPrintStatus == 0 && dgv.Rows.Count > 0)
                {
                    btnPrintToken.Enabled = true;
                    btnSetCustomer.Enabled = true;
                }
                else
                {
                    btnPrintToken.Enabled = false;
                    btnSetCustomer.Enabled = false;
                }
                Application.DoEvents();
                this.Refresh();
            }
        }


        public void LOAD_SUB_CATEGORY_BUTTON(String CategoryName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetAllInventryByCategoryName", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        int cnt = 0;
                        int Left = 19;
                        int Top = 19;
                        int Repeat = 0;

                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                DataRow dr = (DataRow)dt.Rows[i];
                                if (cnt == 5)
                                {
                                    Left = 19;
                                    Top = Top + 101;
                                    Repeat = +1;
                                    cnt = 0;
                                }
                                Button button = new Button();
                                button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
                                button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                button.Location = new System.Drawing.Point(Left, Top);
                                button.Name = "" + dr["InvName"];
                                button.Size = new System.Drawing.Size(141, 95);
                                button.TabIndex = i;
                                button.Text = "" + dr["InvName"].ToString().ToUpper(); ;
                                button.UseVisualStyleBackColor = false;
                                groupSubCategory.Controls.Add(button);
                                cnt = cnt + 1;
                                Left = Left + 147;
                                AppConfiguration a = new AppConfiguration();
                                int TokenPrintStatus = Check_Token_Print_Status(a.TerminalID);
                                if (TokenPrintStatus == 0)
                                    button.Enabled = true;
                                else
                                    button.Enabled = false;

                                button.Click += delegate
                                {
                                    // Your code
                                    String SubCategory = button.Text;
                                    Pass_Inventry_Info(SubCategory);
                                    this.Visible = false;
                                    this.Close();
                                    this.Hide();
                                    if (Application.OpenForms.OfType<frmNewOrder>().Any())
                                    {
                                        frmNewOrder frm = new frmNewOrder();
                                        frm.Visible = false;
                                        frm.Close();
                                        frm.Hide();

                                    }
                                    frmNewOrder frm1 = new frmNewOrder();
                                    frm1.Show();
                                    //                                    MessageBox.Show(SubCategory);

                                };
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }


        public void Pass_Inventry_Info(String InventryName)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetInventryIDForOrderByItemName", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ItemName", InventryName);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = (DataRow)dt.Rows[0];
                            InventryOrder io = new InventryOrder();
                            io.OrderItemID = Convert.ToInt32(dr["InvID"]);
                            io.OrderItemName = InventryName;
                            io.OrderItemBasePricePerPiece =float.Parse(dr["InvBasePricePerPiece"].ToString());
                            io.OrderItemBasePricePerKG = float.Parse(dr["InvBasePricePerKG"].ToString());
                            io.OrderIGST = float.Parse(dr["IGST"].ToString());
                            io.OrderCGST = float.Parse(dr["CGST"].ToString());
                            io.OrderSGST = float.Parse(dr["SGST"].ToString());
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }


        private int GET_TAXPercentage_By_TaxID(int TaxID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetTaxDetailsByTaxID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TaxID", TaxID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = (DataRow)dt.Rows[0];
                            return Convert.ToInt32(dr["TaxPercentage"]);
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }



        private void Load_Terminal_Order(int TerminalID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetTerminalOrder", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TerminalID",TerminalID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            dgv.DataSource = dt;
                            dgv.Columns[0].Width = 37;
                            dgv.Columns[2].Width = 35;
                            dgv.Columns[3].Width = 40;
                        }
                        else
                        {
                            dgv.DataSource = null;
                        }
                    }
                }
            }
            catch (Exception)
            {
                dgv.DataSource = null;
            }
        }

        

        private int Check_Token_Print_Status(int TerminalID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetPrintStatus", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TerminalID", TerminalID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = (DataRow)dt.Rows[0];
                            int n = Convert.ToInt32(dr["TokenPrint"]);
                            return n;
                        }
                        else
                            return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private void Load_Order_header(int TerminalID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetTerminalTotalOrder", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TerminalID", TerminalID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = (DataRow)dt.Rows[0];
                            lblOrderDate.Text = "Order Date:" + dr["OrderDate"];
                            lblTokenNo.Text = "Token#: " + dr["OrderID"];
                            lblTime.Text = "Time: " + dr["Time"];
                            InventryOrder i = new InventryOrder();
                            i.OrderCustomerID = Convert.ToInt32(dr["CustomerID"]);
                            i.OrderCustomerName = "" + dr["CustomerName"];
                            lblCustomer.Text = "Customer: " + i.OrderCustomerName;
                            lblSalesMan.Text = "Salesman: " + dr["Salesman"];
                            lblTotalAmount.Text = "" + dr["TotalAmount"];
                            lblTax.Text = "" + dr["TaxAmount"];
                            lblNetINR.Text = "" + dr["NetAmount"];

                        }
                        else
                            dgv.DataSource = null;
                    }
                }
            }
            catch (Exception)
            {
                dgv.DataSource = null;
            }
        }


        private int InsertTempDataToMain(int TerminalID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERTOrderFromTempToMain", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TerminalID", TerminalID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        int n = cmd.ExecuteNonQuery();
                        return n;
                    }
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private void btnDuplicateToken_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Visible = false;
            this.Close();
            this.Hide();
            if (Application.OpenForms.OfType<frmPrintDuplicateToken>().Any())
            {
                frmPrintDuplicateToken frm = new frmPrintDuplicateToken();
                frm.Visible = false;
                frm.Close();
                frm.Hide();
            }
            frmPrintDuplicateToken frm1 = new frmPrintDuplicateToken();
            frm1.Show();

        }
    }
}
