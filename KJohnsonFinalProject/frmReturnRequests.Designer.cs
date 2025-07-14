namespace KJohnsonFinalProject
{
    partial class frmReturnRequests
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReturnRequests));
            this.lbxReturnRequests = new System.Windows.Forms.ListBox();
            this.tbxProdName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.tbxCustName = new System.Windows.Forms.TextBox();
            this.lblCustName = new System.Windows.Forms.Label();
            this.tbxQuantity = new System.Windows.Forms.TextBox();
            this.tbxRefundAmt = new System.Windows.Forms.TextBox();
            this.lblRefund = new System.Windows.Forms.Label();
            this.chbxReceived = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnApproveReturn = new System.Windows.Forms.Button();
            this.tbxReason = new System.Windows.Forms.TextBox();
            this.lblErr = new System.Windows.Forms.Label();
            this.lblHelp = new System.Windows.Forms.Label();
            this.hlpReturnRequests = new System.Windows.Forms.HelpProvider();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbxReturnRequests
            // 
            this.lbxReturnRequests.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxReturnRequests.FormattingEnabled = true;
            this.lbxReturnRequests.ItemHeight = 17;
            this.lbxReturnRequests.Location = new System.Drawing.Point(41, 96);
            this.lbxReturnRequests.Name = "lbxReturnRequests";
            this.lbxReturnRequests.Size = new System.Drawing.Size(596, 395);
            this.lbxReturnRequests.TabIndex = 0;
            this.lbxReturnRequests.Click += new System.EventHandler(this.lbxReturnRequests_Click);
            // 
            // tbxProdName
            // 
            this.tbxProdName.Enabled = false;
            this.tbxProdName.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxProdName.Location = new System.Drawing.Point(241, 537);
            this.tbxProdName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbxProdName.Name = "tbxProdName";
            this.tbxProdName.ReadOnly = true;
            this.tbxProdName.Size = new System.Drawing.Size(355, 25);
            this.tbxProdName.TabIndex = 45;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.Control;
            this.lblName.Location = new System.Drawing.Point(124, 540);
            this.lblName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(109, 17);
            this.lblName.TabIndex = 47;
            this.lblName.Text = "Product Name:";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReason.ForeColor = System.Drawing.SystemColors.Control;
            this.lblReason.Location = new System.Drawing.Point(169, 601);
            this.lblReason.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(63, 17);
            this.lblReason.TabIndex = 48;
            this.lblReason.Text = "Reason:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.ForeColor = System.Drawing.SystemColors.Control;
            this.lblQuantity.Location = new System.Drawing.Point(161, 571);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(71, 17);
            this.lblQuantity.TabIndex = 49;
            this.lblQuantity.Text = "Quantity:";
            // 
            // tbxCustName
            // 
            this.tbxCustName.Enabled = false;
            this.tbxCustName.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCustName.Location = new System.Drawing.Point(241, 507);
            this.tbxCustName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbxCustName.Name = "tbxCustName";
            this.tbxCustName.ReadOnly = true;
            this.tbxCustName.Size = new System.Drawing.Size(247, 25);
            this.tbxCustName.TabIndex = 51;
            // 
            // lblCustName
            // 
            this.lblCustName.AutoSize = true;
            this.lblCustName.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustName.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCustName.Location = new System.Drawing.Point(112, 510);
            this.lblCustName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCustName.Name = "lblCustName";
            this.lblCustName.Size = new System.Drawing.Size(121, 17);
            this.lblCustName.TabIndex = 52;
            this.lblCustName.Text = "Customer Name:";
            // 
            // tbxQuantity
            // 
            this.tbxQuantity.Enabled = false;
            this.tbxQuantity.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxQuantity.Location = new System.Drawing.Point(241, 568);
            this.tbxQuantity.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbxQuantity.Name = "tbxQuantity";
            this.tbxQuantity.ReadOnly = true;
            this.tbxQuantity.Size = new System.Drawing.Size(77, 25);
            this.tbxQuantity.TabIndex = 53;
            // 
            // tbxRefundAmt
            // 
            this.tbxRefundAmt.Enabled = false;
            this.tbxRefundAmt.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRefundAmt.Location = new System.Drawing.Point(241, 629);
            this.tbxRefundAmt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbxRefundAmt.Name = "tbxRefundAmt";
            this.tbxRefundAmt.ReadOnly = true;
            this.tbxRefundAmt.Size = new System.Drawing.Size(187, 25);
            this.tbxRefundAmt.TabIndex = 55;
            // 
            // lblRefund
            // 
            this.lblRefund.AutoSize = true;
            this.lblRefund.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefund.ForeColor = System.Drawing.SystemColors.Control;
            this.lblRefund.Location = new System.Drawing.Point(112, 632);
            this.lblRefund.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRefund.Name = "lblRefund";
            this.lblRefund.Size = new System.Drawing.Size(120, 17);
            this.lblRefund.TabIndex = 54;
            this.lblRefund.Text = "Refund Amount:";
            // 
            // chbxReceived
            // 
            this.chbxReceived.AutoSize = true;
            this.chbxReceived.Enabled = false;
            this.chbxReceived.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxReceived.ForeColor = System.Drawing.SystemColors.Control;
            this.chbxReceived.Location = new System.Drawing.Point(457, 631);
            this.chbxReceived.Name = "chbxReceived";
            this.chbxReceived.Size = new System.Drawing.Size(148, 21);
            this.chbxReceived.TabIndex = 57;
            this.chbxReceived.Text = "Product Received";
            this.chbxReceived.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(13, 669);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 27);
            this.btnCancel.TabIndex = 59;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.Location = new System.Drawing.Point(13, 705);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(112, 27);
            this.btnBack.TabIndex = 58;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnApproveReturn
            // 
            this.btnApproveReturn.Enabled = false;
            this.btnApproveReturn.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApproveReturn.Location = new System.Drawing.Point(536, 705);
            this.btnApproveReturn.Name = "btnApproveReturn";
            this.btnApproveReturn.Size = new System.Drawing.Size(145, 33);
            this.btnApproveReturn.TabIndex = 60;
            this.btnApproveReturn.Text = "Approve Return";
            this.btnApproveReturn.UseVisualStyleBackColor = true;
            this.btnApproveReturn.Click += new System.EventHandler(this.btnApproveReturn_Click);
            // 
            // tbxReason
            // 
            this.tbxReason.Enabled = false;
            this.tbxReason.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxReason.Location = new System.Drawing.Point(241, 598);
            this.tbxReason.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbxReason.Name = "tbxReason";
            this.tbxReason.ReadOnly = true;
            this.tbxReason.Size = new System.Drawing.Size(355, 25);
            this.tbxReason.TabIndex = 61;
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErr.ForeColor = System.Drawing.Color.Red;
            this.lblErr.Location = new System.Drawing.Point(220, 696);
            this.lblErr.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(237, 38);
            this.lblErr.TabIndex = 62;
            this.lblErr.Text = "Check Product Received before\r\nselecting Approve Return.\r\n";
            this.lblErr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblErr.Visible = false;
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHelp.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelp.ForeColor = System.Drawing.SystemColors.Control;
            this.lblHelp.Location = new System.Drawing.Point(9, 8);
            this.lblHelp.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(41, 17);
            this.lblHelp.TabIndex = 63;
            this.lblHelp.Text = "Help";
            this.lblHelp.Click += new System.EventHandler(this.lblHelp_Click);
            // 
            // hlpReturnRequests
            // 
            this.hlpReturnRequests.HelpNamespace = "Return Requests Help.chm";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(163, 66);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(367, 25);
            this.lblTitle.TabIndex = 64;
            this.lblTitle.Text = "Select a Return to view and approve.";
            // 
            // lblTitle1
            // 
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle1.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle1.Location = new System.Drawing.Point(249, 26);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(195, 28);
            this.lblTitle1.TabIndex = 65;
            this.lblTitle1.Text = "Return Requests";
            // 
            // frmReturnRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(37)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(693, 743);
            this.Controls.Add(this.lblTitle1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.lblErr);
            this.Controls.Add(this.tbxReason);
            this.Controls.Add(this.btnApproveReturn);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.chbxReceived);
            this.Controls.Add(this.tbxRefundAmt);
            this.Controls.Add(this.lblRefund);
            this.Controls.Add(this.tbxQuantity);
            this.Controls.Add(this.tbxCustName);
            this.Controls.Add(this.lblCustName);
            this.Controls.Add(this.tbxProdName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lbxReturnRequests);
            this.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmReturnRequests";
            this.Text = "Return Requests";
            this.Load += new System.EventHandler(this.frmReturnRequests_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxReturnRequests;
        private System.Windows.Forms.TextBox tbxProdName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox tbxCustName;
        private System.Windows.Forms.Label lblCustName;
        private System.Windows.Forms.TextBox tbxQuantity;
        private System.Windows.Forms.TextBox tbxRefundAmt;
        private System.Windows.Forms.Label lblRefund;
        private System.Windows.Forms.CheckBox chbxReceived;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnApproveReturn;
        private System.Windows.Forms.TextBox tbxReason;
        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.HelpProvider hlpReturnRequests;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTitle1;
    }
}