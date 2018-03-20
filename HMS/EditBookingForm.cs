using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HMS
{
    // Popup form for å endre booking
    // Produserer mer lesbar data for brukeren i henhold til FKs i databasen
    public partial class EditBookingForm : HMS.PopupForm
    {
        public EditBookingForm()
        {
            InitializeComponent();
        }
        string query;

        // Load DB info and insert values to textfields
        private void EditBookingForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString);
                // Connect to database
                conn.Open();

                // Fill textboxes
                query = "SELECT room_reservation_amount, " +
                    "room_reservation_datefrom, room_reservation_dateto, " +
                    "room_reservation_remark FROM room_reservation " +
                    "WHERE room_reservationid = @reservationid";
                MySqlCommand cmdGetValues = new MySqlCommand(query, conn);
                cmdGetValues.Parameters.AddWithValue("@reservationid", DBConn.QueryID);
                MySqlDataReader valuesResult = cmdGetValues.ExecuteReader();
                // Check if the reader has data
                if (valuesResult.HasRows)
                {
                    // Grab non-listbox values from database
                    valuesResult.Read();
                    textBoxRoomAmount.Text = valuesResult.GetString(valuesResult.GetOrdinal("room_reservation_amount"));
                    datePickerArrival.Text = valuesResult.GetString(valuesResult.GetOrdinal("room_reservation_datefrom"));
                    datePickerDeparture.Text = valuesResult.GetString(valuesResult.GetOrdinal("room_reservation_dateto"));
                    if (!valuesResult.IsDBNull(3))
                    {
                        textBoxRemark.Text = valuesResult.GetString(valuesResult.GetOrdinal("room_reservation_remark"));
                    }

                }
                valuesResult.Close();

                // Fill guest name listbox
                query = "SELECT RR.room_reservation_guestid, G.guest_name " +
                    "FROM room_reservation RR " +
                    "JOIN guest G " +
                    "ON RR.room_reservation_guestid = G.guestid " +
                    "WHERE room_reservationid = @reservationid";
                MySqlCommand cmdGetReservationGuest = new MySqlCommand(query, conn);
                cmdGetReservationGuest.Parameters.AddWithValue("@reservationid", DBConn.QueryID);
                DataTable guestTable = new DataTable();
                MySqlDataAdapter editBookingGuestAdapter = new MySqlDataAdapter(cmdGetReservationGuest);
                editBookingGuestAdapter.Fill(guestTable);
                listBoxGuest.DataSource = guestTable;
                listBoxGuest.DisplayMember = "guest_name";
                listBoxGuest.ValueMember = "room_reservation_guestid";
                listBoxGuest.SelectedIndex = 0;


                // Fill room types listbox
                query = "SELECT room_typeid, room_type_name " +
                    "FROM room_type " +
                    "ORDER BY room_typeid";
                MySqlCommand cmdGetAllRoomtypes = new MySqlCommand(query, conn);
                DataTable roomtypeTable = new DataTable();
                MySqlDataAdapter editBookingRoomtypeAdapter = new MySqlDataAdapter(cmdGetAllRoomtypes);
                editBookingRoomtypeAdapter.Fill(roomtypeTable);
                listBoxRoomType.DataSource = roomtypeTable;
                listBoxRoomType.DisplayMember = "room_type_name";
                listBoxRoomType.ValueMember = "room_typeid";

                // Highlight the current roomtype
                query = "SELECT room_reservation_typeid " +
                    "FROM room_reservation " +
                    "WHERE room_reservationid = @reservationid";
                MySqlCommand cmdGetReservationRoomtype = new MySqlCommand(query, conn);
                cmdGetReservationRoomtype.Parameters.AddWithValue("@reservationid", DBConn.QueryID);
                MySqlDataReader reservationRoomtypeResult = cmdGetReservationRoomtype.ExecuteReader();
                if(reservationRoomtypeResult.HasRows)
                {
                    reservationRoomtypeResult.Read();
                    switch (reservationRoomtypeResult.GetString(0))
                    {
                        case "1":
                            listBoxRoomType.SelectedIndex = 0;
                            break;
                        case "2":
                            listBoxRoomType.SelectedIndex = 1;
                            break;
                        case "3":
                            listBoxRoomType.SelectedIndex = 2;
                            break;
                        case "4":
                            listBoxRoomType.SelectedIndex = 3;
                            break;
                        case "5":
                            listBoxRoomType.SelectedIndex = 4;
                            break;
                        case "6":
                            listBoxRoomType.SelectedIndex = 5;
                            break;
                    }
                }
                reservationRoomtypeResult.Close();

                // Close database connection
                conn.Close();
            }
            // Catch exceptions and display in a message box
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 'Søk' button
        // Query database and display list of result in listBoxGuest
        private void buttonSearchBookingGuest_Click(object sender, EventArgs e)
        {
            try
            {
                string search_input = @textBoxGuestName.Text.Trim();
                MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString);
                // Connect to database
                conn.Open();

                // Create a new data adapter
                query = "SELECT guestid, guest_name FROM guest " +
                    "WHERE guest_name LIKE @search " +
                    "ORDER BY guest_name";
                MySqlCommand cmdGetSearch = new MySqlCommand(query, conn);
                cmdGetSearch.Parameters.AddWithValue("@search", "%" + search_input + "%");
                DataTable searchTable = new DataTable();
                MySqlDataAdapter editBookingSearchAdapter = new MySqlDataAdapter(cmdGetSearch);
                editBookingSearchAdapter.Fill(searchTable);
                listBoxGuest.DataSource = searchTable;
                listBoxGuest.DisplayMember = "guest_name";
                listBoxGuest.ValueMember = "guestid";

                // Close database connection
                conn.Close();
            }
            // Catch exceptions and display in a message box
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 'Endre' button
        private void buttonEditBookingConfirm_Click(object sender, EventArgs e)
        {
            // Validation
            // dateTimePicker1.Value.ToString("yyyy/mm/DD")
        }

        // 'Avbryt' button
        private void buttonEditBookingCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}