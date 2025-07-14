using System;
using System.Drawing;
using System.Windows.Forms;

namespace KJohnsonFinalProject
{
    public partial class frmAcctCreation : Form
    {
        public static bool managerLoggedIn;
        public frmAcctCreation()
        {
            InitializeComponent();
        }

        //Checks whether the form was opened by a manager or a new user during account creation
        private void frmAcctCreation_Load(object sender, EventArgs e)
        {
            //Checking to see if a manager is logged in
            if (frmLogin.managerLoggedIn == true)
            {
                managerLoggedIn = true;
                cbxPosition.Visible = true;
                lblPosition.Visible = true;
            }
            else
            {
                managerLoggedIn = false;
                cbxPosition.Visible = false;
                lblPosition.Visible = false;
            }

            fillComboBoxes();//Calling the Method to fill the combo boxes

        }

        //Populates ComboBoxes with predefined values for suffixes, states, and positionTitles.
        private void fillComboBoxes()
        {
            //String with the suffixes
            string[] suffix = { "Jr.", "Sr.", "I", "II", "III" };

            string[] position = { "Manager", "Customer", "Employee"};

            //String with all of the states
            string[] states = { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA",
            "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD",
            "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ",
            "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC",
            "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY",
            "AE", "AA", "AP"};

            cbxSuffix.Items.AddRange(suffix);//Adding suffixes to the comboBox
            cbxState.Items.AddRange(states);//Adding the states to the comboBox
            cbxPosition.Items.AddRange(position);//Adding the positions to the comboBox

            //Calling the Database Command Method to get the security questions
            clsSQL.DatabaseCommandSecurity(cbxSecurityQ1, cbxSecurityQ2, cbxSecurityQ3);
        }

        /// <summary>
        /// Handles the sumbission of the account creation form.
        /// Collects user input, validates the data, encrypts the password, and inserts the new user into the database.
        /// </summary>
        /// <remarks>
        /// If a Manager is logged in and opens this form, they can select the position for the new user.
        /// </remarks>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Getting the user data from the form and adding it to variables
            string username = tbxUsername.Text;
            string password1 = mTbxPass.Text;
            string title = tbxTitle.Text;
            string firstName = tbxFName.Text;
            string middleName = tbxMName.Text;
            string lastName = tbxLName.Text;
            string suffix = cbxSuffix.Text;
            string address1 = tbxAddress1.Text;
            string address2 = tbxAddress2.Text;
            string address3 = tbxAddress3.Text;
            string city = tbxCity.Text;
            string state = cbxState.Text;
            string zipcode = tbxZip.Text;
            string email = tbxEmail.Text;
            string phonePrimary = mTbxPhone1.Text;
            string phoneSecondary = mTbxPhone2.Text;
            string positionTitle = "";

            //If the manager is logged in, allow them to choose a position
            if (frmLogin.managerLoggedIn)
            {
                //Checking if the manager selected a position
                if (cbxPosition.SelectedItem != null)
                {
                    positionTitle = cbxPosition.SelectedItem.ToString();
                }
                else
                {
                    lblPosErr.Text = "Please select a position.";
                    return;
                }
            }
            else//If the user is not a manager, set the position to customer
            {
                positionTitle = "Customer";
            }

            //Security questions and answers
            string securityQuestion1 = cbxSecurityQ1.Text;
            string securityAnswer1 = tbxSecurityA1.Text;
            string securityQuestion2 = cbxSecurityQ2.Text;
            string securityAnswer2 = tbxSecurityA2.Text;
            string securityQuestion3 = cbxSecurityQ3.Text;
            string securityAnswer3 = tbxSecurityA3.Text;

            //Checking to see if the passwords match before validation
            if (mTbxPass.Text != mTbxPass2.Text)
            {
                MessageBox.Show("Passwords do not match", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            //Validating the Not Null fields are filled out, and ensuring that username, password, email, and zip code are filled out correctly
            if (!clsValidation.ValidateAcctCreationForm(username, password1, email, firstName, lastName, address1, city, state, zipcode, positionTitle, securityAnswer1, securityAnswer2, securityAnswer3))
            {
                return;
            }

            //Calling the Method to encrypt the password
            string encryptedPass = clsValidation.EncryptPass(password1);

            //Calling the method in the clsSQL class to insert data into the table 
            clsSQL.InsertUserData(username, encryptedPass, title, firstName, middleName, lastName, suffix,
                          address1, address2, address3, city, state, zipcode, email,
                          phonePrimary, phoneSecondary, positionTitle,
                          securityQuestion1, securityQuestion2, securityQuestion3, securityAnswer1, securityAnswer2, securityAnswer3);

            //Finding an instance of frmManagerView that is open to refresh the inventory
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmManagerAccounts managerAccounts)
                {
                    managerAccounts.loadManagersAccounts();
                    break;
                }

                if (form is frmCustomerAccounts customerAccounts)
                {
                    customerAccounts.loadCustomersAccounts();
                    break;
                }
            }

