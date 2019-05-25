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
    public partial class frmEditOrder : Form
    {
        string ConnString;
        public frmEditOrder()
        {
            InitializeComponent();
            Globals gb = new Globals();
            ConnString = gb.ConnString;
        }

        private void frmEditOrder_Load(object sender, EventArgs e)
        {
            AppConfiguration c = new AppConfiguration();

            dgv.Top = 120;
            dgv.Left = 0;
            dgv.Width = Screen.PrimaryScreen.Bounds.Width;
            dgv.Height = Screen.PrimaryScreen.Bounds.Height - 120;
            groupBox1.Width= Screen.PrimaryScreen.Bounds.Width;
            Load_Terminal_Order(c.TerminalID);

        }


        private void Load_Terminal_Order(int TerminalID)
        {
            try
            {
                dgv.DataSource = null;
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetTerminalOrderForDelete", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TerminalID", TerminalID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            dgv.DataSource = dt;
                            dgv.Columns[0].Width = 37;
                            dgv.Columns[2].Width = 35;
                            dgv.Columns[3].Width = 40;

                            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                            dgv.Columns.Add(btn);
                            btn.HeaderText = "Delete";
                            btn.Text = "Delete";
                            btn.Name = "btnDelete";
                            btn.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
                            btn.UseColumnTextForButtonValue = true;
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Hide();
            this.Close();
            if (Application.OpenForms.OfType<frmOrder>().Any())
            {
                frmOrder frm = new frmOrder();
                frm.Hide();
                frm.Close();
            }
            frmOrder frm1 = new frmOrder();
            frm1.Show();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dgv.NewRowIndex || e.RowIndex < 0)
                return;

            //Check if click is on specific column 
            if (e.ColumnIndex == dgv.Columns["btnDelete"].Index)
            {
                //Put some logic here, for example to remove row from your binding list.
                int rowIndex = e.RowIndex;
                DataGridViewRow row = dgv.Rows[rowIndex];
                int TransID = Convert.ToInt32(row.Cells[1].Value);
                //DialogResult result = MessageBox.Show("Do you want to delete item?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                //if (result == DialogResult.Yes)
                //{
                    int n = DELETE_Item_DATA(TransID);
                    if (n > 0)
                    {
                        MessageBox.Show("Item has been successfully deleted", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AppConfiguration c = new AppConfiguration();
                        Load_Terminal_Order(c.TerminalID);
                        dgv.Columns.Remove("btnDelete");
                    }
                    else
                        MessageBox.Show("Failed to delete item", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

//                }
            }
        }


        public int DELETE_Item_DATA(int ItemID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteOrderItemByItemID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ItemID", ItemID);
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

    }
}
