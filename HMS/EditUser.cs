using System;
using System.Security.Cryptography;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HMS
{
    public partial class EditUser : HMS.PopupForm
    {
        User userForm = (User)Application.OpenForms["User"];
        string adminid = DBGetData.UserID;

        public EditUser()
        {
            InitializeComponent();
            LoadDataUser();
        }

        private void LoadDataUser()
        {
            // Insert existing values
            MySqlDataReader getValues = DBGetData.GetUserData(adminid);
            if(getValues.Read())
            {
                textBoxUsername.Text = Convert.ToString(getValues[0]);
                textBoxFirstname.Text = Convert.ToString(getValues[1]);
                textBoxLastname.Text = Convert.ToString(getValues[2]);
                int superuser = Convert.ToInt32(getValues[3]);
                int active = Convert.ToInt32(getValues[4]);
                if(superuser == 1) { checkBoxSuperuser.Checked = true; }
                if(active == 1) { checkBoxActive.Checked = true; }
            }

            getValues.Dispose();
        }

        // Button 'Save'
        private void buttonEditUserConfirm_Click(object sender, EventArgs e)
        {
            string firstname = textBoxFirstname.Text;
            string lastname = textBoxLastname.Text;
            string password = textBoxPassword.Text;
            int superuser = 0;
            int active = 0;
            if(checkBoxSuperuser.Checked) { superuser = 1; }
            if(checkBoxActive.Checked) { active = 1; }

            // Check for null or empty input
            if(string.IsNullOrWhiteSpace(firstname)) { MessageBox.Show("Firstname field is not filled in"); }
            if(string.IsNullOrWhiteSpace(lastname)) { MessageBox.Show("Lastname field is not filled in"); }

            if(!string.IsNullOrWhiteSpace(adminid) && !string.IsNullOrWhiteSpace(firstname) && !string.IsNullOrWhiteSpace(lastname))
            {
                // Execute save
                DBSetData.UserEdit(adminid, firstname, lastname, superuser, active);

                // Close form and refresh data
                userForm.LoadDataUser();
                userForm.Refresh();
                this.Close();
                new StatusMessage("User with login " + adminid + " is updated in the database.");
            }
        }

        // Button 'Cancel'
        private void buttonEditUserCancel_Click(object sender, EventArgs e)
        {
            userForm.LoadDataUser();
            userForm.Refresh();
            this.Close();
        }

        // Button 'Reset'
        private void buttonEditPasswordConfirm_Click(object sender, EventArgs e)
        {
            Boolean passwordMatch = false;
            string password = textBoxPassword.Text;
            string passwordConfirm = textBoxPasswordConfirm.Text;

            // Check for null or empty input
            if(string.IsNullOrWhiteSpace(password)) { MessageBox.Show("Password field is not filled in"); }
            if(string.IsNullOrWhiteSpace(passwordConfirm)) { MessageBox.Show("Password confirmation field is not filled in"); }

            // Check that confirmation field is equal to password field
            if (password.Equals(passwordConfirm)) { passwordMatch = true; }

            // Execute save
            if (passwordMatch && !string.IsNullOrWhiteSpace(adminid) && !string.IsNullOrWhiteSpace(password) && !string.IsNullOrWhiteSpace(passwordConfirm))
            {
                // Generate new salt and hash password
                PasswordHasher pwHasher = new PasswordHasher();
                HashResult hashedPassword = pwHasher.HashNewSalt(password, 20, SHA512.Create());
                string salt = hashedPassword.Salt;
                string passwordHash = hashedPassword.Digest;

                DBSetData.UserPasswordChange(adminid, passwordHash, salt);

                // Close form
                this.Close();
                userForm.LoadDataUser();
                new StatusMessage("Password for user with login " + adminid + " is updated in the database.");
            }
        }

        // Button 'Clear'
        private void buttonClearPassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.Text = "";
            textBoxPasswordConfirm.Text = "";
        }
    }
}
