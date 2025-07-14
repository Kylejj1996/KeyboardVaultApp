using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace KJohnsonFinalProject
{
    public partial class frmManagerView : Form
    {
        //Global Variables
        public static Person loggedInManager;//List to hold the current logged in manager
        public static List<Inventory> currentProducts = new List<Inventory>();
        /// <summary>
        /// A list of <c>Discounts</c> objects storing all promo codes retrieved from the database.
        /// </summary>
        public static List<Discounts> promoCodesList = new List<Discounts>();
        /// <summary>
        /// A list of <c>Person</c> objects storing all customers retrieved from the database.
        /// </summary>
        /// <remarks>This List is used inf <c>frmReports</c> and <c>frmCustomerView</c>.</remarks>
        public static List<Person> customerList = new List<Person>();
        /// <summary>
        /// A list of <c>Person</c> objects storing all employees retrieved from the database.
        /// </summary>
        /// <remarks>This List is used inf <c>frmReports</c> and <c>frmManagerView</c>.</remarks>
        public static List<Person> employeeList = new List<Person>();
        public static List<Inventory> lowStockProducts = new List<Inventory>();//List to hold the products that have low stock
        public static bool managerAccountEdit = false;
        private byte[] imageData;//Byte array to hold the image

        public frmManagerView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the load event for the Manager View form.
        /// Initializes the form by performing the following actions:
        /// <list type="bullet">
        /// <item><description>Displays a welcome message using the logged-in manager's full name.</description></item>
        /// <item><description>Loads <c>promoCodesList</c> on a separate thread, if not already loaded.</description></item>
        /// <item><description>Loads <c>customerList</c> and <c>employeeList</c> on separate threads, if not already loaded.</description></item>
        /// <item><description>Clears and repopulates the category buttons in the flow layout panel.</description></item>
        /// <item><description>Populates discount type combo boxes with "Percentage" and "Dollar Amount".</description></item>
        /// </list>
        /// </summary>
        /// <remarks>
        /// If the <c>promoCodesList</c>, <c>customerList</c>, or <c>employeeList</c> are empty or null, this method calls their load methods to initialize them.
        /// </remarks>
        private void frmManagerView_Load(object sender, EventArgs e)
        {
            //Checking if the loggedInManager object
            if (loggedInManager != null)
            {
                string fullName = loggedInManager.NameFirst + " " + loggedInManager.NameLast;
                lblWelcome.Text = "Welcome, " + fullName;
            }

            //Check to see if promocodes have already been loaded
            if (promoCodesList == null || promoCodesList.Count == 0)
            {
                LoadPromos();//Calling the method to load the promos
            }

            //Check to see if customers and employees have been loaded
            if (customerList == null || customerList.Count == 0 || employeeList == null || employeeList.Count == 0)
            {
                LoadPerson();//Calling the method to load customers and employees/managers
            }

            flpCategories.Controls.Clear();//Clearing the flowLayoutPanel before adding the categories to it
            CreateCategoryButtons();//Calling the method to load the category buttons

            //String to hold the discount types
            string[] discountTypes = {"Percentage", "Dollar Amount",};

            //Adding the discount types to the comboBox
            cbxDiscountTypeCart.Items.AddRange(discountTypes);
            cbxDiscountTypeItem.Items.AddRange(discountTypes);

        }


        //Creates and displays category buttons for each available category, each with a click event to display products in that category.
        //It checks for low stock items and adds a "Low Stock" button if any products fall below their restock threshold.
        private void CreateCategoryButtons()
        {
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

                //Adding the categories to the comboBox
                cbxPromoItemCategory.Items.Add(categoryName);
                cbxCategory.Items.Add(categoryName);

                //Creating a click event for each button
                categoryBtn.Click += (s, ev) =>
                {
                    //Getting a list of the keyboard category selected and displaying them
                    currentProducts = frmLogin.productsList.Where(product => product.CategoryID.ToString() == categoryID).ToList();

                    DisplayProducts(currentProducts);//Displaying the products
                };

                flpCategories.Controls.Add(categoryBtn);
            }

            lowStockProducts.Clear();//Clearing the low stock products

            //Checking to see if any products are below the restock Threshold, if there are creating a button
            foreach (var product in frmLogin.productsList)
            {
                //Getting the quantity and restock threshold
                int stock = int.Parse(product.Quantity.ToString());
                int restockThreshold = int.Parse(product.RestockThreshold.ToString());

                //Checking if the stock is lower than the restock threshold
                if (stock < restockThreshold)
                {
                    lowStockProducts.Add(product);//Adding the low stock products to the list
                }
            }

            //If the list has anything in it create a button
            if (lowStockProducts.Count > 0)
            {
                //lowStockProducts = lowStockProducts.OrderBy(p => p.ItemName).ToList();
                Button stockBtn = new Button
                {
                    Text = "Low Stock",
                    Width = 120,
                    Height = 31,
                    BackColor = Color.White,
                    ForeColor = Color.Red,
                };

                //The Click event for the Low Stock button
                stockBtn.Click += (s, ev) =>
                {
                    lblStockWarning.Visible = false;//Making the stock warning label not visible

                    //Adding the low stock products to the ListBox
                    currentProducts = new List<Inventory>(lowStockProducts);

                    //Displaying the products when clicked
                    DisplayProducts(currentProducts);
                };

                //Adding the button to the flpCategories
                flpCategories.Controls.Add(stockBtn);

                lblStockWarning.Visible = true;//Making the stock warning label visible, if there is low stock
            }
        }

        /// <summary>
        /// Loads customer and employee account data using separate threads to populate the <c>customerList</c> and <c>employeeList</c>.
        /// Populates the corresponding lists based on the predefined position IDs.
        /// </summary>
        /// <remarks>
        /// Customers are retrieved using position ID "1000", while employees/managers are retrieved using position ID "1001".
        /// Separate threads are used to improve responsiveness during data loading.
        /// </remarks>
        public void LoadPerson()
        {
            string custPosID = "1000";
            string empPosID = "1001";

            //Creating a thread to get the customers and fill the list
            Thread customerThread = new Thread(() =>
            {
                customerList = clsSQL.PersonAccountsCommand(custPosID);
            });

            //Starting the Thread
            customerThread.Start();

            //Creating a thread to get the employees and fill the list
            Thread employeeThread = new Thread(() =>
            {
                employeeList = clsSQL.PersonAccountsCommand(empPosID);
            });
            
            //Starting the Thread
            employeeThread.Start();
        }

        /// <summary>
        /// Loads promotional code data on a separate thread and populates the <c>promoCodesList</c>.
        /// </summary>
        /// <remarks>
        /// Retrieves promo codes from the database using <c>clsSQL.DiscountCommandManager()</c>.
        /// </remarks>
        public void LoadPromos()
        {
            Thread promoThread = new Thread(() =>
            {
                //Getting the promoCodes from the database
                promoCodesList = clsSQL.DiscountCommandManager();
            });

            //Starting the thread
            promoThread.Start();
        }

        //               -----Inventory GroupBox-----

        /// <summary>
        /// Reloads inventory data from the database and repopulates the <c>productsList</c> when product changes occur.
        /// </summary>
        /// <remarks>
        /// Clears the existing <c>productsList</c>, retrieves updated product data on a background thread, and updates the low stock list afterward.
        /// The thread is joined to ensure the inventory is fully loaded before continuing.
        /// </remarks>
        public void RefreshInventoryProducts()
        {
            frmLogin.productsList.Clear();//Clearing the list

            //Getting the products from the database on a seperate thread
            Thread productsThread = new Thread(() =>
            {
                frmLogin.productsList = clsSQL.InventoryCommand();//Calling the method to the database to get all of the products and add them to the productsList
            });

            productsThread.IsBackground = true;//Making the thread a background thread
            productsThread.Start();//Starting the thread
            productsThread.Join();

            currentProducts.Clear();
            UpdateLowStock();//Calling the method to update the low stock products
        }

        //Updates the low stock list
        private void UpdateLowStock()
        {
            lowStockProducts.Clear();//Clearing the list

            foreach (var product in frmLogin.productsList)
            {
                if (product.Quantity < product.RestockThreshold)
                {
                    lowStockProducts.Add(product);
                }
            }
        }

        //Displays the products in a ListBox
        private void DisplayProducts(List<Inventory> productsList)
        {
            //Clear existing the Inventory List Box
            lbxInventory.Items.Clear();

            //Loop through each product and add it to the FlowLayoutPanel
            foreach (Inventory product in productsList)
            {
                //Adding the products to the listbox
                lbxInventory.Items.Add(product.ItemName.ToString());
            }
        }

        /// <summary>
        /// Converts a byte array containing image data into a <c>Image</c> object.
        /// </summary>
        /// <param name="imageData">A byte array with the image data.</param>
        /// <returns>
        /// A <c>Image</c> object if conversion is successful; otherwise <c>null</c>.
        /// Displays an error message if the image cannot be loaded or if the data is invalid.
        /// </returns>
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

        /// <summary>
        /// Converts an <c>Image</c> object to a byte array in PNG format.
        /// </summary>
        /// <param name="image">The <c>Image</c> to convert.</param>
        /// <returns>
        /// A byte array representing the image in PNG format, or <c>null</c> if the image is <c>null</c>.
        /// </returns>
        private byte[] ImageToByteArray(Image image)
        {
            //Checking if the image is null
            if (image == null)
            {
                return null;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        //Resets the Inventory groupbox controls
        public void clearInventory()
        {
            //Clearing the textboxes, picture, listbox and other controls
            tbxProductName.Text = "";
            pbxKeyboardImg.Image = null;
            tbxDescription.Text = "";
            tbxPrice.Text = "";
            tbxStock.Text = "";
            tbxCost.Text = "";
            lbxInventory.Enabled = true;
            lbxInventory.ClearSelected();
            btnCancelProductAdd.Visible = false;
            btnAddProduct.Visible = false;
            btnAddImg.Visible = false;
            btnUpdateProduct.Visible = false;
            btnNewProduct.Enabled = true;
            cbxCategory.SelectedIndex = -1;
            tbxRestockThresh.Text = "";
            gbxInventory.Enabled = false;
            lbxInventory.Items.Clear();
            flpCategories.Enabled = true;
            tbxSearch.Enabled = true;
            btnSearch.Enabled = true;
            lblInvErr.Text = "";
        }

        private void tsiViewInventory_Click(object sender, EventArgs e)
        {
            gbxProductDetails.Visible = true;
            gbxPromo.Visible = false;
        }

        //Enables adding a new product
        private void btnNewItem_Click(object sender, EventArgs e)
        {
            //Clearing the texboxes and Image
            tbxProductName.Text = "";
            pbxKeyboardImg.Image = null;
            tbxDescription.Text = "";
            tbxPrice.Text = "";
            tbxStock.Text = "";
            lbxInventory.Enabled = false;
            btnUpdateProduct.Visible = false;
            btnCancelProductAdd.Visible = true;
            btnAddImg.Visible = true;
            gbxInventory.Enabled = true;
            btnAddProduct.Visible = true;//Making the button the add a new product Visible
            flpCategories.Enabled = false;
            tbxSearch.Enabled = false;
            tbxSearch.Text = "";
            btnSearch.Enabled = false;
        }

        //Displays the selected product in the form controls
        private void lbxInventory_Click(object sender, EventArgs e)
        {
            //Checking if there is a selected item before continuing
            if (lbxInventory.SelectedItem == null)
            {
                return;
            }

            //Getting the selected Item from the listbox
            string selectedItem = lbxInventory.SelectedItem.ToString();

            //Finding the selectedProduct in the currentProducts List
            Inventory selectedProduct = currentProducts.FirstOrDefault(product => product.ItemName.ToString() == selectedItem);

            //Checking if selected product is not null
            if (selectedProduct != null)
            {
                gbxInventory.Enabled = true;
                btnUpdateProduct.Visible = true;
                btnAddImg.Visible = true;
                btnCancelProductAdd.Visible = true;
                btnNewProduct.Enabled = false;

                string productID = selectedProduct.InventoryID.ToString();
                string productName = selectedProduct.ItemName.ToString();
                string productDescription = selectedProduct.ItemDescription.ToString();
                string productPrice = selectedProduct.RetailPrice.ToString();
                int productStock = int.Parse(selectedProduct.Quantity.ToString());
                int productCategoryID = int.Parse(selectedProduct.CategoryID.ToString());
                byte[] productImage = selectedProduct.ItemImage as byte[];
                int restockThreshold = int.Parse(selectedProduct.RestockThreshold.ToString());
                string productCost = selectedProduct.Cost.ToString();
                string discontinued = selectedProduct.Discontinued.ToString();

                //Checking if the product is discontinued, if it is checking the box, if not leaving it unchecked
                if (discontinued == "True" || discontinued == "1")
                {
                    chbxProductDiscontinued.Checked = true;
                }
                else
                {
                    chbxProductDiscontinued.Checked = false;
                }

                //Finding the category name in the category list
                Categories selectedCategory = frmLogin.categoryList.FirstOrDefault(category => category.CategoryID == productCategoryID);

                if (selectedCategory != null)
                {
                    //Selecting the category in the comboBox
                    cbxCategory.SelectedItem = selectedCategory.CategoryName ;
                }

                //Updating the textBoxes and Image
                lblProductID.Text = productID;
                tbxProductName.Text = productName;
                tbxDescription.Text = productDescription;
                tbxPrice.Text = "$" + productPrice;
                tbxCost.Text = "$" + productCost;
                tbxStock.Text = productStock.ToString();
                tbxRestockThresh.Text = restockThreshold.ToString();
                pbxKeyboardImg.Image = productImage != null ? LoadImage(productImage) : null;

            }
        }

        private void btnCancelProductAdd_Click(object sender, EventArgs e)
        {
            clearInventory();
        }


        //Adds the product to the database, refreshes the inventory list, and resets the form
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string type = "Add";
            //Adding the New Inventory to Variables
            string productID = lblProductID.Text;
            string productName = tbxProductName.Text;
            string productDescription = tbxDescription.Text;
            string productCategory = cbxCategory.SelectedItem != null ? cbxCategory.SelectedItem.ToString() : null;
            //Taking the $ out of the cost and price text
            string productCost = tbxCost.Text.Replace("$", "");
            string productRetailPrice = tbxPrice.Text.Replace("$", "");
            string productStock = tbxStock.Text;
            string restockThreshold = tbxRestockThresh.Text;
            byte[] image = ImageToByteArray(pbxKeyboardImg.Image);
            string productDiscontinued = "";

            //Calling the method to validate the inventory before adding it to the database
            string message = clsValidation.ValidateInventory(productName, productDescription, productCategory, productCost, productRetailPrice, productStock, restockThreshold, image);

            if (message != "Valid")
            {
                lblInvErr.Text = message;
                return;
            }
            else
            {
                lblInvErr.Text = "";
            }

            //Checking if the checkBox is checked for the product
            if (chbxProductDiscontinued.Checked)
            {
                productDiscontinued = "1";
            }
            else
            {
                productDiscontinued = "0";
            }

            //Finding the category ID in the category list
            Categories selectedCategory = frmLogin.categoryList.FirstOrDefault(category => category.CategoryID.ToString() == productCategory);

            if (selectedCategory != null)
            {
                string productCategoryID = selectedCategory.CategoryID.ToString();

                //Calling the method too add the new product to the database
                clsSQL.AddInventoryCommand(type, productID, productName, productDescription, productCategoryID, productCost, productRetailPrice, productStock, restockThreshold, image, productDiscontinued);

                //Refreshing the Inventory
                RefreshInventoryProducts();

                //Calling the clearInventory method to clear form controls
                clearInventory();

                //Updating the currentProducts List
                currentProducts = frmLogin.productsList;
            }
            else
            {
                MessageBox.Show("Category not found");
            }
        }

        //Updates the product in the database, refreshes the inventory list, and resets the form
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            string type = "Update";
            //Adding the New Inventory to Variables
            string productID = lblProductID.Text;
            string productName = tbxProductName.Text;
            string productDescription = tbxDescription.Text;
            string productCategory = cbxCategory.SelectedItem.ToString();
            //Taking the $ out of the cost and price text
            string productCost = tbxCost.Text.Replace("$", "");
            string productRetailPrice = tbxPrice.Text.Replace("$", "");
            string productStock = tbxStock.Text;
            string restockThreshold = tbxRestockThresh.Text;
            byte[] image = ImageToByteArray(pbxKeyboardImg.Image);
            string productDiscontinued = "";

            //Checking if the checkBox is checked for the product
            if (chbxProductDiscontinued.Checked)
            {
                productDiscontinued = "1";
            }
            else
            {
                productDiscontinued = "0";
            }

            //Finding the category ID in the category list
            Categories selectedCategory = frmLogin.categoryList.FirstOrDefault(category => category.CategoryName == productCategory);

            if (selectedCategory != null)
            {
                string productCategoryID = selectedCategory.CategoryID.ToString();

                clsSQL.AddInventoryCommand(type, productID, productName, productDescription, productCategoryID, productCost, productRetailPrice, productStock, restockThreshold, image, productDiscontinued);

                //Refreshing the Inventory
                RefreshInventoryProducts();

                // Clear existing buttons
                flpCategories.Controls.Clear();

                //Recreate the category buttons
                CreateCategoryButtons();

                //Calling the clearInventory method to clear form controls
                clearInventory();

                //Updating the currentProducts List
                currentProducts = frmLogin.productsList;
                lblInvErr.Text = "";
            }
            else
            {
                MessageBox.Show("Category not found");
            }
        }

        //Adds an image to the picture box, allowing a selection from the users computer
        private void btnAddImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pbxKeyboardImg.Image = Image.FromFile(openFileDialog.FileName);//Showing the image in PictureBox

                    //Converting the image to a byte array
                    imageData = File.ReadAllBytes(openFileDialog.FileName);
                }
            }

        }

        //Key press events for the price and cost 
        private void tbxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.AllowedKeysProductPrice(e, tbxPrice);//Allowing only numbers and backspace, auto formats
        }

        private void tbxCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.AllowedKeysProductPrice(e, tbxCost);//Allowing only numbers and backspace, auto formats
        }

        //Searches for a product using the products description
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = tbxSearch.Text.Trim().ToLower();//Making the searchQuery lowercase

            if (!string.IsNullOrEmpty(searchText))
            {
                //Filtering the productsList based on product name and description containing the search query
                currentProducts = frmLogin.productsList.Where(product => product.ItemName.ToString().ToLower().Contains(searchText) || product.ItemDescription.ToString().ToLower().Contains(searchText)).ToList();

                if (currentProducts.Count > 0)
                {
                    DisplayProducts(currentProducts);//Displaying the searched products
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
                currentProducts = frmLogin.productsList;
                DisplayProducts(currentProducts);//Show all products if search box is empty
            }
        }

        //               -----Promo Codes GroupBox-----

        //Displays the promoCodes groupbox
        private void tsiViewPromo_Click(object sender, EventArgs e)
        {
            gbxProductDetails.Visible = false;
            gbxPromo.Visible = true;

            //Disabling controls in the groupBox
            tbxPromoCode.Enabled = false;
            tbxPromoDescription.Enabled = false;
            chbxCart.Enabled = false;
            chbxItem.Enabled = false;
            tbxStartDate.Enabled = false;
            tbxExpDate.Enabled = false;
            btnUpdatePromo.Visible = false;
            btnCancelPromo.Visible = false;

            //Clearing the ListBox
            lbxPromoCodes.Items.Clear();

            //Using a for each loop to add the promoCodes to the listBox
            foreach (var promoCode in promoCodesList)
            {
                //If the promo code is discontinued
                if (promoCode.isDiscontinued)
                {
                    continue;//Skips adding the promo code that is discontinued
                }

                lbxPromoCodes.Items.Add(promoCode.DiscountCode);
            }
        }

        //Refreshes the promoCodes list
        private void refreshPromoCodes()
        {
            Thread promoThread = new Thread(() =>
            {
                //Getting the new promoCodes from the database
                promoCodesList = clsSQL.DiscountCommandManager();
            });

            //Starting the thread
            promoThread.Start();
            promoThread.Join();

            //Clearing the ListBox
            lbxPromoCodes.Items.Clear();

            //Using a for each look to add the promoCodes to the listBox
            foreach (var promoCode in promoCodesList)
            {
                if (promoCode.isDiscontinued)
                {
                    continue;//Skips adding the promo code that is discontinued
                }

                lbxPromoCodes.Items.Add(promoCode.DiscountCode);
            }
        }


        private void chbxCart_Click(object sender, EventArgs e)
        {
            //If the user selects Cart discount, it shows the Cart groupbox to add the discount to the cart
            if (chbxCart.Checked)
            {
                gbxCartDiscount.Visible = true;
                chbxItem.Enabled = false;
                chbxItem.Checked = false;
                gbxItemDiscount.Visible = false;
            }
            else
            {
                gbxCartDiscount.Visible = false;
                //Clearing the textbox
                tbxDiscountCart.Text = "";
                cbxDiscountTypeCart.SelectedIndex = -1;//Clearing the ComboBox
                chbxItem.Enabled = true;
            }

        }

        private void chbxItem_Click(object sender, EventArgs e)
        {
            //If the user selects Item discount, it shows the Item groupbox to add the discount to a specific item
            if (chbxItem.Checked)
            {
                gbxItemDiscount.Visible = true;
                chbxCart.Enabled = false;
                chbxCart.Checked = false;
                gbxCartDiscount.Visible = false;
                //cbxDiscountTypeCart.Enabled = false;
                //tbxDiscountCart.Enabled = false;
            }
            else
            {
                gbxItemDiscount.Visible = false;
                tbxDiscountItem.Text = "";
                cbxDiscountTypeItem.SelectedIndex = -1;//Clearing the discountType ComboBox
                cbxPromoItemCategory.SelectedIndex = -1;//Clearing the category ComboBox
                cbxPromoItem.SelectedIndex = -1;//Clearing the item comboBox
                chbxCart.Enabled = true;
            }

        }

        private void cbxPromoItemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Checking if an item is selected
            if (cbxPromoItemCategory.SelectedItem == null)
            {
                cbxPromoItem.Items.Clear();
                return;
            }

            //Getting the selected category name
            string selectedCategoryName = cbxPromoItemCategory.SelectedItem.ToString();

            //Finding the categoryID that matches the selected name
            Categories selectedCategory = frmLogin.categoryList.FirstOrDefault(category => category.CategoryName == selectedCategoryName);

            if (selectedCategory != null)
            {
                //Finding the products that match the selected categoryID
                var matchedProducts = frmLogin.productsList.Where(product => product.CategoryID == selectedCategory.CategoryID).ToList();

                //Clearing the cbxPromoItem
                cbxPromoItem.Items.Clear();

                //Adding the matching product names to cbxPromoItem
                foreach (var product in matchedProducts)
                {
                    cbxPromoItem.Items.Add(product.ItemName.ToString());
                }

                //Selecting the first Item
                if (cbxPromoItem.Items.Count > 0)
                {
                    cbxPromoItem.SelectedIndex = -1;
                }
            }
        }

        //Cart Discount textBox leave event
        private void tbxDiscountCart_Leave(object sender, EventArgs e)
        {
            //Getting the selected discount type 
            string selectedType = cbxDiscountTypeCart.SelectedItem?.ToString();
            //Removing % or $ from the user input
            string input = tbxDiscountCart.Text.Replace("%", "").Replace("$", "").Trim();
            lblErrCart.Visible = false;

            //If no discount is selected, telling the user
            if (string.IsNullOrEmpty(selectedType))
            {
                lblErrCart.Text = "Please select a discount type.";
                lblErrCart.Visible = true;
                cbxDiscountTypeCart.Focus();
                return;
            }

            //Percentage discount
            if (selectedType == "Percentage")
            {
                if (decimal.TryParse(input, out decimal percent))
                {
                    //Checking if the percentage is between 1 and 100
                    if (percent >= 1 && percent <= 100)
                    {
                        //Formating the text
                        tbxDiscountCart.Text = $"{percent}%";
                    }
                    else
                    {
                        //Telling the user that the percentage is out of range
                        lblErrCart.Text = "Please enter a percentage between 1 and 100.";
                        lblErrCart.Visible = true;
                        tbxDiscountCart.Focus();
                    }
                }
                else if (!string.IsNullOrEmpty(input))
                {
                    //Telling the user that the input is not a vaild number
                    lblErrCart.Text = "Please enter a valid number for percentage.";
                    lblErrCart.Visible = true;
                    tbxDiscountCart.Focus();
                }
            }
            //Dollar discount
            else if (selectedType == "Dollar Amount")
            {
                if (decimal.TryParse(input, out decimal dollar))
                {
                    //Checking if the dollar amount is greater than zero
                    if (dollar >= 0.01m)
                    {
                        //Formatting the text
                        tbxDiscountCart.Text = $"${dollar:0.00}";
                    }
                    else
                    {
                        //Telling the user that the dollar amount is too low
                        lblErrCart.Text = "Please enter a dollar amount greater than 0.";
                        lblErrCart.Visible = true;
                        tbxDiscountCart.Focus();
                    }
                }
                else if (!string.IsNullOrEmpty(input))
                {
                    //Telling the user that the input is not a vaild number
                    lblErrCart.Text = "Please enter a valid dollar amount.";
                    lblErrCart.Visible = true;
                    tbxDiscountCart.Focus();
                }
            }
        }

        //Item Discount textBox leave event
        private void tbxDiscountItem_Leave(object sender, EventArgs e)
        {
            //Getting the selected discount type
            string selectedType = cbxDiscountTypeItem.SelectedItem?.ToString();
            //Removing % or $ from the user input
            string input = tbxDiscountItem.Text.Replace("%", "").Replace("$", "").Trim();
            lblErrItem.Visible = false;

            //If no discount is selected, telling the user
            if (string.IsNullOrEmpty(selectedType))
            {
                lblErrItem.Text = "Please select a discount type.";
                lblErrItem.Visible = true;
                cbxDiscountTypeItem.Focus();
                return;
            }
            //Percentage Discount
            if (selectedType == "Percentage")
            {
                if (decimal.TryParse(input, out decimal percent))
                {
                    //Checking if the percentage is between 1 and 100
                    if (percent >= 1 && percent <= 100)
                    {
                        //Formatting the Text
                        tbxDiscountItem.Text = $"{percent}%";
                    }
                    else
                    {
                        //Telling the user that the percentage is out of range
                        lblErrItem.Text = "Please enter a percentage between 1 and 100.";
                        lblErrItem.Visible = true;
                        tbxDiscountItem.Focus();
                    }
                }
                else if (!string.IsNullOrEmpty(input))
                {
                    //Telling the user that the input is not a vaild number
                    lblErrItem.Text = "Please enter a valid number for percentage.";
                    lblErrItem.Visible = true;
                    tbxDiscountItem.Focus();
                }
            }
            //Dollar Amount
            else if (selectedType == "Dollar Amount")
            {
                if (decimal.TryParse(input, out decimal dollar))
                {
                    //Checking if the dollar amount is greater than zero
                    if (dollar >= 0.01m)
                    {
                        //Formatting the text
                        tbxDiscountItem.Text = $"${dollar:0.00}";
                    }
                    else
                    {
                        //Telling the user that the dollar amount is too low
                        lblErrItem.Text = "Please enter a dollar amount greater than 0.";
                        lblErrItem.Visible = true;
                        tbxDiscountItem.Focus();
                    }
                }
                else if (!string.IsNullOrEmpty(input))
                {
                    //Telling the user that the input is not a vaild number
                    lblErrItem.Text = "Please enter a valid dollar amount.";
                    lblErrItem.Visible = true;
                    tbxDiscountItem.Focus();
                }
            }
        }

        private void cbxDiscountTypeCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Clearing the textbox is the user selects a different discount type
            tbxDiscountCart.Text = "";
        }

        private void cbxDiscountTypeItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Clearing the textbox is the user selects a different discount type
            tbxDiscountItem.Text = "";
        }

        /// <summary>
        /// Handles the Add Promo button click event.
        /// <list type="bullet">
        /// <item><description>Validates and processes user input to add a new promotional code.</description></item>
        /// <item><description>Performs input validation for promo code, discount amounts, and dates.</description></item>
        /// <item><description>Adds the promo code to the database if the validations pass, and then refreshes the promo codes list and resets the form.</description></item>
        /// </list>
        /// </summary>
        /// <param name="sender">The source of the event (Add Promo Button).</param>
        /// <param name="e">The event arguments.</param>
        private void btnAddPromo_Click(object sender, EventArgs e)
        {
            //Getting the promoCode
            string promoCode = tbxPromoCode.Text;
            string description = tbxPromoDescription.Text;
            string discountLevel = "";
            int discountTypeValue = 0;
            string inventoryID = "";
            string startDate = "";
            string endDate = "";
            decimal discountPercentage = 0;
            decimal discountDollarAmnt = 0;

            //Checking if the promoCode is valid before adding it
            string promoMessage = clsValidation.ValidatePromo(promoCode);

            if (promoMessage != "Valid")
            {
                lblPromoErr.Text = promoMessage;
                lblPromoErr.ForeColor = Color.Red;
                return;
            }

            //Checking which discount level is checked: Cart level, or Item Level
            if (chbxCart.Checked)//Cart level
            {
                discountLevel = "0";
                discountTypeValue = (cbxDiscountTypeCart.Text == "Percentage") ? 0 : 1;//Getting the discountType

                //Getting rid of the $ and % in the text to add it to the database
                string discountText = tbxDiscountCart.Text.Replace("%", "").Replace("$", "").Trim();

                if (string.IsNullOrWhiteSpace(discountText))//Checking if the user entered a discount amount
                {
                    lblPromoErr.Text = "Please enter a discount amount.";
                    return;
                }

                if (discountTypeValue == 0)//percentage
                {
                    if (decimal.TryParse(discountText, out decimal percentage))
                    {
                        discountPercentage = percentage / 100;
                    }
                    else
                    {
                        //Telling the user there is a error
                        lblPromoErr.Text = "Invalid percentage entered.";
                    }
                }
                else if (discountTypeValue == 1)//Dollar Amount
                {
                    if (decimal.TryParse(discountText, out decimal dollarAmount))
                    {
                        discountDollarAmnt = dollarAmount;
                    }
                    else
                    {
                        //Telling the user there is a error
                        lblPromoErr.Text = "Invalid dollar amount entered.";
                    }
                }
            }
            else if (chbxItem.Checked)//Item Level
            {
                discountLevel = "1";
                discountTypeValue = (cbxDiscountTypeItem.Text == "Percentage") ? 0 : 1;//Getting the discountType
                inventoryID = tbxPromoProductID.Text;//Getting the selected ProductID

                string discountText = tbxDiscountItem.Text.Replace("%", "").Replace("$", "").Trim();

                if (string.IsNullOrWhiteSpace(discountText))//Checking if the user entered a discount amount
                {
                    lblPromoErr.Text = "Please enter a discount amount.";
                    return;
                }

                //Checking if the user selected a category
                if (cbxPromoItemCategory.SelectedIndex == -1)
                {
                    lblPromoErr.Text = "Please select a category to choose from.";
                    return;
                }

                //Checking if the user selected a keyboard for discount
                if (cbxPromoItem.SelectedIndex == -1)
                {
                    lblPromoErr.Text = "Please select a keyboard for the promo code.";
                    return;
                }

                if (discountTypeValue == 0)//Percentage
                {
                    if (decimal.TryParse(discountText, out decimal percentage))
                    {
                        discountPercentage = percentage / 100;
                    }
                    else
                    {
                        //Telling the user there is a error
                        lblPromoErr.Text = "Invalid percentage entered.";
                    }
                }
                else if (discountTypeValue == 1)//Dollar Amount
                {
                    if (decimal.TryParse(discountText, out decimal dollarAmount))
                    {
                        discountDollarAmnt = dollarAmount;
                    }
                    else
                    {
                        //Telling the user there is a error
                        lblPromoErr.Text = "Invalid dollar amount entered.";
                    }
                }
            }

            //Getting the start and end dates
            DateTime formattedStartDate;
            DateTime formattedEndDate;

            if (!string.IsNullOrWhiteSpace(tbxStartDate.Text) && DateTime.TryParse(tbxStartDate.Text, out formattedStartDate))
            {
                startDate = formattedStartDate.ToString("yyyy-MM-dd");//Creating the formatted date
            }
            else
            {
                startDate = "";//Keeping startDate empty
            }

            //Trying to parse and format the expiration date
            if (!DateTime.TryParse(tbxExpDate.Text, out formattedEndDate))
            {
                lblPromoErr.Text = "Please enter a valid expiration date.";
                lblPromoErr.ForeColor = Color.Red;
                return;
            }
            else
            {
                endDate = formattedEndDate.ToString("yyyy-MM-dd");//Creating the formatted date
                lblPromoErr.Text = "";
                lblPromoErr.ForeColor = Color.Green;
            }

            string validationText = clsValidation.ValidatePromo(promoCode, description, discountLevel, discountTypeValue, endDate);//Calling the method to validate the promo codes

            if (validationText == "Valid")
            {
                lblPromoErr.Visible = false;
                //Calling the method to add the promoCode to the database
                clsSQL.AddPromoCode(promoCode, description, discountLevel, inventoryID, discountTypeValue, discountPercentage, discountDollarAmnt, startDate, endDate);

                refreshPromoCodes();//Calling the method to refresh the promo Codes list
                resetPromoForm();//Calling the method to reset the form
            }
            else
            {
                lblPromoErr.Text = validationText;
            }

        }



        /// <summary>
        /// Handles the selection change event for the promo codes list box.
        /// <list type="bullet">
        /// <item><description>Enables and populates the text boxes for promo code and description.</description></item>
        /// <item><description>Selects the category and promo item in combo boxes.</description></item>
        /// <item><description>Checks and sets the discount level (Cart or Item) and displays the related groupBox visibility.</description></item>
        /// <item><description>Sets discount type and amount in relevant text boxes and combo boxes.</description></item>
        /// <item><description>Formats and sets start and expiration dates in the date text boxes.</description></item>
        /// <item><description>Enables and configures buttons and group boxes related to promo code editing.</description></item>
        /// </list>
        /// </summary>
        /// <param name="sender">The source of the event (Promo Codes ListBox).</param>
        /// <param name="e">The event arguments.</param>
        private void lbxPromoCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Enabling controls in the groupBox
            tbxPromoCode.Enabled = true;
            tbxPromoDescription.Enabled = true;
            chbxCart.Enabled = true;
            chbxItem.Enabled = true;

            //Start Date and End Date
            tbxStartDate.Enabled = true;
            tbxExpDate.Enabled = true;

            btnUpdatePromo.Visible = true;
            btnCancelPromo.Visible = true;
            btnNewPromo.Enabled = false;//Disabling the new Promo Code Button
            gbxPromoFields.Visible = true;
            btnDeletePromo.Visible = true;

            //Checking if a promo code is selected
            if (lbxPromoCodes.SelectedItem == null)
            {
                return;
            }

            //Getting the selected promo code from the listBox
            string selectedPromoCode = lbxPromoCodes.SelectedItem.ToString();

            //Finding the corresponding promo code from the promoCodesList
            Discounts selectedPromo = promoCodesList.FirstOrDefault(promo => promo.DiscountCode == selectedPromoCode);

            if (selectedPromo == null)
            {
                return;
            }
            
            lblSubtitle.Visible = false;

            //Setting the promo code and description
            tbxPromoID.Text = selectedPromo.DiscountID.ToString();
            tbxPromoCode.Text = selectedPromo.DiscountCode;
            tbxPromoDescription.Text = selectedPromo.Description;

            //Looping through categoryList to find the matching CategoryID
            foreach (var category in frmLogin.categoryList)
            {
                if (category.CategoryID == selectedPromo.CategoryID)
                {
                    int index = cbxPromoItemCategory.Items.IndexOf(category.CategoryName);//Getting the index of the category name
                    if (index >= 0)
                    {
                        cbxPromoItemCategory.SelectedIndex = index;//Set ComboBox selection
                    }
                    break; 
                }
            }
            //Setting the selected Promo Item if it is not NULL
            if (selectedPromo.ItemName != null)
            {
                cbxPromoItem.SelectedItem = selectedPromo.ItemName;//Set ComboBox selected item
            }


            //Checking the Discount Level and checking the corresponding checkbox
            if (selectedPromo.DiscountLevel == 0)//Cart level
            {
                chbxCart.Checked = true;
                gbxCartDiscount.Visible = true;
                chbxItem.Checked = false;
                gbxItemDiscount.Visible = false;
            }
            else if (selectedPromo.DiscountLevel == 1)//Item level
            {
                chbxCart.Checked = false;
                gbxCartDiscount.Visible = false;
                chbxItem.Checked = true;
                gbxItemDiscount.Visible = true;
            }

            //Setting the Discount Type and Amount 
            if (chbxCart.Checked)//Cart level
            {
                string discountTypeCart = selectedPromo.DiscountType.ToString();

                //Setting to comboBox to the correct discount type
                if (discountTypeCart == "0")//Percentage
                {
                    cbxDiscountTypeCart.SelectedIndex = 0;
                }
                else//Dollar Amount
                {
                    cbxDiscountTypeCart.SelectedIndex = 1;
                }

                //Setting the textbox with the discount
                if (selectedPromo.DiscountType == 0)//Percentage
                {
                    decimal percentageDiscount = selectedPromo.DiscountPercentage;
                    tbxDiscountCart.Text = (percentageDiscount * 100).ToString("0") + "%";
                }
                else//Dollar Amount
                {
                    decimal dollarDiscount = selectedPromo.DiscountDollarAmount;
                    tbxDiscountCart.Text = dollarDiscount.ToString("C2");
                }
            }
            else if (chbxItem.Checked)//Item level
            {
                string discountTypeItem = selectedPromo.DiscountType.ToString();

                //Setting to comboBox to the correct discount type
                if (discountTypeItem == "0")//Percentage
                {
                    cbxDiscountTypeItem.SelectedIndex = 0;
                }
                else//Dollar Amount
                {
                    cbxDiscountTypeItem.SelectedIndex = 1;
                }

                //Adding the productID to the textBox
                tbxPromoProductID.Text = selectedPromo.InventoryID.ToString();//Product ID 

                if (selectedPromo.DiscountType == 0)//Percentage
                {
                    decimal percentageDiscount = selectedPromo.DiscountPercentage;
                    tbxDiscountItem.Text = (percentageDiscount * 100).ToString("0") + "%";
                }
                else//Dollar Amount
                {
                    decimal dollarDiscount = selectedPromo.DiscountDollarAmount;
                    tbxDiscountItem.Text = dollarDiscount.ToString("C2");
                }
            }

            //Setting the Start Date, if not null
            if (selectedPromo.StartDate != null && DateTime.TryParse(selectedPromo.StartDate.ToString(), out DateTime startDate))
            {
                tbxStartDate.Text = startDate.ToString("MM/dd/yyyy");//Adding the start date formatted
            }

            // Set the End Date, Expiration Date
            if (selectedPromo.ExpirationDate != null && DateTime.TryParse(selectedPromo.ExpirationDate.ToString(), out DateTime endDate))
            {
                tbxExpDate.Text = endDate.ToString("MM/dd/yyyy");//Adding the end date formatted
            }
            
        }

        private void cbxPromoItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Getting the selected Item from the comboBox
            string selectedProduct = cbxPromoItem.SelectedItem.ToString();

            if (selectedProduct != null)
            {
                var productName = frmLogin.productsList.FirstOrDefault(p => p.ItemName.ToString() == selectedProduct);

                if (productName != null)
                {
                    //Adding the productID to the textBox
                    tbxPromoProductID.Text = productName.InventoryID.ToString();//Product ID
                }
                else
                {
                    tbxPromoProductID.Text = "";//Clear if not found
                }
                
            }
        }

        /// <summary>
        /// Handles the update of an existing promo code when the Update button is clicked.
        /// Validates user input, parses discount values, and updates the promo code record in the database.
        /// </summary>
        /// <param name="sender">The source of the event (Update Promo Button).</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>Validates discount amounts, discount level (cart or item), selected category, and promo dates.</description></item>
        /// <item><description>Displays error messages in <c>lblPromoErr</c> if validation fails.</description></item>
        /// <item><description>Calls <c>clsSQL.UpdatePromoCode</c> to save changes on successful validation.</description></item>
        /// <item><description>Refreshes the promo codes list and resets the promo form after update.</description></item>
        /// </list>
        /// </remarks>
        private void btnUpdatePromo_Click(object sender, EventArgs e)
        {
            //Getting the promoCode
            string promoID = tbxPromoID.Text;
            string promoCode = tbxPromoCode.Text;
            string description = tbxPromoDescription.Text;
            string discountLevel = "";
            int discountTypeValue = 0;
            string inventoryID = "";
            string startDate = "";
            string endDate = "";
            decimal discountPercentage = 0;
            decimal discountDollarAmnt = 0;

            //Checking which discount level is checked: Cart level, or Item Level
            if (chbxCart.Checked)//Cart level
            {
                discountLevel = "0";
                discountTypeValue = (cbxDiscountTypeCart.Text == "Percentage") ? 0 : 1;//Getting the discountType
                //Getting rid of the $ and % in the text to add it to the database
                string discountText = tbxDiscountCart.Text.Replace("%", "").Replace("$", "").Trim();

                if (string.IsNullOrWhiteSpace(discountText))//Checking if the user entered a discount amount
                {
                    lblPromoErr.Text = "Please enter a discount amount.";
                    return;
                }

                if (discountTypeValue == 0)//percentage
                {
                    if (decimal.TryParse(discountText, out decimal percentage))
                    {
                        discountPercentage = percentage / 100;
                    }
                    else
                    {
                        //Telling the user there is a error
                        lblPromoErr.Text = "Invalid percentage entered.";
                    }
                }
                else if (discountTypeValue == 1)//Dollar Amount
                {
                    if (decimal.TryParse(discountText, out decimal dollarAmount))
                    {
                        discountDollarAmnt = dollarAmount;
                    }
                    else
                    {
                        //Telling the user there is a error
                        lblPromoErr.Text = "Invalid dollar amount entered.";
                    }
                }
            }
            else if (chbxItem.Checked)//Item Level
            {
                discountLevel = "1";
                discountTypeValue = (cbxDiscountTypeItem.Text == "Percentage") ? 0 : 1;//Getting the discountType
                inventoryID = tbxPromoProductID.Text;//Getting the selected ProductID

                string discountText = tbxDiscountItem.Text.Replace("%", "").Replace("$", "").Trim();

                if (string.IsNullOrWhiteSpace(discountText))//Checking if the user entered a discount amount
                {
                    lblPromoErr.Text = "Please enter a discount amount.";
                    return;
                }

                //Checking if the user selected a category
                if (cbxPromoItemCategory.SelectedIndex == -1)
                {
                    lblPromoErr.Text = "Please select a category to choose from.";
                    return;
                }

                //Checking if the user selected a keyboard for discount
                if (cbxPromoItem.SelectedIndex == -1)
                {
                    lblPromoErr.Text = "Please select a keyboard for the promo code.";
                    return;
                }

                if (discountTypeValue == 0)//Percentage
                {
                    if (decimal.TryParse(discountText, out decimal percentage))
                    {
                        discountPercentage = percentage / 100;
                    }
                    else
                    {
                        //Telling the user there is a error
                        lblPromoErr.Text = "Invalid percentage entered.";
                    }
                }
                else if (discountTypeValue == 1)//Dollar Amount
                {
                    if (decimal.TryParse(discountText, out decimal dollarAmount))
                    {
                        discountDollarAmnt = dollarAmount;
                    }
                    else
                    {
                        //Telling the user there is a error
                        lblPromoErr.Text = "Invalid dollar amount entered.";
                    }
                }
            }

            //Getting the start and end dates
            DateTime formattedStartDate;
            DateTime formattedEndDate;

            if (!string.IsNullOrWhiteSpace(tbxStartDate.Text) && DateTime.TryParse(tbxStartDate.Text, out formattedStartDate))
            {
                startDate = formattedStartDate.ToString("yyyy-MM-dd");//Creating the formatted date
            }
            else
            {
                startDate = "";//Keeping startDate empty
            }

            //Trying to parse and format the expiration date
            if (!DateTime.TryParse(tbxExpDate.Text, out formattedEndDate))
            {
                lblPromoErr.Text = "Please enter a valid expiration date.";
                return;
            }
            else
            {
                endDate = formattedEndDate.ToString("yyyy-MM-dd");//Creating the formatted date
            }

            string validationText = clsValidation.ValidatePromo(promoCode, description, discountLevel, discountTypeValue, endDate);//Calling the method to validate the promo codes

            if (validationText == "Valid")
            {
                //Calling the method to add the promoCode to the database
                clsSQL.UpdatePromoCode(promoID, promoCode, description, discountLevel, inventoryID, discountTypeValue, discountPercentage, discountDollarAmnt, startDate, endDate);

                refreshPromoCodes();//Calling the method to refresh the promo Codes list
                resetPromoForm();//Calling the method to reset the form
            }
            else
            {
                lblPromoErr.Text = validationText;
                return;
            }


        }

        private void btnNewPromo_Click(object sender, EventArgs e)
        {
            //Enabling/Disabling controls in the groupBox
            lbxPromoCodes.Enabled = false;
            tbxPromoCode.Enabled = true;
            tbxPromoDescription.Enabled = true;
            cbxPromoItemCategory.Focus();
            cbxPromoItemCategory.Enabled = true;
            cbxPromoItem.Enabled = true;
            chbxCart.Enabled = true;
            chbxItem.Enabled = true;
            tbxStartDate.Enabled = true;
            tbxExpDate.Enabled = true;
            btnUpdatePromo.Visible = false;
            btnCancelPromo.Visible = true;
            btnAddPromo.Visible = true;
            btnNewPromo.Enabled = false;//Disabling the new Promo Code Button
            gbxPromoFields.Visible = true;
            btnDeletePromo.Visible = false;
            lblSubtitle.Visible = false;
        }

        private void resetPromoForm()
        {
            //Enabling/Disabling controls in the groupBox
            lbxPromoCodes.Enabled = true;
            lbxPromoCodes.ClearSelected();
            gbxCartDiscount.Visible = false;
            gbxItemDiscount.Visible = false;
            tbxPromoCode.Enabled = false;
            tbxPromoDescription.Enabled = false;
            chbxCart.Enabled = false;
            chbxItem.Enabled = false;
            tbxStartDate.Enabled = false;
            tbxExpDate.Enabled = false;
            btnUpdatePromo.Visible = false;
            btnCancelPromo.Visible = false;
            btnAddPromo.Visible = false;
            btnNewPromo.Enabled = true;//Enabling the new Promo Code Button
            gbxPromoFields.Visible = false;
            btnDeletePromo.Visible = false;
            lblSubtitle.Visible = true;

            //Clearing the fields
            tbxPromoCode.Text = "";
            tbxPromoDescription.Text = "";
            chbxCart.Checked = false;
            chbxItem.Checked = false;
            cbxDiscountTypeItem.SelectedIndex = -1;
            cbxPromoItemCategory.SelectedIndex = -1;
            cbxPromoItem.SelectedIndex = -1;
            tbxDiscountItem.Text = "";
            tbxPromoProductID.Text = "";
            cbxDiscountTypeCart.SelectedIndex = -1;
            tbxDiscountCart.Text = "";
            tbxStartDate.Text = "";
            tbxExpDate.Text = "";
            lblPromoErr.Text = "";
        }

        private void btnCancelPromo_Click(object sender, EventArgs e)
        {
            resetPromoForm();//Calling the Method to Reset the Promo Code controls
        }

        private void tbxStartDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.AllowedKeysExpDatePromo(e, tbxStartDate);//Allowing only numbers and backspace, auto formats
        }

        private void tbxStartDate_TextChanged(object sender, EventArgs e)
        {
            //Method to validate the startDate
            string validationText = clsValidation.ValidatePromoDate(tbxStartDate.Text, true);
            tbxExpDate.Text = "";//Clearing the expiration date
            if (validationText == "Valid")
            {
                lblPromoErr.Text = "Start Date is valid";
                lblPromoErr.ForeColor = Color.Green;
            }
            else
            {
                lblPromoErr.Text = validationText;
                lblPromoErr.ForeColor = Color.Red;
            }
        }

        private void tbxExpDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.AllowedKeysExpDatePromo(e, tbxExpDate);//Allowing only numbers and backspace, auto formats
        }

        private void tbxExpDate_TextChanged(object sender, EventArgs e)
        {
            //Method to validate the expDate
            string validationText = clsValidation.ValidatePromoDate(tbxExpDate.Text, false, tbxStartDate.Text);

            if (validationText == "Valid")
            {
                lblPromoErr.Text = "Expiration date is valid";
                lblPromoErr.ForeColor = Color.Green;
            }
            else
            {
                lblPromoErr.Text = validationText;
                lblPromoErr.ForeColor = Color.Red;
            }
        }

        //Closes the ManagerView form, sets managerLoggedIn to false
        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin.managerLoggedIn = false;//Setting this to false
            frmCustomerView.shoppingForCustomer = false;//Setting to false
            this.Close();//Exits the Manager View Form 
        }

        //Dispalys the Manager Accounts form
        private void tsiViewManagerAcct_Click(object sender, EventArgs e)
        {
            managerAccountEdit = false;
            frmManagerAccounts frmManagerAccounts = new frmManagerAccounts();
            frmManagerAccounts.ShowDialog();
        }

        //Displays the Customers Account form
        private void tsiViewCustomersAcct_Click(object sender, EventArgs e)
        {
            frmCustomerAccounts frmCustomerAccounts = new frmCustomerAccounts();
            frmCustomerAccounts.ShowDialog();
        }

        //Deletes the selected promo code, updates the database, resets the from and reloads the promoCodes list
        private void btnDeletePromo_Click(object sender, EventArgs e)
        {
            //Getting the promoCode
            string promoID = tbxPromoID.Text;
            string promoCode = tbxPromoCode.Text;

            //Calling the method to remove the promo code
            clsSQL.RemovePromoCode(promoID, promoCode);
            resetPromoForm();//Calling the method to reset the promo Form
            refreshPromoCodes();//Calling the method to refresh the promo codes
            btnDeletePromo.Visible = false;
        }

        private void tbxPromoCode_TextChanged(object sender, EventArgs e)
        {
            //Checking if lbxPromoCodes has a selection
            if (lbxPromoCodes.SelectedItem != null)
            {
                return;//Skipping the validation
            }

            //Method to validate the username
            string validationText = clsValidation.ValidatePromo(tbxPromoCode.Text);

            if (validationText == "Valid")
            {
                lblPromoErr.Text = "Promo Code is valid";
                lblPromoErr.ForeColor = Color.Green;
            }
            else
            {
                lblPromoErr.Text = validationText;
                lblPromoErr.ForeColor = Color.Red;
            }
        }

      
        private void viewCustomerAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerAccounts frmCustomerAccounts = new frmCustomerAccounts();
            frmCustomerAccounts.ShowDialog();
        }

        private void tsiViewInventoryReports_Click(object sender, EventArgs e)
        {
            frmReports frmReports = new frmReports();
            frmReports.ShowDialog();//Showing the Reports form
        }

        private void viewShopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerView frmCustomerView = new frmCustomerView();    
            frmCustomerView.ShowDialog();//Opening the customer View shop
        }

        private void tsiMyAccount_Click(object sender, EventArgs e)
        {
            managerAccountEdit = true;
            frmManagerAccounts frmManagerAccounts = new frmManagerAccounts();
            frmManagerAccounts.ShowDialog();
        }

        //Displays the help files
        private void lblHelp_Click(object sender, EventArgs e)
        {
            //Showing the HTML Help files
            Help.ShowHelp(this, hlpManagerView.HelpNamespace);
        }

        private void returnRequestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReturnRequests frmReturnRequests = new frmReturnRequests();
            frmReturnRequests.ShowDialog();
        }
    }
}
                

