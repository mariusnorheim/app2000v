using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HMS
{
    public partial class NewGuest : HMS.PopupForm
    {
        Gjest guestForm = (Gjest)Application.OpenForms["Gjest"];
        private string query;

        public NewGuest()
        {
            InitializeComponent();
        }

        // Button 'Lagre'
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
            if (string.IsNullOrWhiteSpace(firstname)) { MessageBox.Show("Fornavn ikke fylt ut eller kun tomrom"); }
            if (string.IsNullOrWhiteSpace(lastname)) { MessageBox.Show("Etternavn ikke fylt ut eller kun tomrom"); }
            if (string.IsNullOrWhiteSpace(address)) { MessageBox.Show("Adresse ikke fylt ut eller kun tomrom"); }
            if (string.IsNullOrWhiteSpace(city)) { MessageBox.Show("By ikke fylt ut eller kun tomrom"); }
            if (string.IsNullOrWhiteSpace(postcode)) { MessageBox.Show("Postkode ikke fylt ut eller kun tomrom"); }
            if (string.IsNullOrWhiteSpace(telephone)) { telephone = null; }

            if (!string.IsNullOrWhiteSpace(firstname) && !string.IsNullOrWhiteSpace(lastname) && !string.IsNullOrWhiteSpace(address)
                && !string.IsNullOrWhiteSpace(city) && !string.IsNullOrWhiteSpace(postcode))
            {
                using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
                {
                    try
                    {
                        // Connect to database
                        conn.Open();
                        // Save record to database
                        query = "INSERT INTO guest (firstname, lastname, address, city, postcode, telephone) " +
                                "VALUES (@firstname, @lastname, @address, @city, @postcode, @telephone)";
                        using (MySqlCommand newGuestCmd = new MySqlCommand(query, conn))
                        {
                            newGuestCmd.Parameters.AddWithValue("@firstname", firstname);
                            newGuestCmd.Parameters.AddWithValue("@lastname", lastname);
                            newGuestCmd.Parameters.AddWithValue("@address", address);
                            newGuestCmd.Parameters.AddWithValue("@city", city);
                            newGuestCmd.Parameters.AddWithValue("@postcode", postcode);
                            newGuestCmd.Parameters.AddWithValue("@telephone", telephone);
                            newGuestCmd.ExecuteNonQuery();
                            // Close form and refresh data
                            this.Close();
                            guestForm.LoadDataGuest();
                            guestForm.labelStatus.Text = "Gjest med navn " + firstname + " " + lastname + " er lagt til i databasen.";
                        }
                    }
                    // Catch exceptions and display in MessageBox
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    // Make sure connection is closed
                    finally
                    {
                        if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
                    }
                }
            }
        }

        // Button 'Avbryt'
        private void buttonNewGuestCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            guestForm.LoadDataGuest();
        }
    }
}
