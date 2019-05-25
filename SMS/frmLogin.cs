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
    public partial class frmLogin : Form
    {
        string ConnString;
        public frmLogin()
        {
            InitializeComponent();
            Globals gb = new Globals();
            ConnString = gb.ConnString;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.Left = 300;
            this.Top = 225;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            bool flag=LoginVerification(txtUserID.Text.Trim(), txtPassword.Text.Trim());
            if (flag == true)
            {
                Globals gb = new Globals();
                gb.UserID = Convert.ToInt32(txtUserID.Text.Trim());
                new frmHome().Hide();
                new frmHome().Visible = false;
                this.Visible = false;
                this.Hide();
                new MDIParent1().Show();
            }
            else
            {
                MessageBox.Show("Authentication Failed!! Invalid UserID Or Password.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool LoginVerification(string UserID, string Password)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("DoLogin", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = (DataRow)dt.Rows[0];
                            AppConfiguration a = new AppConfiguration();
                            a.UserID =Convert.ToInt32(dr["UserID"]);
                            a.UserName = "" + dr["EmployeeName"];
                            a.RoleID =Convert.ToInt32(dr["RoleID"]);
                            return true;
                        }
                        else
                            return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
