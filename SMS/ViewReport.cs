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
    public partial class ViewReport : Form
    {
        string ConnString;
        public ViewReport()
        {
            InitializeComponent();
            Globals gb = new Globals();
            ConnString = gb.ConnString;
        }

        private void ViewReport_Load(object sender, EventArgs e)
        {
            try
            {
                AppConfiguration a = new AppConfiguration();
                if (a.ReportNo == 1)
                    TaxInvoicePrint();
                else if (a.ReportNo == 2)
                    CashMemoPrint();
                else if (a.ReportNo == 3)
                    DuplicateTokenPrint();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TaxInvoicePrint()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetBulkOrderForPrintingByOrderID", con))
                    {
                        AppConfiguration a = new AppConfiguration();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OrderID", a.OrderID);
                        cmd.Parameters.AddWithValue("@InvoiceCopyOf", a.InvoiceCopyOf);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            rpt_BulkOrderPrint rpt = new rpt_BulkOrderPrint();
                            rpt.SetDataSource(dt);
//                            rpt.SetParameterValue("@InvoiceCopyOf", a.InvoiceCopyOf);

                            try
                            {
                                using (SqlConnection Subcon = new SqlConnection(ConnString))
                                {
                                    using (SqlCommand Subcmd = new SqlCommand("GetTaxGroupingDetailsForInvoiceByOrderID", Subcon))
                                    {
                                        Subcmd.CommandType = CommandType.StoredProcedure;
                                        Subcmd.Parameters.AddWithValue("@OrderID", a.OrderID);
                                        Subcmd.CommandTimeout = 0;
                                        Subcon.Open();
                                        SqlDataAdapter Subda = new SqlDataAdapter(Subcmd);
                                        DataTable Subdt = new DataTable();
                                        Subda.Fill(Subdt);
                                        if (Subdt.Rows.Count > 0)
                                        {
                                            TaxDetailsForBulkOrder Subrpt = new TaxDetailsForBulkOrder();
                                            Subrpt.SetDataSource(Subdt);
                                            rpt.Subreports[0].SetDataSource(Subdt);
                                        }
                                    }
                                }
                            }
                            catch (Exception)
                            {

                            }

                            //                            Load_CrystalReport_TaxData();
//                            TaxInvoicePrint_TaxData();
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



        private void CashMemoPrint()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetBulkOrderForPrintingByOrderID", con))
                    {
                        AppConfiguration a = new AppConfiguration();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OrderID", a.OrderID);
                        cmd.Parameters.AddWithValue("@InvoiceCopyOf", a.InvoiceCopyOf);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            rpt_CashMemoOrderPrint rpt = new rpt_CashMemoOrderPrint();
                            rpt.SetDataSource(dt);

                            try
                            {
                                using (SqlConnection Subcon = new SqlConnection(ConnString))
                                {
                                    using (SqlCommand Subcmd = new SqlCommand("GetTaxGroupingDetailsForInvoiceByOrderID", Subcon))
                                    {
                                        Subcmd.CommandType = CommandType.StoredProcedure;
                                        Subcmd.Parameters.AddWithValue("@OrderID", a.OrderID);
                                        Subcmd.CommandTimeout = 0;
                                        Subcon.Open();
                                        SqlDataAdapter Subda = new SqlDataAdapter(Subcmd);
                                        DataTable Subdt = new DataTable();
                                        Subda.Fill(Subdt);
                                        if (Subdt.Rows.Count > 0)
                                        {
                                            TaxDetailsForCashMemo Subrpt = new TaxDetailsForCashMemo();
                                            Subrpt.SetDataSource(Subdt);
                                            rpt.Subreports[0].SetDataSource(Subdt);
                                        }
                                    }
                                }
                            }
                            catch (Exception)
                            {

                            }

                            //                            Load_CrystalReport_TaxData();
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


        private void DuplicateTokenPrint()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetBulkOrderForPrintingByOrderID", con))
                    {
                        AppConfiguration a = new AppConfiguration();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OrderID", a.OrderID);
                        cmd.Parameters.AddWithValue("@InvoiceCopyOf", "<< Duplicate Copy >>");
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            rpt_TokenDuplicatePrint rpt = new rpt_TokenDuplicatePrint();
                            rpt.SetDataSource(dt);
                            try
                            {
                                using (SqlConnection Subcon = new SqlConnection(ConnString))
                                {
                                    using (SqlCommand Subcmd = new SqlCommand("GetTaxGroupingDetailsForInvoiceByOrderID", Subcon))
                                    {
                                        Subcmd.CommandType = CommandType.StoredProcedure;
                                        Subcmd.Parameters.AddWithValue("@OrderID", a.OrderID);
                                        Subcmd.CommandTimeout = 0;
                                        Subcon.Open();
                                        SqlDataAdapter Subda = new SqlDataAdapter(Subcmd);
                                        DataTable Subdt = new DataTable();
                                        Subda.Fill(Subdt);
                                        if (Subdt.Rows.Count > 0)
                                        {
                                            TaxDetailsForBulkOrder Subrpt = new TaxDetailsForBulkOrder();
                                            Subrpt.SetDataSource(Subdt);
                                            rpt.Subreports[0].SetDataSource(Subdt);
                                        }
                                    }
                                }
                            }
                            catch (Exception)
                            {

                            }
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
