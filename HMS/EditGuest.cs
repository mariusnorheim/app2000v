using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
            List<string> guestData = DBGetData.GetGuestData(guestid);

            // Insert values to textboxes
            if (guestData.Count > 0)
            {
                textBoxFirstname.Text = Convert.ToString(guestData[0]);
                textBoxLastname.Text = Convert.ToString(guestData[1]);
                textBoxAddress.Text = Convert.ToString(guestData[2]);
                textBoxCity.Text = Convert.ToString(guestData[3]);
                textBoxPostcode.Text = Convert.ToString(guestData[4]);
                textBoxTelephone.Text = Convert.ToString(guestData[5]);
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
                DBSetData.EditGuest(guestid, firstname, lastname, address, city, postcode, telephone);

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
