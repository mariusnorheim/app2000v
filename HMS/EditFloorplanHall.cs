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
    public partial class EditFloorplanHall : HMS.PopupForm
    {
        Floorplan floorplanForm = (Floorplan)Application.OpenForms["Floorplan"];
        int hallid = DBGetData.QueryID;

        public EditFloorplanHall()
        {
            InitializeComponent();
            LoadDataHall();
        }

        // Loading data from database into comboBoxRoomType
        private void LoadDataHall()
        {
            // Fetch dataset
            DataSet halltypeListDS = DBGetData.GetHalltypeList();

            if(halltypeListDS != null)
            {
                // No tables fetched
                if(halltypeListDS.Tables.Count == 0)
                {
                    MessageBox.Show("No halltype datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if(halltypeListDS.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No datarows found in halltype table.");
                    return;
                }

                // Set the dataset as source for combobox
                comboBoxHallType.ValueMember = "hall_typeid";
                comboBoxHallType.DisplayMember = "name";
                comboBoxHallType.DataSource = halltypeListDS.Tables[0];
            }

            // Highlight existing values
            MySqlDataReader getValues = DBGetData.GetFloorplanHallData(hallid);
            if(getValues.Read())
            {
                textBoxHallname.Text = getValues.GetString(0);
                comboBoxHallType.SelectedValue = getValues.GetInt32(1);
            }

            getValues.Dispose();
        }

        // Button 'Save'
        private void buttonEditHallConfirm_Click(object sender, EventArgs e)
        {
            string hallname = textBoxHallname.Text;

            // Check for null or empty input
            if(string.IsNullOrWhiteSpace(hallname)) { MessageBox.Show("Hallname field is not filled in"); }
            
            if(!string.IsNullOrWhiteSpace(hallname) && comboBoxHallType.SelectedIndex > -1)
            {
                // Execute save
                int halltypeid = Convert.ToInt32(comboBoxHallType.SelectedValue);
                DBSetData.FloorplanHallEdit(hallid, hallname, halltypeid);
                // Close form
                this.Close();
                floorplanForm.LoadDataHall();
                floorplanForm.Refresh();
                new StatusMessage("Hall with name " + hallname + " is updated in the database.");
            }
        }

        // Button 'Cancel'
        private void buttonEditHallCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            floorplanForm.LoadDataHall();
        }
    }
}
