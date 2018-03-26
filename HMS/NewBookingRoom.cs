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
        private int roomChecked = 0;
        Boolean validInput = true;
        private string query;

        public NewBookingRoom()
        {
            InitializeComponent();
        }

        private void NewBookingRoom_Load(object sender, System.EventArgs e)
        {
            LoadDataGuest();
        }

        // Loading data from database into listBoxGuest and comboBoxRoomType
        private void LoadDataGuest()
        {
            this.AcceptButton = this.buttonSearchGuest;
            using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
            {
                try
                {
                    // Connect to database
                    conn.Open();
                    // Prepare MySQL query
                    query = "SELECT guestid, CONCAT(firstname, ' ', lastname) AS guest_name FROM guest " +
                            "ORDER BY lastname, firstname";
                    using (MySqlDataAdapter guestTableAdapter = new MySqlDataAdapter(query, conn))
                    {
                        // Populate listBoxGuest
                        DataSet guestDS = new DataSet();
                        guestTableAdapter.Fill(guestDS, "guest");
                        listBoxGuest.ValueMember = "guestid";
                        listBoxGuest.DisplayMember = "guest_name";
                        listBoxGuest.DataSource = guestDS.Tables["guest"];
                    }

                    // Prepare MySQL query
                    query = "SELECT room_typeid, name FROM room_type " +
                            "ORDER BY room_typeid";
                    using (MySqlDataAdapter roomTypeTableAdapter = new MySqlDataAdapter(query, conn))
                    {
                        // Populate comboBoxRoomType
                        DataSet roomTypeDS = new DataSet();
                        roomTypeTableAdapter.Fill(roomTypeDS, "room_type");
                        comboBoxRoomType.ValueMember = "room_typeid";
                        comboBoxRoomType.DisplayMember = "name";
                        comboBoxRoomType.DataSource = roomTypeDS.Tables["room_type"];
                    }
                }
                // Catch exceptions and display in message box
                catch (Exception ex) { MessageBox.Show(ex.Message); }
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
            string search_input = @textBoxSearch.Text.Trim();
            using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
            {
                try
                {
                    // Connect to database
                    conn.Open();
                    // Prepare MySQL query
                    query = "SELECT guestid, CONCAT(firstname, ' ', lastname) AS guest_name FROM guest " +
                            "WHERE CONCAT(firstname, ' ', lastname) LIKE @search " +
                            "ORDER BY lastname, firstname";
                    using (MySqlCommand guestSearchCmd = new MySqlCommand(query, conn))
                    {
                        guestSearchCmd.Parameters.AddWithValue("@search", "%" + search_input + "%");
                        using (MySqlDataAdapter guestTableAdapter = new MySqlDataAdapter(guestSearchCmd))
                        {
                            // Populate Guest listbox
                            DataSet guestDS = new DataSet();
                            guestTableAdapter.Fill(guestDS, "guest");
                            listBoxGuest.ValueMember = "guestid";
                            listBoxGuest.DisplayMember = "guest_name";
                            listBoxGuest.DataSource = guestDS.Tables["guest"];
                        }
                    }
                }
                // Catch exceptions and display in message box
                catch (Exception ex) { MessageBox.Show(ex.Message); }
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
            roomChecked = 0;

            ValidateInput();
            string roomType = comboBoxRoomType.SelectedValue.ToString();
            string dateArrive = datePickerArrival.Value.ToString("yyyy-MM-dd");
            string dateDepart = datePickerDeparture.Value.ToString("yyyy-MM-dd");

            if (validInput)
            {
                // Connect to database
                using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
                {
                    try
                    {
                        // Connect to database
                        conn.Open();
                        // Prepare MySQL query
                        query = "SELECT R.roomid, RT.name FROM room as R " +
                                "INNER JOIN room_type AS RT ON R.room_typeid = RT.room_typeid " +
                                "WHERE RT.room_typeid =  @roomtype " +
                                "AND roomid NOT IN ( " +
                                "SELECT RR.roomid " +
                                "FROM room_reservation AS RR " +
                                "LEFT JOIN room AS R ON RR.roomid = R.roomid " +
                                "WHERE RR.datefrom BETWEEN @datearrive AND @datedepart " +
                                "OR RR.dateto BETWEEN @datearrive AND @datedepart " +
                                ") AND roomid NOT IN ( " +
                                "SELECT R.roomid " +
                                "FROM room AS R " +
                                "LEFT JOIN housekeeping AS H ON R.roomid = H.roomid " +
                                "WHERE H.isactive = '1' " +
                                ") ORDER BY roomid";
                        using (MySqlCommand roomSearchCmd = new MySqlCommand(query, conn))
                        {
                            roomSearchCmd.Parameters.AddWithValue("@roomtype", roomType);
                            roomSearchCmd.Parameters.AddWithValue("@datearrive", dateArrive);
                            roomSearchCmd.Parameters.AddWithValue("@datedepart", dateDepart);
                            using (MySqlDataReader roomResult = roomSearchCmd.ExecuteReader())
                            {
                                // Fetch data and generate drag and drop panels to indicate available rooms
                                while (roomResult.Read())
                                {
                                    Panel p = new Panel();
                                    p.Name = roomResult["roomid"].ToString();
                                    p.Size = new Size(79, 35);
                                    p.BackColor = Color.Yellow;
                                    p.AllowDrop = true;
                                    // Setup event handlers for DragOver og DragDrop
                                    p.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelRoom_DragDrop);
                                    p.DragOver += new System.Windows.Forms.DragEventHandler(this.panelRoom_DragOver);
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
                    // Catch exceptions and display in message box
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    // Make sure connection is closed
                    finally
                    {
                        if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
                    }
                }
            }
        }

        // Button 'Lagre', validate input and insert into database
        private void buttonNewBookingConfirm_Click(object sender, EventArgs e)
        {
            ValidateInput();

            if (validInput)
            {
                string guestid = listBoxGuest.SelectedValue.ToString();
                string roomid = DBConn.QueryID;
                string dateArrive = datePickerArrival.Value.ToString("yyyy-MM-dd");
                string dateDepart = datePickerDeparture.Value.ToString("yyyy-MM-dd");
                string remark;
                if (string.IsNullOrWhiteSpace(textBoxRemark.Text))
                {
                    remark = null;
                }
                else
                {
                    remark = textBoxRemark.Text.ToString();
                }

                // Connect to database
                using (MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString))
                {
                    try
                    {
                        // Connect to database
                        conn.Open();
                        // Prepare MySQL query
                        query = "INSERT INTO room_reservation (guestid, roomid, datefrom, dateto, remark) " +
                                "VALUES (@guestid, @roomid, @datearrive, @datedepart, @remark)";
                        using (MySqlCommand roomBookingCmd = new MySqlCommand(query, conn))
                        {
                            roomBookingCmd.Parameters.AddWithValue("@guestid", guestid);
                            roomBookingCmd.Parameters.AddWithValue("@roomid", roomid);
                            roomBookingCmd.Parameters.AddWithValue("@datearrive", dateArrive);
                            roomBookingCmd.Parameters.AddWithValue("@datedepart", dateDepart);
                            roomBookingCmd.Parameters.AddWithValue("@remark", remark);
                            roomBookingCmd.ExecuteNonQuery();
                            MessageBox.Show("Reservasjon for rom " + roomid + " i tidsrommet fra " + dateArrive + 
                                            " til " + dateDepart + " er lagret i databasen.");
                            // Clear flowlayoutpanel and set parameter to enable drag and drop
                            flowLayoutPanel1.Controls.Clear();
                            roomChecked = 0;
                        }
                    }
                    // Catch exceptions and display in message box
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    // Make sure connection is closed
                    finally
                    {
                        if (conn.State == System.Data.ConnectionState.Open)
                        {
                            conn.Close();
                        }
                    }
                }
            }
        }

        // Button 'Avbryt'
        private void buttonNewBookingCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Event handler for listBoxGuest mousedrag
        private void listBoxGuest_MouseMove(object sender, MouseEventArgs e)
        {
            if (roomChecked == 0)
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
            if (roomChecked == 0)
            {
                listBoxGuest.DoDragDrop(listBoxGuest.GetItemText(listBoxGuest.SelectedValue), DragDropEffects.All);
            }
        }

        // Event handler for available room panel dragover
        private void panelRoom_DragOver(object sender, DragEventArgs e)
        {
            if (roomChecked == 0)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        // Event handler for available room panel dragdrop
        private void panelRoom_DragDrop(object sender, DragEventArgs e)
        {
            if (roomChecked == 0)
            {
                // item contains object that is dragged from listbox
                // c contains controller that object is dragged onto
                Object item = (object)e.Data.GetData(typeof(System.String));
                Control c = (Control)sender;
                if (item != null)
                {
                    c.BackColor = Color.Lime;
                    roomChecked = 1;
                    DBConn.QueryID = c.Name;
                }
            }
        }

        // Validate input
        private void ValidateInput()
        {
            validInput = true;
            if (datePickerArrival.Value.Date < DateTime.Today)
            {
                validInput = false;
                MessageBox.Show("Ankomstdato kan ikke være tidligere enn i dag.");
                datePickerArrival.Focus();
            }
            if (datePickerDeparture.Value.Date <= datePickerArrival.Value.Date)
            {
                validInput = false;
                MessageBox.Show("Avreisedato kan ikke være tidligere eller samme dag som ankomstdato.");
                datePickerDeparture.Focus();
            }
        }
    }
}
