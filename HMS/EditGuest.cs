using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HMS
{
    public partial class EditGuest : HMS.PopupForm
    {
        Guest guestForm = (Guest)Application.OpenForms["Guest"];
        int guestid = DBGetData.QueryID;

        public EditGuest()
        {
            InitializeComponent();
            LoadDataGuest();
        }

        private void LoadDataGuest()
        {
            // Insert existing values
            MySqlDataReader getValues = DBGetData.GetGuestData(guestid);
            if(getValues.Read())
            {
                textBoxFirstname.Text = Convert.ToString(getValues[0]);
                textBoxLastname.Text = Convert.ToString(getValues[1]);
                textBoxAddress.Text = Convert.ToString(getValues[2]);
                textBoxCity.Text = Convert.ToString(getValues[3]);
                textBoxPostcode.Text = Convert.ToString(getValues[4]);
                textBoxTelephone.Text = Convert.ToString(getValues[5]);
            }

            getValues.Dispose();
        }

        // Button 'Save'
        // Update database record
        private void buttonNewGuestConfirm_Click(object sender, EventArgs e)
        {
            string firstname = textBoxFirstname.Text;
            string lastname = textBoxLastname.Text;
            string address = textBoxAddress.Text;
            string city = textBoxCity.Text;
            string postcode = textBoxPostcode.Text;
            string telephone = textBoxTelephone.Text;

            // Check for null or empty input
            if(string.IsNullOrWhiteSpace(firstname)) { MessageBox.Show("Firstname field is not filled in"); }
            if(string.IsNullOrWhiteSpace(lastname)) { MessageBox.Show("Lastname field is not filled in"); }
            if(string.IsNullOrWhiteSpace(address)) { MessageBox.Show("Address field is not filled in"); }
            if(string.IsNullOrWhiteSpace(city)) { MessageBox.Show("City field is not filled in"); }
            if(string.IsNullOrWhiteSpace(postcode)) { MessageBox.Show("Postcode field is not filled in"); }

            if(!string.IsNullOrWhiteSpace(firstname) && !string.IsNullOrWhiteSpace(lastname) && !string.IsNullOrWhiteSpace(address) 
                && !string.IsNullOrWhiteSpace(city) && !string.IsNullOrWhiteSpace(postcode))
            {
                if(string.IsNullOrWhiteSpace(telephone)) { telephone = null; }
                // Execute save
                DBSetData.GuestEdit(guestid, firstname, lastname, address, city, postcode, telephone);

                // Close form and refresh data
                guestForm.LoadDataGuest();
                guestForm.Refresh();
                this.Close();
                new StatusMessage("Guest with name " + firstname + " " + lastname + " is updated in the database.");
            }
        }

        // Button 'Cancel'
        private void buttonNewGuestCancel_Click(object sender, EventArgs e)
        {
            guestForm.LoadDataGuest();
            guestForm.Refresh();
            this.Close();
        }
    }
}
