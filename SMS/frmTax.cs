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
    public partial class frmTax : Form
    {
        string ConnString;
        public frmTax()
        {
            InitializeComponent();
            Globals gb = new Globals();
            ConnString = gb.ConnString;
        }

        private void frmTax_Load(object sender, EventArgs e)
        {
            this.Left = 100;
            this.Top = 25;
            Load_TAX_data();
            Globals gb = new Globals();
            gb.FillDropdownList(ConnString, "GetActiveStatus", cmbActiveStatus, "StatusName", "StatusID");
        }

        private bool CheckValidationData()
        {
            if (txtTaxName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter tax name.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTaxName.Focus();
                return false;
            }
            else if (txtPercentage.Text.Trim() == "")
            {
                MessageBox.Show("Please enter percentage.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPercentage.Focus();
                return false;
            }
            else
                return true;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = CheckValidationData();
            if (flag == true)
            {
                Globals gb = new Globals();
                int n = INSERT_TAX_DATA(txtTaxName.Text.Trim(), float.Parse(txtPercentage.Text.Trim()), gb.UserID);
                if (n > 0)
                {
                    Load_TAX_data();
                    MessageBox.Show("New tax master data has been successfully saved", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Failed to saved tax master data.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool flag = CheckValidationData();
            if (flag == true)
            {
                Globals gb = new Globals();
                int n = UPDATE_TAX_DATA(gb.TaxID, txtTaxName.Text.Trim(),float.Parse(txtPercentage.Text.Trim()), 
                        Convert.ToInt32(cmbActiveStatus.SelectedValue), gb.UserID);
                if (n > 0)
                {
                    Load_TAX_data();
                    MessageBox.Show("Tax master data has been successfully updated", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Failed to update tax master data.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }



        public int INSERT_TAX_DATA(string TaxName, float TaxPercentage, int UserID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertTaxMaster", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TaxName", TaxName);
                        cmd.Parameters.AddWithValue("@TaxPercentage", TaxPercentage);
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

        public int UPDATE_TAX_DATA(int TaxID, string TaxName, float TaxPercentage,int IsActive,int UserID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateTaxMaster", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TaxID", TaxID);
                        cmd.Parameters.AddWithValue("@TaxName", TaxName);
                        cmd.Parameters.AddWithValue("@TaxPercentage", TaxPercentage);
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


        private void Load_TAX_data()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetAllTaxMaster", con))
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




        private void ClearData()
        {
            txtTaxName.Text = "";
            txtPercentage.Text = "";
            cmbActiveStatus.SelectedIndex = 0;
            btnUpdate.Enabled = false;
            cmbActiveStatus.Enabled = false;
            btnSave.Enabled = true;
            txtTaxName.Focus();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dgv.Rows[rowIndex];
            int TID = Convert.ToInt32(row.Cells[0].Value);
            Globals gb = new Globals();
            gb.TaxID = TID;
            Load_Tax_Data_By_TaxID(TID);
            cmbActiveStatus.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
        }


        private void Load_Tax_Data_By_TaxID(int TaxID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetTaxDetailsByTaxID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TaxID", TaxID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = (DataRow)dt.Rows[0];
                            txtTaxName.Text = "" + dr["TaxName"];
                            txtPercentage.Text = "" + dr["TaxPercentage"];
                            cmbActiveStatus.SelectedValue = "" + dr["IsActive"];

                        }
                        else
                        {
                            txtTaxName.Text = "" ;
                            txtPercentage.Text = "" ;
                            cmbActiveStatus.SelectedValue = "" ;
                        }
                    }
                }
            }
            catch (Exception)
            {
                txtTaxName.Text = "";
                txtPercentage.Text = "";
                cmbActiveStatus.SelectedValue = "";
            }
        }




    }
}
