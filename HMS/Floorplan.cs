using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HMS
{
    public partial class Floorplan : HMS.Content
    {
        public Floorplan()
        {
            InitializeComponent();
        }

        private void Floorplan_Load(object sender, EventArgs e)
        {
            LoadDataRoom();
        }

        // Load dataGridViewFloorplan
        public void LoadDataGridViewRoom()
        {
            this.AcceptButton = buttonSearchRoom;
            dataGridViewFloorplanRoom.Visible = true;
            dataGridViewFloorplanHall.Visible = false;
            buttonNewRoom.Visible = true;
            buttonEditRoom.Visible = true;
            buttonSearchRoom.Visible = true;
            buttonNewHall.Visible = false;
            buttonEditHall.Visible = false;
            buttonSearchHall.Visible = false;

            // Hide ID and make readable table headers
            dataGridViewFloorplanRoom.Columns[0].HeaderText = "Room number";
            dataGridViewFloorplanRoom.Columns[1].HeaderText = "Room type";
        }

        // Load dataset to datagridview
        public void LoadDataRoom()
        {
            // Fetch dataset
            DataSet roomDS = DBGetData.GetFloorplanDGVRoom();

            if(roomDS != null)
            {
                // No tables fetched
                if(roomDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if(roomDS.Tables[0].Rows.Count == 0)
                {
                    new StatusMessage("No datarows found in room.");
                    return;
                }
                // Clear labelStatus for previous messages
                else
                {
                    new StatusMessage("");
                }

                // Set the dataset as source for datagridview and make sure its displayed
                dataGridViewFloorplanRoom.DataSource = roomDS;
                dataGridViewFloorplanRoom.DataMember = "Get_Floorplan_Room";
                LoadDataGridViewRoom();
            }
        }

        // Button 'Room'
        private void buttonDisplayRoom_Click(object sender, EventArgs e)
        {
            LoadDataRoom();
        }

        // Button 'Hall'
        private void buttonDisplayHall_Click(object sender, EventArgs e)
        {
            LoadDataHall();
        }

        // DataGridViewFloorplanRoom double click
        // Open specialized edit form
        private void dataGridViewFloorplanRoom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridViewFloorplanRoom.SelectedRows.Count > 0 && dataGridViewFloorplanRoom.CurrentRow != null)
            {
                // Set database record ID for reference
                int roomid = Convert.ToInt32(this.dataGridViewFloorplanRoom.CurrentRow.Cells[0].Value);
                DBGetData.QueryID = roomid;

                Form editForm = new EditFloorplanRoom();
                editForm.ShowDialog();
            }
        }

        // Button 'New'
        private void buttonNewRoom_Click(object sender, EventArgs e)
        {
            Form roomForm = new NewFloorplanRoom();
            roomForm.ShowDialog();
        }

        // Button 'Edit'
        private void buttonEditRoom_Click(object sender, EventArgs e)
        {
            if(dataGridViewFloorplanRoom.SelectedRows.Count > 0 && dataGridViewFloorplanRoom.CurrentRow != null)
            {
                // Set database record ID for reference
                int roomid = Convert.ToInt32(this.dataGridViewFloorplanRoom.CurrentRow.Cells[0].Value);
                DBGetData.QueryID = roomid;

                Form editForm = new EditFloorplanRoom();
                editForm.ShowDialog();
            }
        }

        // Button 'Search'
        private void buttonSearchRoom_Click(object sender, EventArgs e)
        {
            string searchinput = @textBoxSearch.Text.Trim();

            // Fetch dataset
            DataSet roomDS = DBGetData.GetFloorplanDGVRoomSearch(searchinput);

            if(roomDS != null)
            {
                // No tables fetched
                if(roomDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if(roomDS.Tables[0].Rows.Count == 0)
                {
                    new StatusMessage("No datarows found matching search.");
                    return;
                }
                // Clear labelStatus for previous messages
                else
                {
                    new StatusMessage("");
                }

                // Set the dataset as source for datagridview and make sure its displayed
                dataGridViewFloorplanRoom.DataSource = roomDS;
                dataGridViewFloorplanRoom.DataMember = "Get_Floorplan_RoomSearch";
                LoadDataGridViewRoom();
            }
        }

        //
        // Hall section
        //

        // Load dataGridViewFloorplanHall
        public void LoadDataGridViewHall()
        {
            this.AcceptButton = buttonSearchHall;
            dataGridViewFloorplanHall.Visible = true;
            dataGridViewFloorplanRoom.Visible = false;
            buttonNewHall.Visible = true;
            buttonEditHall.Visible = true;
            buttonSearchHall.Visible = true;
            buttonNewRoom.Visible = false;
            buttonEditRoom.Visible = false;
            buttonSearchRoom.Visible = false;

            // Hide ID and make readable table headers
            dataGridViewFloorplanHall.Columns[0].Visible = false;
            dataGridViewFloorplanHall.Columns[1].HeaderText = "Hall name";
            dataGridViewFloorplanHall.Columns[2].HeaderText = "Hall type";
        }

        // Load dataset to datagridview
        public void LoadDataHall()
        {
            // Fetch dataset
            DataSet hallDS = DBGetData.GetFloorplanDGVHall();

            if(hallDS != null)
            {
                // No tables fetched
                if(hallDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if(hallDS.Tables[0].Rows.Count == 0)
                {
                    new StatusMessage("No datarows found in hall.");
                    return;
                }
                // Clear labelStatus for previous messages
                else
                {
                    new StatusMessage("");
                }

                // Set the dataset as source for datagridview and make sure its displayed
                dataGridViewFloorplanHall.DataSource = hallDS;
                dataGridViewFloorplanHall.DataMember = "Get_Floorplan_Hall";
                LoadDataGridViewHall();
            }
        }

        // DataGridViewFloorplanHall double click
        // Open specialized edit form
        private void dataGridViewFloorplanHall_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridViewFloorplanHall.SelectedRows.Count > 0 && dataGridViewFloorplanHall.CurrentRow != null)
            {
                // Set database record ID for reference
                int hallid = Convert.ToInt32(this.dataGridViewFloorplanHall.CurrentRow.Cells[0].Value);
                DBGetData.QueryID = hallid;

                Form editForm = new EditFloorplanHall();
                editForm.ShowDialog();
            }
        }

        // Button 'New'
        private void buttonNewHall_Click(object sender, EventArgs e)
        {
            Form hallForm = new NewFloorplanHall();
            hallForm.ShowDialog();
        }

        // Button 'Edit'
        private void buttonEditHall_Click(object sender, EventArgs e)
        {
            if(dataGridViewFloorplanHall.SelectedRows.Count > 0 && dataGridViewFloorplanHall.CurrentRow != null)
            {
                // Set database record ID for reference
                int hallid = Convert.ToInt32(this.dataGridViewFloorplanHall.CurrentRow.Cells[0].Value);
                DBGetData.QueryID = hallid;

                Form editForm = new EditFloorplanHall();
                editForm.ShowDialog();
            }
        }

        private void buttonSearchHall_Click(object sender, EventArgs e)
        {
            string searchinput = @textBoxSearch.Text.Trim();

            // Fetch dataset
            DataSet hallDS = DBGetData.GetFloorplanDGVHallSearch(searchinput);

            if(hallDS != null)
            {
                // No tables fetched
                if(hallDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if(hallDS.Tables[0].Rows.Count == 0)
                {
                    new StatusMessage("No datarows found matching search.");
                    return;
                }
                // Clear labelStatus for previous messages
                else
                {
                    new StatusMessage("");
                }

                // Set the dataset as source for datagridview and make sure its displayed
                dataGridViewFloorplanHall.DataSource = hallDS;
                dataGridViewFloorplanHall.DataMember = "Get_Floorplan_HallSearch";
                LoadDataGridViewHall();
            }
        }
    }
}
