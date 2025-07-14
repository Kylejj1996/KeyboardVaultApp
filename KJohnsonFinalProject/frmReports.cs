using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KJohnsonFinalProject
{
    public partial class frmReports : Form
    {
        //Variables
        List<Inventory> inventoryList = new List<Inventory>();//List object to store the inventory details
        List<string[]> ordersList = new List<string[]>();//List to store the order details
        public static List<Person> searchedPersonList = new List<Person>();//List to store the searched person
        public static bool customerReport = false;
        public static bool employeeReport = false;
        StringBuilder html = new StringBuilder();

        public frmReports()
        {
            InitializeComponent();
        }

        //Closes the Reports form
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();//Closing the reports form
        }

        //Retrieves daily, weekly, monthly, or yearly sales data based on the selected date and report type.
        //It generates and displays the sales report.
        private void btnGetSales_Click(object sender, EventArgs e)
        {
            //Getting the selected date
            DateTime date = dtpDate.Value;
            string formattedDate = date.ToString("yyyy-MM-dd");

            string reportType = "";
            string reportTypeName = "Sales_Report";

            //Checking to see which radio button is selected to get that inventory report
            if (rdbDaily.Checked)//Daily
            {
                reportType = "Daily";
                lblReportErr.Text = "";
            }
            else if (rdbWeekly.Checked)//Weekly
            {
                reportType = "Weekly";
                lblReportErr.Text = "";
            }
            else if (rdbMonthly.Checked)//Monthly
            {
                reportType = "Monthly";
                lblReportErr.Text = "";
            }
            else if (rdbYearly.Checked)
            {
                reportType = "Yearly";
                lblReportErr.Text = "";
            }
            else
            {
                //Telling the user to select a report type
                lblReportErr.Text = "Please select a report type for Sales Reports.";
                return;
            }

            List<string[]> salesResult = clsSQL.getSalesReports(formattedDate, reportType);//Calling the method to get sales reports

            //Calling the method to generate the report
            html = GenerateHTMLReportSales(salesResult, date, reportType);

            //Calling the method print the report
            PrintReport(html, reportTypeName);
        }


        //Retrieves sales data for a selected customer or employee within a specified date range,
        //generates a customer or employee sales report, and displays the report.
        private void btnGetSalesReport_Click(object sender, EventArgs e)
        {
            //Getting the selected startDate and endDate
            string startDate = dateTpStartDate.Value.ToString("yyyy-MM-dd");
            string endDate = dateTpEndDate.Value.ToString("yyyy-MM-dd");
            string personName = "";
            string personID = "";
            string reportTypeName = "Customer_Sales_Report";

            if (!chbxCustomer.Checked && !chbxEmployee.Checked)
            {
                lblReportErr.Text = "Please select either customer or employee for their sales report.";
                return;
            }

            //If the customer checkBox is checked, set the customer name to the selected name from the comboBox
            if (chbxCustomer.Checked)
            {
                if (cbxCustomer.SelectedItem == null)
                {
                    lblReportErr.Text = "Please select a customer.";
                    return;
                }

                int index = cbxCustomer.SelectedIndex;//Getting the selected index
                
                if (index >= 0 && index < searchedPersonList.Count)
                {
                    Person person = searchedPersonList[index];//Getting the selected customer
                    personID = person.PersonID.ToString();//Getting the personID
                }
                else
                {
                    lblReportErr.Text = "Invalid customer selection.";
                    return;
                }

                personName = cbxCustomer.SelectedItem.ToString();//Assigning the customers name
                customerReport = true;

            }
            else if (chbxEmployee.Checked)
            {
                if (cbxEmployee.SelectedItem == null)
                {
                    lblReportErr.Text = "Please select an employee.";
                    return;
                }

                int index = cbxEmployee.SelectedIndex;//Getting the selected Index

                if (index >= 0 && index < searchedPersonList.Count)
                {
                    Person person = searchedPersonList[index];//Getting the selected employee
                    personID = person.PersonID.ToString();
                }
                else
                {
                    lblReportErr.Text = "Invalid employee selection.";
                    return;
                }

                personName = cbxEmployee.SelectedItem.ToString();//Assigning the employees name
                employeeReport = true;
            }

            //Getting the selected startDate and endDate to display in the report
            DateTime start = dateTpStartDate.Value.Date;
            DateTime end = dateTpEndDate.Value.Date;

            //Checking if the start date is after the end date
            if (start > end)
            {
                lblReportErr.Text = "Start date cannot be after the end date.";
                return;
            }
            else
            {
                lblReportErr.Text = "";
            }

            //Adding the date range to a string
            string dateRange = $"{start:MMMM d, yyyy} to {end:MMMM d, yyyy}";

            ordersList.Clear();//Clearing the ordersList

            //Adding the orders to the sales list
            ordersList = clsSQL.getCustomerSalesReports(startDate, endDate, personID);

            //Checking if the personName is filled
            if (!string.IsNullOrWhiteSpace(personName))
            {
                string lowerCustomerName = personName.Trim().ToLower();

                ordersList = ordersList.Where(order =>(order[9] + " " + order[10]).ToLower().Contains(lowerCustomerName)).ToList();
            }

            //Calling the method to generate the report
            html = GenerateHTMLCustReportSales(ordersList, dateRange, personName);

            //Calling the method print the report
            PrintReport(html, reportTypeName);

            //Clearing the customer fields
            tbxCustomerName.Text = "";
            cbxCustomer.Items.Clear();//Clearing the customer comboBox
            cbxCustomer.Text = "";
            cbxCustomer.Enabled = false;
            customerReport = false;

            //Clearing the employee fields
            tbxEmployee.Text = "";
            cbxEmployee.Items.Clear();
            cbxEmployee.Text = "";
            cbxEmployee.Enabled = false;
            employeeReport = false;
        }

        //Retrieves inventory data based on the selected report type (All available, low stock, or all products including discontinued),
        //generates an inventory report, and displays the report.
        private void btnGetInventoryReport_Click(object sender, EventArgs e)
        {
            string reportType = "";
            string reportTypeName = "Inventory_Report";
            //Checking to see which radio button is selected to get that inventory report
            if (rdbAvailableInv.Checked)//Available inventory
            {
                reportType = "Available Products";
                lblReportErr.Text = "";
            }
            else if (rdbLowInv.Checked)//Low stock inventory
            {
                reportType = "Products with Low Stock";
                lblReportErr.Text = "";
            }
            else if (rdbAllInv.Checked)//All inventory in the database
            {
                reportType = "All Products (Including Discontinued)";
                lblReportErr.Text = "";
            }
            else
            {
                //Telling the user to select a report type
                lblReportErr.Text = "Please select a report type for Inventory Reports.";
                return;
            }

            inventoryList.Clear();//Clearing the inventory List

            //Adding the inventory Results to the inventory List
            inventoryList = clsSQL.getInventoryReports();

            //Calling the method to generate the report
            html = GenerateHTMLReportInventory(inventoryList, reportType);

            //Calling the method print the report
            PrintReport(html, reportTypeName);
        }

        //Generates a customer report using the current customer list and prints the report.
        private void btnCustomersReports_Click(object sender, EventArgs e)
        {
            string reportTypeName = "Customer_Report";

            //Calling the method to generate the report
            html = GenerateHTMLCustomer(frmManagerView.customerList);

            PrintReport(html, reportTypeName);
        }

        //Generates an employee report using the current employee list and prints the report.
        private void btnEmployeesReports_Click(object sender, EventArgs e)
        {
            string reportTypeName = "Employee_Report";

            //Calling the method to generate the report
            html = GenerateHTMLEmployees(frmManagerView.employeeList);

            PrintReport(html, reportTypeName);
        }

        /// <summary>
        /// Generates an HTML report containing customer information formatted in a table.
        /// </summary>
        /// <param name="customerList">A list of Person objects with the customers whose information will be displayed in the report.</param>
        /// <returns>A stringBuilder with the generated HTML.</returns>
        private StringBuilder GenerateHTMLCustomer(List<Person> customerList)
        {
            //Creating a new string builder to hold the HTML
            StringBuilder html = new StringBuilder();

            //Creating the HTML
            html.AppendLine("<style>");
            html.AppendLine("body {background-color: #1C2541; font-family: Arial, sans-serif; color: black;}");
            html.AppendLine(".report-container {max-width: 95%; background-color: #F9FBF2; margin: 40px auto; padding: 30px; border-radius: 15px; color: black; box-shadow: 0 0 15px rgba(0,0,0,0.3);}");
            html.AppendLine("table {width: 100%; border-collapse: collapse;}");
            html.AppendLine("th, td {border: 1px solid #ccc; padding: 10px; text-align: left;}");
            html.AppendLine("th {background-color: #1C2541; color: white;}");
            html.AppendLine("tr:nth-child(even) {background-color: #f2f2f2;}");
            html.AppendLine("</style>");

            html.AppendLine("<html><body>");
            html.AppendLine("<div class='report-container'>");
            html.AppendLine("<h1>Keyboard Vault</h1>");
            html.AppendLine("<h2>Customers Report</h2>");

            html.AppendLine("<table>");
            html.AppendLine("<thead><tr>");
            html.AppendLine("<th>Name</th><th>Title</th><th>Address</th><th>Email</th><th>Phone</th><th>Account Disabled</th><th>Account Deleted</th>");
            html.AppendLine("</tr></thead>");
            html.AppendLine("<tbody>");

            //Looping through the customers list
            foreach (Person customer in customerList)
            {
                string positionTitle = customer.PositionTitle;
                string customerFName = customer.NameFirst; 
                string customerLName = customer.NameLast;
                string address = customer.Address1;
                string address2 = customer.Address2;
                string address3 = customer.Address3;  
                string city = customer.City;
                string state = customer.State;
                string zip = customer.Zipcode;
                string email = customer.Email;
                string phone = customer.PhonePrimary;
                string accountDisabled = customer.AccountDisabled ? "Yes" : "No";
                string accountDeleted = customer.AccountDeleted ? "Yes" : "No";

                StringBuilder fullAddress = new StringBuilder();
                fullAddress.AppendLine($"{address}<br/>");
                if (!string.IsNullOrWhiteSpace(address2))
                    fullAddress.AppendLine($"{address2}<br/>");
                if (!string.IsNullOrWhiteSpace(address3))
                    fullAddress.AppendLine($"{address3}<br/>");
                fullAddress.AppendLine($"{city}, {state} {zip}");


                html.AppendLine("<tr>");
                html.AppendLine($"<td>{customerFName} {customerLName}</td>");
                html.AppendLine($"<td>{positionTitle}</td>");
                html.AppendLine($"<td>{fullAddress}</td>");
                html.AppendLine($"<td>{email}</td>");
                html.AppendLine($"<td>{phone}</td>");
                html.AppendLine($"<td>{accountDisabled}</td>");
                html.AppendLine($"<td>{accountDeleted}</td>");
                html.AppendLine("</tr>");
            }

            html.AppendLine("</tbody>");
            html.AppendLine("</table>");
            html.AppendLine("</div></body></html>");

            return html;
        }

        /// <summary>
        /// Generates an HTML report containing employee information formatted in a table.
        /// </summary>
        /// <param name="employeeList">A list of Person objects with the employees whose information will be displayed in the report.</param>
        /// <returns>A stringBuilder with the generated HTML.</returns>
        private StringBuilder GenerateHTMLEmployees(List<Person> employeeList)
        {
            //Creating a new string builder to hold the HTML
            StringBuilder html = new StringBuilder();

            //Creating the HTML
            html.AppendLine("<style>");
            html.AppendLine("body {background-color: #1C2541; font-family: Arial, sans-serif; color: black;}");
            html.AppendLine(".report-container {max-width: 95%; background-color: #F9FBF2; margin: 40px auto; padding: 30px; border-radius: 15px; color: black; box-shadow: 0 0 15px rgba(0,0,0,0.3);}");
            html.AppendLine("table {width: 100%; border-collapse: collapse;}");
            html.AppendLine("th, td {border: 1px solid #ccc; padding: 10px; text-align: left;}");
            html.AppendLine("th {background-color: #1C2541; color: white;}");
            html.AppendLine("tr:nth-child(even) {background-color: #f2f2f2;}");
            html.AppendLine("</style>");
            html.AppendLine("<html><body>");
            html.AppendLine("<div class='report-container'>");
            html.AppendLine("<h1>Keyboard Vault</h1>");
            html.AppendLine("<h2>Employees Report</h2>");
            html.AppendLine("<table>");
            html.AppendLine("<thead><tr>");
            html.AppendLine("<th>Name</th><th>Title</th><th>Address</th><th>Email</th><th>Phone</th><th>Account Disabled</th><th>Account Deleted</th>");
            html.AppendLine("</tr></thead>");
            html.AppendLine("<tbody>");

            //Looping through the employees list
            foreach (Person employee in employeeList)
            {
                string positionTitle = employee.PositionTitle;
                string employeeFName = employee.NameFirst;
                string employeeLName = employee.NameLast;
                string address = employee.Address1;
                string address2 = employee.Address2;
                string address3 = employee.Address3;
                string city = employee.City;
                string state = employee.State;
                string zip = employee.Zipcode;
                string email = employee.Email;
                string phone = employee.PhonePrimary;
                string accountDisabled = employee.AccountDisabled ? "Yes" : "No";
                string accountDeleted = employee.AccountDeleted ? "Yes" : "No";

                //String Builder to combine the address
                StringBuilder fullAddress = new StringBuilder();

                fullAddress.AppendLine($"{address}<br/>");
                if (!string.IsNullOrWhiteSpace(address2))
                    fullAddress.AppendLine($"{address2}<br/>");
                if (!string.IsNullOrWhiteSpace(address3))
                    fullAddress.AppendLine($"{address3}<br/>");
                fullAddress.AppendLine($"{city}, {state} {zip}");

                html.AppendLine("<tr>");
                html.AppendLine($"<td>{employeeFName} {employeeLName}</td>");
                html.AppendLine($"<td>{positionTitle}</td>");
                html.AppendLine($"<td>{fullAddress}</td>");
                html.AppendLine($"<td>{email}</td>");
                html.AppendLine($"<td>{phone}</td>");
                html.AppendLine($"<td>{accountDisabled}</td>");
                html.AppendLine($"<td>{accountDeleted}</td>");
                html.AppendLine("</tr>");
            }

            html.AppendLine("</tbody>");
            html.AppendLine("</table>");
            html.AppendLine("</div></body></html>");

            return html;
        }

        /// <summary>
        /// Generates an HTML sales report including detailed order information, discounts, taxes, refunds, and total sales.
        /// </summary>
        /// <param name="ordersList">A list of string arrays with order data to include in the report.</param>
        /// <param name="dateRange">The date range included in the report.</param>
        /// <param name="personName">The name of the customer or employee the report was created for.</param>
        /// <returns>A stringBuilder with the generated HTML.</returns>
        private StringBuilder GenerateHTMLCustReportSales(List<string[]> ordersList, string dateRange, string personName)
        {
            //Creating a new string builder to build the HTML
            StringBuilder html = new StringBuilder();

            decimal taxRate = 0.0825m;//The tax Rate
            string taxRateText = "8.25%";

            //The HTML for the Sales Reports
            html.AppendLine("<style>");
            html.AppendLine("body {background-color: #1C2541; font-family: Arial, sans-serif; color: black; margin: 0; padding: 0;}");
            html.AppendLine(".report-container {width: 95%; max-width: 1000px; background-color: #F9FBF2; margin: 40px auto; padding: 20px; border-radius: 15px; color: black; box-shadow: 0 0 15px rgba(0,0,0,0.3);}");
            html.AppendLine("h1, h3 {text-align: left; color: #1C2541;}");
            html.AppendLine("table {width: 100%; border-collapse: collapse; margin-top: 20px; table-layout: auto;}");
            html.AppendLine("th, td {border: 1px solid #ccc; padding: 10px; text-align: left; word-wrap: break-word;}");
            html.AppendLine("th {background-color: #1C2541; color: white;}");
            html.AppendLine("tr:nth-child(even) {background-color: #f2f2f2;}");
            html.AppendLine(".summary {margin-top: 30px; font-size: 16px; text-align: right;}");
            html.AppendLine(".tblTotal td {background-color: #dfefff; font-weight: bold;}");
            html.AppendLine("</style>");

            html.AppendLine("<html><body>");
            html.AppendLine("<div class='report-container'>");
            html.AppendLine("<h1>Keyboard Vault Sales Report</h1>");
            html.AppendLine($"<h3>Sales Summary for: {dateRange}</h3>");

            if (customerReport == true)
            {
                html.AppendLine($"<h3>Customer Name: {personName}</h3>");
            }
            else if (employeeReport == true)
            {
                html.AppendLine($"<h3>Employee Name: {personName}</h3>");
            }

            var groupedOrders = ordersList.GroupBy(p => p[0]);//Keeping the orders together

            //Variables to hold the Total sales
            decimal totalSales = 0;

            //Looping through each item in the orders list
            foreach (var orderGroup in groupedOrders)
            {
                string orderID = orderGroup.Key;//Order ID for the current Order group
                string orderDate = Convert.ToDateTime(orderGroup.First()[1]).ToShortDateString();
                decimal itemTotal = 0;
                decimal cartDiscountAmount = 0;
                decimal itemDiscountAmount = 0;
                decimal totalItemDiscount = 0;
                decimal totalRefunds = 0;
                bool cartDiscountApplied = false;//Boolean to keep track if the cart discount has been applied

                html.AppendLine("<table>");
                html.AppendLine($"<tr><th colspan='6'>Order Number: {orderID} | Order Date: {orderDate}</th></tr>");
                html.AppendLine("<tr><th>Product Name</th><th>Price</th><th>Cost</th><th>Quantity</th><th>Item Total</th><th>Status</th></tr>");

                //For each loop to loop through each item in the order group
                foreach (var order in orderGroup)
                {
                    string itemName = order[2];
                    decimal price = Convert.ToDecimal(order[3]);
                    decimal cost = Convert.ToDecimal(order[4]); 
                    int quantity = Convert.ToInt32(order[5]);
                    int refundedQuantity = Convert.ToInt32(order[13]);
                    decimal refundedAmount = Convert.ToDecimal(order[14]);
                    decimal discountPercent = order[6] != "NULL" ? Convert.ToDecimal(order[6]) : 0;
                    decimal discountDollar = order[7] != "NULL" ? Convert.ToDecimal(order[7]) : 0;
                    string discountLevel = order[8];// 1 - Item Level, 0 - Cart Level
                    string orderDetailsInvID = order[11].ToString();
                    string discountInvID = order[12] != null ? order[12].ToString() : "NULL";
                    itemDiscountAmount = 0;

                    //Getting the total price of each item and their quantity
                    decimal itemTotalPrice = price * quantity;

                    //If else to add the discount to the sales receipt
                    if (discountLevel == "1" && orderDetailsInvID == discountInvID)//ItemLevel discount
                    {
                        if (discountPercent > 0)
                        {
                            itemDiscountAmount = itemTotalPrice * discountPercent;
                        }
                        else if (discountDollar > 0)
                        {
                            itemDiscountAmount = discountDollar * quantity;
                        }
                    }

                    //Adding to the orders item total
                    decimal finalTotal = itemTotalPrice;

                    //Adding to the itemtotal and itemProfit
                    itemTotal += finalTotal;

                    //Adding to the total Item discount
                    totalItemDiscount += itemDiscountAmount;

                    string status;

                    //If the product was refunded
                    if (refundedQuantity > 0)
                    {
                        status = "Refunded";
                        html.AppendLine($"<tr><td>{itemName}</td><td>{price:C}</td><td>{cost:C}</td><td>{quantity}</td><td>{itemTotalPrice:C}</td><td style='color:red'>{status}</td></tr>");
                    }
                    else//If the product wasn't refunded
                    {
                        status = "Purchased";
                        html.AppendLine($"<tr><td>{itemName}</td><td>{price:C}</td><td>{cost:C}</td><td>{quantity}</td><td>{itemTotalPrice:C}</td><td style='color:green'>{status}</td></tr>");
                    }
                    //Calculating the refunded amount
                    totalRefunds += refundedAmount;
                }

                //For Cart discounts
                if (!cartDiscountApplied)
                {
                    //Finding a row in the ordergroup where the discount is cartLevel
                    var cartDiscountRow = orderGroup.FirstOrDefault(p => p[8] == "0");//DiscountLevel == CartDiscount
                    //If there is a cartLevel Discount
                    if (cartDiscountRow != null)
                    {
                        //Checking for percent or dollar discount
                        decimal discountPercent = cartDiscountRow[6] != "NULL" ? Convert.ToDecimal(cartDiscountRow[6]) : 0;
                        decimal discountDollar = cartDiscountRow[7] != "NULL" ? Convert.ToDecimal(cartDiscountRow[7]) : 0;

                        if (discountPercent > 0)
                        {
                            cartDiscountAmount = itemTotal * discountPercent;//Getting the cartDiscount using the percent
                        }
                        else if (discountDollar > 0)
                        {
                            cartDiscountAmount = discountDollar;//Getting the cartDiscount if it is a dollar amount
                        }

                        cartDiscountApplied = true;//Setting to true
                    }
                }

                //Subtracting the cartLevel discount once from the item total
                decimal orderSubTotal = itemTotal;
                decimal totalDiscounts = cartDiscountAmount + totalItemDiscount;
                decimal refundedAmt = totalRefunds;
                decimal orderTotal = itemTotal - totalDiscounts;//Subtracting the total discounts from the total

                //Calculating the tax and the order total with tax
                decimal taxAmount = orderTotal * taxRate;
                decimal orderTotalWithTax = orderTotal + taxAmount - refundedAmt;


                html.AppendLine($"<tr><td colspan='5' style='text-align:right;'><strong>Subtotal:</strong></td><td><strong>{orderSubTotal:C}</strong></td></tr>");

                //Showing cart or item discount if there is one
                if (cartDiscountAmount > 0)
                {
                    html.AppendLine($"<tr><td colspan='5' style='text-align:right;font-weight:bold;'>Cart Discount Applied:</td><td style='font-weight:bold;'>-{cartDiscountAmount:C}</td></tr>");
                }
                else if (totalItemDiscount > 0)
                {
                    html.AppendLine($"<tr><td colspan='5' style='text-align:right;font-weight:bold;'>Item Discount Applied:</td><td style='font-weight:bold;'>-{totalItemDiscount:C}</td></tr>");
                }

                //Showing the tax and order total with tax
                html.AppendLine($"<tr><td colspan='5' style='text-align:right;'><strong>Tax ({taxRateText}):</strong></td><td><strong>{taxAmount:C}</strong></td></tr>");
                if (refundedAmt > 0)
                {
                    html.AppendLine($"<tr><td colspan='5' style='text-align:right; color:red;'><strong>Refunded Amount:</strong></td><td style='color:red;'><strong>-{refundedAmt:C}</strong></td></tr>");
                }
                html.AppendLine($"<tr class='tblTotal'><td colspan='5' style='text-align:right;'><strong>Order Total (with tax):</strong></td><td><strong>{orderTotalWithTax:C}</strong></td></tr>");
                html.AppendLine("</table>");

                totalSales += orderTotalWithTax;
            }

            html.AppendLine("<div class='summary'>");
            html.AppendLine($"<p><strong>Total Sales (with tax): {totalSales:C}</strong></p>");
            html.AppendLine("</div>");

            html.AppendLine("</div></body></html>");

            return html;
            
        }

        /// <summary>
        /// Generates an HTML sales report for daily, weekly, monthly or daily.
        /// Inluding overall sales totals, tax, discounts, and product summary.
        /// </summary>
        /// <param name="ordersList">A list of string arrays with order data to include in the report.</param>
        /// <param name="date">The date associated with the report.</param>
        /// <param name="reportType">The type of report being generated (Daily, Weekly, Monthly, Yearkly).</param>
        /// <returns>A stringBuilder with the generated HTML.</returns>
        private StringBuilder GenerateHTMLReportSales(List<string[]> ordersList, DateTime date, string reportType)
        {
            //Creating a new string builder to build the HTML
            StringBuilder html = new StringBuilder();
            decimal taxRate = 0.0825m;//Tax rate

            //Totals for the entire report
            int totalOrders = 0;
            int totalItemsSold = 0;
            decimal totalSalesBeforeTax = 0;
            decimal totalDiscountAmount = 0;

            var groupedOrders = ordersList.GroupBy(p => p[0]);//Grouping by OrderID
            totalOrders = groupedOrders.Count();

            //Looping through each order
            foreach (var orderGroup in groupedOrders)
            {
                //Subtotals and bool for each order
                decimal orderSubtotal = 0;
                decimal cartDiscountAmount = 0;
                bool cartDiscountApplied = false;

                //Looping through each item in the order
                foreach (var order in orderGroup)
                {
                    //Getting the order details from the order array
                    decimal price = Convert.ToDecimal(order[3]);
                    decimal cost = Convert.ToDecimal(order[4]);
                    int quantity = Convert.ToInt32(order[5]);
                    decimal discountPercent = order[6] != "NULL" ? Convert.ToDecimal(order[6]) : 0;
                    decimal discountDollar = order[7] != "NULL" ? Convert.ToDecimal(order[7]) : 0;
                    string discountLevel = order[8];

                    decimal itemTotalPrice = price * quantity;
                    decimal itemDiscountAmount = 0;

                    //Applying the item-level discount
                    if (discountLevel == "1")
                    {
                        itemDiscountAmount = discountPercent > 0 ? itemTotalPrice * discountPercent : discountDollar;
                    }
                    //Applying the cart-level discount one time
                    else if (discountLevel == "0" && !cartDiscountApplied)
                    {
                        cartDiscountAmount = discountPercent > 0 ? itemTotalPrice * discountPercent : discountDollar;
                        cartDiscountApplied = true;
                    }

                    //The final item price after the discount
                    decimal finalTotal = itemTotalPrice - itemDiscountAmount;

                    //Updating the totals
                    orderSubtotal += finalTotal;
                    totalItemsSold += quantity;
                    totalDiscountAmount += itemDiscountAmount;
                }
                //Subtracting the cartLevel discount from the subtotal
                orderSubtotal -= cartDiscountAmount;
                totalDiscountAmount += cartDiscountAmount;
                totalSalesBeforeTax += orderSubtotal;
            }

            //Grouping the products and the quantites ordered
            var productSummary = ordersList.GroupBy(o => o[2]).Select(g => new {ProductName = g.Key, Quantity = g.Sum(x => Convert.ToInt32(x[5])) }).OrderByDescending(x => x.Quantity).ToList();

            //Calculating the total tax and total price 
            decimal totalTax = totalSalesBeforeTax * taxRate;
            decimal totalSale = totalSalesBeforeTax + totalTax;

            //String to hold the date lable
            string dateLabel;
        
            //Switch to create the date label
            switch (reportType)
            {
                case "Daily":
                    dateLabel = $"for {date.ToString("MMMM dd, yyyy")}";
                    break;
                case "Weekly":
                    dateLabel = $"for week of {date.ToString("MMMM dd, yyyy")}";
                    break;
                case "Monthly":
                    dateLabel = $"for {date.ToString("MMMM yyyy")}";
                    break;
                case "Yearly":
                    dateLabel = $"for year {date.Year}";
                    break;
                default:
                    dateLabel = date.ToString();
                    break;
            }

            //Creating the HTML 
            html.AppendLine("<style>");
            html.AppendLine("body {background-color: #1C2541; font-family: Arial, sans-serif; color: black;}");
            html.AppendLine(".report-container {max-width: 800px; background-color: #F9FBF2; margin: 40px auto; padding: 30px; border-radius: 15px; color: black; box-shadow: 0 0 15px rgba(0,0,0,0.3);}");
            html.AppendLine("h1, h2, h3 {color: #1C2541;}");
            html.AppendLine("p {font-size: 18px; margin-bottom: 12px;}");
            html.AppendLine("table {width: 100%; border-collapse: collapse; margin-top: 20px;}");
            html.AppendLine("th, td {padding: 12px 15px; text-align: left; border-bottom: 1px solid #ddd;}");
            html.AppendLine("th {background-color: #1C2541; color: white;}");
            html.AppendLine("tr:nth-child(even) {background-color: #f2f2f2;}");
            html.AppendLine("</style>");

            html.AppendLine("<html><body>");
            html.AppendLine("<div class='report-container'>");
            html.AppendLine("<h1>Keyboard Vault</h1>");
            html.AppendLine($"<h2>{reportType} Sales Report</h2>");
            html.AppendLine($"<h3>{dateLabel}</h3>");
            html.AppendLine($"<p><strong>Total Orders:</strong> {totalOrders}</p>");
            html.AppendLine($"<p><strong>Total Products Sold:</strong> {totalItemsSold}</p>");
            html.AppendLine($"<p><strong>Total Discounts:</strong> -{totalDiscountAmount:C}</p>");
            html.AppendLine($"<p><strong>Total Sales (Before Tax):</strong> {totalSalesBeforeTax:C}</p>");
            html.AppendLine($"<p><strong>Total Tax Collected:</strong> {totalTax:C}</p>");
            html.AppendLine($"<p><strong>Total Sales (After Tax):</strong> {totalSale:C}</p>");
            html.AppendLine("<h3 style='margin-top: 30px;'>Products Sold</h3>");
            html.AppendLine("<table>");
            html.AppendLine("<tr><th>Product Name</th><th>Quantity Ordered</th></tr>");

            //Creating a table to display the purchased products
            foreach (var product in productSummary)
            {
                html.AppendLine($"<tr><td>{product.ProductName}</td><td>{product.Quantity}</td></tr>");
            }
            html.AppendLine("</table>");

            html.AppendLine("</div></body></html>");

            return html;
        }

        /// <summary>
        /// Generates an HTML refund report including totals for refunded orders, items refunded, total refund amount, and a product summary.
        /// </summary>
        /// <param name="refundsList">A list of string arrays with the refunds.</param>
        /// <param name="date">The date associated with the report.</param>
        /// <param name="reportType">The type of report (Daily, Weekly, Monthly, Yearly).</param>
        /// <returns>A stringBuilder with the generated HTML.</returns>
        private StringBuilder GenerateHTMLReportRefunds(List<string[]> refundsList, DateTime date, string reportType)
        {
            //Creating a new string builder to build the HTML
            StringBuilder html = new StringBuilder();

            //Totals for the refund report
            int totalRefundedOrders = 0;
            int totalItemsRefunded = 0;
            decimal totalRefundAmount = 0;

            var groupedRefunds = refundsList.GroupBy(p => p[0]);//Grouping by OrderID
            totalRefundedOrders = groupedRefunds.Count();

            //Looping through each refund
            foreach (var refundGroup in groupedRefunds)
            {
                //Subtotals and bool for each order
                bool cartDiscountApplied = false;
                decimal cartDiscountAmount = 0;

                foreach (var refund in refundGroup)
                {
                    decimal price = Convert.ToDecimal(refund[3]);
                    decimal cost = Convert.ToDecimal(refund[4]);
                    int quantity = Convert.ToInt32(refund[5]);
                    decimal refundAmount = Convert.ToDecimal(refund[6]);
                    decimal discountPercent = refund[7] != "NULL" ? Convert.ToDecimal(refund[7]) : 0;
                    decimal discountDollar = refund[8] != "NULL" ? Convert.ToDecimal(refund[8]) : 0;
                    string discountLevel = refund[9];

                    decimal itemTotalPrice = price * quantity;
                    decimal itemDiscountAmount = 0;

                    if (discountLevel == "1") // Item-level discount
                    {
                        itemDiscountAmount = discountPercent > 0 ? itemTotalPrice * discountPercent : discountDollar;
                    }
                    else if (discountLevel == "0" && !cartDiscountApplied) // Cart-level discount once per order
                    {
                        cartDiscountAmount = discountPercent > 0 ? itemTotalPrice * discountPercent : discountDollar;
                        cartDiscountApplied = true;
                    }

                    totalItemsRefunded += quantity;
                    totalRefundAmount += refundAmount;
                }
            }

            //Grouping the products and the quantites ordered
            var productSummary = refundsList.GroupBy(r => r[2]).Select(g => new { ProductName = g.Key, Quantity = g.Sum(x => Convert.ToInt32(x[5])) }).OrderByDescending(x => x.Quantity).ToList();

            //String to hold the date label
            string dateLabel;

            //Switch to create the date label
            switch (reportType)
            {
                case "Daily":
                    dateLabel = $"for {date.ToString("MMMM dd, yyyy")}";
                    break;
                case "Weekly":
                    dateLabel = $"for week of {date.ToString("MMMM dd, yyyy")}";
                    break;
                case "Monthly":
                    dateLabel = $"for {date.ToString("MMMM yyyy")}";
                    break;
                case "Yearly":
                    dateLabel = $"for year {date.Year}";
                    break;
                default:
                    dateLabel = date.ToString();
                    break;
            }

            //Creating the HTML 
            html.AppendLine("<style>");
            html.AppendLine("body {background-color: #1C2541; font-family: Arial, sans-serif; color: black;}");
            html.AppendLine(".report-container {max-width: 800px; background-color: #F9FBF2; margin: 40px auto; padding: 30px; border-radius: 15px; color: black; box-shadow: 0 0 15px rgba(0,0,0,0.3);}");
            html.AppendLine("h1, h2, h3 {color: #1C2541;}");
            html.AppendLine("p {font-size: 18px; margin-bottom: 12px;}");
            html.AppendLine("table {width: 100%; border-collapse: collapse; margin-top: 20px;}");
            html.AppendLine("th, td {padding: 12px 15px; text-align: left; border-bottom: 1px solid #ddd;}");
            html.AppendLine("th {background-color: #1C2541; color: white;}");
            html.AppendLine("tr:nth-child(even) {background-color: #f2f2f2;}");
            html.AppendLine("</style>");

            html.AppendLine("<html><body>");
            html.AppendLine("<div class='report-container'>");
            html.AppendLine("<h1>Keyboard Vault</h1>");
            html.AppendLine($"<h2>{reportType} Refund Report</h2>");
            html.AppendLine($"<h3>{dateLabel}</h3>");
            html.AppendLine($"<p><strong>Total Refunded Orders:</strong> {totalRefundedOrders}</p>");
            html.AppendLine($"<p><strong>Total Items Refunded:</strong> {totalItemsRefunded}</p>");
            html.AppendLine($"<p style='color:red;'><strong>Total Refunded Amount:</strong> -{totalRefundAmount:C}</p>");
            html.AppendLine("<h3 style='margin-top: 30px;'>Products Sold</h3>");
            html.AppendLine("<table>");
            html.AppendLine("<tr><th>Product Name</th><th>Quantity Refunded</th></tr>");

            //Creating a table to display the refunded products
            foreach (var product in productSummary)
            {
                html.AppendLine($"<tr><td>{product.ProductName}</td><td>{product.Quantity}</td></tr>");
            }
            html.AppendLine("</table>");
            html.AppendLine("</div></body></html>");

            return html;
        }


        /// <summary>
        /// Generates an HTML inventory report displaying inventory details based on the specified report type.
        /// </summary>
        /// <param name="inventoryList">A list of Inventory objects in the database.</param>
        /// <param name="reportType">The type of report to generate(All available products, Products low in stock, All products including discontinued).</param>
        /// <returns>A stringbuilder with the generate HTML.</returns>
        private StringBuilder GenerateHTMLReportInventory(List<Inventory> inventoryList, string reportType)
        {
            //Creating a new string builder to hold the HTML
            StringBuilder html = new StringBuilder();

            //The HTML for the Inventory Reports
            html.AppendLine("<style>");
            html.AppendLine("body {background-color: #1C2541; font-family: Arial, sans-serif;}");
            html.AppendLine(".report-container {width: 800px; background-color: #F9FBF2; margin: 40px auto; padding: 30px; border-radius: 15px; color: black; box-shadow: 0 0 15px rgba(0,0,0,0.3);}");
            html.AppendLine("h1, h2, h4 { color: #1C2541; }");
            html.AppendLine("p {font-size: 18px; margin-bottom: 12px;}");
            html.AppendLine("table {width: 100%; border-collapse: collapse; margin-top: 20px;}");
            html.AppendLine("th, td {padding: 12px 15px; text-align: left; border-bottom: 1px solid #ddd;}");
            html.AppendLine("th {background-color: #1C2541; color: white;}");
            html.AppendLine("tr:nth-child(even) {background-color: #f2f2f2;}");
            html.AppendLine("</style>");

            html.AppendLine("<html><body>");
            html.AppendLine("<div class='report-container'>");
            html.AppendLine("<h1>Keyboard Vault Inventory Report</h1>");
            html.AppendLine($"<h2>{reportType} Inventory Report</h2>");
            html.AppendLine($"<h4>Date: {DateTime.Now.ToString("MM/dd/yyyy")}</h4>");

            html.AppendLine("<table>");
            html.AppendLine("<tr class='tblHeader'><th>Item Name</th><th>Cost</th><th>Retail Price</th><th>Quantity</th><th>Restock Threshold</th><th>Discontinued</th></tr>");

            //Looping through each item in the inventory list
            foreach (var item in inventoryList)
            {
                string itemName = item.ItemName;
                decimal cost = Convert.ToDecimal(item.Cost);
                decimal retailPrice = Convert.ToDecimal(item.RetailPrice);
                int stock = Convert.ToInt32(item.Quantity);
                int threshold = Convert.ToInt32(item.RestockThreshold);
                bool discontinued = item.Discontinued;

                //Switch to check the report type
                switch (reportType)
                {
                    case "Available Products" when discontinued || stock <= 0:
                        continue;
                    case "Products with Low Stock" when stock >= threshold:
                        continue;
                }

                html.AppendLine($"<tr><td>{itemName}</td><td>{cost:C}</td><td>{retailPrice:C}</td><td>{stock}</td><td>{threshold}</td><td>{(discontinued ? "Yes" : "No")}</td></tr>");
            }

            html.AppendLine("</table>");
            html.AppendLine("</div>");
            html.AppendLine("</body></html>");

            return html;
        }

        /// <summary>
        /// Saves the provided HTML to a file named with the report type and timestamp, and opens it in the default web browser.
        /// </summary>
        /// <param name="html">The HTML content to save and display.</param>
        /// <param name="reportType">The type of report.</param>
        public void PrintReport(StringBuilder html, string reportType)
        {
            string time = DateTime.Now.ToString("MM-dd-yy HH-mm-ss");
            string fileName = $"{reportType}_{time}.html";

            //Creating the filepath using the reportType and formattedDate to save the HTML document
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);
            //Saving the receipt to a file
            try
            {
                //Checking to see if file already exists
                if (File.Exists(filePath))
                {
                    MessageBox.Show("The Order History has already been generated", "Order History Already Generated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Writing the html to a file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(html);
                }

                System.Diagnostics.Process.Start(filePath);//Opens the reciept in the web browser
            }
            catch (Exception)
            {
                MessageBox.Show("You do not have write permissions.", "Error with your System Permissions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the click event for the Search button to find customers matching the search text.
        /// Searches the customer list by name, username, email, or phone numbers.
        /// Populates the combo box with matching customers or displays an error message if none are found.
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Getting the search text from the textbox
            string searchText = tbxCustomerName.Text.Trim().ToLower();

            lblReportErr.Text = "";

            //Clearing the comboBox
            cbxCustomer.Items.Clear();
            searchedPersonList = new List<Person>();//Clearing the list

            if (!string.IsNullOrEmpty(searchText) && frmManagerView.customerList != null)
            {
                foreach (Person customer in frmManagerView.customerList)
                {
                    //The different fields that can be searched
                    string fullName = $"{customer.NameFirst} {customer.NameLast}".ToLower();
                    string username = customer.LogonName.ToLower();
                    string email = customer.Email.ToLower();
                    string phone1 = customer.PhonePrimary;
                    string phone2 = customer.PhoneSecondary;

                    //Checking if the searchText Matches anyone in the customers list
                    if (fullName.Contains(searchText) ||
                        username.Contains(searchText) ||
                        email.Contains(searchText) ||
                        phone1.Contains(searchText) ||
                        phone2.Contains(searchText))
                    {
                        //Adding the found customer to the list box
                        cbxCustomer.Items.Add($"{customer.NameFirst} {customer.NameLast}");
                        searchedPersonList.Add(customer);
                        cbxCustomer.SelectedIndex = 0;
                        cbxCustomer.Enabled = true;
                        lblReportErr.Text = "";
                        tbxCustomerName.Text = "";
                    }
                }

                //Checking if the results found anyone, if not displaying a error
                if (cbxCustomer.Items.Count == 0)
                {
                    lblReportErr.Text = "No customers found.";
                    tbxCustomerName.Text = "";
                }
            }
            else
            {
                lblReportErr.Text = "Please enter a name to search for.";
            }
        }

        private void chbxCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxCustomer.Checked)
            {
                gbxCustomer.Visible = true;
                gbxEmployee.Visible = false;
                chbxEmployee.Enabled = false;
            }
            else
            {
                gbxCustomer.Visible = false;
                chbxEmployee.Enabled = true;
            }
        }

        private void chbxEmployee_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxEmployee.Checked)
            {
                gbxEmployee.Visible = true;
                gbxCustomer.Visible = false;
                chbxCustomer.Enabled = false;
            }
            else
            {
                gbxEmployee.Visible = false;
                chbxCustomer.Enabled = true;
            }
        }

        /// <summary>
        /// Handles the click event for the Employee Search button to find employees matching the search text.
        /// Searches the employee list by name, username, email, or phone numbers.
        /// Populates the combo box with matching employees or displays an error message if none are found.
        /// </summary>
        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            //Getting the search text from the textbox
            string searchText = tbxEmployee.Text.Trim().ToLower();

            lblReportErr.Text = "";

            //Clearing the comboBox
            cbxEmployee.Items.Clear();
            searchedPersonList = new List<Person>();//Clearing the list

            if (!string.IsNullOrEmpty(searchText) && frmManagerView.employeeList != null)
            {
                foreach (Person employee in frmManagerView.employeeList)
                {

                    //The different fields that can be searched
                    string fullName = $"{employee.NameFirst} {employee.NameLast}".ToLower();
                    string username = employee.LogonName.ToLower();
                    string email = employee.Email.ToLower();
                    string phone1 = employee.PhonePrimary;
                    string phone2 = employee.PhoneSecondary;

                    //Checking if the searchText Matches anyone in the employees list
                    if (fullName.Contains(searchText) ||
                        username.Contains(searchText) ||
                        email.Contains(searchText) ||
                        phone1.Contains(searchText) ||
                        phone2.Contains(searchText))
                    {
                        //Adding the found employee to the list box
                        cbxEmployee.Items.Add($"{employee.NameFirst} {employee.NameLast}");
                        searchedPersonList.Add(employee);
                        cbxEmployee.SelectedIndex = 0;
                        cbxEmployee.Enabled = true;
                        lblReportErr.Text = "";
                        tbxEmployee.Text = "";
                    }
                }

                //Checking if the results found anyone, if not displaying a error
                if (cbxEmployee.Items.Count == 0)
                {
                    lblReportErr.Text = "No employees found.";
                    tbxEmployee.Text = "";
                }
            }
            else
            {
                lblReportErr.Text = "Please enter a name to search for.";
            }
        }

        private void lblHelp_Click(object sender, EventArgs e)
        {
            //Showing the HTML Help files
            Help.ShowHelp(this, hlpReports.HelpNamespace);
        }

        /// <summary>
        /// Handles the click event for the Refund Report button.
        /// Retrieves refund information based on the selected date and report type (daily, weekly, monthly, yearly).
        /// Generates an HTML report of the refund data and prints it.
        /// </summary>
        private void btnGetRefundReports_Click(object sender, EventArgs e)
        {
            //Getting the selected date
            DateTime date = dtpDateRefunds.Value;
            string formattedDate = date.ToString("yyyy-MM-dd");

            string reportType = "";
            string reportTypeName = "Refunds_Report";

            //Checking to see which radio button is selected to get that refunds report
            if (rdbDailyRefunds.Checked)//Daily
            {
                reportType = "Daily";
                lblReportErr.Text = "";
            }
            else if (rdbWeeklyRefunds.Checked)//Weekly
            {
                reportType = "Weekly";
                lblReportErr.Text = "";
            }
            else if (rdbMonthlyRefunds.Checked)//Monthly
            {
                reportType = "Monthly";
                lblReportErr.Text = "";
            }
            else if (rdbYearlyRefunds.Checked)
            {
                reportType = "Yearly";
                lblReportErr.Text = "";
            }
            else
            {
                //Telling the user to select a report type
                lblReportErr.Text = "Please select a report type for Refund Reports.";
                return;
            }

            List<string[]> refundsResult = clsSQL.getRefundsReports(formattedDate, reportType);//Calling the method to get refunds reports

            //Calling the method to generate the report
            html = GenerateHTMLReportRefunds(refundsResult, date, reportType);

            //Calling the method print the report
            PrintReport(html, reportTypeName);
        }
    }
}
