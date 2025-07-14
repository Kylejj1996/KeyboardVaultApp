namespace KJohnsonFinalProject
{
    partial class frmCustomerView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerView));
            this.flowLayoutPanelProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.flpCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCart = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pbxKeyboardImg = new System.Windows.Forms.PictureBox();
            this.lblKeyboardName = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblPriceTxt = new System.Windows.Forms.Label();
            this.lblStockTxt = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.cbxQuantity = new System.Windows.Forms.ComboBox();
            this.lblQuantityErr = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblProductID = new System.Windows.Forms.Label();
            this.gbxProductDetails = new System.Windows.Forms.GroupBox();
            this.lblDescriptionTxt = new System.Windows.Forms.TextBox();
            this.lblSoldOut = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.hlpCustomerView = new System.Windows.Forms.HelpProvider();
            this.lblHelp = new System.Windows.Forms.Label();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.btnPurchaseHistory = new System.Windows.Forms.Button();
            this.btnSearchCustomer = new System.Windows.Forms.Button();
            this.tbxSearchCustomer = new System.Windows.Forms.TextBox();
            this.cbxSearchedCustomer = new System.Windows.Forms.ComboBox();
            this.gbxSearchCustomer = new System.Windows.Forms.GroupBox();
            this.btnCancelCustomer = new System.Windows.Forms.Button();
            this.btnSelectCustomer = new System.Windows.Forms.Button();
            this.lblCustSearchErr = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnShopForCustomer = new System.Windows.Forms.Button();
            this.btnShopAsManager = new System.Windows.Forms.Button();
            this.btnNewCustomer = new System.Windows.Forms.Button();
            this.lblShoppingFor = new System.Windows.Forms.Label();
            this.lblReturnProd = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxKeyboardImg)).BeginInit();
            this.gbxProductDetails.SuspendLayout();
            this.gbxSearchCustomer.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelProducts
            // 
            this.flowLayoutPanelProducts.AutoScroll = true;
            this.flowLayoutPanelProducts.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanelProducts.ForeColor = System.Drawing.Color.Black;
            this.flowLayoutPanelProducts.Location = new System.Drawing.Point(176, 158);
            this.flowLayoutPanelProducts.Name = "flowLayoutPanelProducts";
            this.flowLayoutPanelProducts.Size = new System.Drawing.Size(569, 496);
            this.flowLayoutPanelProducts.TabIndex = 1;
            // 
            // flpCategories
            // 
            this.flpCategories.AutoScroll = true;
            this.flpCategories.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flpCategories.Location = new System.Drawing.Point(12, 158);
            this.flpCategories.Name = "flpCategories";
            this.flpCategories.Size = new System.Drawing.Size(145, 445);
            this.flpCategories.TabIndex = 0;
            // 
            // lblCart
            // 
            this.lblCart.AutoSize = true;
            this.lblCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCart.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCart.ForeColor = System.Drawing.Color.White;
            this.lblCart.Location = new System.Drawing.Point(1105, 9);
            this.lblCart.Name = "lblCart";
            this.lblCart.Size = new System.Drawing.Size(75, 17);
            this.lblCart.TabIndex = 33;
            this.lblCart.Text = "View Cart";
            this.lblCart.Click += new System.EventHandler(this.lblCart_Click);
            this.lblCart.MouseLeave += new System.EventHandler(this.lblCart_MouseLeave);
            this.lblCart.MouseHover += new System.EventHandler(this.lblCart_MouseHover);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.Location = new System.Drawing.Point(27, 752);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(112, 35);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tbxSearch
            // 
            this.tbxSearch.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSearch.Location = new System.Drawing.Point(12, 43);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(95, 23);
            this.tbxSearch.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(113, 43);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(69, 24);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pbxKeyboardImg
            // 
            this.pbxKeyboardImg.BackColor = System.Drawing.Color.White;
            this.pbxKeyboardImg.Location = new System.Drawing.Point(27, 39);
            this.pbxKeyboardImg.Name = "pbxKeyboardImg";
            this.pbxKeyboardImg.Size = new System.Drawing.Size(380, 318);
            this.pbxKeyboardImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxKeyboardImg.TabIndex = 42;
            this.pbxKeyboardImg.TabStop = false;
            // 
            // lblKeyboardName
            // 
            this.lblKeyboardName.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyboardName.ForeColor = System.Drawing.Color.White;
            this.lblKeyboardName.Location = new System.Drawing.Point(95, 13);
            this.lblKeyboardName.Name = "lblKeyboardName";
            this.lblKeyboardName.Size = new System.Drawing.Size(228, 23);
            this.lblKeyboardName.TabIndex = 43;
            this.lblKeyboardName.Text = "Product";
            this.lblKeyboardName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(312, 593);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 35);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add to Cart";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.ForeColor = System.Drawing.Color.White;
            this.lblStock.Location = new System.Drawing.Point(21, 542);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(50, 17);
            this.lblStock.TabIndex = 45;
            this.lblStock.Text = "Stock:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.White;
            this.lblPrice.Location = new System.Drawing.Point(21, 498);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(48, 17);
            this.lblPrice.TabIndex = 46;
            this.lblPrice.Text = "Price:";
            // 
            // lblPriceTxt
            // 
            this.lblPriceTxt.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceTxt.ForeColor = System.Drawing.Color.White;
            this.lblPriceTxt.Location = new System.Drawing.Point(75, 498);
            this.lblPriceTxt.Name = "lblPriceTxt";
            this.lblPriceTxt.Size = new System.Drawing.Size(92, 23);
            this.lblPriceTxt.TabIndex = 49;
            // 
            // lblStockTxt
            // 
            this.lblStockTxt.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockTxt.ForeColor = System.Drawing.Color.White;
            this.lblStockTxt.Location = new System.Drawing.Point(75, 542);
            this.lblStockTxt.Name = "lblStockTxt";
            this.lblStockTxt.Size = new System.Drawing.Size(92, 23);
            this.lblStockTxt.TabIndex = 48;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.ForeColor = System.Drawing.Color.White;
            this.lblQuantity.Location = new System.Drawing.Point(21, 582);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(71, 17);
            this.lblQuantity.TabIndex = 51;
            this.lblQuantity.Text = "Quantity:";
            this.lblQuantity.Visible = false;
            // 
            // cbxQuantity
            // 
            this.cbxQuantity.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxQuantity.FormattingEnabled = true;
            this.cbxQuantity.Location = new System.Drawing.Point(99, 578);
            this.cbxQuantity.Name = "cbxQuantity";
            this.cbxQuantity.Size = new System.Drawing.Size(76, 27);
            this.cbxQuantity.TabIndex = 0;
            this.cbxQuantity.Visible = false;
            // 
            // lblQuantityErr
            // 
            this.lblQuantityErr.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantityErr.Location = new System.Drawing.Point(24, 605);
            this.lblQuantityErr.Name = "lblQuantityErr";
            this.lblQuantityErr.Size = new System.Drawing.Size(165, 19);
            this.lblQuantityErr.TabIndex = 53;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(437, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(321, 37);
            this.lblTitle.TabIndex = 54;
            this.lblTitle.Text = "Keyboard Vault Shop";
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductID.ForeColor = System.Drawing.Color.White;
            this.lblProductID.Location = new System.Drawing.Point(1100, 47);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(0, 23);
            this.lblProductID.TabIndex = 55;
            this.lblProductID.Visible = false;
            // 
            // gbxProductDetails
            // 
            this.gbxProductDetails.Controls.Add(this.lblDescriptionTxt);
            this.gbxProductDetails.Controls.Add(this.lblSoldOut);
            this.gbxProductDetails.Controls.Add(this.lblQuantityErr);
            this.gbxProductDetails.Controls.Add(this.cbxQuantity);
            this.gbxProductDetails.Controls.Add(this.lblQuantity);
            this.gbxProductDetails.Controls.Add(this.lblKeyboardName);
            this.gbxProductDetails.Controls.Add(this.lblPriceTxt);
            this.gbxProductDetails.Controls.Add(this.lblStockTxt);
            this.gbxProductDetails.Controls.Add(this.lblPrice);
            this.gbxProductDetails.Controls.Add(this.lblStock);
            this.gbxProductDetails.Controls.Add(this.btnAdd);
            this.gbxProductDetails.Controls.Add(this.pbxKeyboardImg);
            this.gbxProductDetails.Location = new System.Drawing.Point(742, 122);
            this.gbxProductDetails.Name = "gbxProductDetails";
            this.gbxProductDetails.Size = new System.Drawing.Size(431, 636);
            this.gbxProductDetails.TabIndex = 2;
            this.gbxProductDetails.TabStop = false;
            this.gbxProductDetails.Visible = false;
            // 
            // lblDescriptionTxt
            // 
            this.lblDescriptionTxt.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptionTxt.Location = new System.Drawing.Point(27, 363);
            this.lblDescriptionTxt.Multiline = true;
            this.lblDescriptionTxt.Name = "lblDescriptionTxt";
            this.lblDescriptionTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lblDescriptionTxt.Size = new System.Drawing.Size(380, 126);
            this.lblDescriptionTxt.TabIndex = 55;
            // 
            // lblSoldOut
            // 
            this.lblSoldOut.AutoSize = true;
            this.lblSoldOut.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoldOut.ForeColor = System.Drawing.Color.Red;
            this.lblSoldOut.Location = new System.Drawing.Point(194, 582);
            this.lblSoldOut.Name = "lblSoldOut";
            this.lblSoldOut.Size = new System.Drawing.Size(72, 19);
            this.lblSoldOut.TabIndex = 54;
            this.lblSoldOut.Text = "Sold Out";
            this.lblSoldOut.Visible = false;
            // 
            // lblSearch
            // 
            this.lblSearch.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(12, 70);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(228, 38);
            this.lblSearch.TabIndex = 57;
            // 
            // hlpCustomerView
            // 
            this.hlpCustomerView.HelpNamespace = "Customer View Help.chm";
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHelp.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelp.ForeColor = System.Drawing.Color.White;
            this.lblHelp.Location = new System.Drawing.Point(9, 9);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(41, 17);
            this.lblHelp.TabIndex = 58;
            this.lblHelp.Text = "Help";
            this.lblHelp.Click += new System.EventHandler(this.lblHelp_Click);
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblInstructions.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.ForeColor = System.Drawing.Color.White;
            this.lblInstructions.Location = new System.Drawing.Point(124, 122);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(390, 22);
            this.lblInstructions.TabIndex = 59;
            this.lblInstructions.Text = "Select a Catergory, or search for a keyboard.";
            // 
            // btnPurchaseHistory
            // 
            this.btnPurchaseHistory.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchaseHistory.ForeColor = System.Drawing.Color.Black;
            this.btnPurchaseHistory.Location = new System.Drawing.Point(12, 703);
            this.btnPurchaseHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPurchaseHistory.Name = "btnPurchaseHistory";
            this.btnPurchaseHistory.Size = new System.Drawing.Size(157, 31);
            this.btnPurchaseHistory.TabIndex = 60;
            this.btnPurchaseHistory.Text = "Order History";
            this.btnPurchaseHistory.UseVisualStyleBackColor = true;
            this.btnPurchaseHistory.Click += new System.EventHandler(this.btnPurchaseHistory_Click);
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCustomer.ForeColor = System.Drawing.Color.Black;
            this.btnSearchCustomer.Location = new System.Drawing.Point(162, 25);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(69, 26);
            this.btnSearchCustomer.TabIndex = 62;
            this.btnSearchCustomer.Text = "Search";
            this.btnSearchCustomer.UseVisualStyleBackColor = true;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            // 
            // tbxSearchCustomer
            // 
            this.tbxSearchCustomer.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSearchCustomer.Location = new System.Drawing.Point(9, 25);
            this.tbxSearchCustomer.Name = "tbxSearchCustomer";
            this.tbxSearchCustomer.Size = new System.Drawing.Size(147, 25);
            this.tbxSearchCustomer.TabIndex = 61;
            // 
            // cbxSearchedCustomer
            // 
            this.cbxSearchedCustomer.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSearchedCustomer.FormattingEnabled = true;
            this.cbxSearchedCustomer.Location = new System.Drawing.Point(237, 25);
            this.cbxSearchedCustomer.Name = "cbxSearchedCustomer";
            this.cbxSearchedCustomer.Size = new System.Drawing.Size(149, 25);
            this.cbxSearchedCustomer.TabIndex = 63;
            // 
            // gbxSearchCustomer
            // 
            this.gbxSearchCustomer.Controls.Add(this.btnCancelCustomer);
            this.gbxSearchCustomer.Controls.Add(this.btnSelectCustomer);
            this.gbxSearchCustomer.Controls.Add(this.lblCustSearchErr);
            this.gbxSearchCustomer.Controls.Add(this.cbxSearchedCustomer);
            this.gbxSearchCustomer.Controls.Add(this.btnSearchCustomer);
            this.gbxSearchCustomer.Controls.Add(this.tbxSearchCustomer);
            this.gbxSearchCustomer.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxSearchCustomer.ForeColor = System.Drawing.Color.White;
            this.gbxSearchCustomer.Location = new System.Drawing.Point(204, 690);
            this.gbxSearchCustomer.Name = "gbxSearchCustomer";
            this.gbxSearchCustomer.Size = new System.Drawing.Size(532, 93);
            this.gbxSearchCustomer.TabIndex = 64;
            this.gbxSearchCustomer.TabStop = false;
            this.gbxSearchCustomer.Text = "Search for a customer to shop for";
            this.gbxSearchCustomer.Visible = false;
            // 
            // btnCancelCustomer
            // 
            this.btnCancelCustomer.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelCustomer.ForeColor = System.Drawing.Color.Black;
            this.btnCancelCustomer.Location = new System.Drawing.Point(393, 57);
            this.btnCancelCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelCustomer.Name = "btnCancelCustomer";
            this.btnCancelCustomer.Size = new System.Drawing.Size(132, 28);
            this.btnCancelCustomer.TabIndex = 67;
            this.btnCancelCustomer.Text = "Cancel";
            this.btnCancelCustomer.UseVisualStyleBackColor = true;
            this.btnCancelCustomer.Click += new System.EventHandler(this.btnCancelCustomer_Click);
            // 
            // btnSelectCustomer
            // 
            this.btnSelectCustomer.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectCustomer.ForeColor = System.Drawing.Color.Black;
            this.btnSelectCustomer.Location = new System.Drawing.Point(393, 23);
            this.btnSelectCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelectCustomer.Name = "btnSelectCustomer";
            this.btnSelectCustomer.Size = new System.Drawing.Size(132, 28);
            this.btnSelectCustomer.TabIndex = 65;
            this.btnSelectCustomer.Text = "Select Customer";
            this.btnSelectCustomer.UseVisualStyleBackColor = true;
            this.btnSelectCustomer.Click += new System.EventHandler(this.btnSelectCustomer_Click);
            // 
            // lblCustSearchErr
            // 
            this.lblCustSearchErr.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustSearchErr.ForeColor = System.Drawing.Color.Red;
            this.lblCustSearchErr.Location = new System.Drawing.Point(6, 62);
            this.lblCustSearchErr.Name = "lblCustSearchErr";
            this.lblCustSearchErr.Size = new System.Drawing.Size(350, 23);
            this.lblCustSearchErr.TabIndex = 66;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblWelcome.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(436, 55);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(325, 38);
            this.lblWelcome.TabIndex = 65;
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnShopForCustomer
            // 
            this.btnShopForCustomer.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShopForCustomer.ForeColor = System.Drawing.Color.Black;
            this.btnShopForCustomer.Location = new System.Drawing.Point(12, 664);
            this.btnShopForCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnShopForCustomer.Name = "btnShopForCustomer";
            this.btnShopForCustomer.Size = new System.Drawing.Size(156, 29);
            this.btnShopForCustomer.TabIndex = 66;
            this.btnShopForCustomer.Text = "Shop for Customer";
            this.btnShopForCustomer.UseVisualStyleBackColor = true;
            this.btnShopForCustomer.Visible = false;
            this.btnShopForCustomer.Click += new System.EventHandler(this.btnShopForCustomer_Click);
            // 
            // btnShopAsManager
            // 
            this.btnShopAsManager.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShopAsManager.ForeColor = System.Drawing.Color.Black;
            this.btnShopAsManager.Location = new System.Drawing.Point(12, 625);
            this.btnShopAsManager.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnShopAsManager.Name = "btnShopAsManager";
            this.btnShopAsManager.Size = new System.Drawing.Size(156, 29);
            this.btnShopAsManager.TabIndex = 67;
            this.btnShopAsManager.Text = "Shop as Manager";
            this.btnShopAsManager.UseVisualStyleBackColor = true;
            this.btnShopAsManager.Visible = false;
            this.btnShopAsManager.Click += new System.EventHandler(this.btnShopAsManager_Click);
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCustomer.ForeColor = System.Drawing.Color.Black;
            this.btnNewCustomer.Location = new System.Drawing.Point(13, 664);
            this.btnNewCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(156, 29);
            this.btnNewCustomer.TabIndex = 68;
            this.btnNewCustomer.Text = "Change Customer";
            this.btnNewCustomer.UseVisualStyleBackColor = true;
            this.btnNewCustomer.Visible = false;
            this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
            // 
            // lblShoppingFor
            // 
            this.lblShoppingFor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblShoppingFor.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShoppingFor.ForeColor = System.Drawing.Color.White;
            this.lblShoppingFor.Location = new System.Drawing.Point(440, 70);
            this.lblShoppingFor.Name = "lblShoppingFor";
            this.lblShoppingFor.Size = new System.Drawing.Size(305, 38);
            this.lblShoppingFor.TabIndex = 69;
            this.lblShoppingFor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReturnProd
            // 
            this.lblReturnProd.AutoSize = true;
            this.lblReturnProd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblReturnProd.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnProd.ForeColor = System.Drawing.Color.White;
            this.lblReturnProd.Location = new System.Drawing.Point(1037, 9);
            this.lblReturnProd.Name = "lblReturnProd";
            this.lblReturnProd.Size = new System.Drawing.Size(63, 17);
            this.lblReturnProd.TabIndex = 70;
            this.lblReturnProd.Text = "Returns";
            this.lblReturnProd.Visible = false;
            this.lblReturnProd.Click += new System.EventHandler(this.lblReturnProd_Click);
            // 
            // frmCustomerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(37)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(1194, 800);
            this.Controls.Add(this.lblReturnProd);
            this.Controls.Add(this.lblShoppingFor);
            this.Controls.Add(this.btnShopAsManager);
            this.Controls.Add(this.btnShopForCustomer);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.gbxSearchCustomer);
            this.Controls.Add(this.btnPurchaseHistory);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.gbxProductDetails);
            this.Controls.Add(this.lblProductID);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblCart);
            this.Controls.Add(this.flpCategories);
            this.Controls.Add(this.flowLayoutPanelProducts);
            this.Controls.Add(this.btnNewCustomer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCustomerView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keyboard Vault Shop";
            this.Load += new System.EventHandler(this.frmCustomerView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxKeyboardImg)).EndInit();
            this.gbxProductDetails.ResumeLayout(false);
            this.gbxProductDetails.PerformLayout();
            this.gbxSearchCustomer.ResumeLayout(false);
            this.gbxSearchCustomer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProducts;
        private System.Windows.Forms.FlowLayoutPanel flpCategories;
        private System.Windows.Forms.Label lblCart;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox pbxKeyboardImg;
        private System.Windows.Forms.Label lblKeyboardName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblPriceTxt;
        private System.Windows.Forms.Label lblStockTxt;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.ComboBox cbxQuantity;
        private System.Windows.Forms.Label lblQuantityErr;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.GroupBox gbxProductDetails;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.HelpProvider hlpCustomerView;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.Label lblSoldOut;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Button btnPurchaseHistory;
        private System.Windows.Forms.TextBox lblDescriptionTxt;
        private System.Windows.Forms.Button btnSearchCustomer;
        private System.Windows.Forms.TextBox tbxSearchCustomer;
        private System.Windows.Forms.ComboBox cbxSearchedCustomer;
        private System.Windows.Forms.GroupBox gbxSearchCustomer;
        private System.Windows.Forms.Button btnSelectCustomer;
        private System.Windows.Forms.Label lblCustSearchErr;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnShopForCustomer;
        private System.Windows.Forms.Button btnShopAsManager;
        private System.Windows.Forms.Button btnNewCustomer;
        private System.Windows.Forms.Button btnCancelCustomer;
        private System.Windows.Forms.Label lblShoppingFor;
        private System.Windows.Forms.Label lblReturnProd;
    }
}