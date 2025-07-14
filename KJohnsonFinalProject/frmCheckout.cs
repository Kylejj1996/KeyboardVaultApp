using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace KJohnsonFinalProject
{
    public partial class frmCheckout : Form
    {
        //Gloabal Variables
        StringBuilder html = new StringBuilder();//StringBuilder for the HTML
        private Discounts appliedDiscount;//Creating a Discounts object to hold the applied discount details
        const decimal taxRate = 0.0825m;
        public decimal cartSubTotal = 0;
        public decimal cartTax = 0;
        public decimal cartTotalDue = 0;
        public decimal cartDiscount = 0;
        public decimal itemPrice = 0;
        public decimal discountPercent = 0;
        public string keyboardName;
        bool discountApplied = false;
        bool discountPercentApplied = false;
        string discountTypeName;

        public frmCheckout()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the checkout form data, including calculating and displaying
        /// the cart subtotal, discount, tax, and total due from the purchase details.
        /// Also populates combo boxes with necessary data.
        /// </summary>
        private void frmCheckout_Load(object sender, EventArgs e)
        {
            //Adding each item in the purchase Details to a variable
            foreach (string item in frmCart.purchaseDetails)
            {
                string[] details = item.Split(',');
                decimal itemSubtotal = Convert.ToDecimal(details[0]);
                decimal itemTax = Convert.ToDecimal(details[1]);
                decimal itemTotal = Convert.ToDecimal(details[2]);

                //Displaying the subtotal, tax, and cartTotals
                cartSubTotal += itemSubtotal;
                cartTax += itemTax;
                cartTotalDue += itemTotal;
            }

            //Adding the totals to the labels
            lblSubtotalTxt.Text = cartSubTotal.ToString("C");
            lblDiscountTxt.Text = cartDiscount.ToString("C");
            lblTaxTxt.Text = cartTax.ToString("C");
            lblTotalDueTxt.Text = cartTotalDue.ToString("C");

            fillComboBoxes();//Calling the method to fill the combo boxes
        }

        //Resets the Checkout Form
        private void ResetCheckout()
        {
            //Resetting the order totals
            cartSubTotal = 0;
            cartTax = 0;
            cartTotalDue = 0;
            cartDiscount = 0;
            itemPrice = 0;
            discountPercent = 0;

            //Clearing the shopping cart
            frmCustomerView.shoppingCart.Clear();

            //Clearing the purchase details 
            frmCart.purchaseDetails.Clear();

            //Clearing the labels
            lblSubtotalTxt.Text = "$0.00";
            lblDiscountTxt.Text = "$0.00";
            lblTaxTxt.Text = "$0.00";
            lblTotalDueTxt.Text = "$0.00";
        }

        //Populates ComboBoxes with predefined values for states
        private void fillComboBoxes()
        {
            //String with all of the states
            string[] states = { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA",
            "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD",
            "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ",
            "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC",
            "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY",
            "AE", "AA", "AP"};

            cbxState.Items.AddRange(states);//Adding the states to the comboBox
        }

        //Validates the entered promo code and attempts to apply it by calling the ApplyPromoCode method.
        private void btnAddPromo_Click(object sender, EventArgs e)
        {
            //String to hold the promo code
            string promoCode = tbxPromo.Text.Trim();

            if (string.IsNullOrWhiteSpace(promoCode))
            {
                lblError.Visible = true;
                lblError.Text = "Please enter a promo code.";
                lblError.ForeColor = Color.Red;
            }
            else
            {
                lblError.Visible = false;
                ApplyPromoCode(promoCode);
            }
        }

        /// <summary>
        /// Applies the provided promo code, validates it against the database,
        /// checks expiration and start dates, and applies either cart-level or item-level
        /// discounts accordingly. Updates the UI to reflect applied discounts.
        /// </summary>
        /// <param name="promoCode">The promo code entered by the user.</param>
        private void ApplyPromoCode(string promoCode)
        {
            //Calling the discountCommand to fill the appliedDiscounts object from the database
            appliedDiscount = clsSQL.DiscountCommand(promoCode);

            //If the list is empty, tell the user either invalid or expired
            if (appliedDiscount == null)
            {
                lblError.Text = "Invalid or expired promo code";
                lblError.ForeColor = Color.Red;
                lblError.Visible = true;
                return;
            }

            //Adding the discount details to seperate strings
            string inventoryID = appliedDiscount.InventoryID.ToString();
            int discountType = appliedDiscount.DiscountType;
            decimal discountPercentage = appliedDiscount.DiscountPercentage;
            decimal discountDollarAmount = appliedDiscount.DiscountDollarAmount;
            int discountLevel = appliedDiscount.DiscountLevel;

            //Getting the startDate string
            string startDateString = appliedDiscount.StartDate;

            // If StartDate is not null, checking to see if the promo code has started
            if (startDateString != "NULL" && !string.IsNullOrEmpty(startDateString))
            {
                //Setting the startDate DateTime
                DateTime startDate = Convert.ToDateTime(startDateString);

                // Check if the promo code has started
                if (DateTime.Now < startDate)
                {
                    lblError.Text = "Promo code has not started yet";
                    lblError.ForeColor = Color.Red;
                    lblError.Visible = true;
                    return;
                }
            }

            //Getting the expiration date
            DateTime expirationDate = Convert.ToDateTime(appliedDiscount.ExpirationDate);
            

            //Checking to see if the promoCode is expired
            if (DateTime.Now > expirationDate)
            {
                lblError.Text = "Expired promo code";
                lblError.ForeColor = Color.Red;
                lblError.Visible = true;
                return;
            }

            decimal discount = 0;

            if (discountLevel == 0)//Cart Level discount
            {
                discountTypeName = "Cart";
                discountApplied = true;

                //Using the cartSubtotal to calculate the discount
                decimal subtotal = cartSubTotal;
                decimal newSubtotal = 0;

                //Applying the discount based on type
                if (discountType == 0)//Percentage Discount
                {
                    //Using math.round to round to 2 decimal places
                    discount = Math.Round(subtotal * discountPercentage,2);
                    discountPercent = discountPercentage;//Storing the discount percentage in a global variable to be used in the HTML receipt
                    discountPercentApplied = true;//Setting the boolean to true to display in the HTML receipt
                }
                else if (discountType == 1)//Dollar Discount
                {
                    discount = discountDollarAmount;
                }

                //Updating the new cartTotalDue and discount
                cartDiscount = discount;
                newSubtotal = subtotal - discount;
                cartTax = newSubtotal * taxRate;
                cartTotalDue = newSubtotal  + cartTax;

                //Updating the labels
                lblSubtotalTxt.Text = cartSubTotal.ToString("C");
                lblDiscountTxt.Text = "-" + cartDiscount.ToString("C");
                lblTaxTxt.Text = cartTax.ToString("C");
                lblTotalDueTxt.Text = cartTotalDue.ToString("C");
                tbxPromo.Enabled = false;//Disabling the promo code textbox
                btnAddPromo.Enabled = false;//Disabling the promo button
                lblDiscountApplied.Visible = true;//Telling the user the discount was applied
            }
            else if (discountLevel == 1)//Item level discount
            {
                //A bool to check if the item with the discount is in the cart
                bool itemFound = false;

                foreach (CartItem cartItem in frmCustomerView.shoppingCart)
                {
                    string itemID = cartItem.ProductID.ToString();
                    string itemName = cartItem.ItemName;
                    decimal currentItemPrice = cartItem.Price;
                    int itemQuantity = cartItem.QuantitySelected;

                    //Using the cartSubtotal to calculate the discount
                    decimal subtotal = cartSubTotal;
                    decimal newSubtotal = 0;

                    //Checking if the promo code applies to the current item
                    if (itemID == inventoryID)
                    {
                        decimal discountAmt = 0;
                        discountTypeName = "Item";
                        discountApplied = true;
                        keyboardName = itemName;

                        //Applying the discount based on the type of discount
                        if (discountType == 0)//Percentage Discount
                        {
                            //Getting the discount by multiplying the item price and the discount percentage
                            discountAmt = Math.Round(currentItemPrice * discountPercentage,2);
                            discountPercent = discountPercentage;//Storing the discount percentage in a global variable to be used in the HTML receipt
                            discountPercentApplied = true;//Setting the boolean to true to display in the HTML receipt
                            discount = discountAmt * itemQuantity;
                        }
                        else if (discountType == 1)//Dollar Discount
                        {
                            //Getting the discount by multiplying the dollar discount by the item quantity
                            discountAmt = discountDollarAmount;
                            discount = discountAmt * itemQuantity;
                        }

                        //The new price of the item with the discount applied
                        itemPrice = currentItemPrice - discount;

                        //Updating the new cartTotalDue, cartTax, and 
                        cartDiscount = discount;
                        newSubtotal = cartSubTotal - discount;
                        cartTax = newSubtotal * taxRate;
                        cartTotalDue = newSubtotal + cartTax;

                        //Updating the labels
                        lblSubtotalTxt.Text = cartSubTotal.ToString("C");
                        lblDiscountTxt.Text = "-" + cartDiscount.ToString("C");
                        lblTaxTxt.Text = cartTax.ToString("C");
                        lblTotalDueTxt.Text = cartTotalDue.ToString("C");
                        tbxPromo.Enabled = false;//Disabling the promo code textbox
                        btnAddPromo.Enabled = false;//Disabling the promo button
                        lblDiscountApplied.Visible = true;//Telling the user the discount was applied

                        itemFound = true;
                        break;
                    }

                }
                //If the item is not found, tell the user
                if (!itemFound)
                {
                    MessageBox.Show("This promo code is only valid for a specific item that is not in your cart.", "Invalid Promo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Handles the Place Order button click event.
        /// Validates the checkout form inputs, processes the applied discount if any,
        /// inserts the order and order details into the database, records payment information,
        /// updates inventory in the database and reloads the <c>inventoryList</c>, and then generates and prints the receipt, and resets <c>frmCheckout</c>.
        /// </summary>
        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            lblDiscountApplied.Visible = false;//Making the discount applied false
            string firstName = tbxFirstName.Text;
            string lastName = tbxLastName.Text; 
            string address1 = tbxAddress1.Text;
            string address2 = tbxAddress2.Text;
            string address3 = tbxAddress3.Text;
            string city = tbxCity.Text;
            string state = cbxState.Text;
            string zip = tbxZip.Text;
            string email = tbxEmail.Text;
            string phone = mTbxPhone.Text;
            string ccNum = tbxCC.Text;
            string expDate = tbxExpDate.Text;
            string ccv = tbxCCV.Text;
            string promoCode = tbxPromo.Text;
       
            //Adding Adding the personID and employeeID to the variables
            int personID = frmLogin.loggedInPerson.PersonID;
            int employeeID = frmLogin.loggedInPerson.PositionID;

            string orderDate = DateTime.Now.ToString("yyyy-MM-dd");

            //Validating the checkout form is filled out before allowing the user to checkout
            if (!clsValidation.ValidateCheckoutForm(firstName, lastName, email, address1, city, state, zip, phone, ccNum, expDate, ccv))
            {
                return;
            }

            string maskedCCNum = new string('*', ccNum.Length - 4) + ccNum.Substring(ccNum.Length - 4);//Masking the CC number except for the last 4 digits
            int appliedDiscountID = 0;
            int discountID = 0;

            //Checking if there was a discount applied
            if (appliedDiscount != null)
            {
                discountID = appliedDiscount.DiscountID;
                string expirationDate = DateTime.Parse(appliedDiscount.ExpirationDate).ToString("yyyy-MM-dd");
                string appliedDate = DateTime.Now.ToString("yyyy-MM-dd");

                //Insert into AppliedDiscounts using the Discounts Object, getting the applied discountID
                appliedDiscountID = clsSQL.InsertAppliedPromo(appliedDiscount.DiscountID.ToString(), appliedDiscount.DiscountCode, appliedDiscount.Description, appliedDiscount.DiscountLevel.ToString(),
                appliedDiscount.InventoryID.ToString(), appliedDiscount.DiscountType.ToString(), appliedDiscount.DiscountPercentage.ToString(), appliedDiscount.DiscountDollarAmount.ToString(),
                appliedDiscount.StartDate, expirationDate, appliedDate);      
            }

            if (appliedDiscountID == -1)
            {
                MessageBox.Show("Error inserting applied discount.");
                return; // Stop the operation
            }


            //Adding the order to the Orders Table and getting the orderID
            int orderID = clsSQL.InsertOrders(discountID, personID, employeeID, orderDate, appliedDiscountID);

            if (orderID == -1)
            {
                MessageBox.Show("Error inserting order");
                return;
            }


            //Inserting each item from the shopping cart into the OrderDetails table
            foreach (CartItem item in frmCustomerView.shoppingCart)
            {
                int inventoryID = item.ProductID;
                int quantity = item.QuantitySelected;

                //Insert the order details for each item in the cart
                clsSQL.InsertOrderDetails(orderID, inventoryID, discountID, quantity);
            }

            //Inserting the payment details into the Payments table
            clsSQL.InsertPayments(orderID, maskedCCNum, expDate, ccv);


            //Updating the inventory table
            clsSQL.UpdateInventory(orderID);

            MessageBox.Show("Order placed successfully.");

            //Calling the generate receipt method
            StringBuilder html = GenerateReceipt(orderID, firstName, lastName, address1, address2, address3, city, state, zip, email, phone, discountPercent);

            //Calling the print report method
            PrintReport(html, orderID);

            ResetCheckout();//Calling the method to reset the totals and clear the cart and shopping list

            //Finding an instance of frmCustomerView that is open to refresh the inventory
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmCustomerView customerView)
                {
                    customerView.RefreshInventory();
                    break;
                }
            }

            this.Close();//Closing the checkout form

        }

        /// <summary>
        /// Generates an HTML formatted order receipt as a <c>StringBuilder</c> for the order details.
        /// </summary>
        /// <param name="orderID">The ID for the order.</param>
        /// <param name="firstName">Customer's first name.</param>
        /// <param name="lastName">Customer's last name.</param>
        /// <param name="address1">Customer's primary address line.</param>
        /// <param name="address2">Customer's secondary address line (optional).</param>
        /// <param name="address3">Customer's tertiary address line (optional).</param>
        /// <param name="city">City of the shipping address.</param>
        /// <param name="state">State of the shipping address.</param>
        /// <param name="zip">ZIP or postal code of the shipping address.</param>
        /// <param name="email">Customer's email address.</param>
        /// <param name="phone">Customer's phone number.</param>
        /// <param name="discountPercent">Discount percentage applied to the order.</param>
        /// <returns>Returns a <c>StringBuilder</c> with the complete HTML receipt for the order.</returns>
        private StringBuilder GenerateReceipt(int orderID, string firstName, string lastName, string address1, string address2, string address3, string city, string state, string zip, string email, string phone, decimal discountPercent)
        {
            //The HTML for the Order Receipt
            html.AppendLine("<style>");
            html.AppendLine("body {background-color: #1C2541; font-family: Arial, sans-serif; color: black; margin: 0; padding: 0;}");
            html.AppendLine(".receipt-container {width: 95%; max-width: 1000px; background-color: #F9FBF2; margin: 40px auto; padding: 20px; border-radius: 15px; color: black; box-shadow: 0 0 15px rgba(0,0,0,0.3);}");
            html.AppendLine("h1, h3 {text-align: center; color: #1C2541;}");
            html.AppendLine("table {width: 100%; border-collapse: collapse; margin-top: 20px; table-layout: auto;}");
            html.AppendLine("th, td {border: 1px solid #ccc; padding: 10px; text-align: left; word-wrap: break-word;}");
            html.AppendLine("th {background-color: #1C2541; color: white;}");
            html.AppendLine("tr:nth-child(even) {background-color: #f2f2f2;}");
            html.AppendLine(".summary {margin-top: 30px; font-size: 16px; text-align: right;}");
            html.AppendLine(".header {display: flex; justify-content: space-between; align-items: flex-start;}");
            html.AppendLine(".customer-info {text-align: left;}");
            html.AppendLine(".address {text-align: right;}");
            html.AppendLine(".discount-message {text-align: center; font-size: 14px; color: green; margin-top: 15px;}");
            html.AppendLine("</style>");

            html.AppendLine("<html>");
            html.AppendLine("<body>");
            html.AppendLine("<div class='receipt-container'>");
            html.AppendLine("<h1>Keyboard Vault Order Receipt</h1>");
            html.AppendLine("<h3>Thank you for shopping with us!</h3>");
            html.AppendLine("<div class='header'>");
            html.AppendLine("<div class='customer-info'>");
            html.AppendLine($"<p><strong>Customer Name:</strong> {firstName} {lastName}</p>");

            //Checking if the manager is shopping for a customer
            if(frmCustomerView.shoppingForCustomer == true)
            {
                html.AppendLine($"<p><strong>Ordered by:</strong> {frmCustomerView.managerName} </p>");
            }

            html.AppendLine($"<p><strong>Order Number:</strong> {orderID}</p>");
            html.AppendLine("</div>");

            //Adding the address
            html.AppendLine("<div class='address'>");
            html.AppendLine("<p><strong>Shipping Address:</strong><br>");
            if (!string.IsNullOrWhiteSpace(address1)) html.AppendLine($"{address1}<br>");
            if (!string.IsNullOrWhiteSpace(address2)) html.AppendLine($"{address2}<br>");
            if (!string.IsNullOrWhiteSpace(address3)) html.AppendLine($"{address3}<br>");
            html.AppendLine($"{city}, {state} {zip}</p>");
            html.AppendLine("</div>");
            html.AppendLine("</div>");

            html.AppendLine($"<p><strong>Email:</strong> {email} | <strong>Phone:</strong> {phone}</p>");
            html.AppendLine("<table>");
            html.AppendLine("<tr><th>Product Name</th><th>Price Per Item</th><th>Quantity</th><th>Total Price</th></tr>");

            //For each loop to loop through the cart items and seperate them
            foreach (CartItem item in frmCustomerView.shoppingCart)
            {
                string name = item.ItemName;
                decimal price = item.Price;
                int quantity = item.QuantitySelected;
                decimal total = price * quantity;

                html.AppendLine($"<tr><td>{name}</td><td>{price:C}</td><td>{quantity}</td><td>{total:C}</td></tr>");
            }
            html.AppendLine("</table>");

            //Displaying a message if there is a discount
            if (discountApplied)
            {
                html.AppendLine("<div class='discount-message'>");

                if (discountPercentApplied)//Percentage discount
                {
                    if (discountTypeName == "Cart")
                    {
                        html.AppendLine($"<p><strong>Discount:</strong> {discountPercent.ToString("0%")} off entire cart - ({cartDiscount:C})</p>");
                    }
                    else if (discountTypeName == "Item")
                    {
                        html.AppendLine($"<p><strong>Discount:</strong> {discountPercent.ToString("0%")} off {keyboardName} - ({cartDiscount:C})</p>");
                    }
                }
                else//Dollar discount
                {
                    if (discountTypeName == "Cart")
                    {
                        html.AppendLine($"<p><strong>Discount:</strong> {cartDiscount:C} off entire cart</p>");
                    }
                    else if (discountTypeName == "Item")
                    {
                        html.AppendLine($"<p><strong>Discount:</strong> {cartDiscount:C} off {keyboardName}</p>");
                    }
                }

                html.AppendLine("</div>");
            }

            //Order Summary
            html.AppendLine("<div class='summary'>");
            html.AppendLine($"<p><strong>Subtotal:</strong> {cartSubTotal:C}</p>");
            if (discountApplied)
            {
                html.AppendLine($"<p><strong>Discounts Applied:</strong> - {cartDiscount:C}</p>");
            }
            html.AppendLine($"<p><strong>Tax:</strong> {cartTax:C}</p>");
            html.AppendLine($"<p><strong>Purchase Amount:</strong> <strong>{cartTotalDue:C}</strong></p>");
            html.AppendLine("</div>");
            html.AppendLine("</div>");
            html.AppendLine("</body></html>");

            return html;
        }

        /// <summary>
        /// Saves the provided HTML receipt to a file in the user's Documents folder and opens it in the default web browser.
        /// </summary>
        /// <param name="html">The HTML content of the receipt to be saved and printed.</param>
        /// <param name="orderID">The order ID used to name the receipt file.</param>
        /// <remarks>
        /// If the receipt file already exists, a warning message is shown and the file is not overwritten.
        /// If there are insufficient permissions to write to the file, an error message is displayed.
        /// </remarks>
        public void PrintReport(StringBuilder html, int orderID)
        {
            //Creating the filepath using the OrderID to save the HTML document
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"KV_Receipt_OrderID_{orderID}.html");
            //Saving the receipt to a file
            try
            {
                //Checking to see if file already exists
                if(File.Exists(filePath))
                {
                    MessageBox.Show("This receipt has already been generated", "Receipt Already Generated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        
        //Closes the Checkout form
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Validates the Credit Card Number to ensure the correct format
        private void tbxCC_TextChanged(object sender, EventArgs e)
        {
            //String to hold the ccNum text
            string ccNum = tbxCC.Text;

            //Checking if the CC is valid
            string validationText = clsValidation.ValidateCC(ccNum);

            //If the CC is not vaild, tells the user
            if (validationText != "Valid")
            {
                lblCCerr.Text = validationText;
                lblCCerr.ForeColor = Color.Red;
            }
            else
            {
                lblCCerr.Text = "";
            }
        }

        //Keypress event for the Credit Card number allowing only numbers and backspace, and it auto formats
        private void tbxCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.AllowedKeysCC(e, tbxCC);
        }

        //Validates the expiration date for the credit card
        private void tbxExpDate_TextChanged(object sender, EventArgs e)
        {
            //String to hold the ccNum text
            string expDate = tbxExpDate.Text;

            //Checking if the CC is valid
            string validationText = clsValidation.ValidateExpDate(expDate);

            //If the experation date is not vaild, tells the user
            if (validationText != "Valid")
            {
                lblCCerr.Text = validationText;
                lblCCerr.ForeColor = Color.Red;
            }
            else
            {
                lblCCerr.Text = "";
            }
        }

        //Keypress event for the expiration date allowing only numbers and backspace, and it auto formats 
        private void tbxExpDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.AllowedKeysExpDate(e, tbxExpDate);
        }

        //Keypress event for the CCV allowing only 3 numbers and a backspace
        private void tbxCCV_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.AllowedKeysCCV(e, tbxCCV);
        }

        //Validates the CCV
        private void tbxCCV_TextChanged(object sender, EventArgs e)
        {
            string ccv = tbxCC.Text;

            //Checking to see if the user enters a 3 digit ccv
            if (ccv.Length < 3)
            {
                lblCCerr.Text = "CCV must be at least 3 digits.";
                lblCCerr.ForeColor = Color.Red;
            }
            else
            {
                lblCCerr.Text = "";
            }
        }

        //Validates the Email
        private void tbxEmail_TextChanged(object sender, EventArgs e)
        {
            //Validating the email to make sure it is a valid email
            string validationText = clsValidation.ValidateEmail(tbxEmail.Text);

            //Updating the label to tell the user if the email they are entering is valid
            if (validationText == "Valid")
            {
                lblShippingErr.Text = "Email meets specifications.";
                lblShippingErr.ForeColor = Color.Green;
            }
            else
            {
                lblShippingErr.Text = validationText;
                lblShippingErr.ForeColor = Color.Red;
            }
        }

        //Validates the zipcode
        private void tbxZip_TextChanged(object sender, EventArgs e)
        {
            string validationText = clsValidation.ValidateZip(tbxZip.Text);
            //Checking if the zipcode is valid
            if (validationText == "Valid")
            {
                lblShippingErr.Text = "Zip Code meets specifications";
                lblShippingErr.ForeColor = Color.Green;
            }
            else
            {
                lblShippingErr.Text = validationText;
                lblShippingErr.ForeColor = Color.Red;
            }
        }

        private void tbxZip_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Allowing only numbers and one hyphen to be types
            clsValidation.AllowedKeysZip(e, tbxZip);
        }

        //Closes the checkout form if the user cancels payment
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            frmCustomerView.shoppingCart.Clear();
        }

        //Displays the help files
        private void lblHelp_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, hlpCheckout.HelpNamespace);
        }

        //Adds the logged in users shipping deatils to the form controls
        private void btnAdd_Click(object sender, EventArgs e)
        {
            lblShippingErr.Visible = false;

            //Adding each item in the loggedInperson List to the textboxes
            if (frmLogin.loggedInPerson != null)
            {
                tbxFirstName.Text = frmLogin.loggedInPerson.NameFirst;
                tbxLastName.Text = frmLogin.loggedInPerson.NameLast;
                tbxAddress1.Text = frmLogin.loggedInPerson.Address1;
                tbxAddress2.Text = frmLogin.loggedInPerson.Address2;
                tbxAddress3.Text = frmLogin.loggedInPerson.Address3;
                tbxCity.Text = frmLogin.loggedInPerson.City;
                cbxState.Text = frmLogin.loggedInPerson.State;
                tbxZip.Text = frmLogin.loggedInPerson.Zipcode;
                tbxEmail.Text = frmLogin.loggedInPerson.Email;
                mTbxPhone.Text = frmLogin.loggedInPerson.PhonePrimary;
            }
            
        }

        //Clears the shipping details from the form controls
        private void btnClear_Click(object sender, EventArgs e)
        {
            lblShippingErr.Visible = true;
            //Clearing the textboxes if the checkbox is unchecked
            tbxFirstName.Clear();
            tbxLastName.Clear();
            tbxAddress1.Clear();
            tbxAddress2.Clear();
            tbxAddress3.Clear();
            tbxCity.Clear();
            cbxState.SelectedIndex = -1;
            tbxZip.Clear();
            tbxEmail.Clear();
            mTbxPhone.Clear();
        }

        
    }
    
}
