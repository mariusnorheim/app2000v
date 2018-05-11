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
    public partial class EditFloorplanRoom : HMS.PopupForm
    {
        Floorplan floorplanForm = (Floorplan)Application.OpenForms["Floorplan"];
        int roomid = DBGetData.QueryID;

        public EditFloorplanRoom()
        {
            InitializeComponent();
            LoadDataRoom();
        }

        // Loading data from database into comboBoxRoomType
        private void LoadDataRoom()
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

            // Highlight existing values
            textBoxRoomid.Text = roomid.ToString();

            MySqlDataReader getValues = DBGetData.GetFloorplanRoomData(roomid);
            if(getValues.Read())
            {
                comboBoxRoomType.SelectedValue = getValues.GetInt32(0);
            }

            getValues.Dispose();
        }

        // Button 'Save'
        private void buttonNewRoomConfirm_Click(object sender, EventArgs e)
        {
            if(comboBoxRoomType.SelectedIndex > -1)
            {
                // Execute save
                int roomtypeid = Convert.ToInt32(comboBoxRoomType.SelectedValue);
                DBSetData.FloorplanRoomEdit(roomid, roomtypeid);
                // Close form
                this.Close();
                floorplanForm.LoadDataRoom();
                floorplanForm.Refresh();
                new StatusMessage("Room with number " + roomid + " is updated in the database.");
            }
        }

        // Button 'Cancel'
        private void buttonNewRoomCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            floorplanForm.LoadDataRoom();
        }
    }
}