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
        /*
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
            catch (Exception ex) { this.labelStatus.Text = ex.Message; }
        }
        */

        private void CheckLogin()
        {
            string uid = textBoxUsername.Text;
            string upw = textBoxPassword.Text;
            // Check for input
            if (!string.IsNullOrWhiteSpace(uid) && !string.IsNullOrWhiteSpace(upw))
            {
                using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
                {
                    try
                    {
                        // Connect to database
                        conn.Open();

                        // Fetch salt and superuser status
                        // Prepare MySQL query
                        query = "SELECT salt, superuser FROM admin " +
                                "WHERE admin_username = @uid";
                        Boolean validlogin = false;
                        string salt;
                        int su;
                        using (MySqlCommand getValuesCmd = new MySqlCommand(query, conn))
                        {
                            getValuesCmd.Parameters.AddWithValue("@uid", uid);
                            using (MySqlDataReader getValuesResult = getValuesCmd.ExecuteReader())
                            {
                                if (getValuesResult.Read())
                                {
                                    salt = getValuesResult.GetString(0);
                                    su = getValuesResult.GetInt32(1);

                                    // Hash password with salt
                                    PasswordHasher pwHasher = new PasswordHasher();
                                    HashResult hashedPassword = pwHasher.HashStoredSalt(upw, salt, SHA512.Create());

                                    // Check database for login input match
                                    // Prepare MySQL query
                                    query = "SELECT COUNT(*) FROM admin " +
                                            "WHERE adminid = @uid AND admin_password = @upw";
                                    using (MySqlCommand matchLoginCmd = new MySqlCommand(query, conn))
                                    {
                                        matchLoginCmd.Parameters.AddWithValue("@uid", uid);
                                        matchLoginCmd.Parameters.AddWithValue("@upw", hashedPassword.Digest);
                                        if (int.Parse(matchLoginCmd.ExecuteScalar() + "") == 1)
                                        {
                                            validlogin = true;
                                        }
                                    }

                                    // Correct username/password combination
                                    if (validlogin)
                                    {
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
                                    { this.labelStatus.Text = "Feil brukernavn eller passord, forsøk på nytt."; }
                                }
                            }
                        }
                    }
                    // Catch exceptions and display in labelStatus
                    catch (Exception ex) { this.labelStatus.Text = ex.Message; }
                    // Make sure connection is closed
                    finally {
                        if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
                    }
                }
            }
            // No input
            else { this.labelStatus.Text = "Brukernavn eller passord felt tomt, forsøk på nytt."; }
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
