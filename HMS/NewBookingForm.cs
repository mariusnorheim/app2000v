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
    public partial class NewBookingForm : HMS.PopupForm
    {
        public NewBookingForm()
        {
            InitializeComponent();
        }
        string query;

        // Load available room type values
        private void NewBookingForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString);
                // Connect to database
                conn.Open();

                // Fill room types listbox
                query = "SELECT room_typeid, room_type_name " +
                    "FROM room_type";
                MySqlCommand cmdGetAllRoomtypes = new MySqlCommand(query, conn);
                DataTable roomtypeTable = new DataTable();
                MySqlDataAdapter editBookingRoomtypeAdapter = new MySqlDataAdapter(cmdGetAllRoomtypes);
                editBookingRoomtypeAdapter.Fill(roomtypeTable);
                listBoxRoomType.DataSource = roomtypeTable;
                listBoxRoomType.DisplayMember = "room_type_name";
                listBoxRoomType.ValueMember = "room_typeid";
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

        // 'Registrer' button
        private void buttonNewBookingConfirm_Click(object sender, EventArgs e)
        {

        }

        // 'Avbryt' button
        private void buttonNewBookingCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
