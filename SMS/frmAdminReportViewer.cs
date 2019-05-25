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
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.Shared;

namespace SMS
{
    public partial class frmAdminReportViewer : Form
    {
        string ConnString;
        public frmAdminReportViewer()
        {
            InitializeComponent();
            Globals gb = new Globals();
            ConnString = gb.ConnString;
        }

        private void frmAdminReportViewer_Load(object sender, EventArgs e)
        {
            AppConfiguration a = new AppConfiguration();
            int AdminReportID = a.AdminReportID;
            if (AdminReportID == 1)
            {
                BulkReport();
            }
        }


        private void BulkReport()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetBulkOrderReport", con))
                    {
                        AppConfiguration a = new AppConfiguration();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FromDate", a.ReportFromDate);
                        cmd.Parameters.AddWithValue("@ToDate", a.ReportToDate);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            BulkReportForAdmin rpt = new BulkReportForAdmin();
                            rpt.SetDataSource(dt);
                            crystalReportViewer1.ShowGroupTreeButton = false;
                            crystalReportViewer1.ToolPanelView = ToolPanelViewType.None;
                            crystalReportViewer1.ReportSource = rpt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
