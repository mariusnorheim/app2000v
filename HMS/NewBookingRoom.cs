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
    public partial class NewBookingRoom : HMS.PopupForm
    {
        Booking bookingForm = (Booking)Application.OpenForms["Booking"];
        private Boolean roomchecked;
        private Boolean validinput;
        private string roomid;
        private string query;

        public NewBookingRoom()
        {
            InitializeComponent();
            this.AcceptButton = buttonSearchGuest;
        }

        private void NewBookingRoom_Load(object sender, System.EventArgs e)
        {
            LoadDataBooking();
        }

        // Loading data from database into listBoxGuest and comboBoxRoomType
        private void LoadDataBooking()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
            {
                try
                {
                    // Connect to database
                    conn.Open();
                    // Populate listBoxGuest
                    query = "SELECT guestid, CONCAT(firstname, ' ', lastname) AS guest_name FROM guest " +
                            "ORDER BY lastname, firstname";
                    using (MySqlDataAdapter guestListAdapter = new MySqlDataAdapter(query, conn))
                    {
                        DataSet guestListDS = new DataSet();
                        guestListAdapter.Fill(guestListDS, "guest");
                        listBoxGuest.ValueMember = "guestid";
                        listBoxGuest.DisplayMember = "guest_name";
                        listBoxGuest.DataSource = guestListDS.Tables["guest"];
                    }

                    // Populate comboBoxRoomType
                    query = "SELECT room_typeid, name FROM room_type " +
                            "ORDER BY room_typeid";
                    using (MySqlDataAdapter roomTypeBoxAdapter = new MySqlDataAdapter(query, conn))
                    {
                        DataSet roomTypeBoxDS = new DataSet();
                        roomTypeBoxAdapter.Fill(roomTypeBoxDS, "room_type");
                        comboBoxRoomType.ValueMember = "room_typeid";
                        comboBoxRoomType.DisplayMember = "name";
                        comboBoxRoomType.DataSource = roomTypeBoxDS.Tables["room_type"];
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

        // Button 'Søk gjest'
        // Search guest archive
        private void buttonSearchGuest_Click(object sender, EventArgs e)
        {
            string searchinput = @textBoxSearch.Text.Trim();

            using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
            {
                try
                {
                    // Connect to database
                    conn.Open();
                    // Populate Guest listbox
                    query = "SELECT guestid, CONCAT(firstname, ' ', lastname) AS guest_name FROM guest " +
                            "WHERE CONCAT(firstname, ' ', lastname) LIKE @search " +
                            "ORDER BY lastname, firstname";
                    using (MySqlCommand guestListSearchCmd = new MySqlCommand(query, conn))
                    {
                        guestListSearchCmd.Parameters.AddWithValue("@search", "%" + searchinput + "%");
                        using (MySqlDataAdapter guestListSearchAdapter = new MySqlDataAdapter(guestListSearchCmd))
                        {
                            DataSet guestListDS = new DataSet();
                            guestListSearchAdapter.Fill(guestListDS, "guest");
                            listBoxGuest.ValueMember = "guestid";
                            listBoxGuest.DisplayMember = "guest_name";
                            listBoxGuest.DataSource = guestListDS.Tables["guest"];
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

        // Button 'Søk rom'
        // Display available rooms for selected date
        private void buttonSearchRoomBookingAvailable_Click(object sender, EventArgs e)
        {
            int roomtype = Convert.ToInt32(comboBoxRoomType.SelectedValue);
            string datearrive = datePickerArrival.Value.ToString("yyyy-MM-dd");
            string datedepart = datePickerDeparture.Value.ToString("yyyy-MM-dd");

            // Clear flowlayoutpanel and set parameter to enable drag and drop
            flowLayoutPanel1.Controls.Clear();
            roomchecked = false;

            ValidateInput();
            // Check all relevant fields for input
            if (validinput)
            {
                using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
                {
                    try
                    {
                        // Connect to database
                        conn.Open();
                        // Fetch available rooms
                        query = "SELECT R.roomid FROM room as R " +
                                "INNER JOIN room_type AS RT ON R.room_typeid = RT.room_typeid " +
                                "WHERE RT.room_typeid =  @roomtype " +
                                "AND roomid NOT IN ( " +
                                "SELECT RR.roomid " +
                                "FROM room_reservation AS RR " +
                                "LEFT JOIN room AS R ON RR.roomid = R.roomid " +
                                "WHERE (RR.datefrom BETWEEN @datearrive AND @datedepart " +
                                "OR RR.dateto BETWEEN @datearrive AND @datedepart) " +
                                "AND RR.isactive ='1' " +
                                ") AND roomid NOT IN ( " +
                                "SELECT R.roomid " +
                                "FROM room AS R " +
                                "LEFT JOIN housekeeping AS H ON R.roomid = H.roomid " +
                                "WHERE H.isactive = '1' " +
                                ") ORDER BY roomid";
                        using (MySqlCommand roomSearchCmd = new MySqlCommand(query, conn))
                        {
                            roomSearchCmd.Parameters.AddWithValue("@roomtype", roomtype);
                            roomSearchCmd.Parameters.AddWithValue("@datearrive", datearrive);
                            roomSearchCmd.Parameters.AddWithValue("@datedepart", datedepart);
                            using (MySqlDataReader roomResult = roomSearchCmd.ExecuteReader())
                            {
                                // Generate panels to indicate available rooms
                                // Create event handlers for click and drag and drop with values from listBoxGuest
                                while (roomResult.Read())
                                {
                                    Panel p = new Panel();
                                    p.Name = roomResult["roomid"].ToString();
                                    p.Size = new Size(79, 35);
                                    p.BackColor = Color.Yellow;
                                    p.AllowDrop = true;
                                    // Setup event handlers for DragOver, DragDrop and Click
                                    p.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelRoom_DragDrop);
                                    p.DragOver += new System.Windows.Forms.DragEventHandler(this.panelRoom_DragOver);
                                    p.Click += new EventHandler(this.panelRoom_Click);
                                    this.flowLayoutPanel1.Controls.Add(p);
                                    // Draw room number on panel
                                    Font drawFont = new Font("Tahoma", 12);
                                    p.Paint += (ss, ee) =>
                                    {
                                        ee.Graphics.DrawString(p.Name, drawFont, Brushes.Black, 20, 8);
                                    };
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
        }

        // Button 'Lagre'
        // Validate input and insert into database
        private void buttonNewBookingConfirm_Click(object sender, EventArgs e)
        {
            //Reference variables
            string datearrive = datePickerArrival.Value.ToString("yyyy-MM-dd");
            string datedepart = datePickerDeparture.Value.ToString("yyyy-MM-dd");
            int guestid = Convert.ToInt32(listBoxGuest.SelectedValue);
            string remark;
            if (string.IsNullOrWhiteSpace(textBoxRemark.Text)) { remark = null; }
            else { remark = textBoxRemark.Text; }

            // Display error messages if variable is missing
            if (guestid == null) { MessageBox.Show("Velg gjest i boksen øverst til venstre før du prøver å lagre endringer."); }
            if (roomid == null) { MessageBox.Show("Søk og velg rom før du prøver å lagre endringer."); }

            ValidateInput();
            // Check all relevant fields for input
            if (validinput && guestid != null && roomid != null)
            {
                using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
                {
                    try
                    {
                        // Connect to database
                        conn.Open();
                        // Save entry to database
                        query = "INSERT INTO room_reservation (guestid, roomid, datefrom, dateto, remark) " +
                                "VALUES (@guestid, @roomid, @datearrive, @datedepart, @remark)";
                        using (MySqlCommand newRoomBookingCmd = new MySqlCommand(query, conn))
                        {
                            newRoomBookingCmd.Parameters.AddWithValue("@guestid", guestid);
                            newRoomBookingCmd.Parameters.AddWithValue("@roomid", roomid);
                            newRoomBookingCmd.Parameters.AddWithValue("@datearrive", datearrive);
                            newRoomBookingCmd.Parameters.AddWithValue("@datedepart", datedepart);
                            newRoomBookingCmd.Parameters.AddWithValue("@remark", remark);
                            newRoomBookingCmd.ExecuteNonQuery();
                            // Close form and display statustext
                            this.Close();
                            new StatusMessage("Reservation for roomnumber " + roomid + " saved in database.");
                        }
                    }
                    // Catch exceptions and display in MessageBox
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    // Make sure connection is closed and refresh data
                    finally
                    {
                        if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
                        bookingForm.DisplayDefaultRoom();
                        bookingForm.dataGridViewRoom.Refresh();
                    }
                }
            }
        }

        // Button 'Avbryt'
        private void buttonNewBookingCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            bookingForm.DisplayDefaultRoom();
        }

        // Event handler for listBoxGuest mousedrag
        private void listBoxGuest_MouseMove(object sender, MouseEventArgs e)
        {
            if (!roomchecked)
            {
                if ((e.Button & MouseButtons.Left) == MouseButtons.Left) { DragDropEffects dropEffect = listBoxGuest.DoDragDrop(listBoxGuest.SelectedValue, DragDropEffects.Move); }
            }
        }

        // Event handler for listBoxGuest mousedown
        private void listBoxGuest_MouseDown(object sender, MouseEventArgs e)
        {
            if (!roomchecked) { listBoxGuest.DoDragDrop(listBoxGuest.GetItemText(listBoxGuest.SelectedValue), DragDropEffects.All); }
        }

        // Event handler for available room panel dragover
        private void panelRoom_DragOver(object sender, DragEventArgs e)
        {
            if (!roomchecked) { e.Effect = DragDropEffects.Copy; }
        }

        // Event handler for available room panel dragdrop
        private void panelRoom_DragDrop(object sender, DragEventArgs e)
        {
            if (!roomchecked)
            {
                // item contains object that is dragged from listbox
                // c contains controller that object is dragged onto
                Object item = (object)e.Data.GetData(typeof(System.String));
                Control c = (Control)sender;
                if (item != null)
                {
                    roomchecked = true;
                    roomid = c.Name;
                    c.BackColor = Color.Lime;
                }
            }
        }

        // Event handler for available room panel click
        private void panelRoom_Click(object sender, EventArgs e)
        {
            if (!roomchecked)
            {
                // c contains controller that is clicked
                Control c = (Control)sender;
                roomchecked = true;
                roomid = c.Name;
                c.BackColor = Color.Lime;
            }
        }

        // Validate date input
        private void ValidateInput()
        {
            validinput = true;
            if (datePickerArrival.Value.Date < DateTime.Today)
            {
                validinput = false;
                MessageBox.Show("Ankomstdato kan ikke være tidligere enn i dag.");
                datePickerArrival.Focus();
            }
            if (datePickerDeparture.Value.Date <= datePickerArrival.Value.Date)
            {
                validinput = false;
                MessageBox.Show("Avreisedato kan ikke være tidligere eller samme dag som ankomstdato.");
                datePickerDeparture.Focus();
            }
        }
    }
}
