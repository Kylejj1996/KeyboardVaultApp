namespace KJohnsonFinalProject
{
    partial class frmCart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCart));
            this.lbxCart = new System.Windows.Forms.ListBox();
            this.btnContShopping = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.gbxDetails = new System.Windows.Forms.GroupBox();
            this.lblTotalDueTxt = new System.Windows.Forms.Label();
            this.lblSubtotalTxt = new System.Windows.Forms.Label();
            this.lblTaxTxt = new System.Windows.Forms.Label();
            this.lblTotalDue = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblCartEmpty = new System.Windows.Forms.Label();
            this.btnClearCart = new System.Windows.Forms.Button();
            this.btnUpdateQty = new System.Windows.Forms.Button();
            this.cbxQuantity = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblHelp = new System.Windows.Forms.Label();
            this.hlpCart = new System.Windows.Forms.HelpProvider();
            this.gbxDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxCart
            // 
            this.lbxCart.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxCart.FormattingEnabled = true;
            this.lbxCart.ItemHeight = 17;
            this.lbxCart.Location = new System.Drawing.Point(12, 92);
            this.lbxCart.Name = "lbxCart";
            this.lbxCart.ScrollAlwaysVisible = true;
            this.lbxCart.Size = new System.Drawing.Size(714, 276);
            this.lbxCart.TabIndex = 0;
            this.lbxCart.SelectedIndexChanged += new System.EventHandler(this.lbxCart_SelectedIndexChanged);
            // 
            // btnContShopping
            // 
            this.btnContShopping.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContShopping.Location = new System.Drawing.Point(12, 431);
            this.btnContShopping.Name = "btnContShopping";
            this.btnContShopping.Size = new System.Drawing.Size(145, 42);
            this.btnContShopping.TabIndex = 6;
            this.btnContShopping.Text = "Continue Shopping";
            this.btnContShopping.UseVisualStyleBackColor = true;
            this.btnContShopping.Click += new System.EventHandler(this.btnContShopping_Click);
            // 
            // btnCheckout
            // 
            this.btnCheckout.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckout.Location = new System.Drawing.Point(848, 334);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(149, 47);
            this.btnCheckout.TabIndex = 5;
            this.btnCheckout.Text = "Proceed to Checkout";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(12, 383);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(120, 29);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove Item";
            this.btnRemove.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // gbxDetails
            // 
            this.gbxDetails.Controls.Add(this.lblTotalDueTxt);
            this.gbxDetails.Controls.Add(this.lblSubtotalTxt);
            this.gbxDetails.Controls.Add(this.lblTaxTxt);
            this.gbxDetails.Controls.Add(this.lblTotalDue);
            this.gbxDetails.Controls.Add(this.lblSubtotal);
            this.gbxDetails.Controls.Add(this.lblTax);
            this.gbxDetails.Controls.Add(this.lblSubtitle);
            this.gbxDetails.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDetails.Location = new System.Drawing.Point(744, 129);
            this.gbxDetails.Name = "gbxDetails";
            this.gbxDetails.Size = new System.Drawing.Size(352, 199);
            this.gbxDetails.TabIndex = 5;
            this.gbxDetails.TabStop = false;
            // 
            // lblTotalDueTxt
            // 
            this.lblTotalDueTxt.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDueTxt.ForeColor = System.Drawing.Color.White;
            this.lblTotalDueTxt.Location = new System.Drawing.Point(168, 128);
            this.lblTotalDueTxt.Name = "lblTotalDueTxt";
            this.lblTotalDueTxt.Size = new System.Drawing.Size(122, 23);
            this.lblTotalDueTxt.TabIndex = 63;
            // 
            // lblSubtotalTxt
            // 
            this.lblSubtotalTxt.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotalTxt.ForeColor = System.Drawing.Color.White;
            this.lblSubtotalTxt.Location = new System.Drawing.Point(168, 73);
            this.lblSubtotalTxt.Name = "lblSubtotalTxt";
            this.lblSubtotalTxt.Size = new System.Drawing.Size(109, 23);
            this.lblSubtotalTxt.TabIndex = 59;
            // 
            // lblTaxTxt
            // 
            this.lblTaxTxt.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxTxt.ForeColor = System.Drawing.Color.White;
            this.lblTaxTxt.Location = new System.Drawing.Point(168, 99);
            this.lblTaxTxt.Name = "lblTaxTxt";
            this.lblTaxTxt.Size = new System.Drawing.Size(109, 23);
            this.lblTaxTxt.TabIndex = 58;
            // 
            // lblTotalDue
            // 
            this.lblTotalDue.AutoSize = true;
            this.lblTotalDue.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDue.ForeColor = System.Drawing.Color.White;
            this.lblTotalDue.Location = new System.Drawing.Point(58, 128);
            this.lblTotalDue.Name = "lblTotalDue";
            this.lblTotalDue.Size = new System.Drawing.Size(97, 22);
            this.lblTotalDue.TabIndex = 61;
            this.lblTotalDue.Text = "Total Due:";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.ForeColor = System.Drawing.Color.White;
            this.lblSubtotal.Location = new System.Drawing.Point(69, 73);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(88, 22);
            this.lblSubtotal.TabIndex = 57;
            this.lblSubtotal.Text = "Subtotal:";
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTax.ForeColor = System.Drawing.Color.White;
            this.lblTax.Location = new System.Drawing.Point(110, 99);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(46, 22);
            this.lblTax.TabIndex = 56;
            this.lblTax.Text = "Tax:";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.White;
            this.lblSubtitle.Location = new System.Drawing.Point(99, 27);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(144, 25);
            this.lblSubtitle.TabIndex = 55;
            this.lblSubtitle.Text = "Order Details";
            // 
            // lblCartEmpty
            // 
            this.lblCartEmpty.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartEmpty.Location = new System.Drawing.Point(855, 384);
            this.lblCartEmpty.Name = "lblCartEmpty";
            this.lblCartEmpty.Size = new System.Drawing.Size(142, 29);
            this.lblCartEmpty.TabIndex = 7;
            // 
            // btnClearCart
            // 
            this.btnClearCart.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearCart.Location = new System.Drawing.Point(138, 383);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(120, 29);
            this.btnClearCart.TabIndex = 2;
            this.btnClearCart.Text = "Clear Cart";
            this.btnClearCart.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClearCart.UseVisualStyleBackColor = true;
            this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);
            // 
            // btnUpdateQty
            // 
            this.btnUpdateQty.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateQty.Location = new System.Drawing.Point(580, 410);
            this.btnUpdateQty.Name = "btnUpdateQty";
            this.btnUpdateQty.Size = new System.Drawing.Size(147, 29);
            this.btnUpdateQty.TabIndex = 4;
            this.btnUpdateQty.Text = "Update Quantity";
            this.btnUpdateQty.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUpdateQty.UseVisualStyleBackColor = true;
            this.btnUpdateQty.Visible = false;
            this.btnUpdateQty.Click += new System.EventHandler(this.btnUpdateQty_Click);
            // 
            // cbxQuantity
            // 
            this.cbxQuantity.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxQuantity.FormattingEnabled = true;
            this.cbxQuantity.Location = new System.Drawing.Point(594, 383);
            this.cbxQuantity.Name = "cbxQuantity";
            this.cbxQuantity.Size = new System.Drawing.Size(121, 25);
            this.cbxQuantity.TabIndex = 3;
            this.cbxQuantity.Visible = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(411, 29);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(233, 28);
            this.lblTitle.TabIndex = 55;
            this.lblTitle.Text = "Keyboard Vault Cart";
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHelp.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelp.ForeColor = System.Drawing.Color.White;
            this.lblHelp.Location = new System.Drawing.Point(8, 9);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(41, 17);
            this.lblHelp.TabIndex = 59;
            this.lblHelp.Text = "Help";
            this.lblHelp.Click += new System.EventHandler(this.lblHelp_Click);
            // 
            // hlpCart
            // 
            this.hlpCart.HelpNamespace = "Cart Help.chm";
            // 
            // frmCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(37)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(1108, 485);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cbxQuantity);
            this.Controls.Add(this.btnUpdateQty);
            this.Controls.Add(this.btnClearCart);
            this.Controls.Add(this.lblCartEmpty);
            this.Controls.Add(this.gbxDetails);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.btnContShopping);
            this.Controls.Add(this.lbxCart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keyboard Vault Shopping Cart";
            this.Load += new System.EventHandler(this.lbxCart_Load);
            this.gbxDetails.ResumeLayout(false);
            this.gbxDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxCart;
        private System.Windows.Forms.Button btnContShopping;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.GroupBox gbxDetails;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblSubtotalTxt;
        private System.Windows.Forms.Label lblTaxTxt;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblTotalDueTxt;
        private System.Windows.Forms.Label lblTotalDue;
        private System.Windows.Forms.Label lblCartEmpty;
        private System.Windows.Forms.Button btnClearCart;
        private System.Windows.Forms.Button btnUpdateQty;
        private System.Windows.Forms.ComboBox cbxQuantity;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.HelpProvider hlpCart;
    }
}