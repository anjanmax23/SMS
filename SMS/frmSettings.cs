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
using System.Data.SqlClient;
using System.Configuration;

namespace SMS
{
    public partial class frmSettings : Form
    {
        string ConnString;
        public frmSettings()
        {
            InitializeComponent();
            Globals gb = new Globals();
            ConnString = gb.ConnString;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbCompanyID.SelectedIndex == 0)
            {
                MessageBox.Show("Please select company.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCompanyID.Focus();
            }
            else if (cmbCounterID.SelectedIndex == 0)
            {
                MessageBox.Show("Please select counter.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCounterID.Focus();
            }
            else if (cmbTerminalID.SelectedIndex == 0)
            {
                MessageBox.Show("Please select terminal.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTerminalID.Focus();
            }
            else
            {
                //string path = @"C:\Users\Pradeep\AppData\Roaming\SMS";
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\SMS"; 
                try
                {
                    // Determine whether the directory exists.
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    StreamWriter sw = new StreamWriter(path + "\\config.txt");
                    sw.WriteLine(cmbCounterID.SelectedValue);
                    sw.WriteLine(cmbTerminalID.SelectedValue);
                    sw.Flush();
                    sw.Close();
                    MessageBox.Show("Counter and Terminal successfully mapped with PC", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Visible = false;
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Application.Exit();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            Globals gb = new Globals();
            gb.FillDropdownList(ConnString, "GetAllActiveCompany", cmbCompanyID, "CompanyName", "CompanyID");
        }

        private void cmbCounterID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Globals gb = new Globals();
                int val =Convert.ToInt32(cmbCounterID.SelectedValue);
                gb.FillDropdownList(ConnString, "GetAllActiveTerminalByCounterID", cmbTerminalID, "TerminalName", "TerminalID", "@CounterID", val);
            }
            catch (Exception)
            { }


        }

        private void cmbCompanyID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Globals gb = new Globals();
                int val = Convert.ToInt32(cmbCompanyID.SelectedValue.ToString());
                gb.FillDropdownList(ConnString, "GetAllActiveCounterByCompanyID", cmbCounterID, "CounterName", "CounterID", "@CompanyID", val);
            }
            catch (Exception )
            { }
        }
    }
}
