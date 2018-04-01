using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HMS
{
    public partial class EditGuest : HMS.PopupForm
    {
        Guest guestForm = (Guest)Application.OpenForms["Guest"];
        int guestid = DBConn.QueryID;

        public EditGuest()
        {
            InitializeComponent();
            LoadDataGuest();
        }

        private void LoadDataGuest()
        {
            // Fetch data
            DBGetData setData = new DBGetData();
            List<string>[] guestData = setData.GetGuestData(guestid);

            // Insert values to textboxes
            if (guestData.Length > 0)
            {
                textBoxFirstname.Text = guestData.GetValue(0).ToString();
                textBoxLastname.Text = guestData.GetValue(1).ToString();
                textBoxAddress.Text = guestData.GetValue(2).ToString();
                textBoxCity.Text = guestData.GetValue(3).ToString();
                textBoxPostcode.Text = guestData.GetValue(4).ToString();
                if (guestData.Length == 5) { textBoxTelephone.Text = guestData.GetValue(5).ToString(); }
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
            // TODO: returns error if null. code IF statement in SQL to skip field if null?
            if (string.IsNullOrWhiteSpace(telephone)) { telephone = (string)Convert.DBNull; }

            if(!string.IsNullOrWhiteSpace(firstname) && !string.IsNullOrWhiteSpace(lastname) && !string.IsNullOrWhiteSpace(address) 
                && !string.IsNullOrWhiteSpace(city) && !string.IsNullOrWhiteSpace(postcode))
            {
                // Execute save
                DBGetData setData = new DBGetData();
                setData.EditGuest(guestid, firstname, lastname, address, city, postcode, telephone);

                // Close form and refresh data
                this.Close();
                guestForm.labelStatus.Text = "Guest with name " + firstname + " " + lastname + " is updated in the database.";
                guestForm.LoadDataGuest();
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
