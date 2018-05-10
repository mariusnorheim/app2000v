using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HMS
{
    public partial class EditBookingRoom : HMS.PopupForm
    {
        Booking bookingForm = (Booking)Application.OpenForms["Booking"];
        private Boolean roomchecked;
        private Boolean validinput;
        private int reservationid = DBGetData.QueryID;
        private string roomid;

        public EditBookingRoom()
        {
            InitializeComponent();
        }

        private void EditBookingRoom_Load(object sender, EventArgs e)
        {
            LoadDataBooking();
            this.AcceptButton = buttonSearchGuest;
        }

        // Loading data from database into listBoxGuest and comboBoxRoomType
        private void LoadDataBooking()
        {
            // Fetch dataset
            DataSet guestListDS = DBGetData.GetGuestList();

            if (guestListDS != null)
            {
                // No tables fetched
                if (guestListDS.Tables.Count == 0)
                {
                    MessageBox.Show("No guest datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if (guestListDS.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No datarows found in guest table.");
                    return;
                }

                // Set the dataset as source for listbox
                listBoxGuest.ValueMember = "guestid";
                listBoxGuest.DisplayMember = "guest_name";
                listBoxGuest.DataSource = guestListDS.Tables[0];
            }

            // Fetch dataset
            DataSet roomtypeListDS = DBGetData.GetRoomtypeList();

            if (roomtypeListDS != null)
            {
                // No tables fetched
                if (roomtypeListDS.Tables.Count == 0)
                {
                    MessageBox.Show("No roomtype datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if (roomtypeListDS.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No datarows found in roomtype table.");
                    return;
                }

                // Set the dataset as source for combobox

                comboBoxRoomType.ValueMember = "room_typeid";
                comboBoxRoomType.DisplayMember = "name";
                comboBoxRoomType.DataSource = roomtypeListDS.Tables[0];
            }

            // Highlight existing values
            MySqlDataReader getValues = DBGetData.GetRoomreservationData(reservationid);
            if (getValues.Read())
            {
                listBoxGuest.SelectedValue = getValues.GetInt32(0);
                comboBoxRoomType.SelectedValue = getValues.GetInt32(1);
                datePickerArrival.Value = getValues.GetDateTime(2);
                datePickerDeparture.Value = getValues.GetDateTime(3);
                if (!getValues.IsDBNull(4)) { textBoxRemark.Text = getValues.GetString(4); }
            }

            getValues.Dispose();
        }

        // Button 'Search'
        // Search guest archive
        private void buttonSearchGuest_Click(object sender, EventArgs e)
        {
            string searchinput = @textBoxSearch.Text.Trim();

            // Fetch dataset
            DataSet guestListDS = DBGetData.GetGuestListSearch(searchinput);

            if (guestListDS != null)
            {
                // No tables fetched
                if (guestListDS.Tables.Count == 0)
                {
                    MessageBox.Show("No guest datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if (guestListDS.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No search result found in guest table.");
                    return;
                }

                // Set the dataset as source for listbox
                listBoxGuest.ValueMember = "guestid";
                listBoxGuest.DisplayMember = "guest_name";
                listBoxGuest.DataSource = guestListDS.Tables[0];
            }
        }

        // Button 'Find room'
        // Display available rooms for selected date
        private void buttonSearchRoomBookingAvailable_Click(object sender, EventArgs e)
        {
            if (listBoxGuest.SelectedIndex > -1 && comboBoxRoomType.SelectedIndex > -1)
            {
                int roomtypeid = Convert.ToInt32(comboBoxRoomType.SelectedValue);
                string datefrom = datePickerArrival.Value.ToString("yyyy-MM-dd");
                string dateto = datePickerDeparture.Value.ToString("yyyy-MM-dd");

                // Clear flowlayoutpanel and set parameter to enable drag and drop
                flowLayoutPanel1.Controls.Clear();
                roomchecked = false;
                roomid = null;

                ValidateInput();
                // Check all relevant fields for input
                if (validinput)
                {
                    // Check available rooms
                    MySqlDataReader getAvailableRooms = DBGetData.GetAvailableRooms(roomtypeid, datefrom, dateto);

                    while (getAvailableRooms.Read())
                    {
                        // Generate panels to indicate available rooms
                        // Create event handlers for click and drag and drop with values from listBoxGuest
                        Panel p = new Panel();
                        p.Name = getAvailableRooms["roomid"].ToString();
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

                    getAvailableRooms.Dispose();
                }
            }
        }

        // Button 'Lagre'
        // Validate input and update database record
        private void buttonEditBookingConfirm_Click(object sender, EventArgs e)
        {
            // Validation variables
            Boolean checkedin = false;
            Boolean guestchanged = false;
            Boolean guestconfirm = true;

            // Display error messages if value is not selected
            if (listBoxGuest.SelectedIndex == -1) { MessageBox.Show("Select a guest before saving entry"); }
            if (!roomchecked || roomid == null) { MessageBox.Show("Select a room before saving entry"); }

            // Make sure guest and room is selected and reservationid set
            if (listBoxGuest.SelectedIndex > -1 && roomchecked && roomid != null && reservationid > 0)
            {
                //Reference variables
                string datefrom = datePickerArrival.Value.ToString("yyyy-MM-dd");
                string dateto = datePickerDeparture.Value.ToString("yyyy-MM-dd");
                int guestid = Convert.ToInt32(listBoxGuest.SelectedValue);
                string remark;
                if (string.IsNullOrWhiteSpace(textBoxRemark.Text)) { remark = null; }
                else { remark = textBoxRemark.Text; }

                ValidateInput();
                // Check all relevant fields for input
                if (validinput)
                {
                    // Check if reservation is checked in
                    if (DBGetData.GetRoomCheckedin(reservationid) > 0) { checkedin = true; }
                    if (checkedin) { new StatusMessage("Room reservation has already checked in."); }

                    // Check if guestid has changed
                    MySqlDataReader getReservationGuest = DBGetData.GetRoomreservationGuest(reservationid, guestid);
                    if (getReservationGuest.Read()) { guestchanged = true; }
                    getReservationGuest.Dispose();

                    // Give warning if guest has changed and ask for confirmation
                    if (!guestchanged)
                    {
                        DialogResult guestDifferent = MessageBox.Show("You have changed the guest for this reservation" +
                                                                      "\nAre you sure you want to continue?", "Warning!", MessageBoxButtons.YesNo);
                        if (guestDifferent == DialogResult.No)
                        {
                            // Cancel edit and reload data
                            guestconfirm = false;
                            LoadDataBooking();
                            // Clear flowlayoutpanel and set parameter to enable drag and drop
                            flowLayoutPanel1.Controls.Clear();
                            roomchecked = false;
                        }
                    }

                    if (!checkedin && guestconfirm)
                    {
                        DBSetData.RoomreservationEdit(reservationid, guestid, roomid, datefrom, dateto, remark);
                        // Refresh datagridview, close form and display new StatusMessage
                        bookingForm.DisplayDefaultRoom();
                        bookingForm.dataGridViewRoom.Refresh();
                        this.Close();
                        new StatusMessage("Reservation for roomnumber " + roomid + " saved in database and previous roomnumber released.");
                    }
                }
            }
        }

        // Button 'Avbryt'
        private void buttonEditBookingCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            bookingForm.DisplayDefaultRoom();
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

        // Validate date input
        private void ValidateInput()
        {
            validinput = true;
            if (datePickerArrival.Value.Date < DateTime.Today)
            {
                validinput = false;
                MessageBox.Show("Arrival date can not be earlier than today.");
                datePickerArrival.Focus();
            }
            if (datePickerDeparture.Value.Date <= datePickerArrival.Value.Date)
            {
                validinput = false;
                MessageBox.Show("Departure date can not be earlier or same date as arrival.");
                datePickerDeparture.Focus();
            }
        }
    }
}
