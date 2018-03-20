using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HMS
{
    public partial class Booking : HMS.Content
    {
        public Booking()
        {
            InitializeComponent();
        }

        private void Booking_Load(object sender, System.EventArgs e)
        {
            //ThreadPool.QueueUserWorkItem(LoadData);
            LoadData();
        }
        string query;

        //private void LoadData(Object threadContext)
        private void LoadData()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString);
                // Connect to database
                conn.Open();

                // Create a new data adapter
                query = "SELECT RR.room_reservationid, G.guest_name, RT.room_type_name, " +
                    "RR.room_reservation_amount, RR.room_reservation_datefrom, RR.room_reservation_dateto, " +
                    "RR.room_reservation_remark FROM room_reservation RR " +
                    "JOIN room_type RT " +
                    "ON RR.room_reservation_typeid = RT.room_typeid " +
                    "JOIN guest G " +
                    "ON RR.room_reservation_guestid = G.guestid " +
                    "ORDER BY room_reservation_datefrom, guest_name";
                MySqlDataAdapter bookingTableAdapter = new MySqlDataAdapter(query, conn);
                // Populate a new data set
                DataSet bookingDS = new DataSet();
                bookingTableAdapter.Fill(bookingDS, "room_reservation");
                dataGridView1.DataSource = bookingDS;
                dataGridView1.DataMember = "room_reservation";
                // Hide ID and make readable table headers
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Gjest";
                dataGridView1.Columns[2].HeaderText = "Romtype";
                dataGridView1.Columns[3].HeaderText = "Romantall";
                dataGridView1.Columns[4].HeaderText = "Ankomst";
                dataGridView1.Columns[5].HeaderText = "Avreise";
                dataGridView1.Columns[6].HeaderText = "Anmerkning";

                // Close database connection
                conn.Close();
            }
            // Catch exceptions and display in labelStatus
            catch (Exception ex)
            {
                this.labelStatus.Text = ex.Message;
            }
        }

        // DataGridView double click, open edit form
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Set database record ID for reference
            DBConn.QueryID = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            // New edit form
            EditBookingForm editForm = new EditBookingForm();
            editForm.ShowDialog();
        }

        // Button 'Ny gjest', open new form
        private void buttonNewGuest_Click(object sender, EventArgs e)
        {
            // New guest form
            NewGuestForm guestForm = new NewGuestForm();
            guestForm.ShowDialog();
        }

        // Button 'Ny booking', open new form
        private void buttonNewBooking_Click(object sender, EventArgs e)
        {
            // New booking form
            Form bookingForm = new NewBookingForm();
            bookingForm.ShowDialog();
        }

        // Button 'Endre', identical to datagridview double click
        private void buttonEditBooking_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                // Set database record ID for reference
                DBConn.QueryID = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                // New edit form
                EditBookingForm editForm = new EditBookingForm();
                editForm.ShowDialog();
            }
        }

        // TextBox 'Search' click event, empty placeholder text
        private void textBoxSearch_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBoxSearch.Text = "";
        }

        // Button 'Søk', searches result in relevant tables from textinput
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string search_input = @textBoxSearch.Text.Trim();
                MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString);
                // Connect to database
                conn.Open();

                // Create a new data adapter
                query = "SELECT RR.room_reservationid, G.guest_name, RT.room_type_name, " +
                    "RR.room_reservation_amount, RR.room_reservation_datefrom, RR.room_reservation_dateto, " +
                    "RR.room_reservation_remark FROM room_reservation RR " +
                    "JOIN room_type RT " +
                    "ON RR.room_reservation_typeid = RT.room_typeid " +
                    "JOIN guest G " +
                    "ON RR.room_reservation_guestid = G.guestid " +
                    "WHERE guest_name LIKE @search " +
                    "ORDER BY guest_name";
                MySqlCommand cmdGetSearch = new MySqlCommand(query, conn);
                cmdGetSearch.Parameters.AddWithValue("@search", "%" + search_input + "%");
                MySqlDataAdapter bookingSearchTableAdapter = new MySqlDataAdapter(cmdGetSearch);
                // Populate a new data set
                DataSet bookingSearchDS = new DataSet();
                bookingSearchTableAdapter.Fill(bookingSearchDS, "room_reservation");
                dataGridView1.DataSource = bookingSearchDS;
                dataGridView1.DataMember = "room_reservation";
                // Hide ID and make readable table headers
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Gjest";
                dataGridView1.Columns[2].HeaderText = "Romtype";
                dataGridView1.Columns[3].HeaderText = "Romantall";
                dataGridView1.Columns[4].HeaderText = "Ankomst";
                dataGridView1.Columns[5].HeaderText = "Avreise";
                dataGridView1.Columns[6].HeaderText = "Anmerkning";

                // Close database connection
                conn.Close();
            }
            // Catch exceptions and display in labelStatus
            catch (Exception ex)
            {
                this.labelStatus.Text = ex.Message;
            }
        }
    }
}
