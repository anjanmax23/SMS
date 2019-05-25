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

    public partial class frmEmployeeMaster : Form
    {
        string ConnString;
        public frmEmployeeMaster()
        {
            InitializeComponent();
            Globals gb = new Globals();
            ConnString = gb.ConnString;
        }

        private void btnBrowseBOB_Click(object sender, EventArgs e)
        {
            if (monthDOB.Visible == false)
                monthDOB.Visible = true;
            else
                monthDOB.Visible = false;
        }

        private void btnBrowseJoing_Click(object sender, EventArgs e)
        {
            if (monthJoingDate.Visible == false)
                monthJoingDate.Visible = true;
            else
                monthJoingDate.Visible = false;
        }

        private void btnBrowseExitDate_Click(object sender, EventArgs e)
        {
            if (monthExitDate.Visible == false)
                monthExitDate.Visible = true;
            else
                monthExitDate.Visible = false;
        }

        private void monthDOB_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtDOB.Text = monthDOB.SelectionRange.Start.ToString("yyyy-MM-dd");
            monthDOB.Visible = false;
            cmbIDProof.Focus();
        }

        private void monthJoingDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtJoiningDate.Text = monthJoingDate.SelectionRange.Start.ToString("yyyy-MM-dd");
            monthJoingDate.Visible = false;
            rdoMale.Focus();
        }

        private void monthExitDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtExitDate.Text = monthExitDate.SelectionRange.Start.ToString("yyyy-MM-dd");
            monthExitDate.Visible = false;
            txtExitDate.Focus();
        }

        private void frmEmployeeMaster_Load(object sender, EventArgs e)
        {
            this.Left = 100;
            this.Top = 25;
            Load_EmployeeMaster_data();
            Globals gb = new Globals();
            gb.FillDropdownList(ConnString, "GetActiveStatus", cmbActiveStatus, "StatusName", "StatusID");
            gb.FillDropdownList(ConnString, "GetAllIDProof", cmbIDProof, "IDProofName", "IDProofID");
            gb.FillDropdownList(ConnString, "GetAllActiveCompany", cmbCompanyID, "CompanyName", "CompanyID");
            gb.FillDropdownList(ConnString, "GetAllActiveRoles", cmbRoleID, "RoleName", "RoleID");
        }

        private int GetGender()
        {
            if (rdoMale.Checked)
                return 1;
            else if (rdoFemale.Checked)
                return 0;
            else
                return -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = CheckValidationData();
            if (flag == true)
            {
                Globals gb = new Globals();
                int n = INSERT_EmployeeMaster_DATA(txtEmployeeName.Text.Trim(),txtDOB.Text.Trim(),Convert.ToInt32(cmbIDProof.SelectedValue),
                    txtIDProofNumber.Text.Trim(),txtFatherName.Text.Trim(),txtMotherName.Text.Trim(),txtSpauceName.Text.Trim(),
                    txtMobileNo.Text.Trim(),txtAddress.Text.Trim(),txtJoiningDate.Text.Trim(),GetGender(),
                    Convert.ToInt32(cmbCompanyID.SelectedValue),Convert.ToInt32(cmbRoleID.SelectedValue),txtExitDate.Text.Trim(), gb.UserID,
                    txtEPFNumber.Text.Trim(),txtAccountNumber.Text.Trim(),txtBankName.Text.Trim(),txtBankBranchName.Text.Trim());
                if (n > 0)
                {
                    Load_EmployeeMaster_data();
                    MessageBox.Show("New employee master data has been successfully saved", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Failed to saved employee master data.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool flag = CheckValidationData();
            if (flag == true)
            {
                Globals gb = new Globals();
                int n = Update_EmployeeMaster_DATA(gb.EmployeeID,txtEmployeeName.Text.Trim(), txtDOB.Text.Trim(), Convert.ToInt32(cmbIDProof.SelectedValue),
                    txtIDProofNumber.Text.Trim(), txtFatherName.Text.Trim(), txtMotherName.Text.Trim(), txtSpauceName.Text.Trim(),
                    txtMobileNo.Text.Trim(), txtAddress.Text.Trim(), txtJoiningDate.Text.Trim(), GetGender(),
                    Convert.ToInt32(cmbCompanyID.SelectedValue), Convert.ToInt32(cmbRoleID.SelectedValue), Convert.ToInt32(cmbActiveStatus.SelectedValue),
                    txtExitDate.Text.Trim(), gb.UserID,
                    txtEPFNumber.Text.Trim(), txtAccountNumber.Text.Trim(), txtBankName.Text.Trim(), txtBankBranchName.Text.Trim());
                if (n > 0)
                {
                    Load_EmployeeMaster_data();
                    MessageBox.Show("Employee master data has been successfully updated", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Failed to update employee master data.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }



        private void Load_EmployeeMaster_data()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetAllEmployeeMasterData", con))
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


        private void ClearData()
        {
            txtEmployeeName.Text = "";
            txtDOB.Text = "";
            cmbIDProof.SelectedIndex = 0;
            txtIDProofNumber.Text = "";
            txtFatherName.Text = "";
            txtMotherName.Text = "";
            txtSpauceName.Text = "";
            txtMobileNo.Text = "";
            txtAddress.Text = "";
            txtJoiningDate.Text = "";
            rdoMale.Checked = false;
            rdoFemale.Checked = false;
            cmbCompanyID.SelectedIndex = 0;
            cmbRoleID.SelectedIndex = 0;
            cmbActiveStatus.SelectedIndex = 0;
            txtExitDate.Text = "";
            txtEPFNumber.Text = "";
            txtAccountNumber.Text = "";
            txtBankName.Text = "";
            txtBankBranchName.Text = "";
            btnUpdate.Enabled = false;
            cmbActiveStatus.Enabled = false;
            btnSave.Enabled = true;
//            txtRoleName.Focus();
        }

        private bool CheckValidationData()
        {
            if (txtEmployeeName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter employee name.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeeName.Focus();
                return false;
            }
            else if (txtDOB.Text.Trim() == "")
            {
                MessageBox.Show("Please select dob.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDOB.Focus();
                return false;
            }
            else if (rdoMale.Checked==false && rdoFemale.Checked==false)
            {
                MessageBox.Show("Please select gender.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDOB.Focus();
                return false;
            }
            else if (cmbCompanyID.SelectedItem.ToString()=="Select")
            {
                MessageBox.Show("Please select company.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDOB.Focus();
                return false;
            }
            else if (cmbRoleID.SelectedItem.ToString() == "Select")
            {
                MessageBox.Show("Please select role id.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDOB.Focus();
                return false;
            }
            //    else
            //        return true;
            //
            return true;
        }



        public int INSERT_EmployeeMaster_DATA(String EmployeeName, String DOB, int IDProof, String IDProofNumber, String FatherName, String MotherName, 
            String SpouceName, String MobileNumber, String Addresses, String JoiningDate, int GenderID, int CompanyID, int RoleID, String ExitDate, int UserID,
            string EPFAccountNumber,string AccountNumber,string BankName,string BankBranchName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertEmployee", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                        cmd.Parameters.AddWithValue("@DOB", DOB);
                        cmd.Parameters.AddWithValue("@IDProof", IDProof);
                        cmd.Parameters.AddWithValue("@IDProofNumber", IDProofNumber);
                        cmd.Parameters.AddWithValue("@FatherName", FatherName);
                        cmd.Parameters.AddWithValue("@MotherName", MotherName);
                        cmd.Parameters.AddWithValue("@SpouceName", SpouceName);
                        cmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                        cmd.Parameters.AddWithValue("@Addresses", Addresses);
                        cmd.Parameters.AddWithValue("@JoiningDate", JoiningDate);
                        cmd.Parameters.AddWithValue("@GenderID", GenderID);
                        cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                        cmd.Parameters.AddWithValue("@RoleID", RoleID);
                        cmd.Parameters.AddWithValue("@ExitDate", ExitDate);
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.Parameters.AddWithValue("@EPFNumber", EPFAccountNumber);
                        cmd.Parameters.AddWithValue("@AccountNumber", AccountNumber);
                        cmd.Parameters.AddWithValue("@BankName", BankName);
                        cmd.Parameters.AddWithValue("@BankBranchName", BankBranchName);
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


        public int Update_EmployeeMaster_DATA(int EmployeeID,String EmployeeName, String DOB, int IDProof, String IDProofNumber, String FatherName,
            String MotherName, String SpouceName, String MobileNumber, String Addresses, String JoiningDate, int GenderID, 
            int CompanyID, int RoleID,int IsActive, String ExitDate, int UserID,string EPFAccountNumber,string AccountNumber,string BankName,string BankBranchName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateEmployee", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                        cmd.Parameters.AddWithValue("@DOB", DOB);
                        cmd.Parameters.AddWithValue("@IDProof", IDProof);
                        cmd.Parameters.AddWithValue("@IDProofNumber", IDProofNumber);
                        cmd.Parameters.AddWithValue("@FatherName", FatherName);
                        cmd.Parameters.AddWithValue("@MotherName", MotherName);
                        cmd.Parameters.AddWithValue("@SpouceName", SpouceName);
                        cmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                        cmd.Parameters.AddWithValue("@Addresses", Addresses);
                        cmd.Parameters.AddWithValue("@JoiningDate", JoiningDate);
                        cmd.Parameters.AddWithValue("@GenderID", GenderID);
                        cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                        cmd.Parameters.AddWithValue("@RoleID", RoleID);
                        cmd.Parameters.AddWithValue("@IsActive", IsActive);
                        cmd.Parameters.AddWithValue("@ExitDate", ExitDate);
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.Parameters.AddWithValue("@EPFNumber", EPFAccountNumber);
                        cmd.Parameters.AddWithValue("@AccountNumber", AccountNumber);
                        cmd.Parameters.AddWithValue("@BankName", BankName);
                        cmd.Parameters.AddWithValue("@BankBranchName", BankBranchName);
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

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dgv.Rows[rowIndex];
            int CID = Convert.ToInt32(row.Cells[0].Value);
 //           MessageBox.Show(""+CID);
            Globals gb = new Globals();
            gb.EmployeeID = CID;
            Load_EmployeeMaster_Data_By_EmployeeID(CID);
            cmbActiveStatus.Enabled = true;
            btnBrowseExitDate.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
        }


        private void Load_EmployeeMaster_Data_By_EmployeeID(int EmployeeID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetEmployeeDetailsByEmployeeID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = (DataRow)dt.Rows[0];
                            txtEmployeeName.Text = "" + dr["EmployeeName"];
                            txtDOB.Text = "" + dr["DOB"];
                            if (!dr.IsNull("IDProof"))
                                cmbIDProof.SelectedValue = "" + dr["IDProof"];
                            else
                                cmbIDProof.SelectedIndex = 0;
                            if (!dr.IsNull("IDProofNumber"))
                                txtIDProofNumber.Text = "" + dr["IDProofNumber"];
                            else
                                txtIDProofNumber.Text = "";
                            if(!dr.IsNull("FatherName"))
                                txtFatherName.Text = "" + dr["FatherName"];
                            else
                                txtFatherName.Text = "";
                            if(!dr.IsNull("MotherName"))
                                txtMotherName.Text = "" + dr["MotherName"];
                            else
                                txtMotherName.Text = "";
                            if(!dr.IsNull("SpouceName"))
                                txtSpauceName.Text = "" + dr["SpouceName"];
                            else
                                txtSpauceName.Text = "";
                            if(!dr.IsNull("MobileNumber"))
                                txtMobileNo.Text = "" + dr["MobileNumber"];
                            else
                                txtMobileNo.Text = "";
                            if(!dr.IsNull("Addresses"))
                                txtAddress.Text = "" + dr["Addresses"];
                            else
                                txtAddress.Text = "";
                            if(!dr.IsNull("JoiningDate"))
                                txtJoiningDate.Text = "" + dr["JoiningDate"];
                            else
                                txtJoiningDate.Text = "";
                            if (Convert.ToInt32(dr["GenderID"]) == 1)
                            {
                                rdoMale.Checked = true;
                                rdoFemale.Checked = false;
                            }
                            else if (Convert.ToInt32(dr["GenderID"]) == 0)
                            {
                                rdoFemale.Checked = true;
                                rdoMale.Checked = false;
                            }
                            cmbCompanyID.SelectedValue = "" + dr["CompanyID"];
                            cmbRoleID.SelectedValue = "" + dr["RoleID"];
                            cmbActiveStatus.SelectedValue = "" + dr["IsActive"];
                            if (!dr.IsNull("ExitDate"))
                                txtExitDate.Text = "" + dr["ExitDate"];
                            else
                                txtExitDate.Text = "";
                            if (!dr.IsNull("EPFNumber"))
                                txtEPFNumber.Text = "" + dr["EPFNumber"];
                            else
                                txtEPFNumber.Text = "";
                            if (!dr.IsNull("AccountNumber"))
                                txtAccountNumber.Text = "" + dr["AccountNumber"];
                            else
                                txtAccountNumber.Text = "";
                            if (!dr.IsNull("BankName"))
                                txtBankName.Text = "" + dr["BankName"];
                            else
                                txtBankName.Text = "";
                            if (!dr.IsNull("BankBranchName"))
                                txtBankBranchName.Text = "" + dr["BankBranchName"];
                            else
                                txtBankBranchName.Text = "";

                            txtEmployeeName.Focus();
                        }
                        else
                        {
                            txtEmployeeName.Text = "";
                            txtDOB.Text = "";
                            cmbIDProof.SelectedIndex = 0;
                            txtIDProofNumber.Text = "";
                            txtFatherName.Text = "";
                            txtMotherName.Text = "";
                            txtSpauceName.Text = "";
                            txtMobileNo.Text = "";
                            txtAddress.Text = "";
                            txtJoiningDate.Text = "";
                            rdoMale.Checked = false;
                            rdoFemale.Checked = false;
                            cmbCompanyID.SelectedIndex = 0;
                            cmbRoleID.SelectedIndex = 0;
                            cmbActiveStatus.SelectedIndex = 0;
                            txtExitDate.Text = "";
                        }
                    }
                }
            }
            catch (Exception)
            {
                txtEmployeeName.Text = "";
                txtDOB.Text = "";
                cmbIDProof.SelectedIndex = 0;
                txtIDProofNumber.Text = "";
                txtFatherName.Text = "";
                txtMotherName.Text = "";
                txtSpauceName.Text = "";
                txtMobileNo.Text = "";
                txtAddress.Text = "";
                txtJoiningDate.Text = "";
                rdoMale.Checked = false;
                rdoFemale.Checked = false;
                cmbCompanyID.SelectedIndex = 0;
                cmbRoleID.SelectedIndex = 0;
                cmbActiveStatus.SelectedIndex = 0;
                txtExitDate.Text = "";
            }
        }



    }
}
