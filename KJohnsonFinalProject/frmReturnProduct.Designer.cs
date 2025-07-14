namespace KJohnsonFinalProject
{
    partial class frmReturnProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReturnProduct));
            this.btnBack = new System.Windows.Forms.Button();
            this.lbxOrders = new System.Windows.Forms.ListBox();
            this.tbxProdName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.cbxQuantity = new System.Windows.Forms.ComboBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.cbxReason = new System.Windows.Forms.ComboBox();
            this.btnSubmitReturn = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAdd1 = new System.Windows.Forms.Label();
            this.gbxAddress = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblHelp = new System.Windows.Forms.Label();
            this.hlpReturnProducts = new System.Windows.Forms.HelpProvider();
            this.chbxAgree = new System.Windows.Forms.CheckBox();
            this.lblReturnPolicy = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.gbxProductInfo = new System.Windows.Forms.GroupBox();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.gbxAddress.SuspendLayout();
            this.gbxProductInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.Location = new System.Drawing.Point(22, 718);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(112, 32);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lbxOrders
            // 
            this.lbxOrders.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxOrders.FormattingEnabled = true;
            this.lbxOrders.ItemHeight = 19;
            this.lbxOrders.Location = new System.Drawing.Point(72, 105);
            this.lbxOrders.Name = "lbxOrders";
            this.lbxOrders.Size = new System.Drawing.Size(496, 289);
            this.lbxOrders.TabIndex = 5;
            this.lbxOrders.Click += new System.EventHandler(this.lbxOrders_Click);
            // 
            // tbxProdName
            // 
            this.tbxProdName.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxProdName.Location = new System.Drawing.Point(151, 28);
            this.tbxProdName.Margin = new System.Windows.Forms.Padding(4);
            this.tbxProdName.Name = "tbxProdName";
            this.tbxProdName.ReadOnly = true;
            this.tbxProdName.Size = new System.Drawing.Size(364, 26);
            this.tbxProdName.TabIndex = 34;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.Control;
            this.lblName.Location = new System.Drawing.Point(33, 32);
            this.lblName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(109, 17);
            this.lblName.TabIndex = 39;
            this.lblName.Text = "Product Name:";
            // 
            // cbxQuantity
            // 
            this.cbxQuantity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxQuantity.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxQuantity.FormattingEnabled = true;
            this.cbxQuantity.Location = new System.Drawing.Point(151, 74);
            this.cbxQuantity.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbxQuantity.Name = "cbxQuantity";
            this.cbxQuantity.Size = new System.Drawing.Size(76, 27);
            this.cbxQuantity.TabIndex = 38;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReason.ForeColor = System.Drawing.SystemColors.Control;
            this.lblReason.Location = new System.Drawing.Point(79, 123);
            this.lblReason.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(63, 17);
            this.lblReason.TabIndex = 40;
            this.lblReason.Text = "Reason:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.ForeColor = System.Drawing.SystemColors.Control;
            this.lblQuantity.Location = new System.Drawing.Point(71, 78);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(71, 17);
            this.lblQuantity.TabIndex = 43;
            this.lblQuantity.Text = "Quantity:";
            // 
            // cbxReason
            // 
            this.cbxReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxReason.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxReason.FormattingEnabled = true;
            this.cbxReason.Location = new System.Drawing.Point(151, 119);
            this.cbxReason.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbxReason.Name = "cbxReason";
            this.cbxReason.Size = new System.Drawing.Size(364, 27);
            this.cbxReason.TabIndex = 44;
            // 
            // btnSubmitReturn
            // 
            this.btnSubmitReturn.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitReturn.Location = new System.Drawing.Point(374, 154);
            this.btnSubmitReturn.Name = "btnSubmitReturn";
            this.btnSubmitReturn.Size = new System.Drawing.Size(145, 32);
            this.btnSubmitReturn.TabIndex = 45;
            this.btnSubmitReturn.Text = "Submit Return";
            this.btnSubmitReturn.UseVisualStyleBackColor = true;
            this.btnSubmitReturn.Click += new System.EventHandler(this.btnSubmitReturn_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(131, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(378, 28);
            this.lblTitle.TabIndex = 46;
            this.lblTitle.Text = "All orders within the last 14 days.";
            // 
            // lblAdd1
            // 
            this.lblAdd1.AutoSize = true;
            this.lblAdd1.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdd1.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAdd1.Location = new System.Drawing.Point(38, 26);
            this.lblAdd1.Name = "lblAdd1";
            this.lblAdd1.Size = new System.Drawing.Size(142, 51);
            this.lblAdd1.TabIndex = 48;
            this.lblAdd1.Text = "Keyboard Vault Inc.\r\n2868 N. Main St.\r\nDallas TX, 78955";
            // 
            // gbxAddress
            // 
            this.gbxAddress.Controls.Add(this.lblAdd1);
            this.gbxAddress.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxAddress.ForeColor = System.Drawing.SystemColors.Control;
            this.gbxAddress.Location = new System.Drawing.Point(410, 658);
            this.gbxAddress.Name = "gbxAddress";
            this.gbxAddress.Size = new System.Drawing.Size(208, 92);
            this.gbxAddress.TabIndex = 49;
            this.gbxAddress.TabStop = false;
            this.gbxAddress.Text = "Return Address";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(22, 676);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 32);
            this.btnCancel.TabIndex = 50;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHelp.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelp.ForeColor = System.Drawing.SystemColors.Control;
            this.lblHelp.Location = new System.Drawing.Point(9, 9);
            this.lblHelp.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(41, 17);
            this.lblHelp.TabIndex = 51;
            this.lblHelp.Text = "Help";
            this.lblHelp.Click += new System.EventHandler(this.lblHelp_Click);
            // 
            // hlpReturnProducts
            // 
            this.hlpReturnProducts.HelpNamespace = "Returning Products Help.chm";
            // 
            // chbxAgree
            // 
            this.chbxAgree.AutoSize = true;
            this.chbxAgree.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxAgree.ForeColor = System.Drawing.SystemColors.Control;
            this.chbxAgree.Location = new System.Drawing.Point(124, 165);
            this.chbxAgree.Name = "chbxAgree";
            this.chbxAgree.Size = new System.Drawing.Size(213, 21);
            this.chbxAgree.TabIndex = 52;
            this.chbxAgree.Text = "I agree to the Return Policy";
            this.chbxAgree.UseVisualStyleBackColor = true;
            this.chbxAgree.CheckedChanged += new System.EventHandler(this.chbxAgree_CheckedChanged);
            // 
            // lblReturnPolicy
            // 
            this.lblReturnPolicy.AutoSize = true;
            this.lblReturnPolicy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblReturnPolicy.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnPolicy.ForeColor = System.Drawing.Color.Teal;
            this.lblReturnPolicy.Location = new System.Drawing.Point(11, 165);
            this.lblReturnPolicy.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReturnPolicy.Name = "lblReturnPolicy";
            this.lblReturnPolicy.Size = new System.Drawing.Size(102, 17);
            this.lblReturnPolicy.TabIndex = 53;
            this.lblReturnPolicy.Text = "Return Policy";
            this.lblReturnPolicy.Click += new System.EventHandler(this.lblReturnPolicy_Click);
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblError.Location = new System.Drawing.Point(100, 634);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(441, 21);
            this.lblError.TabIndex = 54;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxProductInfo
            // 
            this.gbxProductInfo.Controls.Add(this.tbxProdName);
            this.gbxProductInfo.Controls.Add(this.lblQuantity);
            this.gbxProductInfo.Controls.Add(this.lblReturnPolicy);
            this.gbxProductInfo.Controls.Add(this.lblReason);
            this.gbxProductInfo.Controls.Add(this.chbxAgree);
            this.gbxProductInfo.Controls.Add(this.cbxQuantity);
            this.gbxProductInfo.Controls.Add(this.lblName);
            this.gbxProductInfo.Controls.Add(this.cbxReason);
            this.gbxProductInfo.Controls.Add(this.btnSubmitReturn);
            this.gbxProductInfo.Enabled = false;
            this.gbxProductInfo.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxProductInfo.Location = new System.Drawing.Point(49, 414);
            this.gbxProductInfo.Name = "gbxProductInfo";
            this.gbxProductInfo.Size = new System.Drawing.Size(541, 204);
            this.gbxProductInfo.TabIndex = 55;
            this.gbxProductInfo.TabStop = false;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblSubtitle.Location = new System.Drawing.Point(196, 67);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(230, 22);
            this.lblSubtitle.TabIndex = 56;
            this.lblSubtitle.Text = "Select an Order to Return";
            // 
            // frmReturnProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(37)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(640, 768);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.gbxProductInfo);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbxAddress);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lbxOrders);
            this.Controls.Add(this.btnBack);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmReturnProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Return Products";
            this.Load += new System.EventHandler(this.frmReturnProduct_Load);
            this.gbxAddress.ResumeLayout(false);
            this.gbxAddress.PerformLayout();
            this.gbxProductInfo.ResumeLayout(false);
            this.gbxProductInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ListBox lbxOrders;
        private System.Windows.Forms.TextBox tbxProdName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cbxQuantity;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.ComboBox cbxReason;
        private System.Windows.Forms.Button btnSubmitReturn;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAdd1;
        private System.Windows.Forms.GroupBox gbxAddress;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.HelpProvider hlpReturnProducts;
        private System.Windows.Forms.CheckBox chbxAgree;
        private System.Windows.Forms.Label lblReturnPolicy;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.GroupBox gbxProductInfo;
        private System.Windows.Forms.Label lblSubtitle;
    }
}