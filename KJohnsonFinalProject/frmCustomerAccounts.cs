using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace KJohnsonFinalProject
{
    public partial class frmCustomerAccounts : Form
    {
        /// <summary>
        /// A list of <c>Person</c> objects to store customers returned from a search.
        /// </summary>
        public static List<Person> searchedCustomersList;//List for the searched customers
        public frmCustomerAccounts()
        {
            InitializeComponent();
        }

        private void frmCustomerAccounts_Load(object sender, EventArgs e)
        {
            fillComboBoxes();//Calling the method to fill the comboBoxes
        }

        /// <summary>
        /// Reloads the customer accounts after changes have been made and submitted.
        /// Accounts are loaded on a separate thread, and the customerList is reloaded with the new data.
        /// </summary>
        public void loadCustomersAccounts()
        {
            string positionID = "1000";

            //Creating a thread to get the customers and fill the list
            Thread customerThread = new Thread(() =>
            {
                frmManagerView.customerList = clsSQL.PersonAccountsCommand(positionID);
            });

            //Starting the Thread
            customerThread.Start();
            customerThread.Join();

            lbxCustomers.Items.Clear();//Clearing the listBox
        }

        //Populates combo boxes with predefined values for suffixes, and states.
        private void fillComboBoxes()
        {
            //String with the suffixes
            string[] suffix = { "Jr.", "Sr.", "I", "II", "III" };

            //String with all of the states
            string[] states = { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA",
            "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD",
            "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ",
            "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC",
            "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY",
            "AE", "AA", "AP"};

            cbxSuffix.Items.AddRange(suffix);//Adding suffixes to the comboBox
            cbxState.Items.AddRange(states);//Adding the states to the comboBox
        }

        //Closes the Customer Accounts form
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();//Closing this form
        }

        //Populates the customer information fields with the selected customer's data and updates the UI.
        private void lbxCustomers_Click(object sender, EventArgs e)
        {

            //Checking if there is a selected item before continuing
            if (lbxCustomers.SelectedItem == null)
            {
                return;
            }

            btnRemoveCustomer.Visible = true;
            btnEditCustomerAcct.Visible = true;
            btnCancelEdit.Visible = true;   
            btnNewCustomer.Enabled = false;
            btnSearchCustomer.Enabled = false;
            tbxSearch.Enabled = false;

            int index = lbxCustomers.SelectedIndex;

            if (index >= 0 && index < searchedCustomersList.Count)
            {
                Person customer = searchedCustomersList[index];//Getting the selected customer from the List

                //Updating the groupBox text
                gbxCustomerInfo.Text = $"{customer.NameFirst} {customer.NameLast}'s Account Information";

                //Populating the fields with the customer data
                tbxTitle.Text = customer.Title;
                tbxFName.Text = customer.NameFirst;
                tbxMName.Text = customer.NameMiddle;
                tbxLName.Text = customer.NameLast;

                if (cbxSuffix.Items.Contains(customer.Suffix))
                {
                    cbxSuffix.SelectedItem = customer.Suffix;//Selecting the suffix from the comboBox
                }
                else
                {
                    cbxSuffix.SelectedIndex = -1;
                }

                tbxAddress1.Text = customer.Address1;
                tbxAddress2.Text = customer.Address2;
                tbxAddress3.Text = customer.Address3;
                tbxCity.Text = customer.City;

                if (cbxState.Items.Contains(customer.State))
                {
                    cbxState.SelectedItem = customer.State;//Selecting the state from the comboBox
                }
                else
                {
                    cbxState.SelectedIndex = -1;
                }

                tbxZip.Text = customer.Zipcode;
                tbxEmail.Text = customer.Email;
                mTbxPhone1.Text = customer.PhonePrimary;
                mTbxPhone2.Text = customer.PhoneSecondary;
                tbxUsername.Text = customer.LogonName;
                tbxPersonID.Text = customer.PersonID.ToString();

                //Checking if the account is disabled
                if (customer.AccountDisabled)
                {
                    chbxAcctDisabled.Checked = true;
                }
                else
                {
                    chbxAcctDisabled.Checked = false;
                }
            }
        }

        //Searches the customers list for matches based on the entered search text and displays the results in the listBox.
        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            //Getting the search text from the textbox
            string searchText = tbxSearch.Text.Trim().ToLower();

            lblSearcErr.Text = "";
            lblSubtitle.Visible = false;

            //Clearing the listbox
            lbxCustomers.Items.Clear();
            searchedCustomersList = new List<Person>();//Resetting the list for the search results

            if (!string.IsNullOrEmpty(searchText) && frmManagerView.customerList != null)
            {
                foreach (Person customer in frmManagerView.customerList)
                {
                    //Checking if the account is deleted
                    if (customer.AccountDeleted)
                    {
                        continue;
                    }

                 
                    //The different fields that can be searched
                    string fullName = $"{customer.NameFirst} {customer.NameLast}".ToLower();
                    string username = customer.LogonName.ToLower();
                    string email = customer.Email.ToLower();
                    string phone1 = customer.PhonePrimary.ToLower();
                    string phone2 = customer.PhoneSecondary.ToLower();

                    
                    //Checking if the searchText Matches anyone in the customers list
                    if (fullName.Contains(searchText) ||
                        username.Contains(searchText) ||
                        email.Contains(searchText) ||
                        phone1.Contains(searchText) ||
                        phone2.Contains(searchText))
                    {
                        //Adding the found customer to the list box
                        lbxCustomers.Items.Add($"{customer.NameFirst} {customer.NameLast}");//Adding the name to the listBox
                        searchedCustomersList.Add(customer);//Adding the customer to the searchedCustomersList

                        tbxSearch.Text = "";
                    }
                }

                //Checking if the results found anyone, if not displaying a error
                if (lbxCustomers.Items.Count == 0)
                {
                    lblSearcErr.Text = "No customers found.";
                    tbxSearch.Text = "";
                }
            }
            else
            {
                lblSearcErr.Text = "Please enter a name to search for.";
            }
        }

        //Clears and resets the form
        private void clearForm()
        {
            btnRemoveCustomer.Visible = false;
            btnEditCustomerAcct.Visible = false;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            gbxCustomerInfo.Enabled = false;
            btnCancelEdit.Visible = false;
            lblSubtitle.Visible = true;
            lbxCustomers.Enabled = true;
            btnSearchCustomer.Enabled = true;
            tbxSearch.Enabled = true;
            btnNewCustomer.Enabled = true;
            

            //Clearing the form controls
            lbxCustomers.ClearSelected();
            lbxCustomers.Items.Clear();
            gbxCustomerInfo.Text = "Customer Account Information";
            tbxTitle.Text = "";
            tbxFName.Text = "";
            tbxMName.Text = "";
            tbxLName.Text = "";
            cbxSuffix.SelectedIndex = -1;
            tbxAddress1.Text = "";
            tbxAddress2.Text = "";
            tbxAddress3.Text = "";
            tbxCity.Text = "";
            cbxState.SelectedIndex = -1;
            tbxZip.Text = "";
            tbxEmail.Text = "";
            mTbxPhone1.Text = "";
            mTbxPhone2.Text = "";
            tbxUsername.Text = "";
            lblValidation.Text = "";
        }

        //Retrieves the customer information from the form fields and returns it as a list of strings.
        private List<string> getCustomersFromTbx()
        {
            string title = tbxTitle.Text;
            string fName = tbxFName.Text;
            string mName = tbxMName.Text;
            string lName = tbxLName.Text;
            string suffix = cbxSuffix.Text;
            string address1 = tbxAddress1.Text;
            string address2 = tbxAddress2.Text;
            string address3 = tbxAddress3.Text;
            string city = tbxCity.Text;
            string state = cbxState.Text;
            string zip = tbxZip.Text;
            string email = tbxEmail.Text;
            string phone1 = mTbxPhone1.Text;
            string phone2 = mTbxPhone2.Text;
            string username = tbxUsername.Text;
            string personID = tbxPersonID.Text;
            string accountDisabled = "";

            if (chbxAcctDisabled.Checked)
            {
                accountDisabled = "1";
            }
            else
            {
                accountDisabled = "0";
            }

            //Returning all of the data
            return new List<string>
            {
                title, fName, mName, lName, suffix, address1, address2, address3, city, state, zip, email, phone1, phone2, username, personID, accountDisabled
            };
        }

        //Removes the selected customer's account and reloads the customer list.
        private void btnRemoveCustomer_Click(object sender, EventArgs e)
        {
            //Getting the manager info from the textBoxes
            List<string> customerInfo = getCustomersFromTbx();
            string type = "Remove";
            btnCancelEdit.Visible = false;
            clsSQL.PersonInfoCommand(customerInfo, type);
            clearForm();//Clearing the form after Disabling the customer
            loadCustomersAccounts();//Calling the method to load customers accounts after change
        }

        //Updates the selected customer's data in the database and reloads the customer list.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Getting the manager info from the textBoxes
            List<string> customerInfo = getCustomersFromTbx();
            string type = "Update";

            clsSQL.PersonInfoCommand(customerInfo, type);
            clearForm();//Clearing the form after Disabling the customer
            loadCustomersAccounts();//Calling the method to load customers accounts after change
        }

        //Enables editing mode for the selected customer's information and shows update and cancel buttons.
        private void btnEditCustomerAcct_Click(object sender, EventArgs e)
        {
            //Enabling the groupBox, making the buttons visible
            gbxCustomerInfo.Enabled = true;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            lbxCustomers.Enabled = false;
            btnSearchCustomer.Enabled = false;
            tbxSearch.Enabled = false;
            btnCancelEdit.Visible = false;
        }

        //Opens the account creation form as a dialog for adding a new customer.
        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            frmAcctCreation frmAcctCreation = new frmAcctCreation();
            frmAcctCreation.ShowDialog();//Takes the manager to the Account Creation form
        }
        
        //Clears the form and reloads the customer accounts list.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearForm();//Calling the method to clear the form
            loadCustomersAccounts();
        }

        //Validates the email entered
        private void tbxEmail_TextChanged(object sender, EventArgs e)
        {
            //Validating the email to make sure it is a valid email
            string validationText = clsValidation.ValidateEmail(tbxEmail.Text);

            //Updating the label to tell the user if the email they are entering is valid
            if (validationText == "Valid")
            {
                lblValidation.Text = "Email meets specifications.";
                lblValidation.ForeColor = Color.Green;
            }
            else
            {
                lblValidation.Text = validationText;
                lblValidation.ForeColor = Color.Red;
            }
        }

        //Validates the zipcode entered
        private void tbxZip_TextChanged(object sender, EventArgs e)
        {
            string validationText = clsValidation.ValidateZip(tbxZip.Text);
            //Checking if the zipcode is valid
            if (validationText == "Valid")
            {
                lblCheckMark.Text = "✔";
                lblCheckMark.ForeColor = Color.Green;
            }
            else
            {
                lblCheckMark.Text = "X";
                lblCheckMark.ForeColor = Color.Red;
            }
        }

        private void tbxZip_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Allowing only numbers and one hyphen to be types
            clsValidation.AllowedKeysZip(e, tbxZip);
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            clearForm();//Calling the method that clears the form
        }

        //Displays the help files 
        private void lblHelp_Click(object sender, EventArgs e)
        {
            //Showing the HTML Help files
            Help.ShowHelp(this, hlpCustomerAccts.HelpNamespace);
        }
    }
}
