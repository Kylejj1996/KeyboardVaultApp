using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace KJohnsonFinalProject
{
    public partial class frmCustomerView : Form
    {
        StringBuilder html = new StringBuilder();//StringBuilder for the HTML
        //Global Variables
        public static bool userCheckedOut = false;
        public static bool shoppingForCustomer;
        public static string managerName = "";//String holding the managers name for checking out for customers

        /// <summary>
        /// A list of <c>CartItem</c> objects representing the current shopping cart products. 
        /// </summary>
        public static List<CartItem> shoppingCart = new List<CartItem>();//List to add products to the shopping cart
        
        public frmCustomerView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the load event of the Customer View form.
        /// Checks if a customer or manager is logged in and adjusts what controls are visible and enabled accordingly.
        /// Then, it creates buttons for each product category so that the user can filter products by clicking on those buttons.
        /// </summary>
        /// <example>
        /// Example of creating buttons for each product category and adding their click events:
        /// <code>
        /// foreach (var category in frmLogin.categoryList)
        /// {
        ///     string categoryID = category.CategoryID.ToString();
        ///     string categoryName = category.CategoryName;
        ///
        ///     Button categoryBtn = new Button
        ///     {
        ///         Text = categoryName,
        ///         Width = 120,
        ///         Height = 31,
        ///         BackColor = Color.White
        ///     };
        ///
        ///     categoryBtn.Click += (s, ev) =>
        ///     {
        ///         gbxProductDetails.Visible = false;
        ///
        ///         var filteredProducts = frmLogin.productsList
        ///             .Where(product => product.CategoryID.ToString() == categoryID)
        ///             .ToList();
        ///
        ///         DisplayProducts(filteredProducts);
        ///     };
        ///
        ///     flpCategories.Controls.Add(categoryBtn);
        /// }
        /// </code>
        /// </example>
        private void frmCustomerView_Load(object sender, EventArgs e)
        {
            //Checking to see if the user is logged into an account
            if (frmLogin.customerLoggedIn == true)
            {
                btnAdd.Enabled = true;
                btnAdd.Visible = true;
                lblCart.Visible = true;
                cbxQuantity.Enabled = true;
                cbxQuantity.Visible = true;
                lblQuantity.Visible = true;
                btnPurchaseHistory.Visible = true;
                lblReturnProd.Visible = true;
            }
            else if (frmLogin.managerLoggedIn == true)//Checking to see if the manager is logged in
            {
                btnAdd.Enabled = true;
                btnAdd.Visible = true;
                lblCart.Visible = true;
                cbxQuantity.Enabled = true;
                cbxQuantity.Visible = true;
                lblQuantity.Visible = true;
                btnPurchaseHistory.Visible = true;
                btnShopForCustomer.Visible = true;
                //Checking if the loggedIn manager list if filled
                if (frmManagerView.loggedInManager != null)
                {
                    string firstName = frmManagerView.loggedInManager.NameFirst;
                    string lastName = frmManagerView.loggedInManager.NameLast;

                    //Setting the managers name for when they order products for a customer
                    managerName = $"{firstName} {lastName}";
                }
                shopForManager();//Calling the method to add the manager to the person list 
            }
            else
            {
                //Disabling the add to cart button and quantity button
                btnAdd.Enabled = false;
                lblCart.Visible = false;
                cbxQuantity.Enabled = false;
                btnPurchaseHistory.Visible = false;
            }

            flpCategories.Controls.Clear();//Clearing the flowLayoutPanel before adding the categories to it

            //For each loop to loop through each category and add them to the buttons
            foreach (var category in frmLogin.categoryList)
            {
                string categoryID = category.CategoryID.ToString();
                string categoryName = category.CategoryName;

                //Creating buttons for each category
                Button categoryBtn = new Button
                {
                    Text = categoryName,
                    Width = 120,
                    Height = 31,
                    BackColor = Color.White
                };

                //Creating a click event for each button
                categoryBtn.Click += (s, ev) =>
                {
                    gbxProductDetails.Visible = false;

                    //Filtering the inventory by categoryID
                    var filteredProducts = frmLogin.productsList.Where(product => product.CategoryID.ToString() == categoryID).ToList();

                    DisplayProducts(filteredProducts);
                };

                flpCategories.Controls.Add(categoryBtn);  
            }
        }

        /// <summary>
        /// Refreshes the product inventory by clearing the products list in <c>frmLogin</c> and retrieving the updated product information from the database on a background thread.
        /// </summary>
        /// <example>
        /// <code>
        /// frmLogin.productsList.Clear();
        /// Thread productsThread = new Thread(() =>
        /// {
        ///     frmLogin.productsList = clsSQL.InventoryCommand();
        /// });
        /// productsThread.IsBackground = true;
        /// productsThread.Start();
        /// </code>
        /// </example>
        public void RefreshInventory()
        {
            frmLogin.productsList.Clear();

            //Getting the products from the database on a seperate thread
            Thread productsThread = new Thread(() =>
            {
                frmLogin.productsList = clsSQL.InventoryCommand();//Calling the method to the database to get all of the products and add them to the productsList
            });

            productsThread.IsBackground = true;//Making the thread a background thread
            productsThread.Start();//Starting the thread

            gbxProductDetails.Visible = false;
            flowLayoutPanelProducts.Controls.Clear();
            lblInstructions.Visible = true;
        }

        /// <summary>
        /// Displays a list of Inventory objects in the FlowLayoutPanel, creating a panel for each product with its image, name, and a button to view details.
        /// </summary>
        /// <param name="productList">A list of the Inventory objects with all current products.</param>
        private void DisplayProducts(List<Inventory> productList)
        {
            //Clear existing controls from the FlowLayoutPanel before adding new ones
            flowLayoutPanelProducts.Controls.Clear();

            //Looping through each product and add it to the FlowLayoutPanel
            foreach (Inventory product in productList)
            {
                //Checking to see if the product is discontinued
                if (product.Discontinued)
                {
                    continue;//Skipping adding that product
                }

                //Creating a panel to hold product details
                Panel productPanel = new Panel
                {
                    Width = 160,
                    Height = 180,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.White,
                    Margin = new Padding(5),
                };

                //Creating the labels for product details
                Label lblName = new Label
                {
                    Text = product.ItemName,
                    AutoSize = false,
                    Width = productPanel.Width,
                    Height = 20,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Comis Sans MS", 9, FontStyle.Bold),
                    Location = new Point(0, 5)
                };

                //Creating a picture box to hold the image
                PictureBox pbxProductImg = new PictureBox
                {
                    Width = 100,
                    Height = 100,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BorderStyle = BorderStyle.FixedSingle,
                };

                //Adding the image to the form
                pbxProductImg.Image = product.ItemImage != null ? LoadImage(product.ItemImage) : null;

                //Centering the image
                pbxProductImg.Location = new Point((productPanel.Width - pbxProductImg.Width) / 2, lblName.Bottom + 5);

                //A button to display more details
                Button btnDetails = new Button
                {
                    Text = "View Details",
                    Width = 120,
                    Height = 30,
                    Location = new Point((productPanel.Width - 120) / 2, pbxProductImg.Bottom + 5),
                };

                //Click event for the button Details to display more information
                btnDetails.Click += (sender, e) =>
                {
                    //Updating the product details labels
                    lblProductID.Text = product.InventoryID.ToString();
                    lblPriceTxt.Text = $"${product.RetailPrice:F2}";
                    lblStockTxt.Text = product.Quantity.ToString();
                    lblDescriptionTxt.Text = product.ItemDescription;

                    //Clearing and updating quantity
                    cbxQuantity.Items.Clear();
                    cbxQuantity.Text = "";

                    if (product.Quantity > 0)
                    {
                        lblSoldOut.Visible = false;
                        lblSoldOut.Visible = false;
                        lblQuantity.Visible = true;
                        cbxQuantity.Visible = true;
                        btnAdd.Visible = true;

                        //Adding the stock quantity to the combo box
                        for (int i = 1; i <= product.Quantity; i++)
                        {
                            cbxQuantity.Items.Add(i.ToString());
                        }
                        cbxQuantity.SelectedIndex = 0;
                    }
                    else
                    {
                        lblQuantity.Visible = false;
                        cbxQuantity.Visible = false;
                        btnAdd.Visible = false;
                        lblSoldOut.Visible = true;
                    }

                    //AAdding the product Image to the picture box
                    pbxKeyboardImg.Image = product.ItemImage != null ? LoadImage(product.ItemImage) : null;
                    lblKeyboardName.Text = product.ItemName;
                    

                    gbxProductDetails.Visible = true;
                };

                //Adding the controls to the panel
                productPanel.Controls.Add(lblName);
                productPanel.Controls.Add(pbxProductImg);
                productPanel.Controls.Add(btnDetails);

                //Adding the panel to FlowLayoutPanel
                flowLayoutPanelProducts.Controls.Add(productPanel);
                
            }
        }

        //Method to convert a byte array with image data into a Image object.
        private Image LoadImage(byte[] imageData)
        {
            //Checking to see if the imageData not null and contains img data
            if (imageData != null && imageData.Length > 0)
            {
                try
                {
                    //Creating a memory stream
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        //Converting the memory stream to an image
                        return Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error converting image: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No image found.");
            }
            return null;
        }

        //Closes the Customer View from, displays a warning message to the user before closing
        private void btnBack_Click(object sender, EventArgs e)
        {
            //If the shopping cart is not empty, tell the user
            if (shoppingCart.Count != 0)
            {
                DialogResult response;
                response = MessageBox.Show("You have items in your cart. If you leave this page, the cart will be cleared. Do you want to continue?", "Cart Not Empty", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (response == DialogResult.Yes)
                {
                    shoppingCart.Clear();//Clearing the shopping cart
                    this.Close();//Closing the form
                    frmLogin.loggedInPerson = null;//Clearing the currently logged in person
                    frmLogin.customerLoggedIn = false;
                }
                else
                {
                    return;
                }
            }
            this.Close();//Closing the form
            frmLogin.loggedInPerson = null;//Clearing the currently logged in person
            frmLogin.customerLoggedIn = false;
        }

        //Searches for products using the description
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = tbxSearch.Text.Trim().ToLower();//Making the searchQuery lowercase
                                                             
            if (!string.IsNullOrEmpty(searchText))
            {
                //Filtering the productsList based on product description containing the search query
                List<Inventory> filteredProducts = frmLogin.productsList.Where(product => product.ItemDescription.ToString().ToLower().Contains(searchText)).ToList();

                if (filteredProducts.Count > 0)
                {
                    DisplayProducts(filteredProducts);//Displaying the searched products
                    lblInstructions.Visible = false;
                    lblSearch.Text = "";
                }
                else
                {
                    lblSearch.Text = "No results found";
                    lblSearch.ForeColor = Color.Red;
                }
                
            }
            else
            {
                DisplayProducts(frmLogin.productsList);//Show all products if search box is empty
            }
        }

        //Opens the cart form
        private void lblCart_Click(object sender, EventArgs e)
        {
            gbxProductDetails.Visible = false;
            frmCart frmCart = new frmCart();
            frmCart.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event for the Add button.
        /// Adds the selected product and quantity to the shopping cart and updates the available stock accordingly.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>Validates the selected quantity is greater than zero.</description></item>
        /// <item><description>Updates the shopping cart by adding new items or increasing quantity of existing items.</description></item>
        /// <item><description>Updates stock quantity in the inventory and form controls.</description></item>
        /// <item><description>If the product is out of stock after adding, it disables quantity selection and the Add button.</description></item>
        /// <item><description>Prompts the user to continue shopping or view the cart.</description></item>
        /// </list>
        /// </remarks>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int productId = int.Parse(lblProductID.Text);
            string productName = lblKeyboardName.Text;
            decimal productPrice = decimal.Parse(lblPriceTxt.Text.Replace("$", ""));
            int quantity = int.Parse(cbxQuantity.SelectedItem.ToString());
            int stock = Convert.ToInt32(lblStockTxt.Text);
            tbxSearch.Text = "";//Clearing the search textbox

            //Checking if the user selected a quantity
            if(quantity <= 0)
            {
                lblQuantityErr.Text = "Select Quantity Amount";
                lblQuantityErr.ForeColor = Color.Red;
                return;
            }
            else
            {
                lblQuantityErr.Visible = false;
            }

            //Finding the product in the products list
            Inventory selectedProduct = frmLogin.productsList.FirstOrDefault(p => p.InventoryID == productId);

            //Checking if the item already exists in the cart
            var existingCartItem = shoppingCart.FirstOrDefault(item => item.ProductID == productId);

            if (existingCartItem != null)
            {
                existingCartItem.QuantitySelected += quantity;
                existingCartItem.Stock -= quantity;
            }
            else
            {
                //Creating a cart item
                CartItem newCartItem = new CartItem
                {
                    ProductID = productId,
                    ItemName = productName,
                    Price = productPrice,
                    QuantitySelected = quantity,
                    Stock = stock - quantity
                };
                shoppingCart.Add(newCartItem);//Adding the cart item to the shopping cart
            }
            
            //Adjusting the stock total after adding item to the cart
            int updatedStock = stock - quantity;
            selectedProduct.Quantity = updatedStock;
            lblStockTxt.Text = updatedStock.ToString();

            //Clearing the comboBox
            cbxQuantity.Items.Clear();

            if (updatedStock > 0)
            {
                for (int i = 1; i <= updatedStock; i++)
                {
                    cbxQuantity.Items.Add(i);//Adding the new quantity to the comboBox.
                }

                cbxQuantity.SelectedIndex = 0;
            }
            else
            {
                //Updating the controls when the product is out of stock
                cbxQuantity.Items.Add("Out of Stock");
                cbxQuantity.SelectedIndex = 0;
                cbxQuantity.Visible = false;
                btnAdd.Visible = false;
                lblSoldOut.Visible = true;
            }

            //Asking the user if they want to continue shopping
            DialogResult response = MessageBox.Show("Item added to cart! Do you want to continue shopping?", "Continue Shopping", MessageBoxButtons.YesNo);

            //If the response is no, takes them to the cart
            if (response == DialogResult.No)
            {
                gbxProductDetails.Visible = false;
                frmCart frmCart = new frmCart();
                frmCart.ShowDialog();//Opening the Cart
            }
        }

        private void lblCart_MouseHover(object sender, EventArgs e)
        {
            lblCart.ForeColor = Color.Gray;
        }

        private void lblCart_MouseLeave(object sender, EventArgs e)
        {
            lblCart.ForeColor = Color.White;
        }

        private void lblHelp_Click(object sender, EventArgs e)
        {
            //Showing the HTML Help files
            Help.ShowHelp(this, hlpCustomerView.HelpNamespace);
        }

        /// <summary>
        /// Handles the click event for the Order History button.
        /// Generates and displays the logged-in user's order history report as an HTML file.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>Checks if a user is logged in; shows error if not.</description></item>
        /// <item><description>Fetches purchase history data from the database.</description></item>
        /// <item><description>Generates the HTML report for the purchase history.</description></item>
        /// <item><description>Saves and opens the report for viewing.</description></item>
        /// </list>
        /// </remarks>
        private void btnPurchaseHistory_Click(object sender, EventArgs e)
        {
            html.Clear();//Clearing the html
            //Getting the current date to add to the saved HTML file
            DateTime dateTime = DateTime.Now;
            string formattedDate = dateTime.ToString("MM-dd-yy HH-mm-ss");

            //Checking if the loggedInPerson object is null
            if (frmLogin.loggedInPerson == null)
            {
                MessageBox.Show("No logged in user found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Accessing properties directly from the Person object
            string loggedInPerson = frmLogin.loggedInPerson.NameFirst + "_" + frmLogin.loggedInPerson.NameLast;
            string personID = frmLogin.loggedInPerson.PersonID.ToString();

            //Getting the purchase history from database
            List<string[]> purchaseHistory = clsSQL.CustomerReports(personID);

            //Checking to see if purchase history list is populated
            if(purchaseHistory.Count == 0)
            {
                MessageBox.Show("No purchase history found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Calling the method to generate the report
            html = GenerateHTMLReport(purchaseHistory, personID, dateTime);

            //Calling the method print the report
            PrintReport(html, loggedInPerson, formattedDate);
        }

        /// <summary>
        /// Generates a HTML formatted order history report for a customer.
        /// </summary>
        /// <param name="purchaseHistory">List of array with purchase history data.</param>
        /// <param name="customerID">The customer's ID.</param>
        /// <param name="date">The date of report generation.</param>
        /// <returns>A stringBuilder with the HTML.</returns>
        /// /// <remarks>
        /// <list type="bullet">
        /// <item><description>Calculates totals, discounts, taxes, and refunds per order.</description></item>
        /// <item><description>Groups purchases by order ID to create detailed tables.</description></item>
        /// <item><description>Formats the report with CSS styling.</description></item>
        /// <item><description>Includes customer contact details and total amount spent.</description></item>
        /// </list>
        /// </remarks>
        private StringBuilder GenerateHTMLReport(List<string[]> purchaseHistory, string customerID, DateTime date)
        {
            decimal tax = 0.0825m;//The tax rate
            string taxRateText = "8.25%";
            html.AppendLine("<style>");
            html.AppendLine("body {background-color:#1C2541; font-family: Arial, sans-serif; color: black; margin: 0; padding: 0;}");
            html.AppendLine(".receipt-container {width: 95%; max-width: 1000px; background-color: #F9FBF2; margin: 40px auto; padding: 20px; border-radius: 15px; color: black; box-shadow: 0 0 15px rgba(0,0,0,0.3);}");
            html.AppendLine("h1, h3, h4 {text-align: left; color: #1C2541;}");
            html.AppendLine("table {width: 100%; border-collapse: collapse; margin-top: 20px; table-layout: auto;}");
            html.AppendLine("th, td {border: 1px solid #ccc; padding: 10px; text-align: left; word-wrap: break-word;}");
            html.AppendLine("th {background-color: #1C2541; color: white;}");
            html.AppendLine("tr:nth-child(even) {background-color: #f2f2f2;}");
            html.AppendLine(".totalSpent {margin-top: 30px; font-size: 16px; text-align: right;}");
            html.AppendLine(".tblTotal td {background-color: #dfefff; font-weight: bold;}");
            html.AppendLine("</style>");

            html.AppendLine("<html>");
            html.AppendLine("<body>");
            html.AppendLine("<div class='receipt-container'>");
            html.AppendLine("<h1>Keyboard Vault</h1>");
            html.AppendLine("<h3>Order History</h3>");
            html.AppendLine($"<h4>Date: {date.ToString("MMMM dd, yyyy")}</h4>");

            //Getting the firstName, lastName, email, and phone
            string firstName = purchaseHistory[0][1];
            string lastName = purchaseHistory[0][2];
            string email = purchaseHistory[0][3];
            string phone = purchaseHistory[0][4];

            html.AppendLine($"<p><strong>Customer Name:</strong> {firstName} {lastName}</p>");
            html.AppendLine($"<p><strong>Email:</strong> {email} | <strong>Phone:</strong> {phone}</p>");

            var orders = purchaseHistory.GroupBy(p => p[0]);//Keeping the orders together
            decimal totalSpent = 0;

            //Looping through each order in the orders list
            foreach (var orderGroup in orders)
            {
                string orderID = orderGroup.Key;//The orderID for the current orderGroup
                decimal itemTotal = 0;
                decimal cartDiscountAmount = 0;
                decimal itemDiscountAmount = 0;
                decimal totalItemDiscount = 0;
                decimal totalRefunds = 0;
                bool cartDiscountApplied = false;//Boolean to keep track if the cart discount has been applied
                html.AppendLine("<table>");
                html.AppendLine("<tr class='tblHeader'><th>Order Number</th><th>Product Name</th><th>Price Per Item</th><th>Quantity</th><th>Item Total</th><th>Status</th></tr>");

                //For each loop to loop through each item in the order group
                foreach (var purchase in orderGroup)
                {
                    string productName = purchase[5];
                    decimal price = Convert.ToDecimal(purchase[6]);
                    int quantity = Convert.ToInt32(purchase[7]);
                    int refundedQuantity = Convert.ToInt32(purchase[13]);
                    decimal refundedAmount = Convert.ToDecimal(purchase[14]);
                    decimal discountPercent = purchase[8] != "NULL" ? Convert.ToDecimal(purchase[8]) : 0;
                    decimal discountDollar = purchase[9] != "NULL" ? Convert.ToDecimal(purchase[9]) : 0;
                    string discountLevel = purchase[10];// 1 - Item Level, 0 - Cart Level
                    string orderDetailsInvID = purchase[11].ToString();
                    string discountInvID = purchase[12] != null ? purchase[12].ToString() : "NULL";
                    itemDiscountAmount = 0;

                    decimal itemTotalPrice = price * quantity;

                    //Item Level Discounts
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
                    
                    //The final total to the items total price
                    decimal finalTotal = itemTotalPrice;

                    //Adding to the orders item total
                    itemTotal += finalTotal;

                    //Adding to the itemDiscount total
                    totalItemDiscount += itemDiscountAmount;

                    string status;

                    //If the product was refunded
                    if (refundedQuantity > 0)
                    {
                        status = "Refunded";
                        html.AppendLine($"<tr><td>{orderID}</td><td>{productName}</td><td>{price:C}</td><td>{quantity}</td><td>{itemTotalPrice:C}</td><td  style='color:red'>{status}</td></tr>");
                    }
                    else//If the product wasn't refunded
                    {
                        status = "Purchased";
                        html.AppendLine($"<tr><td>{orderID}</td><td>{productName}</td><td>{price:C}</td><td>{quantity}</td><td>{itemTotalPrice:C}</td><td  style='color:green'>{status}</td></tr>");
                    }
                    //Calculating the refunded amount
                    totalRefunds += refundedAmount;
                }

                //For Cart discounts
                if (!cartDiscountApplied)
                {
                    //Finding a row in the ordergroup where the discount is cartLevel
                    var cartDiscountRow = orderGroup.FirstOrDefault(p => p[10] == "0");//DiscountLevel == CartDiscount
                    //If there is a cartLevel Discount
                    if (cartDiscountRow != null)
                    {
                        //Checking for percent or dollar discount
                        decimal discountPercent = cartDiscountRow[8] != "NULL" ? Convert.ToDecimal(cartDiscountRow[8]) : 0;
                        decimal discountDollar = cartDiscountRow[9] != "NULL" ? Convert.ToDecimal(cartDiscountRow[9]) : 0;

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

                //Calculating the order total after applying cart-level discount
                decimal orderSubTotal = itemTotal;
                decimal totalDiscounts = cartDiscountAmount + totalItemDiscount;
                decimal refundedAmt = totalRefunds;
                decimal orderTotal = itemTotal - totalDiscounts;

                //Calculating the tax and the order total with tax
                decimal taxAmount = orderTotal * tax;
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

                //Showing the tax, refunds, and order total with tax
                html.AppendLine($"<tr><td colspan='5' style='text-align:right;'><strong>Tax ({taxRateText}):</strong></td><td><strong>{taxAmount:C}</strong></td></tr>");
                if (refundedAmt > 0)
                {
                    html.AppendLine($"<tr><td colspan='5' style='text-align:right; color:red;'><strong>Refunded Amount:</strong></td><td style='color:red;'><strong>-{refundedAmt:C}</strong></td></tr>");
                }
                html.AppendLine($"<tr class='tblTotal'><td colspan='5' style='text-align:right;'><strong>Order Total (with tax):</strong></td><td><strong>{orderTotalWithTax:C}</strong></td></tr>");
                html.AppendLine("</table>");

                //Calculating the total amount spent
                totalSpent += orderTotalWithTax;
            }
            html.AppendLine("</table>");

            html.AppendLine($"<div class='totalSpent'> <strong>Amount Spent to Date: {totalSpent:C}</strong> </div>");
            html.AppendLine("</div>");
            html.AppendLine("</body>");
            html.AppendLine("</html>");

            return html;
        }

        /// <summary>
        /// Saves the generated HTML report to a file and displays it in the users default browser.
        /// </summary>
        /// <param name="html">The HTML content to save and display.</param>
        /// <param name="loggedInPerson">The name of the person the report if created for.</param>
        /// <param name="formattedDate">The date to include in the filename.</param>
        /// <example>
        /// <strong>Creating the File Path:</strong>
        /// <code>
        /// string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"KV_Order_History_{loggedInPerson}_{formattedDate}.html");
        /// </code>
        /// <strong>Writing HTML to a file:</strong>
        /// <code>
        /// using (StreamWriter writer = new StreamWriter(filePath))
        /// {
        ///     writer.WriteLine(html);
        /// }
        /// </code>
        /// <strong>Opening the Order History in the Default Browser:</strong>
        /// <code>
        /// System.Diagnostics.Process.Start(filePath);
        /// </code>
        /// </example>
        public void PrintReport(StringBuilder html, string loggedInPerson, string formattedDate)
        {
            //Creating the filepath using the loggedInPerson and formattedDate to save the HTML document
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"KV_Order_History_{loggedInPerson}_{formattedDate}.html");
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
        /// Handles the click event for searching customers when a manager is shopping for a customer.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>Retrieves the search text and filters customer list by first name, last name, or username.</description></item>
        /// <item><description>Excludes accounts that are deleted or disabled from search results.</description></item>
        /// <item><description>Adds matching customers to the combo box for selection.</description></item>
        /// <item><description>Displays error messages if no customers are found or search field is empty.</description></item>
        /// </list>
        /// </remarks>
        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            //Getting the search text from the textbox
            string searchText = tbxSearchCustomer.Text.Trim().ToLower();

            lblCustSearchErr.Text = "";

            //Clearing the comboBox
            cbxSearchedCustomer.Items.Clear();
            cbxSearchedCustomer.Text = "";

            if (!string.IsNullOrEmpty(searchText) && frmManagerView.customerList != null)
            {
                foreach (Person customer in frmManagerView.customerList)
                {
                    //The different fields that can be searched
                    string fName = customer.NameFirst.ToLower();
                    string lName = customer.NameLast.ToLower();
                    string username = customer.LogonName.ToLower();
                    string email = customer.Email.ToLower();
                    string phone1 = customer.PhonePrimary.ToLower();
                    string phone2 = customer.PhoneSecondary.ToLower();

                    //If the account is deleted or disabled, skip adding that person to the comboBox
                    if (customer.AccountDeleted || customer.AccountDisabled)
                    {
                        continue;
                    }

                    //Checking if the searchText Matches anyone in the customers list
                    if (fName.Contains(searchText) ||
                        lName.Contains(searchText) ||
                        username.Contains(searchText))
                    {
                        //Adding the found customers to the comboBox
                        cbxSearchedCustomer.Items.Add($"{customer.NameFirst} {customer.NameLast}");
                        cbxSearchedCustomer.SelectedIndex = 0;
                        tbxSearchCustomer.Text = "";
                    }
                }

                //Checking if the results found anyone, if not displaying a error
                if (cbxSearchedCustomer.Items.Count == 0)
                {
                    lblCustSearchErr.Text = "No customers found.";
                    tbxSearch.Text = "";
                }
            }
            else
            {
                lblCustSearchErr.Text = "Please enter a name to search for.";
            }
        }

        /// <summary>
        /// Handles the Click event for selecting a customer when the manager is shopping for them.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>Checks if a customer is selected in the combo box.</description></item>
        /// <item><description>Finds the selected customer in the customer list and creates a new Person object.</description></item>
        /// <item><description>Updates labels and visibility of relevant controls to reflect the shopping context.</description></item>
        /// <item><description>Displays error messages if no customer is selected or found.</description></item>
        /// </list>
        /// </remarks>
        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            //Checking if the manager selected a customer from the comboBox
            if (cbxSearchedCustomer.SelectedItem == null)
            {
                lblCustSearchErr.Text = "Please select a customer to shop for.";
                return;
            }

            //Getting the selected customer
            string searchedCustomer = cbxSearchedCustomer.SelectedItem.ToString();

            //Checking if there is a selected customer, and that the customers list is populated
            if (!string.IsNullOrWhiteSpace(searchedCustomer) && frmManagerView.customerList != null)
            {
                //Finding the selected customer in the customers list
                Person selectedCustomer = frmManagerView.customerList.FirstOrDefault(customer => $"{customer.NameFirst} {customer.NameLast}".Equals(searchedCustomer, StringComparison.OrdinalIgnoreCase));

                //Adding the selected customer to the person list
                if (selectedCustomer != null)
                {
                    //Getting the selected customer and adding it to variables
                    string positionID = selectedCustomer.PositionID.ToString();
                    string positionTitle = selectedCustomer.PositionTitle;
                    string firstName = selectedCustomer.NameFirst;
                    string lastName = selectedCustomer.NameLast;
                    string address1 = selectedCustomer.Address1;
                    string address2 = selectedCustomer.Address2;
                    string address3 = selectedCustomer.Address3;
                    string city = selectedCustomer.City;
                    string state = selectedCustomer.State;
                    string zip = selectedCustomer.Zipcode;
                    string email = selectedCustomer.Email;
                    string phone = selectedCustomer.PhonePrimary;
                    string personID = selectedCustomer.PersonID.ToString();

                    //Creating a new person object and assigning it to loggedInPerson
                    frmLogin.loggedInPerson = new Person
                    {
                        PositionID = int.Parse(positionID),
                        PositionTitle = positionTitle,
                        NameFirst = firstName,
                        NameLast = lastName,
                        Address1 = address1,
                        Address2 = address2,
                        Address3 = address3,
                        City = city,
                        State = state,
                        Zipcode = zip,
                        Email = email,
                        PhonePrimary = phone,
                        PersonID = int.Parse(personID)
                    };

                    lblCustSearchErr.Text = "";
                    lblShoppingFor.Text = $"Shopping for: {firstName} {lastName}";
                    gbxSearchCustomer.Visible = false;
                    btnShopForCustomer.Visible = false;
                    btnNewCustomer.Visible = true;
                    cbxSearchedCustomer.Items.Clear();
                    cbxSearchedCustomer.Text = "";
                    btnShopAsManager.Visible = true;
                    shoppingForCustomer = true;
                }
                else
                {
                    lblCustSearchErr.Text = "Customer not found.";
                }
            }
            else
            {
                lblCustSearchErr.Text = "Please select a customer to shop for.";
            }
        }

        //Hides form controls and calls the shopForManagers() method
        private void btnShopAsManager_Click(object sender, EventArgs e)
        {
            gbxSearchCustomer.Visible = false;
            btnShopAsManager.Visible = false;
            btnNewCustomer.Visible = false;
            btnShopForCustomer.Visible = true;
            shoppingForCustomer = false;
            shopForManager();//Calling the method to add the manager to the person list
        }

        /// <summary>
        /// Sets the active shopping user to the logged in manager.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>Checks if <c>loggedInManager</c> is populated.</description></item>
        /// <item><description>Assigns the manager object to <c>loggedInPerson</c>.</description></item>
        /// </list>
        /// </remarks>
        public void shopForManager()
        {
            
            //Checking if the loggedIn manager list if filled
            if (frmManagerView.loggedInManager != null)
            {
                //Assigning the manager object to the loggedInPerson object
                frmLogin.loggedInPerson = frmManagerView.loggedInManager;

                lblWelcome.Text = $"Welcome, {frmLogin.loggedInPerson.NameFirst} {frmLogin.loggedInPerson.NameLast}";
                lblShoppingFor.Text = "";
            }
           
        }

        
        private void btnShopForCustomer_Click(object sender, EventArgs e)
        {
            gbxSearchCustomer.Visible = true;
            lblShoppingFor.Text = "";
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            gbxSearchCustomer.Visible = true;
            lblShoppingFor.Text = "";
        }

        private void btnCancelCustomer_Click(object sender, EventArgs e)
        {
            btnShopForCustomer.Visible = true;
            gbxSearchCustomer.Visible = false;
            btnShopAsManager.Visible = false;
            shopForManager();//Calling the method to add the manager to the person list
        }

        private void lblReturnProd_Click(object sender, EventArgs e)
        {
            frmReturnProduct frmReturnProduct = new frmReturnProduct();
            frmReturnProduct.ShowDialog();
        }
    }
}
