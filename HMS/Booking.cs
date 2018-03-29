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
            LoadControlsRoom();
            DisplayDefaultRoom();
        }

        // Load dataset to datagridview
        public void LoadDataRoom(String query)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
            {
                try
                {
                    // Connect to database
                    conn.Open();
                    using (MySqlDataAdapter bookingRoomTableAdapter = new MySqlDataAdapter(query, conn))
                    {
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
                        dataGridViewRoom.Columns[6].HeaderText = "Merknad";
                        dataGridViewRoom.Columns[7].HeaderText = "Innsjekket";
                        dataGridViewRoom.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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

        // Set controls visibility for submenu button 'Rom'
        public void LoadControlsRoom()
        {
            dataGridViewRoom.Visible = true;
            buttonNewBookingRoom.Visible = true;
            buttonEditBookingRoom.Visible = true;
            buttonDeleteBookingRoom.Visible = true;
            buttonSjekkinnRoom.Visible = true;
            buttonSjekkutRoom.Visible = true;
            buttonSearchBookingRoom.Visible = true;
            buttonDisplayRoomDay.Visible = true;
            buttonDisplayRoomWeek.Visible = true;
            buttonDisplayRoomMonth.Visible = true;
            buttonDisplayRoomAll.Visible = true;
            dataGridViewHall.Visible = false;
            buttonNewBookingHall.Visible = false;
            buttonEditBookingHall.Visible = false;
            buttonDeleteBookingHall.Visible = false;
            buttonSjekkinnHall.Visible = false;
            buttonSjekkutHall.Visible = false;
            buttonSearchBookingHall.Visible = false;
            buttonDisplayHallDay.Visible = false;
            buttonDisplayHallWeek.Visible = false;
            buttonDisplayHallMonth.Visible = false;
            buttonDisplayHallAll.Visible = false;
            this.AcceptButton = buttonSearchBookingRoom;
        }

        // Load dataset to datagridview
        public void LoadDataHall(String query)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
            {
                try
                {
                    // Connect to database
                    conn.Open();
                    using (MySqlDataAdapter bookingHallTableAdapter = new MySqlDataAdapter(query, conn))
                    {
                        // Populate a new data set to datagridview
                        DataSet bookingHallDS = new DataSet();
                        bookingHallTableAdapter.Fill(bookingHallDS, "hall_reservation");
                        dataGridViewHall.DataSource = bookingHallDS;
                        dataGridViewHall.DataMember = "hall_reservation";
                        // Hide ID and make readable table headers
                        dataGridViewHall.Columns[0].Visible = false;
                        dataGridViewHall.Columns[1].HeaderText = "Gjest";
                        dataGridViewHall.Columns[2].HeaderText = "Hall";
                        dataGridViewHall.Columns[3].HeaderText = "Halltype";
                        dataGridViewHall.Columns[4].HeaderText = "Fra";
                        dataGridViewHall.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridViewHall.Columns[5].HeaderText = "Til";
                        dataGridViewHall.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridViewHall.Columns[6].HeaderText = "Merknad";
                        dataGridViewHall.Columns[7].HeaderText = "Innsjekket";
                        dataGridViewHall.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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

        // Set controls visibility for submenu button 'Hall'
        private void LoadControlsHall()
        {
            dataGridViewHall.Visible = true;
            buttonNewBookingHall.Visible = true;
            buttonEditBookingHall.Visible = true;
            buttonDeleteBookingHall.Visible = true;
            buttonSjekkinnHall.Visible = true;
            buttonSjekkutHall.Visible = true;
            buttonSearchBookingHall.Visible = true;
            buttonDisplayHallDay.Visible = true;
            buttonDisplayHallWeek.Visible = true;
            buttonDisplayHallMonth.Visible = true;
            buttonDisplayHallAll.Visible = true;
            dataGridViewRoom.Visible = false;
            buttonNewBookingRoom.Visible = false;
            buttonEditBookingRoom.Visible = false;
            buttonDeleteBookingRoom.Visible = false;
            buttonSjekkinnRoom.Visible = false;
            buttonSjekkutRoom.Visible = false;
            buttonSearchBookingRoom.Visible = false;
            buttonDisplayRoomDay.Visible = false;
            buttonDisplayRoomWeek.Visible = false;
            buttonDisplayRoomMonth.Visible = false;
            buttonDisplayRoomAll.Visible = false;
            this.AcceptButton = buttonSearchBookingHall;
        }

        // Default room display (monthly)
        public void DisplayDefaultRoom()
        {
            // Find this weeks start date and convert to readable format for MySQL
            DateTime today = DateTime.Today;
            DateTime startofmonth = new DateTime(today.Year, today.Month, 1);
            DateTime endofmonth = startofmonth.AddMonths(1).AddDays(-1);
            string startdate = startofmonth.ToString("yyyy-MM-dd");
            string enddate = endofmonth.ToString("yyyy-MM-dd");
            query = "SELECT RR.room_reservationid, CONCAT(G.firstname, ' ', G.lastname) AS guest_name, " +
                    "R.roomid, RT.name, RR.datefrom, RR.dateto, RR.remark, RR.ischeckedin FROM room_reservation AS RR " +
                    "JOIN guest AS G " +
                    "ON RR.guestid = G.guestid " +
                    "JOIN room AS R " +
                    "ON RR.roomid = R.roomid " +
                    "JOIN room_type AS RT " +
                    "ON R.room_typeid = RT.room_typeid " +
                    "WHERE (datefrom BETWEEN '" + startdate + "' AND '" + enddate + "' " +
                    "OR dateto BETWEEN '" + startdate + "' AND '" + enddate + "') " +
                    "AND RR.isactive = '1' " +
                    "ORDER BY datefrom, lastname, firstname";
            LoadDataRoom(query);
        }

        // Default hall display (monthly)
        public void DisplayDefaultHall()
        {
            query = "SELECT HR.hall_reservationid, CONCAT(G.firstname, ' ', G.lastname) AS guest_name, " +
                    "H.name, HT.name, HR.datetimefrom, HR.datetimeto, HR.remark, HR.ischeckedin FROM hall_reservation AS HR " +
                    "JOIN guest AS G " +
                    "ON HR.guestid = G.guestid " +
                    "JOIN hall AS H " +
                    "ON HR.hallid = H.hallid " +
                    "JOIN hall_type AS HT " +
                    "ON H.hall_typeid = HT.hall_typeid " +
                    "WHERE HR.isactive = '1' " +
                    "ORDER BY datetimefrom, lastname, firstname";
            LoadDataHall(query);
        }

        // Submenu button 'Rom'
        // Displays the Room section
        private void buttonSubMenu1_Click(object sender, EventArgs e)
        {
            LoadControlsRoom();
            DisplayDefaultRoom();
        }

        // Submenu button 'Hall'
        // Displays the Hall section
        private void buttonSubMenu2_Click(object sender, EventArgs e)
        {
            LoadControlsHall();
            DisplayDefaultHall();
        }

        // TextBox 'Search' click event, empty text
        private void textBoxSearch_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBoxSearch.Text = "";
        }

        //
        // Room section
        //

        // DataGridViewRoom double click
        // Open specialized edit form
        private void dataGridViewRoom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Boolean checkedin = false;
            int reservationid = Convert.ToInt32(this.dataGridViewRoom.CurrentRow.Cells[0].Value);

            using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
            {
                try
                {
                    // Connect to database
                    conn.Open();
                    // Check that room is not already checked in to
                    query = "SELECT ischeckedin FROM room_reservation " +
                            "WHERE room_reservationid = @reservationid AND ischeckedin = '1'";
                    using (MySqlCommand getCheckinStatusCmd = new MySqlCommand(query, conn))
                    {
                        getCheckinStatusCmd.Parameters.AddWithValue("@reservationid", reservationid);
                        using (MySqlDataReader getCheckinStatusResult = getCheckinStatusCmd.ExecuteReader())
                        {
                            checkedin = getCheckinStatusResult.Read();
                        }
                    }

                    if (checkedin) { this.labelStatus.Text = "Romreservasjon har allerede foretatt innsjekking og kan ikke endres."; }
                    else
                    {
                        // Set database record ID for reference
                        DBConn.QueryID = Convert.ToInt32(this.dataGridViewRoom.CurrentRow.Cells[0].Value);
                        Form editForm = new EditBookingRoom();
                        editForm.ShowDialog();
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

        // Button 'Ny' in the room section
        // Open specialized add form
        private void buttonNewBookingRoom_Click(object sender, EventArgs e)
        {
            Form bookingForm = new NewBookingRoom();
            bookingForm.ShowDialog();
        }

        // Button 'Endre' in the room section
        // Open specialized edit form, identical to DataGridViewRoom double click
        private void buttonEditBookingRoom_Click(object sender, EventArgs e)
        {
            // Make sure a value is selected
            if (this.dataGridViewRoom.SelectedCells.Count > 0)
            {
                Boolean checkedin = false;
                int reservationid = Convert.ToInt32(this.dataGridViewRoom.CurrentRow.Cells[0].Value);

                using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
                {
                    try
                    {
                        // Connect to database
                        conn.Open();
                        // Check that room is not already checked in to
                        query = "SELECT ischeckedin FROM room_reservation " +
                                "WHERE room_reservationid = @reservationid AND ischeckedin = '1'";
                        using (MySqlCommand getCheckinStatusCmd = new MySqlCommand(query, conn))
                        {
                            getCheckinStatusCmd.Parameters.AddWithValue("@reservationid", reservationid);
                            using (MySqlDataReader getCheckinStatusResult = getCheckinStatusCmd.ExecuteReader())
                            {
                                checkedin = getCheckinStatusResult.Read();
                            }
                        }

                        if (checkedin) { this.labelStatus.Text = "Romreservasjonen har allerede foretatt innsjekking og kan ikke endres."; }
                        else
                        {
                            // Set database record ID for reference
                            DBConn.QueryID = Convert.ToInt32(this.dataGridViewRoom.CurrentRow.Cells[0].Value);
                            Form editForm = new EditBookingRoom();
                            editForm.ShowDialog();
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

        // Button 'Slett' in the room section
        // Remove isactive flag on selected record
        private void buttonDeleteBookingRoom_Click(object sender, EventArgs e)
        {
            // Make sure a value is selected
            if (this.dataGridViewRoom.SelectedCells.Count > 0)
            {
                Boolean checkedin = false;
                int reservationid = Convert.ToInt32(this.dataGridViewRoom.CurrentRow.Cells[0].Value);

                using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
                {
                    try
                    {
                        // Connect to database
                        conn.Open();
                        // Check that room is not already checked in to
                        query = "SELECT ischeckedin FROM room_reservation " +
                                "WHERE room_reservationid = @reservationid AND ischeckedin = '1'";
                        using (MySqlCommand getCheckinStatusCmd = new MySqlCommand(query, conn))
                        {
                            getCheckinStatusCmd.Parameters.AddWithValue("@reservationid", reservationid);
                            using (MySqlDataReader getCheckinStatusResult = getCheckinStatusCmd.ExecuteReader())
                            {
                                checkedin = getCheckinStatusResult.Read();
                            }
                        }

                        if (checkedin) { this.labelStatus.Text = "Romreservasjonen har allerede foretatt innsjekking og kan ikke slettes."; }
                        else
                        {
                            // Save entry to database
                            query = "UPDATE room_reservation " +
                                    "SET isactive = 0 " +
                                    "WHERE room_reservationid = @reservationid";
                            using (MySqlCommand roomBookingDeleteCmd = new MySqlCommand(query, conn))
                            {
                                roomBookingDeleteCmd.Parameters.AddWithValue("@reservationid", reservationid);
                                roomBookingDeleteCmd.ExecuteNonQuery();
                                this.labelStatus.Text = "Reservasjon fjernet fra aktiv liste.";
                                DisplayDefaultRoom();
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

        // Button 'Sjekk inn' in the room section
        // Checkin process
        // Validation: Room is not marked as checked in already -> Date for checkin is today ->
        // Room is clean (Warning) -> Guest has existing unpaid folio
        // Checkin: Create new folio or append existing -> Add folio items for room charge -> Mark room as checked in
        private void buttonSjekkinnRoom_Click(object sender, EventArgs e)
        {
            // Validation variables
            Boolean checkedin = false;
            Boolean checkindate = true;
            Boolean folioexists = false;
            Boolean roomcleared = true;
            // Roomstatus values: 0 = deny checkin, 1 = warning, 2 = no flag
            int roomstatus = 2;
            // Reference variables
            string adminid = UserInfo.UserID;
            int billingitemid = 0;
            long folioid;
            int guestid;
            int roomid = Convert.ToInt32(this.dataGridViewRoom.CurrentRow.Cells[2].Value);
            int reservationid = Convert.ToInt32(this.dataGridViewRoom.CurrentRow.Cells[0].Value);

            using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
            {
                try
                {
                    // Connect to database
                    conn.Open();
                    // Check that room is not already checked in to
                    query = "SELECT ischeckedin FROM room_reservation " +
                            "WHERE room_reservationid = @reservationid AND ischeckedin = '1'";
                    using (MySqlCommand getCheckinStatusCmd = new MySqlCommand(query, conn))
                    {
                        getCheckinStatusCmd.Parameters.AddWithValue("@reservationid", reservationid);
                        using (MySqlDataReader getCheckinStatusResult = getCheckinStatusCmd.ExecuteReader())
                        {
                            checkedin = getCheckinStatusResult.Read();
                        }
                    }
                    if (checkedin) { this.labelStatus.Text = "Romreservasjonen har allerede foretatt innsjekking."; }

                    // Check that date for checkin is today
                    query = "SELECT datefrom FROM room_reservation " +
                            "WHERE room_reservationid = @reservationid";
                    using (MySqlCommand getCheckinDateCmd = new MySqlCommand(query, conn))
                    {
                        getCheckinDateCmd.Parameters.AddWithValue("@reservationid", reservationid);
                        using (MySqlDataReader getCheckinDateResult = getCheckinDateCmd.ExecuteReader())
                        {
                            if (getCheckinDateResult.Read())
                            {
                                DateTime date = getCheckinDateResult.GetDateTime(0);
                                if (date != DateTime.Today) { checkindate = false; }
                            }
                        }
                    }
                    if (!checkindate) { this.labelStatus.Text = "Romreservasjonen er ikke markert for innsjekking i dag."; }

                    // Check if room is clean
                    query = "SELECT code FROM housekeeping " +
                            "WHERE roomid = @roomid AND isactive = '1'";
                    using (MySqlCommand getHousekeepingStatusCmd = new MySqlCommand(query, conn))
                    {
                        getHousekeepingStatusCmd.Parameters.AddWithValue("@roomid", roomid);
                        using (MySqlDataReader getHousekeepingsResult = getHousekeepingStatusCmd.ExecuteReader())
                        {
                            // Room is marked with a code in the database
                            if (getHousekeepingsResult.Read())
                            {
                                int code = getHousekeepingsResult.GetInt32(0);
                                switch (code)
                                {
                                    case 0:
                                        roomstatus = 0;
                                        this.labelStatus.Text = "Rommet er utilgjengelig på grunn av vedlikehold, " +
                                                                "vennligst endre reservasjonen eller oppgrader kunden.";
                                        break;
                                    case 1:
                                        roomstatus = 1;
                                        this.labelStatus.Text = "Rommet trenger inspeksjon, " +
                                                                "vennligst endre reservasjonen eller send personalet inn umiddelbart.";
                                        break;
                                    case 2:
                                        roomstatus = 1;
                                        this.labelStatus.Text = "Rommet trenger rengjøring av personalet, " +
                                                                "vennligst endre reservasjonen eller send personalet inn umiddelbart.";
                                        break;
                                }
                            }
                        }
                    }

                    // Check if room is cleared for checkin
                    switch (roomstatus)
                    {
                        // Deny checkin of a room that is flagged as inactive
                        case 0:
                            roomcleared = false;
                            break;
                        // Option to continue if room has a warning code and other arrangements cant be made
                        case 1:
                            DialogResult continueCheckin = MessageBox.Show("Rommet er flagget for rengjøring og bør inspiseres\n" +
                                                                           "Er du sikker på at du vil fortsette?", "Advarsel!", MessageBoxButtons.YesNo);
                            if (continueCheckin == DialogResult.Yes) { roomcleared = true; }
                            else if (continueCheckin == DialogResult.No) { roomcleared = false; }
                            break;
                        // No code on room
                        case 2:
                            roomcleared = true;
                            break;
                    }

                    // Proceed with checkin
                    if (!checkedin && checkindate && roomcleared)
                    {
                        // Fetch guestid
                        query = "SELECT guestid FROM room_reservation " +
                                "WHERE room_reservationid = @reservationid";
                        using (MySqlCommand getGuestidCmd = new MySqlCommand(query, conn))
                        {
                            getGuestidCmd.Parameters.AddWithValue("@reservationid", reservationid);
                            using (MySqlDataReader getGuestidResult = getGuestidCmd.ExecuteReader())
                            {
                                getGuestidResult.Read();
                                guestid = getGuestidResult.GetInt32(0);
                            }
                        }

                        // Fetch room type for folio_item
                        query = "SELECT room_type.room_typeid FROM room_reservation " +
                                "LEFT JOIN room ON room_reservation.roomid = room.roomid " +
                                "LEFT JOIN room_type ON room.room_typeid = room_type.room_typeid " +
                                "WHERE room_reservationid = @reservationid";
                        using (MySqlCommand getRoomtypeCmd = new MySqlCommand(query, conn))
                        {
                            getRoomtypeCmd.Parameters.AddWithValue("@reservationid", reservationid);
                            using (MySqlDataReader getRoomtypeResult = getRoomtypeCmd.ExecuteReader())
                            {
                                getRoomtypeResult.Read();
                                int roomtypeid = getRoomtypeResult.GetInt32(0);
                                switch (roomtypeid)
                                {
                                    case 1:
                                        billingitemid = 1;
                                        break;
                                    case 2:
                                        billingitemid = 2;
                                        break;
                                    case 3:
                                        billingitemid = 3;
                                        break;
                                    case 4:
                                        billingitemid = 4;
                                        break;
                                    case 5:
                                        billingitemid = 5;
                                        break;
                                    case 6:
                                        billingitemid = 6;
                                        break;
                                }
                            }
                        }

                        // Check if unpaid folio exists
                        query = "SELECT folioid FROM folio " +
                                "WHERE guestid = @guestid AND paiddate IS NULL";
                        using (MySqlCommand getFolioCmd = new MySqlCommand(query, conn))
                        {
                            getFolioCmd.Parameters.AddWithValue("@guestid", guestid);
                            using (MySqlDataReader getFolioResult = getFolioCmd.ExecuteReader())
                            {
                                if (getFolioResult.Read())
                                {
                                    folioexists = true;
                                    folioid = getFolioResult.GetInt32(0);
                                    // Add new folio items for room charge to existing folio
                                    query = "INSERT INTO folio_item (folioid, billing_itemid, createddate, createdby) " +
                                            "VALUES (@folioid, @billingitemid, CURDATE(), @adminid)";
                                    using (MySqlCommand newFolioItemCmd = new MySqlCommand(query, conn))
                                    {
                                        newFolioItemCmd.Parameters.AddWithValue("@folioid", folioid);
                                        newFolioItemCmd.Parameters.AddWithValue("@billingitemid", billingitemid);
                                        newFolioItemCmd.Parameters.AddWithValue("@adminid", adminid);
                                        // Calculate amount of days and add a folio item for every day
                                        DateTime datefrom = Convert.ToDateTime(this.dataGridViewRoom.CurrentRow.Cells[4].Value.ToString());
                                        DateTime dateto = Convert.ToDateTime(this.dataGridViewRoom.CurrentRow.Cells[5].Value.ToString());
                                        int days = Convert.ToInt32(Math.Floor((dateto - datefrom).TotalDays));
                                        for (int i = 0; i < days; i++)
                                        {
                                            newFolioItemCmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }

                        if (!folioexists)
                        {
                            // Create new folio if none exists
                            query = "INSERT INTO folio (guestid, createddate, createdby) " +
                                    "VALUES (@guestid, CURDATE(), @adminid)";
                            using (MySqlCommand newFolioCmd = new MySqlCommand(query, conn))
                            {
                                newFolioCmd.Parameters.AddWithValue("@guestid", guestid);
                                newFolioCmd.Parameters.AddWithValue("@adminid", adminid);
                                newFolioCmd.ExecuteNonQuery();
                                // Save id for use in folio_item table
                                folioid = newFolioCmd.LastInsertedId;
                            }

                            // Add new folio items for room charge
                            query = "INSERT INTO folio_item (folioid, billing_itemid, createddate, createdby) " +
                                    "VALUES (@folioid, @billingitemid, CURDATE(), @adminid)";
                            using (MySqlCommand newFolioItemCmd = new MySqlCommand(query, conn))
                            {
                                newFolioItemCmd.Parameters.AddWithValue("@folioid", folioid);
                                newFolioItemCmd.Parameters.AddWithValue("@billingitemid", billingitemid);
                                newFolioItemCmd.Parameters.AddWithValue("@adminid", adminid);
                                // Calculate amount of days and add a folio item for every day
                                DateTime datefrom = Convert.ToDateTime(this.dataGridViewRoom.CurrentRow.Cells[4].Value.ToString());
                                DateTime dateto = Convert.ToDateTime(this.dataGridViewRoom.CurrentRow.Cells[5].Value.ToString());
                                int days = Convert.ToInt32(Math.Floor((dateto - datefrom).TotalDays));
                                for (int i = 0; i < days; i++)
                                {
                                    newFolioItemCmd.ExecuteNonQuery();
                                }
                            }
                        }

                        // Mark room as checked in
                        query = "UPDATE room_reservation " +
                                "SET ischeckedin = 1 " +
                                "WHERE room_reservationid = @reservationid";
                        using (MySqlCommand setRoomCheckinCmd = new MySqlCommand(query, conn))
                        {
                            setRoomCheckinCmd.Parameters.AddWithValue("@reservationid", reservationid);
                            setRoomCheckinCmd.ExecuteNonQuery();
                            this.labelStatus.Text = "Reservasjonen for romnummer " + roomid + " er flagget som innsjekket og folio lagt til.";
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

        // Button 'Sjekk ut' in the room section
        // Checkout process
        // Validation: Room is marked as checked in > Date for checkout is today -> Guest has active message
        // Checkout: Potential reimbursement -> Payment process -> 
        // Mark folio with paid or due date -> Mark room for housekeeping -> Mark room reservation as checked out and inactive
        private void buttonSjekkutRoom_Click(object sender, EventArgs e)
        {
            // Validation variables
            Boolean checkedout = false;
            Boolean checkoutdate = true;
            Boolean checkoutwarning = false;
            Boolean foliopaid = false;
            Decimal foliototal;
            Boolean message = false;
            int roomcount;
            // Reference variables
            int billingitemid = 0;
            long folioid;
            int guestid;
            int roomid = Convert.ToInt32(this.dataGridViewRoom.CurrentRow.Cells[2].Value);
            int reservationid = Convert.ToInt32(this.dataGridViewRoom.CurrentRow.Cells[0].Value);
            using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
            {
                try
                {
                    // Connect to database
                    conn.Open();
                    // Check that room is not already checked out
                    query = "SELECT ischeckedin FROM room_reservation " +
                            "WHERE room_reservationid = @reservationid AND ischeckedin = '0'";
                    using (MySqlCommand getCheckoutStatusCmd = new MySqlCommand(query, conn))
                    {
                        getCheckoutStatusCmd.Parameters.AddWithValue("@reservationid", reservationid);
                        using (MySqlDataReader getCheckoutStatusResult = getCheckoutStatusCmd.ExecuteReader())
                        {
                            checkedout = getCheckoutStatusResult.Read();
                        }
                    }
                    if (checkedout) { this.labelStatus.Text = "Romreservasjonen har allerede foretatt utsjekking."; }

                    else
                    {
                        // Check that date for checkout is today
                        query = "SELECT dateto FROM room_reservation " +
                                "WHERE room_reservationid = @reservationid";
                        using (MySqlCommand getCheckoutDateCmd = new MySqlCommand(query, conn))
                        {
                            getCheckoutDateCmd.Parameters.AddWithValue("@reservationid", reservationid);
                            using (MySqlDataReader getCheckoutDateResult = getCheckoutDateCmd.ExecuteReader())
                            {
                                if (getCheckoutDateResult.Read())
                                {
                                    // Room is not marked for checkout today
                                    DateTime date = getCheckoutDateResult.GetDateTime(0);
                                    if (date != DateTime.Today) { checkoutdate = false; }
                                }
                            }
                        }

                        // Yes/no continue dialogue if checkout is early
                        if (!checkoutdate)
                        {
                            DialogResult continueCheckout = MessageBox.Show("Rommet er ikke flagget for utsjekking i dag\n" +
                                                                            "Er du sikker på at du vil fortsette?", "Advarsel!", MessageBoxButtons.YesNo);
                            if (continueCheckout == DialogResult.Yes)
                            {
                                checkoutwarning = true;
                                checkoutdate = true;
                            }
                        }

                        // Proceed with checkout process
                        if (checkoutdate)
                        {
                            // Fetch guestid
                            query = "SELECT guestid FROM room_reservation " +
                                    "WHERE room_reservationid = @reservationid";
                            using (MySqlCommand getGuestidCmd = new MySqlCommand(query, conn))
                            {
                                getGuestidCmd.Parameters.AddWithValue("@reservationid", reservationid);
                                using (MySqlDataReader getGuestidResult = getGuestidCmd.ExecuteReader())
                                {
                                    getGuestidResult.Read();
                                    guestid = getGuestidResult.GetInt32(0);
                                }
                            }

                            // Check if guest has undelivered messages
                            query = "SELECT sender, message, createddatetime FROM message " +
                                    "WHERE guestid = @guestid AND isactive = '1'";
                            using (MySqlCommand getMessageCmd = new MySqlCommand(query, conn))
                            {
                                getMessageCmd.Parameters.AddWithValue("@guestid", guestid);
                                using (MySqlDataReader getMessageResult = getMessageCmd.ExecuteReader())
                                {
                                    // Deliver messages
                                    while (getMessageResult.Read())
                                    {
                                        MessageBox.Show("Fra: " + getMessageResult.GetString(0) +
                                                        "\nDato mottatt: " + getMessageResult.GetDateTime(2) +
                                                        "\nInnhold: " + getMessageResult.GetString(1) + "", "Melding til gjest");
                                        message = true;
                                    }
                                }
                            }

                            // Mark messages as inactive if any
                            if (message)
                            {
                                query = "UPDATE message " +
                                        "SET isactive = 0 " +
                                        "WHERE guestid = @guestid";
                                using (MySqlCommand setMessageInactiveCmd = new MySqlCommand(query, conn))
                                {
                                    setMessageInactiveCmd.Parameters.AddWithValue("@guestid", guestid);
                                    setMessageInactiveCmd.ExecuteNonQuery();
                                    this.labelStatus.Text = "Meldinger markert som inaktive.";
                                }
                            }

                            // Check if guest has more than one room reservation checked in
                            query = "SELECT COUNT(room_reservationid) FROM room_reservation " +
                                    "WHERE guestid = @guestid AND ischeckedin = '1'";
                            using (MySqlCommand getRoomCountCmd = new MySqlCommand(query, conn))
                            {
                                getRoomCountCmd.Parameters.AddWithValue("@guestid", guestid);
                                roomcount = Convert.ToInt32(getRoomCountCmd.ExecuteScalar());
                            }

                            // Delete folio items if checkout is early
                            // Delay reimbursement until last room is being checked out
                            if (checkoutwarning && roomcount == 1)
                            {
                                // Fetch room type for folio_item
                                query = "SELECT room_type.room_typeid FROM room_reservation " +
                                        "LEFT JOIN room ON room_reservation.roomid = room.roomid " +
                                        "LEFT JOIN room_type ON room.room_typeid = room_type.room_typeid " +
                                        "WHERE room_reservationid = @reservationid";
                                using (MySqlCommand getRoomtypeCmd = new MySqlCommand(query, conn))
                                {
                                    getRoomtypeCmd.Parameters.AddWithValue("@reservationid", reservationid);
                                    using (MySqlDataReader getRoomtypeResult = getRoomtypeCmd.ExecuteReader())
                                    {
                                        getRoomtypeResult.Read();
                                        int roomtypeid = getRoomtypeResult.GetInt32(0);
                                        switch (roomtypeid)
                                        {
                                            case 1:
                                                billingitemid = 1;
                                                break;
                                            case 2:
                                                billingitemid = 2;
                                                break;
                                            case 3:
                                                billingitemid = 3;
                                                break;
                                            case 4:
                                                billingitemid = 4;
                                                break;
                                            case 5:
                                                billingitemid = 5;
                                                break;
                                            case 6:
                                                billingitemid = 6;
                                                break;
                                        }
                                    }
                                }

                                // Fetch folioid
                                query = "SELECT folioid FROM folio " +
                                        "WHERE guestid = @guestid AND paiddate IS NULL";
                                using (MySqlCommand getFolioCmd = new MySqlCommand(query, conn))
                                {
                                    getFolioCmd.Parameters.AddWithValue("@guestid", guestid);
                                    using (MySqlDataReader getFolioResult = getFolioCmd.ExecuteReader())
                                    {
                                        getFolioResult.Read();
                                        folioid = getFolioResult.GetInt32(0);
                                    }

                                    // Calculate amount of days refunded
                                    DateTime datefrom = Convert.ToDateTime(this.dataGridViewRoom.CurrentRow.Cells[4].Value.ToString());
                                    DateTime dateto = Convert.ToDateTime(this.dataGridViewRoom.CurrentRow.Cells[5].Value.ToString());
                                    DateTime today = DateTime.Today;
                                    int days;
                                    // Always charge for 1 day even if departure is same day as arrival
                                    if (datefrom == today) { days = 1; }
                                    else { days = Convert.ToInt32(Math.Floor((dateto - today).TotalDays)); }
                                    // Delete unused folio items for room charge
                                    if (days > 0)
                                    {
                                        query = "DELETE FROM folio_item " +
                                                "WHERE billing_itemid = @billingitemid AND folioid = @folioid LIMIT @days";
                                        using (MySqlCommand newFolioItemCmd = new MySqlCommand(query, conn))
                                        {
                                            newFolioItemCmd.Parameters.AddWithValue("@billingitemid", billingitemid);
                                            newFolioItemCmd.Parameters.AddWithValue("@folioid", folioid);
                                            newFolioItemCmd.Parameters.AddWithValue("@days", days);
                                            newFolioItemCmd.ExecuteNonQuery();
                                            this.labelStatus.Text = days + " dager trukket fra regningen.";
                                        }
                                    }
                                }
                            }

                            // Payment process
                            // Delay payment until last room is being checked out
                            if (roomcount == 1)
                            {
                                // Fetch folioid
                                query = "SELECT folioid FROM folio " +
                                        "WHERE guestid = @guestid AND paiddate IS NULL";
                                using (MySqlCommand getFolioCmd = new MySqlCommand(query, conn))
                                {
                                    getFolioCmd.Parameters.AddWithValue("@guestid", guestid);
                                    using (MySqlDataReader getFolioResult = getFolioCmd.ExecuteReader())
                                    {
                                        getFolioResult.Read();
                                        folioid = getFolioResult.GetInt32(0);
                                    }

                                    // Fetch folio items and sum up total cost
                                    query = "SELECT SUM(cost) FROM folio AS F " +
                                            "LEFT JOIN folio_item AS FI ON F.folioid = FI.folioid " +
                                            "LEFT JOIN billing_item AS BI ON FI.billing_itemid = BI.billing_itemid " +
                                            "WHERE F.folioid = @folioid";
                                    using (MySqlCommand getFolioTotalCmd = new MySqlCommand(query, conn))
                                    {
                                        getFolioTotalCmd.Parameters.AddWithValue("@folioid", folioid);
                                        using (MySqlDataReader getFolioTotalResult = getFolioTotalCmd.ExecuteReader())
                                        {
                                            // Print for receptionist and give option to pay now or send invoice
                                            getFolioTotalResult.Read();
                                            foliototal = getFolioTotalResult.GetDecimal(0);
                                        }
                                    }
                                }

                                // Payment options
                                // Yes -> Cash/card, No -> Invoice bill
                                DialogResult paymentCheckout = MessageBox.Show("Å betale: " + foliototal +
                                                                               "\nTrykk 'Ja' for straksbetaling med kontakt eller kort, 'Nei' for å sende faktura ", "Betaling for opphold", MessageBoxButtons.YesNo);

                                if (paymentCheckout == DialogResult.Yes)
                                {
                                    // Mark folio as paid
                                    DateTime date = DateTime.Today;
                                    query = "UPDATE folio " +
                                            "SET paiddate = @date " +
                                            "WHERE folioid = @folioid";
                                    using (MySqlCommand setHousekeepingCmd = new MySqlCommand(query, conn))
                                    {
                                        setHousekeepingCmd.Parameters.AddWithValue("@date", date);
                                        setHousekeepingCmd.Parameters.AddWithValue("@folioid", folioid);
                                        setHousekeepingCmd.ExecuteNonQuery();
                                    }
                                }
                                else if (paymentCheckout == DialogResult.No)
                                {
                                    // Mark folio with duedate
                                    DateTime date = DateTime.Today.AddDays(21);
                                    query = "UPDATE folio " +
                                            "SET duedate = @date " +
                                            "WHERE folioid = @folioid";
                                    using (MySqlCommand setHousekeepingCmd = new MySqlCommand(query, conn))
                                    {
                                        setHousekeepingCmd.Parameters.AddWithValue("@date", date);
                                        setHousekeepingCmd.Parameters.AddWithValue("@folioid", folioid);
                                        setHousekeepingCmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            // Mark room for housekeeping inspection
                            query = "INSERT INTO housekeeping (roomid, code, isactive) " +
                                    "VALUES (@roomid, '2', '1')";
                            using (MySqlCommand setHousekeepingCmd = new MySqlCommand(query, conn))
                            {
                                setHousekeepingCmd.Parameters.AddWithValue("@roomid", roomid);
                                setHousekeepingCmd.ExecuteNonQuery();
                                this.labelStatus.Text = "Rom flagget for rengjøring.";
                            }

                            // Mark booking as inactive and checked out
                            query = "UPDATE room_reservation " +
                                    "SET isactive = 0, ischeckedin = 0 " +
                                    "WHERE room_reservationid = @reservationid";
                            using (MySqlCommand setMessageInactiveCmd = new MySqlCommand(query, conn))
                            {
                                setMessageInactiveCmd.Parameters.AddWithValue("@reservationid", reservationid);
                                setMessageInactiveCmd.ExecuteNonQuery();
                                this.labelStatus.Text = "Reservasjonen for romnummer " + roomid + " er flagget som utsjekket og rommet frigitt.";
                            }

                            // Refresh data
                            DisplayDefaultRoom();
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

        // Button 'Søk' in the room section
        // Searches result in relevant tables from textinput
        private void buttonSearchBookingRoom_Click(object sender, EventArgs e)
        {
            string searchinput = @textBoxSearch.Text.Trim();

            using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
            {
                try
                {
                    // Connect to database
                    conn.Open();
                    query = "SELECT RR.room_reservationid, CONCAT(G.firstname, ' ', G.lastname) AS guest_name, " +
                            "R.roomid, RT.name, RR.datefrom, RR.dateto, RR.remark, RR.ischeckedin FROM room_reservation RR " +
                            "JOIN guest G " +
                            "ON RR.guestid = G.guestid " +
                            "JOIN room R " +
                            "ON RR.roomid = R.roomid " +
                            "JOIN room_type RT " +
                            "ON R.room_typeid = RT.room_typeid " +
                            "WHERE (CONCAT(G.firstname, ' ', G.lastname) LIKE @search " +
                            "OR R.roomid LIKE @search) " +
                            "AND isactive='1' " +
                            "ORDER BY datefrom, lastname, firstname";
                    using (MySqlCommand bookingRoomSearchCmd = new MySqlCommand(query, conn))
                    {
                        bookingRoomSearchCmd.Parameters.AddWithValue("@search", "%" + searchinput + "%");
                        using (MySqlDataAdapter bookingRoomSearchAdapter = new MySqlDataAdapter(bookingRoomSearchCmd))
                        {
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
                            dataGridViewRoom.Columns[6].HeaderText = "Merknad";
                        }
                    }
                }
                // Catch exceptions and display in labelStatus
                catch (Exception ex) { this.labelStatus.Text = ex.Message; }
                // Make sure connection is closed
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    { conn.Close(); }
                }
            }
        }

        // Button 'I dag' in the room section
        // Display room reservations for today
        private void buttonDisplayRoomDay_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            string date = today.ToString("yyyy-MM-dd");
            query = "SELECT RR.room_reservationid, CONCAT(G.firstname, ' ', G.lastname) AS guest_name, " +
                    "R.roomid, RT.name, RR.datefrom, RR.dateto, RR.remark, RR.ischeckedin FROM room_reservation AS RR " +
                    "JOIN guest AS G " +
                    "ON RR.guestid = G.guestid " +
                    "JOIN room AS R " +
                    "ON RR.roomid = R.roomid " +
                    "JOIN room_type AS RT " +
                    "ON R.room_typeid = RT.room_typeid " +
                    "WHERE (datefrom = '" + date + "' OR dateto ='" + date + "') " +
                    "AND RR.isactive = '1' " +
                    "ORDER BY datefrom, lastname, firstname";
            LoadDataRoom(query);
        }

        // Button 'Denne uke' in the room section
        // Display room reservation for this week
        private void buttonDisplayRoomWeek_Click(object sender, EventArgs e)
        {
            // Find this weeks start date and convert to readable format for MySQL
            DateTime startofweek = CalculateDate.GetFirstDayOfWeek(DateTime.Today);
            DateTime endofweek = startofweek.AddDays(7);
            string startdate = startofweek.ToString("yyyy-MM-dd");
            string enddate = endofweek.ToString("yyyy-MM-dd");
            query = "SELECT RR.room_reservationid, CONCAT(G.firstname, ' ', G.lastname) AS guest_name, " +
                    "R.roomid, RT.name, RR.datefrom, RR.dateto, RR.remark, RR.ischeckedin FROM room_reservation AS RR " +
                    "JOIN guest AS G " +
                    "ON RR.guestid = G.guestid " +
                    "JOIN room AS R " +
                    "ON RR.roomid = R.roomid " +
                    "JOIN room_type AS RT " +
                    "ON R.room_typeid = RT.room_typeid " +
                    "WHERE (datefrom BETWEEN '" + startdate + "' AND '" + enddate + "' " +
                    "OR dateto BETWEEN '" + startdate + "' AND '" + enddate +  "') " +
                    "AND RR.isactive = '1' " +
                    "ORDER BY datefrom, lastname, firstname";
            LoadDataRoom(query);
        }

        // Button 'Denne mnd' in the room section
        // Display room reservations for this month (default view)
        private void buttonDisplayRoomMonth_Click(object sender, EventArgs e)
        {
            DisplayDefaultRoom();
        }

        // Button 'Alle' in the room section
        // Display all room reservations
        private void buttonDisplayRoomAll_Click(object sender, EventArgs e)
        {
            query = "SELECT RR.room_reservationid, CONCAT(G.firstname, ' ', G.lastname) AS guest_name, " +
                    "R.roomid, RT.name, RR.datefrom, RR.dateto, RR.remark, RR.ischeckedin FROM room_reservation AS RR " +
                    "JOIN guest AS G " +
                    "ON RR.guestid = G.guestid " +
                    "JOIN room AS R " +
                    "ON RR.roomid = R.roomid " +
                    "JOIN room_type AS RT " +
                    "ON R.room_typeid = RT.room_typeid " +
                    "WHERE RR.isactive = '1' " +
                    "ORDER BY datefrom, lastname, firstname";
            LoadDataRoom(query);
        }

        //
        // Hall section
        //

        // DataGridViewRoom double click
        // Open specialized edit form
        private void dataGridViewHall_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Boolean checkedin = false;
            int reservationid = Convert.ToInt32(this.dataGridViewHall.CurrentRow.Cells[0].Value);

            using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
            {
                try
                {
                    // Connect to database
                    conn.Open();
                    // Check that hall is not already checked in to
                    query = "SELECT ischeckedin FROM hall_reservation " +
                            "WHERE hall_reservationid = @reservationid AND ischeckedin = '1'";
                    using (MySqlCommand getCheckinStatusCmd = new MySqlCommand(query, conn))
                    {
                        getCheckinStatusCmd.Parameters.AddWithValue("@reservationid", reservationid);
                        using (MySqlDataReader getCheckinStatusResult = getCheckinStatusCmd.ExecuteReader())
                        {
                            checkedin = getCheckinStatusResult.Read();
                        }
                    }

                    if (checkedin) { this.labelStatus.Text = "Hallreservasjon har allerede foretatt innsjekking og kan ikke endres."; }
                    else
                    {
                        // Set database record ID for reference
                        DBConn.QueryID = Convert.ToInt32(this.dataGridViewHall.CurrentRow.Cells[0].Value);
                        Form editForm = new EditBookingRoom();
                        editForm.ShowDialog();
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

        // Button 'Ny' in the hall section, open new form
        // Open specialized add form
        private void buttonNewBookingHall_Click(object sender, EventArgs e)
        {
            // TODO: Same as new room, but for hall
        }

        // Button 'Endre' in the hall section
        // Open specialized edit form, identical to DataGridViewRoom double click
        private void buttonEditBookingHall_Click(object sender, EventArgs e)
        {
            // TODO: Same as edit room, but for hall
        }

        // Button 'Slett' in the hall section
        // Remove isactive flag on selected record
        private void buttonDeleteBookingHall_Click(object sender, EventArgs e)
        {
            // TODO: Update MySQL parameter isactive to 0
        }

        // Button 'Søk' in the hall section
        // Searches result in relevant tables from textinput
        private void buttonSearchBookingHall_Click(object sender, EventArgs e)
        {
            // TODO: Same as search room, but for hall
        }

        // Button 'Sjekk inn' in the hall section
        private void buttonSjekkinnHall_Click(object sender, EventArgs e)
        {
            // TODO: Checkin process
        }

        // Button 'Sjekk ut' in the hall section
        private void buttonSjekkutHall_Click(object sender, EventArgs e)
        {
            // TODO: Checkout process
        }

        // Button 'I dag' in the hall section
        // Display hall reservations for today
        private void buttonDisplayHallDay_Click(object sender, EventArgs e)
        {

        }

        // Button 'Denne uke' in the hall section
        // Display hall reservations for this week
        private void buttonDisplayHallWeek_Click(object sender, EventArgs e)
        {

        }

        // Button 'Denne mnd' in the hall section
        // Display hall reservations for this month (default view)
        private void buttonDisplayHallMonth_Click(object sender, EventArgs e)
        {

        }

        // Button 'Alle' in the hall section
        // Display all hall reservations
        private void buttonDisplayHallAll_Click(object sender, EventArgs e)
        {

        }
    }
}
