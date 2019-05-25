using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class frmBackupRestore : Form
    {
        public frmBackupRestore()
        {
            InitializeComponent();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            BackupAndRestoreDatabase b = new BackupAndRestoreDatabase();
            bool Flag = b.BackupDatabase();
            if (Flag == true)
                MessageBox.Show("Database has been successfully backup", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to backup database", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Bak files (*.bak)|*.bak|All files (*.*)|*.*";
            dialog.InitialDirectory = @"D:\Backup\";
            dialog.Title = "Please select an latest backup file to restore datababse.";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //Encrypt the selected file. I'll do this later. :)
                txtFilePath.Text = dialog.FileName;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (txtFilePath.Text.Trim() == "")
            {
                MessageBox.Show("Please select latest .bak file to restore.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnBrowse.Focus();
            }
            else
            {
                BackupAndRestoreDatabase b = new BackupAndRestoreDatabase();
                bool Flag = b.RestoreDatabase(txtFilePath.Text.Trim());
                if (Flag == true)
                    MessageBox.Show("Database has been successfully restored", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Failed to retored database", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