            this.Close();//Closing the account creation form
        }

        //Closes the account Creation form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();//Closing the Account creation Form
        }

        
        private void lblPeek1_Click(object sender, EventArgs e)
        {
            //Click between hiding and showing the password
            if (mTbxPass.PasswordChar == '*')
            {
                mTbxPass.PasswordChar = '\0';//Showing the password
            }
            else
            {
                mTbxPass.PasswordChar = '*';//Hiding the password 
            }
        }

        //A TextChanged event to check for validation for users Password
        private void mTbxPass_TextChanged(object sender, EventArgs e)
        {
            string validationText = clsValidation.ValidatePassword(mTbxPass.Text);

            if (validationText == "Valid")
            {
                lblPassCheck.Text = "Password meets specifications.";
                lblPassCheck.ForeColor = Color.Green;
            }
            else
            {
                lblPassCheck.Text = validationText;
                lblPassCheck.ForeColor = Color.Red;
            }
        }

        //Keypress event for the users password
        private void mTbxPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            //A method call to not allow certain keys to be pressed
            clsValidation.AllowedKeysPass(e);
        }

        //Validates the username
        private void tbxUsername_TextChanged(object sender, EventArgs e)
        {
            //Method to validate the username
            string validationText = clsValidation.ValidateUserName(tbxUsername.Text);

            if (validationText == "Valid")
            {
                lblPassCheck.Text = "Username meets specifications.";
                lblPassCheck.ForeColor = Color.Green;
            }
            else
            {
                lblPassCheck.Text = validationText;
                lblPassCheck.ForeColor = Color.Red;
            }
        }

        //Keypress event for the users username
        private void tbxUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            //A method call to not allow certain keys to be pressed
            clsValidation.AllowedKeysUser(e);
        }

        //Validates the users email
        private void tbxEmail_TextChanged(object sender, EventArgs e)
        {
            //Validating the email to make sure it is a valid email
            string validationText = clsValidation.ValidateEmail(tbxEmail.Text);

            //Updating the label to tell the user if the email they are entering is valid
            if (validationText == "Valid")
            {
                lblPassCheck.Text = "Email meets specifications.";
                lblPassCheck.ForeColor = Color.Green;
            }
            else
            {
                lblPassCheck.Text = validationText;
                lblPassCheck.ForeColor = Color.Red;
            }
        }

        //Keypress event for the users Zipcode
        private void tbxZip_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Allowing only numbers and one hyphen to be types
            clsValidation.AllowedKeysZip(e, tbxZip);
        }

        //Validates the users Zipcode
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

        //Validates the users second password entered to ensure it matches the first one entered
        private void mTbxPass2_TextChanged(object sender, EventArgs e)
        {
            //Checking if password 2 is valid and is the same as the first password
            string validationText = clsValidation.ValidatePassword(mTbxPass2.Text);

            if (validationText == "Valid")
            {
                lblPassCheck.Text = "Password meets specifications.";
                lblPassCheck.ForeColor = Color.Green;
            }
            else
            {
                lblPassCheck.Text = validationText;
                lblPassCheck.ForeColor = Color.Red;
            }

            //Checking to see if the passwords match
            if (mTbxPass.Text == mTbxPass2.Text)
            {
                lblPassCheck.Text = "Passwords match";
                lblPassCheck.ForeColor = Color.Green;
                mTbxPass.BackColor = Color.Green;
                mTbxPass2.BackColor = Color.Green;
            }
            else
            {
                lblPassCheck.Text = "Passwords do not match";
                lblPassCheck.ForeColor = Color.Red;
                mTbxPass.BackColor = Color.Red;
                mTbxPass2.BackColor = Color.Red;
            }
        }

        private void mTbxPass2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //A method call to not allow certain keys to be pressed
            clsValidation.AllowedKeysPass(e);
        }

        private void lblPeek2_Click(object sender, EventArgs e)
        {
            //Click between hiding and showing the password
            if (mTbxPass2.PasswordChar == '*')
            {
                mTbxPass2.PasswordChar = '\0';//Showing the password
            }
            else
            {
                mTbxPass2.PasswordChar = '*';//Hiding the password 
            }
        }

        private void lblCity_Click(object sender, EventArgs e)
        {

        }
    }
}
