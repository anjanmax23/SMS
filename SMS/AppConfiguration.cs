using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS
{
    class AppConfiguration
    {
        public static int counterid = 0;
        public static int terminalid = 0;
        public static int orderid = 0;
        public static int roleid = 0;
        public static int userid = 0;
        public static int tokenno = 0;
        public static string username = "";
        public static int reportno = 0;
        public static string InvoiceCopy = "";

        public static int adminreportid = 0;
        public static DateTime reportfromdate;
        public static DateTime reporttodate;

        public int CounterID
        {
            get
            {
                return counterid;
            }
            set
            {
                counterid = value;
            }
        }
        public int TerminalID
        {
            get
            {
                return terminalid;
            }
            set
            {
                terminalid = value;
            }
        }

        public int OrderID
        {
            get
            {
                return orderid;
            }
            set
            {
                orderid = value;
            }
        }
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

        public String UserName
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public String InvoiceCopyOf
        {
            get
            {
                return InvoiceCopy;
            }
            set
            {
                InvoiceCopy = value;
            }
        }

        public int TokenNo
        {
            get
            {
                return tokenno;
            }
            set
            {
                tokenno = value;
            }
        }

        public int ReportNo
        {
            get
            {
                return reportno;
            }
            set
            {
                reportno = value;
            }
        }


        public int AdminReportID
        {
            get
            {
                return adminreportid;
            }
            set
            {
                adminreportid = value;
            }
        }

        public DateTime ReportFromDate
        {
            get
            {
                return reportfromdate;
            }
            set
            {
                reportfromdate = value;
            }
        }


        public DateTime ReportToDate
        {
            get
            {
                return reporttodate;
            }
            set
            {
                reporttodate = value;
            }
        }

    }

}
