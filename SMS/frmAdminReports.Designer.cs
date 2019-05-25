namespace SMS
{
    partial class frmAdminReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoTotalSaleRegister = new System.Windows.Forms.RadioButton();
            this.rdoTaxableSaleRegister = new System.Windows.Forms.RadioButton();
            this.rdoGSTINSaleRegister = new System.Windows.Forms.RadioButton();
            this.rdoStockDetails = new System.Windows.Forms.RadioButton();
            this.rdoBulkOrder = new System.Windows.Forms.RadioButton();
            this.monthToDate = new System.Windows.Forms.MonthCalendar();
            this.monthFromDate = new System.Windows.Forms.MonthCalendar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowseToDate = new System.Windows.Forms.Button();
            this.txtToDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseFromDate = new System.Windows.Forms.Button();
            this.txtFromDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetReport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.rdoTotalSaleRegister);
            this.groupBox1.Controls.Add(this.rdoTaxableSaleRegister);
            this.groupBox1.Controls.Add(this.rdoGSTINSaleRegister);
            this.groupBox1.Controls.Add(this.rdoStockDetails);
            this.groupBox1.Controls.Add(this.rdoBulkOrder);
            this.groupBox1.Location = new System.Drawing.Point(6, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 300);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Type";
            // 
            // rdoTotalSaleRegister
            // 
            this.rdoTotalSaleRegister.AutoSize = true;
            this.rdoTotalSaleRegister.Location = new System.Drawing.Point(24, 137);
            this.rdoTotalSaleRegister.Name = "rdoTotalSaleRegister";
            this.rdoTotalSaleRegister.Size = new System.Drawing.Size(115, 17);
            this.rdoTotalSaleRegister.TabIndex = 0;
            this.rdoTotalSaleRegister.Text = "Total Sale Register";
            this.rdoTotalSaleRegister.UseVisualStyleBackColor = true;
            // 
            // rdoTaxableSaleRegister
            // 
            this.rdoTaxableSaleRegister.AutoSize = true;
            this.rdoTaxableSaleRegister.Location = new System.Drawing.Point(24, 63);
            this.rdoTaxableSaleRegister.Name = "rdoTaxableSaleRegister";
            this.rdoTaxableSaleRegister.Size = new System.Drawing.Size(129, 17);
            this.rdoTaxableSaleRegister.TabIndex = 0;
            this.rdoTaxableSaleRegister.Text = "Taxable Sale Register";
            this.rdoTaxableSaleRegister.UseVisualStyleBackColor = true;
            // 
            // rdoGSTINSaleRegister
            // 
            this.rdoGSTINSaleRegister.AutoSize = true;
            this.rdoGSTINSaleRegister.Location = new System.Drawing.Point(24, 97);
            this.rdoGSTINSaleRegister.Name = "rdoGSTINSaleRegister";
            this.rdoGSTINSaleRegister.Size = new System.Drawing.Size(124, 17);
            this.rdoGSTINSaleRegister.TabIndex = 0;
            this.rdoGSTINSaleRegister.Text = "GSTIN Sale Register";
            this.rdoGSTINSaleRegister.UseVisualStyleBackColor = true;
            // 
            // rdoStockDetails
            // 
            this.rdoStockDetails.AutoSize = true;
            this.rdoStockDetails.Location = new System.Drawing.Point(24, 170);
            this.rdoStockDetails.Name = "rdoStockDetails";
            this.rdoStockDetails.Size = new System.Drawing.Size(88, 17);
            this.rdoStockDetails.TabIndex = 0;
            this.rdoStockDetails.Text = "Stock Details";
            this.rdoStockDetails.UseVisualStyleBackColor = true;
            // 
            // rdoBulkOrder
            // 
            this.rdoBulkOrder.AutoSize = true;
            this.rdoBulkOrder.Checked = true;
            this.rdoBulkOrder.Location = new System.Drawing.Point(24, 29);
            this.rdoBulkOrder.Name = "rdoBulkOrder";
            this.rdoBulkOrder.Size = new System.Drawing.Size(75, 17);
            this.rdoBulkOrder.TabIndex = 0;
            this.rdoBulkOrder.TabStop = true;
            this.rdoBulkOrder.Text = "Bulk Order";
            this.rdoBulkOrder.UseVisualStyleBackColor = true;
            // 
            // monthToDate
            // 
            this.monthToDate.Location = new System.Drawing.Point(49, 53);
            this.monthToDate.Name = "monthToDate";
            this.monthToDate.TabIndex = 6;
            this.monthToDate.Visible = false;
            this.monthToDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthToDate_DateSelected);
            // 
            // monthFromDate
            // 
            this.monthFromDate.Location = new System.Drawing.Point(49, 53);
            this.monthFromDate.Name = "monthFromDate";
            this.monthFromDate.TabIndex = 6;
            this.monthFromDate.Visible = false;
            this.monthFromDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthFromDate_DateSelected);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Controls.Add(this.monthFromDate);
            this.groupBox2.Controls.Add(this.monthToDate);
            this.groupBox2.Controls.Add(this.btnBrowseToDate);
            this.groupBox2.Controls.Add(this.txtToDate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnBrowseFromDate);
            this.groupBox2.Controls.Add(this.txtFromDate);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(311, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 300);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Date Range";
            // 
            // btnBrowseToDate
            // 
            this.btnBrowseToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseToDate.Location = new System.Drawing.Point(282, 99);
            this.btnBrowseToDate.Name = "btnBrowseToDate";
            this.btnBrowseToDate.Size = new System.Drawing.Size(33, 31);
            this.btnBrowseToDate.TabIndex = 5;
            this.btnBrowseToDate.Text = "...";
            this.btnBrowseToDate.UseVisualStyleBackColor = true;
            this.btnBrowseToDate.Click += new System.EventHandler(this.btnBrowseToDate_Click);
            // 
            // txtToDate
            // 
            this.txtToDate.Location = new System.Drawing.Point(154, 106);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Size = new System.Drawing.Size(122, 20);
            this.txtToDate.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To Date";
            // 
            // btnBrowseFromDate
            // 
            this.btnBrowseFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseFromDate.Location = new System.Drawing.Point(282, 53);
            this.btnBrowseFromDate.Name = "btnBrowseFromDate";
            this.btnBrowseFromDate.Size = new System.Drawing.Size(33, 31);
            this.btnBrowseFromDate.TabIndex = 2;
            this.btnBrowseFromDate.Text = "...";
            this.btnBrowseFromDate.UseVisualStyleBackColor = true;
            this.btnBrowseFromDate.Click += new System.EventHandler(this.btnBrowseFromDate_Click);
            // 
            // txtFromDate
            // 
            this.txtFromDate.Location = new System.Drawing.Point(154, 60);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Size = new System.Drawing.Size(122, 20);
            this.txtFromDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "FromDate";
            // 
            // btnGetReport
            // 
            this.btnGetReport.Location = new System.Drawing.Point(409, 322);
            this.btnGetReport.Name = "btnGetReport";
            this.btnGetReport.Size = new System.Drawing.Size(85, 24);
            this.btnGetReport.TabIndex = 2;
            this.btnGetReport.Text = "Get Report";
            this.btnGetReport.UseVisualStyleBackColor = true;
            this.btnGetReport.Click += new System.EventHandler(this.btnGetReport_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(500, 322);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 24);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAdminReports
            // 
            this.AcceptButton = this.btnGetReport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(634, 365);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGetReport);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdminReports";
            this.Text = "Reports";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoTotalSaleRegister;
        private System.Windows.Forms.RadioButton rdoTaxableSaleRegister;
        private System.Windows.Forms.RadioButton rdoGSTINSaleRegister;
        private System.Windows.Forms.RadioButton rdoStockDetails;
        private System.Windows.Forms.RadioButton rdoBulkOrder;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBrowseFromDate;
        private System.Windows.Forms.TextBox txtFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseToDate;
        private System.Windows.Forms.TextBox txtToDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetReport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.MonthCalendar monthFromDate;
        private System.Windows.Forms.MonthCalendar monthToDate;
    }
}