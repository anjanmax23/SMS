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
    public partial class frmBoxMaster : Form
    {
        string ConnString;
        public frmBoxMaster()
        {
            InitializeComponent();
            Globals gb = new Globals();
            ConnString = gb.ConnString;
        }

        private void frmBoxMaster_Load(object sender, EventArgs e)
        {
            this.Left = 100;
            this.Top = 25;
            Load_BoxMaster_data();
            Globals gb = new Globals();
            gb.FillDropdownList(ConnString, "GetActiveStatus", cmbActiveStatus, "StatusName", "StatusID");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = CheckValidationData();
            if (flag == true)
            {
                Globals gb = new Globals();
                int n = INSERT_BoxMaster_DATA(txtBoxName.Text.Trim(), gb.UserID);
                if (n > 0)
                {
                    Load_BoxMaster_data();
                    MessageBox.Show("New box master data has been successfully saved", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Failed to saved box master data.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool flag = CheckValidationData();
            if (flag == true)
            {
                Globals gb = new Globals();
                int n = UPDATE_BoxMaster_DATA(gb.BoxID, txtBoxName.Text.Trim(),Convert.ToInt32(cmbActiveStatus.SelectedValue), gb.UserID);
                if (n > 0)
                {
                    Load_BoxMaster_data();
                    MessageBox.Show("Box master data has been successfully updated", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Failed to update box master data.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void Load_BoxMaster_data()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetAllBoxMaster", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            dgv.DataSource = dt;
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


        private bool CheckValidationData()
        {
            if (txtBoxName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter box name.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoxName.Focus();
                return false;
            }
            else
                return true;
        }

        private void ClearData()
        {
            txtBoxName.Text = "";
            cmbActiveStatus.SelectedIndex = 0;
            btnUpdate.Enabled = false;
            cmbActiveStatus.Enabled = false;
            btnSave.Enabled = true;
            txtBoxName.Focus();
        }


        public int INSERT_BoxMaster_DATA(string BoxName, int UserID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertBaxMaster", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BoxName", BoxName);
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        int n = cmd.ExecuteNonQuery();
                        return n;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        public int UPDATE_BoxMaster_DATA(int BoxID, string BoxName, int IsActive, int UserID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateBaxMaster", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BoxID", BoxID);
                        cmd.Parameters.AddWithValue("@BoxName", BoxName);
                        cmd.Parameters.AddWithValue("@IsActive", IsActive);
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        int n = cmd.ExecuteNonQuery();
                        return n;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dgv.Rows[rowIndex];
            int BID = Convert.ToInt32(row.Cells[0].Value);
            Globals gb = new Globals();
            gb.BoxID = BID;
            Load_BoxMaster_Data_By_BoxID(BID);
            cmbActiveStatus.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
        }

        private void Load_BoxMaster_Data_By_BoxID(int BoxID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetBoxMasterByBoxID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BoxID", BoxID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = (DataRow)dt.Rows[0];
                            txtBoxName.Text = "" + dr["BoxName"];
                            cmbActiveStatus.SelectedValue = "" + dr["IsActive"];

                        }
                        else
                        {
                            txtBoxName.Text = "";
                            cmbActiveStatus.SelectedValue = "";
                        }
                    }
                }
            }
            catch (Exception)
            {
                txtBoxName.Text = "";
                cmbActiveStatus.SelectedValue = "";
            }
        }


    }
}
