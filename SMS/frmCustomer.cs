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
    public partial class frmCustomer : Form
    {
        string ConnString;
        public frmCustomer()
        {
            InitializeComponent();
            Globals gb = new Globals();
            ConnString = gb.ConnString;
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            this.Left = 25;
            this.Top = 25;
            Globals gb = new Globals();
            gb.FillDropdownList(ConnString, "GetActiveStatus", cmbActiveStatus, "StatusName", "StatusID");
            gb.FillDropdownList(ConnString, "GetActiveStatus", cmbOutsideUP, "StatusName", "StatusID");
            Load_Customer_data();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = CheckValidationData();
            if (flag == true)
            {
                int IsRegistration = GetRegistration();
                Globals gb = new Globals();
                int n = INSERT_Customer_DATA(txtCustomerName.Text, IsRegistration, txtDistance.Text, txtShopNumber.Text, txtStreetName.Text, 
                    txtLandmark.Text, txtCity.Text,txtState.Text, txtZipCode.Text, txtTANNumber.Text, txtPANNumber.Text, txtGSTNNumber.Text, 
                    txtCINNumber.Text, txtPhone.Text, txtFax.Text, txtLandline.Text, txtEmail.Text, txtWebURL.Text, gb.UserID,
                    Convert.ToInt32(cmbOutsideUP.SelectedValue));
                if (n > 0)
                {
                    Load_Customer_data();
                    MessageBox.Show("New customer master data has been successfully saved", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Failed to saved customer master data.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool flag = CheckValidationData();
            if (flag == true)
            {
                int IsRegistration = GetRegistration();
                Globals gb = new Globals();
                int n = UPDATE_Customer_DATA(gb.CustomerID,txtCustomerName.Text, IsRegistration, txtDistance.Text, txtShopNumber.Text, txtStreetName.Text,
                    txtLandmark.Text, txtCity.Text, txtState.Text, txtZipCode.Text, txtTANNumber.Text, txtPANNumber.Text, txtGSTNNumber.Text,
                    txtCINNumber.Text, txtPhone.Text, txtFax.Text, txtLandline.Text, txtEmail.Text, txtWebURL.Text,Convert.ToInt32(cmbActiveStatus.SelectedValue),
                    gb.UserID,txtExitDate.Text,Convert.ToInt32(cmbOutsideUP.SelectedValue));
                if (n > 0)
                {
                    Load_Customer_data();
                    MessageBox.Show("Customer master data has been successfully updated", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Failed to update customer master data.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dgv.Rows[rowIndex];
            int CID = Convert.ToInt32(row.Cells[0].Value);
            Globals gb = new Globals();
            gb.CustomerID = CID;
            Load_Customer_Data_By_CustomerID(CID);
            cmbActiveStatus.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
        }


        private void Load_Customer_Data_By_CustomerID(int CustomerID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetCustomerMasterByCustomerID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = (DataRow)dt.Rows[0];
                            txtCustomerName.Text = "" + dr["CustomerName"];
                            int Status = Convert.ToInt32(dr["IsRegistered"]);
                            if (Status == 1)
                                rdoYes.Checked = true;
                            else if (Status == 0)
                                rdoNo.Checked = true;
                            if (!dr.IsNull("DistanceOrURP"))
                                txtDistance.Text = "" + dr["DistanceOrURP"];
                            else
                                txtDistance.Text = "";
                            if (!dr.IsNull("ShopNumber"))
                                txtShopNumber.Text = "" + dr["ShopNumber"];
                            else
                                txtShopNumber.Text = "";
                            if (!dr.IsNull("StreetName"))
                                txtStreetName.Text = "" + dr["StreetName"];
                            else
                                txtStreetName.Text = "";
                            if (!dr.IsNull("Landmark"))
                                txtLandmark.Text = "" + dr["Landmark"];
                            else
                                txtLandline.Text = "";
                            if (!dr.IsNull("City"))
                                txtCity.Text = "" + dr["City"];
                            else
                                txtCity.Text = "";
                            if (!dr.IsNull("State"))
                                txtState.Text = "" + dr["State"];
                            else
                                txtState.Text = "";
                            if (!dr.IsNull("ZipCode"))
                                txtZipCode.Text = "" + dr["ZipCode"];
                            else
                                txtZipCode.Text = "";
                            if (!dr.IsNull("TANNumber"))
                                txtTANNumber.Text = "" + dr["TANNumber"];
                            else
                                txtTANNumber.Text = "";
                            if (!dr.IsNull("PANNumber"))
                                txtPANNumber.Text = "" + dr["PANNumber"];
                            else
                                txtPANNumber.Text = "";
                            if (!dr.IsNull("GSTNNumber"))
                                txtGSTNNumber.Text = "" + dr["GSTNNumber"];
                            else
                                txtGSTNNumber.Text = "";
                            if (!dr.IsNull("CINNumber"))
                                txtCINNumber.Text = "" + dr["CINNumber"];
                            else
                                txtCINNumber.Text = "";
                            if (!dr.IsNull("Phone"))
                                txtPhone.Text = "" + dr["Phone"];
                            else
                                txtPhone.Text = "";
                            if (!dr.IsNull("Fax"))
                                txtFax.Text = "" + dr["Fax"];
                            else
                                txtFax.Text = "";
                            if (!dr.IsNull("Landline"))
                                txtLandline.Text = "" + dr["Landline"];
                            else
                                txtLandline.Text = "";
                            if (!dr.IsNull("Email"))
                                txtEmail.Text = "" + dr["Email"];
                            else
                                txtEmail.Text = "";
                            if (!dr.IsNull("WebURL"))
                                txtWebURL.Text = "" + dr["WebURL"];
                            else
                                txtWebURL.Text = "";
                            if (!dr.IsNull("ExitDate"))
                                txtExitDate.Text = "" + dr["ExitDate"];
                            else
                                txtExitDate.Text = "";
                            cmbActiveStatus.SelectedValue = "" + dr["IsActive"];
                            if (!dr.IsNull("IsOutsideUP"))
                                cmbOutsideUP.SelectedValue = "" + dr["IsOutsideUP"];
                            else
                                cmbOutsideUP.SelectedIndex = 0;
                        }
                        else
                        {
                            ClearData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
//                MessageBox.Show(ex.Message);
                ClearData();
            }
        }


        private int GetRegistration()
        {
            if (rdoYes.Checked == true)
                return 1;
            else
                return 0;
        }
        private void Load_Customer_data()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetAllCustomerMaster", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            dgv.DataSource = dt;
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

        private bool CheckValidationData()
        {
            if (txtCustomerName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter customer name.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerName.Focus();
                return false;
            }
            else if (rdoYes.Checked == false && rdoNo.Checked == false)
            {
                MessageBox.Show("Please select registration status.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rdoYes.Focus();
                return false;
            }
            else if (cmbOutsideUP.SelectedIndex == 0)
            {
                MessageBox.Show("Please select is outside up.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbOutsideUP.Focus();
                return false;
            }
            else
                return true;
        }


        private void ClearData()
        {
            txtCustomerName.Text = "";
            rdoYes.Checked = false;
            rdoNo.Checked = false;
            txtDistance.Text = "";
            txtShopNumber.Text = "";
            txtStreetName.Text = "";
            txtLandmark.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZipCode.Text = "";
            txtTANNumber.Text = "";
            txtPANNumber.Text = "";
            txtGSTNNumber.Text = "";
            txtCINNumber.Text = "";
            txtPhone.Text = "";
            txtFax.Text = "";
            txtLandline.Text = "";
            txtEmail.Text = "";
            txtWebURL.Text = "";
            cmbOutsideUP.SelectedIndex = 0;
            cmbActiveStatus.SelectedIndex = 0;
            btnUpdate.Enabled = false;
            cmbActiveStatus.Enabled = false;
            btnSave.Enabled = true;
            txtCustomerName.Focus();
        }


        public int INSERT_Customer_DATA(string CustomerName, int IsRegistered, string DistanceOrURP, string ShopNumber, string StreetName, string Landmark, string City, string State, string ZipCode, string TANNumber, string PANNumber, string GSTNNumber, string CINNumber, string Phone, string Fax, string Landline, string Email, string WebURL, int UserID,int IsOutsideUP)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertCustomer", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                        cmd.Parameters.AddWithValue("@IsRegistered", IsRegistered);
                        cmd.Parameters.AddWithValue("@DistanceOrURP", DistanceOrURP);
                        cmd.Parameters.AddWithValue("@ShopNumber", ShopNumber);
                        cmd.Parameters.AddWithValue("@StreetName", StreetName);
                        cmd.Parameters.AddWithValue("@Landmark", Landmark);
                        cmd.Parameters.AddWithValue("@City", City);
                        cmd.Parameters.AddWithValue("@State", State);
                        cmd.Parameters.AddWithValue("@ZipCode", ZipCode);
                        cmd.Parameters.AddWithValue("@TANNumber", TANNumber);
                        cmd.Parameters.AddWithValue("@PANNumber", PANNumber);
                        cmd.Parameters.AddWithValue("@GSTNNumber", GSTNNumber);
                        cmd.Parameters.AddWithValue("@CINNumber", CINNumber);
                        cmd.Parameters.AddWithValue("@Phone", Phone);
                        cmd.Parameters.AddWithValue("@Fax", Fax);
                        cmd.Parameters.AddWithValue("@Landline", Landline);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@WebURL", WebURL);
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.Parameters.AddWithValue("@IsOutsideUP", IsOutsideUP);
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

        public int UPDATE_Customer_DATA(int CustomerID,string CustomerName, int IsRegistered, string DistanceOrURP, string ShopNumber, string StreetName, 
            string Landmark, string City, string State, string ZipCode, string TANNumber, string PANNumber, string GSTNNumber, 
            string CINNumber, string Phone, string Fax, string Landline, string Email, string WebURL,int IsActive, int UserID,string ExitDate,int IsOutsideUP)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateCustomerMaster", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                        cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                        cmd.Parameters.AddWithValue("@IsRegistered", IsRegistered);
                        cmd.Parameters.AddWithValue("@DistanceOrURP", DistanceOrURP);
                        cmd.Parameters.AddWithValue("@ShopNumber", ShopNumber);
                        cmd.Parameters.AddWithValue("@StreetName", StreetName);
                        cmd.Parameters.AddWithValue("@Landmark", Landmark);
                        cmd.Parameters.AddWithValue("@City", City);
                        cmd.Parameters.AddWithValue("@State", State);
                        cmd.Parameters.AddWithValue("@ZipCode", ZipCode);
                        cmd.Parameters.AddWithValue("@TANNumber", TANNumber);
                        cmd.Parameters.AddWithValue("@PANNumber", PANNumber);
                        cmd.Parameters.AddWithValue("@GSTNNumber", GSTNNumber);
                        cmd.Parameters.AddWithValue("@CINNumber", CINNumber);
                        cmd.Parameters.AddWithValue("@Phone", Phone);
                        cmd.Parameters.AddWithValue("@Fax", Fax);
                        cmd.Parameters.AddWithValue("@Landline", Landline);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@WebURL", WebURL);
                        cmd.Parameters.AddWithValue("@IsActive", IsActive);
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.Parameters.AddWithValue("@ExitDate", ExitDate);
                        cmd.Parameters.AddWithValue("@IsOutsideUP", IsOutsideUP);
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

        private void btnBowseExitDate_Click(object sender, EventArgs e)
        {
            if (monthExitDate.Visible == true)
                monthExitDate.Visible = false;
            else
                monthExitDate.Visible = true;
        }


        private void monthExitDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtExitDate.Text = monthExitDate.SelectionRange.Start.ToString("yyyy-MM-dd");
            monthExitDate.Visible = false;
        }
    }
}
