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
    public partial class frmRoleMaster : Form
    {
        string ConnString;
        public frmRoleMaster()
        {
            InitializeComponent();
            Globals gb = new Globals();
            ConnString = gb.ConnString;
        }

        private void frmRoleMaster_Load(object sender, EventArgs e)
        {
            this.Left = 100;
            this.Top = 25;
            Load_RoleMaster_data();
            Globals gb = new Globals();
            gb.FillDropdownList(ConnString, "GetActiveStatus", cmbActiveStatus, "StatusName", "StatusID");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = CheckValidationData();
            if (flag == true)
            {
                Globals gb = new Globals();
                int n = INSERT_RoleMaster_DATA(txtRoleName.Text.Trim(), gb.UserID);
                if (n > 0)
                {
                    Load_RoleMaster_data();
                    MessageBox.Show("New role master data has been successfully saved", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Failed to saved role master data.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool flag = CheckValidationData();
            if (flag == true)
            {
                Globals gb = new Globals();
                int n = UPDATE_RoleMaster_DATA(gb.RoleID, txtRoleName.Text.Trim(), Convert.ToInt32(cmbActiveStatus.SelectedValue), gb.UserID);
                if (n > 0)
                {
                    Load_RoleMaster_data();
                    MessageBox.Show("Role master data has been successfully updated", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Failed to update role master data.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            gb.RoleID = CID;
            Load_RoleMaster_Data_By_RoleID(CID);
            cmbActiveStatus.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
        }

        private void Load_RoleMaster_Data_By_RoleID(int RoleID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetRoleMasterDataByRoleID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RoleID", RoleID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = (DataRow)dt.Rows[0];
                            txtRoleName.Text = "" + dr["RoleName"];
                            cmbActiveStatus.SelectedValue = "" + dr["IsActive"];

                        }
                        else
                        {
                            txtRoleName.Text = "";
                            cmbActiveStatus.SelectedValue = "";
                        }
                    }
                }
            }
            catch (Exception)
            {
                txtRoleName.Text = "";
                cmbActiveStatus.SelectedValue = "";
            }
        }


        private void ClearData()
        {
            txtRoleName.Text = "";
            cmbActiveStatus.SelectedIndex = 0;
            btnUpdate.Enabled = false;
            cmbActiveStatus.Enabled = false;
            btnSave.Enabled = true;
            txtRoleName.Focus();
        }

        private bool CheckValidationData()
        {
            if (txtRoleName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter role name.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRoleName.Focus();
                return false;
            }
            else
                return true;
        }


        private void Load_RoleMaster_data()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetAllRoleMasterData", con))
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


        public int INSERT_RoleMaster_DATA(string RoleName, int UserID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertRoleMaster", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RoleName", RoleName);
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


        public int UPDATE_RoleMaster_DATA(int RoleID, string RoleName, int IsActive, int UserID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateRoleMaster", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RoleID", RoleID);
                        cmd.Parameters.AddWithValue("@RoleName", RoleName);
                        cmd.Parameters.AddWithValue("@IsActive", IsActive);
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



    }
}
