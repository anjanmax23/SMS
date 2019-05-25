using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SMS
{
    public partial class frmSqlSetting : Form
    {
        public frmSqlSetting()
        {
            InitializeComponent();
        }


        private void frmSqlSetting_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool Flag = CheckValidationData();
            if (Flag == true)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SMS";
                try
                {
                    // Determine whether the directory exists.
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    StreamWriter sw = new StreamWriter(path + "\\server.txt");
                    sw.WriteLine(txtServerIP.Text.Trim());
                    sw.WriteLine(txtUserID.Text.Trim());
                    sw.WriteLine(txtPassword.Text.Trim());
                    sw.Flush();
                    sw.Close();
                    MessageBox.Show("Sql Server Configuration has been configured.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Visible = false;
                    Application.Exit();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Application.Exit();
        }

        private bool CheckValidationData()
        {
            if (txtServerIP.Text.Trim() == "")
            {
                MessageBox.Show("Please enter server ip or server host name.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtServerIP.Focus();
                return false; 
            }
            else if (txtUserID.Text.Trim()=="")
            {
                MessageBox.Show("Please enter user id.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserID.Focus();
                return false;
            }
            else if (txtPassword.Text.Trim()=="")
            {
                MessageBox.Show("Please enter password.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
