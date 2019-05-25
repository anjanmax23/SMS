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
    public partial class frmSetCustomer : Form
    {
        string ConnString;

        public frmSetCustomer()
        {
            InitializeComponent();
            Globals gb = new Globals();
            ConnString = gb.ConnString;

        }

        private void Load_Customer_Data(String CustomeName)
        {
            try
            {
                dgv.DataSource = null;
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetCustomerNameByCustomerNameLike", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("CustomerName", CustomeName);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            dgv.DataSource = dt;
                            dgv.Columns[0].Width = 110;
                            dgv.Columns[1].Width = 460;
                            dgv.Columns[2].Width = 500;
                        }
                        else
                            dgv.DataSource = null;
                    }
                }
            }
            catch (Exception)
            {
                dgv.DataSource = null;
            }
        }

        private void frmSetCustomer_Load(object sender, EventArgs e)
        {
            dgv.Top = 120;
            dgv.Left = 0;
            dgv.Width = Screen.PrimaryScreen.Bounds.Width;
            dgv.Height= Screen.PrimaryScreen.Bounds.Height-120;
            Load_Customer_Data(txtCustomerName.Text.Trim());

        }

        private int SetOrderCustomerID(int TerminalID, int CustomerID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SetCustomerID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TerminalID", TerminalID);
                        cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
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


        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
                Load_Customer_Data(txtCustomerName.Text.Trim());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new frmOrder().Show();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int rowIndex = e.RowIndex;
            DataGridViewRow row = dgv.Rows[rowIndex];
            int CID = Convert.ToInt32(row.Cells[0].Value);
            string C_Name = "" + row.Cells[1].Value;
            InventryOrder i = new InventryOrder();
            i.OrderCustomerID = CID;
            i.OrderCustomerName = C_Name;
            AppConfiguration c = new AppConfiguration();
            int n = SetOrderCustomerID(c.TerminalID, CID);
            if (n > 0)
            {
                this.Visible = false;
                new frmOrder().Show();
            }
            else
            {
                MessageBox.Show("Failed to set customer!!", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerName.Focus();
            }

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int rowIndex = e.RowIndex;
            DataGridViewRow row = dgv.Rows[rowIndex];
            int CID = Convert.ToInt32(row.Cells[0].Value);
            string C_Name = "" + row.Cells[1].Value;
            InventryOrder i = new InventryOrder();
            i.OrderCustomerID = CID;
            i.OrderCustomerName = C_Name;
            AppConfiguration c = new AppConfiguration();
            int n = SetOrderCustomerID(c.TerminalID, CID);
            if (n > 0)
            {
                this.Visible = false;
                new frmOrder().Show();
            }
            else
            {
                MessageBox.Show("Failed to set customer!!", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerName.Focus();
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dgv.Rows[rowIndex];
            int CID = Convert.ToInt32(row.Cells[0].Value);
            string C_Name = "" + row.Cells[1].Value;
            InventryOrder i = new InventryOrder();
            i.OrderCustomerID = CID;
            i.OrderCustomerName = C_Name;
            AppConfiguration c = new AppConfiguration();
            int n = SetOrderCustomerID(c.TerminalID, CID);
            if (n > 0)
            {
                this.Visible = false;
                new frmOrder().Show();
            }
            else
            {
                MessageBox.Show("Failed to set customer!!", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerName.Focus();
            }

        }
    }
}
