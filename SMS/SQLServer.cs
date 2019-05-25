
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS
{
    class SQLServer
    {
        public static string serverip = "";
        public static string serveruserid = "";
        public static string serverpassword = "";
        public static string appconnectionstring = "";
        public String ServerIP
        {
            get
            {
                return serverip;
            }
            set
            {
                serverip = value;
            }
        }

        public String ServerUserID
        {
            get
            {
                return serveruserid;
            }
            set
            {
                serveruserid = value;
            }
        }


        public String ServerPassword
        {
            get
            {
                return serverpassword;
            }
            set
            {
                serverpassword = value;
            }
        }


    }
}
