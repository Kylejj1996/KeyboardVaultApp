namespace KJohnsonFinalProject
{
    partial class frmReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReports));
            this.lblTitle = new System.Windows.Forms.Label();
            this.dateTpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.btnGetSalesReport = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblReportErr = new System.Windows.Forms.Label();
            this.gbxCustomerSales = new System.Windows.Forms.GroupBox();
            this.gbxEmployee = new System.Windows.Forms.GroupBox();
            this.cbxEmployee = new System.Windows.Forms.ComboBox();
            this.lblSelectEmp = new System.Windows.Forms.Label();
            this.btnSearchEmployee = new System.Windows.Forms.Button();
            this.tbxEmployee = new System.Windows.Forms.TextBox();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.chbxEmployee = new System.Windows.Forms.CheckBox();
            this.chbxCustomer = new System.Windows.Forms.CheckBox();
            this.gbxCustomer = new System.Windows.Forms.GroupBox();
            this.cbxCustomer = new System.Windows.Forms.ComboBox();
            this.lblSelectCustomer = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.gbxInventoryReports = new System.Windows.Forms.GroupBox();
            this.rdbAllInv = new System.Windows.Forms.RadioButton();
            this.rdbLowInv = new System.Windows.Forms.RadioButton();
            this.rdbAvailableInv = new System.Windows.Forms.RadioButton();
            this.btnGetInventoryReport = new System.Windows.Forms.Button();
            this.gbxInventory = new System.Windows.Forms.GroupBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.rdbYearly = new System.Windows.Forms.RadioButton();
            this.rdbMonthly = new System.Windows.Forms.RadioButton();
            this.rdbWeekly = new System.Windows.Forms.RadioButton();
            this.rdbDaily = new System.Windows.Forms.RadioButton();
            this.btnGetSales = new System.Windows.Forms.Button();
            this.gbxCustEmpReport = new System.Windows.Forms.GroupBox();
            this.btnEmployeesReports = new System.Windows.Forms.Button();
            this.btnCustomersReports = new System.Windows.Forms.Button();
            this.lblHelp = new System.Windows.Forms.Label();
            this.hlpReports = new System.Windows.Forms.HelpProvider();
            this.gbxRefunds = new System.Windows.Forms.GroupBox();
            this.dtpDateRefunds = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbYearlyRefunds = new System.Windows.Forms.RadioButton();
            this.rdbMonthlyRefunds = new System.Windows.Forms.RadioButton();
            this.rdbWeeklyRefunds = new System.Windows.Forms.RadioButton();
            this.rdbDailyRefunds = new System.Windows.Forms.RadioButton();
            this.btnGetRefundReports = new System.Windows.Forms.Button();
            this.gbxCustomerSales.SuspendLayout();
            this.gbxEmployee.SuspendLayout();
            this.gbxCustomer.SuspendLayout();
            this.gbxInventoryReports.SuspendLayout();
            this.gbxInventory.SuspendLayout();
            this.gbxCustEmpReport.SuspendLayout();
            this.gbxRefunds.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Cambria", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(458, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(330, 34);
            this.lblTitle.TabIndex = 85;
            this.lblTitle.Text = "Keyboard Vault Reports";
            // 
            // dateTpStartDate
            // 
            this.dateTpStartDate.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTpStartDate.Location = new System.Drawing.Point(155, 27);
            this.dateTpStartDate.Name = "dateTpStartDate";
            this.dateTpStartDate.Size = new System.Drawing.Size(287, 25);
            this.dateTpStartDate.TabIndex = 86;
            // 
            // dateTpEndDate
            // 
            this.dateTpEndDate.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTpEndDate.Location = new System.Drawing.Point(155, 66);
            this.dateTpEndDate.Name = "dateTpEndDate";
            this.dateTpEndDate.Size = new System.Drawing.Size(287, 25);
            this.dateTpEndDate.TabIndex = 87;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.ForeColor = System.Drawing.Color.White;
            this.lblStartDate.Location = new System.Drawing.Point(47, 31);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(80, 17);
            this.lblStartDate.TabIndex = 95;
            this.lblStartDate.Text = "Start Date:";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.ForeColor = System.Drawing.Color.White;
            this.lblEndDate.Location = new System.Drawing.Point(62, 70);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(74, 17);
            this.lblEndDate.TabIndex = 94;
            this.lblEndDate.Text = "End Date:";
            // 
            // btnGetSalesReport
            // 
            this.btnGetSalesReport.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetSalesReport.ForeColor = System.Drawing.Color.Black;
            this.btnGetSalesReport.Location = new System.Drawing.Point(170, 236);
            this.btnGetSalesReport.Name = "btnGetSalesReport";
            this.btnGetSalesReport.Size = new System.Drawing.Size(208, 33);
            this.btnGetSalesReport.TabIndex = 98;
            this.btnGetSalesReport.Text = "Get Sales Report";
            this.btnGetSalesReport.UseVisualStyleBackColor = true;
            this.btnGetSalesReport.Click += new System.EventHandler(this.btnGetSalesReport_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(14, 582);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(88, 25);
            this.btnBack.TabIndex = 99;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblReportErr
            // 
            this.lblReportErr.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportErr.ForeColor = System.Drawing.Color.Red;
            this.lblReportErr.Location = new System.Drawing.Point(277, 581);
            this.lblReportErr.Name = "lblReportErr";
            this.lblReportErr.Size = new System.Drawing.Size(854, 26);
            this.lblReportErr.TabIndex = 100;
            this.lblReportErr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxCustomerSales
            // 
            this.gbxCustomerSales.Controls.Add(this.gbxEmployee);
            this.gbxCustomerSales.Controls.Add(this.chbxEmployee);
            this.gbxCustomerSales.Controls.Add(this.chbxCustomer);
            this.gbxCustomerSales.Controls.Add(this.gbxCustomer);
            this.gbxCustomerSales.Controls.Add(this.dateTpStartDate);
            this.gbxCustomerSales.Controls.Add(this.lblStartDate);
            this.gbxCustomerSales.Controls.Add(this.btnGetSalesReport);
            this.gbxCustomerSales.Controls.Add(this.dateTpEndDate);
            this.gbxCustomerSales.Controls.Add(this.lblEndDate);
            this.gbxCustomerSales.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxCustomerSales.ForeColor = System.Drawing.Color.White;
            this.gbxCustomerSales.Location = new System.Drawing.Point(57, 53);
            this.gbxCustomerSales.Name = "gbxCustomerSales";
            this.gbxCustomerSales.Size = new System.Drawing.Size(566, 285);
            this.gbxCustomerSales.TabIndex = 101;
            this.gbxCustomerSales.TabStop = false;
            this.gbxCustomerSales.Text = "Customer Sales Report";
            // 
            // gbxEmployee
            // 
            this.gbxEmployee.Controls.Add(this.cbxEmployee);
            this.gbxEmployee.Controls.Add(this.lblSelectEmp);
            this.gbxEmployee.Controls.Add(this.btnSearchEmployee);
            this.gbxEmployee.Controls.Add(this.tbxEmployee);
            this.gbxEmployee.Controls.Add(this.lblEmpName);
            this.gbxEmployee.Location = new System.Drawing.Point(27, 122);
            this.gbxEmployee.Name = "gbxEmployee";
            this.gbxEmployee.Size = new System.Drawing.Size(511, 109);
            this.gbxEmployee.TabIndex = 105;
            this.gbxEmployee.TabStop = false;
            this.gbxEmployee.Visible = false;
            // 
            // cbxEmployee
            // 
            this.cbxEmployee.Enabled = false;
            this.cbxEmployee.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxEmployee.FormattingEnabled = true;
            this.cbxEmployee.Location = new System.Drawing.Point(170, 65);
            this.cbxEmployee.Name = "cbxEmployee";
            this.cbxEmployee.Size = new System.Drawing.Size(188, 27);
            this.cbxEmployee.TabIndex = 103;
            // 
            // lblSelectEmp
            // 
            this.lblSelectEmp.AutoSize = true;
            this.lblSelectEmp.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectEmp.ForeColor = System.Drawing.Color.White;
            this.lblSelectEmp.Location = new System.Drawing.Point(21, 70);
            this.lblSelectEmp.Name = "lblSelectEmp";
            this.lblSelectEmp.Size = new System.Drawing.Size(125, 17);
            this.lblSelectEmp.TabIndex = 102;
            this.lblSelectEmp.Text = "Select Employee:";
            // 
            // btnSearchEmployee
            // 
            this.btnSearchEmployee.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchEmployee.ForeColor = System.Drawing.Color.Black;
            this.btnSearchEmployee.Location = new System.Drawing.Point(384, 26);
            this.btnSearchEmployee.Name = "btnSearchEmployee";
            this.btnSearchEmployee.Size = new System.Drawing.Size(107, 26);
            this.btnSearchEmployee.TabIndex = 101;
            this.btnSearchEmployee.Text = "Search";
            this.btnSearchEmployee.UseVisualStyleBackColor = true;
            this.btnSearchEmployee.Click += new System.EventHandler(this.btnSearchEmployee_Click);
            // 
            // tbxEmployee
            // 
            this.tbxEmployee.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxEmployee.Location = new System.Drawing.Point(164, 24);
            this.tbxEmployee.Name = "tbxEmployee";
            this.tbxEmployee.Size = new System.Drawing.Size(194, 26);
            this.tbxEmployee.TabIndex = 100;
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpName.ForeColor = System.Drawing.Color.White;
            this.lblEmpName.Location = new System.Drawing.Point(21, 28);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(123, 17);
            this.lblEmpName.TabIndex = 99;
            this.lblEmpName.Text = "Employee Name:";
            // 
            // chbxEmployee
            // 
            this.chbxEmployee.AutoSize = true;
            this.chbxEmployee.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxEmployee.Location = new System.Drawing.Point(93, 96);
            this.chbxEmployee.Name = "chbxEmployee";
            this.chbxEmployee.Size = new System.Drawing.Size(155, 21);
            this.chbxEmployee.TabIndex = 106;
            this.chbxEmployee.Text = "Sales by Employee";
            this.chbxEmployee.UseVisualStyleBackColor = true;
            this.chbxEmployee.CheckedChanged += new System.EventHandler(this.chbxEmployee_CheckedChanged);
            // 
            // chbxCustomer
            // 
            this.chbxCustomer.AutoSize = true;
            this.chbxCustomer.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxCustomer.Location = new System.Drawing.Point(327, 96);
            this.chbxCustomer.Name = "chbxCustomer";
            this.chbxCustomer.Size = new System.Drawing.Size(153, 21);
            this.chbxCustomer.TabIndex = 105;
            this.chbxCustomer.Text = "Sales by Customer";
            this.chbxCustomer.UseVisualStyleBackColor = true;
            this.chbxCustomer.CheckedChanged += new System.EventHandler(this.chbxCustomer_CheckedChanged);
            // 
            // gbxCustomer
            // 
            this.gbxCustomer.Controls.Add(this.cbxCustomer);
            this.gbxCustomer.Controls.Add(this.lblSelectCustomer);
            this.gbxCustomer.Controls.Add(this.btnSearch);
            this.gbxCustomer.Controls.Add(this.tbxCustomerName);
            this.gbxCustomer.Controls.Add(this.lblCustomer);
            this.gbxCustomer.Location = new System.Drawing.Point(27, 122);
            this.gbxCustomer.Name = "gbxCustomer";
            this.gbxCustomer.Size = new System.Drawing.Size(511, 109);
            this.gbxCustomer.TabIndex = 104;
            this.gbxCustomer.TabStop = false;
            this.gbxCustomer.Visible = false;
            // 
            // cbxCustomer
            // 
            this.cbxCustomer.Enabled = false;
            this.cbxCustomer.FormattingEnabled = true;
            this.cbxCustomer.Location = new System.Drawing.Point(170, 65);
            this.cbxCustomer.Name = "cbxCustomer";
            this.cbxCustomer.Size = new System.Drawing.Size(188, 27);
            this.cbxCustomer.TabIndex = 103;
            // 
            // lblSelectCustomer
            // 
            this.lblSelectCustomer.AutoSize = true;
            this.lblSelectCustomer.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectCustomer.ForeColor = System.Drawing.Color.White;
            this.lblSelectCustomer.Location = new System.Drawing.Point(21, 70);
            this.lblSelectCustomer.Name = "lblSelectCustomer";
            this.lblSelectCustomer.Size = new System.Drawing.Size(127, 20);
            this.lblSelectCustomer.TabIndex = 102;
            this.lblSelectCustomer.Text = "Select Customer:";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(384, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(107, 26);
            this.btnSearch.TabIndex = 101;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbxCustomerName
            // 
            this.tbxCustomerName.Location = new System.Drawing.Point(164, 24);
            this.tbxCustomerName.Name = "tbxCustomerName";
            this.tbxCustomerName.Size = new System.Drawing.Size(194, 26);
            this.tbxCustomerName.TabIndex = 100;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.White;
            this.lblCustomer.Location = new System.Drawing.Point(21, 28);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(121, 20);
            this.lblCustomer.TabIndex = 99;
            this.lblCustomer.Text = "Customer Name:";
            // 
            // gbxInventoryReports
            // 
            this.gbxInventoryReports.Controls.Add(this.rdbAllInv);
            this.gbxInventoryReports.Controls.Add(this.rdbLowInv);
            this.gbxInventoryReports.Controls.Add(this.rdbAvailableInv);
            this.gbxInventoryReports.Controls.Add(this.btnGetInventoryReport);
            this.gbxInventoryReports.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxInventoryReports.ForeColor = System.Drawing.Color.White;
            this.gbxInventoryReports.Location = new System.Drawing.Point(57, 360);
            this.gbxInventoryReports.Name = "gbxInventoryReports";
            this.gbxInventoryReports.Size = new System.Drawing.Size(566, 200);
            this.gbxInventoryReports.TabIndex = 102;
            this.gbxInventoryReports.TabStop = false;
            this.gbxInventoryReports.Text = "Inventory Report";
            // 
            // rdbAllInv
            // 
            this.rdbAllInv.AutoSize = true;
            this.rdbAllInv.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbAllInv.Location = new System.Drawing.Point(109, 105);
            this.rdbAllInv.Name = "rdbAllInv";
            this.rdbAllInv.Size = new System.Drawing.Size(288, 21);
            this.rdbAllInv.TabIndex = 101;
            this.rdbAllInv.TabStop = true;
            this.rdbAllInv.Text = "All Products (Including Discontinued)";
            this.rdbAllInv.UseVisualStyleBackColor = true;
            // 
            // rdbLowInv
            // 
            this.rdbLowInv.AutoSize = true;
            this.rdbLowInv.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbLowInv.Location = new System.Drawing.Point(159, 74);
            this.rdbLowInv.Name = "rdbLowInv";
            this.rdbLowInv.Size = new System.Drawing.Size(201, 21);
            this.rdbLowInv.TabIndex = 100;
            this.rdbLowInv.TabStop = true;
            this.rdbLowInv.Text = "All Products low on stock";
            this.rdbLowInv.UseVisualStyleBackColor = true;
            // 
            // rdbAvailableInv
            // 
            this.rdbAvailableInv.AutoSize = true;
            this.rdbAvailableInv.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbAvailableInv.Location = new System.Drawing.Point(170, 42);
            this.rdbAvailableInv.Name = "rdbAvailableInv";
            this.rdbAvailableInv.Size = new System.Drawing.Size(179, 21);
            this.rdbAvailableInv.TabIndex = 99;
            this.rdbAvailableInv.TabStop = true;
            this.rdbAvailableInv.Text = "All Available Products";
            this.rdbAvailableInv.UseVisualStyleBackColor = true;
            // 
            // btnGetInventoryReport
            // 
            this.btnGetInventoryReport.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetInventoryReport.ForeColor = System.Drawing.Color.Black;
            this.btnGetInventoryReport.Location = new System.Drawing.Point(190, 151);
            this.btnGetInventoryReport.Name = "btnGetInventoryReport";
            this.btnGetInventoryReport.Size = new System.Drawing.Size(150, 33);
            this.btnGetInventoryReport.TabIndex = 98;
            this.btnGetInventoryReport.Text = "Get Inventory Report";
            this.btnGetInventoryReport.UseVisualStyleBackColor = true;
            this.btnGetInventoryReport.Click += new System.EventHandler(this.btnGetInventoryReport_Click);
            // 
            // gbxInventory
            // 
            this.gbxInventory.Controls.Add(this.dtpDate);
            this.gbxInventory.Controls.Add(this.lblDate);
            this.gbxInventory.Controls.Add(this.rdbYearly);
            this.gbxInventory.Controls.Add(this.rdbMonthly);
            this.gbxInventory.Controls.Add(this.rdbWeekly);
            this.gbxInventory.Controls.Add(this.rdbDaily);
            this.gbxInventory.Controls.Add(this.btnGetSales);
            this.gbxInventory.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxInventory.ForeColor = System.Drawing.Color.White;
            this.gbxInventory.Location = new System.Drawing.Point(680, 53);
            this.gbxInventory.Name = "gbxInventory";
            this.gbxInventory.Size = new System.Drawing.Size(566, 151);
            this.gbxInventory.TabIndex = 103;
            this.gbxInventory.TabStop = false;
            this.gbxInventory.Text = "Sales Reports";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Location = new System.Drawing.Point(182, 31);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(269, 25);
            this.dtpDate.TabIndex = 103;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(77, 37);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(99, 17);
            this.lblDate.TabIndex = 104;
            this.lblDate.Text = "Select a Date:";
            // 
            // rdbYearly
            // 
            this.rdbYearly.AutoSize = true;
            this.rdbYearly.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbYearly.Location = new System.Drawing.Point(381, 70);
            this.rdbYearly.Name = "rdbYearly";
            this.rdbYearly.Size = new System.Drawing.Size(70, 21);
            this.rdbYearly.TabIndex = 102;
            this.rdbYearly.TabStop = true;
            this.rdbYearly.Text = "Yearly";
            this.rdbYearly.UseVisualStyleBackColor = true;
            // 
            // rdbMonthly
            // 
            this.rdbMonthly.AutoSize = true;
            this.rdbMonthly.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMonthly.Location = new System.Drawing.Point(273, 70);
            this.rdbMonthly.Name = "rdbMonthly";
            this.rdbMonthly.Size = new System.Drawing.Size(84, 21);
            this.rdbMonthly.TabIndex = 101;
            this.rdbMonthly.TabStop = true;
            this.rdbMonthly.Text = "Monthly";
            this.rdbMonthly.UseVisualStyleBackColor = true;
            // 
            // rdbWeekly
            // 
            this.rdbWeekly.AutoSize = true;
            this.rdbWeekly.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbWeekly.Location = new System.Drawing.Point(172, 70);
            this.rdbWeekly.Name = "rdbWeekly";
            this.rdbWeekly.Size = new System.Drawing.Size(77, 21);
            this.rdbWeekly.TabIndex = 100;
            this.rdbWeekly.TabStop = true;
            this.rdbWeekly.Text = "Weekly";
            this.rdbWeekly.UseVisualStyleBackColor = true;
            // 
            // rdbDaily
            // 
            this.rdbDaily.AutoSize = true;
            this.rdbDaily.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDaily.Location = new System.Drawing.Point(90, 70);
            this.rdbDaily.Name = "rdbDaily";
            this.rdbDaily.Size = new System.Drawing.Size(63, 21);
            this.rdbDaily.TabIndex = 99;
            this.rdbDaily.TabStop = true;
            this.rdbDaily.Text = "Daily";
            this.rdbDaily.UseVisualStyleBackColor = true;
            // 
            // btnGetSales
            // 
            this.btnGetSales.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetSales.ForeColor = System.Drawing.Color.Black;
            this.btnGetSales.Location = new System.Drawing.Point(197, 105);
            this.btnGetSales.Name = "btnGetSales";
            this.btnGetSales.Size = new System.Drawing.Size(150, 33);
            this.btnGetSales.TabIndex = 98;
            this.btnGetSales.Text = "Get Sales Report";
            this.btnGetSales.UseVisualStyleBackColor = true;
            this.btnGetSales.Click += new System.EventHandler(this.btnGetSales_Click);
            // 
            // gbxCustEmpReport
            // 
            this.gbxCustEmpReport.Controls.Add(this.btnEmployeesReports);
            this.gbxCustEmpReport.Controls.Add(this.btnCustomersReports);
            this.gbxCustEmpReport.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxCustEmpReport.ForeColor = System.Drawing.Color.White;
            this.gbxCustEmpReport.Location = new System.Drawing.Point(680, 245);
            this.gbxCustEmpReport.Name = "gbxCustEmpReport";
            this.gbxCustEmpReport.Size = new System.Drawing.Size(566, 117);
            this.gbxCustEmpReport.TabIndex = 104;
            this.gbxCustEmpReport.TabStop = false;
            this.gbxCustEmpReport.Text = "Customer and Employee Information Report";
            // 
            // btnEmployeesReports
            // 
            this.btnEmployeesReports.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployeesReports.ForeColor = System.Drawing.Color.Black;
            this.btnEmployeesReports.Location = new System.Drawing.Point(301, 44);
            this.btnEmployeesReports.Name = "btnEmployeesReports";
            this.btnEmployeesReports.Size = new System.Drawing.Size(170, 35);
            this.btnEmployeesReports.TabIndex = 98;
            this.btnEmployeesReports.Text = "Get Employees Report";
            this.btnEmployeesReports.UseVisualStyleBackColor = true;
            this.btnEmployeesReports.Click += new System.EventHandler(this.btnEmployeesReports_Click);
            // 
            // btnCustomersReports
            // 
            this.btnCustomersReports.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomersReports.ForeColor = System.Drawing.Color.Black;
            this.btnCustomersReports.Location = new System.Drawing.Point(57, 44);
            this.btnCustomersReports.Name = "btnCustomersReports";
            this.btnCustomersReports.Size = new System.Drawing.Size(172, 35);
            this.btnCustomersReports.TabIndex = 98;
            this.btnCustomersReports.Text = "Get Customers Report";
            this.btnCustomersReports.UseVisualStyleBackColor = true;
            this.btnCustomersReports.Click += new System.EventHandler(this.btnCustomersReports_Click);
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHelp.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelp.ForeColor = System.Drawing.Color.White;
            this.lblHelp.Location = new System.Drawing.Point(9, 12);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(41, 17);
            this.lblHelp.TabIndex = 105;
            this.lblHelp.Text = "Help";
            this.lblHelp.Click += new System.EventHandler(this.lblHelp_Click);
            // 
            // hlpReports
            // 
            this.hlpReports.HelpNamespace = "Manager Reports Help.chm";
            // 
            // gbxRefunds
            // 
            this.gbxRefunds.Controls.Add(this.dtpDateRefunds);
            this.gbxRefunds.Controls.Add(this.label1);
            this.gbxRefunds.Controls.Add(this.rdbYearlyRefunds);
            this.gbxRefunds.Controls.Add(this.rdbMonthlyRefunds);
            this.gbxRefunds.Controls.Add(this.rdbWeeklyRefunds);
            this.gbxRefunds.Controls.Add(this.rdbDailyRefunds);
            this.gbxRefunds.Controls.Add(this.btnGetRefundReports);
            this.gbxRefunds.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxRefunds.ForeColor = System.Drawing.Color.White;
            this.gbxRefunds.Location = new System.Drawing.Point(680, 409);
            this.gbxRefunds.Name = "gbxRefunds";
            this.gbxRefunds.Size = new System.Drawing.Size(566, 151);
            this.gbxRefunds.TabIndex = 106;
            this.gbxRefunds.TabStop = false;
            this.gbxRefunds.Text = "Refund Reports";
            // 
            // dtpDateRefunds
            // 
            this.dtpDateRefunds.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateRefunds.Location = new System.Drawing.Point(182, 31);
            this.dtpDateRefunds.Name = "dtpDateRefunds";
            this.dtpDateRefunds.Size = new System.Drawing.Size(269, 25);
            this.dtpDateRefunds.TabIndex = 103;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(77, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 104;
            this.label1.Text = "Select a Date:";
            // 
            // rdbYearlyRefunds
            // 
            this.rdbYearlyRefunds.AutoSize = true;
            this.rdbYearlyRefunds.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbYearlyRefunds.Location = new System.Drawing.Point(381, 70);
            this.rdbYearlyRefunds.Name = "rdbYearlyRefunds";
            this.rdbYearlyRefunds.Size = new System.Drawing.Size(70, 21);
            this.rdbYearlyRefunds.TabIndex = 102;
            this.rdbYearlyRefunds.TabStop = true;
            this.rdbYearlyRefunds.Text = "Yearly";
            this.rdbYearlyRefunds.UseVisualStyleBackColor = true;
            // 
            // rdbMonthlyRefunds
            // 
            this.rdbMonthlyRefunds.AutoSize = true;
            this.rdbMonthlyRefunds.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMonthlyRefunds.Location = new System.Drawing.Point(273, 70);
            this.rdbMonthlyRefunds.Name = "rdbMonthlyRefunds";
            this.rdbMonthlyRefunds.Size = new System.Drawing.Size(84, 21);
            this.rdbMonthlyRefunds.TabIndex = 101;
            this.rdbMonthlyRefunds.TabStop = true;
            this.rdbMonthlyRefunds.Text = "Monthly";
            this.rdbMonthlyRefunds.UseVisualStyleBackColor = true;
            // 
            // rdbWeeklyRefunds
            // 
            this.rdbWeeklyRefunds.AutoSize = true;
            this.rdbWeeklyRefunds.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbWeeklyRefunds.Location = new System.Drawing.Point(172, 70);
            this.rdbWeeklyRefunds.Name = "rdbWeeklyRefunds";
            this.rdbWeeklyRefunds.Size = new System.Drawing.Size(77, 21);
            this.rdbWeeklyRefunds.TabIndex = 100;
            this.rdbWeeklyRefunds.TabStop = true;
            this.rdbWeeklyRefunds.Text = "Weekly";
            this.rdbWeeklyRefunds.UseVisualStyleBackColor = true;
            // 
            // rdbDailyRefunds
            // 
            this.rdbDailyRefunds.AutoSize = true;
            this.rdbDailyRefunds.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDailyRefunds.Location = new System.Drawing.Point(90, 70);
            this.rdbDailyRefunds.Name = "rdbDailyRefunds";
            this.rdbDailyRefunds.Size = new System.Drawing.Size(63, 21);
            this.rdbDailyRefunds.TabIndex = 99;
            this.rdbDailyRefunds.TabStop = true;
            this.rdbDailyRefunds.Text = "Daily";
            this.rdbDailyRefunds.UseVisualStyleBackColor = true;
            // 
            // btnGetRefundReports
            // 
            this.btnGetRefundReports.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetRefundReports.ForeColor = System.Drawing.Color.Black;
            this.btnGetRefundReports.Location = new System.Drawing.Point(197, 105);
            this.btnGetRefundReports.Name = "btnGetRefundReports";
            this.btnGetRefundReports.Size = new System.Drawing.Size(150, 33);
            this.btnGetRefundReports.TabIndex = 98;
            this.btnGetRefundReports.Text = "Get Refunds Report";
            this.btnGetRefundReports.UseVisualStyleBackColor = true;
            this.btnGetRefundReports.Click += new System.EventHandler(this.btnGetRefundReports_Click);
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(37)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(1279, 619);
            this.Controls.Add(this.gbxRefunds);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.gbxCustEmpReport);
            this.Controls.Add(this.gbxInventory);
            this.Controls.Add(this.gbxInventoryReports);
            this.Controls.Add(this.gbxCustomerSales);
            this.Controls.Add(this.lblReportErr);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.gbxCustomerSales.ResumeLayout(false);
            this.gbxCustomerSales.PerformLayout();
            this.gbxEmployee.ResumeLayout(false);
            this.gbxEmployee.PerformLayout();
            this.gbxCustomer.ResumeLayout(false);
            this.gbxCustomer.PerformLayout();
            this.gbxInventoryReports.ResumeLayout(false);
            this.gbxInventoryReports.PerformLayout();
            this.gbxInventory.ResumeLayout(false);
            this.gbxInventory.PerformLayout();
            this.gbxCustEmpReport.ResumeLayout(false);
            this.gbxRefunds.ResumeLayout(false);
            this.gbxRefunds.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DateTimePicker dateTpStartDate;
        private System.Windows.Forms.DateTimePicker dateTpEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Button btnGetSalesReport;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblReportErr;
        private System.Windows.Forms.GroupBox gbxCustomerSales;
        private System.Windows.Forms.GroupBox gbxInventoryReports;
        private System.Windows.Forms.Button btnGetInventoryReport;
        private System.Windows.Forms.RadioButton rdbAllInv;
        private System.Windows.Forms.RadioButton rdbLowInv;
        private System.Windows.Forms.RadioButton rdbAvailableInv;
        private System.Windows.Forms.TextBox tbxCustomerName;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cbxCustomer;
        private System.Windows.Forms.Label lblSelectCustomer;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox gbxCustomer;
        private System.Windows.Forms.CheckBox chbxCustomer;
        private System.Windows.Forms.CheckBox chbxEmployee;
        private System.Windows.Forms.GroupBox gbxEmployee;
        private System.Windows.Forms.ComboBox cbxEmployee;
        private System.Windows.Forms.Label lblSelectEmp;
        private System.Windows.Forms.Button btnSearchEmployee;
        private System.Windows.Forms.TextBox tbxEmployee;
        private System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.GroupBox gbxInventory;
        private System.Windows.Forms.RadioButton rdbMonthly;
        private System.Windows.Forms.RadioButton rdbWeekly;
        private System.Windows.Forms.RadioButton rdbDaily;
        private System.Windows.Forms.Button btnGetSales;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.RadioButton rdbYearly;
        private System.Windows.Forms.GroupBox gbxCustEmpReport;
        private System.Windows.Forms.Button btnCustomersReports;
        private System.Windows.Forms.Button btnEmployeesReports;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.HelpProvider hlpReports;
        private System.Windows.Forms.GroupBox gbxRefunds;
        private System.Windows.Forms.DateTimePicker dtpDateRefunds;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbYearlyRefunds;
        private System.Windows.Forms.RadioButton rdbMonthlyRefunds;
        private System.Windows.Forms.RadioButton rdbWeeklyRefunds;
        private System.Windows.Forms.RadioButton rdbDailyRefunds;
        private System.Windows.Forms.Button btnGetRefundReports;
    }
}