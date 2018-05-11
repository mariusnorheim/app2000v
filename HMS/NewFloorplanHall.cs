using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HMS
{
    public partial class NewFloorplanHall : HMS.PopupForm
    {
        Floorplan floorplanForm = (Floorplan)Application.OpenForms["Floorplan"];

        public NewFloorplanHall()
        {
            InitializeComponent();
            LoadDataFloorplanHall();
        }

        // Loading data from database into comboBoxRoomType
        private void LoadDataFloorplanHall()
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
        }

        // Button 'Save'
        private void buttonNewHallConfirm_Click(object sender, EventArgs e)
        {
            Boolean hallexists = false;
            string hallname = textBoxHallname.Text;

            if(DBGetData.GetFloorplanHallExists(hallname) > 0)
            {
                hallexists = true;
                MessageBox.Show("Hall name already exists, select a different name.");
            }

            // Execute save
            if(!hallexists && !string.IsNullOrWhiteSpace(hallname) && comboBoxHallType.SelectedIndex > -1)
            {
                int halltypeid = Convert.ToInt32(comboBoxHallType.SelectedValue);
                DBSetData.FloorplanHallAdd(hallname, halltypeid);
                // Close form
                this.Close();
                floorplanForm.LoadDataHall();
                floorplanForm.Refresh();
                new StatusMessage("Hall with name " + hallname + " is added to the database.");
            }
        }

        // Button 'Cancel'
        private void buttonNewHallCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            floorplanForm.LoadDataHall();
        }
    }
}
