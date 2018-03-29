﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HMS
{
    public partial class EditBookingRoom : HMS.PopupForm
    {
        Booking bookingForm = (Booking)Application.OpenForms["Booking"];
        private Boolean roomchecked;
        private Boolean validinput;
        private string roomid;
        private string query;

        public EditBookingRoom()
        {
            InitializeComponent();
        }

        private void EditBookingRoom_Load(object sender, EventArgs e)
        {
            LoadDataBooking();
            this.AcceptButton = this.buttonSearchGuest;
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

                    // Fetch selected values
                    query = "SELECT RR.guestid, RT.room_typeid, RR.datefrom, RR.dateto FROM room_reservation AS RR " +
                            "LEFT JOIN room AS R ON RR.roomid = R.roomid " +
                            "LEFT JOIN room_type AS RT ON R.room_typeid = RT.room_typeid " +
                            "WHERE RR.room_reservationid = @queryid";
                    using (MySqlCommand getValuesCmd = new MySqlCommand(query, conn))
                    {
                        getValuesCmd.Parameters.AddWithValue("@queryid", DBConn.QueryID);
                        using (MySqlDataReader getValuesResult = getValuesCmd.ExecuteReader())
                        {
                            if (getValuesResult.Read())
                            {
                                int guestid = getValuesResult.GetInt32(0);
                                int roomtypeid = getValuesResult.GetInt32(1);
                                DateTime datearrive = getValuesResult.GetDateTime(2);
                                DateTime datedepart = getValuesResult.GetDateTime(3);
                                listBoxGuest.SelectedValue = guestid;
                                comboBoxRoomType.SelectedValue = roomtypeid;
                                datePickerArrival.Value = datearrive;
                                datePickerDeparture.Value = datedepart;
                            }
                        }
                    }
                }
                // Catch exceptions and display in statusline
                catch (Exception ex) { bookingForm.labelStatus.Text = ex.Message; }
                // Make sure connection is closed
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
                }
            }
        }

        // Button 'Søk gjest'
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
                // Catch exceptions and display in statusline
                catch (Exception ex) { bookingForm.labelStatus.Text = ex.Message; }
                // Make sure connection is closed
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
                }
            }
        }

        // Button 'Søk rom'
        private void buttonSearchRoomBookingAvailable_Click(object sender, EventArgs e)
        {
            // Clear flowlayoutpanel and set parameter to enable drag and drop
            flowLayoutPanel1.Controls.Clear();
            roomchecked = false;

            ValidateInput();
            int roomtype = Convert.ToInt32(comboBoxRoomType.SelectedValue);
            string datearrive = datePickerArrival.Value.ToString("yyyy-MM-dd");
            string datedepart = datePickerDeparture.Value.ToString("yyyy-MM-dd");

            if (validinput)
            {
                // Connect to database
                using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
                {
                    try
                    {
                        // Connect to database
                        conn.Open();
                        // Fetch data and generate drag and drop panels to indicate available rooms
                        query = "SELECT R.roomid FROM room as R " +
                                "INNER JOIN room_type AS RT ON R.room_typeid = RT.room_typeid " +
                                "WHERE RT.room_typeid =  @roomtype " +
                                "AND roomid NOT IN ( " +
                                "SELECT RR.roomid " +
                                "FROM room_reservation AS RR " +
                                "LEFT JOIN room AS R ON RR.roomid = R.roomid " +
                                "WHERE (RR.datefrom BETWEEN @datearrive AND @datedepart " +
                                "OR RR.dateto BETWEEN @datearrive AND @datedepart) " +
                                "AND RR.isactive = '1' " +
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
                    // Catch exceptions and display in statusline
                    catch (Exception ex) { bookingForm.labelStatus.Text = ex.Message; }
                    // Make sure connection is closed
                    finally
                    {
                        if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
                    }
                }
            }
        }

        // Button 'Lagre'
        private void buttonEditBookingConfirm_Click(object sender, EventArgs e)
        {
            Boolean checkedin = false;
            string datefrom = datePickerArrival.Value.ToString("yyyy-MM-dd");
            string dateto = datePickerDeparture.Value.ToString("yyyy-MM-dd");
            int guestid = Convert.ToInt32(listBoxGuest.SelectedValue);
            int reservationid = DBConn.QueryID;
            string remark;
            if (string.IsNullOrWhiteSpace(textBoxRemark.Text)) { remark = null; }
            else { remark = textBoxRemark.Text; }

            ValidateInput();
            // Check all relevant fields for input
            if (validinput && reservationid != null && guestid != null)
            {
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

                        if (checkedin) { MessageBox.Show("Romreservasjon har allerede foretatt innsjekking og kan ikke endres."); }
                        else
                        {
                            // Save changes to database
                            query = "UPDATE room_reservation " +
                                    "SET guestid = @guestid, roomid = @roomid, datefrom = @datearrive, dateto = @datedepart, remark = @remark " +
                                    "WHERE room_reservationid = @reservationid";
                            using (MySqlCommand editRoomBookingCmd = new MySqlCommand(query, conn))
                            {
                                editRoomBookingCmd.Parameters.AddWithValue("@reservationid", reservationid);
                                editRoomBookingCmd.Parameters.AddWithValue("@guestid", guestid);
                                editRoomBookingCmd.Parameters.AddWithValue("@roomid", roomid);
                                editRoomBookingCmd.Parameters.AddWithValue("@datearrive", datefrom);
                                editRoomBookingCmd.Parameters.AddWithValue("@datedepart", dateto);
                                editRoomBookingCmd.Parameters.AddWithValue("@remark", remark);
                                editRoomBookingCmd.ExecuteNonQuery();
                                // Refresh data and close form
                                bookingForm.DisplayDefaultRoom();
                                this.Close();
                                bookingForm.labelStatus.Text = "Reservasjon for romnummer " + roomid + " er lagret i databasen og tidligere romnummer frigitt.";
                            }
                        }
                    }
                    // Catch exceptions and display in statusline
                    catch (Exception ex) { bookingForm.labelStatus.Text = ex.Message; }
                    // Make sure connection is closed
                    finally
                    {
                        if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
                    }
                }
            }
        }

        // Button 'Avbryt'
        private void buttonEditBookingCancel_Click(object sender, EventArgs e)
        {
            bookingForm.DisplayDefaultRoom();
            this.Close();
        }

        // Event handler for listBoxGuest mousedrag
        private void listBoxGuest_MouseMove(object sender, MouseEventArgs e)
        {
            if (!roomchecked)
            {
                if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                {
                    DragDropEffects dropEffect = listBoxGuest.DoDragDrop(listBoxGuest.SelectedValue, DragDropEffects.Move);
                }
            }
        }

        // Event handler for listBoxGuest mousedown
        private void listBoxGuest_MouseDown(object sender, MouseEventArgs e)
        {
            if (!roomchecked)
            {
                listBoxGuest.DoDragDrop(listBoxGuest.GetItemText(listBoxGuest.SelectedValue), DragDropEffects.All);
            }
        }

        // Event handler for available room panel dragover
        private void panelRoom_DragOver(object sender, DragEventArgs e)
        {
            if (!roomchecked)
            {
                e.Effect = DragDropEffects.Copy;
            }
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

        // Validate input
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
