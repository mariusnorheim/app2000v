using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HMS
{
    public partial class Gjest : HMS.Content
    {
        private string query;

        public Gjest()
        {
            InitializeComponent();
        }

        private void Gjest_Load(object sender, System.EventArgs e)
        {
            LoadDataGuest();
            this.AcceptButton = buttonSearchGuest;
        }

        // Load dataset to datagridview
        public void LoadDataGuest()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
            {
                try
                {
                    // Connect to database
                    conn.Open();
                    query = "SELECT guestid, CONCAT(firstname, ' ', lastname) as guest_name,  " +
                            "address, postcode, city, telephone FROM guest " +
                            "ORDER BY lastname, firstname";
                    using (MySqlDataAdapter guestTableAdapter = new MySqlDataAdapter(query, conn))
                    {
                        // Populate a new data set to datagridview
                        DataSet guestDS = new DataSet();
                        guestTableAdapter.Fill(guestDS, "guest");
                        dataGridViewGuest.DataSource = guestDS;
                        dataGridViewGuest.DataMember = "guest";
                        // Hide ID and make readable table headers
                        dataGridViewGuest.Columns[0].Visible = false;
                        dataGridViewGuest.Columns[1].HeaderText = "Navn";
                        dataGridViewGuest.Columns[2].HeaderText = "Adresse";
                        dataGridViewGuest.Columns[3].HeaderText = "Postkode";
                        dataGridViewGuest.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridViewGuest.Columns[4].HeaderText = "By";
                        dataGridViewGuest.Columns[5].HeaderText = "Telefon";
                        dataGridViewGuest.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }
                // Catch exceptions and display in labelStatus
                catch (Exception ex) { this.labelStatus.Text = ex.Message; }
                // Make sure connection is closed
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
                }
            }
        }

        // DataGridViewRoom double click
        // Open specialized edit form
        private void dataGridViewGuest_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Set database record ID for reference
            DBConn.QueryID = Convert.ToInt32(this.dataGridViewGuest.CurrentRow.Cells[0].Value);
            Form editForm = new EditGuest();
            editForm.ShowDialog();
        }

        // TextBox 'Search' click event, empty placeholder text
        private void textBoxSearch_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBoxSearch.Text = "";
        }

        // Button 'Ny'
        // Open specialized add form
        private void buttonNewGuest_Click(object sender, EventArgs e)
        {
            Form editForm = new NewGuest();
            editForm.ShowDialog();
        }

        // Button 'Endre'
        // Open specialized edit form
        private void buttonEditGuest_Click(object sender, EventArgs e)
        {
            // Set database record ID for reference
            DBConn.QueryID = Convert.ToInt32(this.dataGridViewGuest.CurrentRow.Cells[0].Value);
            Form editForm = new EditGuest();
            editForm.ShowDialog();
        }

        // Button 'Søk'
        // Searches result in guest table from textinput
        private void buttonSearchGuest_Click(object sender, EventArgs e)
        {
            string searchinput = @textBoxSearch.Text.Trim();

            using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
            {
                try
                {
                    // Connect to database
                    conn.Open();
                    query = "SELECT guestid, CONCAT(firstname, ' ', lastname) as guest_name,  " +
                            "address, postcode, city, telephone FROM guest " +
                            "WHERE CONCAT(firstname, ' ', lastname) LIKE @search " +
                            "OR postcode LIKE @search OR telephone LIKE @search " +
                            "ORDER BY lastname, firstname";
                    using (MySqlCommand bookingRoomSearchCmd = new MySqlCommand(query, conn))
                    {
                        bookingRoomSearchCmd.Parameters.AddWithValue("@search", "%" + searchinput + "%");
                        using (MySqlDataAdapter guestSearchAdapter = new MySqlDataAdapter(bookingRoomSearchCmd))
                        {
                            // Populate a new data set to datagridview
                            DataSet guestSearchDS = new DataSet();
                            guestSearchAdapter.Fill(guestSearchDS, "guest");
                            dataGridViewGuest.DataSource = guestSearchDS;
                            dataGridViewGuest.DataMember = "guest";
                            // Hide ID and make readable table headers
                            dataGridViewGuest.Columns[0].Visible = false;
                            dataGridViewGuest.Columns[1].HeaderText = "Navn";
                            dataGridViewGuest.Columns[2].HeaderText = "Adresse";
                            dataGridViewGuest.Columns[3].HeaderText = "Postkode";
                            dataGridViewGuest.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridViewGuest.Columns[4].HeaderText = "By";
                            dataGridViewGuest.Columns[5].HeaderText = "Telefon";
                            dataGridViewGuest.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        }
                    }
                }
                // Catch exceptions and display in labelStatus
                catch (Exception ex) { this.labelStatus.Text = ex.Message; }
                // Make sure connection is closed
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
                }
            }
        }
    }
}
