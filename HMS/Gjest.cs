using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HMS
{
    public partial class Gjest : HMS.Content
    {
        MySqlDataAdapter guestTableAdapter;
        DataSet guestDS;
        string query;

        public Gjest()
        {
            InitializeComponent();
        }

        private void Gjest_Load(object sender, System.EventArgs e)
        {
            LoadDataGuest();
        }

        private void LoadDataGuest()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString);
                // Connect to database
                conn.Open();

                // Populate a new data set to datagridview
                query = "SELECT guestid, CONCAT(firstname, lastname) as guest_name,  " +
                    "address, postcode, city, telephone, membersince FROM guest " +
                    "ORDER BY lastname, firstname";
                guestTableAdapter = new MySqlDataAdapter(query, conn);
                MySqlCommandBuilder guestTableCmd = new MySqlCommandBuilder(guestTableAdapter);
                guestDS = new DataSet();
                guestTableAdapter.Fill(guestDS, "guest");
                dataGridViewGuest.DataSource = guestDS;
                dataGridViewGuest.DataMember = "guest";
                // Hide ID and make readable table headers
                dataGridViewGuest.Columns[0].Visible = false;
                dataGridViewGuest.Columns[1].HeaderText = "Fornavn";
                dataGridViewGuest.Columns[2].HeaderText = "Etternavn";
                dataGridViewGuest.Columns[3].HeaderText = "Adresse";
                dataGridViewGuest.Columns[4].HeaderText = "Postkode";
                dataGridViewGuest.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridViewGuest.Columns[5].HeaderText = "By";
                dataGridViewGuest.Columns[6].HeaderText = "Telefon";
                dataGridViewGuest.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dataGridViewGuest.Columns[7].HeaderText = "Medlem siden";
                //dataGridViewGuest.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // Close database connection
                conn.Close();
            }
            // Catch exceptions and display in labelStatus
            catch (Exception ex)
            {
                this.labelStatus.Text = ex.Message;
            }
        }

        private void buttonNewGuest_Click(object sender, EventArgs e)
        {

        }

        private void buttonEditGuest_Click(object sender, EventArgs e)
        {
            DialogResult confirmEdit = MessageBox.Show("Are you sure you want to edit the database table?\nClick \"No\" if you are unsure.", "Confirm", MessageBoxButtons.YesNo);
            if (confirmEdit == DialogResult.Yes)
            {
                guestTableAdapter.Update(guestDS, "guest");
                this.labelStatus.Text = "Databasen oppdatert.";
            }
            LoadDataGuest();
        }

        private void buttonSearchGuest_Click(object sender, EventArgs e)
        {

        }

        // TextBox 'Search' click event, empty placeholder text
        private void textBoxSearch_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBoxSearch.Text = "";
        }
    }
}
