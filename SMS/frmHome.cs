using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
namespace SMS
{
    public partial class frmHome : Form
    {
        string ConnString;
        public frmHome()
        {
            InitializeComponent();
            Globals gb = new Globals();
            ConnString = gb.ConnString;
            Properties.Settings.Default.ConnectionString = gb.ConnString;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            AppConfiguration a = new AppConfiguration();
            DeleteTempOrder_By_TerminalID(a.TerminalID);
            Application.Exit();
        }


        private int DeleteTempOrder_By_TerminalID(int TerminalID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteTempOrder", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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

        private void btnAdministrator_Click(object sender, EventArgs e)
        {
            Globals gb = new Globals();
            if (gb.ConnString != "")
                new frmLogin().Show();
            else
                new frmSqlSetting().ShowDialog();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new frmOrder().Hide();
            new frmOrder().Show();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SMS";
            //if (!Directory.Exists(path))
            //{
            //    this.Visible = false;
            //    new frmSqlSetting().Show();
            //}

            int counter = 0;
            string line;
            AppConfiguration c = new AppConfiguration();

            if (File.Exists(path + "\\config.txt"))
            {
                System.IO.StreamReader file = new System.IO.StreamReader(path + "\\config.txt");
                while ((line = file.ReadLine()) != null)
                {
                    if (counter == 0)
                        c.CounterID = Convert.ToInt32(line);
                    else if (counter == 1)
                        c.TerminalID = Convert.ToInt32(line);

                    counter++;
                }

                file.Close();
                System.Console.WriteLine("There were {0} lines.", counter);
                // Suspend the screen.  
                System.Console.ReadLine();
            }

            if (File.Exists(path + "\\server.txt"))
            {

                counter = 0;
                SQLServer s = new SQLServer();
                System.IO.StreamReader serverfile = new System.IO.StreamReader(path + "\\server.txt");
                while ((line = serverfile.ReadLine()) != null)
                {
                    if (counter == 0)
                        s.ServerIP = "" + line;
                    else if (counter == 1)
                        s.ServerUserID = "" + line;
                    else if (counter == 2)
                        s.ServerPassword = "" + line;

                    counter++;
                }

                serverfile.Close();
                System.Console.WriteLine("There were {0} lines.", counter);
                // Suspend the screen.  
                System.Console.ReadLine();

                string AppConnectionString = String.Format("Data Source = {0}; Initial Catalog = SMS; Persist Security Info = True; User ID = {1}; Password = {2}", s.ServerIP, s.ServerUserID, s.ServerPassword);
                Globals g = new Globals();
                g.ConnString = AppConnectionString;

            }

            if (!File.Exists(path + "\\server.txt"))
            {
                this.Visible = false;
                new frmSqlSetting().Show();
            }
            else if (!File.Exists(path + "\\config.txt"))
            {
                this.Visible = false;
                new frmSettings().Show();
            }


        }

        private void btnCashier_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
        }
    }
}
