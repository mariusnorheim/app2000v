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
        private string query;

        public Booking()
        {
            InitializeComponent();
        }

        private void Booking_Load(object sender, System.EventArgs e)
        {
            LoadDataRoom();
        }

        private void LoadDataRoom()
        {
            // Set button visibility
            this.buttonNewBookingHall.Visible = false;
            this.buttonEditBookingHall.Visible = false;
            this.buttonDeleteBookingHall.Visible = false;
            this.buttonSjekkinnHall.Visible = false;
            this.buttonSjekkutHall.Visible = false;
            this.buttonSearchBookingHall.Visible = false;
            this.dataGridViewHall.Visible = false;
            this.buttonNewBookingRoom.Visible = true;
            this.buttonEditBookingRoom.Visible = true;
            this.buttonDeleteBookingRoom.Visible = true;
            this.buttonSjekkinnRoom.Visible = true;
            this.buttonSjekkutRoom.Visible = true;
            this.buttonSearchBookingRoom.Visible = true;
            this.dataGridViewRoom.Visible = true;
            this.AcceptButton = this.buttonSearchBookingRoom;

            using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
            {
                // Prepare MySQL query
                query = "SELECT RR.room_reservationid, CONCAT(G.firstname, ' ', G.lastname) AS guest_name, " +
                        "R.roomid, RT.name, RR.datefrom, RR.dateto, RR.remark FROM room_reservation RR " +
                        "JOIN guest G " +
                        "ON RR.guestid = G.guestid " +
                        "JOIN room R " +
                        "ON RR.roomid = R.roomid " +
                        "JOIN room_type RT " +
                        "ON R.room_typeid = RT.room_typeid " +
                        "ORDER BY datefrom, lastname, firstname";
                using (MySqlDataAdapter bookingRoomTableAdapter = new MySqlDataAdapter(query, conn))
                {
                    try
                    {
                        // Connect to database
                        conn.Open();

                        // Populate a new data set to datagridview
                        DataSet bookingRoomDS = new DataSet();
                        bookingRoomTableAdapter.Fill(bookingRoomDS, "room_reservation");
                        dataGridViewRoom.DataSource = bookingRoomDS;
                        dataGridViewRoom.DataMember = "room_reservation";
                        // Hide ID and make readable table headers
                        dataGridViewRoom.Columns[0].Visible = false;
                        dataGridViewRoom.Columns[1].HeaderText = "Gjest";
                        dataGridViewRoom.Columns[2].HeaderText = "Rom";
                        dataGridViewRoom.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridViewRoom.Columns[3].HeaderText = "Romtype";
                        dataGridViewRoom.Columns[4].HeaderText = "Ankomst";
                        dataGridViewRoom.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridViewRoom.Columns[5].HeaderText = "Avreise";
                        dataGridViewRoom.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridViewRoom.Columns[6].HeaderText = "Anmerkning";

                        conn.Close();
                        conn.Dispose();
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

        private void LoadDataHall()
        {
            this.buttonNewBookingRoom.Visible = false;
            this.buttonEditBookingRoom.Visible = false;
            this.buttonDeleteBookingRoom.Visible = false;
            this.buttonSjekkinnRoom.Visible = false;
            this.buttonSjekkutRoom.Visible = false;
            this.buttonSearchBookingRoom.Visible = false;
            this.dataGridViewRoom.Visible = false;
            this.buttonNewBookingHall.Visible = true;
            this.buttonEditBookingHall.Visible = true;
            this.buttonDeleteBookingHall.Visible = true;
            this.buttonSjekkinnHall.Visible = true;
            this.buttonSjekkutHall.Visible = true;
            this.buttonSearchBookingHall.Visible = true;
            this.dataGridViewHall.Visible = true;
            this.AcceptButton = this.buttonSearchBookingHall;
        }

        private void buttonSubMenu1_Click(object sender, EventArgs e)
        {
            LoadDataRoom();
        }

        private void buttonSubMenu2_Click(object sender, EventArgs e)
        {
            LoadDataHall();
        }

        // DataGridViewRoom double click, open edit form
        private void dataGridViewRoom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Set database record ID for reference
            DBConn.QueryID = this.dataGridViewRoom.CurrentRow.Cells[0].Value.ToString();
            Form editForm = new EditBookingRoom();
            editForm.ShowDialog();
        }

        // Button 'Ny' in the room section, open new form
        private void buttonNewBookingRoom_Click(object sender, EventArgs e)
        {
            Form bookingForm = new NewBookingRoom();
            bookingForm.ShowDialog();
        }

        // Button 'Endre' in the room section, identical to datagridview double click
        private void buttonEditBookingRoom_Click(object sender, EventArgs e)
        {
            if (dataGridViewRoom.SelectedCells.Count > 0)
            {
                // Set database record ID for reference
                DBConn.QueryID = this.dataGridViewRoom.CurrentRow.Cells[0].Value.ToString();
                Form editForm = new EditBookingRoom();
                editForm.ShowDialog();
            }
        }

        // Button 'Slett' in the room section, remove isactive trigger on selected record
        private void buttonDeleteBookingRoom_Click(object sender, EventArgs e)
        {
            // TODO: Update MySQL parameter isactive to 0
        }

        // Button 'Sjekk inn' in the room section
        private void buttonSjekkinnRoom_Click(object sender, EventArgs e)
        {
            // TODO: Checkin process
            // Check that room is clean -> create folio -> create folio_item for room rental
        }

        // Button 'Sjekk ut' in the room section
        private void buttonSjekkutRoom_Click(object sender, EventArgs e)
        {
            // TODO: Checkout process
            // Check and deliver messages -> Mark room to 'Need inspection' for housekeeping -> payment process -> set paiddate -> set booking to isactive 0
        }

        // Button 'Søk' in the room section, searches result in relevant tables from textinput
        private void buttonSearchBookingRoom_Click(object sender, EventArgs e)
        {
            string search_input = @textBoxSearch.Text.Trim();
            using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
            {
                // Prepare MySQL query
                query = "SELECT RR.room_reservationid, CONCAT(G.firstname, ' ', G.lastname) AS guest_name, " +
                        "R.roomid, RT.name, RR.datefrom, RR.dateto, RR.remark FROM room_reservation RR " +
                        "JOIN guest G " +
                        "ON RR.guestid = G.guestid " +
                        "JOIN room R " +
                        "ON RR.roomid = R.roomid " +
                        "JOIN room_type RT " +
                        "ON R.room_typeid = RT.room_typeid " +
                        "WHERE CONCAT(G.firstname, ' ', G.lastname) LIKE @search " +
                        "OR R.roomid LIKE @search " +
                        "ORDER BY datefrom, lastname, firstname";
                using (MySqlCommand bookingRoomSearchCmd = new MySqlCommand(query, conn))
                {
                    bookingRoomSearchCmd.Parameters.AddWithValue("@search", "%" + search_input + "%");
                    using (MySqlDataAdapter bookingRoomSearchAdapter = new MySqlDataAdapter(bookingRoomSearchCmd))
                    {
                        try
                        {
                            // Connect to database
                            conn.Open();

                            // Populate a new data set to datagridview
                            DataSet bookingRoomSearchDS = new DataSet();
                            bookingRoomSearchAdapter.Fill(bookingRoomSearchDS, "room_reservation");
                            dataGridViewRoom.DataSource = bookingRoomSearchDS;
                            dataGridViewRoom.DataMember = "room_reservation";
                            // Hide ID and make readable table headers
                            dataGridViewRoom.Columns[0].Visible = false;
                            dataGridViewRoom.Columns[1].HeaderText = "Gjest";
                            dataGridViewRoom.Columns[2].HeaderText = "Rom";
                            dataGridViewRoom.Columns[3].HeaderText = "Romtype";
                            dataGridViewRoom.Columns[4].HeaderText = "Ankomst";
                            dataGridViewRoom.Columns[5].HeaderText = "Avreise";
                            dataGridViewRoom.Columns[6].HeaderText = "Anmerkning";

                            conn.Close();
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

        // TextBox 'Search' click event, empty text
        private void textBoxSearch_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBoxSearch.Text = "";
        }

        // Button 'Ny' in the hall section, open new form
        private void buttonNewBookingHall_Click(object sender, EventArgs e)
        {
            // TODO: Same as new room, but for hall
        }

        // Button 'Endre' in the hall section, open new form
        private void buttonEditBookingHall_Click(object sender, EventArgs e)
        {
            // TODO: Same as edit room, but for hall
        }

        // Button 'Slett' in the hall section, remove isactive trigger on selected record
        private void buttonDeleteBookingHall_Click(object sender, EventArgs e)
        {
            // TODO: Update MySQL parameter isactive to 0
        }

        // Button 'Søk' in the hall section, searches result in relevant tables from textinput
        private void buttonSearchBookingHall_Click(object sender, EventArgs e)
        {
            // TODO: Same as search room, but for hall
        }

        // Button 'Sjekk inn' in the hall section
        private void buttonSjekkinnHall_Click(object sender, EventArgs e)
        {
            // TODO: Checkin process
            // Create folio -> create folio_item for hall rental
        }

        private void buttonSjekkutHall_Click(object sender, EventArgs e)
        {
            // TODO: Checkout process
            // Check and deliver messages -> payment process -> set paiddate -> set booking to isactive 0
        }
    }
}
