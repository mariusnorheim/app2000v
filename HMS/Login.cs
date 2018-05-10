using System;
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
            this.AcceptButton = buttonLogin;
        }

        // Fetches a valid users stored salt and makes a hash with the salt and password input
        // Checks database for username/password combination match
        private void CheckLogin()
        {
            string uid = textBoxUsername.Text;
            string upw = textBoxPassword.Text;

            // Check for input
            if (!string.IsNullOrWhiteSpace(uid) && !string.IsNullOrWhiteSpace(upw))
            {
                Boolean validLogin = false;
                string salt;
                int su;

                // Fetch salt and superuser status for user
                MySqlDataReader getValues = DBGetData.GetLoginData(uid);
                if (getValues.Read())
                {
                    salt = getValues.GetString(0);
                    su = getValues.GetInt32(1);

                    // Hash password with salt
                    PasswordHasher pwHasher = new PasswordHasher();
                    HashResult hashedPassword = pwHasher.HashStoredSalt(upw, salt, SHA512.Create());

                    if(DBGetData.GetLoginMatch(uid, hashedPassword.Digest) == 1) { validLogin = true; }

                    // Check for login match
                    if(validLogin)
                    {
                        // Save user information in static variables through the UserInfo class
                        UserInfo.AdminID = uid;
                        UserInfo.SuperUser = su;

                        // Open main program and hide login screen
                        UserInterface UIForm = new UserInterface();
                        UIForm.Show();
                        this.Hide();
                    }
                }

                // No login match
                else { this.labelStatus.Text = "Username or password incorrect, try again."; }

                getValues.Dispose();
            }
            // No textfield input
            else { this.labelStatus.Text = "Username or password field empty, try again."; }
        }

        // Button for closing program
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        // Button 'Login'
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }
    }
}
