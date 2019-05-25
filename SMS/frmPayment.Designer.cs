namespace SMS
{
    partial class frmPayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpCheque = new System.Windows.Forms.GroupBox();
            this.txtChequeDate = new System.Windows.Forms.TextBox();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.txtChequeBank = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnChequeDate = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.monthChequeDate = new System.Windows.Forms.MonthCalendar();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtCurrentTotalPaidAmount = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtCurrentTotalOutstandingAmount = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnPaymentHistory = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTotalOutstandingAmount = new System.Windows.Forms.TextBox();
            this.txtSettledDate = new System.Windows.Forms.TextBox();
            this.txtLastPaymentDate = new System.Windows.Forms.TextBox();
            this.txtTotalPaidAmount = new System.Windows.Forms.TextBox();
            this.txtTotalDueAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.grpBulkOrder = new System.Windows.Forms.GroupBox();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.chkBulkOrder = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbBoxType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdoCard = new System.Windows.Forms.RadioButton();
            this.rdoCheque = new System.Windows.Forms.RadioButton();
            this.rdoCash = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoAdvanced = new System.Windows.Forms.RadioButton();
            this.rdoOnCredit = new System.Windows.Forms.RadioButton();
            this.rdoFullSettlement = new System.Windows.Forms.RadioButton();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtCareOf = new System.Windows.Forms.TextBox();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTokenNo = new System.Windows.Forms.TextBox();
            this.lblSalesmanName = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblOrderCounter = new System.Windows.Forms.Label();
            this.lblOrderTerminal = new System.Windows.Forms.Label();
            this.btnCashMemo = new System.Windows.Forms.Button();
            this.btnTaxInvoice = new System.Windows.Forms.Button();
            this.btnSubmitOrder = new System.Windows.Forms.Button();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnDuplicateToken = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.grpCheque.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.grpBulkOrder.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Token #";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.grpCheque);
            this.groupBox1.Controls.Add(this.monthChequeDate);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.grpBulkOrder);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.txtCareOf);
            this.groupBox1.Controls.Add(this.txtMobileNo);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtTokenNo);
            this.groupBox1.Controls.Add(this.lblSalesmanName);
            this.groupBox1.Controls.Add(this.lblCustomerName);
            this.groupBox1.Controls.Add(this.lblOrderDate);
            this.groupBox1.Controls.Add(this.lblOrderCounter);
            this.groupBox1.Controls.Add(this.lblOrderTerminal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(383, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 481);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // grpCheque
            // 
            this.grpCheque.Controls.Add(this.txtChequeDate);
            this.grpCheque.Controls.Add(this.txtChequeNo);
            this.grpCheque.Controls.Add(this.txtChequeBank);
            this.grpCheque.Controls.Add(this.label9);
            this.grpCheque.Controls.Add(this.btnChequeDate);
            this.grpCheque.Controls.Add(this.label10);
            this.grpCheque.Controls.Add(this.label11);
            this.grpCheque.Location = new System.Drawing.Point(263, 160);
            this.grpCheque.Name = "grpCheque";
            this.grpCheque.Size = new System.Drawing.Size(198, 102);
            this.grpCheque.TabIndex = 557;
            this.grpCheque.TabStop = false;
            this.grpCheque.Text = "Cheque Details";
            // 
            // txtChequeDate
            // 
            this.txtChequeDate.Enabled = false;
            this.txtChequeDate.Location = new System.Drawing.Point(57, 73);
            this.txtChequeDate.Name = "txtChequeDate";
            this.txtChequeDate.Size = new System.Drawing.Size(103, 20);
            this.txtChequeDate.TabIndex = 555;
            this.txtChequeDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTokenNo_KeyDown);
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Location = new System.Drawing.Point(57, 17);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(134, 20);
            this.txtChequeNo.TabIndex = 12;
            this.txtChequeNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTokenNo_KeyDown);
            this.txtChequeNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChequeNo_KeyPress);
            // 
            // txtChequeBank
            // 
            this.txtChequeBank.Location = new System.Drawing.Point(57, 44);
            this.txtChequeBank.Name = "txtChequeBank";
            this.txtChequeBank.Size = new System.Drawing.Size(134, 20);
            this.txtChequeBank.TabIndex = 13;
            this.txtChequeBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTokenNo_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Cheque #";
            // 
            // btnChequeDate
            // 
            this.btnChequeDate.Location = new System.Drawing.Point(160, 73);
            this.btnChequeDate.Name = "btnChequeDate";
            this.btnChequeDate.Size = new System.Drawing.Size(31, 20);
            this.btnChequeDate.TabIndex = 14;
            this.btnChequeDate.Text = "...";
            this.btnChequeDate.UseVisualStyleBackColor = true;
            this.btnChequeDate.Click += new System.EventHandler(this.btnChequeDate_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Bank";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Date";
            // 
            // monthChequeDate
            // 
            this.monthChequeDate.Location = new System.Drawing.Point(193, 256);
            this.monthChequeDate.Name = "monthChequeDate";
            this.monthChequeDate.TabIndex = 556;
            this.monthChequeDate.Visible = false;
            this.monthChequeDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthChequeDate_DateSelected);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.txtCurrentTotalPaidAmount);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.txtCurrentTotalOutstandingAmount);
            this.groupBox6.Location = new System.Drawing.Point(9, 410);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(626, 65);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Current Payment";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 29);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 13);
            this.label19.TabIndex = 9;
            this.label19.Text = "Paid Amount";
            // 
            // txtCurrentTotalPaidAmount
            // 
            this.txtCurrentTotalPaidAmount.Enabled = false;
            this.txtCurrentTotalPaidAmount.Location = new System.Drawing.Point(148, 26);
            this.txtCurrentTotalPaidAmount.Name = "txtCurrentTotalPaidAmount";
            this.txtCurrentTotalPaidAmount.Size = new System.Drawing.Size(148, 20);
            this.txtCurrentTotalPaidAmount.TabIndex = 19;
            this.txtCurrentTotalPaidAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTokenNo_KeyDown);
            this.txtCurrentTotalPaidAmount.Leave += new System.EventHandler(this.txtCurrentTotalPaidAmount_Leave);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(343, 29);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(103, 13);
            this.label20.TabIndex = 9;
            this.label20.Text = "Outstanding Amount";
            // 
            // txtCurrentTotalOutstandingAmount
            // 
            this.txtCurrentTotalOutstandingAmount.Location = new System.Drawing.Point(470, 26);
            this.txtCurrentTotalOutstandingAmount.Name = "txtCurrentTotalOutstandingAmount";
            this.txtCurrentTotalOutstandingAmount.ReadOnly = true;
            this.txtCurrentTotalOutstandingAmount.Size = new System.Drawing.Size(153, 20);
            this.txtCurrentTotalOutstandingAmount.TabIndex = 20;
            this.txtCurrentTotalOutstandingAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTokenNo_KeyDown);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnPaymentHistory);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.txtTotalOutstandingAmount);
            this.groupBox5.Controls.Add(this.txtSettledDate);
            this.groupBox5.Controls.Add(this.txtLastPaymentDate);
            this.groupBox5.Controls.Add(this.txtTotalPaidAmount);
            this.groupBox5.Controls.Add(this.txtTotalDueAmount);
            this.groupBox5.Location = new System.Drawing.Point(9, 291);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(626, 113);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Last Payment Details";
            // 
            // btnPaymentHistory
            // 
            this.btnPaymentHistory.Location = new System.Drawing.Point(465, 69);
            this.btnPaymentHistory.Name = "btnPaymentHistory";
            this.btnPaymentHistory.Size = new System.Drawing.Size(150, 28);
            this.btnPaymentHistory.TabIndex = 560;
            this.btnPaymentHistory.Text = "Customer Payment History ...";
            this.btnPaymentHistory.UseVisualStyleBackColor = true;
            this.btnPaymentHistory.Click += new System.EventHandler(this.btnPaymentHistory_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(323, 48);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 13);
            this.label18.TabIndex = 9;
            this.label18.Text = "Settled Date";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(323, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(130, 13);
            this.label17.TabIndex = 9;
            this.label17.Text = "Total Outstanding Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Last Payment Date";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 51);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Total Paid Amount";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "Total Due Amount";
            // 
            // txtTotalOutstandingAmount
            // 
            this.txtTotalOutstandingAmount.Location = new System.Drawing.Point(465, 19);
            this.txtTotalOutstandingAmount.Name = "txtTotalOutstandingAmount";
            this.txtTotalOutstandingAmount.ReadOnly = true;
            this.txtTotalOutstandingAmount.Size = new System.Drawing.Size(148, 20);
            this.txtTotalOutstandingAmount.TabIndex = 558;
            this.txtTotalOutstandingAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTokenNo_KeyDown);
            // 
            // txtSettledDate
            // 
            this.txtSettledDate.Location = new System.Drawing.Point(465, 45);
            this.txtSettledDate.Name = "txtSettledDate";
            this.txtSettledDate.ReadOnly = true;
            this.txtSettledDate.Size = new System.Drawing.Size(150, 20);
            this.txtSettledDate.TabIndex = 559;
            this.txtSettledDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTokenNo_KeyDown);
            // 
            // txtLastPaymentDate
            // 
            this.txtLastPaymentDate.Location = new System.Drawing.Point(147, 74);
            this.txtLastPaymentDate.Name = "txtLastPaymentDate";
            this.txtLastPaymentDate.ReadOnly = true;
            this.txtLastPaymentDate.Size = new System.Drawing.Size(150, 20);
            this.txtLastPaymentDate.TabIndex = 557;
            this.txtLastPaymentDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTokenNo_KeyDown);
            // 
            // txtTotalPaidAmount
            // 
            this.txtTotalPaidAmount.Location = new System.Drawing.Point(147, 48);
            this.txtTotalPaidAmount.Name = "txtTotalPaidAmount";
            this.txtTotalPaidAmount.ReadOnly = true;
            this.txtTotalPaidAmount.Size = new System.Drawing.Size(150, 20);
            this.txtTotalPaidAmount.TabIndex = 557;
            this.txtTotalPaidAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTokenNo_KeyDown);
            // 
            // txtTotalDueAmount
            // 
            this.txtTotalDueAmount.Location = new System.Drawing.Point(148, 22);
            this.txtTotalDueAmount.Name = "txtTotalDueAmount";
            this.txtTotalDueAmount.ReadOnly = true;
            this.txtTotalDueAmount.Size = new System.Drawing.Size(148, 20);
            this.txtTotalDueAmount.TabIndex = 556;
            this.txtTotalDueAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTokenNo_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Email";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(467, 245);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Address";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(463, 203);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "Care Of";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(463, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Mobile #";
            // 
            // grpBulkOrder
            // 
            this.grpBulkOrder.Controls.Add(this.dtpTime);
            this.grpBulkOrder.Controls.Add(this.chkBulkOrder);
            this.grpBulkOrder.Controls.Add(this.label7);
            this.grpBulkOrder.Controls.Add(this.cmbBoxType);
            this.grpBulkOrder.Controls.Add(this.label8);
            this.grpBulkOrder.Controls.Add(this.dtpDeliveryDate);
            this.grpBulkOrder.Location = new System.Drawing.Point(9, 94);
            this.grpBulkOrder.Name = "grpBulkOrder";
            this.grpBulkOrder.Size = new System.Drawing.Size(626, 67);
            this.grpBulkOrder.TabIndex = 8;
            this.grpBulkOrder.TabStop = false;
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = "HH";
            this.dtpTime.Enabled = false;
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(150, 40);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(84, 20);
            this.dtpTime.TabIndex = 4;
            // 
            // chkBulkOrder
            // 
            this.chkBulkOrder.AutoSize = true;
            this.chkBulkOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBulkOrder.Location = new System.Drawing.Point(7, 0);
            this.chkBulkOrder.Name = "chkBulkOrder";
            this.chkBulkOrder.Size = new System.Drawing.Size(216, 21);
            this.chkBulkOrder.TabIndex = 2;
            this.chkBulkOrder.Text = "The Order is a Bulk Order";
            this.chkBulkOrder.UseVisualStyleBackColor = true;
            this.chkBulkOrder.CheckedChanged += new System.EventHandler(this.chkBulkOrder_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Expected Delivery Date and Time";
            // 
            // cmbBoxType
            // 
            this.cmbBoxType.Enabled = false;
            this.cmbBoxType.FormattingEnabled = true;
            this.cmbBoxType.Location = new System.Drawing.Point(324, 39);
            this.cmbBoxType.Name = "cmbBoxType";
            this.cmbBoxType.Size = new System.Drawing.Size(215, 21);
            this.cmbBoxType.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(321, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Box Type";
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDeliveryDate.Enabled = false;
            this.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDeliveryDate.Location = new System.Drawing.Point(42, 40);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(111, 20);
            this.dtpDeliveryDate.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdoCard);
            this.groupBox4.Controls.Add(this.rdoCheque);
            this.groupBox4.Controls.Add(this.rdoCash);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(145, 160);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(110, 121);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Payment Mode";
            // 
            // rdoCard
            // 
            this.rdoCard.AutoSize = true;
            this.rdoCard.Location = new System.Drawing.Point(20, 68);
            this.rdoCard.Name = "rdoCard";
            this.rdoCard.Size = new System.Drawing.Size(47, 17);
            this.rdoCard.TabIndex = 11;
            this.rdoCard.Text = "Card";
            this.rdoCard.UseVisualStyleBackColor = true;
            this.rdoCard.CheckedChanged += new System.EventHandler(this.rdoCard_CheckedChanged);
            // 
            // rdoCheque
            // 
            this.rdoCheque.AutoSize = true;
            this.rdoCheque.Location = new System.Drawing.Point(20, 45);
            this.rdoCheque.Name = "rdoCheque";
            this.rdoCheque.Size = new System.Drawing.Size(62, 17);
            this.rdoCheque.TabIndex = 10;
            this.rdoCheque.Text = "Cheque";
            this.rdoCheque.UseVisualStyleBackColor = true;
            this.rdoCheque.CheckedChanged += new System.EventHandler(this.rdoCheque_CheckedChanged);
            // 
            // rdoCash
            // 
            this.rdoCash.AutoSize = true;
            this.rdoCash.Checked = true;
            this.rdoCash.Location = new System.Drawing.Point(20, 22);
            this.rdoCash.Name = "rdoCash";
            this.rdoCash.Size = new System.Drawing.Size(49, 17);
            this.rdoCash.TabIndex = 9;
            this.rdoCash.TabStop = true;
            this.rdoCash.Text = "Cash";
            this.rdoCash.UseVisualStyleBackColor = true;
            this.rdoCash.CheckedChanged += new System.EventHandler(this.rdoCash_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoAdvanced);
            this.groupBox2.Controls.Add(this.rdoOnCredit);
            this.groupBox2.Controls.Add(this.rdoFullSettlement);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(9, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(126, 121);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payment Type";
            // 
            // rdoAdvanced
            // 
            this.rdoAdvanced.AutoSize = true;
            this.rdoAdvanced.Enabled = false;
            this.rdoAdvanced.Location = new System.Drawing.Point(20, 68);
            this.rdoAdvanced.Name = "rdoAdvanced";
            this.rdoAdvanced.Size = new System.Drawing.Size(74, 17);
            this.rdoAdvanced.TabIndex = 8;
            this.rdoAdvanced.Text = "Adavance";
            this.rdoAdvanced.UseVisualStyleBackColor = true;
            this.rdoAdvanced.CheckedChanged += new System.EventHandler(this.rdoAdvanced_CheckedChanged);
            // 
            // rdoOnCredit
            // 
            this.rdoOnCredit.AutoSize = true;
            this.rdoOnCredit.Location = new System.Drawing.Point(20, 45);
            this.rdoOnCredit.Name = "rdoOnCredit";
            this.rdoOnCredit.Size = new System.Drawing.Size(69, 17);
            this.rdoOnCredit.TabIndex = 7;
            this.rdoOnCredit.Text = "On Credit";
            this.rdoOnCredit.UseVisualStyleBackColor = true;
            this.rdoOnCredit.CheckedChanged += new System.EventHandler(this.rdoOnCredit_CheckedChanged);
            // 
            // rdoFullSettlement
            // 
            this.rdoFullSettlement.AutoSize = true;
            this.rdoFullSettlement.Checked = true;
            this.rdoFullSettlement.Location = new System.Drawing.Point(20, 22);
            this.rdoFullSettlement.Name = "rdoFullSettlement";
            this.rdoFullSettlement.Size = new System.Drawing.Size(94, 17);
            this.rdoFullSettlement.TabIndex = 6;
            this.rdoFullSettlement.TabStop = true;
            this.rdoFullSettlement.Text = "Full Settlement";
            this.rdoFullSettlement.UseVisualStyleBackColor = true;
            this.rdoFullSettlement.CheckedChanged += new System.EventHandler(this.rdoFullSettlement_CheckedChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(515, 222);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(121, 69);
            this.txtAddress.TabIndex = 18;
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTokenNo_KeyDown);
            // 
            // txtCareOf
            // 
            this.txtCareOf.Location = new System.Drawing.Point(514, 196);
            this.txtCareOf.Name = "txtCareOf";
            this.txtCareOf.Size = new System.Drawing.Size(121, 20);
            this.txtCareOf.TabIndex = 17;
            this.txtCareOf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTokenNo_KeyDown);
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(514, 173);
            this.txtMobileNo.MaxLength = 10;
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(121, 20);
            this.txtMobileNo.TabIndex = 16;
            this.txtMobileNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTokenNo_KeyDown);
            this.txtMobileNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobileNo_KeyPress);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(321, 268);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(134, 20);
            this.txtEmail.TabIndex = 15;
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTokenNo_KeyDown);
            // 
            // txtTokenNo
            // 
            this.txtTokenNo.Location = new System.Drawing.Point(104, 11);
            this.txtTokenNo.Name = "txtTokenNo";
            this.txtTokenNo.Size = new System.Drawing.Size(92, 20);
            this.txtTokenNo.TabIndex = 1;
            this.txtTokenNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTokenNo_KeyDown);
            this.txtTokenNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTokenNo_KeyPress);
            // 
            // lblSalesmanName
            // 
            this.lblSalesmanName.AutoSize = true;
            this.lblSalesmanName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesmanName.Location = new System.Drawing.Point(210, 47);
            this.lblSalesmanName.Name = "lblSalesmanName";
            this.lblSalesmanName.Size = new System.Drawing.Size(105, 13);
            this.lblSalesmanName.TabIndex = 0;
            this.lblSalesmanName.Text = "Salesman Name: ";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(212, 14);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(103, 13);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Customer Name: ";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDate.Location = new System.Drawing.Point(212, 78);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(73, 13);
            this.lblOrderDate.TabIndex = 0;
            this.lblOrderDate.Text = "Order Date:";
            // 
            // lblOrderCounter
            // 
            this.lblOrderCounter.AutoSize = true;
            this.lblOrderCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderCounter.Location = new System.Drawing.Point(9, 47);
            this.lblOrderCounter.Name = "lblOrderCounter";
            this.lblOrderCounter.Size = new System.Drawing.Size(90, 13);
            this.lblOrderCounter.TabIndex = 0;
            this.lblOrderCounter.Text = "Order Counter:";
            // 
            // lblOrderTerminal
            // 
            this.lblOrderTerminal.AutoSize = true;
            this.lblOrderTerminal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderTerminal.Location = new System.Drawing.Point(9, 78);
            this.lblOrderTerminal.Name = "lblOrderTerminal";
            this.lblOrderTerminal.Size = new System.Drawing.Size(94, 13);
            this.lblOrderTerminal.TabIndex = 0;
            this.lblOrderTerminal.Text = "Order Terminal:";
            // 
            // btnCashMemo
            // 
            this.btnCashMemo.Location = new System.Drawing.Point(523, 490);
            this.btnCashMemo.Name = "btnCashMemo";
            this.btnCashMemo.Size = new System.Drawing.Size(68, 41);
            this.btnCashMemo.TabIndex = 22;
            this.btnCashMemo.Text = "Order Memo";
            this.btnCashMemo.UseVisualStyleBackColor = true;
            this.btnCashMemo.Click += new System.EventHandler(this.btnCashMemo_Click);
            // 
            // btnTaxInvoice
            // 
            this.btnTaxInvoice.Enabled = false;
            this.btnTaxInvoice.Location = new System.Drawing.Point(600, 490);
            this.btnTaxInvoice.Name = "btnTaxInvoice";
            this.btnTaxInvoice.Size = new System.Drawing.Size(68, 41);
            this.btnTaxInvoice.TabIndex = 23;
            this.btnTaxInvoice.Text = "Tax Invoice";
            this.btnTaxInvoice.UseVisualStyleBackColor = true;
            this.btnTaxInvoice.Click += new System.EventHandler(this.btnTaxInvoice_Click);
            // 
            // btnSubmitOrder
            // 
            this.btnSubmitOrder.Location = new System.Drawing.Point(441, 490);
            this.btnSubmitOrder.Name = "btnSubmitOrder";
            this.btnSubmitOrder.Size = new System.Drawing.Size(68, 41);
            this.btnSubmitOrder.TabIndex = 21;
            this.btnSubmitOrder.Text = "Submit Order";
            this.btnSubmitOrder.UseVisualStyleBackColor = true;
            this.btnSubmitOrder.Click += new System.EventHandler(this.btnSubmitOrder_Click);
            this.btnSubmitOrder.MouseHover += new System.EventHandler(this.btnSubmitOrder_MouseHover);
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelOrder.Location = new System.Drawing.Point(674, 490);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(68, 41);
            this.btnCancelOrder.TabIndex = 24;
            this.btnCancelOrder.Text = "Cancel Order";
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(823, 490);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(68, 41);
            this.btnReport.TabIndex = 25;
            this.btnReport.Text = "Reports";
            this.btnReport.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(897, 491);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(68, 41);
            this.btnExit.TabIndex = 26;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgv
            // 
            this.dgv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(0, 3);
            this.dgv.Name = "dgv";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(386, 539);
            this.dgv.TabIndex = 560;
            // 
            // btnDuplicateToken
            // 
            this.btnDuplicateToken.Location = new System.Drawing.Point(749, 491);
            this.btnDuplicateToken.Name = "btnDuplicateToken";
            this.btnDuplicateToken.Size = new System.Drawing.Size(68, 40);
            this.btnDuplicateToken.TabIndex = 561;
            this.btnDuplicateToken.Text = "Duplicate Token";
            this.btnDuplicateToken.UseVisualStyleBackColor = true;
            this.btnDuplicateToken.Click += new System.EventHandler(this.btnDuplicateToken_Click);
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1028, 543);
            this.Controls.Add(this.btnDuplicateToken);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnCancelOrder);
            this.Controls.Add(this.btnSubmitOrder);
            this.Controls.Add(this.btnTaxInvoice);
            this.Controls.Add(this.btnCashMemo);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPayment";
            this.Text = "Cashier Payment Console";
            this.Load += new System.EventHandler(this.frmPayment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpCheque.ResumeLayout(false);
            this.grpCheque.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.grpBulkOrder.ResumeLayout(false);
            this.grpBulkOrder.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTokenNo;
        private System.Windows.Forms.Label lblSalesmanName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblOrderCounter;
        private System.Windows.Forms.Label lblOrderTerminal;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.CheckBox chkBulkOrder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDate;
        private System.Windows.Forms.ComboBox cmbBoxType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoAdvanced;
        private System.Windows.Forms.RadioButton rdoOnCredit;
        private System.Windows.Forms.RadioButton rdoFullSettlement;
        private System.Windows.Forms.GroupBox grpBulkOrder;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdoCard;
        private System.Windows.Forms.RadioButton rdoCheque;
        private System.Windows.Forms.RadioButton rdoCash;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.Button btnChequeDate;
        private System.Windows.Forms.TextBox txtChequeDate;
        private System.Windows.Forms.TextBox txtChequeBank;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtCareOf;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTotalOutstandingAmount;
        private System.Windows.Forms.TextBox txtSettledDate;
        private System.Windows.Forms.TextBox txtTotalPaidAmount;
        private System.Windows.Forms.TextBox txtTotalDueAmount;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtCurrentTotalOutstandingAmount;
        private System.Windows.Forms.TextBox txtCurrentTotalPaidAmount;
        private System.Windows.Forms.Button btnCashMemo;
        private System.Windows.Forms.Button btnTaxInvoice;
        private System.Windows.Forms.Button btnSubmitOrder;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.MonthCalendar monthChequeDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLastPaymentDate;
        private System.Windows.Forms.Button btnPaymentHistory;
        private System.Windows.Forms.GroupBox grpCheque;
        private System.Windows.Forms.Button btnDuplicateToken;
    }
}