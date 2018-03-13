using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace HMS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        string query;
        // Add a default superuser to the database
        public void AddDefaultSuperUser()
        {
            // Generate new salt and hash password
            PasswordHasher pwHasher = new PasswordHasher();
            HashResult hashedPassword = pwHasher.HashNewSalt("adminpw321", 20, SHA512.Create());

            MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString);
            try
            {
                // Open connection
                conn.Open();
                // Create command and assign the query and connection from the constructor
                query = "INSERT INTO admin (admin_name, admin_username, admin_password, admin_salt, admin_superuser)" +
                "VALUES('Nerd Herd administrator', 'nhadmin', @admin_pw, @salt, '1');";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@salt", hashedPassword.Salt);
                cmd.Parameters.AddWithValue("@admin_pw", hashedPassword.Digest);
                // Execute command
                cmd.ExecuteNonQuery();
                // Close connection
                conn.Close();
            }
            catch (Exception ex)
            {
                this.labelStatus.Text = ex.Message;
            }
        }

        private void CheckLogin()
        {
            // Check for input
            if(!(string.IsNullOrEmpty(textBoxUsername.Text)) && !(string.IsNullOrEmpty(textBoxPassword.Text)))
            {
                MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString);
                string uid = textBoxUsername.Text;

                try
                {
                    // Connect to database
                    conn.Open();

                    // Create mysql command and data reader
                    query = "SELECT admin_salt FROM admin WHERE admin_username=@uid";
                    string salt = "";
                    MySqlCommand cmdGetSalt = new MySqlCommand(query, conn);
                    cmdGetSalt.Parameters.AddWithValue("@uid", uid);
                    MySqlDataReader saltResult = cmdGetSalt.ExecuteReader();
                    // Check if the reader has data
                    if (saltResult.HasRows)
                    {
                        // Grab salt from database
                        saltResult.Read();
                        salt = saltResult.GetString(saltResult.GetOrdinal("admin_salt"));
                    }
                    saltResult.Close();

                    // Hash password with salt
                    PasswordHasher pwHasher = new PasswordHasher();
                    HashResult hashedPassword = pwHasher.HashStoredSalt(textBoxPassword.Text, salt, SHA512.Create());

                    // Check database for login input match
                    int matchLogin = 0;
                    query = "SELECT COUNT(*) FROM admin WHERE admin_username=@uid AND admin_password=@admin_pw";
                    // Create mysql command and return value
                    MySqlCommand cmdMatchLogin = new MySqlCommand(query, conn);
                    cmdMatchLogin.Parameters.AddWithValue("@uid", uid);
                    cmdMatchLogin.Parameters.AddWithValue("@admin_pw", hashedPassword.Digest);
                    matchLogin = int.Parse(cmdMatchLogin.ExecuteScalar() + "");

                    // Correct username/password combination
                    if (matchLogin == 1)
                    {
                        // Create mysql command and data reader
                        query = "SELECT admin_superuser FROM admin WHERE admin_username=@uid";
                        int su = 0;
                        MySqlCommand cmdGetSu = new MySqlCommand(query, conn);
                        cmdGetSu.Parameters.AddWithValue("@uid", uid);
                        MySqlDataReader suResult = cmdGetSu.ExecuteReader();
                        if(suResult.HasRows)
                        {
                            // Grab superuser status from database
                            suResult.Read();
                            su = suResult.GetInt16(suResult.GetOrdinal("admin_superuser"));
                        }
                        suResult.Close();

                        // Save user information in static variables through the UserInfo class
                        UserInfo.UserID = uid;
                        UserInfo.SuperUser = su;

                        // Open main program and hide login screen
                        UserInterface UIForm = new UserInterface();
                        UIForm.Show();
                        this.Hide();
                    }
                    // Wrong username/password combination
                    else
                    {
                        this.labelStatus.Text = "Feil brukernavn eller passord, forsøk på nytt.";
                    }
                }
                // Catch exceptions and display in labelStatus
                catch (Exception ex)
                {
                    this.labelStatus.Text = ex.Message;
                }
                // Close connection
                finally
                {
                    conn.Close();
                }
            }
            // No input
            else
            {
                this.labelStatus.Text = "Brukernavn eller passord felt tomt, forsøk på nytt.";
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }
    }
}
