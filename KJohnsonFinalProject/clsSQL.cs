using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using Dapper;
using System.Linq;
using System.IO;

namespace KJohnsonFinalProject
{
    internal class clsSQL
    {
        /// <summary>
        /// Loads the connection string used to access the Keyboard Vault SQLite local database.
        /// The database is located in the user's AppData\Roaming\KeyboardVault directory.
        /// </summary>
        /// <returns>A connection string for the SQLite database.</returns> 
        public static string LoadConnectionString()
        {
            string dbName = "KeyboardVaultDB.db";//The name of the database file

            //Getting the path to the AppData/Roaming/KeyboardVault Folder
            string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "KeyboardVault");

            //Combining the folder path with the database file name
            string fullPath = Path.Combine(appDataPath, dbName);

            //Returning the connection string that points to the database located in the AppData
            return $"Data Source={fullPath};Version=3;";
        }


        /// <summary>
        /// Ensures that the Keyboard Vault database exists in the user's AppData\Roaming\KeyboardVault folder.
        /// If the database is not found in that location, a writable copy of the read-only installed version is copied there
        /// when the application loads.
        /// </summary>
        public static void EnsureDatabaseExists()
        {
            string dbName = "KeyboardVaultDB.db";//The name of the database file

            //Path to AppData\Roaming\KeyboardVault folder to store a writable copy
            string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "KeyboardVault");

            //The full path to where the database will be copied to
            string fullPath = Path.Combine(appDataPath, dbName);

