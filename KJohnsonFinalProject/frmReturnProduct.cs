using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace KJohnsonFinalProject
{
    public partial class frmReturnProduct : Form
    {
        //Global Variables
        StringBuilder html = new StringBuilder();//StringBuilder for the HTML
        List<string[]> purchases = new List<string[]>();
        string personID = "";
        string orderID = "";
        string inventoryID = "";
        private bool hasViewedPolicy = false;   

        public frmReturnProduct()
        {
            InitializeComponent();
        }

        //Initializes the form by setting the logged-in user information, loads the orders list, and populates the reasons comboBox.
        private void frmReturnProduct_Load(object sender, EventArgs e)
        {
            string loggedInPerson = "";

            //Getting the loggedIn Persons personID
            if (frmLogin.loggedInPerson != null)
            {
                loggedInPerson = frmLogin.loggedInPerson.NameFirst + "_" + frmLogin.loggedInPerson.NameLast;
                personID = frmLogin.loggedInPerson.PersonID.ToString();
            }

            refreshOrders();//Calling the method to add products available to be returned

            //String with all of the reason options
            string[] reasons = {"Defective or not working", "Wrong item received", "Keys are unresponsive or sticky", "Changed my mind",
                "Found a better price elsewhere", "Not as described", "Too noisy or loud", "Arrived late", "No longer need", "Accidental purchase", "Not compatible with my device"};

            cbxReason.Items.AddRange(reasons);//Adding reasons to the comboBox
        }

        //Refreshes the purchases list after a return request is submitted and populates the listBox with the updated data.
        private void refreshOrders()
        {
            //Getting the users purchases from the database
            purchases = clsSQL.getPurchases(personID);

            //Clearing the listbox before adding items
            lbxOrders.Items.Clear();

            //Looping through each order and adding them to the listbox
            foreach (string[] purchase in purchases)
            {
                //Formatted string
                string display = $"{purchase[3]} ({purchase[5]})";
                lbxOrders.Items.Add(display);
            }
        }

        //Disables the listBox, retrieves the selected purchase details, populates the product name textBox and quantity comboBox,
        //and enables the product info groupBox and cancel button.
        private void lbxOrders_Click(object sender, EventArgs e)
        {
            int index = lbxOrders.SelectedIndex;

            if (index >= 0 && index < purchases.Count)
            {
                lbxOrders.Enabled = false;//Disabling the list box

                string[] selectedPurchase = purchases[index];//Getting the selected purchase from the purchases list
                string productName = selectedPurchase[3];//The product name
                int maxQuantity = int.Parse(selectedPurchase[5]);//The product quantity
                orderID = selectedPurchase[0];//The orderID
                inventoryID = selectedPurchase[2];//The inventoryID

                //Adding the product Name to the textbox
                tbxProdName.Text = productName;

                cbxQuantity.Items.Clear();

                for (int i = 1; i <= maxQuantity; i++)
                {
                    //Adding the quantity to the cbxQuantity
                    cbxQuantity.Items.Add(i);
                }

                cbxQuantity.SelectedIndex = 0;
                gbxProductInfo.Enabled = true;
                btnCancel.Enabled = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Validates the quantity, reason, and return policy agreement has been viewed and checked. 
        //Adds the return to the ReturnRequests table
        private void btnSubmitReturn_Click(object sender, EventArgs e)
        {
            //Checking if the Quantity and Reason have been selected before submitting
            if (cbxQuantity.SelectedItem == null)
            {
                lblError.Text = "Please select a quantity before submitting.";
                return;
            }
            else if (cbxReason.SelectedItem == null)
            {
                lblError.Text = "Please select a reason before submitting.";
                return;
            }
            else if (!hasViewedPolicy && !chbxAgree.Checked)
            {
                lblError.Text = "Please review the return policy and agree to the terms.";
                return;
            }

            int quantity = int.Parse(cbxQuantity.SelectedItem.ToString());
            string reason = cbxReason.SelectedItem.ToString();

            //Converting the string IDs to int
            int parsedOrderID = int.Parse(orderID);
            int parsedInventoryID = int.Parse(inventoryID);
            int parsedPersonID = int.Parse(personID);

            //Submit the return request
            clsSQL.ReturnRequest(parsedOrderID, parsedInventoryID, parsedPersonID, quantity, reason);

            MessageBox.Show("Return request submitted successfully.");
            CreateShippingLabel();//Calling the method to create the shipping label
            ResetForm();//Calling the method to reset the form and disabled the controls
            refreshOrders();//Calling the method to refresh the orders
        }

        //Resets the Form
        private void ResetForm()
        {
            tbxProdName.Text = "";
            cbxQuantity.Items.Clear();
            lbxOrders.Enabled = true;
            lbxOrders.ClearSelected();
            gbxProductInfo.Enabled = false;
            cbxReason.SelectedIndex = -1;
            chbxAgree.Checked = false;
            hasViewedPolicy = false;
            btnCancel.Enabled = false;
            lblError.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();//Calling the method to reset the form and disabled the controls
        }

        private void lblHelp_Click(object sender, EventArgs e)
        {
            //Showing the HTML Help files
            Help.ShowHelp(this, hlpReturnProducts.HelpNamespace);
        }

        //Displays the return information in a messageBox and marks the return policy as viewed.
        private void lblReturnPolicy_Click(object sender, EventArgs e)
        {
            //String to hold the return policy
            string policy = "Return Policy:\n\n " +
                "- Returns must be initiated within 14 days of the original purchase date.\n" +
                "- Items must be returned in their original condition and packaging.\n " +
                "- Refunds will be issued by a manager upon receiving the product.\n " +
                "- Shipping fees are non-refundable.\n\n " +
                "Please use the provided shipping label for your return.";
            
            //Displaying the Return Policy
            MessageBox.Show(policy, "Return Policy", MessageBoxButtons.OK, MessageBoxIcon.Information);
            hasViewedPolicy = true;
        }

        private void chbxAgree_CheckedChanged(object sender, EventArgs e)
        {
            //Checking if the user has viewed the return policy
            if (!hasViewedPolicy)
            {
                lblError.Text = "You must view the Return Policy before agreeing!";
                chbxAgree.Checked = false;
            }
            else if (chbxAgree.Checked)
            {
                lblError.Text = "";
            }

        }

        private void chbxAgree_CheckStateChanged(object sender, EventArgs e)
        {
            lblError.Text = "";
        }

        //Creates an HTML shipping label for returning a product.
        private void CreateShippingLabel()
        {
            //Get the persons info directly from the loggedInPerson object
            string fullName = frmLogin.loggedInPerson.NameFirst + " " + frmLogin.loggedInPerson.NameLast;
            string address1 = frmLogin.loggedInPerson.Address1;
            string address2 = frmLogin.loggedInPerson.Address2;
            string address3 = frmLogin.loggedInPerson.Address3;
            string city = frmLogin.loggedInPerson.City;
            string state = frmLogin.loggedInPerson.State;
            string zip = frmLogin.loggedInPerson.Zipcode;

            //Creating the HTML
            html.AppendLine("<style>");
            html.AppendLine("body {font-family: Arial, sans-serif; margin: 20px;}");
            html.AppendLine(".label {width: 400px; border: 2px solid #000; padding: 20px;}");
            html.AppendLine(".top {display: flex; align-items: center; margin-bottom: 10px;}");
            html.AppendLine(".p-box {font-size: 48px; font-weight: bold; border: 1px solid #000; width: 50px; height: 50px; text-align: center; line-height: 50px;}");
            html.AppendLine(".usps-header {font-size: 20px; font-weight: bold; margin-left: 10px;}");
            html.AppendLine(".section {margin-bottom: 10px;}");
            html.AppendLine("hr {border: none; border-top: 2px solid #000;}");
            html.AppendLine(".barcode {font-family: 'Courier New', monospace; font-size: 20px; text-align: center; margin-top: 10px;}");
            html.AppendLine(".footer {font-size: 12px; text-align: center; margin-top: 10px;}");
            html.AppendLine("</style>");
            html.AppendLine("<html><body>");
            html.AppendLine("<div class='label'>");
            html.AppendLine("<div class='top'>");
            html.AppendLine("<div class='p-box'>P</div>");
            html.AppendLine("<div class='usps-header'>USPS PRIORITY MAIL</div>");
            html.AppendLine("</div>");
            html.AppendLine("<hr>");

            //Sender Address
            html.AppendLine("<div class='section'><strong>Sender:</strong><br>");
            html.AppendLine($"{fullName}<br>");
            html.AppendLine($"{address1}<br>");
            if (!string.IsNullOrWhiteSpace(address2)) html.AppendLine($"{address2}<br>");
            html.AppendLine($"{city}, {state}, {zip}</div>");
            html.AppendLine("<hr>");

            //Company Address
            html.AppendLine("<div class='section'><strong>SHIP TO:</strong><br>");
            html.AppendLine("Keyboard Vault<br>");
            html.AppendLine("2868 N. Main St.<br>");
            html.AppendLine("Dallas, TX 78955</div>");
            html.AppendLine("<hr>");

            //Barcode & Footer
            html.AppendLine("<div class='section'><strong>USPS DELIVERY CONFIRMATION</strong></div>");

            //Creating a random barcode number
            Random rnd = new Random();
            string barcode = "";

            //Looping through 5 times to create a barcode number
            for (int i = 0; i < 5; i++)
            {
                //Generating a random number
                barcode += rnd.Next(1000, 9999).ToString();

                //Adding a space between each set of numbers
                if (i < 4)
                {
                    barcode += " ";
                }
            }

            html.AppendLine($"<div class='barcode'>{barcode}</div>");
            html.AppendLine("<div class='footer'>Electronic Rate Approved #839292929</div>");
            html.AppendLine("</div></body></html>");

            string time = DateTime.Now.ToString("MM-dd-yy HH-mm-ss");
            string fileName = $"Return_Label_{orderID}_{time}.html";

            //Creating the filepath using the fileName and formattedDate to save the HTML document
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);

            //Writing the html to a file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(html);
            }

            //Opening the Receipt in the web browser
            System.Diagnostics.Process.Start(filePath);
        }
    }
}
