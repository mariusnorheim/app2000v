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
            // Fetch data
            MySqlDataReader getGuestData = DBGetData.GetGuestData(guestid);

            // Insert values to textboxes
            if (getGuestData.Read())
            {
                textBoxFirstname.Text = Convert.ToString(getGuestData[0]);
                textBoxLastname.Text = Convert.ToString(getGuestData[1]);
                textBoxAddress.Text = Convert.ToString(getGuestData[2]);
                textBoxCity.Text = Convert.ToString(getGuestData[3]);
                textBoxPostcode.Text = Convert.ToString(getGuestData[4]);
                textBoxTelephone.Text = Convert.ToString(getGuestData[5]);
            }
        }

        // Button 'Lagre'
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
            if (string.IsNullOrWhiteSpace(firstname)) { MessageBox.Show("Firstname field is not filled in"); }
            if (string.IsNullOrWhiteSpace(lastname)) { MessageBox.Show("Lastname field is not filled in"); }
            if (string.IsNullOrWhiteSpace(address)) { MessageBox.Show("Address field is not filled in"); }
            if (string.IsNullOrWhiteSpace(city)) { MessageBox.Show("City field is not filled in"); }
            if (string.IsNullOrWhiteSpace(postcode)) { MessageBox.Show("Postcode field is not filled in"); }

            if(!string.IsNullOrWhiteSpace(firstname) && !string.IsNullOrWhiteSpace(lastname) && !string.IsNullOrWhiteSpace(address) 
                && !string.IsNullOrWhiteSpace(city) && !string.IsNullOrWhiteSpace(postcode))
            {
                if (string.IsNullOrWhiteSpace(telephone)) { telephone = null; }
                // Execute save
                DBSetData.GuestEdit(guestid, firstname, lastname, address, city, postcode, telephone);

                // Close form and refresh data
                this.Close();
                guestForm.LoadDataGuest();
                new StatusMessage("Guest with name " + firstname + " " + lastname + " is updated in the database.");
            }
        }

        // Button 'Cancel'
        private void buttonNewGuestCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            guestForm.LoadDataGuest();
        }
    }
}
