using System;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace HMS
{
    public partial class NewUser : HMS.PopupForm
    {
        User userForm = (User)Application.OpenForms["User"];

        public NewUser()
        {
            InitializeComponent();
        }

        // Button 'Save'
        // Validate input and insert into database
        private void buttonNewUserConfirm_Click(object sender, EventArgs e)
        {
            Boolean existingid = false;
            string adminid = textBoxUsername.Text;
            string firstname = textBoxFirstname.Text;
            string lastname = textBoxLastname.Text;
            string password = textBoxPassword.Text;
            int superuser = 0;
            if(checkBoxSuperuser.Checked) { superuser = 1; }

            // Check for null or empty input
            if(string.IsNullOrWhiteSpace(adminid)) { MessageBox.Show("Username field is not filled in"); }
            if(string.IsNullOrWhiteSpace(firstname)) { MessageBox.Show("Firstname field is not filled in"); }
            if(string.IsNullOrWhiteSpace(lastname)) { MessageBox.Show("Lastname field is not filled in"); }
            if(string.IsNullOrWhiteSpace(password)) { MessageBox.Show("Password field is not filled in"); }

            // Check if username is already taken
            if(DBGetData.GetLoginUsername(adminid) > 0) { existingid = true; }
            if(existingid) { MessageBox.Show("Username already exists, please choose a different one."); }

            // Execute save
            if(!existingid && !string.IsNullOrWhiteSpace(adminid) && !string.IsNullOrWhiteSpace(firstname) && !string.IsNullOrWhiteSpace(lastname) && !string.IsNullOrWhiteSpace(password))
            {
                // Generate new salt and hash password
                PasswordHasher pwHasher = new PasswordHasher();
                HashResult hashedPassword = pwHasher.HashNewSalt(password, 20, SHA512.Create());
                string salt = hashedPassword.Salt;
                string passwordHash = hashedPassword.Digest;

                DBSetData.UserAdd(adminid, firstname, lastname, passwordHash, salt, superuser);

                // Close form
                this.Close();
                userForm.LoadDataUser();
                new StatusMessage("User with login " + adminid + " is added to the database.");
            }
        }

        // Button 'Cancel'
        private void buttonNewUserCancel_Click(object sender, EventArgs e)
        {
            userForm.LoadDataUser();
            this.Close();
        }
    }
}
