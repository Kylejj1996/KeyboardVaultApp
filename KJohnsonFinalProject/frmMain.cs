using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace KJohnsonFinalProject
{
    public partial class frmLogin : Form
    {
        //Variables 
        public static bool customerLoggedIn = false;//Flag indicating if a customer is logged in.
        public static bool managerLoggedIn = false;//Flag indicating if a manager is logged in.
        public static Person loggedInPerson;//Stores the currently logged-in person.

        /// <summary>
        /// A list of <c>Inventory</c> objects holding all available products.
        /// </summary>
        /// <remarks>This list is used in <c>frmCustomerView</c> and <c>frmManagerView</c>.</remarks>
        public static List<Inventory> productsList;
        /// <summary>
        /// A list of <c>Categories</c> objects storing all product categories.
        /// </summary>
        /// <remarks>This list is used in <c>frmCustomerView</c> and <c>frmManagerView</c>.</remarks>
        public static List<Categories> categoryList = null;
        

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            clsSQL.EnsureDatabaseExists();//Calling the method to check if the database exists if not it creates it
            LoadInvData();//Calling the method to load the inventory data on seperate threads when loading the form
            tbxPassword.PasswordChar = '*'; 
        }

        /// <summary>
        /// Loads category and inventory data on separate threads during application startup.
        /// Populates the shared categoryList and productsList after threads complete.
        /// </summary>
        public void LoadInvData()
        {
            List<Categories> loadedCategories = null;
            List<Inventory> loadedInventory = null;

            //Creating a thread to load the categories
            Thread categoriesThread = new Thread(() =>
            {
                loadedCategories = clsSQL.CategoriesCommand();
            });

            //Creating a thread to load the inventory
            Thread inventoryThread = new Thread(() =>
            {
                loadedInventory = clsSQL.InventoryCommand();
            });

            //Starting both threads
            categoriesThread.Start();
            inventoryThread.Start();

            //Waiting for both threads to finish
            categoriesThread.Join();
            inventoryThread.Join();

            //Checking if the loadedCategories is filled before adding categories to the categoryLists
            if (loadedCategories != null)
            {
                categoryList = loadedCategories;//Adding the loaded categories to the list
            }

            //Checking if the loadedInventory is filled before adding inventory to the productsList
            if (loadedInventory != null)
            {
                productsList = loadedInventory;//Adding the loaded inventory to the products list
            }

        }

        //Displays the account creation form
        private void btnCreateAcct_Click(object sender, EventArgs e)
        {
            lblAcctErr.Text = "";//Clearing the error text
            frmAcctCreation frm = new frmAcctCreation();
            frm.ShowDialog();//Showing the Account Creation Form
        }

        /// <summary>
        /// Handles the login process when the Login button is clicked. 
        /// Validates input, checks user credentials, handles account restrictions,
        /// and opens the appropriate form based on user role.
        /// </summary>
        /// <remarks>
        /// If login is successful:
        /// <list type="bullet">
        /// <item><description>Stores the logged-in user's info in the <c>loggedInPerson</c> object.</description></item>
        /// <item><description>Checks for account restrictions like disabled or deleted accounts.</description></item>
        /// <item><description>Sets role-specific flags: (<c>managerLoggedIn</c>, <c>customerLoggedIn</c>).</description></item>
        /// <item><description>Launches the appropriate form based on <c>PositionTitle</c>.</description></item>
        /// </list>
        /// Displays relevant error messages if login fails or account is restricted.
        /// </remarks>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Variables to hold the username and password to be logged in
            string username = tbxUsername.Text.ToLower();
            string password = tbxPassword.Text;
            //Checking to see if the user entered a username and password
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter your username.");
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your password.");
                return;
            }

            //Calling the method to login the user
            Person person = clsSQL.LoginUser(username, password);

            //If the login fails, telling the user
            if (person == null)
            {
                MessageBox.Show("Invalid Username or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Checking if the account was disabled
            if (person.AccountDisabled)
            {
                lblAcctErr.Text = "Account has been disabled.";
                tbxUsername.Clear();
                tbxPassword.Clear();
                return;
            }

            //Checking if the account is deleted
            if (person.AccountDeleted)
            {
                lblAcctErr.Text = "Account has been deleted.";
                tbxUsername.Clear();
                tbxPassword.Clear();
                return;
            }

            loggedInPerson = person;

            //Switch to login the user to the correct form on the application
            switch (person.PositionTitle)
            {
                case "Manager":
                    managerLoggedIn = true;
                    frmManagerView.loggedInManager = person;
                    frmManagerView frmManager = new frmManagerView();
                    frmManager.ShowDialog();
                    tbxUsername.Clear();
                    tbxPassword.Clear();
                    break;

                case "Customer":
                    customerLoggedIn = true;
                    frmCustomerView frmCustomer = new frmCustomerView();
                    frmCustomer.ShowDialog();
                    tbxUsername.Text = "";
                    tbxPassword.Text = "";
                    break;

                default:
                    MessageBox.Show("Unknown role.");
                    break;
            }
        }

        //Displays the password reset form
        private void lblForgotPass_Click(object sender, EventArgs e)
        {
            frmPasswordReset frm = new frmPasswordReset();
            frm.ShowDialog();//Showing the Password Reset Fom
        }

        private void lblPeek_Click(object sender, EventArgs e)
        {
            //Click between hiding and showing the password
            if (tbxPassword.PasswordChar == '*')
            {
                tbxPassword.PasswordChar = '\0';//Showing the password
            }
            else
            {
                tbxPassword.PasswordChar = '*';//Hiding the password 
            }
        }

        //Displays the help files
        private void lblHelp_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, hlpLogonView.HelpNamespace);
        }

        /// <summary>
        /// Handles the click event for accessing the customer view. 
        /// Prompts the user to create an account if they want to make purchases.
        /// </summary>
        private void btnCustomerView_Click(object sender, EventArgs e)
        {
            //Setting is logged in to false
            customerLoggedIn = false;
            lblAcctErr.Text = "";//Clearing the error text
            DialogResult response;
            response = MessageBox.Show("You'll need an account to purchase products. Would you like to create one now?", "Account Required", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (response == DialogResult.Yes)
            {
                frmAcctCreation frmAcctCreation = new frmAcctCreation();
                frmAcctCreation.ShowDialog();
                return;
            }
            else
            {
                //Loading the customer view if the user does not want to create a account
                frmCustomerView frm = new frmCustomerView();
                frm.ShowDialog();
            }
        }

        private void tbxUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
