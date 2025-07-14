using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KJohnsonFinalProject
{
    internal class clsValidation
    {
        /// <summary>
        /// Validates all required fields for creating a new account. Ensures required information is filled in and correctly formatted,
        /// including username, password, email, and zip code. Displays warning messages for any invalid or missing data.
        /// </summary>
        /// <param name="username">The username for the account.</param>
        /// <param name="password1">The password for the account.</param>
        /// <param name="email">The user's email address.</param>
        /// <param name="firstName">The user's first name.</param>
        /// <param name="lastName">The user's last name.</param>
        /// <param name="address1">The user's primary address.</param>
        /// <param name="city">The user.s city.</param>
        /// <param name="state">The user's state.</param>
        /// <param name="zipcode">The user's zipcode.</param>
        /// <param name="positionTitle">The position title. (Customer or Manager)</param>
        /// <param name="securityAnswer1">The answer to the first security question.</param>
        /// <param name="securityAnswer2">The answer to the second security question.</param>
        /// <param name="securityAnswer3">The answer to the third security question.</param>
        /// <returns>Returns <c>true</c> if all of the validations pass; otherwise <c>false</c>.</returns>
        public static bool ValidateAcctCreationForm(string username, string password1, string email, string firstName, string lastName, string address1, string city, string state, string zipcode,
            string positionTitle, string securityAnswer1, string securityAnswer2, string securityAnswer3)
        {
            //Checking to see if the username is filled out
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter a username.", "Username Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Calling ValidateUserName to validate the username and storing the result in a string
            string usernameValidation = ValidateUserName(username);

            //Checking to see if the username is valid or not
            if (usernameValidation != "Valid")
            {
                MessageBox.Show(usernameValidation, "Username not Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Checking to see if the password is filled out
            if (string.IsNullOrWhiteSpace(password1))
            {
                MessageBox.Show("Please enter a password.", "Password Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Calling ValidatePassword to validate the password and storing the result in a string
            string pass1Validation = ValidatePassword(password1);

            //Checking to see if the password is valid or not
            if (pass1Validation != "Valid")
            {
                MessageBox.Show(pass1Validation, "Password not Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            //Checking to see if the email is filled out
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter a email.", "EmailMissing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Calling ValidateEmail to validate the email and storing the result in a string
            string emailValidation = ValidateEmail(email);

            //Checking to see if email is empty or filled out correctly
            if (emailValidation != "Valid")
            {
                MessageBox.Show(emailValidation, "Email not Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            

            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Please enter your First name", "First Name Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Please enter your Last name", "Last Name Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(address1))
            {
                MessageBox.Show("Please enter an Address", "Address Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(city))
            {
                MessageBox.Show("Please enter a City", "City Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(state))
            {
                MessageBox.Show("Please select a State", "State Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Checkign to see if the zip code is filled out
            if(string.IsNullOrWhiteSpace(zipcode))
            {
                MessageBox.Show("Please enter a vaild Zip Code", "Zip Code Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //Calling ValidateZip to validate the zipcode and storing the result in a string
            string zipValidation = ValidateZip(zipcode);

            //Checking to see if the zipCode is valid
            if (zipValidation != "Valid")
            {
                MessageBox.Show(zipValidation, "Zip Code is Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(positionTitle))
            {
                MessageBox.Show("Please select a Position", "Position not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(securityAnswer1))
            {
                MessageBox.Show("Please answer the first Security Question", "Security Answer Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(securityAnswer2))
            {
                MessageBox.Show("Please answer the second Security Question", "Security Answer Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(securityAnswer3))
            {
                MessageBox.Show("Please answer the third Security Question", "Security Answer Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the format of a U.S. zip code using a regular expression.
        /// Accepts 5 digit or 9 digit zip codes.
        /// </summary>
        /// <param name="zipcode">The zipcode string to validate.</param>
        /// <returns>
        /// Returns <c>"Valid"</c> if the zip code is in the correct format; otherwise, returns an error message indicating invalid input.
        /// </returns>
        public static string ValidateZip(string zipcode)
        {
            //Checking if the zipcode is filled out correctly using a RegularExpression
            string zipPattern = @"^\d{5}(-\d{4})?$";//Either 12345 or 12345-6789

            //Checking that the zipcode entered matches the pattern
            if (Regex.IsMatch(zipcode, zipPattern))
            {
                return "Valid";//Returning valid if the zipcode is filled out correctly
            }

            return "Please enter a valid zip code.";//Returning this string if the zipcode if filled out incorrectly
        }

        /// <summary>
        /// Validates the format of an email address.
        /// </summary>
        /// <param name="email">The email address string to validate.</param>
        /// <returns>
        /// Returns <c>"Valid"</c> if the email meets formatting requirements and length constraints; 
        /// otherwise, returns an error message indicating the issue.
        /// </returns>
        /// /// <remarks>
        /// The email must:
        /// <list type="bullet">
        /// <item><description>Start with an alphabetic character.</description></item>
        /// <item><description>Not contain consecutive periods (..).</description></item>
        /// <item><description>End with a valid domain: .com, .net, .org, .gov, or .edu.</description></item>
        /// </list>
        /// </remarks>
        public static string ValidateEmail(string email)
        {

            //Checking the max length 
            if (email.Length > 40)
            {
                return "Email cannot exceed 40 characters.";
            }

            //A regular expression to vaildate the email address the user enters
            string emailPattern = @"^[a-zA-Z](?!.*\.\.)[a-zA-Z0-9._-]*[a-zA-Z0-9]@[a-zA-Z]+(\.[a-zA-Z]+)*\.(com|net|org|gov|edu)$";


            //Checking if the email matches the pattern
            if (!Regex.IsMatch(email, emailPattern))
            {
                return "Please enter a valid email.";
            }

            return "Valid";
        }

        /// <summary>
        /// Validates the given username against specific formatting and uniqueness rules.
        /// </summary>
        /// <param name="userName">The username string to validate.</param>
        /// <returns>
        /// Returns <c>"Valid"</c> if the username meets all criteria; otherwise, returns a descriptive error message.
        /// </returns>
        /// <remarks>
        /// The username must meet the following criteria:
        /// <list type="bullet">
        /// <item><description>Must not contain spaces.</description></item>
        /// <item><description>Must be between 8 and 20 characters in length.</description></item>
        /// <item><description>Must not begin with a number.</description></item>
        /// <item><description>Must not contain special characters.</description></item>
        /// <item><description>Must be unique and not already used.</description></item>
        /// </list>
        /// The list of existing usernames is retrieved from the database via <c>clsSQL.DatabaseCommandLogon()</c>.
        /// </remarks>
        public static string ValidateUserName(string userName)
        {
            //List Variable hold existing LogonNames
            List<string> existingUsers = clsSQL.DatabaseCommandLogon();//Getting the list of existing Users

            //Checking if the Username contains spaces
            if (userName.Contains(" "))
            {
                return "No spaces allowed.";
            }

            //Checking if the logonName is less than 8 character and longer than 20 characters
            if (userName.Length < 8 || userName.Length > 20)
            {
                return "Username must be 8-20 characters.";
            }

            //Check if logonName starts with a number
            if (Char.IsDigit(userName[0]))
            {
                return "Username cannot begin with a number.";
            }

            //Checking if the LogonName contains special characters
            if (!Regex.IsMatch(userName, @"^[a-zA-Z0-9]*$"))
            {
                return "Username cannot contain special characters.";
            }

            //Checking if the LogonName is unique using the StringComparer.OrdinalIgnoreCase property
            if (existingUsers != null && existingUsers.Contains(userName, StringComparer.OrdinalIgnoreCase))
            {
                return "Username is already taken. Please choose another one.";
            }

            return "Valid";
        }

        /// <summary>
        /// Validates the password against specific formatting rules.
        /// </summary>
        /// <param name="password">The password string to validate.</param>
        /// <returns>
        /// Returns <c>"Valid"</c> if the password meets all requirements; otherwise, returns a specific error message.
        /// </returns>
        /// <remarks>
        /// The password must meet the following conditions:
        /// <list type="bullet">
        /// <item>Must not contain spaces.</item>
        /// <item>Must be between 8 and 20 characters.</item>
        /// <item>Must include at least three of the following character types: uppercase letters (A-Z), lowercase letters (a-z), digits (0-9), or special characters <c>()!@#$%^*</c>.</item>
        /// </list>
        /// </remarks>
        public static string ValidatePassword(string password)
        {
            //String holding the characters that are allowed
            string specialCharacter = "!@#$%^&*()";

            //Checking if the Password contains spaces
            if (password.Contains(" "))
            {
                return "No spaces allowed.";
            }

            //Checking if Password length is between 8 and 20 characters
            if (password.Length < 8 || password.Length > 20)
            {
                return "Password Must be 8-20 characters.";
            }

            //Checking if Password contains at least three of the four character types
            bool hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;
            int typesCount = 0;
            

            //Foreach loop to check each character in the password
            foreach (char c in password)
            {
                if (!hasUpper && char.IsUpper(c)) 
                { 
                    hasUpper = true; typesCount++;//Upper case
                }
                else if (!hasLower && char.IsLower(c)) 
                { 
                    hasLower = true; typesCount++;//Lower Case
                }
                else if (!hasDigit && char.IsDigit(c)) 
                { 
                    hasDigit = true; typesCount++;//Digits
                }
                else if (!hasSpecial && specialCharacter.Contains(c)) 
                { 
                    hasSpecial = true; typesCount++;//Special Character 
                }
                else if (!char.IsLetterOrDigit(c) && !specialCharacter.Contains(c))//Characters that are not allowed
                {
                    return $"Invalid character '{c}'. Use only !@#$%^&*()";
                }

                //Break out of the foreach if 3 are found
                if (typesCount >= 3) break;
            }

            //Checking to see if the user has at least 3 of the 4 types
            if (typesCount < 3)
            {
                return "Include 3 of the following: Uppercase, lowercase, digit, or a special character (!@#$%^&*()).";
            }

            return "Valid";
        }

        /// <summary>
        /// Handles key presses for a Zip Code input field, allowing only digits and backspace.
        /// Automatically inserts a hyphen after the fifth digit if one is not already present. 
        /// </summary>
        /// /// <remarks>
        /// This method restricts input to numeric characters (0-9) and backspace. When the user enters the
        /// sixth character, a hyphen is inserted automatically after the fifth character (e.g., 12345-6789).
        /// If a non-numeric key is pressed, the input is suppressed and a system beep is played.
        /// </remarks>
        public static void AllowedKeysZip(KeyPressEventArgs e, TextBox tbxZip)
        {
            //Allowing number 0-9 and backspace
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == 8 || char.IsControl(e.KeyChar)) 
            {
                //Checking if the text already has 5 digits and the user is entering the 6th digit
                if (tbxZip.Text.Length == 5 && !tbxZip.Text.Contains("-") && e.KeyChar != 8)
                {
                    //Inserting a hyphen after the 5th character 
                    tbxZip.Text += "-";
                    tbxZip.SelectionStart = tbxZip.Text.Length;//Move the cursor after the hyphen
                }
                e.Handled = false;//Allowing numbers and backspace
            }
            else
            {
                e.Handled = true;//Prevents from adding any other characters
                SystemSounds.Beep.Play();
            }
        }

        /// <summary>
        /// Restricts password input to valid characters: letters, digits, control keys, and select special characters.
        /// </summary>
        /// /// <remarks>
        /// This method allows only the following characters:
        /// <list type="bullet">
        /// <item><description>Uppercase and lowercase letters (A-Z, a-z)</description></item>
        /// <item><description>Digits (0-9)</description></item>
        /// <item><description>Control characters (e.g., backspace)</description></item>
        /// <item><description>Special characters: <c>()!@#$%^*</c></description></item>
        /// </list>
        /// Spaces and any other characters are blocked from being entered.
        /// </remarks>
        public static void AllowedKeysPass(KeyPressEventArgs e)
        {
            string strAllowedKeys = "()!@#$%^&*";

            //Checking if the key pressed is a letter, digit, control character, or an allowed special character
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsControl(e.KeyChar) || strAllowedKeys.Contains(e.KeyChar.ToString()))
            {
                e.Handled = false;//Allows the key press
            }
            else
            {
                e.Handled = true;//Blocks the key press
            }

            //If the space bar is pressed, block it and show an error message
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Restricts input by blocking the spacebar during a keypress event.
        /// </summary>
        /// <param name="e">The Key press event with data about the pressed key.</param>
        /// <remarks>
        /// Sets <c>e.Handled</c> to <c>true</c> if the spacebar is pressed, preventing the input from being accepted.
        /// This is used to restrict spaces when creating a username in the <c>frmAcctCreation</c>.
        /// </remarks>
        public static void AllowedKeysUser(KeyPressEventArgs e)
        {
            //If the space bar is pressed, block it and show an error message
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Encrypts the given password by shifting each character forward by 4 positions.
        /// </summary>
        /// <param name="password">The password to encrypt.</param>
        /// <returns>The encrypted password as a string.</returns>
        public static string EncryptPass(string password)
        {
            //Converting the password to an character array
            char[] characters = password.ToCharArray();

            for (int i = 0; i < characters.Length; i++)
            {
                characters[i] = (char)(characters[i] + 4);//Shifting each character by 4 positions
            }

            return new string(characters);//Returning the encrypted password as a string
        }

        /// <summary>
        /// Decrypts the given password by shifting each character backward by 4 positions.
        /// </summary>
        /// <param name="password">The password top decrypt.</param>
        /// <returns>The decrypted (original) password as a string.</returns>
        public static string DecryptPass(string password)
        {
            //Convering the encrypted password to a character array
            char[] characters = password.ToCharArray();

            for (int i = 0; i < characters.Length; i++)
            {
                characters[i] = (char)(characters[i] - 4);//Shifting each character back by 4 positions
            }

            return new string(characters);//Returning the decrypted password as a string
        }




        // ----- Customer View Validation -----

        /// <summary>
        /// Validates the format of a credit card number.
        /// </summary>
        /// <param name="ccNum">The credit card number as a string, expected in the format ####-####-####-####</param>
        /// <returns>
        /// Returns "Valid" if the credit card number matches the required format; otherwise,
        /// returns an error message indicating the format is invalid.
        /// </returns>
        public static string ValidateCC(string ccNum)
        {
            //Checking if the credit card number is filled out correctly using a RegularExpression
            string ccPattern = @"^\d{4}-\d{4}-\d{4}-\d{4}$";//####-####-####-####

            //Checking that the credit card number entered matches the pattern
            if (Regex.IsMatch(ccNum, ccPattern))
            {
                return "Valid";//Returning valid if the credit card number is filled out correctly
            }

            return "Please enter a valid Credit Card Number.";//Returning this string if the credit card number if filled out incorrectly
        }


        /// <summary>
        /// Handles key input for credit card number entry, allowing only digits and backspace,
        /// and auto-formats the input by inserting hyphens after every 4 digits.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="tbxCC"></param>
        /// /// <remarks>
        /// This method restricts input to digits and backspace, inserts hyphens automatically at
        /// positions 5, 10, and 15, and prevents input beyond 19 characters.
        /// Any invalid key press is blocked and a beep sound is played.
        /// </remarks>
        public static void AllowedKeysCC(KeyPressEventArgs e, TextBox tbxCC)
        {
            //Allowing numbers 0-9 and backspace
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == 8 || char.IsControl(e.KeyChar))
            {
                //Auto formatting the CC number
                if ((tbxCC.Text.Length == 4 || tbxCC.Text.Length == 9 || tbxCC.Text.Length == 14) && e.KeyChar != 8)
                {
                    //Inserting a hyphen after every 4 numbers 
                    tbxCC.Text += "-";
                    tbxCC.SelectionStart = tbxCC.Text.Length;//Move the cursor after the hyphen
                }

                //Checking if there are 19 characters
                if (tbxCC.Text.Length >= 19 && e.KeyChar != 8)
                {
                    e.Handled = true;
                    return;
                }

                e.Handled = false;//Allowing numbers and backspace
            }
            else
            {
                e.Handled = true;//Prevents from adding any other characters
                SystemSounds.Beep.Play();
            }
        }

        /// <summary>
        /// Handles key input for expiration date entry, allowing only digits and backspace,
        /// and auto-formats the input by inserting a slash (/) after the month digits.
        /// </summary>
        /// <param name="tbxExpDate">The textbox control where the expiration date is entered.</param>
        /// /// <remarks>
        /// This method restricts input to digits and backspace, inserts a slash automatically after
        /// the first two digits if not already present, and prevents input beyond 7 characters (MM/YYYY).
        /// Any invalid key press is blocked and a beep sound is played.
        /// </remarks>
        public static void AllowedKeysExpDate(KeyPressEventArgs e, TextBox tbxExpDate)
        {
            //Allowing numbers 0-9 and backspace
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == 8 || char.IsControl(e.KeyChar))
            {
                //Insert / after the first two digits 
                if (tbxExpDate.Text.Length == 2 && e.KeyChar != 8 && !tbxExpDate.Text.Contains("/"))
                {
                    tbxExpDate.Text += "/";
                    tbxExpDate.SelectionStart = tbxExpDate.Text.Length;
                }

                //Checking if there are 5
                if (tbxExpDate.Text.Length >= 7 && e.KeyChar != 8)
                {
                    e.Handled = true;
                    return;
                }

                e.Handled = false;//Allowing numbers and backspace
            }
            else
            {
                e.Handled = true;//Prevents from adding any other characters
                SystemSounds.Beep.Play();
            }
        }


        /// <summary>
        /// Validates the expiration date format and checks if the date is valid and not expired.
        /// </summary>
        /// <param name="expDate">The expiration date string in MM/YY or MM/YYYY format.</param>
        /// <returns>
        /// Returns "Valid" if the expiration date is correctly formatted, not expired, and not more than 5 years in the future; 
        /// otherwise, returns a specific error message indicating the problem.
        /// </returns>
        /// <remarks>
        /// The method:
        /// <list type="bullet">
        /// <item>Validates the format with a regular expression (MM/YY or MM/YYYY).</item>
        /// <item>Parses the month and year values.</item>
        /// <item>Converts 2-digit years to 4-digit years.</item>
        /// <item>Checks if the expiration date is in the past (card expired).</item>
        /// <item>Checks if the expiration date is more than 5 years in the future.</item>
        /// </list>
        /// </remarks>
        public static string ValidateExpDate(string expDate)
        {
            //Checking if the experation date is filled out correctly using a RegularExpression
            string expDatePattern = @"^(0[1-9]|1[0-2])\/(\d{2}|\d{4})$";//  MM/YY or MM/YYYY

            //Checking that the experation date entered matches the pattern
            if (!Regex.IsMatch(expDate, expDatePattern))
            {
                return "Please enter a valid expiration date";//Returning this string if the experation date is invalid
            }

            //Seperating the month and year
            string[] parts = expDate.Split('/');
            int enteredMonth = int.Parse(parts[0]);
            int enteredYear = int.Parse(parts[1]);

            //Getting the current year and month
            int currentYear4Digit = DateTime.Now.Year;
            int currentYear2Digit = currentYear4Digit % 100;//Last two digits of current year
            int currentMonth = DateTime.Now.Month;
            int maxValidYear = currentYear4Digit + 5;//Max valid year, 5 years

            //Converting the 2 digit year to a 4 digit year for checking
            if (enteredYear < 100)
            {
                enteredYear += 2000;
            }

            //Checking if the card is expired
            if (enteredYear < currentYear4Digit || (enteredYear == currentYear4Digit && enteredMonth < currentMonth))
            {
                return "Card is expired.";
            }

            //Checking if the card is too far in the future
            if (enteredYear > maxValidYear)
            {
                return "Invalid expiration date.";
            }

            return "Valid";
        }

        /// <summary>
        /// Handles key press events to restrict input to only numeric characters (0-9) and backspace,
        /// and limits the input length to a maximum of 3 digits for the CCV in <c>frmCheckout</c>.
        /// </summary>
        /// <param name="tbxCCV">The textbox control where the CCV is being entered.</param>
        public static void AllowedKeysCCV(KeyPressEventArgs e, TextBox tbxCCV)
        {
            //Allowing numbers 0-9 and backspace
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == 8 || char.IsControl(e.KeyChar))
            {
                //Checking if there are 3 digits
                if (tbxCCV.Text.Length >= 3 && e.KeyChar != 8)
                {
                    e.Handled = true; // Prevent any input beyond 3 digits
                    return;
                }

                e.Handled = false;//Allowing numbers and backspace
            }
            else
            {
                e.Handled = true;//Prevents from adding any other characters
                SystemSounds.Beep.Play();
            }
        }

        /// <summary>
        /// Validates that all required <c>frmCheckout</c> fields are filled out and formatted correctly.
        /// </summary>
        /// <param name="firstName">Customer's first name.</param>
        /// <param name="lastName">Customer's last name.</param>
        /// <param name="email">Customer's email address.</param>
        /// <param name="address1">Primary street address.</param>
        /// <param name="city">City of the address.</param>
        /// <param name="state">State of the address.</param>
        /// <param name="zipcode">Zip code of the address.</param>
        /// <param name="phone">Customer's phone number.</param>
        /// <param name="CCnum">Credit card number.</param>
        /// <param name="expDate">Credit card expiration date.</param>
        /// <param name="CCV">Credit card verification code.</param>
        /// <returns>Returns <c>true</c> if all fields are valid; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// Displays message boxes for missing or invalid input and prevents form submission until all validations pass.
        /// </remarks>
        public static bool ValidateCheckoutForm(string firstName, string lastName, string email, string address1, string city, string state, string zipcode,
            string phone, string CCnum, string expDate, string CCV)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Please enter your First name", "First Name Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Please enter your Last name", "Last Name Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Checking to see if the email is filled out
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter a email.", "EmailMissing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Calling ValidateEmail to validate the email and storing the result in a string
            string emailValidation = ValidateEmail(email);

            //Checking to see if email is empty or filled out correctly
            if (emailValidation != "Valid")
            {
                MessageBox.Show(emailValidation, "Email not Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(address1))
            {
                MessageBox.Show("Please enter an Address", "Address Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            

            if (string.IsNullOrWhiteSpace(city))
            {
                MessageBox.Show("Please enter a City", "City Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(state))
            {   
                MessageBox.Show("Please select a State", "State Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Checkign to see if the zip code is filled out
            if (string.IsNullOrWhiteSpace(zipcode))
            {
                MessageBox.Show("Please enter a vaild Zip Code", "Zip Code Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Calling ValidateZip to validate the zipcode and storing the result in a string
            string zipValidation = ValidateZip(zipcode);

            //Checking to see if the zipCode is valid
            if (zipValidation != "Valid")
            {
                MessageBox.Show(zipValidation, "Zip Code is Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Please enter a phone number", "Phone Number Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Creit Card Number
            if (string.IsNullOrWhiteSpace(CCnum))
            {
                MessageBox.Show("Please enter a valid Credit Card Number", "Credit Card Number Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Calling the ValidatCC to check if the CC is valid
            string ccValidation = ValidateCC(CCnum);

            if (ccValidation != "Valid")
            {
                MessageBox.Show(ccValidation, "Credit Card is Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Expiration Date
            if (string.IsNullOrWhiteSpace(expDate))
            {
                MessageBox.Show("Please enter a valid Expiration Date", "Expiration Date Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Calling the expDateValidation to check if the Expiration date is valid
            string expDateValidation = ValidateExpDate(expDate);

            if (expDateValidation != "Valid")
            {
                MessageBox.Show(expDateValidation, "Expiration Date is Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //CCV
            if (CCV == "" || CCV.Length < 3)
            {
                MessageBox.Show("Please enter a valid CCV", "CCV Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // ----- Manager View Validation -----

        /// <summary>
        /// Validates all required promo code fields in the <c>frmManagerView</c> form to ensure they are correctly filled out and formatted.
        /// </summary>
        /// <param name="promoCode">The promo code string.</param>
        /// <param name="description">Description of the promo code.</param>
        /// <param name="discountLevel">Indicates whether the discount applies to the cart or individual items.</param>
        /// <param name="discountType">An integer representing the discount type; expected values are 0 or 1.</param>
        /// <param name="endDate">The expiration date of the promo.</param>
        /// <returns>
        /// Returns "Valid" if all fields pass validation; otherwise, returns an error message describing the missing or invalid field.
        /// </returns>
        public static string ValidatePromo(string promoCode, string description, string discountLevel, int discountType, string endDate)
        {
            //Validating promo code 
            if (string.IsNullOrWhiteSpace(promoCode))
            {
                return "Please enter a promo code.";
            }

            //Validating the promo code
            if (string.IsNullOrWhiteSpace(description))
            {
                return "Please enter a description.";
            }

            if (string.IsNullOrWhiteSpace(discountLevel))
            {
                return "Please select Cart Level Discount or Item Level Discount.";
            }

            if (discountType != 0 && discountType != 1)
            {
                return "Please select Discount Type.";
            }

            if (string.IsNullOrWhiteSpace(endDate))
            {
                return "Please Enter a expiration date";
            }

            return "Valid";
        }

        /// <summary>
        /// Handles allowed key input for the expiration date field in <c>frmManagerView</c>, enforcing MM/DD/YYYY format.
        /// Automatically inserts slashes after the month and day segments during typing.
        /// </summary>
        /// <param name="tbxExpDate">The TextBox control for the expiration date input.</param>
        public static void AllowedKeysExpDatePromo(KeyPressEventArgs e, TextBox tbxExpDate)
        {
            //Allowing numbers 0-9, backspace, and control keys
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == 8 || char.IsControl(e.KeyChar))
            {
                //Formatting the expiration date
                if ((tbxExpDate.Text.Length == 2 || tbxExpDate.Text.Length == 5) && e.KeyChar != 8)
                {
                    //Inserting a slash after the 2nd and 5th digits
                    tbxExpDate.Text += "/";
                    tbxExpDate.SelectionStart = tbxExpDate.Text.Length;
                }


                //Preventing more than 10 characters (MM/DD/YYYY)
                if (tbxExpDate.Text.Length >= 10 && e.KeyChar != 8)
                {
                    e.Handled = true;
                    return;
                }

                e.Handled = false;
            }
            else
            {
                e.Handled = true; 
                SystemSounds.Beep.Play();  
            }
        }

        /// <summary>
        /// Validate whether the promo code already exists in the database.
        /// </summary>
        /// <param name="promoCode">The promo code string to validate.</param>
        /// <returns>
        /// Returns "Promo code already in use." if the promo code exists; otherwise, returns "Valid".
        /// </returns>
        public static string ValidatePromo(string promoCode)
        {
            //List Variable hold existing LogonNames
            List<Discounts> existingPromoCodes = clsSQL.DiscountCommandManager();//Getting the list of existing Users

            //Checking if the promoCode is used or if it is discontinued
            foreach (var code in existingPromoCodes)
            {
                if (code.DiscountCode.Equals(promoCode, StringComparison.OrdinalIgnoreCase))//Comparing the DiscountCodes with the entered promoCode
                {
                    return "Promo code already in use.";//Returning a message if the promo code exists and is not discontinued
                }
            }

            return "Valid";
        }

        /// <summary>
        /// Checks that the promo start or expiration date is in the correct format and occurs in an appropriate timeframe.
        /// </summary>
        /// <param name="date">The date string to validate.</param>
        /// <param name="isStartDate">True if validating a start date; false if validating an expiration date.</param>
        /// <param name="startDate">The start date string used to compare against expiration date.</param>
        /// <returns>
        /// Returns "Valid" if the date is properly formatted and logically valid; otherwise, returns a descriptive error message.
        /// </returns>
        public static string ValidatePromoDate(string date, bool isStartDate, string startDate = "")
        {
            //Regular expression to match MM/DD/YY format
            string datePattern = @"^(0[1-9]|1[0-2])\/(0[1-9]|[12][0-9]|3[01])\/\d{4}$";

            //Validating the date format
            if (Regex.IsMatch(date, datePattern))
            {
                //Parsing the date into a DateTime object
                string[] dateParts = date.Split('/');
                int month = int.Parse(dateParts[0]);
                int day = int.Parse(dateParts[1]);
                int year = int.Parse(dateParts[2]);

                //DateTime to hold the entered date
                DateTime enteredDate;
                enteredDate = new DateTime(year, month, day);//Creating the dateTime
           
                //If it is the start date, check if it's today or in the future
                if (isStartDate)
                {
                    if (enteredDate.Date < DateTime.Today)//Checking if the entered start date is the current date or in the future
                    {
                        return "Start date must be today or in the future.";
                    }
                }
                else
                {
                    //If there is a start date, checking if the expDate is after the startDate
                    if (!string.IsNullOrEmpty(startDate))
                    {
                        //Parsing the startDate into a DateTime object
                        string[] startDateParts = startDate.Split('/');
                        int startMonth = int.Parse(startDateParts[0]);
                        int startDay = int.Parse(startDateParts[1]);
                        int startYear = int.Parse(startDateParts[2]);

                        //DateTime to hold the entered date
                        DateTime startDates;
                       
                        startDates = new DateTime(startYear, startMonth, startDay);//Creating the dateTime

                        //Comparing the expiration date to the start date
                        if (enteredDate.Date <= startDates.Date)
                        {
                            return "Expiration date must be after the start date.";
                        }
                    }
                    else
                    {
                        //If there is no start date, checking if the expiration date is in the future
                        if (enteredDate.Date <= DateTime.Today)
                        {
                            return "Expiration date must be after the current date.";
                        }
                    }
                }

                return "Valid";//Telling the user the date is valid
            }
            else
            {
                return "Invalid date format. Please use MM/DD/YYYY.";
            }
        }


        /// <summary>
        /// Validates the inventory item details before adding it to the database.
        /// </summary>
        /// <param name="productName">The name of the product.</param>
        /// <param name="productDescription">The description of the product.</param>
        /// <param name="productCategory">The category the product belongs to.</param>
        /// <param name="productCost">The cost of the product.</param>
        /// <param name="productRetailPrice">The retail price of the product.</param>
        /// <param name="productStock">The current stock quantity of the product.</param>
        /// <param name="restockThreshold">The stock level at which the product should be restocked.</param>
        /// <param name="image">The image of the product as a byte array.</param>
        /// <returns>
        /// Returns <c>"Valid"</c> if all fields are properly filled; otherwise returns an error message indicating the missing or invalid field.
        /// </returns>
        public static string ValidateInventory(string productName, string productDescription, string productCategory, string productCost, string productRetailPrice,
            string productStock, string restockThreshold, byte[] image)
        {

            //Checking if the product name is empty
            if (string.IsNullOrWhiteSpace(productName))
            {
                return "Please enter a product name.";
            }

            //Checking if the product description is empty
            if (string.IsNullOrWhiteSpace(productDescription))
            {
                return "Please enter a product description.";
            }

            //Checking if the product category is selected
            if (string.IsNullOrWhiteSpace(productCategory))
            {
                return "Please select a product category.";
            }

            //Checking if the product cost is empty 
            if (string.IsNullOrWhiteSpace(productCost))
            {
                return "Please enter a product cost.";
            }

            //Checking if the retail price is empty
            if (string.IsNullOrWhiteSpace(productRetailPrice))
            {
                return "Please enter a retail price.";
            }

            //Checing if the stock quantity is empty
            if (string.IsNullOrWhiteSpace(productStock))
            {
                return "Please enter a stock quantity.";
            }

            //Checking if the restock threshold is empty
            if (string.IsNullOrWhiteSpace(restockThreshold))
            {
                return "Please enter a restock threshold.";
            }

            //Checking if the image is null or empty
            if (image == null || image.Length == 0)
            {
                return "Please provide an image for the product.";
            }

            return "Valid";
        }

        /// <summary>
        /// Handles key press events to restrict input in a price textbox.
        /// </summary>
        /// <param name="tbxPrice">The textbox control for entering the product price.</param>
        /// <remarks>
        /// Allows only numeric digits, a single leading dollar sign ('$'), a single decimal point,
        /// and backspace. Ensures the dollar sign is the first character, only one decimal point is allowed,
        /// and no more than two digits are allowed after the decimal point.
        /// Invalid characters are blocked and a beep sound is played.
        /// </remarks>
        public static void AllowedKeysProductPrice(KeyPressEventArgs e, TextBox tbxPrice)
        {
            //Allowing only numbers, backspace, $ and one decimal point
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)8 || e.KeyChar == '$' || e.KeyChar == '.')
            {
                //If the textbox is empty and the user is typing something other than a backspace
                if (tbxPrice.Text.Length == 0 && e.KeyChar != (char)8)
                {
                    //First character should be $
                    tbxPrice.Text = "$" + e.KeyChar;
                    tbxPrice.SelectionStart = tbxPrice.Text.Length;//Moving the cursor after the number
                    e.Handled = true;
                    return;
                }

                //If there's already a $, prevent the user from adding another one
                if (tbxPrice.Text.StartsWith("$") && e.KeyChar == '$')
                {
                    e.Handled = true;
                    return;
                }

                //Only allowing one decimal point
                if (e.KeyChar == '.' && tbxPrice.Text.Contains("."))
                {
                    e.Handled = true;//Preventing the user from entering more than one decimal point
                    return;
                }

                //Preventing more than two digits after the decimal point
                int decimalPointIndex = tbxPrice.Text.IndexOf('.');//Finding the position of decimal point
                if (decimalPointIndex != -1 && tbxPrice.Text.Length - decimalPointIndex > 2 && e.KeyChar != (char)8)
                {
                    e.Handled = true;//Prevents from adding more than 2 decimal places
                    return;
                }

                e.Handled = false;
            }
            else
            {
                //If a invalid character is entered, prevent input
                e.Handled = true;
                SystemSounds.Beep.Play();//Play a beep sound when an invalid character is entered
            }
        }

    }

}
