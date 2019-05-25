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
    public partial class frmInventry : Form
    {
        string ConnString;
        public frmInventry()
        {
            InitializeComponent();
            Globals gb = new Globals();
            ConnString = gb.ConnString;
        }

        private void frmInventry_Load(object sender, EventArgs e)
        {
            this.Left = 100;
            this.Top = 25;
            Load_Inventry_data();
            Globals gb = new Globals();
            gb.FillDropdownList(ConnString, "GetActiveStatus", cmbActiveStatus, "StatusName", "StatusID");
            gb.FillDropdownList(ConnString, "GetAllActiveCategory", cmbCategoryID, "CategoryName", "CategoryID");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = CheckValidationData();
            if (flag == true)
            {
                if (txtBasePricePerKg.Text.Trim() == "")
                    txtBasePricePerKg.Text = "0";
                if (txtBasePricePerPiece.Text.Trim() == "")
                    txtBasePricePerPiece.Text = "0";
                if (txtHSNCode.Text.Trim() == "")
                    txtHSNCode.Text = "0";

                Globals gb = new Globals();
                int n = INSERT_Inventry_DATA(txtInventryName.Text.Trim(),Convert.ToInt32(cmbCategoryID.SelectedValue),float.Parse(txtBasePricePerPiece.Text.Trim()),
                        float.Parse(txtBasePricePerKg.Text.Trim()),0,txtHSNCode.Text.Trim(),gb.UserID,float.Parse(txtIGST.Text.Trim()));
                if (n > 0)
                {
                    Load_Inventry_data();
                    MessageBox.Show("New inventry master data has been successfully saved", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Failed to saved inventry master data.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool flag = CheckValidationData();
            if (flag == true)
            {
                if (txtBasePricePerKg.Text.Trim() == "")
                    txtBasePricePerKg.Text = "0";
                if (txtBasePricePerPiece.Text.Trim() == "")
                    txtBasePricePerPiece.Text = "0";
                if (txtHSNCode.Text.Trim() == "")
                    txtHSNCode.Text = "0";

                Globals gb = new Globals();
                int n = UPDATE_Inventry_DATA(gb.InventryID,txtInventryName.Text.Trim(), Convert.ToInt32(cmbCategoryID.SelectedValue), 
                    float.Parse(txtBasePricePerPiece.Text.Trim()),float.Parse(txtBasePricePerKg.Text.Trim()), 
                    0, txtHSNCode.Text.Trim(),Convert.ToInt32(cmbActiveStatus.SelectedValue), gb.UserID,float.Parse(txtIGST.Text.Trim()));
                if (n > 0)
                {
                    Load_Inventry_data();
                    MessageBox.Show("Inventry master data has been successfully updated", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Failed to update inventry master data.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dgv.Rows[rowIndex];
            int TID = Convert.ToInt32(row.Cells[0].Value);
            Globals gb = new Globals();
            gb.InventryID = TID;
            Load_Inventry_Data_By_InventryID(TID);
            cmbActiveStatus.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
        }

        private void Load_Inventry_Data_By_InventryID(int InventryID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetInventryDetailsByInventryID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@InventryID", InventryID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = (DataRow)dt.Rows[0];
                            txtInventryName.Text = "" + dr["InvName"];
                            cmbCategoryID.SelectedValue = "" + dr["CategoryID"];
                            txtBasePricePerPiece.Text = "" + dr["InvBasePricePerPiece"];
                            txtBasePricePerKg.Text = "" + dr["InvBasePricePerKG"];
                            txtHSNCode.Text = "" + dr["HSNCode"];
                            cmbActiveStatus.SelectedValue = "" + dr["IsActive"];
                            if (!dr.IsNull("IGST"))
                                txtIGST.Text = "" + dr["IGST"];
                            else
                                txtIGST.Text = "";
                            if (!dr.IsNull("CGST"))
                                txtCGST.Text = "" + dr["CGST"];
                            else
                                txtCGST.Text = "";
                            if (!dr.IsNull("SGST"))
                                txtSGST.Text = "" + dr["SGST"];
                            else
                                txtSGST.Text = "";

                        }
                        else
                        {
                            txtInventryName.Text = "";
                            cmbCategoryID.SelectedIndex = 0;
                            txtBasePricePerKg.Text = "";
                            txtBasePricePerKg.Text = "";
                            txtHSNCode.Text = "";
                            cmbActiveStatus.SelectedIndex = 0;
                            txtIGST.Text = "";
                            txtCGST.Text = "";
                            txtSGST.Text = "";
                        }
                    }
                }
            }
            catch (Exception)
            {
                txtInventryName.Text = "";
                cmbCategoryID.SelectedIndex = 0;
                txtBasePricePerKg.Text = "";
                txtBasePricePerKg.Text = "";
                txtHSNCode.Text = "";
                cmbActiveStatus.SelectedIndex = 0;
                txtIGST.Text = "";
                txtCGST.Text = "";
                txtSGST.Text = "";
            }
        }



        private bool CheckValidationData()
        {
            if (txtInventryName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter inventry name.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInventryName.Focus();
                return false;
            }
            else if (cmbCategoryID.SelectedText.ToString() == "Select")
            {
                MessageBox.Show("Please select category.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCategoryID.Focus();
                return false;
            }
            //else if (txtBasePricePerPiece.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please enter base price per piece.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtBasePricePerPiece.Focus();
            //    return false;
            //}
            //else if (txtBasePricePerKg.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please enter base price per kg.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtBasePricePerKg.Focus();
            //    return false;
            //}
            //else if (cmbTaxID.SelectedText.ToString() == "Select")
            //{
            //    MessageBox.Show("Please select tax category.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cmbTaxID.Focus();
            //    return false;
            //}
            else if (txtIGST.Text.Trim() == "")
            {
                MessageBox.Show("Please enter igst.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIGST.Focus();
                return false;

            }
            //else if (txtCGST.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please enter cgst.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtCGST.Focus();
            //    return false;

            //}
            //else if (txtSGST.Text.Trim()=="")
            //{
            //    MessageBox.Show("Please enter sgst.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtSGST.Focus();
            //    return false;

            //}
            else
                return true;
        }


        private void Load_Inventry_data()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetAllInventry", con))
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
            txtInventryName.Text = "";
            cmbCategoryID.SelectedIndex=0;
            txtBasePricePerPiece.Text = "0";
            txtBasePricePerKg.Text = "0";
            txtHSNCode.Text = "";
            txtIGST.Text = "";
            txtCGST.Text = "";
            txtSGST.Text = "";
            cmbActiveStatus.SelectedIndex = 0;
            btnUpdate.Enabled = false;
            cmbActiveStatus.Enabled = false;
            btnSave.Enabled = true;
            txtInventryName.Focus();
        }


        public int INSERT_Inventry_DATA(string InventryName, int CategoryID,float InventryBasePricePerPice, float InventryBasePricePerKg,
            int TaxID,string HSNCode,int UserID,float IGST)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertInventry", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@InvName", InventryName);
                        cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                        cmd.Parameters.AddWithValue("@InvBasePricePerPiece", InventryBasePricePerPice);
                        cmd.Parameters.AddWithValue("@InvBasePricePerKG", InventryBasePricePerKg);
                        cmd.Parameters.AddWithValue("@TaxID", TaxID);
                        cmd.Parameters.AddWithValue("@HSNCode", HSNCode);
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.Parameters.AddWithValue("@IGST", IGST);
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



        public int UPDATE_Inventry_DATA(int InventryID,string InventryName, int CategoryID, float InventryBasePricePerPice, float InventryBasePricePerKg, int TaxID, 
            string HSNCode,int IsActive, int UserID, float IGST)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateInventry", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@InvID", InventryID);
                        cmd.Parameters.AddWithValue("@InvName", InventryName);
                        cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                        cmd.Parameters.AddWithValue("@InvBasePricePerPiece", InventryBasePricePerPice);
                        cmd.Parameters.AddWithValue("@InvBasePricePerKG", InventryBasePricePerKg);
                        cmd.Parameters.AddWithValue("@TaxID", TaxID);
                        cmd.Parameters.AddWithValue("@HSNCode", HSNCode);
                        cmd.Parameters.AddWithValue("@IsActive", IsActive);
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.Parameters.AddWithValue("@IGST", IGST);
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



    }
}
