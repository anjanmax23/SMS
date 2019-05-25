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
    public partial class frmSetEmployee : Form
    {
        string ConnString;

        public frmSetEmployee()
        {
            InitializeComponent();
            Globals gb = new Globals();
            ConnString = gb.ConnString;

        }

        private void frmSetEmployee_Load(object sender, EventArgs e)
        {
            dgv.Top = 120;
            dgv.Left = 0;
            dgv.Width = Screen.PrimaryScreen.Bounds.Width;
            dgv.Height = Screen.PrimaryScreen.Bounds.Height - 120;
            Load_Customer_Data(txtCustomerName.Text.Trim());

        }

        private int SetOrderCustomerID(int TerminalID, int EmployeeID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SetEmployeeID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TerminalID", TerminalID);
                        cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
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


        private void Load_Customer_Data(String CustomeName)
        {
            try
            {
                dgv.DataSource = null;
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetEmployeeNameByEmployeeNameLike", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeeName", CustomeName);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            dgv.DataSource = dt;
                            dgv.Columns[0].Width = 110;
                            dgv.Columns[1].Width = 500;
                        }
                        else
                            dgv.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgv.DataSource = null;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new frmOrder().Show();

        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            Load_Customer_Data(txtCustomerName.Text.Trim());

        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dgv.Rows[rowIndex];
            int CID = Convert.ToInt32(row.Cells[0].Value);
            string C_Name = "" + row.Cells[1].Value;
            InventryOrder i = new InventryOrder();
            i.OrderEmployeeID = CID;
            i.OrderEmployeeName = C_Name;
            AppConfiguration c = new AppConfiguration();
            int n = SetOrderCustomerID(c.TerminalID, CID);
            if (n > 0)
            {
                this.Visible = false;
                this.Visible = false;
                this.Close();
                this.Hide();
                if (Application.OpenForms.OfType<frmPrintToken>().Any())
                {
                    frmPrintToken frm = new frmPrintToken();
                    frm.Visible = false;
                    frm.Close();
                    frm.Hide();
                }
                frmPrintToken frm1 = new frmPrintToken();
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Failed to set employee!!", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerName.Focus();
            }

        }

        private void dgv_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dgv.Rows[rowIndex];
            int CID = Convert.ToInt32(row.Cells[0].Value);
            string C_Name = "" + row.Cells[1].Value;
            InventryOrder i = new InventryOrder();
            i.OrderEmployeeID = CID;
            i.OrderEmployeeName = C_Name;
            AppConfiguration c = new AppConfiguration();
            int n = SetOrderCustomerID(c.TerminalID, CID);
            if (n > 0)
            {
                this.Visible = false;
                this.Visible = false;
                this.Close();
                this.Hide();
                if (Application.OpenForms.OfType<frmPrintToken>().Any())
                {
                    frmPrintToken frm = new frmPrintToken();
                    frm.Visible = false;
                    frm.Close();
                    frm.Hide();
                }
                frmPrintToken frm1 = new frmPrintToken();
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Failed to set employee!!", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerName.Focus();
            }

        }
    }
}
