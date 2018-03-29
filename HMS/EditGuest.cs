using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HMS
{
    public partial class EditGuest : HMS.PopupForm
    {
        Gjest guestForm = (Gjest)Application.OpenForms["Gjest"];
        int guestid = DBConn.QueryID;
        private string query;

        public EditGuest()
        {
            InitializeComponent();
            LoadDataGuest();
        }

        private void LoadDataGuest()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
            {
                try
                {
                    // Connect to database
                    conn.Open();
                    // Fetch selected values
                    query = "SELECT firstname, lastname, address, city, postcode, telephone FROM guest " +
                            "WHERE guestid = @guestid";
                    using (MySqlCommand getValuesCmd = new MySqlCommand(query, conn))
                    {
                        getValuesCmd.Parameters.AddWithValue("@guestid", guestid);
                        using (MySqlDataReader getValuesResult = getValuesCmd.ExecuteReader())
                        {
                            // Insert values to textboxes
                            if (getValuesResult.Read())
                            {
                                textBoxFirstname.Text = getValuesResult.GetString(0);
                                textBoxLastname.Text = getValuesResult.GetString(1);
                                textBoxAddress.Text = getValuesResult.GetString(2);
                                textBoxCity.Text = getValuesResult.GetString(3);
                                textBoxPostcode.Text = getValuesResult.GetString(4);
                                if (!getValuesResult.IsDBNull(5)) { textBoxTelephone.Text = getValuesResult.GetString(5); }
                            }
                        }
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
            if (string.IsNullOrWhiteSpace(firstname)) { MessageBox.Show("Fornavn ikke fylt ut eller kun tomrom"); }
            if (string.IsNullOrWhiteSpace(lastname)) { MessageBox.Show("Etternavn ikke fylt ut eller kun tomrom"); }
            if (string.IsNullOrWhiteSpace(address)) { MessageBox.Show("Adresse ikke fylt ut eller kun tomrom"); }
            if (string.IsNullOrWhiteSpace(city)) { MessageBox.Show("By ikke fylt ut eller kun tomrom"); }
            if (string.IsNullOrWhiteSpace(postcode)) { MessageBox.Show("Postkode ikke fylt ut eller kun tomrom"); }
            if (string.IsNullOrWhiteSpace(telephone)) { telephone = null; }

            if(!string.IsNullOrWhiteSpace(firstname) && !string.IsNullOrWhiteSpace(lastname) && !string.IsNullOrWhiteSpace(address) 
                && !string.IsNullOrWhiteSpace(city) && !string.IsNullOrWhiteSpace(postcode))
            {
                using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
                {
                    try
                    {
                        // Connect to database
                        conn.Open();
                        // Save changes to database
                        query = "UPDATE guest " +
                                "SET firstname = @firstname, lastname = @lastname, address = @address, " +
                                "city = @city, postcode = @postcode, telephone = @telephone " +
                                "WHERE guestid = @guestid";
                        using (MySqlCommand editGuestCmd = new MySqlCommand(query, conn))
                        {
                            editGuestCmd.Parameters.AddWithValue("@firstname", firstname);
                            editGuestCmd.Parameters.AddWithValue("@lastname", lastname);
                            editGuestCmd.Parameters.AddWithValue("@address", address);
                            editGuestCmd.Parameters.AddWithValue("@city", city);
                            editGuestCmd.Parameters.AddWithValue("@postcode", postcode);
                            editGuestCmd.Parameters.AddWithValue("@telephone", telephone);
                            editGuestCmd.Parameters.AddWithValue("@guestid", guestid);
                            editGuestCmd.ExecuteNonQuery();
                            // Close form and refresh data
                            this.Close();
                            guestForm.LoadDataGuest();
                            guestForm.labelStatus.Text = "Gjest med navn " + firstname + " " + lastname + " er oppdatert i databasen.";
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
