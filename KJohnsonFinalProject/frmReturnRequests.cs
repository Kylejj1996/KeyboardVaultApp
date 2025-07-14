using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KJohnsonFinalProject
{
    public partial class frmReturnRequests : Form
    {
        //Global Variables
        List<string[]> returnRequests = new List<string[]>();
        public frmReturnRequests()
        {
            InitializeComponent();
        }

        //Retrieves return requests from the database and populates the list box with the request details.
        private void frmReturnRequests_Load(object sender, EventArgs e)
        {
            //Getting the return requests
            returnRequests = clsSQL.getReturnRequests();

            //Clearing the listbox
            lbxReturnRequests.Items.Clear();

            foreach (string[] returns in returnRequests)
            {
                //Example Displaying: Order #105 - Requested on June 10, 2025
                string display = $"Order #{returns[1]} - Requested on {DateTime.Parse(returns[9]).ToString("MMMM dd, yyyy")}";
                lbxReturnRequests.Items.Add(display);
            }
        }

        //Refreshes the refund requests that are displayed in the listBox.
        //Retrieves the return requests from the database after changes were made and populates the list box with the request details.
        private void RefreshRefundRequests()
        {
            //Getting the return requests
            returnRequests = clsSQL.getReturnRequests();

            //Clearing the listbox
            lbxReturnRequests.Items.Clear();

            foreach (string[] returns in returnRequests)
            {
                // Displaying: "John Doe - ItemName (Qty: 2) - $49.98"
                string display = $"Order ID: {returns[1]} Date Requested: {returns[9]}";
                lbxReturnRequests.Items.Add(display);
            }
        }

        //Resets the form
        private void ResetForm()
        {
            tbxCustName.Text = "";
            tbxProdName.Text = "";
            tbxQuantity.Text = "";
            tbxReason.Text = "";
            tbxRefundAmt.Text = "";
            lbxReturnRequests.ClearSelected();
            lbxReturnRequests.Enabled = true;
            chbxReceived.Checked = false;
            tbxCustName.Enabled = false;
            tbxProdName.Enabled = false;
            tbxQuantity.Enabled = false;
            tbxReason.Enabled = false;
            tbxRefundAmt.Enabled = false;
            btnApproveReturn.Enabled = false;
            btnCancel.Enabled = false;
            chbxReceived.Enabled = false;
            lblErr.Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();//Closing the return Requests Form
        }

        //Validates the selected return request, processes the refund if the return is received,
        //updates the ReturnRequests and ReturnedOrders tables in the database, and
        //refreshes the inventory in the manager view, and resets the form.
        private void btnApproveReturn_Click(object sender, EventArgs e)
        {
            //Getting the selected index
            int index = lbxReturnRequests.SelectedIndex;

            if (index >= 0 && index < returnRequests.Count)
            {
                lbxReturnRequests.Enabled = false;//Disabling the listBox

                string[] selectedRequest = returnRequests[index];//Getting the selected return from the returnRequests list
                int returnID = int.Parse(selectedRequest[0]);
                int orderID = int.Parse(selectedRequest[1]);
                int inventoryID = int.Parse(selectedRequest[2]);
                int personID = int.Parse(selectedRequest[3]);
                int managerID = frmManagerView.loggedInManager.PersonID;
                int quantityReturned = int.Parse(selectedRequest[8]);
                decimal refundAmount = Math.Round(CalculateRefundAmount(selectedRequest), 2);//Rounding to two decimal places.

                if (chbxReceived.Checked)
                {
                    clsSQL.ReturnedOrdersCommand(returnID, orderID, inventoryID, personID, managerID, quantityReturned, refundAmount);
                }
                else
                {
                    lblErr.Visible = true;
                    return;
                }

                MessageBox.Show("Order has been refunded.");

                //Finding an instance of frmManagerView that is open to refresh the inventory
                foreach (Form form in Application.OpenForms)
                {
                    if (form is frmManagerView managerView)
                    {
                        managerView.RefreshInventoryProducts();//Updating the inventory 
                        managerView.clearInventory();//Clearing the inventory
                        break;
                    }
                }

                ResetForm();//Calling the method to reset the form
                RefreshRefundRequests();
            }
        }

        //Displays the return information about the selected return request including customer name, product, quantity, reason, and refund amount.
        //Enables controls for approving or canceling the return, and for marking the item as received.
        private void lbxReturnRequests_Click(object sender, EventArgs e)
        {
            //Getting the selected index
            int index = lbxReturnRequests.SelectedIndex;

            if (index >= 0 && index < returnRequests.Count)
            {
                lbxReturnRequests.Enabled = false;//Disabling the listBox

                string[] selectedRequest = returnRequests[index];//Getting the selected return from the returnRequests list
                string customerName = selectedRequest[4] + " " + selectedRequest[5];
                string productName = selectedRequest[6];
                string quantity = selectedRequest[8];
                string reason = selectedRequest[11];

                //Getting the refund amount
                decimal refundAmount = CalculateRefundAmount(selectedRequest);

                tbxCustName.Text = customerName;
                tbxProdName.Text = productName;
                tbxQuantity.Text = quantity;
                tbxReason.Text = reason;
                tbxRefundAmt.Text = refundAmount.ToString("C");
                tbxCustName.Enabled = true;
                tbxProdName.Enabled = true;
                tbxQuantity.Enabled = true;
                tbxReason.Enabled = true;
                tbxRefundAmt.Enabled = true;
                btnApproveReturn.Enabled = true;
                btnCancel.Enabled = true;
                chbxReceived.Enabled = true;
            }

        }

        /// <summary>
        /// Calculates the refund amount for a returned item, including any applied discounts and tax.
        /// </summary>
        /// <param name="returnData">An array of strings including return and product details, including price, quantity, discount info, and IDs.</param>
        /// <returns>The total refund amount including discounts and tax.</returns>
        /// <remarks>
        /// Applies item-level or cart-level discounts if applicable, ensures the refund is not negative,
        /// and includes a fixed tax rate of 8.25% in the final amount.
        /// </remarks>
        private decimal CalculateRefundAmount(string[] returnData)
        {
            decimal price = decimal.Parse(returnData[7]);//Price of the item
            int quantity = int.Parse(returnData[8]);//Quantity of the item

            decimal itemTotalPrice = price * quantity;//Total price of items
            decimal itemDiscountAmount = 0;
            decimal cartDiscountAmount = 0;
            bool cartDiscountApplied = false;

            decimal discountPercent = returnData[12] != "NULL" ? Convert.ToDecimal(returnData[12]) : 0;
            decimal discountDollar = returnData[13] != "NULL" ? Convert.ToDecimal(returnData[13]) : 0;
            string discountLevel = returnData[14];
            string returnInvID = returnData[2];
            string discountInvID = returnData[15] != null ? returnData[15].ToString() : "NULL";

            //Checking to see if a discount was applied, if not return the price with tax included
            if (discountLevel != "0" && discountLevel != "1")
            {
                // No valid discount level, return full price
                decimal taxAmount = itemTotalPrice * 0.0825m;
                return itemTotalPrice + taxAmount;
            }


            if (discountLevel == "1" && returnInvID == discountInvID)//Item Level Discount
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
            else if (discountLevel == "0" && !cartDiscountApplied)//CartLevel discount, applied once
            {
                if (discountPercent > 0)
                {
                    cartDiscountAmount = itemTotalPrice * discountPercent;
                }
                else if (discountDollar > 0)
                {
                    cartDiscountAmount = discountDollar;
                }

                cartDiscountApplied = true;//Setting to true, so the discount isnt applied more than once
            }

            //Calculation the refund amount
            decimal discountedTotal = itemTotalPrice - itemDiscountAmount - cartDiscountAmount;

            if (discountedTotal < 0)
            {
                discountedTotal = 0;
            }

            decimal tax = discountedTotal * 0.0825m;
            decimal refundAmount = discountedTotal + tax;

            return refundAmount;//Returning the refund amount
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();//Calling the method to reset the form
        }

        private void lblHelp_Click(object sender, EventArgs e)
        {
            //Showing the HTML Help files
            Help.ShowHelp(this, hlpReturnRequests.HelpNamespace);
        }
    }
}
