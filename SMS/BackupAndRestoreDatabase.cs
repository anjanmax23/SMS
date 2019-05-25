using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace SMS
{
    class BackupAndRestoreDatabase
    {
        string ConnString = "";

        public bool BackupDatabase()
        {
            try
            {
                Globals gb = new Globals();
                ConnString = gb.ConnString;
                string Path = "D:\\Backup\\SMS ";
                string cmd = "BACKUP DATABASE [SMS] TO DISK='"+ Path + DateTime.Now.ToString("yyyyMMdd HHmmss") + ".bak'";
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        con.Close();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool RestoreDatabase(String FilePath)
        {
            try
            {
                Globals gb = new Globals();
                ConnString = gb.ConnString;

                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    con.Open();
                    string sqlStmt2 = string.Format("ALTER DATABASE [SMS] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                    SqlCommand bu2 = new SqlCommand(sqlStmt2, con);
                    bu2.ExecuteNonQuery();

                    string sqlStmt3 = "USE MASTER RESTORE DATABASE [SMS] FROM DISK='" + FilePath + "'WITH REPLACE;";
                    SqlCommand bu3 = new SqlCommand(sqlStmt3, con);
                    bu3.ExecuteNonQuery();

                    string sqlStmt4 = string.Format("ALTER DATABASE [SMS] SET MULTI_USER");
                    SqlCommand bu4 = new SqlCommand(sqlStmt4, con);
                    bu4.ExecuteNonQuery();

                    con.Close();
                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }



    }
}
