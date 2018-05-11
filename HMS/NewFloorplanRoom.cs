using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HMS
{
    public partial class NewFloorplanRoom : HMS.PopupForm
    {
        Floorplan floorplanForm = (Floorplan)Application.OpenForms["Floorplan"];

        public NewFloorplanRoom()
        {
            InitializeComponent();
            LoadDataFloorplanRoom();
        }

        // Loading data from database into comboBoxRoomType
        private void LoadDataFloorplanRoom()
        {
            // Fetch dataset
            DataSet roomtypeListDS = DBGetData.GetRoomtypeList();

            if(roomtypeListDS != null)
            {
                // No tables fetched
                if(roomtypeListDS.Tables.Count == 0)
                {
                    MessageBox.Show("No roomtype datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if(roomtypeListDS.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No datarows found in roomtype table.");
                    return;
                }

                // Set the dataset as source for combobox
                comboBoxRoomType.ValueMember = "room_typeid";
                comboBoxRoomType.DisplayMember = "name";
                comboBoxRoomType.DataSource = roomtypeListDS.Tables[0];
            }
        }

        // Button 'Save'
        private void buttonNewGuestConfirm_Click(object sender, EventArgs e)
        {
            Boolean roomexists = false;
            Boolean roomvalid = false;
            int roomid;
            int roomtypeid = Convert.ToInt32(comboBoxRoomType.SelectedValue);

            // Check if the point entered is numeric
            if(Int32.TryParse(textBoxRoomid.Text, out roomid))
            {
                roomvalid = true;

                if(DBGetData.GetFloorplanRoomExists(roomid) > 0)
                {
                    roomexists = true;
                    MessageBox.Show("Room number already exists, select a different number.");
                }
            }
            else
            {
                MessageBox.Show("Only numbers (0-9) are allowed in the room number.");
            }

            // Execute save
            if(!roomexists && roomvalid)
            {
                DBSetData.FloorplanRoomAdd(roomid, roomtypeid);
                // Close form
                this.Close();
                floorplanForm.LoadDataRoom();
                floorplanForm.Refresh();
                new StatusMessage("Room with number " + roomid + " is added to the database.");
            }
        }

        // Button 'Cancel'
        private void buttonNewGuestCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            floorplanForm.LoadDataRoom();
        }
    }
}
