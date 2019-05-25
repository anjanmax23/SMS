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
    public partial class frmChangePassword : Form
    {
        string ConnString;
        public frmChangePassword()
        {
            InitializeComponent();
            Globals gb = new Globals();
            ConnString = gb.ConnString;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool Flag = CheckValidationData();
            if (Flag == true)
            {
                AppConfiguration a = new AppConfiguration();
                UpdatePassword(a.UserID, txtCurrentPassword.Text.Trim(), txtNewPassword.Text.Trim());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        public void UpdatePassword(int UserID,string CurrentPassword ,string NewPassword)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("ChangePassword", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.Parameters.AddWithValue("@CurrentPassword", CurrentPassword);
                        cmd.Parameters.AddWithValue("@NewPassword", NewPassword);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = (DataRow)dt.Rows[0];
                            string status = "" + dr["Status"];
                            if (status == "1")
                            {
                                MessageBox.Show("Password has been successfully updated", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearData();
                            }
                            else if (status == "2")
                            {
                                MessageBox.Show("Current password does not match to previous password", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ClearData();
                            }
                        }
                        else
                        {
                            MessageBox.Show("You have not registered or your are in active, please contact to your administrator.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ClearData();
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ClearData()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtCurrentPassword.Focus();
        }

        private bool CheckValidationData()
        {
            if (txtCurrentPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please enter current password.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrentPassword.Text = "";
                return false;
            }
            else if (txtNewPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please enter new password.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewPassword.Text = "";
                return false;
            }
            else if (txtConfirmPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please enter confirm password.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmPassword.Text = "";
                return false;
            }
            else if (txtNewPassword.Text.Trim().Equals(txtConfirmPassword.Text.Trim()) == false)
            {
                MessageBox.Show("Confirm password does not math to new password.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            this.Left = 100;
            this.Top = 25;
            txtCurrentPassword.Focus();
        }
    }
}
