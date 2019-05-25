namespace SMS
{
    partial class frmPrintCashMemoCR
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
            this.lblSelectedCopy = new System.Windows.Forms.Label();
            this.rdoDuplicate = new System.Windows.Forms.RadioButton();
            this.rdoCollectionCopy = new System.Windows.Forms.RadioButton();
            this.rdoCustomerCopy = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightPink;
            this.groupBox1.Controls.Add(this.lblSelectedCopy);
            this.groupBox1.Controls.Add(this.rdoDuplicate);
            this.groupBox1.Controls.Add(this.rdoCollectionCopy);
            this.groupBox1.Controls.Add(this.rdoCustomerCopy);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(794, 203);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Copy Of";
            // 
            // lblSelectedCopy
            // 
            this.lblSelectedCopy.AutoSize = true;
            this.lblSelectedCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedCopy.ForeColor = System.Drawing.Color.Red;
            this.lblSelectedCopy.Location = new System.Drawing.Point(142, 99);
            this.lblSelectedCopy.Name = "lblSelectedCopy";
            this.lblSelectedCopy.Size = new System.Drawing.Size(66, 24);
            this.lblSelectedCopy.TabIndex = 1;
            this.lblSelectedCopy.Text = "label1";
            // 
            // rdoDuplicate
            // 
            this.rdoDuplicate.AutoSize = true;
            this.rdoDuplicate.Location = new System.Drawing.Point(526, 35);
            this.rdoDuplicate.Name = "rdoDuplicate";
            this.rdoDuplicate.Size = new System.Drawing.Size(107, 19);
            this.rdoDuplicate.TabIndex = 0;
            this.rdoDuplicate.Text = "Duplicate Copy";
            this.rdoDuplicate.UseVisualStyleBackColor = true;
            this.rdoDuplicate.CheckedChanged += new System.EventHandler(this.rdoDuplicate_CheckedChanged);
            // 
            // rdoCollectionCopy
            // 
            this.rdoCollectionCopy.AutoSize = true;
            this.rdoCollectionCopy.Location = new System.Drawing.Point(300, 35);
            this.rdoCollectionCopy.Name = "rdoCollectionCopy";
            this.rdoCollectionCopy.Size = new System.Drawing.Size(109, 19);
            this.rdoCollectionCopy.TabIndex = 0;
            this.rdoCollectionCopy.Text = "Collection Copy";
            this.rdoCollectionCopy.UseVisualStyleBackColor = true;
            this.rdoCollectionCopy.CheckedChanged += new System.EventHandler(this.rdoCollectionCopy_CheckedChanged);
            // 
            // rdoCustomerCopy
            // 
            this.rdoCustomerCopy.AutoSize = true;
            this.rdoCustomerCopy.Checked = true;
            this.rdoCustomerCopy.Location = new System.Drawing.Point(56, 35);
            this.rdoCustomerCopy.Name = "rdoCustomerCopy";
            this.rdoCustomerCopy.Size = new System.Drawing.Size(108, 19);
            this.rdoCustomerCopy.TabIndex = 0;
            this.rdoCustomerCopy.TabStop = true;
            this.rdoCustomerCopy.Text = "Customer Copy";
            this.rdoCustomerCopy.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(549, 215);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 32);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(420, 215);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(123, 32);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmPrintCashMemoCR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 260);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrintCashMemoCR";
            this.Text = "Print Cash Memo";
            this.Load += new System.EventHandler(this.frmPrintCashMemoCR_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSelectedCopy;
        private System.Windows.Forms.RadioButton rdoCollectionCopy;
        private System.Windows.Forms.RadioButton rdoCustomerCopy;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.RadioButton rdoDuplicate;
    }
}