            //Path to the original installed Database that is read only
            string installedDbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dbName);

            //Creating the Keyboard Vault folder if it doesn't exist
            Directory.CreateDirectory(appDataPath);

            //Only copy the database if it isn't already created in the AppData
            if (!File.Exists(fullPath))
            {
                //Checking if the installed database exists
                if (File.Exists(installedDbPath))
                {
                    //Copying the file to AppData so that it can be written to 
                    File.Copy(installedDbPath, fullPath);
                }
            }
        }

        //                              ----Logon View SQL----
        /// <summary>
        /// Retrieves security questions from the database and binds them to the three ComboBoxes for user selection.
        /// Each ComboBox is assigned questions from a different set (SetID 1, 2, and 3).
        /// </summary>
        /// <param name="cbxSecurityQ1">ComboBox for the first security question set.</param>
        /// <param name="cbxSecurityQ2">ComboBox for the second security question set.</param>
        /// <param name="cbxSecurityQ3">ComboBox for the third security question set.</param>
        public static void DatabaseCommandSecurity(ComboBox cbxSecurityQ1, ComboBox cbxSecurityQ2, ComboBox cbxSecurityQ3)
        {
            try
            {
                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Query to get the questions from the database
                    var questions = cnn.Query("SELECT QuestionID, SetID, QuestionPrompt FROM SecurityQuestions").ToList();

                    //Filtering and binding the security questions for the first comboBox
                    cbxSecurityQ1.DataSource = questions.Where(q => q.SetID == 1).ToList();
                    cbxSecurityQ1.DisplayMember = "QuestionPrompt";//Setting the text displayed in the comboxBox
                    cbxSecurityQ1.ValueMember = "QuestionID";//The ID value associated with each item

                    //Filtering and binding the security questions for the Second comboBox
                    cbxSecurityQ2.DataSource = questions.Where(q => q.SetID == 2).ToList();
                    cbxSecurityQ2.DisplayMember = "QuestionPrompt";//Setting the text displayed in the comboxBox
                    cbxSecurityQ2.ValueMember = "QuestionID";//The ID value associated with each item

                    //Filtering and binding the security questions for the third comboBox
                    cbxSecurityQ3.DataSource = questions.Where(q => q.SetID == 3).ToList();
                    cbxSecurityQ3.DisplayMember = "QuestionPrompt";//Setting the text displayed in the comboxBox
                    cbxSecurityQ3.ValueMember = "QuestionID";//The ID value associated with each item
                }

            }

            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Error Loading Security Questions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Inserts a new user into the database by adding records to the Position, Person, and Logon tables.
        /// </summary>
        /// <param name="username">The logon username for the new user.</param>
        /// <param name="password">The password for the new user.</param>
        /// <param name="title">The user's title (e.g., Mr., Ms.).</param>
        /// <param name="firstName">The user's first name.</param>
        /// <param name="middleName">The user's middle name.</param>
        /// <param name="lastName">The user's last name.</param>
        /// <param name="suffix">The user's name suffix (e.g., Jr., Sr.).</param>
        /// <param name="address1">Primary street address.</param>
        /// <param name="address2">Secondary street address.</param>
        /// <param name="address3">Third optional address.</param>
        /// <param name="city">City of residence.</param>
        /// <param name="state">State of residence.</param>
        /// <param name="zip">ZIP code.</param>
        /// <param name="email">Email address.</param>
        /// <param name="phonePrimary">Primary phone number.</param>
        /// <param name="phoneSecondary">Secondary phone number.</param>
        /// <param name="position">User's job position/title.</param>
        /// <param name="securityQ1">Text of first security question.</param>
        /// <param name="securityQ2">Text of second security question.</param>
        /// <param name="securityQ3">Text of third security question.</param>
        /// <param name="securityA1">Answer to the first security question.</param>
        /// <param name="securityA2">Answer to the second security question.</param>
        /// <param name="securityA3">Answer to the third security question.</param>
        public static void InsertUserData(string username, string password, string title, string firstName, string middleName, string lastName,
                                  string suffix, string address1, string address2, string address3, string city,
                                  string state, string zip, string email, string phonePrimary,
                                  string phoneSecondary, string position, string securityQ1, string securityQ2,
                                  string securityQ3, string securityA1, string securityA2, string securityA3)
        {
            
            try
            {
                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                { 
                    //Execute the query to retrieve the PositionID of the user
                    int positionId = cnn.ExecuteScalar<int>("SELECT PositionID FROM Position WHERE PositionTitle = @PositionTitle", new { PositionTitle = position });

                    //Sql query to insert data into the Person Table, and retrieving the PersonID of the inserted record
                    int personId = cnn.ExecuteScalar<int>(@"
                        INSERT INTO Person (Title, NameFirst, NameMiddle, NameLast, Suffix, Address1, Address2, Address3, City, Zipcode, State, Email, PhonePrimary, PhoneSecondary, PositionID) 
                        VALUES (@Title, @NameFirst, @NameMiddle, @NameLast, @Suffix, @Address1, @Address2, @Address3, @City, @Zipcode, @State, @Email, @PhonePrimary, @PhoneSecondary, @PositionID)
                        RETURNING PersonID;", 
                        new
                    {
                        Title = title,
                        NameFirst = firstName,
                        NameMiddle = middleName,
                        NameLast = lastName,
                        Suffix = suffix,
                        Address1 = address1,
                        Address2 = address2,
                        Address3 = address3,
                        City = city,
                        Zipcode = zip,
                        State = state,
                        Email = email,
                        PhonePrimary = phonePrimary,
                        PhoneSecondary = phoneSecondary,
                        PositionID = positionId
                    });

                    //Getting SecurityQuestionIDs for each security question prompt
                    int securityQ1Id = cnn.ExecuteScalar<int>(
                        "SELECT QuestionID FROM SecurityQuestions WHERE QuestionPrompt = @Prompt",
                        new { Prompt = securityQ1 });

                    int securityQ2Id = cnn.ExecuteScalar<int>(
                        "SELECT QuestionID FROM SecurityQuestions WHERE QuestionPrompt = @Prompt",
                        new { Prompt = securityQ2 });

                    int securityQ3Id = cnn.ExecuteScalar<int>(
                        "SELECT QuestionID FROM SecurityQuestions WHERE QuestionPrompt = @Prompt",
                        new { Prompt = securityQ3 });

                    //String query to insert data into the Logon Table
                    string logonQuery = "INSERT INTO Logon (PersonID, LogonName, Password, FirstChallengeQuestion, FirstChallengeAnswer, SecondChallengeQuestion, SecondChallengeAnswer, ThirdChallengeQuestion, ThirdChallengeAnswer, AccountDisabled, AccountDeleted) VALUES (@PersonID, @LogonName, @Password, @FirstChallengeQuestion, @FirstChallengeAnswer, @SecondChallengeQuestion, @SecondChallengeAnswer, @ThirdChallengeQuestion, @ThirdChallengeAnswer, 0 , 0)";

                    //Executing the query
                    cnn.Execute(logonQuery, new
                    {
                        PersonID = personId,
                        LogonName = username,
                        Password = password,
                        FirstChallengeQuestion = securityQ1Id,
                        FirstChallengeAnswer = securityA1,
                        SecondChallengeQuestion = securityQ2Id,
                        SecondChallengeAnswer = securityA2,
                        ThirdChallengeQuestion = securityQ3Id,
                        ThirdChallengeAnswer = securityA3
                    });

                    //Telling the user the account was created
                    MessageBox.Show("Account Successfully Created!.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves all existing logon usernames from the database.
        /// </summary>
        /// <returns>A list of usernames from the Logon table.</returns>
        public static List<string> DatabaseCommandLogon()
        {
            //List to hold the usernames to check 
            List<string> existingLogonID = new List<string>();

            try
            {
                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Getting the available usernames from the Logon Table
                    existingLogonID = cnn.Query<string>("SELECT LogonName FROM Logon").ToList();
                }
            }

            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Error Loading Usernames", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return existingLogonID;
        }

        /// <summary>
        /// Attempts to authenticate a user with the given username and password. 
        /// If successful, returns a populated Person object.
        /// </summary>
        /// <param name="username">The user's login name.</param>
        /// <param name="password">The user's password to validate against the stored credentials.</param>
        /// <returns>
        /// A Person object representing the logged-in user if successful, otherwise, <c>null</c>.
        /// </returns>
        public static Person LoginUser(string username, string password)
        {

            try
            {
                //SQL Query with inner joins to get PersonID, Password, and PositionTitle 
                string query = @"
                    SELECT p.positionID, p.PositionTitle, ps.Title, ps.NameFirst, ps.NameMiddle, ps.NameLast, ps.Suffix, ps.Address1, ps.Address2, ps.Address3, ps.City, ps.State, ps.Zipcode, ps.Email, ps.PhonePrimary, ps.PhoneSecondary, l.LogonName, l.Password, l.PersonID, l.AccountDisabled, l.AccountDeleted 
                    FROM Logon l
                    INNER JOIN Person ps ON l.PersonID = ps.PersonID
                    INNER JOIN Position p ON ps.PositionID = p.PositionID
                    WHERE LOWER(l.LogonName) = @LogonName";

                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Executing the query with the username
                    var result = cnn.Query(query, new { LogonName = username }).FirstOrDefault();

                    //If the user is found with the username
                    if (result != null) 
                    {
                        //Getting the stored password
                        string storedPass = result.Password;
                        string decryptedPass = clsValidation.DecryptPass(storedPass);

                        //If the passwords do not match, returning an empty list
                        if (decryptedPass != password)
                        {
                            return null;
                        }

                        //Sending the result to the Person object
                        Person person = new Person
                        {
                            PersonID = Convert.ToInt32(result.PersonID),
                            Title = result.Title,
                            NameFirst = result.NameFirst,
                            NameMiddle = result.NameMiddle,
                            NameLast = result.NameLast,
                            Suffix = result.Suffix,
                            Address1 = result.Address1,
                            Address2 = result.Address2,
                            Address3 = result.Address3,
                            City = result.City,
                            State = result.State,
                            Zipcode = result.Zipcode,
                            Email = result.Email,
                            PhonePrimary = result.PhonePrimary,
                            PhoneSecondary = result.PhoneSecondary,
                            LogonName = result.LogonName,
                            PositionID = Convert.ToInt32(result.PositionID),
                            PositionTitle = result.PositionTitle,
                            AccountDisabled = Convert.ToBoolean(result.AccountDisabled),
                            AccountDeleted = Convert.ToBoolean(result.AccountDeleted)
                        };

                        return person;//Returning the person object
                    }
                    else
                    {
                        Console.WriteLine("Username not found.");
                        return null;
                    }
                }
                
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }

        }

        /// <summary>
        /// Attempts to retrieve a user's security questions and corresponding answers
        /// for the purpose of resetting their password.
        /// </summary>
        /// <param name="username">The user's login name.</param>
        /// <returns>
        /// A list of strings containing the three security questions and their corresponding answers, 
        /// or an error message if the user is not found or questions cannot be retrieved.
        /// </returns>
        public static List<string> ResetPassword(string username)
        {
            //Variables to hold security question IDs and answers
            int Q1, Q2, Q3;
            string A1, A2, A3;

            //List to hold the questions and answers
            List<string> listQuestions = new List<string>();

            //Query to get user data from the Logon Table
            string queryUser = "SELECT LogonName, Password, FirstChallengeQuestion, SecondChallengeQuestion, ThirdChallengeQuestion, FirstChallengeAnswer, SecondChallengeAnswer, ThirdChallengeAnswer FROM Logon WHERE LOWER(LogonName) = @LogonName";
            
            //Opening the SQLite connection
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                //Getting the user info
                var user = cnn.QueryFirstOrDefault(queryUser, new { LogonName = username });

                //If the user is null
                if (user == null)
                {
                    listQuestions.Add("User not found.");
                    return listQuestions;
                }

                //Getting the challenge question IDs and answers
                Q1 = Convert.ToInt32(user.FirstChallengeQuestion);
                Q2 = Convert.ToInt32(user.SecondChallengeQuestion);
                Q3 = Convert.ToInt32(user.ThirdChallengeQuestion);

                A1 = user.FirstChallengeAnswer.ToString();
                A2 = user.SecondChallengeAnswer.ToString();
                A3 = user.ThirdChallengeAnswer.ToString();

                //Query to get the Question Prompt from the Security questions table
                string queryQuestions = @"SELECT QuestionID, QuestionPrompt FROM SecurityQuestions WHERE QuestionID IN (@Q1, @Q2, @Q3)";

                //Getting the questions
                var questionRows = cnn.Query(queryQuestions, new { Q1, Q2, Q3 });

                //Checking if all three questions were found
                if (questionRows.Count() < 3)
                {
                    listQuestions.Add("Error retrieving security questions.");
                    return listQuestions;
                }

                //Looping through the DataTable to match questions with IDs
                string question1 = "", question2 = "", question3 = "";
                foreach (var row in questionRows)
                {
                    int questionID = Convert.ToInt32(row.QuestionID);
                    string questionText = row.QuestionPrompt.ToString();

                    if (questionID == Q1)
                    {
                        question1 = questionText;
                    }

                    if (questionID == Q2)
                    {
                        question2 = questionText;
                    }

                    if (questionID == Q3)
                    {
                        question3 = questionText;
                    }
                }

                //Adding the questions and answers to the list
                listQuestions.Add(question1);
                listQuestions.Add(A1);
                listQuestions.Add(question2);
                listQuestions.Add(A2);
                listQuestions.Add(question3);
                listQuestions.Add(A3);
            }

            return listQuestions;//Returning the list to the frmPasswordReset
        }

        /// <summary>
        /// Updates the password for a user in the database. The new password is encrypted before being stored.
        /// </summary>
        /// <param name="username">The user's login name.</param>
        /// <param name="password">The new password to set for the user.</param>
        /// <returns>
        /// <c>true</c> if the password was successfully updated, otherwise, <c>false</c>.
        /// </returns>
        public static bool UpdatePassword(string username, string password)
        {
            string encryptedPass = clsValidation.EncryptPass(password);//Encrypting the Password, before updating the password in the database

            //Query to update the users password in the database
            string query = "UPDATE Logon SET Password = @NewPassword WHERE LOWER(LogonName) = @LogonName";

            //Opening the SQLite connection
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                //Executing the query, passing in the new password and logon name
                int rowsAffected = cnn.Execute(query, new
                {
                    NewPassword = encryptedPass,
                    LogonName = username.ToLower()
                });

                return rowsAffected > 0;
            }
        }


        //                              ----Customer View SQL----

        /// <summary>
        /// Retrieves all categories from the database and maps them to a list of <c>Categories</c> objects.
        /// </summary>
        /// <returns>
        /// A list <c>Categories</c> containing all categories from the database. 
        /// An empty list is returned if an error occurs or no categories are found.
        /// </returns>
        public static List<Categories> CategoriesCommand()
        {

            //String array to hold the categories
            List<Categories> categories = new List<Categories>();

            string categoryQuery = "SELECT CategoryID, CategoryName FROM Categories";

            //Opening the SQLite connection
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    //Using Dapper to map to the Categories class
                    categories = cnn.Query<Categories>(categoryQuery).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving categories: " + ex.Message);
                }
            }

            return categories;//Returning the categories list
        }

        /// <summary>
        /// Retrieves all products from the database and maps them to a list of <c>Inventory</c> objects.
        /// </summary>
        /// <returns>
        /// A list <c>Inventory</c> containing all products from the database. 
        /// An empty list is returned if an error occurs or no products are found.
        /// </returns>
        public static List<Inventory> InventoryCommand()
        { 
            //List of objects to store the products
            List<Inventory> products = new List<Inventory>();

            //Query to get all of the products from the database
            string inventoryQuery = "SELECT InventoryID, ItemName, ItemDescription, RetailPrice, Quantity, CategoryID, ItemImage, RestockThreshold, Cost, Discontinued FROM Inventory";

            //Opening the SQLite connection
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    //Using Dapper to map to the Inventory class
                    products = cnn.Query<Inventory>(inventoryQuery).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving inventory: " + ex.Message);
                }
            }

            return products;//Returning the products list
        }

        /// <summary>
        /// Retrieves a single discount from the database that matches the provided promo code.
        /// </summary>
        /// <param name="promoCode">The promotional code used to look up the discount.</param>
        /// <returns>
        /// A <c>Discounts</c> object containing the promo data for the given code,
        /// or <c>null</c> if the promo code is not found or an error occurs.
        /// </returns>
        public static Discounts DiscountCommand(string promoCode)
        {
            try
            {
                //SQL Query to get the discount details from the database
                string promoQuery = @"
                    SELECT d.DiscountID, d.DiscountCode, d.Description, d.DiscountLevel, d.InventoryID, d.DiscountType, d.DiscountPercentage, d.DiscountDollarAmount, d.StartDate, d.ExpirationDate,
                    d.isDiscontinued, i.CategoryID, i.ItemName
                    FROM Discounts d
                    LEFT JOIN Inventory i ON d.InventoryID = i.InventoryID
                    WHERE DiscountCode = @promoCode";

                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Executing the query
                    var discount = cnn.QueryFirstOrDefault<Discounts>(promoQuery, new { promoCode });
                    return discount;
                }
            }
            catch (SqlException ex)
            {
                //Message to display in the console
                Console.WriteLine("Error loading discounts: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Inserts a record into the <c>AppliedDiscounts</c> table using the provided discount information.
        /// </summary>
        /// <param name="discountID">The original discount ID.</param>
        /// <param name="discountCode">The promo code used.</param>
        /// <param name="description">The description of the discount.</param>
        /// <param name="discountLevel">The discount level (0 = Cart Level, 1 = Item Level).</param>
        /// <param name="inventoryID">The related inventory item ID, or <c>null</c> if not applicable.</param>
        /// <param name="discountType">The discount type (0 = percentage, 1 = dollar amount).</param>
        /// <param name="discountPercentage">The discount percentage (used if <paramref name="discountType"/> is 0).</param>
        /// <param name="discountDollarAmount">The discount dollar amount (used if <paramref name="discountType"/> is 1).</param>
        /// <param name="startDate">The discount's start date.</param>
        /// <param name="expirationDate">The expiration date of the discount.</param>
        /// <param name="appliedDate">The date the discount was applied.</param>
        /// <returns>
        /// The ID of the newly inserted applied discount record. 
        /// Returns <c>-1</c> if an error occurs.
        /// </returns>
        public static int InsertAppliedPromo(string discountID, string discountCode, string description, string discountLevel,
            string inventoryID, string discountType, string discountPercentage, string discountDollarAmount,
            string startDate, string expirationDate, string appliedDate)
        {
            try
            {
                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Query to add the discount code details to the AppliedDiscounts table, and returning AppliedDiscountID
                    int appliedDiscountID = cnn.ExecuteScalar<int>(@"
                        INSERT INTO AppliedDiscounts (OriginalDiscountID, DiscountCode, Description, DiscountLevel, InventoryID, DiscountType, DiscountPercentage, DiscountDollarAmount,
                        StartDate, ExpirationDate, AppliedDate) VALUES 
                        (@OriginalDiscountID, @DiscountCode, @Description, @DiscountLevel,
                        @InventoryID, @DiscountType, @DiscountPercentage, @DiscountDollarAmount,
                        @StartDate, @ExpirationDate, @AppliedDate)
                        RETURNING AppliedDiscountID;", new
                    {
                        OriginalDiscountID = int.Parse(discountID),
                        DiscountCode = discountCode,
                        Description = description,
                        DiscountLevel = int.Parse(discountLevel),
                        InventoryID = string.IsNullOrWhiteSpace(inventoryID) || inventoryID.ToUpper() == "NULL" ? (object)DBNull.Value : int.Parse(inventoryID),
                        DiscountPercentage = string.IsNullOrWhiteSpace(discountPercentage) || discountPercentage.ToUpper() == "NULL" ? (object)DBNull.Value : decimal.Parse(discountPercentage),
                        DiscountDollarAmount = string.IsNullOrWhiteSpace(discountDollarAmount) || discountDollarAmount.ToUpper() == "NULL" ? (object)DBNull.Value : decimal.Parse(discountDollarAmount),
                        StartDate = string.IsNullOrWhiteSpace(startDate) || startDate.ToUpper() == "NULL" ? (object)DBNull.Value : DateTime.Parse(startDate),
                        DiscountType = int.Parse(discountType),
                        ExpirationDate = expirationDate,
                        AppliedDate = appliedDate
                    });

                    //Returning the ID
                    return appliedDiscountID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting applied discount: " + ex.Message);
                return -1;
            }
        }


        /// <summary>
        /// Inserts a new order into the database and returns the generated <c>OrderID</c>
        /// </summary>
        /// <param name="discountID">The ID of the discount applied to the order. Use <c>0</c> if no discount was applied.</param>
        /// <param name="personID">The ID of the customer placing the order. (Required)</param>
        /// <param name="employeeID">The ID of the employee processing the order. Use <c>0</c> if the order was placed by a customer.</param>
        /// <param name="orderDate">The date the order was placed, as a string.</param>
        /// <param name="appliedDiscountID">The ID of the applied discount record. Use <c>0</c> if no discount was applied.</param>
        /// <returns>The generated <c>OrderID</c> for the inserted order or returns <c>-1</c> if the operation fails.</returns>
        public static int InsertOrders(int discountID, int personID, int employeeID, string orderDate, int appliedDiscountID)
        {         
            try
            {
                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Query to insert Orders
                    int orderID = cnn.ExecuteScalar<int>("INSERT INTO Orders (DiscountID, PersonID, EmployeeID, OrderDate, AppliedDiscountID) " +
                       "VALUES (@DiscountID, @PersonID, @EmployeeID, @OrderDate, @AppliedDiscountID)" +
                       "RETURNING OrderID;", new
                       {
                           DiscountID = discountID == 0 ? (int?)null : discountID,//If discountID is 0, set to DBNull
                           PersonID = personID,
                           EmployeeID = employeeID == 0 ? (int?)null : employeeID,//If employeeID is 0, set to DBNull
                           OrderDate = orderDate,//Ensure orderDate is in the correct format
                           AppliedDiscountID = appliedDiscountID == 0 ? (int?)null : appliedDiscountID//If appliedDiscountID is 0, set to DBNull
                       });
                    return orderID;//Returning the orderID
                }
            }
            catch (Exception ex)
            {
                //Message to display in the console
                Console.WriteLine("Error inserting order: " + ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// Inserts a new record into the <c>OrderDetails</c> table for a specific order.
        /// </summary>
        /// <param name="orderID">The orderID of the order that was placed.</param>
        /// <param name="inventoryID">The ID of the inventory item being ordered.</param>
        /// <param name="discountID">The ID of the discount applied to this item. Use <c>0</c> if no discount was applied.</param>
        /// <param name="quantity">The quantity of the item being ordered.</param>
        public static void InsertOrderDetails(int orderID, int inventoryID, int discountID, int quantity)
        {
            try
            {
                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Query to insert OrderDetails 
                    string query = "INSERT INTO OrderDetails (OrderID, InventoryID, DiscountID, Quantity) " +
                               "VALUES (@OrderID, @InventoryID, @DiscountID, @Quantity)";

                    //Executing the query
                    cnn.Execute(query, new
                    {
                        OrderID = orderID,
                        InventoryID = inventoryID,
                        DiscountID = discountID == 0 ? (int?)null : discountID,
                        Quantity = quantity
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting order details: " + ex.Message);
            }
        }


        /// <summary>
        /// Inserts a new record into the <c>Payments</c> table for a completed order.
        /// </summary>
        /// <param name="orderID">The orderID of the order that was placed.</param>
        /// <param name="ccNum">The credit card number used for payment.</param>
        /// <param name="expDate">The expiration date of the credit card in MM/YY or MM/YYYY format.</param>
        /// <param name="ccv">The card verification value (CCV) of the credit card.</param>
        public static void InsertPayments(int orderID, string ccNum, string expDate, string ccv)
        {
            try
            {
                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Query to insert Payments
                    string paymentsQuery = "INSERT INTO Payments (OrderID, CC_Number, ExpDate, CCV) " +
                               "VALUES (@OrderID, @CC_Number, @ExpDate, @CCV)";

                    //Executing the query
                    cnn.Execute(paymentsQuery, new
                    {
                        OrderID = orderID,
                        CC_Number = ccNum,
                        ExpDate = expDate,
                        CCV = ccv
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting payment: " + ex.Message);
            }
        }

        /// <summary>
        /// Updates the inventory quantites based on the items purchased in a specific order.
        /// </summary>
        /// <param name="orderID">The ID of the order to update the inventory quantities.</param>
        /// <remarks>
        /// This method reduces the quantity of each inventory item according to the matching entries in the <c>OrderDetails</c> table for the given order.
        /// Only inventory records linked to the order will be affected.
        /// </remarks>
        public static void UpdateInventory(int orderID)
        {
            try
            {
                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Query to update the inventory
                    string inventoryQuery = @"UPDATE Inventory
                    SET Quantity = Quantity - (SELECT od.Quantity FROM OrderDetails od WHERE od.InventoryID = Inventory.InventoryID AND od.OrderID = @OrderID)
                    WHERE EXISTS 
                    (SELECT 1 FROM OrderDetails od WHERE od.InventoryID = Inventory.InventoryID AND od.OrderID = @OrderID);";

                    //Executing the query, passing in the orderID
                    int rowsAffected = cnn.Execute(inventoryQuery, new { OrderID = orderID });

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Inventory updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No inventory records were updated.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating inventory: " + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves the full purchase history for the logged in customer, including order, item, discount, and return information.
        /// </summary>
        /// <param name="personID">The ID of the customer whose purchase history is being requested.</param>
        /// <returns>
        /// A list of string arrays, where each array contains details about a single item in an order. 
        /// The array includes order ID, customer name, contact info, item details, discount data, and any return information.
        /// </returns>
        /// <remarks>
        /// This method joins multiple tables—<c>Orders</c>, <c>Person</c>, <c>OrderDetails</c>, <c>Inventory</c>, 
        /// <c>AppliedDiscounts</c>, and <c>ReturnedOrders</c>—to provide a detailed list of each purchase.
        /// If a discount or return does not exist for an item, those values will be returned as "NULL" or "0".
        /// </remarks>
        public static List<string[]> CustomerReports(string personID)
        {
            //List string to hold the purchase detials
            List<string[]> purchaseDetails = new List<string[]>();

            try
            {
                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Query to get the purchase details from the database
                    string purchaseQuery = @"SELECT o.OrderID, p.NameFirst, p.NameLast, p.Email, p.PhonePrimary, i.ItemName, i.RetailPrice, od.Quantity, od.InventoryID AS OrderDetailsInvID,
                                    ad.DiscountPercentage, ad.DiscountDollarAmount, ad.DiscountLevel, ad.InventoryID AS DiscountInvID, ro.RefundAmount, ro.ReturnDate, ro.QuantityReturned
                                    FROM Orders o
                                    JOIN Person p ON o.PersonID = p.PersonID
                                    JOIN OrderDetails od ON o.OrderID = od.OrderID
                                    JOIN Inventory i ON od.InventoryID = i.InventoryID
                                    LEFT JOIN AppliedDiscounts ad ON o.AppliedDiscountID = ad.AppliedDiscountID
                                    LEFT JOIN ReturnedOrders ro ON o.OrderID = ro.OrderID AND od.InventoryID = ro.InventoryID AND ro.PersonID = p.PersonID
                                    WHERE p.PersonID = @PersonID
                                    ORDER BY o.OrderID;";

                    //Executing the query, passing in the personID
                    var purchases = cnn.Query(purchaseQuery, new { PersonID = personID });
                   

                    //Adding purchase details to the list from the purchases
                    foreach (var row in purchases)
                    {
                        //String array to hold the purchase data
                        string[] purchase = new string[16];

                        purchase[0] = row.OrderID?.ToString();
                        purchase[1] = row.NameFirst?.ToString();
                        purchase[2] = row.NameLast?.ToString();
                        purchase[3] = row.Email?.ToString();
                        purchase[4] = row.PhonePrimary?.ToString();
                        purchase[5] = row.ItemName?.ToString();
                        purchase[6] = row.RetailPrice?.ToString();
                        purchase[7] = row.Quantity?.ToString();
                        purchase[8] = row.DiscountPercentage != null ? row.DiscountPercentage.ToString() : "NULL";
                        purchase[9] = row.DiscountDollarAmount != null ? row.DiscountDollarAmount.ToString() : "NULL";
                        purchase[10] = row.DiscountLevel != null ? row.DiscountLevel.ToString() : "NULL";
                        purchase[11] = row.OrderDetailsInvID?.ToString();
                        purchase[12] = row.DiscountInvID?.ToString();
                        purchase[13] = row.QuantityReturned?.ToString();
                        purchase[14] = row.RefundAmount?.ToString() ?? "0";
                        purchase[15] = row.ReturnDate?.ToString();

                        //Adding the string array to the purchase details list
                        purchaseDetails.Add(purchase);
                    }
                }

            }
            catch (Exception ex)
            {
                //Error Message
                MessageBox.Show("Error loading purchase history: " + ex.Message);
            }

            //Returning the string
            return purchaseDetails;
        }


        //                              ----Manager View SQL----

        /// <summary>
        /// Retrieves all discount codes from the database and maps them to a list of <c>Discounts</c> objects.
        /// </summary>
        /// <returns>
        /// A list of <c>Discounts</c> objects containing details about all available and discontinued promo codes,
        /// including inventory item name and category if applicable.
        /// </returns>
        public static List<Discounts> DiscountCommandManager()
        {
            //A list string to hold the discount details
            List<Discounts> discountCodes = new List<Discounts>();

            try
            {
                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //SQL Query to get the discount details from the database
                    string promoQuery = @"SELECT d.DiscountID, d.DiscountCode, d.Description, d.DiscountLevel, d.InventoryID, 
                             d.DiscountType, d.DiscountPercentage, d.DiscountDollarAmount, d.StartDate, 
                             d.ExpirationDate, d.IsDiscontinued, i.CategoryID, i.ItemName
                          FROM Discounts d
                          LEFT JOIN Inventory i
                          ON d.InventoryID = i.InventoryID";

                   //Executing the query, using dapper to map out the list
                   discountCodes = cnn.Query<Discounts>(promoQuery).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving promo Codes: " + ex.Message);
            }

            return discountCodes;//Returning the discount Promo Codes to ManagerView
        }
  

        /// <summary>
        /// Inserts a new promo codes into the <c>Discounts</c> table.
        /// </summary>
        /// <param name="promoCode">The unique code for the discount.</param>
        /// <param name="description">The description of the promo code.</param>
        /// <param name="discountLevel">The discount level (0 = Cart Level, 1 = Item Level).</param>
        /// <param name="inventoryID">The related inventory item ID, or <c>null</c> if not applicable.</param>
        /// <param name="discountType">The discount type (0 = percentage, 1 = dollar amount).</param>
        /// <param name="discountPercentage">The discount percentage (used if <paramref name="discountType"/> is 0)</param>
        /// <param name="discountDollarAmnt">The discount dollar amount (used if <paramref name="discountType"/> is 1).</param>
        /// <param name="startDate">The discounts start date.</param>
        /// <param name="expirationDate">The expiration date of the discount.</param>
        public static void AddPromoCode(string promoCode, string description, string discountLevel, string inventoryID, int discountType,
            decimal discountPercentage, decimal discountDollarAmnt, string startDate, string expirationDate)
        {

            try
            {
                //Query to instert a promoCode into the database
                string promoQuery = @"INSERT INTO Discounts (DiscountCode, [Description], DiscountLevel, InventoryID, DiscountType, 
                DiscountPercentage, DiscountDollarAmount, StartDate, ExpirationDate)
                VALUES
                (@promoCode, @description, @discountLevel, @inventoryID, @discountType, @discountPercent, @discountDollarAmount, @startDate, @expirationDate)";

                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Creating a Dyanmic Parameters 
                    var promos = new DynamicParameters();

                    //Adding the promo Code data to the promos
                    promos.Add("@promoCode", promoCode);
                    promos.Add("@description", description);
                    promos.Add("@discountLevel", discountLevel);
                    promos.Add("@discountType", discountType);
                    promos.Add("@expirationDate", DateTime.Parse(expirationDate));

                    //Adding Inventory ID if not null
                    if (string.IsNullOrWhiteSpace(inventoryID))
                    {
                        promos.Add("@inventoryID", null);
                    }
                    else
                    {
                        promos.Add("@inventoryID", int.Parse(inventoryID));
                    }

                    //Discount fields
                    if (discountType == 0)//Percentage
                    {
                        promos.Add("@discountPercent", discountPercentage);
                        promos.Add("@discountDollarAmount", null);
                    }
                    else//Dollar Amount
                    {
                        promos.Add("@discountPercent", null);
                        promos.Add("@discountDollarAmount", discountDollarAmnt);
                    }

                    //Start date if not null
                    if (string.IsNullOrWhiteSpace(startDate))
                    {
                        promos.Add("@startDate", null);
                    }
                    else
                    {
                        promos.Add("@startDate", startDate);
                    }

                    //Executing the Query
                    cnn.Execute(promoQuery, promos);
                }

            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show("Error inserting promo Code: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Updates an existing promo code in the <c>Discounts</c> table.
        /// </summary>
        /// <param name="discountID">The ID of the discount record to be updated.</param>
        /// <param name="promoCode">The updated promo code value.</param>
        /// <param name="description">The updated description of the promo code.</param>
        /// <param name="discountLevel">The updated discount level (0 = Cart Level, 1 = Item Level)</param>
        /// <param name="inventoryID">The related inventory item ID, if applicable.</param>
        /// <param name="discountType">The updated discount type (0 = percentage, 1 = dollar amount).</param>
        /// <param name="discountPercentage">The percentage value of the discount (used if <paramref name="discountType"/> is 0).</param>
        /// <param name="discountDollarAmnt">The dollar value of the discount (used if <paramref name="discountType"/> is 1).</param>
        /// <param name="startDate">The updated start date of the discount. Can be null or empty.</param>
        /// <param name="expirationDate">The updated expiration date of the discount.</param>
        /// <remarks>
        /// This method handles both percentage-based and dollar-amount discounts and allows for item-level or cart-level promotions.
        /// Nullable parameters are handled appropriately for fields like inventory and dates.
        /// </remarks>
        public static void UpdatePromoCode(string discountID, string promoCode, string description, string discountLevel, string inventoryID, int discountType,
            decimal discountPercentage, decimal discountDollarAmnt, string startDate, string expirationDate)
        {
            try
            {
                //Query to instert a promoCode into the database
                string promoQuery = @"UPDATE Discounts 
                                SET DiscountCode = @promoCode,
                                    [Description] = @description, 
                                    DiscountLevel = @discountLevel, 
                                    InventoryID = @inventoryID, 
                                    DiscountType = @discountType, 
                                    DiscountPercentage = @discountPercent, 
                                    DiscountDollarAmount = @discountDollarAmount, 
                                    StartDate = @startDate, 
                                    ExpirationDate = @expirationDate
                                WHERE DiscountID = @DiscountID";

                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Creating a Dyanmic Parameters 
                    var promos = new DynamicParameters();

                    //Adding the promo Code data to the promos
                    promos.Add("@promoCode", promoCode);
                    promos.Add("@description", description);
                    promos.Add("@discountLevel", discountLevel);
                    promos.Add("@discountType", discountType);
                    promos.Add("@expirationDate", DateTime.Parse(expirationDate));

                    //Adding Inventory ID if not null
                    if (string.IsNullOrWhiteSpace(inventoryID))
                    {
                        promos.Add("@inventoryID", null);//If empty, adding Null
                    }
                    else
                    {
                        promos.Add("@inventoryID", int.Parse(inventoryID));
                    }

                    //Discount fields
                    if (discountType == 0)//Percentage
                    {
                        promos.Add("@discountPercent", discountPercentage);
                        promos.Add("@discountDollarAmount", null);
                    }
                    else//Dollar Amount
                    {
                        promos.Add("@discountPercent", null);
                        promos.Add("@discountDollarAmount", discountDollarAmnt);
                    }

                    //Start date if not null
                    if (string.IsNullOrWhiteSpace(startDate))
                    {
                        promos.Add("@startDate", null);
                    }
                    else
                    {
                        promos.Add("@startDate", DateTime.Parse(startDate));
                    }

                    promos.Add("@DiscountID", int.Parse(discountID));

                    //Executing the Query
                    cnn.Execute(promoQuery, promos);
                }

            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show("Error updating promo Code: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Marks a promo code as discontinued in the <c>Discounts</c> table, effectively removing it.
        /// </summary>
        /// <param name="discountID">The ID of the discount to be removed.</param>
        /// <param name="promoCode"> The promo code to be removed.</param>
        /// <remarks>
        /// This method does not permanently delete the record but sets <c>IsDiscontinued</c> to <c>1</c> to preserve data integrity
        /// and allow reference for past transactions.
        /// </remarks>
        public static void RemovePromoCode(string discountID, string promoCode)
        {
            try
            {
                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Query to delete a promoCode into the database
                    string promoQuery = @"UPDATE Discounts
                                SET IsDiscontinued = 1
                                WHERE DiscountCode = @promoCode
                                AND DiscountID = @DiscountID";

                    //Executing the query, passing in promoCode and discountID
                    cnn.Execute(promoQuery, new {PromoCode = promoCode, DiscountID  = discountID});
                }     
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show("Error deleting promo Code: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Retrieves a list of person accounts filtered by position ID, for managers to view or edit customer and manager accounts.
        /// </summary>
        /// <param name="positionID">The position ID to filter accounts by.</param>
        /// <returns>
        /// A list of <c>Person</c>> objects representing the accounts matching the given position ID.
        /// Returns <c>null</c> if an error occurs while retrieving data.
        /// </returns>
        /// <remarks>
        /// This method joins the <c>Logon</c>, <c>Person</c>, and <c>Position</c> tables to gather detailed account details.
        /// </remarks>
        public static List<Person> PersonAccountsCommand(string positionID)
        {
            //List to store all of the manager information
            List<Person> personAccounts = new List<Person>();

            try
            {
                //Query to retrieve all of the manager information
                string personQuery = @"
                        SELECT 
                            p.PositionID, p.PositionTitle,
                            ps.Title, ps.NameFirst, ps.NameMiddle, ps.NameLast, ps.Suffix, ps.Address1, ps.Address2, ps.Address3, 
                            ps.City, ps.State, ps.Zipcode, ps.Email, ps.PhonePrimary, ps.PhoneSecondary,
                            l.LogonName, l.PersonID,
                            l.AccountDisabled, l.AccountDeleted
                        FROM Logon l
                        INNER JOIN Person ps ON l.PersonID = ps.PersonID
                        INNER JOIN Position p ON ps.PositionID = p.PositionID
                        WHERE p.PositionID = @PositionID";

                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Executing the query with positionID
                    personAccounts = cnn.Query<Person>(personQuery, new { PositionID = positionID }).ToList();
                    return personAccounts;//Returning the personAccounts
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error retrieving account information: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Updates or removes a person's information in the person and logon tables.
        /// </summary>
        /// <param name="personInfo">A <c>list</c> containing the person's details.</param>
        /// <param name="type">The type of operation to perform:
        /// <list type="bullet">
        /// <item>"Update" — updates person details and account status.</item>
        /// <item>"Remove" — marks the person and account as deleted.</item>
        /// </list>
        /// </param>
        /// <remarks>
        /// When <c>type</c> is "Update", this method updates both the Person and Logon tables with the provided data.
        /// When <c>type</c> is "Remove", this method sets flags to mark the person and account as deleted.
        /// </remarks>
        public static void PersonInfoCommand(List<string> personInfo, string type)
        {
            string query = "";
            try
            {
                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    if (type == "Update")
                    {
                        query = "UPDATE Person SET " +
                                "Title = @Title, NameFirst = @FirstName, NameMiddle = @MiddleName, NameLast = @LastName, Suffix = @Suffix, " +
                                "Address1 = @Address1, Address2 = @Address2, Address3 = @Address3, City = @City, State = @State, " +
                                "Zipcode = @Zip, Email = @Email, PhonePrimary = @Phone1, PhoneSecondary = @Phone2 " +
                                "WHERE PersonID = @PersonID; " +
                                "UPDATE Logon SET AccountDisabled = @AccountDisabled WHERE PersonID = @PersonID;";

                        //Creating a Dynamic Parameters for person details
                        var person = new DynamicParameters();

                        //Adding the person data to the person parameters
                        person.Add("@Title", personInfo[0]);
                        person.Add("@FirstName", personInfo[1]);
                        person.Add("@MiddleName", personInfo[2]);
                        person.Add("@LastName", personInfo[3]);
                        person.Add("@Suffix", personInfo[4]);
                        person.Add("@Address1", personInfo[5]);
                        person.Add("@Address2", personInfo[6]);
                        person.Add("@Address3", personInfo[7]);
                        person.Add("@City", personInfo[8]);
                        person.Add("@State", personInfo[9]);
                        person.Add("@Zip", personInfo[10]);
                        person.Add("@Email", personInfo[11]);
                        person.Add("@Phone1", personInfo[12]);
                        person.Add("@Phone2", personInfo[13]);
                        person.Add("@PersonID", personInfo[15]);
                        person.Add("@AccountDisabled", personInfo[16]);

                        //Executing the Query
                        int rowsAffected = cnn.Execute(query, person);

                        //Checking if rows were affected to tell the user
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Account has been updated.");
                        }
                        else
                        {
                            MessageBox.Show("No account found to update.");
                        }
                    }
                    else if (type == "Remove")
                    {
                        //Removing the person by setting PersonDeleted and AccountDeleted to 1
                        query = "UPDATE Person SET PersonDeleted = 1 WHERE PersonID = " +
                                "(SELECT PersonID FROM Logon WHERE LogonName = @LogonName);" +
                                "UPDATE Logon SET AccountDeleted = 1 " +
                                "WHERE PersonID = @PersonID;";

                        //Creating a Dynamic Parameters for person details
                        var person = new DynamicParameters();

                        //Adding the person data to the person parameters
                        person.Add("@LogonName", personInfo[14]);
                        person.Add("@PersonID", personInfo[15]);

                        int rowsAffected = cnn.Execute(query, person);

                        //Checking if rows were affected to tell the user
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Account has been removed.");
                        }
                        else
                        {
                            MessageBox.Show("No account found to remove.");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating User Account Information: " + ex.Message);
            } 
        }

        /// <summary>
        /// Adds a new product to the <c>Inventory</c> table or updates an existing product in the <c>Inventory</c> table.
        /// </summary>
        /// <param name="type">
        /// The operation type: 
        /// <list type="bullet">
        /// <item>"Add" to insert a new product.</item>
        /// <item>"Update" to modify an existing product.</item>
        /// </list>
        /// </param>
        /// <param name="productID">The ID of the product.</param>
        /// <param name="productName">The name of the product.</param>
        /// <param name="productDescription"></param>
        /// <param name="productCategory">The category ID of the product.</param>
        /// <param name="productCost">The cost of the product.</param>
        /// <param name="productRetailPrice">The retail price of the product.</param>
        /// <param name="productStock">The quantity of the product.</param>
        /// <param name="restockThreshold">The stock level that triggers a restock alert.</param>
        /// <param name="image">The product image as a byte array.</param>
        /// <param name="discontinued">Flag indicating if the product is discontiued.</param>
        /// <remarks>
        /// When <c>type</c> is "Update", this method updates the product with the corresponding <c>productID</c>.
        /// When <c>type</c> is "Add", this method inserts a new product into the <c>Inventory</c> table.
        /// </remarks>
        public static void AddInventoryCommand(string type, string productID, string productName, string productDescription, string productCategory, string productCost,
            string productRetailPrice, string productStock, string restockThreshold, Byte[] image, string discontinued)
        {
            string query ="";
            try
            {
                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    if (type == "Update")
                    {
                        query = "UPDATE Inventory SET " +
                                "ItemName = @ItemName, " +
                                "ItemDescription = @ItemDescription, " +
                                "CategoryID = @CategoryID, " +
                                "RetailPrice = @RetailPrice, " +
                                "Cost = @Cost, " +
                                "Quantity = @Quantity, " +
                                "RestockThreshold = @RestockThreshold, " +
                                "ItemImage = @ItemImage, " +
                                "Discontinued = @Discontinued " +
                                "WHERE InventoryID = @ProductID";

                        //Creating a Dynamic Parameters for product details
                        var product = new DynamicParameters();

                        //Adding the product data to the product parameters
                        product.Add("@ItemName", productName);
                        product.Add("@ItemDescription", productDescription);
                        product.Add("@CategoryID", productCategory);
                        product.Add("@RetailPrice", productRetailPrice);
                        product.Add("@Cost", productCost);
                        product.Add("@Quantity", productStock);
                        product.Add("@RestockThreshold", restockThreshold);
                        product.Add("@ItemImage", image);
                        product.Add("@Discontinued", discontinued);
                        product.Add("@ProductID", productID);

                        //Executing the query
                        int rowsAffected = cnn.Execute(query, product);

                        //Checking if rows were affected to tell the user
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Inventory Updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Inventory was not updated.");
                        }
                    }
                    else if (type == "Add")
                    {
                        //Query to add a new InventoryItem
                        query = "INSERT INTO Inventory (ItemName, ItemDescription, CategoryID, RetailPrice, Cost, Quantity, RestockThreshold, ItemImage) " +
                        "VALUES (@ItemName, @ItemDescription, @CategoryID, @RetailPrice, @Cost, @Quantity, @RestockThreshold, @ItemImage)";

                        //Creating a Dynamic Parameters for product details
                        var product = new DynamicParameters();

                        //Adding the product data to the product parameters
                        product.Add("@ItemName", productName);
                        product.Add("@ItemDescription", productDescription);
                        product.Add("@CategoryID", productCategory);
                        product.Add("@RetailPrice", productRetailPrice);
                        product.Add("@Cost", productCost);
                        product.Add("@Quantity", productStock);
                        product.Add("@RestockThreshold", restockThreshold);
                        product.Add("@ItemImage", image);

                        int rowsAffected = cnn.Execute(query, product);

                        //Checking if rows were affected to tell the user
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Inventory Item added successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Inventory item was not added.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves sales report data for a specific customer within a give date range.
        /// </summary>
        /// <param name="startDate">The start date of the sales report period.</param>
        /// <param name="endDate">The end date of the sales report period.</param>
        /// <param name="personID">The ID of the customer for the sales report.</param>
        /// <returns>
        /// A list of string arrays where each array contains details about an individual sale, including order info,
        /// product details, discounts applied, returns, and refund amounts.
        /// Returns an empty list if no sales are found or an error occurs.
        /// </returns>
        public static List<string[]> getCustomerSalesReports(string startDate, string endDate, string personID)
        {
            //List string to hold the sales
            List<string[]> salesResult = new List<string[]>();

            try
            {
                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Query to get all of the orders from the database
                    string ordersQuery = @"
                            SELECT o.OrderID, o.OrderDate, p.NameFirst, p.NameLast, od.InventoryID AS OrderDetailsInvID, i.ItemName, i.RetailPrice, i.Cost, od.Quantity, 
                            ad.InventoryID AS DiscountInvID, ad.DiscountPercentage, ad.DiscountDollarAmount, ad.DiscountLevel, ro.RefundAmount, ro.QuantityReturned
                            FROM Orders o
                            JOIN Person p ON o.PersonID = p.PersonID
                            JOIN OrderDetails od ON o.OrderID = od.OrderID
                            JOIN Inventory i ON od.InventoryID = i.InventoryID
                            LEFT JOIN AppliedDiscounts ad ON o.AppliedDiscountID = ad.AppliedDiscountID
                            LEFT JOIN ReturnedOrders ro ON o.OrderID = ro.OrderID AND od.InventoryID = ro.InventoryID AND ro.PersonID = p.PersonID
                            WHERE o.OrderDate BETWEEN @StartDate AND @EndDate AND p.PersonID = @PersonID";

                    //Executing the query, passing in the startDate, endDate and personID
                    var purchases = cnn.Query(ordersQuery, new { StartDate = startDate, EndDate = endDate, PersonID = personID });

                    //Adding order details to the list from the dataTable
                    foreach (var purchase in purchases)
                    {
                        string[] customerOrders = new string[15];
                        customerOrders[0] = purchase.OrderID.ToString();
                        customerOrders[1] = purchase.OrderDate.ToString();
                        customerOrders[2] = purchase.ItemName.ToString();
                        customerOrders[3] = purchase.RetailPrice.ToString();
                        customerOrders[4] = purchase.Cost.ToString();
                        customerOrders[5] = purchase.Quantity.ToString();
                        customerOrders[6] = purchase.DiscountPercentage != null ? purchase.DiscountPercentage.ToString() : "NULL";
                        customerOrders[7] = purchase.DiscountDollarAmount != null ? purchase.DiscountDollarAmount.ToString() : "NULL";
                        customerOrders[8] = purchase.DiscountLevel != null ? purchase.DiscountLevel.ToString() : "NULL";
                        customerOrders[9] = purchase.NameFirst.ToString();
                        customerOrders[10] = purchase.NameLast.ToString();
                        customerOrders[11] = purchase.OrderDetailsInvID.ToString();
                        customerOrders[12] = purchase.DiscountInvID?.ToString();
                        customerOrders[13] = purchase.QuantityReturned?.ToString();
                        customerOrders[14] = purchase.RefundAmount?.ToString() ?? "0";

                        salesResult.Add(customerOrders);//Adding the customerOrders to the salesResult list
                    }
                }
            }
            catch (SQLiteException ex)
            {
                //Error Message
                MessageBox.Show("Error loading sales report: " + ex.Message);
            }

            //Returning the string
            return salesResult;
        }

        /// <summary>
        /// Retrieves a list of all inventory items for reports.
        /// </summary>
        /// <returns>
        /// A list of <c>Inventory</c> objects containing all inventory from the database.
        /// Returns null if an error occurs during retrieval.
        /// </returns>
        public static List<Inventory> getInventoryReports()
        {
            List<string[]> inventoryResult = new List<string[]>();

            try
            {
                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Query to get all of the inventory products from the database
                    string query = "SELECT inventoryID, ItemName, Cost, RetailPrice, Quantity, RestockThreshold, Discontinued " +
                                   "FROM Inventory";

                    //Executing the query and adding the result to a list
                    var inventoryList = cnn.Query<Inventory>(query).ToList();

                    return inventoryList;//Returning the inventory List
                }
            }
            catch (SqlException ex)
            {
                //Telling the user there was an error
                MessageBox.Show("Error retrieving Inventory Information: " + ex.Message);
                return null;
            }           
        }

        /// <summary>
        /// Retrieves sales reports filtered by a specified date and report type.
        /// </summary>
        /// <param name="date">The reference date for the report.</param>
        /// <param name="reportType">The type of report to generate: "Daily", "Weekly", "Monthly", "Yearly"</param>
        /// <returns>
        /// A list of string arrays containing sales data including order details, item info, and discounts.
        /// Each array represents one sale record with fields such as OrderID, OrderDate, ItemName, RetailPrice, Cost, Quantity, and discount information.
        /// Returns an empty list if no records are found or if an error occurs.
        /// </returns>
        /// <remarks>
        /// The method uses SQLite's strftime function to filter orders by the specified report type.
        /// </remarks>
        public static List<string[]> getSalesReports(string date, string reportType)
        {

            //List string to hold the sales
            List<string[]> salesResult = new List<string[]>();

            string ordersQuery = "";
            try
            {
                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    string reportQuery = @"
                                SELECT o.OrderID, o.OrderDate, od.InventoryID, i.ItemName, i.RetailPrice, i.Cost, od.Quantity, ad.DiscountPercentage, ad.DiscountDollarAmount, ad.DiscountLevel
                                FROM Orders o
                                JOIN OrderDetails od ON o.OrderID = od.OrderID
                                JOIN Inventory i ON od.InventoryID = i.InventoryID
                                LEFT JOIN AppliedDiscounts ad ON o.AppliedDiscountID = ad.AppliedDiscountID
                                WHERE ";

                    //Switch to check the report type (daily, weekly, monthly, and yearly) and modify the query
                    switch (reportType)
                    {
                        case "Daily":
                            ordersQuery = reportQuery + "DATE(o.OrderDate) = DATE(@Date)";
                            break;
                        case "Weekly":
                            ordersQuery = reportQuery + "strftime('%W', o.OrderDate) = strftime('%W', @Date) AND strftime('%Y', o.OrderDate) = strftime('%Y', @Date)";
                            break;
                        case "Monthly":
                            ordersQuery = reportQuery + "strftime('%m', o.OrderDate) = strftime('%m', @Date) AND strftime('%Y', o.OrderDate) = strftime('%Y', @Date)";
                            break;
                        case "Yearly":
                            ordersQuery = reportQuery + "strftime('%Y', o.OrderDate) = strftime('%Y', @Date)";
                            break;
                    }
                   
                    //Executing the query, passing in date
                    var orders = cnn.Query(ordersQuery, new { Date = date });

                    //Adding order details to the list from orders
                    foreach (var row in orders)
                    {
                        string[] order = new string[11];
                        order[0] = row.OrderID.ToString();
                        order[1] = row.OrderDate.ToString();
                        order[2] = row.ItemName.ToString();
                        order[3] = row.RetailPrice.ToString();
                        order[4] = row.Cost.ToString();
                        order[5] = row.Quantity.ToString();
                        order[6] = row.DiscountPercentage != null ? row.DiscountPercentage.ToString() : "NULL";
                        order[7] = row.DiscountDollarAmount != null ? row.DiscountDollarAmount.ToString() : "NULL";
                        order[8] = row.DiscountLevel != null ? row.DiscountLevel.ToString() : "NULL";

                        salesResult.Add(order);//Adding the orders to the salesResult list
                    }
                }
            }
            catch (SqlException ex)
            {
                //Error Message
                MessageBox.Show("Error loading sales report: " + ex.Message);
            }

            //Returning the string
            return salesResult;
        }

        /// <summary>
        /// Retrieves refund reports filtered by a specified date and report type.
        /// </summary>
        /// <param name="date">The reference date for the report.</param>
        /// <param name="reportType">The type of report to generate: "Daily", "Weekly", "Monthly", "Yearly"</param>
        /// <returns>
        /// A list of string arrays where each array contains refund details such as OrderID, ReturnDate, ItemName, RetailPrice, Cost,
        /// QuantityReturned, RefundAmount, and discount information.
        /// Returns an empty list if no records are found or if an error occurs.
        /// </returns>
        /// <remarks>
        /// The method uses SQLite's strftime function to filter orders by the specified report type.
        /// </remarks>
        public static List<string[]> getRefundsReports(string date, string reportType)
        {

            //List string to hold the refunds
            List<string[]> refundsResult = new List<string[]>();

            string refundsQuery = "";
            try
            {
                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    string reportQuery = @"
                                SELECT ro.OrderID, ro.ReturnDate, i.ItemName, i.RetailPrice, i.Cost, ro.QuantityReturned, ro.RefundAmount, ad.DiscountPercentage, ad.DiscountDollarAmount,
                                    ad.DiscountLevel
                                FROM ReturnedOrders ro
                                JOIN Inventory i ON ro.InventoryID = i.InventoryID
                                JOIN Orders o ON ro.OrderID = o.OrderID
                                LEFT JOIN AppliedDiscounts ad ON o.AppliedDiscountID = ad.AppliedDiscountID
                                WHERE ";

                    //Switch to check the report type (daily, weekly, monthly, and yearly) and modify the query
                    switch (reportType)
                    {
                        case "Daily":
                            refundsQuery = reportQuery + "DATE(ro.ReturnDate) = DATE(@Date)";
                            break;
                        case "Weekly":
                            refundsQuery = reportQuery + "strftime('%W', ro.ReturnDate) = strftime('%W', @Date) AND strftime('%Y', ro.ReturnDate) = strftime('%Y', @Date)";
                            //Explanation: Where week of returnDate = week of selectedDate AND year of returnDate = year of selectedDate
                            break;
                        case "Monthly":
                            refundsQuery = reportQuery + "strftime('%m', ro.ReturnDate) = strftime('%m', @Date) AND strftime('%Y', ro.ReturnDate) = strftime('%Y', @Date)";
                            //Explanation: Where month of returnDate = month of selectedDate AND year of returnDate = year of selectedDate
                            break;
                        case "Yearly":
                            refundsQuery = reportQuery + "strftime('%Y', ro.ReturnDate) = strftime('%Y', @Date)";
                            //Explanation: Where year of returnDate = year of selectedDate
                            break;
                    }

                    //Executing the query, passing in date
                    var refunds = cnn.Query(refundsQuery, new { Date = date });

                    //Adding refund details to the list from refunds
                    foreach (var row in refunds)
                    {
                        string[] refund = new string[11];
                        refund[0] = row.OrderID.ToString();
                        refund[1] = row.ReturnDate.ToString();
                        refund[2] = row.ItemName.ToString();
                        refund[3] = row.RetailPrice.ToString();
                        refund[4] = row.Cost.ToString();
                        refund[5] = row.QuantityReturned.ToString();
                        refund[6] = row.RefundAmount.ToString();
                        refund[7] = row.DiscountPercentage != null ? row.DiscountPercentage.ToString() : "NULL";
                        refund[8] = row.DiscountDollarAmount != null ? row.DiscountDollarAmount.ToString() : "NULL";
                        refund[9] = row.DiscountLevel != null ? row.DiscountLevel.ToString() : "NULL";

                        refundsResult.Add(refund);//Adding the refunds to the refundsResult list
                    }
                }
            }
            catch (SqlException ex)
            {
                //Error Message
                MessageBox.Show("Error loading refunds report: " + ex.Message);
            }

            //Returning the string
            return refundsResult;
        }



        //                              ----Added Feature SQL----


        /// <summary>
        /// Retrieves recent purchase details for a specified customer, excluding any items with refund requests.
        /// Only purchases from the last 14 days are returned.
        /// </summary>
        /// <param name="personID">The ID of the customer.</param>
        /// <returns>
        /// A list of string arrays containing purchase details, including OrderID, OrderDate, InventoryID, ItemName, RetailPrice,
        /// Quantity, discount information, OrderDetails InventoryID, Discount InventoryID, and refund request status.
        /// Returns an empty list if no matching purchases are found or an error occurs.
        /// </returns>
        /// /// <remarks>
        /// This method filters orders to exclude those with refund requests and restricts results to the last 14 days.
        /// </remarks>
        public static List<string[]> getPurchases(string personID)
        {
            //List string to hold the purchase detials
            List<string[]> purchaseDetails = new List<string[]>();

            try
            {
                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Query to get the purchase details from the database
                    string purchaseQuery = @"SELECT o.OrderID, o.OrderDate, i.InventoryID, i.ItemName, i.RetailPrice, od.Quantity, od.InventoryID AS OrderDetailsInvID, od.RefundRequested,
                                    ad.DiscountPercentage, ad.DiscountDollarAmount, ad.DiscountLevel, ad.InventoryID AS DiscountInvID
                                    FROM Orders o
                                    JOIN Person p ON o.PersonID = p.PersonID
                                    JOIN OrderDetails od ON o.OrderID = od.OrderID
                                    JOIN Inventory i ON od.InventoryID = i.InventoryID
                                    LEFT JOIN AppliedDiscounts ad ON o.AppliedDiscountID = ad.AppliedDiscountID
                                    WHERE p.PersonID = @PersonID
                                        AND DATE(o.OrderDate) >= DATE('now', '-14 days')
                                        AND od.RefundRequested = 0
                                    ORDER BY o.OrderID;";

                    //Executing the query, passing in the personID
                    var purchases = cnn.Query(purchaseQuery, new { PersonID = personID });


                    //Adding purchase details to the list from the purchases
                    foreach (var row in purchases)
                    {
                        //String array to hold the purchase data
                        string[] purchase = new string[12];

                        purchase[0] = row.OrderID?.ToString();
                        purchase[1] = row.OrderDate?.ToString();
                        purchase[2] = row.InventoryID?.ToString();
                        purchase[3] = row.ItemName?.ToString();
                        purchase[4] = row.RetailPrice?.ToString();
                        purchase[5] = row.Quantity?.ToString();
                        purchase[6] = row.DiscountPercentage != null ? row.DiscountPercentage.ToString() : "NULL";
                        purchase[7] = row.DiscountDollarAmount != null ? row.DiscountDollarAmount.ToString() : "NULL";
                        purchase[8] = row.DiscountLevel != null ? row.DiscountLevel.ToString() : "NULL";
                        purchase[9] = row.OrderDetailsInvID?.ToString();
                        purchase[10] = row.DiscountInvID?.ToString();
                        purchase[11] = row.RefundRequested?.ToString();

                        //Adding the string array to the purchase details list
                        purchaseDetails.Add(purchase);

                    }
                }

            }
            catch (Exception ex)
            {
                //Error Message
                MessageBox.Show("Error loading purchase history: " + ex.Message);
            }

            //Returning the string
            return purchaseDetails;
        }


        //Method to add a return request to the database
        /// <summary>
        /// Adds a return request to the database for a specific order item and marks the item as having a refund requested.
        /// </summary>
        /// <param name="orderID">The ID of the order associated with the return request.</param>
        /// <param name="inventoryID">The ID of the inventory item being returned.</param>
        /// <param name="personID">The ID of the customer making the return request.</param>
        /// <param name="quantity">The quantity of the item being requested for return.</param>
        /// <param name="reason">The reason provided by the customer for the return request.</param>
        /// <remarks>
        /// This method inserts a new return request record into the <c>ReturnRequests</c> table and updates the corresponding
        /// order details to indicate a refund has been requested.
        /// </remarks>
        public static void ReturnRequest(int orderID, int inventoryID, int personID, int quantity, string reason)
        {

            try
            {
                //Query to insert the return request into the database
                string returnQuery = @"INSERT INTO ReturnRequests (OrderID, InventoryID, PersonID, Quantity, Reason)
                VALUES
                (@orderID, @inventoryID, @personID, @quantity, @reason)";

                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Creating a Dyanmic Parameters 
                    var returns = new DynamicParameters();

                    //Adding the return data to the returns
                    returns.Add("@orderID", orderID);
                    returns.Add("@inventoryID", inventoryID);
                    returns.Add("@personID", personID);
                    returns.Add("@quantity", quantity);
                    returns.Add("@reason", reason);

                    //Executing the Query
                    cnn.Execute(returnQuery, returns);

                    //Query to update the ordersDetails table
                    string updateQuery = @"UPDATE OrderDetails
                                        SET RefundRequested = 1
                                        WHERE OrderID = @orderID AND InventoryID = @inventoryID";

                    //Adding the update data to the updates 
                    var updates = new DynamicParameters();
                    updates.Add("@orderID", orderID);
                    updates.Add("@inventoryID", inventoryID);

                    //Executing the update query
                    cnn.Execute(updateQuery, updates);

                } 
            }
            catch (Exception ex)
            {
                //Error Message
                MessageBox.Show("Error loading purchase history: " + ex.Message);
            }
        }


        /// <summary>
        /// Retrieves all customer return requests that are currently awaiting to be returned.
        /// </summary>
        /// <returns>
        /// A list of string arrays, where each array contains return request details including:
        /// ReturnID, OrderID, InventoryID, PersonID, Customer Name, Item Name, Retail Price,
        /// Quantity Returned, Request Date, Calculated Refund Amount, Reason for Return,
        /// and any applied discount details.
        /// </returns>
        /// <remarks>
        /// This method executes a SQL query to fetch return requests from the database where the status is 'Awaiting Item'.
        /// It joins the <c>Person</c>, <c>Inventory</c>, <c>Orders</c>, and <c>AppliedDiscounts</c> tables
        /// to gather return information.
        /// </remarks>
        public static List<string[]> getReturnRequests()
        {
            //List string to hold the purchase detials
            List<string[]> returnRequests = new List<string[]>();

            try
            {
                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Query to get the purchase details from the database
                    string returnsQuery = @"SELECT rr.ReturnID, rr.OrderID, rr.InventoryID, rr.PersonID, p.NameFirst, p.NameLast, i.ItemName, i.RetailPrice,
                                            rr.Quantity AS QuantityReturned, rr.RequestDate, rr.Reason, (i.RetailPrice * rr.Quantity) AS RefundAmount, ad.DiscountPercentage,
                                            ad.DiscountDollarAmount, ad.DiscountLevel, ad.InventoryID AS DiscountInvID
                                            FROM ReturnRequests rr
                                            JOIN Person p ON rr.PersonID = p.PersonID
                                            JOIN Inventory i ON rr.InventoryID = i.InventoryID
                                            LEFT JOIN Orders o ON rr.OrderID = o.OrderID
                                            LEFT JOIN AppliedDiscounts ad ON o.AppliedDiscountID = ad.AppliedDiscountID
                                            WHERE rr.Status = 'Awaiting Item'
                                            ORDER BY rr.RequestDate DESC;";

                    //Executing the Query
                    var returns = cnn.Query(returnsQuery);

                    //Adding purchase details to the list from the purchases
                    foreach (var row in returns)
                    {
                        //String array to hold the purchase data
                        string[] returnData = new string[16];

                        returnData[0] = row.ReturnID?.ToString();
                        returnData[1] = row.OrderID?.ToString();
                        returnData[2] = row.InventoryID?.ToString();
                        returnData[3] = row.PersonID?.ToString();
                        returnData[4] = row.NameFirst?.ToString();
                        returnData[5] = row.NameLast?.ToString();
                        returnData[6] = row.ItemName?.ToString();
                        returnData[7] = row.RetailPrice?.ToString();
                        returnData[8] = row.QuantityReturned?.ToString();
                        returnData[9] = Convert.ToDateTime(row.RequestDate).ToString("MM/dd/yyyy");
                        returnData[10] = row.RefundAmount?.ToString();
                        returnData[11] = row.Reason?.ToString();
                        returnData[12] = row.DiscountPercentage != null ? row.DiscountPercentage.ToString() : "NULL";
                        returnData[13] = row.DiscountDollarAmount != null ? row.DiscountDollarAmount.ToString() : "NULL";
                        returnData[14] = row.DiscountLevel != null ? row.DiscountLevel.ToString() : "NULL";
                        returnData[15] = row.DiscountInvID?.ToString();

                        //Adding the return data to the returnRequests list
                        returnRequests.Add(returnData);
                    }
                }
            }
            catch (Exception ex)
            {
                //Error Message
                MessageBox.Show("Error loading return Requests: " + ex.Message);
            }

            //Returning the string
            return returnRequests;
        }

        /// <summary>
        /// Processes a return by adding it to the <c>ReturnedOrders</c> table and updating the <c>OrderDetails</c>, <c>ReturnRequests</c>, and <c>Inventory</c> tables.
        /// </summary>
        /// <param name="returnID">The ID for the return request.</param>
        /// <param name="orderID">The ID of the order being returned.</param>
        /// <param name="inventoryID">The ID of the inventory item being returned.</param>
        /// <param name="personID">The ID of the customer returning the item.</param>
        /// <param name="managerID">THe ID of the manager processing the return.</param>
        /// <param name="quantityReturned">The quantity of the item being returned.</param>
        /// <param name="refundAmount">The total refund amount to be issued for the return.</param>
        /// <remarks>
        /// This method:
        /// <list type="bullet">
        /// <item><description>Inserts a new record into the <c>ReturnedOrders</c> table.</description></item>
        /// <item><description>Updates the <c>OrderDetails</c> table to reflect the refunded quantity.</description></item>
        /// <item><description>Updates the <c>ReturnRequests</c> table status to 'Item Received'.</description></item>
        /// <item><description>Restocks the returned quantity into the <c>Inventory</c> table.</description></item>
        /// </list>
        /// </remarks>
        public static void ReturnedOrdersCommand(int returnID, int orderID, int inventoryID, int personID, int managerID, int quantityReturned, decimal refundAmount)
        {

            try
            {
                //Query to insert the return request into the database
                string returnQuery = @"INSERT INTO ReturnedOrders (ReturnID, orderID, InventoryID, PersonID, ManagerID, QuantityReturned, RefundAmount)
                VALUES
                (@returnID, @orderID, @inventoryID, @personID, @managerID, @quantityReturned, @refundAmount)";

                //Opening the SQLite connection
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Creating a Dyanmic Parameters 
                    var returns = new DynamicParameters();

                    //Adding the return data to the returns
                    returns.Add("@returnID", returnID);
                    returns.Add("@orderID", orderID);
                    returns.Add("@inventoryID", inventoryID);
                    returns.Add("@personID", personID);
                    returns.Add("@managerID", managerID);
                    returns.Add("@quantityReturned", quantityReturned);
                    returns.Add("@refundAmount", refundAmount);

                    //Executing the Query
                    cnn.Execute(returnQuery, returns);

                    //Query to update the ordersDetails table
                    string updateODQuery = @"UPDATE OrderDetails
                                        SET RefundedQuantity = @refundedQuantity
                                        WHERE OrderID = @orderID AND InventoryID = @inventoryID";

                    //Adding the update data to the updates 
                    var updates = new DynamicParameters();
                    updates.Add("@refundedQuantity", quantityReturned);
                    updates.Add("@orderID", orderID);
                    updates.Add("@inventoryID", inventoryID);

                    //Executing the update query
                    cnn.Execute(updateODQuery, updates);

                    //Query to update the returnRequests table
                    string updateRequestsQuery = @"UPDATE ReturnRequests
                                        SET Status = 'Item Received'
                                        WHERE OrderID = @orderID AND InventoryID = @inventoryID";

                    var updateRefundRequests = new DynamicParameters();
                    updateRefundRequests.Add("@orderID", orderID);
                    updateRefundRequests.Add("@inventoryID", inventoryID);

                    //Executing the update query
                    cnn.Execute(updateRequestsQuery, updateRefundRequests);

                    string updateInventoryQuery = @"UPDATE Inventory
                                                    SET Quantity = Quantity + @quantityReturned
                                                    WHERE InventoryID = @inventoryID";

                    var inventoryUpdate = new DynamicParameters();
                    inventoryUpdate.Add("@quantityReturned", quantityReturned);
                    inventoryUpdate.Add("@inventoryID", inventoryID);

                    //Executing the query
                    cnn.Execute(updateInventoryQuery, inventoryUpdate);
                }
            }
            catch (Exception ex)
            {
                //Error Message
                MessageBox.Show("SQLite Error: " + ex.Message);
            }
        }

    }
}
