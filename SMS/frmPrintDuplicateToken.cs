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
    public partial class frmPrintDuplicateToken : Form
    {
        string ConnString;
        public frmPrintDuplicateToken()
        {
            InitializeComponent();
            Globals gb = new Globals();
            ConnString = gb.ConnString;
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            GetQuantity(btnOne);
        }

        private void GetQuantity(Button btn)
        {
            txtTokenNo.Text = txtTokenNo.Text + btn.Text.Trim();
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            GetQuantity(btnTwo);
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            GetQuantity(btnThree);
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            GetQuantity(btnFour);
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            GetQuantity(btnFive);
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            GetQuantity(btnSix);
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            GetQuantity(btnSeven);
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            GetQuantity(btnEight);
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            GetQuantity(btnNine);
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            GetQuantity(btnZero);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtTokenNo.Text.Trim() == "")
            {
                MessageBox.Show("Please enter token no !!", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AppConfiguration a = new AppConfiguration();
                a.OrderID = Convert.ToInt32(txtTokenNo.Text.Trim());
                bool Flag = CheckOrderExistByOrderIDAndTerminalID(a.OrderID, a.TerminalID);
                if (Flag == false)
                {
                    MessageBox.Show("No any order by given token no on your terminal id", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
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
                    InsertDataFromMainToTemp(a.OrderID, a.TerminalID);
                    frmPrintToken frm1 = new frmPrintToken();
                    frm1.Show();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Visible = false;
            this.Close();
            this.Hide();
            if (Application.OpenForms.OfType<frmOrder>().Any())
            {
                frmOrder frm = new frmOrder();
                frm.Visible = false;
                frm.Close();
                frm.Hide();
            }
            frmOrder frm1 = new frmOrder();
            frm1.Show();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTokenNo.Text = "";
        }

        private int InsertDataFromMainToTemp(int OrderID,int TerminalID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("PrintDuplicateToken", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OrderID", OrderID);
                        cmd.Parameters.AddWithValue("@TerminalID", TerminalID);
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

        private bool CheckOrderExistByOrderIDAndTerminalID(int OrderID, int TerminalID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("CheckOrderExist", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OrderID", OrderID);
                        cmd.Parameters.AddWithValue("@TerminalID", TerminalID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                            return true;
                        else
                            return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void txtTokenNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
    }
}
