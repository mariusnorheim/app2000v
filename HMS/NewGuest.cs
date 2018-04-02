using System;
using System.Windows.Forms;

namespace HMS
{
    public partial class NewGuest : HMS.PopupForm
    {
        Guest guestForm = (Guest)Application.OpenForms["Guest"];

        public NewGuest()
        {
            InitializeComponent();
        }

        // Button 'Save'
        // Insert record into database
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
            if (string.IsNullOrWhiteSpace(telephone)) { telephone = null; }

            // Execute save
            DBSetData.AddGuest(firstname, lastname, address, city, postcode, telephone);
            // Close form
            this.Close();
            new StatusMessage("Guest with name " + firstname + " " + lastname + " is added to the database.");
            guestForm.LoadDataGuest();
        }

        // Button 'Cancel'
        private void buttonNewGuestCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            guestForm.LoadDataGuest();
        }
    }
}
