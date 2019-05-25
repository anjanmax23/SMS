using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            frmCompany childForm = new frmCompany();
            childForm.MdiParent = this;
            childForm.Show();
        }


        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void toolStripMenuTaxMaster_Click(object sender, EventArgs e)
        {
            frmTax childForm = new frmTax();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void CategoryMastertoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCategoryMaster childForm = new frmCategoryMaster();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void InventryMastertoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInventry childForm = new frmInventry();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void RoleMastertoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRoleMaster childForm = new frmRoleMaster();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void EmployeeMastertoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEmployeeMaster childForm = new frmEmployeeMaster();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void BoxMastertoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBoxMaster childForm = new frmBoxMaster();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            AppConfiguration a = new AppConfiguration();
            if (a.RoleID == 2)
                SettingstoolStripMenuItem1.Enabled = false;
            else if (a.RoleID == 3)
            {
                SettingstoolStripMenuItem1.Enabled = false;
                fileMenu.Enabled = false;
            }
        }

        private string GetMacAddress()
        {
            string macAddresses = string.Empty;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            return macAddresses;
        }

        private void appSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings childForm = new frmSettings();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void CustomertoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmCustomer childForm = new frmCustomer();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void orderPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPayment childForm = new frmPayment();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword childForm = new frmChangePassword();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmSqlSetting childForm = new frmSqlSetting();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void adminReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdminReports childForm = new frmAdminReports();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackupRestore childForm = new frmBackupRestore();
            childForm.MdiParent = this;
            childForm.Show();

        }

        private void customerMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer childForm = new frmCustomer();
            childForm.MdiParent = this;
            childForm.Show();
        }
    }
}
