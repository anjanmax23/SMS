using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace SMS
{
    public partial class frmPrintToken : Form
    {
        string ConnString;

        private System.Windows.Forms.PrintDialog prnDialog;
        private System.Windows.Forms.PrintPreviewDialog prnPreview;
        private System.Drawing.Printing.PrintDocument prnDocument;
        private System.ComponentModel.Container components = null;

        // for Invoice Head:
        private string InvTitle;
        private string InvSubTitle1;
        private string InvSubTitle2;
        private string InvSubTitle3;
        private string InvImage;

        // for Report:
        private int CurrentY;
        private int CurrentX;
        private int leftMargin;
        private int rightMargin;
        private int topMargin;
        private int bottomMargin;
        private int InvoiceWidth;
        private int InvoiceHeight;
        private string CustomerName;
        private string CustomerGSTNNo;
        private string InvoiceType;
        private string OrderNo;
        private string CounterNo;
        private string SalesMan;
        private string TerminalID;
        private string CustomerCity;
        private string SaleID;
        private string SaleDate;
        private decimal SaleFreight;
        private decimal SubTotal;
        private decimal InvoiceTotal;
        private bool ReadInvoice;
        private int AmountPosition;
        private float ItemValue=0;

        // Font and Color:------------------
        // Title Font
        private Font InvTitleFont = new Font("Arial", 10, FontStyle.Regular);
        // Title Font height
        private int InvTitleHeight;
        // SubTitle Font
        private Font InvSubTitleFont = new Font("Arial", 10, FontStyle.Bold);
        private Font InvSalutation = new Font("Arial", 10, FontStyle.Bold);
        // SubTitle Font height
        private int InvSubTitleHeight;
        // Invoice Font
        private Font InvoiceTitle = new Font("Arial", 8, FontStyle.Bold);
        private Font InvoiceFont = new Font("Arial", 8, FontStyle.Regular);
        // Invoice Font height
        private int InvoiceFontHeight;
        // Blue Color
        private SolidBrush BlueBrush = new SolidBrush(Color.Blue);
        // Red Color
        private SolidBrush RedBrush = new SolidBrush(Color.Red);
        // Black Color
        private SolidBrush BlackBrush = new SolidBrush(Color.Black);

        public frmPrintToken()
        {
            InitializeComponent();
            this.prnDialog = new System.Windows.Forms.PrintDialog();
            this.prnPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.prnDocument = new System.Drawing.Printing.PrintDocument();
            // The Event of 'PrintPage'
            prnDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(prnDocument_PrintPage);
            Globals gb = new Globals();
            ConnString = gb.ConnString;
            //InvTitleHeight = InvTitleHeight * 2;
            //InvSubTitleHeight = InvSubTitleHeight * 2;

        }


        private void ReadInvoiceHead()
        {
            AppConfiguration a = new AppConfiguration();
            try
            {

                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetCompanyDetailsByTerminalID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TerminalID", a.TerminalID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = (DataRow)dt.Rows[0];
                            //Titles and Image of invoice:
                            InvTitle = ""+dr["CompanyName"];
                            InvSubTitle1 = ""+dr["Address"];
                            InvSubTitle2 = "GSTIN No : " + dr["GSTNNumber"];
                            InvSubTitle3 = "Phone : "+dr["Phone"];
                            OrderNo = "" + dr["OrderNo"];
                            CustomerName = "" + dr["CustomerName"];
                            CustomerGSTNNo = "" + dr["CustomerGSTNNo"];
                            InvoiceType = "" + dr["InvoiceType"];
                            CounterNo = "" + dr["CounterNo"];
                            SalesMan = "" + dr["SalesMan"];
                            TerminalID = "" + dr["TerminalID"];
                            //      InvImage = Application.StartupPath + @"\Images\" + "InvPic.jpg";
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

        }


        private void ReadInvoiceData()
        {

        }

        private void SetInvoiceHead(Graphics g)
        {
            ReadInvoiceHead();

            CurrentY = topMargin;
            CurrentX = leftMargin;
            int ImageHeight = 0;

            // Draw Invoice image:
            if (System.IO.File.Exists(InvImage))
            {
                Bitmap oInvImage = new Bitmap(InvImage);
                // Set Image Left to center Image:
                int xImage = CurrentX + (InvoiceWidth - oInvImage.Width) / 2;
                ImageHeight = oInvImage.Height; // Get Image Height
                g.DrawImage(oInvImage, xImage, CurrentY);
            }

            InvTitleHeight = (int)(InvTitleFont.GetHeight(g));
            InvSubTitleHeight = (int)(InvSubTitleFont.GetHeight(g));

            // Get Titles Length:
            int lenInvTitle = (int)g.MeasureString(InvTitle, InvTitleFont).Width;
            int lenInvSubTitle1 = (int)g.MeasureString(InvSubTitle1, InvSubTitleFont).Width;
            int lenInvSubTitle2 = (int)g.MeasureString(InvSubTitle2, InvSubTitleFont).Width;
            int lenInvSubTitle3 = (int)g.MeasureString(InvSubTitle3, InvSubTitleFont).Width;
            // Set Titles Left:
            int xInvTitle = CurrentX + (InvoiceWidth - lenInvTitle) / 2;
            int xInvSubTitle1 = CurrentX + (InvoiceWidth - lenInvSubTitle1) / 2;
            int xInvSubTitle2 = CurrentX + (InvoiceWidth - lenInvSubTitle2) / 2;
            int xInvSubTitle3 = CurrentX + (InvoiceWidth - lenInvSubTitle3) / 2;

            // Draw Invoice Head:
            if (InvTitle != "")
            {
                CurrentY = CurrentY + ImageHeight;
                g.DrawString(InvTitle, InvTitleFont, BlueBrush, xInvTitle, CurrentY);
            }
            if (InvSubTitle1 != "")
            {
                CurrentY = CurrentY + InvTitleHeight;
                g.DrawString(InvSubTitle1, InvTitleFont, BlueBrush, xInvSubTitle1, CurrentY);
            }
            if (InvSubTitle2 != "")
            {
                CurrentY = CurrentY + InvSubTitleHeight;
                g.DrawString(InvSubTitle2, InvTitleFont, BlueBrush, xInvSubTitle2, CurrentY);
            }
            if (InvSubTitle3 != "")
            {
                CurrentY = CurrentY + InvSubTitleHeight;
                g.DrawString(InvSubTitle3, InvTitleFont, BlueBrush, xInvSubTitle3, CurrentY);
            }

            // Draw line:
            //CurrentY = CurrentY + InvSubTitleHeight + 8;
            //g.DrawLine(new Pen(Brushes.Black, 2), CurrentX, CurrentY, rightMargin, CurrentY);


            CurrentY = CurrentY + InvSubTitleHeight;
            String FieldValue = "TOKEN PRINT";
            int lenSalutation = (int)g.MeasureString(FieldValue, InvSalutation).Width;
            // Set Titles Left:
            int xSalutation = CurrentX + (InvoiceWidth - lenSalutation) / 2;
            g.DrawString(FieldValue, InvSalutation, BlueBrush, xSalutation, CurrentY);

            CurrentY = CurrentY + InvSubTitleHeight;
            FieldValue = "==>>"+ InvoiceType +"<<==";
            lenSalutation = (int)g.MeasureString(FieldValue, InvSalutation).Width;
            // Set Titles Left:
            xSalutation = CurrentX + (InvoiceWidth - lenSalutation) / 2;
            g.DrawString(FieldValue, InvSalutation, BlueBrush, xSalutation, CurrentY);

            CurrentY = CurrentY + InvSubTitleHeight;
        }



        private void SetOrderData(Graphics g)
        {// Set Company Name, City, Salesperson, Order ID and Order Date
            string FieldValue = "";
            InvoiceFontHeight = (int)(InvoiceFont.GetHeight(g));
            // Set Company Name:
            CurrentX = leftMargin-90;
            CurrentY = CurrentY + 8;
            for (int i = 10; i <= 250; i++)
                g.DrawString("-", InvoiceTitle, BlueBrush, i, CurrentY);
            CurrentX = leftMargin - 90;
            CurrentY = CurrentY + InvoiceFontHeight+ 8;
            FieldValue = OrderNo;
            g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);

            CurrentX = leftMargin - 90;
            CurrentY = CurrentY + InvoiceFontHeight;
            FieldValue = CounterNo;
            g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);

            CurrentX = leftMargin - 90;
            CurrentY = CurrentY + InvoiceFontHeight;
            FieldValue = TerminalID;
            g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);

            CurrentX = leftMargin - 90;
            CurrentY = CurrentY + InvoiceFontHeight;
            FieldValue = SalesMan;
            g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);

            CurrentX = leftMargin - 90;
            CurrentY = CurrentY + 16;
            for (int i = 10; i <= 250; i++)
                g.DrawString("-", InvoiceTitle, BlueBrush, i, CurrentY);

            CurrentX = leftMargin-90;
            CurrentY = CurrentY + InvoiceFontHeight+8;
            FieldValue = CustomerName;
            //String FieldValue1 = "";
            //if (FieldValue.Length > 40)
            //{
            //    FieldValue1 = FieldValue.Substring(41, FieldValue.Length - 41);
            //    FieldValue = FieldValue.Substring(0, 40);
            //}
            g.DrawString(FieldValue, InvoiceFont, BlueBrush, CurrentX, CurrentY);
            //CurrentY = CurrentY + InvoiceFontHeight;
            //g.DrawString(FieldValue1, InvoiceFont, BlueBrush, CurrentX, CurrentY);
            //CurrentY = CurrentY + InvoiceFontHeight;

            //g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);
            // Set Order ID:
            CurrentX = leftMargin-90;
            CurrentY = CurrentY + InvoiceFontHeight;
            FieldValue = CustomerGSTNNo;
            g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);
            // Set Order Date:
            CurrentY = CurrentY + InvoiceFontHeight;
            for (int i = 10; i <= 250; i++)
                g.DrawString("-", InvoiceTitle, BlueBrush, i, CurrentY);

        }

        private void SetInvoiceData(Graphics g, System.Drawing.Printing.PrintPageEventArgs e)
        {// Set Invoice Table:
            string FieldValue = "";
            int CurrentRecord = 0;
            int RecordsPerPage = 0; // twenty items in a page
            decimal Amount = 0;
            bool StopReading = false;
            // Set Table Head:
//            int xProductID = leftMargin;
            int xProductID = leftMargin-90;
            for(int i=10;i<=250;i++)
                g.DrawString("-", InvoiceTitle, BlueBrush, i, CurrentY);
            CurrentY = CurrentY + InvoiceFontHeight;
            g.DrawString("Sr", InvoiceTitle, BlueBrush, xProductID, CurrentY);

            int xProductName = xProductID + (int)g.MeasureString("Products", InvoiceFont).Width + 4;
            g.DrawString("Products", InvoiceTitle, BlueBrush, xProductName-30, CurrentY);

            int xQuantity = xProductName + (int)g.MeasureString("Qty", InvoiceFont).Width + 72;
            g.DrawString("Qty", InvoiceTitle, BlueBrush, xQuantity-50, CurrentY);


            int xUnit = xQuantity + (int)g.MeasureString("Unit", InvoiceFont).Width + 4;
            g.DrawString("Unit", InvoiceTitle, BlueBrush, xUnit-55, CurrentY);

            int xRate = xUnit + (int)g.MeasureString("Rate", InvoiceFont).Width + 4;
            g.DrawString("Rate", InvoiceTitle, BlueBrush, xRate-60, CurrentY);

            AmountPosition = xRate + (int)g.MeasureString("Amount", InvoiceFont).Width + 4;
            g.DrawString("Amount", InvoiceTitle, BlueBrush, AmountPosition-50, CurrentY);
            // Set Invoice Table:
            CurrentY = CurrentY + InvoiceFontHeight + 8;

            for (int i = 10; i <= 250; i++)
                g.DrawString("-", InvoiceTitle, BlueBrush, i, CurrentY);

            CurrentY = CurrentY + InvoiceFontHeight + 8;

            AppConfiguration a = new AppConfiguration();
            float TotalQuantity = 0;
            float TotalAmount = 0;
            float TotalTaxAmount = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetOrderForPrinting", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TerminalID", a.TerminalID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ItemValue = 0;
                        if (dt.Rows.Count > 0)
                        {
                            RecordsPerPage = Convert.ToInt32(dt.Rows.Count);
                            while (CurrentRecord < RecordsPerPage)
                            {
                                DataRow dr = (DataRow)dt.Rows[CurrentRecord];
                                FieldValue = ""+dr["SNO"];
                                g.DrawString(FieldValue, InvoiceFont, BlackBrush, xProductID, CurrentY);
                                FieldValue = ""+dr["ItemName"];
                                // if Length of (Product Name) > 20, Draw 20 character only
                                //if (FieldValue.Length > 50)
                                //    FieldValue = FieldValue.Remove(50, FieldValue.Length - 50);
                                g.DrawString(FieldValue, InvoiceFont, BlackBrush, xProductName-30, CurrentY);
                                CurrentY = CurrentY + InvoiceFontHeight;
                                FieldValue = ""+dr["Qty"];
                                float Quantity = float.Parse(FieldValue);
                                string taxamount = "" + dr["TaxAmount"];
                                string amount = "" + dr["Amount"];
                                float QuantityAmount = float.Parse(taxamount) + float.Parse(amount);
                                TotalAmount = TotalAmount + float.Parse(taxamount)+float.Parse(amount);
                                ItemValue = ItemValue + float.Parse(amount);
                                float RateAmount = QuantityAmount / Quantity;
                                TotalQuantity = TotalQuantity + float.Parse(FieldValue);
                                g.DrawString(FieldValue, InvoiceFont, BlackBrush, xQuantity-50, CurrentY);
                                FieldValue = ""+dr["Unit"];
                                g.DrawString(FieldValue, InvoiceFont, BlackBrush, xUnit-55, CurrentY);
                                FieldValue = String.Format("{0:0.00}", RateAmount);
                                g.DrawString(FieldValue, InvoiceFont, BlackBrush, xRate-60, CurrentY);

                                // Format Extended Price and Align to Right:
                                FieldValue = String.Format("{0:0.00}", (float.Parse(amount)+float.Parse(taxamount)));

                                int xAmount = AmountPosition + (int)g.MeasureString("Amount", InvoiceFont).Width;
                                xAmount = xAmount - (int)g.MeasureString(FieldValue, InvoiceFont).Width;
                                FieldValue = String.Format("{0:0.00}", QuantityAmount);
                                g.DrawString(FieldValue, InvoiceFont, BlackBrush, xAmount-50, CurrentY);
                                CurrentY = CurrentY + InvoiceFontHeight;

                                int xTax = leftMargin - 60;
                                TotalTaxAmount = TotalTaxAmount + float.Parse(taxamount);
//                                TotalAmount = TotalAmount + TotalTaxAmount;
                                FieldValue = "T "+String.Format("{0:0.00}",  dr["TaxRate"])+"% "+ String.Format("{0:0.00}", dr["TaxAmount"]);
                                g.DrawString(FieldValue, InvoiceFont, BlackBrush, xTax, CurrentY);


                                CurrentY = CurrentY + InvoiceFontHeight;
                                if (CurrentRecord== RecordsPerPage)
                                {
                                    StopReading = true;
                                    break;
                                }

                                CurrentRecord++;
                            }
                            for (int i = 10; i <= 250; i++)
                                g.DrawString("-", InvoiceTitle, BlueBrush, i, CurrentY);

                            CurrentY = CurrentY + InvoiceFontHeight;

                            int xTotal = leftMargin - 90;
                            FieldValue = "Total Qty:           " + String.Format("{0:0.00}", TotalQuantity) + "  Amt:                " + String.Format("{0:0.00}", TotalAmount);
                            g.DrawString(FieldValue, InvoiceTitle, BlueBrush, xTotal, CurrentY);

                            CurrentY = CurrentY + InvoiceFontHeight;
                            int xCurrency = leftMargin - 90;
                            string FieldValue1 = "";
                            FieldValue =  CurrencyConverter.AmountInWords(Convert.ToDecimal(TotalAmount));
                            if (FieldValue.Length > 40)
                            {
                                FieldValue1=FieldValue.Substring(41, FieldValue.Length-41);
                                FieldValue = FieldValue.Substring(0, 41);
                            }
                            g.DrawString(FieldValue, InvoiceFont, BlueBrush, xTotal, CurrentY);
                            CurrentY = CurrentY + InvoiceFontHeight;
                            g.DrawString(FieldValue1, InvoiceFont, BlueBrush, xTotal, CurrentY);
                            CurrentY = CurrentY + InvoiceFontHeight;
                            for (int i = 10; i <= 250; i++)
                                g.DrawString("-", InvoiceTitle, BlueBrush, i, CurrentY);
                            CurrentY = CurrentY + InvoiceFontHeight;

                            int xTaxAmount = leftMargin - 90;
                            FieldValue = "Item Value:                                               " + String.Format("{0:0.00}", ItemValue);
                            g.DrawString(FieldValue, InvoiceFont, BlackBrush, xTotal, CurrentY);
                            CurrentY = CurrentY + InvoiceFontHeight;


                            try
                            {
                                using (SqlConnection con1 = new SqlConnection(ConnString))
                                {
                                    using (SqlCommand cmd1 = new SqlCommand("GetTaxGroupingDetailsForPrinting", con1))
                                    {
                                        cmd1.CommandType = CommandType.StoredProcedure;
                                        cmd1.Parameters.AddWithValue("@TerminalID", a.TerminalID);
                                        cmd1.CommandTimeout = 0;
                                        con1.Open();
                                        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                                        DataTable dt1 = new DataTable();
                                        da1.Fill(dt1);
                                        CurrentRecord = 0;
                                        if (dt1.Rows.Count > 0)
                                        {
                                            RecordsPerPage = Convert.ToInt32(dt1.Rows.Count);
                                            while (CurrentRecord < RecordsPerPage)
                                            {
                                                int xTaxType= leftMargin - 90;
                                                DataRow dr = (DataRow)dt1.Rows[CurrentRecord];
                                                FieldValue = "" + dr["TaxType"];
                                                FieldValue = String.Format("{0:0.00}", dr["TaxType"]) + "%                                                 " + String.Format("{0:0.00}", dr["TaxAmount"]);
                                                g.DrawString(FieldValue, InvoiceFont, BlackBrush, xTaxType, CurrentY);
                                                CurrentRecord = CurrentRecord + 1;
                                                CurrentY = CurrentY + InvoiceFontHeight;
                                                if (CurrentRecord == RecordsPerPage)
                                                    break;
                                            }

                                            CurrentY = CurrentY + InvoiceFontHeight;
                                            int CurrentX = leftMargin ;
                                            for (int i = 10; i <= 250; i++)
                                                g.DrawString("-", InvoiceTitle, BlueBrush, i, CurrentY);
                                            CurrentY = CurrentY + InvoiceFontHeight;
                                            CurrentY = CurrentY + InvoiceFontHeight;
                                            CurrentY = CurrentY + InvoiceFontHeight;
                                            CurrentY = CurrentY + InvoiceFontHeight;
                                            CurrentY = CurrentY + InvoiceFontHeight;
                                            CurrentY = CurrentY + InvoiceFontHeight;
                                            CurrentY = CurrentY + InvoiceFontHeight;
                                            FieldValue = "||  THANK YOU VISIT AGAIN ||";
                                            int lenSalutation = (int)g.MeasureString(FieldValue, InvSalutation).Width;
                                            // Set Titles Left:
                                            int xSalutation = CurrentX + (InvoiceWidth - lenSalutation) / 2;
                                            g.DrawString(FieldValue, InvSalutation, BlueBrush, xSalutation, CurrentY);
                                        }
                                    }
                                }
                            }
                            catch (Exception)
                            {

                            }



                            g.Dispose();

                            if (CurrentRecord < RecordsPerPage)
                                e.HasMorePages = false;
                            else
                                e.HasMorePages = true;

                            if (StopReading)
                            {
                                SetInvoiceTotal(g);
                                
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SetInvoiceTotal(Graphics g)
        {// Set Invoice Total:
         // Draw line:
            CurrentY = CurrentY + 8;
            g.DrawLine(new Pen(Brushes.Black), leftMargin, CurrentY, rightMargin, CurrentY);
            // Get Right Edge of Invoice:
            int xRightEdg = AmountPosition + (int)g.MeasureString("Extended Price", InvoiceFont).Width;

            // Write Sub Total:
            int xSubTotal = AmountPosition - (int)g.MeasureString("Sub Total", InvoiceFont).Width;
            CurrentY = CurrentY + 8;
            g.DrawString("Sub Total", InvoiceFont, RedBrush, xSubTotal, CurrentY);
            string TotalValue = String.Format("{0:0.00}", SubTotal);
            int xTotalValue = xRightEdg - (int)g.MeasureString(TotalValue, InvoiceFont).Width;
            g.DrawString(TotalValue, InvoiceFont, BlackBrush, xTotalValue, CurrentY);

            // Write Order Freight:
            int xOrderFreight = AmountPosition - (int)g.MeasureString("Order Freight", InvoiceFont).Width;
            CurrentY = CurrentY + InvoiceFontHeight;
            g.DrawString("Order Freight", InvoiceFont, RedBrush, xOrderFreight, CurrentY);
            string FreightValue = String.Format("{0:0.00}", SaleFreight);
            int xFreight = xRightEdg - (int)g.MeasureString(FreightValue, InvoiceFont).Width;
            g.DrawString(FreightValue, InvoiceFont, BlackBrush, xFreight, CurrentY);

            // Write Invoice Total:
            int xInvoiceTotal = AmountPosition - (int)g.MeasureString("Invoice Total", InvoiceFont).Width;
            CurrentY = CurrentY + InvoiceFontHeight;
            g.DrawString("Invoice Total", InvoiceFont, RedBrush, xInvoiceTotal, CurrentY);
            string InvoiceValue = String.Format("{0:0.00}", InvoiceTotal);
            int xInvoiceValue = xRightEdg - (int)g.MeasureString(InvoiceValue, InvoiceFont).Width;
            g.DrawString(InvoiceValue, InvoiceFont, BlackBrush, xInvoiceValue, CurrentY);
        }


        private bool CheckTokenPrintStatus(int TerminalID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("CheckTokenPrint", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TerminalID", TerminalID);
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                            return true;
                        else
                            return false;
                    }

                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        private void DisplayDialog()
        {
            try
            {
                prnDialog.Document = this.prnDocument;
                DialogResult ButtonPressed = prnDialog.ShowDialog();
                // If user Click 'OK', Print Invoice
                if (ButtonPressed == DialogResult.OK)
                    prnDocument.Print();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void DisplayInvoice()
        {
            prnPreview.Document = this.prnDocument;
            try
            {
                prnPreview.ShowDialog();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void PrintReport()
        {
            try
            {
                prnDocument.Print();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        private int UpdateTokenPrintStatus(int TerminalID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateTokenStatusByTokenNo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TerminalID",TerminalID);
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

                    // Result of the Event 'PrintPage'
        private void prnDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            leftMargin = (int)e.MarginBounds.Left;
            rightMargin = (int)e.MarginBounds.Right;
            topMargin = (int)e.MarginBounds.Top-90;
            bottomMargin = (int)e.MarginBounds.Bottom;
            InvoiceWidth = (int)e.MarginBounds.Width;
            InvoiceHeight = (int)e.MarginBounds.Height;

            //if (!ReadInvoice)
            //    ReadInvoiceData();
            if (ReadInvoice==false)
            {
                SetInvoiceHead(e.Graphics); // Draw Invoice Head
                SetOrderData(e.Graphics); // Draw Order Data
                SetInvoiceData(e.Graphics, e); // Draw Invoice Data
                AppConfiguration a = new AppConfiguration();
                UpdateTokenPrintStatus(a.TerminalID);
                ReadInvoice = true;
                
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            ReadInvoice = false;
            DisplayInvoice(); // Print Preview
 
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            AppConfiguration a = new AppConfiguration();
            int n= InsertTempDataToMain(a.TerminalID);
            bool Flag = CheckTokenPrintStatus(a.TerminalID);
            if (Flag == false)
            {
                for (int i = 0; i < 2; i++)
                {
                    ReadInvoice = false;
                    PrintReport(); // Print Invoice
                }
            }
            else
            {
                ReadInvoice = false;
                PrintReport(); // Print Invoice
            }

            this.Visible = false;
            this.Close();
            this.Hide();
            if (Application.OpenForms.OfType<frmOrder>().Any())
            {
                frmOrder frm = new frmOrder();
                frm.Visible = false;
                frm.Close();
                frm.Hide();
            }
            frmOrder frm1 = new frmOrder();
            frm1.Show();
        }

        private int InsertTempDataToMain(int TerminalID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERTOrderFromTempToMain", con))
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


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
            this.Hide();
            if (Application.OpenForms.OfType<frmOrder>().Any())
            {
                frmOrder frm = new frmOrder();
                frm.Visible = false;
                frm.Close();
                frm.Hide();

            }
            frmOrder frm1 = new frmOrder();
            frm1.Show();

        }

        private void frmPrintToken_Load(object sender, EventArgs e)
        {
            this.Left = 250;
            this.Top = 250;
        }
    }
}
