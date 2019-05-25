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
    public partial class frmCategoryMaster : Form
    {
        string ConnString;
        public frmCategoryMaster()
        {
            InitializeComponent();
            Globals gb = new Globals();
            ConnString = gb.ConnString;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = CheckValidationData();
            if (flag == true)
            {
                Globals gb = new Globals();
                int n = INSERT_CATEGORY_DATA(txtCategoryName.Text.Trim(), gb.UserID);
                if (n > 0)
                {
                    Load_Category_data();
                    MessageBox.Show("New category master data has been successfully saved", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Failed to saved category master data.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearData()
        {
            txtCategoryName.Text = "";
            cmbActiveStatus.SelectedIndex = 0;
            btnUpdate.Enabled = false;
            cmbActiveStatus.Enabled = false;
            btnSave.Enabled = true;
            txtCategoryName.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool flag = CheckValidationData();
            if (flag == true)
            {
                Globals gb = new Globals();
                int n = UPDATE_CATEGORY_DATA(gb.CategoryID, txtCategoryName.Text.Trim(),Convert.ToInt32(cmbActiveStatus.SelectedValue), gb.UserID);
                if (n > 0)
                {
                    Load_Category_data();
                    MessageBox.Show("Category master data has been successfully updated", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Failed to update category master data.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void frmCategoryMaster_Load(object sender, EventArgs e)
        {
            this.Left = 100;
            this.Top = 25;
            Load_Category_data();
            Globals gb = new Globals();
            gb.FillDropdownList(ConnString, "GetActiveStatus", cmbActiveStatus, "StatusName", "StatusID");
        }

        private bool CheckValidationData()
        {
            if (txtCategoryName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter category name.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCategoryName.Focus();
                return false;
            }
            else
                return true;
        }


        public int INSERT_CATEGORY_DATA(string CategoryName, int UserID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertCategory", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
                        cmd.Parameters.AddWithValue("@UserID", UserID);
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


        public int UPDATE_CATEGORY_DATA(int CategoryID, string CategoryName, int IsActive, int UserID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateCategoryMaster", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                        cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
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



        private void Load_Category_data()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetAllCategory", con))
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

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dgv.Rows[rowIndex];
            int CID = Convert.ToInt32(row.Cells[0].Value);
            Globals gb = new Globals();
            gb.CategoryID = CID;
            Load_Category_Data_By_TaxID(CID);
            cmbActiveStatus.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
        }

        private void Load_Category_Data_By_TaxID(int CategoryID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetCategoryMasterByCategoryID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = (DataRow)dt.Rows[0];
                            txtCategoryName.Text = "" + dr["CategoryName"];
                            cmbActiveStatus.SelectedValue = "" + dr["IsActive"];

                        }
                        else
                        {
                            txtCategoryName.Text = "";
                            cmbActiveStatus.SelectedValue = "";
                        }
                    }
                }
            }
            catch (Exception)
            {
                txtCategoryName.Text = "";
                cmbActiveStatus.SelectedValue = "";
            }
        }

    }
}
