using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SMS
{
    class InventryOrder
    {

        public static int order_customerid = 0;
        public static string order_customername = "General Customer";
        public static int is_outside_up = 0;
        public static int orderitemid = 0;
        public static string orderitemname = "";
        public static float base_price_per_piece = 0;
        public static float base_price_per_kg = 0;
        public static float order_igst = 0;
        public static float order_cgst = 0;
        public static float order_sgst = 0;
        public static int EmployeeID = 0;
        public static string EmployeeName = "";


        public int OrderCustomerID
        {
            get
            {
                return order_customerid;
            }
            set
            {
                order_customerid = value;
            }
        }
        public string OrderCustomerName
        {
            get
            {
                return order_customername;
            }
            set
            {
                order_customername = value;
            }
        }

        public int CustomerOutsideUP
        {
            get
            {
                return is_outside_up;
            }
            set
            {
                is_outside_up = value;
            }
        }
        public int OrderItemID
        {
            get
            {
                return orderitemid;
            }
            set
            {
                orderitemid = value;
            }
        }

        public string OrderItemName
        {
            get
            {
                return orderitemname;
            }
            set
            {
                orderitemname = value;
            }
        }

        public float OrderItemBasePricePerPiece
        {
            get
            {
                return base_price_per_piece;
            }
            set
            {
                base_price_per_piece = value;
            }
        }

        public float OrderItemBasePricePerKG
        {
            get
            {
                return base_price_per_kg;
            }
            set
            {
                base_price_per_kg = value;
            }
        }


        public float OrderIGST
        {
            get
            {
                return order_igst;
            }
            set
            {
                order_igst = value;
            }
        }

        public float OrderCGST
        {
            get
            {
                return order_cgst;
            }
            set
            {
                order_cgst = value;
            }
        }

        public float OrderSGST
        {
            get
            {
                return order_sgst;
            }
            set
            {
                order_sgst = value;
            }
        }

        public int OrderEmployeeID
        {
            get
            {
                return EmployeeID;
            }
            set
            {
                EmployeeID = value;
            }
        }


        public string OrderEmployeeName
        {
            get
            {
                return EmployeeName;
            }
            set
            {
                EmployeeName = value;
            }
        }





    }
}
