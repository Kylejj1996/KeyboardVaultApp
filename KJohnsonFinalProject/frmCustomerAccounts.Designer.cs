namespace KJohnsonFinalProject
{
    partial class frmCustomerAccounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerAccounts));
            this.btnBack = new System.Windows.Forms.Button();
            this.gbxCustomerInfo = new System.Windows.Forms.GroupBox();
            this.lblValidation = new System.Windows.Forms.Label();
            this.chbxAcctDisabled = new System.Windows.Forms.CheckBox();
            this.tbxTitle = new System.Windows.Forms.TextBox();
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblCheckMark = new System.Windows.Forms.Label();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.mTbxPhone2 = new System.Windows.Forms.MaskedTextBox();
            this.mTbxPhone1 = new System.Windows.Forms.MaskedTextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cbxSuffix = new System.Windows.Forms.ComboBox();
            this.lblFName = new System.Windows.Forms.Label();
            this.lblPhone2 = new System.Windows.Forms.Label();
            this.tbxFName = new System.Windows.Forms.TextBox();
            this.tbxLName = new System.Windows.Forms.TextBox();
            this.lblPhone1 = new System.Windows.Forms.Label();
            this.tbxMName = new System.Windows.Forms.TextBox();
            this.lblMName = new System.Windows.Forms.Label();
            this.lblZip = new System.Windows.Forms.Label();
            this.cbxState = new System.Windows.Forms.ComboBox();
            this.tbxZip = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.lblLName = new System.Windows.Forms.Label();
            this.lblSuffix = new System.Windows.Forms.Label();
            this.tbxAddress1 = new System.Windows.Forms.TextBox();
            this.tbxAddress2 = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.tbxCity = new System.Windows.Forms.TextBox();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.lblAddress3 = new System.Windows.Forms.Label();
            this.tbxAddress3 = new System.Windows.Forms.TextBox();
            this.tbxPersonID = new System.Windows.Forms.TextBox();
            this.lbxCustomers = new System.Windows.Forms.ListBox();
            this.btnSearchCustomer = new System.Windows.Forms.Button();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.btnEditCustomerAcct = new System.Windows.Forms.Button();
            this.btnNewCustomer = new System.Windows.Forms.Button();
            this.btnRemoveCustomer = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.lblSearcErr = new System.Windows.Forms.Label();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.lblHelp = new System.Windows.Forms.Label();
            this.hlpCustomerAccts = new System.Windows.Forms.HelpProvider();
            this.gbxCustomerInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.Location = new System.Drawing.Point(12, 660);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(112, 35);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // gbxCustomerInfo
            // 
            this.gbxCustomerInfo.Controls.Add(this.lblValidation);
            this.gbxCustomerInfo.Controls.Add(this.chbxAcctDisabled);
            this.gbxCustomerInfo.Controls.Add(this.tbxTitle);
            this.gbxCustomerInfo.Controls.Add(this.tbxUsername);
            this.gbxCustomerInfo.Controls.Add(this.lblUserName);
            this.gbxCustomerInfo.Controls.Add(this.lblCheckMark);
            this.gbxCustomerInfo.Controls.Add(this.tbxEmail);
            this.gbxCustomerInfo.Controls.Add(this.lblError);
            this.gbxCustomerInfo.Controls.Add(this.lblEmail);
            this.gbxCustomerInfo.Controls.Add(this.mTbxPhone2);
            this.gbxCustomerInfo.Controls.Add(this.mTbxPhone1);
            this.gbxCustomerInfo.Controls.Add(this.lblTitle);
            this.gbxCustomerInfo.Controls.Add(this.cbxSuffix);
            this.gbxCustomerInfo.Controls.Add(this.lblFName);
            this.gbxCustomerInfo.Controls.Add(this.lblPhone2);
            this.gbxCustomerInfo.Controls.Add(this.tbxFName);
            this.gbxCustomerInfo.Controls.Add(this.tbxLName);
            this.gbxCustomerInfo.Controls.Add(this.lblPhone1);
            this.gbxCustomerInfo.Controls.Add(this.tbxMName);
            this.gbxCustomerInfo.Controls.Add(this.lblMName);
            this.gbxCustomerInfo.Controls.Add(this.lblZip);
            this.gbxCustomerInfo.Controls.Add(this.cbxState);
            this.gbxCustomerInfo.Controls.Add(this.tbxZip);
            this.gbxCustomerInfo.Controls.Add(this.lblState);
            this.gbxCustomerInfo.Controls.Add(this.lblLName);
            this.gbxCustomerInfo.Controls.Add(this.lblSuffix);
            this.gbxCustomerInfo.Controls.Add(this.tbxAddress1);
            this.gbxCustomerInfo.Controls.Add(this.tbxAddress2);
            this.gbxCustomerInfo.Controls.Add(this.lblCity);
            this.gbxCustomerInfo.Controls.Add(this.lblAddress1);
            this.gbxCustomerInfo.Controls.Add(this.tbxCity);
            this.gbxCustomerInfo.Controls.Add(this.lblAddress2);
            this.gbxCustomerInfo.Controls.Add(this.lblAddress3);
            this.gbxCustomerInfo.Controls.Add(this.tbxAddress3);
            this.gbxCustomerInfo.Controls.Add(this.tbxPersonID);
            this.gbxCustomerInfo.Enabled = false;
            this.gbxCustomerInfo.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxCustomerInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(228)))), ((int)(((byte)(231)))));
            this.gbxCustomerInfo.Location = new System.Drawing.Point(251, 101);
            this.gbxCustomerInfo.Margin = new System.Windows.Forms.Padding(4);
            this.gbxCustomerInfo.Name = "gbxCustomerInfo";
            this.gbxCustomerInfo.Padding = new System.Windows.Forms.Padding(4);
            this.gbxCustomerInfo.Size = new System.Drawing.Size(738, 422);
            this.gbxCustomerInfo.TabIndex = 46;
            this.gbxCustomerInfo.TabStop = false;
            this.gbxCustomerInfo.Text = "Customer Account Information";
            // 
            // lblValidation
            // 
            this.lblValidation.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidation.ForeColor = System.Drawing.Color.White;
            this.lblValidation.Location = new System.Drawing.Point(15, 391);
            this.lblValidation.Name = "lblValidation";
            this.lblValidation.Size = new System.Drawing.Size(515, 23);
            this.lblValidation.TabIndex = 89;
            // 
            // chbxAcctDisabled
            // 
            this.chbxAcctDisabled.AutoSize = true;
            this.chbxAcctDisabled.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxAcctDisabled.Location = new System.Drawing.Point(581, 390);
            this.chbxAcctDisabled.Name = "chbxAcctDisabled";
            this.chbxAcctDisabled.Size = new System.Drawing.Size(148, 21);
            this.chbxAcctDisabled.TabIndex = 46;
            this.chbxAcctDisabled.Text = "Account Disabled";
            this.chbxAcctDisabled.UseVisualStyleBackColor = true;
            // 
            // tbxTitle
            // 
            this.tbxTitle.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTitle.Location = new System.Drawing.Point(64, 89);
            this.tbxTitle.Margin = new System.Windows.Forms.Padding(4);
            this.tbxTitle.Name = "tbxTitle";
            this.tbxTitle.Size = new System.Drawing.Size(84, 25);
            this.tbxTitle.TabIndex = 4;
            // 
            // tbxUsername
            // 
            this.tbxUsername.Enabled = false;
            this.tbxUsername.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxUsername.Location = new System.Drawing.Point(103, 38);
            this.tbxUsername.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(212, 25);
            this.tbxUsername.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(18, 43);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(82, 17);
            this.lblUserName.TabIndex = 25;
            this.lblUserName.Text = "Username:";
            // 
            // lblCheckMark
            // 
            this.lblCheckMark.AutoSize = true;
            this.lblCheckMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckMark.Location = new System.Drawing.Point(617, 299);
            this.lblCheckMark.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCheckMark.Name = "lblCheckMark";
            this.lblCheckMark.Size = new System.Drawing.Size(0, 24);
            this.lblCheckMark.TabIndex = 43;
            // 
            // tbxEmail
            // 
            this.tbxEmail.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxEmail.Location = new System.Drawing.Point(455, 38);
            this.tbxEmail.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(212, 25);
            this.tbxEmail.TabIndex = 3;
            this.tbxEmail.TextChanged += new System.EventHandler(this.tbxEmail_TextChanged);
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.Location = new System.Drawing.Point(16, 368);
            this.lblError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(719, 15);
            this.lblError.TabIndex = 42;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(394, 43);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(52, 17);
            this.lblEmail.TabIndex = 27;
            this.lblEmail.Text = "Email:";
            // 
            // mTbxPhone2
            // 
            this.mTbxPhone2.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTbxPhone2.Location = new System.Drawing.Point(515, 343);
            this.mTbxPhone2.Margin = new System.Windows.Forms.Padding(4);
            this.mTbxPhone2.Mask = "(999) 000-0000";
            this.mTbxPhone2.Name = "mTbxPhone2";
            this.mTbxPhone2.Size = new System.Drawing.Size(133, 25);
            this.mTbxPhone2.TabIndex = 16;
            // 
            // mTbxPhone1
            // 
            this.mTbxPhone1.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTbxPhone1.Location = new System.Drawing.Point(155, 343);
            this.mTbxPhone1.Margin = new System.Windows.Forms.Padding(4);
            this.mTbxPhone1.Mask = "(999) 000-0000";
            this.mTbxPhone1.Name = "mTbxPhone1";
            this.mTbxPhone1.Size = new System.Drawing.Size(120, 25);
            this.mTbxPhone1.TabIndex = 15;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(19, 91);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(45, 17);
            this.lblTitle.TabIndex = 29;
            this.lblTitle.Text = "Title:";
            // 
            // cbxSuffix
            // 
            this.cbxSuffix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSuffix.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSuffix.FormattingEnabled = true;
            this.cbxSuffix.Location = new System.Drawing.Point(405, 130);
            this.cbxSuffix.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbxSuffix.Name = "cbxSuffix";
            this.cbxSuffix.Size = new System.Drawing.Size(76, 25);
            this.cbxSuffix.TabIndex = 8;
            // 
            // lblFName
            // 
            this.lblFName.AutoSize = true;
            this.lblFName.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFName.Location = new System.Drawing.Point(189, 91);
            this.lblFName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(86, 17);
            this.lblFName.TabIndex = 30;
            this.lblFName.Text = "First Name:";
            // 
            // lblPhone2
            // 
            this.lblPhone2.AutoSize = true;
            this.lblPhone2.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone2.Location = new System.Drawing.Point(360, 347);
            this.lblPhone2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPhone2.Name = "lblPhone2";
            this.lblPhone2.Size = new System.Drawing.Size(132, 17);
            this.lblPhone2.TabIndex = 41;
            this.lblPhone2.Text = "Secondary Phone:";
            // 
            // tbxFName
            // 
            this.tbxFName.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxFName.Location = new System.Drawing.Point(276, 89);
            this.tbxFName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tbxFName.Name = "tbxFName";
            this.tbxFName.Size = new System.Drawing.Size(116, 25);
            this.tbxFName.TabIndex = 5;
            // 
            // tbxLName
            // 
            this.tbxLName.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxLName.Location = new System.Drawing.Point(110, 132);
            this.tbxLName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tbxLName.Name = "tbxLName";
            this.tbxLName.Size = new System.Drawing.Size(184, 25);
            this.tbxLName.TabIndex = 7;
            // 
            // lblPhone1
            // 
            this.lblPhone1.AutoSize = true;
            this.lblPhone1.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone1.Location = new System.Drawing.Point(21, 347);
            this.lblPhone1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPhone1.Name = "lblPhone1";
            this.lblPhone1.Size = new System.Drawing.Size(116, 17);
            this.lblPhone1.TabIndex = 40;
            this.lblPhone1.Text = "Primary Phone:";
            // 
            // tbxMName
            // 
            this.tbxMName.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxMName.Location = new System.Drawing.Point(527, 89);
            this.tbxMName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tbxMName.Name = "tbxMName";
            this.tbxMName.Size = new System.Drawing.Size(168, 25);
            this.tbxMName.TabIndex = 6;
            // 
            // lblMName
            // 
            this.lblMName.AutoSize = true;
            this.lblMName.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMName.Location = new System.Drawing.Point(411, 89);
            this.lblMName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMName.Name = "lblMName";
            this.lblMName.Size = new System.Drawing.Size(103, 17);
            this.lblMName.TabIndex = 31;
            this.lblMName.Text = "Middle Name:";
            // 
            // lblZip
            // 
            this.lblZip.AutoSize = true;
            this.lblZip.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZip.Location = new System.Drawing.Point(442, 303);
            this.lblZip.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblZip.Name = "lblZip";
            this.lblZip.Size = new System.Drawing.Size(34, 17);
            this.lblZip.TabIndex = 39;
            this.lblZip.Text = "Zip:";
            // 
            // cbxState
            // 
            this.cbxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxState.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxState.FormattingEnabled = true;
            this.cbxState.ItemHeight = 17;
            this.cbxState.Location = new System.Drawing.Point(293, 296);
            this.cbxState.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbxState.Name = "cbxState";
            this.cbxState.Size = new System.Drawing.Size(88, 25);
            this.cbxState.TabIndex = 13;
            // 
            // tbxZip
            // 
            this.tbxZip.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxZip.Location = new System.Drawing.Point(476, 299);
            this.tbxZip.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tbxZip.MaxLength = 10;
            this.tbxZip.Name = "tbxZip";
            this.tbxZip.Size = new System.Drawing.Size(130, 25);
            this.tbxZip.TabIndex = 14;
            this.tbxZip.TextChanged += new System.EventHandler(this.tbxZip_TextChanged);
            this.tbxZip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxZip_KeyPress);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(242, 303);
            this.lblState.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(46, 17);
            this.lblState.TabIndex = 38;
            this.lblState.Text = "State:";
            // 
            // lblLName
            // 
            this.lblLName.AutoSize = true;
            this.lblLName.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLName.Location = new System.Drawing.Point(22, 137);
            this.lblLName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLName.Name = "lblLName";
            this.lblLName.Size = new System.Drawing.Size(82, 17);
            this.lblLName.TabIndex = 32;
            this.lblLName.Text = "Last Name:";
            // 
            // lblSuffix
            // 
            this.lblSuffix.AutoSize = true;
            this.lblSuffix.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuffix.Location = new System.Drawing.Point(344, 137);
            this.lblSuffix.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSuffix.Name = "lblSuffix";
            this.lblSuffix.Size = new System.Drawing.Size(52, 17);
            this.lblSuffix.TabIndex = 33;
            this.lblSuffix.Text = "Suffix:";
            // 
            // tbxAddress1
            // 
            this.tbxAddress1.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAddress1.Location = new System.Drawing.Point(110, 175);
            this.tbxAddress1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tbxAddress1.Name = "tbxAddress1";
            this.tbxAddress1.Size = new System.Drawing.Size(313, 25);
            this.tbxAddress1.TabIndex = 9;
            // 
            // tbxAddress2
            // 
            this.tbxAddress2.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAddress2.Location = new System.Drawing.Point(110, 214);
            this.tbxAddress2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tbxAddress2.Name = "tbxAddress2";
            this.tbxAddress2.Size = new System.Drawing.Size(313, 25);
            this.tbxAddress2.TabIndex = 10;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(20, 303);
            this.lblCity.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(39, 17);
            this.lblCity.TabIndex = 37;
            this.lblCity.Text = "City:";
            // 
            // lblAddress1
            // 
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress1.Location = new System.Drawing.Point(20, 177);
            this.lblAddress1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(81, 17);
            this.lblAddress1.TabIndex = 34;
            this.lblAddress1.Text = "Address 1:";
            // 
            // tbxCity
            // 
            this.tbxCity.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCity.Location = new System.Drawing.Point(64, 299);
            this.tbxCity.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tbxCity.Name = "tbxCity";
            this.tbxCity.Size = new System.Drawing.Size(154, 25);
            this.tbxCity.TabIndex = 12;
            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress2.Location = new System.Drawing.Point(20, 216);
            this.lblAddress2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(81, 17);
            this.lblAddress2.TabIndex = 35;
            this.lblAddress2.Text = "Address 2:";
            // 
            // lblAddress3
            // 
            this.lblAddress3.AutoSize = true;
            this.lblAddress3.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress3.Location = new System.Drawing.Point(20, 255);
            this.lblAddress3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAddress3.Name = "lblAddress3";
            this.lblAddress3.Size = new System.Drawing.Size(81, 17);
            this.lblAddress3.TabIndex = 36;
            this.lblAddress3.Text = "Address 3:";
            // 
            // tbxAddress3
            // 
            this.tbxAddress3.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAddress3.Location = new System.Drawing.Point(110, 253);
            this.tbxAddress3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tbxAddress3.Name = "tbxAddress3";
            this.tbxAddress3.Size = new System.Drawing.Size(313, 25);
            this.tbxAddress3.TabIndex = 11;
            // 
            // tbxPersonID
            // 
            this.tbxPersonID.Location = new System.Drawing.Point(527, 89);
            this.tbxPersonID.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tbxPersonID.MaxLength = 10;
            this.tbxPersonID.Name = "tbxPersonID";
            this.tbxPersonID.Size = new System.Drawing.Size(96, 25);
            this.tbxPersonID.TabIndex = 44;
            this.tbxPersonID.Visible = false;
            // 
            // lbxCustomers
            // 
            this.lbxCustomers.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxCustomers.FormattingEnabled = true;
            this.lbxCustomers.ItemHeight = 15;
            this.lbxCustomers.Location = new System.Drawing.Point(27, 108);
            this.lbxCustomers.Name = "lbxCustomers";
            this.lbxCustomers.Size = new System.Drawing.Size(175, 364);
            this.lbxCustomers.TabIndex = 48;
            this.lbxCustomers.Click += new System.EventHandler(this.lbxCustomers_Click);
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCustomer.Location = new System.Drawing.Point(113, 9);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(69, 24);
            this.btnSearchCustomer.TabIndex = 50;
            this.btnSearchCustomer.Text = "Search";
            this.btnSearchCustomer.UseVisualStyleBackColor = true;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            // 
            // tbxSearch
            // 
            this.tbxSearch.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSearch.Location = new System.Drawing.Point(12, 9);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(95, 22);
            this.tbxSearch.TabIndex = 49;
            // 
            // btnEditCustomerAcct
            // 
            this.btnEditCustomerAcct.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditCustomerAcct.ForeColor = System.Drawing.Color.Black;
            this.btnEditCustomerAcct.Location = new System.Drawing.Point(35, 570);
            this.btnEditCustomerAcct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditCustomerAcct.Name = "btnEditCustomerAcct";
            this.btnEditCustomerAcct.Size = new System.Drawing.Size(147, 35);
            this.btnEditCustomerAcct.TabIndex = 64;
            this.btnEditCustomerAcct.Text = "Edit Account";
            this.btnEditCustomerAcct.UseVisualStyleBackColor = true;
            this.btnEditCustomerAcct.Visible = false;
            this.btnEditCustomerAcct.Click += new System.EventHandler(this.btnEditCustomerAcct_Click);
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCustomer.ForeColor = System.Drawing.Color.Black;
            this.btnNewCustomer.Location = new System.Drawing.Point(35, 480);
            this.btnNewCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(147, 35);
            this.btnNewCustomer.TabIndex = 62;
            this.btnNewCustomer.Text = "New Customer";
            this.btnNewCustomer.UseVisualStyleBackColor = true;
            this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
            // 
            // btnRemoveCustomer
            // 
            this.btnRemoveCustomer.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveCustomer.ForeColor = System.Drawing.Color.Black;
            this.btnRemoveCustomer.Location = new System.Drawing.Point(35, 525);
            this.btnRemoveCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRemoveCustomer.Name = "btnRemoveCustomer";
            this.btnRemoveCustomer.Size = new System.Drawing.Size(147, 35);
            this.btnRemoveCustomer.TabIndex = 61;
            this.btnRemoveCustomer.Text = "Remove Account";
            this.btnRemoveCustomer.UseVisualStyleBackColor = true;
            this.btnRemoveCustomer.Visible = false;
            this.btnRemoveCustomer.Click += new System.EventHandler(this.btnRemoveCustomer_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(865, 531);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 29);
            this.btnCancel.TabIndex = 65;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnUpdate.Location = new System.Drawing.Point(735, 531);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(122, 29);
            this.btnUpdate.TabIndex = 66;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.White;
            this.lblSubtitle.Location = new System.Drawing.Point(350, 56);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(492, 22);
            this.lblSubtitle.TabIndex = 88;
            this.lblSubtitle.Text = "Search for a customer to edit their account information.";
            // 
            // lblTitle1
            // 
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.Font = new System.Drawing.Font("Cambria", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle1.ForeColor = System.Drawing.Color.White;
            this.lblTitle1.Location = new System.Drawing.Point(359, 9);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(484, 34);
            this.lblTitle1.TabIndex = 87;
            this.lblTitle1.Text = "Keyboard Vault Customer Accounts";
            // 
            // lblSearcErr
            // 
            this.lblSearcErr.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearcErr.ForeColor = System.Drawing.Color.Red;
            this.lblSearcErr.Location = new System.Drawing.Point(8, 35);
            this.lblSearcErr.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSearcErr.Name = "lblSearcErr";
            this.lblSearcErr.Size = new System.Drawing.Size(235, 59);
            this.lblSearcErr.TabIndex = 89;
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelEdit.ForeColor = System.Drawing.Color.Black;
            this.btnCancelEdit.Location = new System.Drawing.Point(35, 615);
            this.btnCancelEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Size = new System.Drawing.Size(147, 35);
            this.btnCancelEdit.TabIndex = 90;
            this.btnCancelEdit.Text = "Cancel Edit";
            this.btnCancelEdit.UseVisualStyleBackColor = true;
            this.btnCancelEdit.Visible = false;
            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHelp.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelp.ForeColor = System.Drawing.Color.White;
            this.lblHelp.Location = new System.Drawing.Point(1076, 10);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(41, 17);
            this.lblHelp.TabIndex = 100;
            this.lblHelp.Text = "Help";
            this.lblHelp.Click += new System.EventHandler(this.lblHelp_Click);
            // 
            // hlpCustomerAccts
            // 
            this.hlpCustomerAccts.HelpNamespace = "Customer Accounts Help.chm";
            // 
            // frmCustomerAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(37)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(1132, 706);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.btnCancelEdit);
            this.Controls.Add(this.lblSearcErr);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnEditCustomerAcct);
            this.Controls.Add(this.btnNewCustomer);
            this.Controls.Add(this.btnRemoveCustomer);
            this.Controls.Add(this.btnSearchCustomer);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.lbxCustomers);
            this.Controls.Add(this.gbxCustomerInfo);
            this.Controls.Add(this.btnBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCustomerAccounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Accounts";
            this.Load += new System.EventHandler(this.frmCustomerAccounts_Load);
            this.gbxCustomerInfo.ResumeLayout(false);
            this.gbxCustomerInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox gbxCustomerInfo;
        private System.Windows.Forms.TextBox tbxTitle;
        private System.Windows.Forms.Label lblCheckMark;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.MaskedTextBox mTbxPhone2;
        private System.Windows.Forms.MaskedTextBox mTbxPhone1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cbxSuffix;
        private System.Windows.Forms.Label lblFName;
        private System.Windows.Forms.Label lblPhone2;
        private System.Windows.Forms.TextBox tbxFName;
        private System.Windows.Forms.TextBox tbxLName;
        private System.Windows.Forms.Label lblPhone1;
        private System.Windows.Forms.TextBox tbxMName;
        private System.Windows.Forms.Label lblMName;
        private System.Windows.Forms.Label lblZip;
        private System.Windows.Forms.ComboBox cbxState;
        private System.Windows.Forms.TextBox tbxZip;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblLName;
        private System.Windows.Forms.Label lblSuffix;
        private System.Windows.Forms.TextBox tbxAddress1;
        private System.Windows.Forms.TextBox tbxAddress2;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblAddress1;
        private System.Windows.Forms.TextBox tbxCity;
        private System.Windows.Forms.Label lblAddress2;
        private System.Windows.Forms.Label lblAddress3;
        private System.Windows.Forms.TextBox tbxAddress3;
        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox tbxEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.ListBox lbxCustomers;
        private System.Windows.Forms.Button btnSearchCustomer;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Button btnEditCustomerAcct;
        private System.Windows.Forms.Button btnNewCustomer;
        private System.Windows.Forms.Button btnRemoveCustomer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle1;
        private System.Windows.Forms.Label lblSearcErr;
        private System.Windows.Forms.TextBox tbxPersonID;
        private System.Windows.Forms.CheckBox chbxAcctDisabled;
        private System.Windows.Forms.Label lblValidation;
        private System.Windows.Forms.Button btnCancelEdit;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.HelpProvider hlpCustomerAccts;
    }
}