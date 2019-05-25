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
    public partial class frmCompany : Form
    {
        string ConnString;
        public frmCompany()
        {
            InitializeComponent();
            Globals gb = new Globals();
            ConnString = gb.ConnString;
        }

        public int INSERT_COMPANY_DATA(string CompanyName, string ShopNumber,string StreetName, string Landmark,string City,string State,string ZipCode,
            string TANNumber,string PANNumber,string GSTNNumber,string CINNumber,string Phone,string Fax,string Landline,string Email,string WebURL,int UserID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertCompany", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
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


        public int UPDATE_COMPANY_DATA(int CompanyID,string CompanyName, string ShopNumber, string StreetName, string Landmark, string City, string State, string ZipCode,
            string TANNumber, string PANNumber, string GSTNNumber, string CINNumber, string Phone, string Fax, string Landline, string Email, string WebURL,
            int IsActive,string CloseDate,int UserID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateCompanyData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                        cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
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
                        cmd.Parameters.AddWithValue("@CloseDate", CloseDate);
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
                MessageBox.Show(ex.Message);
                return -1;
            }
        }


        private void Load_Company_data()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("getAllCompany", con))
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
            if (txtCompanyName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter company name.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCompanyName.Focus();
                return false;
            }
            else if (txtShopNumber.Text.Trim() == "")
            {
                MessageBox.Show("Please enter shop number.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtShopNumber.Focus();
                return false;
            }
            else if (txtStreetName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter street name.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStreetName.Focus();
                return false;
            }
            else if (txtLandmark.Text.Trim() == "")
            {
                MessageBox.Show("Please enter landmark.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLandmark.Focus();
                return false;
            }
            else if (txtCity.Text.Trim() == "")
            {
                MessageBox.Show("Please enter city.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCity.Focus();
                return false;
            }
            else if (txtState.Text.Trim() == "")
            {
                MessageBox.Show("Please enter state.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtState.Focus();
                return false;
            }
            else if (txtZipCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter zip code.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtZipCode.Focus();
                return false;
            }
            else
                return true;

        }


        private void ClearData()
        {
            txtCompanyName.Text = "";
            txtShopNumber.Text = "";
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
            txtPhoneNumber.Text = "";
            txtFax.Text = "";
            txtLandline.Text = "";
            txtEmail.Text = "";
            txtWebURL.Text = "";
            cmbActiveStatus.SelectedIndex = 0;
            txtCloseDate.Text = "";
            btnUpdate.Enabled = false;
            txtCloseDate.Enabled = false;
            cmbActiveStatus.Enabled = false;
            btnSave.Enabled = true;
            txtCompanyName.Focus();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = CheckValidationData();
            if (flag == true)
            {
                Globals gb = new Globals();
                int n=INSERT_COMPANY_DATA(txtCompanyName.Text.Trim(), txtShopNumber.Text.Trim(), txtStreetName.Text.Trim(), txtLandmark.Text.Trim(), txtCity.Text.Trim(),
                    txtState.Text.Trim(), txtZipCode.Text.Trim(), txtTANNumber.Text.Trim(), txtPANNumber.Text.Trim(), txtGSTNNumber.Text.Trim(), txtCINNumber.Text.Trim(),
                    txtPhoneNumber.Text.Trim(), txtFax.Text.Trim(), txtLandline.Text.Trim(), txtEmail.Text.Trim(), txtWebURL.Text.Trim(), gb.UserID);
                if (n > 0)
                {
                    Load_Company_data();
                    MessageBox.Show("New company master data has been successfully saved", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                    txtCompanyName.Focus();
                }
                else
                {
                    MessageBox.Show("Failed to saved company master data.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            this.Left = 25;
            this.Top = 25;
            Load_Company_data();
            Globals gb = new Globals();
            gb.FillDropdownList(ConnString, "GetActiveStatus", cmbActiveStatus, "StatusName", "StatusID");
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dgv.Rows[rowIndex];
            int CID =Convert.ToInt32(row.Cells[0].Value);
            Globals gb = new Globals();
            gb.CompanyID = CID;
            Load_Company_Data_By_CompanyID(CID);
            cmbActiveStatus.Enabled = true;
            txtCloseDate.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
        }


        private void Load_Company_Data_By_CompanyID(int CompanyID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetCompanyDataByCompanyID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = (DataRow)dt.Rows[0];
                            txtCompanyName.Text = "" + dr["CompanyName"];
                            txtShopNumber.Text = "" + dr["ShopNumber"];
                            txtStreetName.Text = "" + dr["StreetName"];
                            txtLandmark.Text = "" + dr["Landmark"];
                            txtCity.Text = "" + dr["City"];
                            txtState.Text = "" + dr["State"];
                            txtZipCode.Text = "" + dr["ZipCode"];
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
                                txtPhoneNumber.Text = "" + dr["Phone"];
                            else
                                txtPhoneNumber.Text = "";
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
                            cmbActiveStatus.SelectedValue = "" + dr["IsActive"];
                            if (!dr.IsNull("CloseDate"))
                                txtCloseDate.Text = "" + dr["CloseDate"];
                            else
                                txtCloseDate.Text = "";

                        }
                        else
                        {

                        }
                    }
                }
            }
            catch (Exception)
            {
                dgv.DataSource = null;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool flag = CheckValidationData();
            if (flag == true)
            {
                Globals gb = new Globals();
                int n = UPDATE_COMPANY_DATA(gb.CompanyID,txtCompanyName.Text.Trim(), txtShopNumber.Text.Trim(), txtStreetName.Text.Trim(), txtLandmark.Text.Trim(), txtCity.Text.Trim(),
                    txtState.Text.Trim(), txtZipCode.Text.Trim(), txtTANNumber.Text.Trim(), txtPANNumber.Text.Trim(), txtGSTNNumber.Text.Trim(), txtCINNumber.Text.Trim(),
                    txtPhoneNumber.Text.Trim(), txtFax.Text.Trim(), txtLandline.Text.Trim(), txtEmail.Text.Trim(), txtWebURL.Text.Trim(), 
                    Convert.ToInt32(cmbActiveStatus.SelectedValue),""+txtCloseDate.Text, gb.UserID);
                if (n > 0)
                {
                    Load_Company_data();
                    MessageBox.Show("Company master data has been successfully updated", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                    txtCompanyName.Focus();
                }
                else
                {
                    MessageBox.Show("Failed to update company master data.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCalender_Click(object sender, EventArgs e)
        {
            if (clr.Visible == false)
                clr.Visible = true;
            else
                clr.Visible = false;
        }

        private void clr_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtCloseDate.Text = clr.SelectionRange.Start.ToString("yyyy-MM-dd");
            clr.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }


    }


}
