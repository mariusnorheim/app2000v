using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MySql.Data;
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

        // Set controls visibility for submenu button 'Rom'
        public void LoadControlsRoom()
        {
            buttonNewBookingRoom.Visible = true;
            buttonEditBookingRoom.Visible = true;
            buttonDeleteBookingRoom.Visible = true;
            buttonCheckinRoom.Visible = true;
            buttonCheckoutRoom.Visible = true;
            buttonSearchBookingRoom.Visible = true;
            buttonDisplayRoomDay.Visible = true;
            buttonDisplayRoomWeek.Visible = true;
            buttonDisplayRoomMonth.Visible = true;
            buttonDisplayRoomAll.Visible = true;
            buttonNewBookingHall.Visible = false;
            buttonEditBookingHall.Visible = false;
            buttonDeleteBookingHall.Visible = false;
            buttonCheckinHall.Visible = false;
            buttonCheckoutHall.Visible = false;
            buttonSearchBookingHall.Visible = false;
            buttonDisplayHallDay.Visible = false;
            buttonDisplayHallWeek.Visible = false;
            buttonDisplayHallMonth.Visible = false;
            buttonDisplayHallAll.Visible = false;
            this.AcceptButton = buttonSearchBookingRoom;
        }

        // Load dataGridViewRoom and make sure its visible
        public void LoadDataGridViewRoom()
        {
            dataGridViewHall.Visible = false;
            dataGridViewRoom.Visible = true;
            // Hide ID and make readable table headers
            dataGridViewRoom.Columns[0].Name = "ReservationID";
            dataGridViewRoom.Columns[0].Visible = false;
            dataGridViewRoom.Columns[1].Name = "Firstname";
            dataGridViewRoom.Columns[1].HeaderText = "Firstname";
            dataGridViewRoom.Columns[2].Name = "Lastname";
            dataGridViewRoom.Columns[2].HeaderText = "Lastname";
            dataGridViewRoom.Columns[3].Name = "Room";
            dataGridViewRoom.Columns[3].HeaderText = "Room";
            dataGridViewRoom.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRoom.Columns[4].Name = "Checkedin";
            dataGridViewRoom.Columns[4].HeaderText = "Checkedin";
            dataGridViewRoom.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRoom.Columns[5].Name = "Roomtype";
            dataGridViewRoom.Columns[5].HeaderText = "Roomtype";
            dataGridViewRoom.Columns[6].Name = "Datefrom";
            dataGridViewRoom.Columns[6].HeaderText = "Arrival";
            dataGridViewRoom.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRoom.Columns[7].Name = "Dateto";
            dataGridViewRoom.Columns[7].HeaderText = "Departure";
            dataGridViewRoom.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRoom.Columns[8].Name = "Remark";
            dataGridViewRoom.Columns[8].HeaderText = "Remark";
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

        // Default room display (monthly)
        public void DisplayDefaultRoom()
        {
            // Find this weeks start date and convert to readable format for MySQL
            DateTime today = DateTime.Today;
            DateTime datefrom = new DateTime(today.Year, today.Month, 1);
            DateTime dateto = datefrom.AddMonths(1).AddDays(-1);
            // Fetch dataset
            DataSet roomreservationDS = DBGetData.GetRoomBookingsBetweenDates(datefrom, dateto);

            if (roomreservationDS != null)
            {
                // No tables fetched
                if (roomreservationDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if (roomreservationDS.Tables[0].Rows.Count == 0)
                {
                    new StatusMessage("No datarows found for this month.");
                    return;
                }
                // Clear labelStatus for previous messages
                else
                {
                    new StatusMessage("");
                }

                // Set the dataset as source for datagridview and make sure its displayed
                dataGridViewRoom.DataSource = roomreservationDS;
                dataGridViewRoom.DataMember = "Get_RR_BetweenDates";
                LoadDataGridViewRoom();
            }
        }

        // Button 'All' in the room section
        // Display all room reservations
        private void buttonDisplayRoomAll_Click(object sender, EventArgs e)
        {
            // Fetch dataset
            DataSet roomreservationDS = DBGetData.GetRoomBookingsAll(1);

            if (roomreservationDS != null)
            {
                // No tables fetched
                if (roomreservationDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if (roomreservationDS.Tables[0].Rows.Count == 0)
                {
                    new StatusMessage("No datarows found in table.");
                    return;
                }
                // Clear labelStatus for previous messages
                else
                {
                    new StatusMessage("");
                }

                // Set the dataset as source for datagridview and make sure its displayed
                dataGridViewRoom.DataSource = roomreservationDS;
                dataGridViewRoom.DataMember = "Get_RR_All";
                LoadDataGridViewRoom();
            }
        }

        // Button 'Month' in the room section
        // Display room reservations for this month (default view)
        private void buttonDisplayRoomMonth_Click(object sender, EventArgs e)
        {
            DisplayDefaultRoom();
        }

        // Button 'Week' in the room section
        // Display room reservation for this week
        private void buttonDisplayRoomWeek_Click(object sender, EventArgs e)
        {
            // Find this weeks start date and convert to readable format for MySQL
            DateTime datefrom = CalculateDate.GetFirstDayOfWeek(DateTime.Today);
            DateTime dateto = datefrom.AddDays(7);

            // Fetch dataset
            DataSet roomreservationDS = DBGetData.GetRoomBookingsBetweenDates(datefrom, dateto);

            if (roomreservationDS != null)
            {
                // No tables fetched
                if (roomreservationDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if (roomreservationDS.Tables[0].Rows.Count == 0)
                {
                    new StatusMessage("No datarows found for this week.");
                    return;
                }
                // Clear labelStatus for previous messages
                else
                {
                    new StatusMessage("");
                }

                // Set the dataset as source for datagridview and make sure its displayed
                dataGridViewRoom.DataSource = roomreservationDS;
                dataGridViewRoom.DataMember = "Get_RR_BetweenDates";
                LoadDataGridViewRoom();
            }
        }

        // Button 'Today' in the room section
        // Display room reservations for today
        private void buttonDisplayRoomDay_Click(object sender, EventArgs e)
        {
            // Find date for today
            DateTime today = DateTime.Today;

            // Fetch dataset
            DataSet roomreservationDS = DBGetData.GetRoomBookingsSpesificDate(today);

            if (roomreservationDS != null)
            {
                // No tables fetched
                if (roomreservationDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if (roomreservationDS.Tables[0].Rows.Count == 0)
                {
                    new StatusMessage("No datarows found for today.");
                    return;
                }
                // Clear labelStatus for previous messages
                else
                {
                    new StatusMessage("");
                }

                // Set the dataset as source for datagridview and make sure its displayed
                dataGridViewRoom.DataSource = roomreservationDS;
                dataGridViewRoom.DataMember = "Get_RR_SpesificDate";
                LoadDataGridViewRoom();
            }
        }

        // DataGridViewRoom double click
        // Open specialized edit form
        private void dataGridViewRoom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Boolean checkedin = false;

            if (dataGridViewRoom.SelectedRows.Count > 0)
            {
                int reservationid = Convert.ToInt32(dataGridViewRoom.CurrentRow.Cells[0].Value);

                if (DBGetData.GetRoomCheckedin(reservationid) > 0) { checkedin = true; }
                if (checkedin) { new StatusMessage("Room reservation has already checked in and cant be changed."); }
                else
                {
                    // Set database record ID for reference
                    DBGetData.QueryID = reservationid;
                    Form editForm = new EditBookingRoom();
                    editForm.ShowDialog();
                }
            }
        }

        // Button 'New' in the room section
        // Open specialized add form
        private void buttonNewBookingRoom_Click(object sender, EventArgs e)
        {
            Form bookingForm = new NewBookingRoom();
            bookingForm.ShowDialog();
        }

        // Button 'Edit' in the room section
        // Open specialized edit form, identical to DataGridViewRoom double click
        private void buttonEditBookingRoom_Click(object sender, EventArgs e)
        {
            Boolean checkedin = false;

            if (dataGridViewRoom.SelectedRows.Count > 0)
            {
                int reservationid = Convert.ToInt32(dataGridViewRoom.CurrentRow.Cells[0].Value);

                if (DBGetData.GetRoomCheckedin(reservationid) > 0) { checkedin = true; }
                if (checkedin) { new StatusMessage("Room reservation has already checked in and cant be changed."); }
                else
                {
                    // Set database record ID for reference
                    DBGetData.QueryID = reservationid;
                    Form editForm = new EditBookingRoom();
                    editForm.ShowDialog();
                }
            }
        }

        // Button 'Delete' in the room section
        // Remove isactive flag on selected record
        private void buttonDeleteBookingRoom_Click(object sender, EventArgs e)
        {
            if (dataGridViewRoom.SelectedRows.Count > 0)
            {
                Boolean checkedin = false;
                int reservationid = Convert.ToInt32(dataGridViewRoom.CurrentRow.Cells[0].Value);

                // Confirm delete
                DialogResult confirmCheckin = MessageBox.Show("Deleting room reservation with id " + reservationid +
                                                              "\nAre you sure you want to continue?", "Warning!", MessageBoxButtons.YesNo);

                if (confirmCheckin == DialogResult.Yes)
                {
                    if (DBGetData.GetRoomCheckedin(reservationid) > 0) { checkedin = true; }
                    if (checkedin) { new StatusMessage("Room reservation has already checked in and cant be deleted."); }
                    else
                    {
                        // Save entry to database
                        DBSetData.DeleteRoomReservation(reservationid);
                        new StatusMessage("Room reservation removed from active list.");
                    }

                    DisplayDefaultRoom();
                }
            }
        }

        // Button 'Check in' in the room section
        // Validation: Room is not marked as checked in already -> Date for checkin is today -> Room is clean
        // Checkin procedure: Create new folio or append existing -> Add folio items for room charge -> Mark room as checked in
        private void buttonCheckinRoom_Click(object sender, EventArgs e)
        {
            // Make sure datagridview has selection
            if (dataGridViewRoom.SelectedRows.Count > 0)
            {
                // Validation variables
                Boolean checkedin = false;
                Boolean checkindate = true;
                Boolean roomcleared = true;
                // Roomstatus values: 0 = deny checkin, 1 = warning, 2 = no flag
                int roomstatus = 2;
                // Reference variables
                string adminid = UserInfo.UserID;
                int reservationid = Convert.ToInt32(this.dataGridViewRoom.CurrentRow.Cells[0].Value);
                int roomid = Convert.ToInt32(this.dataGridViewRoom.CurrentRow.Cells[3].Value);

                // Confirm checkin
                DialogResult confirmCheckin = MessageBox.Show("Checking in roomnumber " + roomid +
                                                               "\nAre you sure you want to continue?", "Check in", MessageBoxButtons.YesNo);
                if (confirmCheckin == DialogResult.Yes)
                {
                    // Check that reservation is not already checked in
                    if (DBGetData.GetRoomCheckedin(reservationid) > 0) { checkedin = true; }
                    if (checkedin) { new StatusMessage("Room reservation has already checked in."); }

                    // Check that reservation checkin date is today
                    MySqlDataReader getRoomCheckinDate = DBGetData.GetRoomCheckinDate(reservationid);
                    if (getRoomCheckinDate.Read())
                    {
                        DateTime date = Convert.ToDateTime(getRoomCheckinDate[0]);
                        if (date != DateTime.Today) { checkindate = false; }
                        if (!checkindate) { new StatusMessage("Room reservation not marked for checkin today."); }
                    }
                    getRoomCheckinDate.Dispose();

                    // Check if room is clean
                    MySqlDataReader getHousekeepingCode = DBGetData.GetRoomHousekeeping(roomid);
                    if (getHousekeepingCode.Read())
                    {
                        int code = Convert.ToInt32(getHousekeepingCode[0]);
                        switch (code)
                        {
                            case 0:
                                roomstatus = 0;
                                new StatusMessage("Room unavailable due to maintainance, " +
                                    "please change reservation or upgrade guest.");
                                break;
                            case 1:
                                roomstatus = 1;
                                new StatusMessage("Room needs inspection, " +
                                                  "please change reservation or send staff immediately.");
                                break;
                            case 2:
                                roomstatus = 1;
                                new StatusMessage("Room needs cleaning, " +
                                                  "please change reservation or send staff immediately.");
                                break;
                        }
                    }
                    getHousekeepingCode.Dispose();

                    // Check if room is cleared for checkin
                    switch (roomstatus)
                    {
                        // Deny checkin of a room that is flagged as inactive
                        case 0:
                            roomcleared = false;
                            break;
                        // Option to continue if room has a warning code and other arrangements cant be made
                        case 1:
                            DialogResult continueCheckin = MessageBox.Show(
                                "Room is flagged for cleaning and should be inspected" +
                                "\nAre you sure you want to continue?", "Warning!", MessageBoxButtons.YesNo);
                            if (continueCheckin == DialogResult.Yes) { roomcleared = true; }
                            else if (continueCheckin == DialogResult.No) { roomcleared = false; }

                            break;
                        // No code on room
                        case 2:
                            roomcleared = true;
                            break;
                    }

                    // Proceed with checkin
                    if (!checkedin && checkindate && roomcleared && dataGridViewRoom.CurrentRow.Cells[0].Value != null || dataGridViewRoom.CurrentRow.Cells[3].Value != null)
                    {
                        DBSetData.CheckinRoomReservation(reservationid, adminid);
                        new StatusMessage("Room reservation for roomnumber " + roomid + " has been flagged as checked in and folio was added.");
                    }

                    DisplayDefaultRoom();
                }
            }
        }

        // Button 'Check out' in the room section
        // Validation: Room is marked as checked in > Date for checkout is today -> Guest has active messages
        // Checkout procedure: Potential reimbursement -> Payment process -> 
        // Mark folio with paid or due date -> Mark room for housekeeping -> Mark room reservation as checked out and inactive
        private void buttonCheckoutRoom_Click(object sender, EventArgs e)
        {
            // Make sure datagridview has selection
            if (dataGridViewRoom.SelectedRows.Count > 0)
            {
                // Validation variables
                Boolean checkedout = false;
                Boolean checkoutdate = true;
                Boolean message = false;
                // Reference variables
                int roomid = Convert.ToInt32(this.dataGridViewRoom.CurrentRow.Cells[3].Value);
                int reservationid = Convert.ToInt32(this.dataGridViewRoom.CurrentRow.Cells[0].Value);

                // Confirm checkout
                DialogResult confirmCheckout = MessageBox.Show("Checking out roomnumber " + roomid +
                                                               "\nAre you sure you want to continue?", "Check out", MessageBoxButtons.YesNo);
                if (confirmCheckout == DialogResult.Yes)
                {
                    // Check that reservation is not already checked in
                    if (DBGetData.GetRoomCheckedout(reservationid) > 0) { checkedout = true; }
                    if (checkedout) { new StatusMessage("Room reservation has not checked in or already checked out."); }

                    // Check that reservation checkout date is today
                    MySqlDataReader getRoomCheckoutDate = DBGetData.GetRoomCheckoutDate(reservationid);
                    if (getRoomCheckoutDate.Read())
                    {
                        DateTime date = Convert.ToDateTime(getRoomCheckoutDate[0]);
                        if (date != DateTime.Today) { checkoutdate = false; }
                        if (!checkoutdate) { new StatusMessage("Room reservation not marked for checkout today."); }
                    }
                    getRoomCheckoutDate.Dispose();

                    // Yes/no continue dialogue if checkout is early
                    if (!checkoutdate)
                    {
                        DialogResult continueCheckout = MessageBox.Show(
                            "Room is not flagged for checkout today" +
                            "\nAre you sure you want to continue?", "Warning!", MessageBoxButtons.YesNo);
                        if (continueCheckout == DialogResult.Yes) { checkoutdate = true; }
                    }

                    // Check if guest has undelivered messages
                    MySqlDataReader getRoomMessages = DBGetData.GetRoomMessages(reservationid);
                    while (getRoomMessages.Read())
                    {
                        MessageBox.Show("Date recieved: " + getRoomMessages.GetDateTime(0) +
                            "\nFrom: " + getRoomMessages.GetString(1) +
                            "\n\n" + getRoomMessages.GetString(2),
                            "Message to guest");
                        message = true;
                    }
                    getRoomMessages.Dispose();

                    // Mark messages as inactive if any
                    if (message) { DBSetData.UpdateMessagesRoomReservation(reservationid); }

                    // Check if guest has more than one room reservation checked in
                    int roomcount = DBGetData.GetRoomCount(reservationid);

                    if (!checkedout && checkoutdate && dataGridViewRoom.CurrentRow.Cells[0].Value != null || dataGridViewRoom.CurrentRow.Cells[3].Value != null)
                    {
                        // Do checkout process
                        DBSetData.CheckoutRoomReservation(reservationid);
                        new StatusMessage("Room reservation for roomnumber " + roomid + " has been flagged for housekeeping and checked out.");

                        // Print customer folio total for the last room checkout
                        if (roomcount == 1)
                        {
                            MySqlDataReader getFolioTotal = DBGetData.GetRoomCheckoutTotal(reservationid);
                            if (getFolioTotal.Read())
                            {
                                Decimal foliototal = getFolioTotal.GetDecimal(0);

                                // Payment options
                                // Yes -> Cash/card, No -> Invoice bill
                                DialogResult paymentCheckout = MessageBox.Show("Payment total: " + foliototal +
                                                                               "\n\n'Yes' for immidiate payment with cash or creditcard," +
                                                                               "\n'No' for invoice with due date 3 weeks from today.",
                                                                               "Payment options", MessageBoxButtons.YesNo);

                                // Mark folio as paid
                                if (paymentCheckout == DialogResult.Yes) { DBSetData.CheckoutFolioPaid(reservationid); }
                                // Mark folio with duedate
                                else if (paymentCheckout == DialogResult.No) { DBSetData.CheckoutFolioDue(reservationid); }
                            }

                            getFolioTotal.Dispose();
                        }
                    }

                    DisplayDefaultRoom();
                }
            }
        }

        // Button 'Search' in the room section
        // Searches result in relevant tables from textinput
        private void buttonSearchBookingRoom_Click(object sender, EventArgs e)
        {
            string searchinput = @textBoxSearch.Text.Trim();

            // Fetch dataset
            DataSet roomreservationDS = DBGetData.GetRoomBookingsSearch(searchinput);

            if (roomreservationDS != null)
            {
                // No tables fetched
                if (roomreservationDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if (roomreservationDS.Tables[0].Rows.Count == 0)
                {
                    new StatusMessage("No datarows found for search.");
                    return;
                }
                // Clear labelStatus for previous messages
                else
                {
                    new StatusMessage("");
                }

                // Set the dataset as source for datagridview and make sure its displayed
                dataGridViewRoom.DataSource = roomreservationDS;
                dataGridViewRoom.DataMember = "Get_RR_Search";
                LoadDataGridViewRoom();
            }
        }

        //
        // Hall section
        //

        // Set controls visibility for submenu button 'Hall'
        private void LoadControlsHall()
        {
            buttonNewBookingHall.Visible = true;
            buttonEditBookingHall.Visible = true;
            buttonDeleteBookingHall.Visible = true;
            buttonCheckinHall.Visible = true;
            buttonCheckoutHall.Visible = true;
            buttonSearchBookingHall.Visible = true;
            buttonDisplayHallDay.Visible = true;
            buttonDisplayHallWeek.Visible = true;
            buttonDisplayHallMonth.Visible = true;
            buttonDisplayHallAll.Visible = true;
            buttonNewBookingRoom.Visible = false;
            buttonEditBookingRoom.Visible = false;
            buttonDeleteBookingRoom.Visible = false;
            buttonCheckinRoom.Visible = false;
            buttonCheckoutRoom.Visible = false;
            buttonSearchBookingRoom.Visible = false;
            buttonDisplayRoomDay.Visible = false;
            buttonDisplayRoomWeek.Visible = false;
            buttonDisplayRoomMonth.Visible = false;
            buttonDisplayRoomAll.Visible = false;
            this.AcceptButton = buttonSearchBookingHall;
        }

        // Load dataGridViewRoom and make sure its visible
        public void LoadDataGridViewHall()
        {
            dataGridViewRoom.Visible = false;
            dataGridViewHall.Visible = true;
            // Hide ID and make readable table headers
            dataGridViewHall.Columns[0].Name = "ReservationID";
            dataGridViewHall.Columns[0].Visible = false;
            dataGridViewHall.Columns[1].Name = "HallID";
            dataGridViewHall.Columns[1].Visible = false;
            dataGridViewHall.Columns[2].Name = "Firstname";
            dataGridViewHall.Columns[2].HeaderText = "Firstname";
            dataGridViewHall.Columns[3].Name = "Lastname";
            dataGridViewHall.Columns[3].HeaderText = "Lastname";
            dataGridViewHall.Columns[4].Name = "Hall";
            dataGridViewHall.Columns[4].HeaderText = "Room";
            dataGridViewHall.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewHall.Columns[5].Name = "Checkedin";
            dataGridViewHall.Columns[5].HeaderText = "Checkedin";
            dataGridViewHall.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewHall.Columns[6].Name = "Halltype";
            dataGridViewHall.Columns[6].HeaderText = "Roomtype";
            dataGridViewHall.Columns[7].Name = "Timefrom";
            dataGridViewHall.Columns[7].HeaderText = "Event start";
            dataGridViewHall.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewHall.Columns[8].Name = "Timeto";
            dataGridViewHall.Columns[8].HeaderText = "Event end";
            dataGridViewHall.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewHall.Columns[9].Name = "Remark";
            dataGridViewHall.Columns[9].HeaderText = "Remark";
        }

        // Default hall display (monthly)
        public void DisplayDefaultHall()
        {
            // Find this weeks start date and convert to readable format for MySQL
            DateTime today = DateTime.Today;
            DateTime datefrom = new DateTime(today.Year, today.Month, 1);
            DateTime dateto = datefrom.AddMonths(1).AddDays(-1);

            // Fetch dataset
            DataSet hallreservationDS = DBGetData.GetHallBookingsBetweenDates(datefrom, dateto);

            if (hallreservationDS != null)
            {
                // No tables fetched
                if (hallreservationDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if (hallreservationDS.Tables[0].Rows.Count == 0)
                {
                    new StatusMessage("No datarows found for this month.");
                    return;
                }
                // Clear labelStatus for previous messages
                else
                {
                    new StatusMessage("");
                }

                // Set the dataset as source for datagridview and make sure its displayed
                dataGridViewHall.DataSource = hallreservationDS;
                dataGridViewHall.DataMember = "Get_HR_BetweenDates";
                LoadDataGridViewHall();
            }
        }

        // Button 'All' in the hall section
        // Display all hall reservations
        private void buttonDisplayHallAll_Click(object sender, EventArgs e)
        {
            // Fetch dataset
            DataSet hallreservationDS = DBGetData.GetHallBookingsAll(1);

            if (hallreservationDS != null)
            {
                // No tables fetched
                if (hallreservationDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if (hallreservationDS.Tables[0].Rows.Count == 0)
                {
                    new StatusMessage("No datarows found in table.");
                    return;
                }
                // Clear labelStatus for previous messages
                else
                {
                    new StatusMessage("");
                }

                // Set the dataset as source for datagridview and make sure its displayed
                dataGridViewHall.DataSource = hallreservationDS;
                dataGridViewHall.DataMember = "Get_HR_All";
                LoadDataGridViewHall();
            }
        }

        // Button 'Month' in the hall section
        // Display hall reservations for this month (default view)
        private void buttonDisplayHallMonth_Click(object sender, EventArgs e)
        {

        }

        // Button 'Week' in the hall section
        // Display hall reservations for this week
        private void buttonDisplayHallWeek_Click(object sender, EventArgs e)
        {

        }

        // Button 'Today' in the hall section
        // Display hall reservations for today
        private void buttonDisplayHallDay_Click(object sender, EventArgs e)
        {

        }

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

                    if (checkedin) { new StatusMessage("Hallreservasjon har allerede foretatt innsjekking og kan ikke endres."); }
                    else
                    {
                        // Set database record ID for reference
                        DBGetData.QueryID = Convert.ToInt32(this.dataGridViewHall.CurrentRow.Cells[0].Value);
                        Form editForm = new EditBookingRoom();
                        editForm.ShowDialog();
                    }
                }
                // Catch exceptions and display in labelStatus
                catch (Exception ex) { new StatusMessage(ex.Message); }
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

        // Button 'Sjekk inn' in the hall section
        private void buttonCheckinHall_Click(object sender, EventArgs e)
        {
            // TODO: Checkin process
        }

        // Button 'Sjekk ut' in the hall section
        private void buttonCheckoutHall_Click(object sender, EventArgs e)
        {
            // TODO: Checkout process
        }

        // Button 'Søk' in the hall section
        // Searches result in relevant tables from textinput
        private void buttonSearchBookingHall_Click(object sender, EventArgs e)
        {
            // TODO: Same as search room, but for hall
        }
    }
}
