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

        //private void LoadData(Object threadContext)
        private void LoadData()
        {
            MySqlConnection conn = new MySqlConnection(DBConn.ConnectionString);
            string query;

            // Connect to database
            conn.Open();

            // Create a new data adapter
            query = "SELECT G.guest_name, RT.room_type_name, RR.room_reservation_amount, " +
                "RR.room_reservation_datefrom, RR.room_reservation_dateto, RR.room_reservation_remark " +
                "FROM room_reservation RR " +
                "JOIN room_type RT " +
                "ON RR.room_reservation_typeid = RT.room_typeid " +
                "JOIN guest G " +
                "ON RR.room_reservation_guestid = G.guestid";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            // Populate a new data set
            DataSet ds = new DataSet();
            adapter.Fill(ds, "room_reservation");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "room_reservation";
            // Make readable table headers
            dataGridView1.Columns[0].HeaderText = "Guest";
            dataGridView1.Columns[1].HeaderText = "Room type";
            dataGridView1.Columns[2].HeaderText = "Room amount";
            dataGridView1.Columns[3].HeaderText = "Arrival";
            dataGridView1.Columns[4].HeaderText = "Departure";
            dataGridView1.Columns[5].HeaderText = "Remark";

            // Close database connection
            conn.Close();
        }

        private void Booking_Load(object sender, System.EventArgs e)
        {
            try
            {
                //ThreadPool.QueueUserWorkItem(LoadData);
                LoadData();
            }
            // Catch exceptions and display in labelStatus
            catch (Exception ex)
            {
                //Placeholder
                this.labelStatus.Text = ex.Message;
            }
        }

        // Load new Form on double click
        /*
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        EditForm editForm = new EditForm();
        editForm.Show();
        }
        */
    }
}
