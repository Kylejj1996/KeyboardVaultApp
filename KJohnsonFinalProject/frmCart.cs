using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KJohnsonFinalProject
{
    public partial class frmCart : Form
    {
        //Variables
        const decimal tax = 0.0825m;
        decimal subTotalPrice;

        /// <summary>
        /// Holds the current purchase totals (subtotal, tax, grand total) as comma-separated strings
        /// to be used by <c>frmCheckout</c>.
        /// </summary>
        public static List<string> purchaseDetails = new List<string>();//List to add totals to the checkout

        public frmCart()
        {
            InitializeComponent();
        }

        private void lbxCart_Load(object sender, EventArgs e)
        {
            loadCart();//Calling this method to load the cart
        }

        /// <summary>
        /// Loads and displays the shopping cart contents in the list box,
        /// updates subtotal, tax, and total labels, and manages button visibility.
        /// </summary>
        /// <remarks>
        /// If the cart is empty, a message is displayed and the checkout button is hidden.
        /// Otherwise, lists each cart item with details and calculates totals.
        /// Also clears and updates the purchase details list with current totals.
        /// </remarks>
        private void loadCart()
        {
            lbxCart.Items.Clear();//Clearing the list box to prevent duplicate items
            subTotalPrice = 0;//Resetting the subtotal

            //If else to check if the shoppingCar is empty
            if (frmCustomerView.shoppingCart.Count == 0)
            {
                lbxCart.Items.Add("Your cart is empty.");//Telling the user that their cart is empty
                btnClearCart.Visible = false;
                btnRemove.Visible = false;
                btnCheckout.Visible = false;
            }
            else
            {
                //Adding each item in the cart to the list box
                foreach (CartItem item in frmCustomerView.shoppingCart)
                {
                    string productName = item.ItemName;
                    decimal productPrice = item.Price;
                    int productQuantity = item.QuantitySelected;
                    decimal subTotal = productPrice * productQuantity;

                    //Adding the product to the listbox
                    lbxCart.Items.Add($"Product Name: {productName}, Price: {productPrice:C}, Quantity: {productQuantity}, Total Price: {subTotal:C}");

                    //Adding to the subtotal
                    subTotalPrice += subTotal;

                    btnClearCart.Visible = true;
                    btnRemove.Visible = true;
                    btnCheckout.Visible = true;
                }
            }

            //Calculations for tax and grand total
            decimal taxTotal = subTotalPrice * tax;
            decimal grandTotal = subTotalPrice + taxTotal;
            
            //Adding the totals to the labels
            lblSubtotalTxt.Text = subTotalPrice.ToString("C");
            lblTaxTxt.Text = taxTotal.ToString("C");
            lblTotalDueTxt.Text = grandTotal.ToString("C");

            purchaseDetails.Clear();//Clearing the purchase details

            //Adding totals to the purchaseDetails List
            purchaseDetails.Add(subTotalPrice + "," + taxTotal + "," + grandTotal);
        }

        //Closes the Cart Form
        private void btnContShopping_Click(object sender, EventArgs e)
        {
            lblCartEmpty.Visible = false;
            this.Close();
        }

        /// <summary>
        /// Handles the checkout button click event.
        /// </summary>
        /// <remarks>
        /// Checks if a user is logged in and if the shopping cart contains items.
        /// If either check fails, displays an error message.
        /// If both checks pass, closes the current form and opens the checkout form.
        /// </remarks>
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            //Checking to see if the user has a account before purchasing
            if (frmLogin.loggedInPerson == null)
            {
                MessageBox.Show("Create Account to Purchase", "Account Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Checking to see if the user has items in their cart before checking out
            if (frmCustomerView.shoppingCart.Count == 0)
            {
                //Displaying an error label
                lblCartEmpty.Visible = true;
                lblCartEmpty.Text = "Cart is empty!";
                lblCartEmpty.ForeColor = Color.Red;
                return;
            }

            this.Close();
            lblCartEmpty.Visible = false;
            frmCheckout frmCheckout = new frmCheckout();
            frmCheckout.ShowDialog();
        }

        //Removes the selected item from the shopping cart and updates the stock quantity.
        private void btnRemove_Click(object sender, EventArgs e)
        {
            //Checking to see if the user selected an item in the listbox
            if (lbxCart.SelectedItem != null)
            {
                //Getting the selected item
                CartItem selectedProduct = frmCustomerView.shoppingCart[lbxCart.SelectedIndex];

                //Finding the product in the productsList
                Inventory product = frmLogin.productsList.FirstOrDefault(p => p.InventoryID == selectedProduct.ProductID);
                if (product != null)
                {
                    //Updating the stock in the productsList
                    product.Quantity += selectedProduct.QuantitySelected;
                }

                //Removing the item from the shopping cart list
                frmCustomerView.shoppingCart.Remove(selectedProduct);

                //Removing the item from the listBox
                lbxCart.Items.Remove(lbxCart.SelectedItem);

                loadCart();//Reloading the cart
                cbxQuantity.Visible = false;
                btnUpdateQty.Visible = false;
                lbxCart.Enabled = true;//Enabling the list
            }
            else
            {
                MessageBox.Show("Please select an item to remove.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Removes all items from the shopping cart and updates the stock quantities for each item.
        private void btnClearCart_Click(object sender, EventArgs e)
        {
            foreach (CartItem cartItem in frmCustomerView.shoppingCart)
            {
                //Updating the stock using the productsList
                Inventory product = frmLogin.productsList.FirstOrDefault(p => p.InventoryID == cartItem.ProductID);
                if (product != null)
                {
                    //Updating the stock in the productsList
                    product.Quantity += cartItem.QuantitySelected;
                }
            }

            lbxCart.Items.Clear();//Clearing the listbox
            frmCustomerView.shoppingCart.Clear();//Clearing the shopping cart
            loadCart();//Reloading the cart
        }

        //Displays the quantity for the selected item in the cbxQuantity, populates it with the stock available and shows the update button
        private void lbxCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Checking to see if the user has selected an item
            if (lbxCart.SelectedIndex >= 0)
            {
                //Getting the selected product form the shoppingCart list
                CartItem selectedProduct = frmCustomerView.shoppingCart[lbxCart.SelectedIndex];

                //Calculating the total stock available
                int totalAvailable = selectedProduct.Stock + selectedProduct.QuantitySelected;

                cbxQuantity.Items.Clear();//Clearing the comboBox before adding the stock quantity

                //Adding the quantity to the comboBox
                for (int i = 1; i <= totalAvailable; i++)
                {
                    cbxQuantity.Items.Add(i);
                }

                //Setting the current quantity selected in the comboBox
                cbxQuantity.SelectedItem = selectedProduct.QuantitySelected;

                //Making the combobox and button visible
                cbxQuantity.Visible = true;
                btnUpdateQty.Visible = true;
                //Diabling the lisbox
                lbxCart.Enabled = false;
            }
        }


        //Validates the new quantity, updates the cart item, adjusts inventory stock, and refreshes the cart display.
        private void btnUpdateQty_Click(object sender, EventArgs e)
        {
            //Checking to see if the user has selected an item and quantity
            if (lbxCart.SelectedIndex >= 0 && cbxQuantity.SelectedItem != null)
            {
                //Getting the new quantity from the comboBox
                int newQty = Convert.ToInt32(cbxQuantity.SelectedItem);

                //Getting the selected CartItem object from the shopping cart
                CartItem selectedItem = frmCustomerView.shoppingCart[lbxCart.SelectedIndex];

                //Calculating the total stock available
                int totalAvailable = selectedItem.Stock + selectedItem.QuantitySelected;

                //Checking if the new quantity is within the correct stock amount
                if (newQty <= 0 || newQty > totalAvailable)
                {
                    MessageBox.Show($"Invalid quantity. Must be between 1 and {selectedItem.Stock}.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Calculating the difference between the new and old quantity
                int quantityChange = newQty - selectedItem.QuantitySelected;

                //Finding the product in the inventory list
                var product = frmLogin.productsList.FirstOrDefault(p => p.InventoryID == selectedItem.ProductID);
                if (product != null)
                {
                    product.Quantity -= quantityChange;//Adjusting the stock
                }

                //Updating the items quantity in the cart
                selectedItem.QuantitySelected = newQty;

                //Refreshing the cart
                loadCart();

                cbxQuantity.Visible = false;
                btnUpdateQty.Visible = false;
                lbxCart.Enabled = true;//Enabling the listbox
            }
            else
            {
                MessageBox.Show("Please select an item to update.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Displays the Help Files
        private void lblHelp_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, hlpCart.HelpNamespace);
        }
    }
}
