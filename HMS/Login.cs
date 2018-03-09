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

        private void CheckLogin()
        {
            string uid = textBoxUsername.Text;
            PasswordHasher pwHasher = new PasswordHasher();
            HashResult hashedPassword = pwHasher.PasswordHash(textBoxPassword.Text, SHA512.Create());

            // Check database for input match
            DBConn conn = new DBConn();
            int matchLogin = conn.Count("SELECT count(*) FROM admin WHERE admin_username='" + uid + 
                "' AND admin_password='" + hashedPassword.Digest + "';");
            if (matchLogin == 1)
            {
                // Save user information in static variables through the UserInfo class
                int su = conn.Count("SELECT count(*) FROM admin WHERE admin_username='" + uid +
                    "' AND admin_superuser='1';");
                UserInfo.UserID = uid;
                UserInfo.SuperUser = su;

                // Open main program and hide login screen
                Oversikt oversiktForm = new Oversikt();
                oversiktForm.Show();
                this.Hide();
            }
            else
            {
                this.labelStatus.Text = "Feil brukernavn eller passord, forsøk på nytt.";
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            /*
            DBConn conn = new DBConn();
            conn.AddDefaultSuperUser();
            */
            CheckLogin();
        }
    }
}
