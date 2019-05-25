using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace SMS
{
    class Globals
    {
//        private static string connstring = "" + ConfigurationManager.ConnectionStrings["SMS.Properties.Settings.SMSConnectionString"].ToString();
        private static string connstring = "" ;
        public static int userid = 0;
        public static int roleid = 0;
        public static int companyid = 0;
        public static int taxid = 0;
        public static int categoryid = 0;
        public static int inventryid = 0;
        public static int employeeid = 0;
        public static int boxid = 0;
        public static int orderitemid = 0;
        public static string orderitemname = "";
        public static int customerid = 0;
        // Declare a Code property of type string:
        public string ConnString
        {
            get
            {
                return connstring;
            }
            set
            {
                connstring = value;
            }
        }

        // Declare a Name property of type string:
        public int UserID
        {
            get
            {
                return userid;
            }
            set
            {
                userid = value;
            }
        }

        // Declare a RoleID property of type int:
        public int RoleID
        {
            get
            {
                return roleid;
            }
            set
            {
                roleid = value;
            }
        }


        // Declare a RoleID property of type int:
        public int CompanyID
        {
            get
            {
                return companyid;
            }
            set
            {
                companyid = value;
            }
        }
        public int TaxID
        {
            get
            {
                return taxid;
            }
            set
            {
                taxid = value;
            }
        }

        public int CategoryID
        {
            get
            {
                return categoryid;
            }
            set
            {
                categoryid = value;
            }
        }

        public int InventryID
        {
            get
            {
                return inventryid;
            }
            set
            {
                inventryid = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return employeeid;
            }
            set
            {
                employeeid = value;
            }
        }

        public int BoxID
        {
            get
            {
                return boxid;
            }
            set
            {
                boxid = value;
            }
        }
        public int CustomerID
        {
            get
            {
                return customerid;
            }
            set
            {
                customerid = value;
            }
        }



        public void FillDropdownList(String ConnString, String QueryText,ComboBox  ddl, String DisplayMember, String ValueMember)
        {
            ddl.Items.Clear();
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand(QueryText, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.NewRow();
                        dr[DisplayMember] = "Select";
                        dr[ValueMember] = 0;
                        dt.Rows.InsertAt(dr, 0);
                        ddl.DataSource = dt;
                        ddl.DisplayMember = DisplayMember;
                        ddl.ValueMember = ValueMember;
                        ddl.SelectedIndex = 0;
                    }
                    else
                    {
                        ddl.DataSource = null;
                    }
                }
            }
        }



        public void FillDropdownList(String ConnString, String QueryText, ComboBox ddl, String DisplayMember, String ValueMember, String Param1Name, String Param1Value)
        {
            ddl.Items.Clear();
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand(QueryText, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(Param1Name, Param1Value);
                    cmd.CommandTimeout = 0;
                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.NewRow();
                        dr[DisplayMember] = "Select";
                        dr[ValueMember] = 0;
                        dt.Rows.InsertAt(dr, 0);
                        ddl.DataSource = dt;
                        ddl.DisplayMember = DisplayMember;
                        ddl.ValueMember = ValueMember;
                        ddl.SelectedIndex = 0;
                    }
                    else
                    {
                        ddl.DataSource = null;
                    }
                }
            }
        }


        public void FillDropdownList(String ConnString, String QueryText, ComboBox ddl, String DisplayMember, String ValueMember, String Param1Name, int Param1Value)
        {
            ddl.Items.Clear();
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand(QueryText, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(Param1Name, Param1Value);
                    cmd.CommandTimeout = 0;
                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.NewRow();
                        dr[DisplayMember] = "Select";
                        dr[ValueMember] = 0;
                        dt.Rows.InsertAt(dr, 0);
                        ddl.DataSource = dt;
                        ddl.DisplayMember = DisplayMember;
                        ddl.ValueMember = ValueMember;
                        ddl.SelectedIndex = 0;
                    }
                    else
                    {
                        ddl.DataSource = null;
                    }
                }
            }
        }



        public void FillDropdownList(String ConnString, String QueryText, ComboBox ddl, String DisplayMember, String ValueMember, String Param1Name, String Param1Value, String Param2Name, String Param2Value)
        {
            ddl.Items.Clear();
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand(QueryText, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(Param1Name, Param1Value);
                    cmd.Parameters.AddWithValue(Param2Name, Param2Value);
                    cmd.CommandTimeout = 0;
                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.NewRow();
                        dr[DisplayMember] = "Select";
                        dr[ValueMember] = 0;
                        dt.Rows.InsertAt(dr, 0);
                        ddl.DataSource = dt;
                        ddl.DisplayMember = DisplayMember;
                        ddl.ValueMember = ValueMember;
                        ddl.SelectedIndex = 0;
                    }
                    else
                    {
                        ddl.DataSource = null;
                    }
                }
            }
        }


        public void FillDropdownList(String ConnString, String QueryText, ComboBox ddl, String DisplayMember, String ValueMember, String Param1Name, String Param1Value, String Param2Name, int Param2Value)
        {
            ddl.Items.Clear();
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand(QueryText, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(Param1Name, Param1Value);
                    cmd.Parameters.AddWithValue(Param2Name, Param2Value);
                    cmd.CommandTimeout = 0;
                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.NewRow();
                        dr[DisplayMember] = "Select";
                        dr[ValueMember] = 0;
                        dt.Rows.InsertAt(dr, 0);
                        ddl.DataSource = dt;
                        ddl.DisplayMember = DisplayMember;
                        ddl.ValueMember = ValueMember;
                        ddl.SelectedIndex = 0;
                    }
                    else
                    {
                        ddl.DataSource = null;
                    }
                }
            }
        }


        public void FillDropdownList(String ConnString, String QueryText, ComboBox ddl, String DisplayMember, String ValueMember, String Param1Name, int Param1Value, String Param2Name, int Param2Value)
        {
            ddl.Items.Clear();
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand(QueryText, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(Param1Name, Param1Value);
                    cmd.Parameters.AddWithValue(Param2Name, Param2Value);
                    cmd.CommandTimeout = 0;
                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.NewRow();
                        dr[DisplayMember] = "Select";
                        dr[ValueMember] = 0;
                        dt.Rows.InsertAt(dr, 0);
                        ddl.DataSource = dt;
                        ddl.DisplayMember = DisplayMember;
                        ddl.ValueMember = ValueMember;
                        ddl.SelectedIndex = 0;
                    }
                    else
                    {
                        ddl.DataSource = null;
                    }
                }
            }
        }




    }

}
