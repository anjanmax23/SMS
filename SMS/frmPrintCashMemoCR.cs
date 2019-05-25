using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace SMS
{

    public partial class frmPrintCashMemoCR : Form
    {
        string ConnString;
        public frmPrintCashMemoCR()
        {
            Globals gb = new Globals();
            InitializeComponent();
            ConnString = gb.ConnString;
        }

        private void frmPrintCashMemoCR_Load(object sender, EventArgs e)
        {
            AppConfiguration a = new AppConfiguration();
            GETCashMemoPrintStatus(a.OrderID);

            if (rdoCustomerCopy.Checked)
                lblSelectedCopy.Text = "Selected copy of: Consumer Copy";
            else if (rdoCollectionCopy.Checked)
                lblSelectedCopy.Text = "Selected copy of: Collection Copy";
            else if (rdoCollectionCopy.Checked)
                lblSelectedCopy.Text = "Selected copy of: Duplicate Copy";

        }

        private void rdoCashierCopy_CheckedChanged(object sender, EventArgs e)
        {
            lblSelectedCopy.Text = "Selected copy of: Customer Copy";

        }


        private void rdoCollectionCopy_CheckedChanged(object sender, EventArgs e)
        {
            lblSelectedCopy.Text = "Selected copy of: Collection Copy";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            AppConfiguration a = new AppConfiguration();
            if (rdoCustomerCopy.Checked)
                a.InvoiceCopyOf = "<< Customer Copy >>";
            if (rdoCollectionCopy.Checked)
                a.InvoiceCopyOf = "<< Collection Copy >>";
            if (rdoDuplicate.Checked)
                a.InvoiceCopyOf = "<< Duplicate Copy >>";
            new ViewReport().ShowDialog();
            UpdateCashMemoPrintStatus(a.OrderID);
            GETCashMemoPrintStatus(a.OrderID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void rdoDuplicate_CheckedChanged(object sender, EventArgs e)
        {
            lblSelectedCopy.Text = "Selected copy of: Duplicate Copy";
        }


        private int UpdateCashMemoPrintStatus(int OrderID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateCashMemoPrintStatusByOrderID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OrderID", OrderID);
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


        private void GETCashMemoPrintStatus(int OrderID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetCashMemoPrintStatus", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OrderID", OrderID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = (DataRow)dt.Rows[0];
                            int Status = Convert.ToInt32(dr["CashMemoPrint"]);
                            if (Status == 0)
                            {
                                rdoCustomerCopy.Checked = true;
                                rdoCustomerCopy.Enabled = true;
                                rdoCollectionCopy.Enabled = false;
                                rdoDuplicate.Enabled = false;
                            }
                            else if (Status == 1)
                            {
                                rdoCollectionCopy.Checked = true;
                                rdoCollectionCopy.Enabled = true;
                                rdoCustomerCopy.Enabled = false;
                                rdoDuplicate.Enabled = false;
                            }
                            else if (Status == 2)
                            {
                                rdoDuplicate.Checked = true;
                                rdoDuplicate.Enabled = true;
                                rdoCustomerCopy.Enabled = false;
                                rdoCollectionCopy.Enabled = false;
                            }
                            else
                            {
                                rdoDuplicate.Checked = true;
                                rdoDuplicate.Enabled = true;
                                rdoCustomerCopy.Enabled = false;
                                rdoCollectionCopy.Enabled = false;
                            }
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
