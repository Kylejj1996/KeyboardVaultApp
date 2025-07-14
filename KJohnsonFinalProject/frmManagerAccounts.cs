using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace KJohnsonFinalProject
{
    public partial class frmManagerAccounts : Form
    {
        public static List<Person> searchedManagersList;//List to store the searched managers
        public frmManagerAccounts()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The form load event for the manager accounts form.
        /// If the current manager is editing their own account, updates the UI to disable the listBox and search controls and loads their details.
        /// Otherwise, loads all manager accounts and populates the comboBoxes for account management.
        /// </summary>
        private void frmManagerAccounts_Load(object sender, EventArgs e)
        {
            //Checking to see if the manager is editing their own account
            if (frmManagerView.managerAccountEdit == true)
            {
                lbxManagers.Visible = false;
                btnNewManager.Visible = false;
                btnRemoveManager.Visible = false;
                btnEditManagerAcct.Visible = false;
                btnCancel.Visible = false;
                btnSearchManager.Visible = false;
                tbxSearch.Visible = false;
                gbxManageAcctInfo.Enabled = true;
                btnUpdate.Visible = true;
                lblTitle.Text = "Keyboard Vault Account Details";
                lblSubtitle.Visible = false;
                chbxAcctDisabled.Visible = false;
                fillComboBoxes();//Calling the method to fill the comboBoxes
                loadManagersAccounts();//Calling the method to load the manager accounts
                loadLoggedInManager();//Calling the method to load the current managers details
            }
            else
            {
                loadManagersAccounts();//Calling the method to load manager accounts
                fillComboBoxes();//Calling the method to fill the comboBoxes
            }

        }

        /// <summary>
        /// Loads and displays the logged-in manager's account information into the form fields.
        /// Updates UI elements such as text boxes and combo boxes with the manager's personal and contact details.
        /// </summary>
        public void loadLoggedInManager()
        {

            //Checking if the loggedIn manager list if filled
            if (frmManagerView.loggedInManager != null)
            {
                //Updating the text on the group box
                gbxManageAcctInfo.Text = $"{frmManagerView.loggedInManager.NameFirst} {frmManagerView.loggedInManager.NameLast}'s Account Information";

                //Populating the fields with the manager data
                tbxTitle.Text = frmManagerView.loggedInManager.Title;
                tbxFName.Text = frmManagerView.loggedInManager.NameFirst;
                tbxMName.Text = frmManagerView.loggedInManager.NameMiddle;
                tbxLName.Text = frmManagerView.loggedInManager.NameLast;

                if (cbxSuffix.Items.Contains(frmManagerView.loggedInManager.Suffix))
                {
                    cbxSuffix.SelectedItem = frmManagerView.loggedInManager.Suffix;//Selecting the suffix from the comboBox
                }
                else
                {
                    cbxSuffix.SelectedIndex = -1;
                }

                tbxAddress1.Text = frmManagerView.loggedInManager.Address1;
                tbxAddress2.Text = frmManagerView.loggedInManager.Address2;
                tbxAddress3.Text = frmManagerView.loggedInManager.Address3;
                tbxCity.Text = frmManagerView.loggedInManager.City;

                if (cbxState.Items.Contains(frmManagerView.loggedInManager.State))
                {
                    cbxState.SelectedItem = frmManagerView.loggedInManager.State;//Selecting the state from the comboBox
                }
                else
                {
                    cbxState.SelectedIndex = -1;
                }

                tbxZip.Text = frmManagerView.loggedInManager.Zipcode;
                tbxEmail.Text = frmManagerView.loggedInManager.Email;
                mTbxPhone1.Text = frmManagerView.loggedInManager.PhonePrimary;
                mTbxPhone2.Text = frmManagerView.loggedInManager.PhoneSecondary;
                tbxUsername.Text = frmManagerView.loggedInManager.LogonName;
                tbxPersonID.Text = frmManagerView.loggedInManager.PersonID.ToString();
            }
        }

        /// <summary>
        /// Loads the manager accounts from the database on a separate thread and updates the managers list.
        /// Clears the current manager list before loading to ensure the list is refreshed after any changes.
        /// </summary>
        public void loadManagersAccounts()
        {
            string positionID = "1001";

            //Creating a thread to get the employees and fill the list
            Thread employeeThread = new Thread(() =>
            {
                frmManagerView.employeeList = clsSQL.PersonAccountsCommand(positionID);
            });

            //Starting the Thread
            employeeThread.Start();
            employeeThread.Join();//Wating for the thread to finish

            lbxManagers.Items.Clear();//Clearing the listBox
        }

        /// <summary>
        /// Populates combo boxes with predefined values for suffixes, and states.
        /// </summary>
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

        //Closes the Manager Accounts form
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();//Closing this form
        }

        /// <summary>
        /// Handles the click event for the managers list box.
        /// Populates the manager information fields with the selected manager's data and updates the UI.
        /// Enables editing and disables controls related to creating or searching managers while editing.
        /// </summary>
        private void lbxManagers_Click(object sender, EventArgs e)
        {
            //Checking if there is a selected item before continuing
            if(lbxManagers.SelectedItem == null)
            {
                return;
            }

            btnRemoveManager.Visible = true;
            btnCancelEdit.Visible = true;
            btnEditManagerAcct.Visible = true;
            btnNewManager.Enabled = false;
            btnSearchManager.Enabled = false;
            tbxSearch.Enabled = false;

            int index = lbxManagers.SelectedIndex;

            if(index >= 0 && index <searchedManagersList.Count)
            {
                Person manager = searchedManagersList[index];//Getting the selected manager from the list
            
                //Updating the text on the group box
                gbxManageAcctInfo.Text = $"{manager.NameFirst} {manager.NameLast}'s Account Information";

                //Populating the fields with the manager data
                tbxPositionID.Text = manager.PositionID.ToString();
                tbxPositionTitle.Text = manager.PositionTitle;
                tbxTitle.Text = manager.Title;
                tbxFName.Text = manager.NameFirst;
                tbxMName.Text = manager.NameMiddle;
                tbxLName.Text = manager.NameLast;

                if (cbxSuffix.Items.Contains(manager.Suffix))
                {
                    cbxSuffix.SelectedItem = manager.Suffix;//Selecting the suffix from the comboBox
                }
                else
                {
                    cbxSuffix.SelectedIndex = -1;
                }

                tbxAddress1.Text = manager.Address1;
                tbxAddress2.Text = manager.Address2;
                tbxAddress3.Text = manager.Address3;
                tbxCity.Text = manager.City;

                if (cbxState.Items.Contains(manager.State))
                {
                    cbxState.SelectedItem = manager.State;//Selecting the state from the comboBox
                }
                else
                {
                    cbxState.SelectedIndex = -1;
                }

                tbxZip.Text = manager.Zipcode;
                tbxEmail.Text = manager.Email;
                mTbxPhone1.Text = manager.PhonePrimary;
                mTbxPhone2.Text = manager.PhoneSecondary;
                tbxUsername.Text = manager.LogonName;
                tbxPersonID.Text = manager.PersonID.ToString();

                //Checking if the account is disabled
                if (manager.AccountDisabled)
                {
                    chbxAcctDisabled.Checked = true;
                }
                else
                {
                    chbxAcctDisabled.Checked = false;
                }

            }
        }

        /// <summary>
        /// Handles the click event for the search manager button.
        /// Searches the managers list for matches based on the entered search text and displays the results in the listBox.
        /// </summary>
        private void btnSearchManager_Click(object sender, EventArgs e)
        {
            //Getting the search text from the textbox
            string searchText = tbxSearch.Text.Trim().ToLower();

            lblSearcErr.Text = "";
            lblSubtitle.Visible = false;

            //Clearing the listbox
            lbxManagers.Items.Clear();
            searchedManagersList = new List<Person>();//Resetting the list for the search results

            if(!string.IsNullOrEmpty(searchText) && frmManagerView.employeeList != null)
            {
                foreach (Person manager in frmManagerView.employeeList)
                {
                    //Checking if the account is deleted
                    if (manager.AccountDeleted)
                    {
                        continue;
                    }

                    //The different fields that can be searched
                    string fullName = $"{manager.NameFirst} {manager.NameLast}".ToLower();
                    string username = manager.LogonName.ToLower();
                    string email = manager.Email.ToLower();
                    string phone1 = manager.PhonePrimary.ToLower();
                    string phone2 = manager.PhoneSecondary?.ToLower() ?? "";

                    //Checking if the searchText Matches anyone in the managers list
                    if (fullName.Contains(searchText) ||
                        username.Contains(searchText) ||
                        email.Contains(searchText) ||
                        phone1.Contains(searchText) ||
                        phone2.Contains(searchText))
                    {
                        //Adding the found manager to the list box
                        lbxManagers.Items.Add($"{manager.NameFirst} {manager.NameLast}");
                        searchedManagersList.Add(manager);//Adding the manager to the searchedCustomersList
                        tbxSearch.Text = "";
                    }
                }

                //Checking if the results found anyone, if not displaying a error
                if (lbxManagers.Items.Count == 0)
                {
                    lblSearcErr.Text = "No managers found.";
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
            //Making the buttons visible for editing an account
            btnRemoveManager.Visible = false;
            btnEditManagerAcct.Visible = false;
            btnRemoveManager.Enabled = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            gbxManageAcctInfo.Enabled = false;
            lblSubtitle.Visible = true;
            btnCancelEdit.Visible = false;
            lbxManagers.Enabled = true;
            btnSearchManager.Enabled = true;
            tbxSearch.Enabled = true;
            btnNewManager.Enabled = true;


            //Clearing the form controls
            lbxManagers.ClearSelected();
            lbxManagers.Items.Clear();
            gbxManageAcctInfo.Text = "Manager Account Information";
            tbxPositionID.Text = "";
            tbxPositionTitle.Text = "";
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

        /// <summary>
        /// Retrieves the manager information from the form fields and returns it as a list of strings.
        /// </summary>
        /// <returns>A list of strings containing the manager data from the form inputs.</returns>
        private List<string> getManagersFromTbx()
        {
            string positionID = tbxPositionID.Text;
            string positionTitle = tbxPositionTitle.Text;
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

        //Updates the logged-in manager's information if editing their own account,
        //or updates another manager's information accordingly.
        //Then refreshes the managers list and clears the form after updating.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Checking to see if the manager is editing their own account
            if (frmManagerView.managerAccountEdit == true)
            {
                //Updating the ManagerLoggedIn Object
                frmManagerView.loggedInManager.PositionID = int.Parse(tbxPositionID.Text);
                frmManagerView.loggedInManager.PositionTitle = tbxPositionTitle.Text;
                frmManagerView.loggedInManager.NameFirst = tbxFName.Text;
                frmManagerView.loggedInManager.NameLast = tbxLName.Text;
                frmManagerView.loggedInManager.Address1 = tbxAddress1.Text;
                frmManagerView.loggedInManager.Address2 = tbxAddress2.Text;
                frmManagerView.loggedInManager.Address3 = tbxAddress3.Text;
                frmManagerView.loggedInManager.City = tbxCity.Text;
                frmManagerView.loggedInManager.State = cbxState.Text;
                frmManagerView.loggedInManager.Zipcode = tbxZip.Text;
                frmManagerView.loggedInManager.Email = tbxEmail.Text;
                frmManagerView.loggedInManager.PhonePrimary = mTbxPhone1.Text;
                frmManagerView.loggedInManager.PersonID = int.Parse(tbxPersonID.Text);
                frmManagerView.loggedInManager.AccountDisabled = false;
                frmManagerView.loggedInManager.AccountDeleted = false;

                //Getting the manager info from the textBoxes
                List<string> managerInfo = getManagersFromTbx();
                string type = "Update";

                clsSQL.PersonInfoCommand(managerInfo, type);
                clearForm();//Clearing the form after Updating the manager
                loadManagersAccounts();//Calling the method to load managers accounts after change

            }
            else
            {
                //Getting the manager info from the textBoxes
                List<string> managerInfo = getManagersFromTbx();
                string type = "Update";

                clsSQL.PersonInfoCommand(managerInfo, type);
                clearForm();//Clearing the form after Updating the manager
                loadManagersAccounts();//Calling the method to load managers accounts after change
            }
    
        }

        //Removes the selected manager's account and reloads the manager list.
        private void btnRemoveManager_Click(object sender, EventArgs e)
        {
            //Getting the manager info from the textBoxes
            List<string> managerInfo = getManagersFromTbx();
            string type = "Remove";
            btnCancelEdit.Visible = false;
            clsSQL.PersonInfoCommand(managerInfo, type);
            clearForm();//Clearing the form after Removing the manager
            loadManagersAccounts();//Calling the method to load managers accounts after change
        }

        //Opens the account creation form to add a new manager.
        private void btnNewManager_Click(object sender, EventArgs e)
        {
            frmAcctCreation frmAcctCreation = new frmAcctCreation();
            frmAcctCreation.ShowDialog();//Takes the manager to the Account Creation form
        }

        //Clears the form and reloads the manager accounts list.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearForm();//Calling the method to clear the form
            loadManagersAccounts();
        }

        //Enables editing mode for the selected managers's information and shows update and cancel buttons.
        private void btnEditManagerAcct_Click(object sender, EventArgs e)
        {
            //Enabling the groupBox, making the buttons visible
            gbxManageAcctInfo.Enabled = true;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            lbxManagers.Enabled = false;
            btnSearchManager.Enabled = false;
            tbxSearch.Enabled = false;
            btnNewManager.Enabled = false;
            btnRemoveManager.Enabled = false;
            btnCancelEdit.Visible = false;
        }

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

        private void lblHelp_Click(object sender, EventArgs e)
        {
            //Showing the HTML Help files
            Help.ShowHelp(this, hlpManagerAccts.HelpNamespace);
        }

        private void tbxCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void mTbxPhone1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void cbxState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbxAddress3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxAddress2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxAddress1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxSuffix_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbxTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxFName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxMName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxLName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
