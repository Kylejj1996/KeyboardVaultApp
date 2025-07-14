using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KJohnsonFinalProject
{
    public partial class frmPasswordReset : Form
    {
        public frmPasswordReset()
        {
            InitializeComponent();
        }
        //Global Variables
        string username;
        string answer1;
        string answer2;
        string answer3;

        /// <summary>
        /// Handles the click event for the "Find" button.
        /// Retrieves security questions for the entered username and displays them.
        /// </summary>
        /// <remarks>
        /// If the username is not found or an error occurs during retrieval, displays an appropriate error message.
        /// On success, disables username input and enables the security questions group box.
        /// </remarks>
        private void btnFind_Click(object sender, EventArgs e)
        {
            //Setting the username and email to be checked
            username = tbxUsername.Text.ToLower();

            //List of strings to hold the security questions
            List<string> questions = clsSQL.ResetPassword(username);

            if (questions.Count == 1 && questions[0] == "User not found.")
            {
                MessageBox.Show("User was not found.", "User not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (questions.Count == 1 && questions[0] == "Error retrieving security questions.")
            {
                MessageBox.Show("Error retrieving security questions.", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Disabling the username text box and find button
                tbxUsername.Enabled = false;
                btnFind.Enabled = false;
                //Setting the Security groupBox to visible
                gbxSecurity.Visible = true;

                lblQ1.Text = questions[0];
                lblQ2.Text = questions[2];
                lblQ3.Text = questions[4];

                //Store the answers in variables to be validated
                answer1 = questions[1].ToLower();
                answer2 = questions[3].ToLower();
                answer3 = questions[5].ToLower();
            }
        }

        /// <summary>
        /// Handles the click event for the submit button.
        /// Validates the user's answers to security questions and enables password reset controls if answers are correct.
        /// </summary>
        /// <remarks>
        /// Displays warning messages if any answer is blank.
        /// Shows an error and clears inputs if any answer is incorrect.
        /// If validation is successful, disables question inputs and enables password reset UI elements.
        /// </remarks>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Making the answer lowercase so that it can check if the information is the same
            string userAnswer1 = tbxQA1.Text.ToLower();
            string userAnswer2 = tbxQA2.Text.ToLower();
            string userAnswer3 = tbxQA3.Text.ToLower();
            //Checking to see if the user filled out the textBoxes
            if (string.IsNullOrWhiteSpace(userAnswer1))
            {
                MessageBox.Show("Please answer the first security question.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(userAnswer2))
            {
                MessageBox.Show("Please answer the second security question.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(userAnswer3))
            {
                MessageBox.Show("Please answer the third security question.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Checking to see if the user gets one of the questions incorrect
            if (userAnswer1 != answer1.ToLower() || userAnswer2 != answer2.ToLower() || userAnswer3 != answer3.ToLower())
            
            {
                MessageBox.Show("One of the questions is incorrect. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbxQA1.Text = "";
                tbxQA2.Text = "";
                tbxQA3.Text = "";
                return;
            }

            //If the user answers all of the questions correct
            if (userAnswer1 == answer1 && userAnswer2 == answer2 && userAnswer3 == answer3)
            {
                //Disabling the textboxes and buttons
                tbxQA1.Enabled = false;
                tbxQA2.Enabled = false;
                tbxQA3.Enabled = false;
                btnSubmit.Enabled = false;

                //Setting the Password Reset Group Box to visible
                gbxPassReset.Visible = true;

                //Setting the Textboxes to enabled
                mTbxPass1.Visible = true;
                mTbxPass2.Visible = true;
                btnReset.Visible = true;
            }
        }

        /// <summary>
        /// Handles the click event for the Reset button.
        /// Attempts to update the user's password in the database with the new password entered.
        /// Displays success or error messages based on the update result, and closes the form on success.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            //Strings to hold the new password, entered twice
            string password1 = mTbxPass1.Text;
            string password2 = mTbxPass2.Text;

            //Updating the password in the database
            bool isUpdated = clsSQL.UpdatePassword(username, password1);

            if (isUpdated)
            {
                MessageBox.Show("Password successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                mTbxPass1.Clear();
                mTbxPass2.Clear();

                this.Close();//Closing the password Reset form
            }
            else
            {
                MessageBox.Show("Failed to update password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmPasswordReset_Load(object sender, EventArgs e)
        {
            
        }

        //Validates the entered password using the ValidatePassword() method and updates the validation label and textbox color accordingly.
        //It also checks if the first and second passwords match, enabling or disabling the reset button.
        private void mTbxPass1_TextChanged(object sender, EventArgs e)
        {
            //Checking if the password meets specifications
            string validationText = clsValidation.ValidatePassword(mTbxPass1.Text);

            //If it is valid, updating the label to tell the user
            if (validationText == "Valid")
            {
                lblPassValid.Text = "Password meets specifications.";
                lblPassValid.ForeColor = Color.Green;
                mTbxPass1.BackColor = Color.Green;
            }
            else
            {
                lblPassValid.Text = validationText;
                lblPassValid.ForeColor = Color.Red;
                mTbxPass1.BackColor = Color.Red;
            }

            //Checking to see if the passwords match
            if (mTbxPass2.Text == mTbxPass1.Text)
            {
                lblPassMatch.Text = "Passwords match.";
                lblPassMatch.ForeColor = Color.Green;
                btnReset.Enabled = true;
            }
            else
            {
                lblPassMatch.Text = "Passwords do not match.";
                lblPassMatch.ForeColor = Color.Red;
                btnReset.Enabled = false;
            }
        }

        //Validates the entered password using the ValidatePassword() method and updates the validation label and textbox color accordingly.
        //It also checks if the first and second passwords match, enabling or disabling the reset button.
        private void mTbxPass2_TextChanged(object sender, EventArgs e)
        {
            //Checking if the password meets specifications
            string validationText = clsValidation.ValidatePassword(mTbxPass2.Text);

            //If it is valid, updating the label to tell the user
            if (validationText == "Valid")
            {
                lblPassValid.Text = "Password meets specifications.";
                lblPassValid.ForeColor = Color.Green;
                mTbxPass2.BackColor = Color.Green;
            }
            else
            {
                lblPassValid.Text = validationText;
                lblPassValid.ForeColor = Color.Red;
                mTbxPass2.BackColor = Color.Red;
            }

            //Checking to see if the passwords match
            if (mTbxPass1.Text == mTbxPass2.Text)
            {
                lblPassMatch.Text = "Passwords match.";
                lblPassMatch.ForeColor = Color.Green;
                btnReset.Enabled = true;
            }
            else
            {
                lblPassMatch.Text = "Passwords do not match.";
                lblPassMatch.ForeColor = Color.Red;
                btnReset.Enabled = false;
            }
        }

        private void mTbxPass1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //A method call to not allow certain keys to be pressed
            clsValidation.AllowedKeysPass(e);
        }

        private void mTbxPass2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //A method call to not allow certain keys to be pressed
            clsValidation.AllowedKeysPass(e);
        }

        private void lblPeek1_Click(object sender, EventArgs e)
        {
            //Click between hiding and showing the password
            if (mTbxPass1.PasswordChar == '*')
            {
                mTbxPass1.PasswordChar = '\0';//Showing the password
            }
            else
            {
                mTbxPass1.PasswordChar = '*';//Hiding the password 
            }
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
    }
}
