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
    public partial class frmAdminReports : Form
    {
        public frmAdminReports()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnBrowseFromDate_Click(object sender, EventArgs e)
        {
            if (monthFromDate.Visible == false)
                monthFromDate.Visible = true;
            else
                monthFromDate.Visible = false;

        }

        private void btnBrowseToDate_Click(object sender, EventArgs e)
        {
            if (monthToDate.Visible == false)
                monthToDate.Visible = true;
            else
                monthToDate.Visible = false;
        }



        private void monthFromDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtFromDate.Text = monthFromDate.SelectionRange.Start.ToString("dd/MM/yyyy");
            monthFromDate.Visible = false;

        }


        private void monthToDate_DateSelected(object sender, DateRangeEventArgs e)
        {

            txtToDate.Text = monthToDate.SelectionRange.Start.ToString("dd/MM/yyyy");
            monthToDate.Visible = false;
        }

        private void btnGetReport_Click(object sender, EventArgs e)
        {
            if (txtFromDate.Text.Trim() == "")
            {
                MessageBox.Show("Please select from date", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFromDate.Focus();
            }
            else if (txtToDate.Text.Trim() == "")
            {
                MessageBox.Show("Please select to date", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtToDate.Focus();
            }
            else
            {
                AppConfiguration a = new AppConfiguration();
                a.AdminReportID = GetReportID();
                a.ReportFromDate = Convert.ToDateTime(txtFromDate.Text.Trim());
                a.ReportToDate = Convert.ToDateTime(txtToDate.Text.Trim());

                new frmAdminReportViewer().ShowDialog();

            }
        }

        private int GetReportID()
        {
            if (rdoBulkOrder.Checked)
                return 1;
            else if (rdoTaxableSaleRegister.Checked)
                return 2;
            else if (rdoGSTINSaleRegister.Checked)
                return 3;
            else if (rdoTotalSaleRegister.Checked)
                return 4;
            else if (rdoStockDetails.Checked)
                return 5;
            else
                return 0;
        }
    }
}
