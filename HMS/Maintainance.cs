using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HMS
{
    public partial class Maintainance : HMS.Content
    {
        public Maintainance()
        {
            InitializeComponent();
        }

        private void Maintainance_Load(object sender, EventArgs e)
        {
            LoadDataMaintainance();
            this.AcceptButton = buttonSearchMaintainance;
        }

        // Load dataGridViewTodo
        public void LoadDataGridViewMaintainance()
        {
            // Hide ID and make readable table headers
            dataGridViewMaintainance.Columns[0].Visible = false;
            dataGridViewMaintainance.Columns[1].HeaderText = "Location";
            dataGridViewMaintainance.Columns[2].HeaderText = "Description";
            dataGridViewMaintainance.Columns[3].HeaderText = "Priority";
            dataGridViewMaintainance.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMaintainance.Columns[4].HeaderText = "Created date";
            dataGridViewMaintainance.Columns[5].HeaderText = "Created by";
            dataGridViewMaintainance.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        // Load dataset to datagridview
        public void LoadDataMaintainance()
        {
            // Fetch dataset
            DataSet maintainanceDS = DBGetData.GetMaintainanceDGVActive();

            if(maintainanceDS != null)
            {
                // No tables fetched
                if(maintainanceDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if(maintainanceDS.Tables[0].Rows.Count == 0)
                {
                    new StatusMessage("No datarows found in maintainance.");
                    return;
                }
                // Clear labelStatus for previous messages
                else
                {
                    new StatusMessage("");
                }

                // Set the dataset as source for datagridview and make sure its displayed
                dataGridViewMaintainance.DataSource = maintainanceDS;
                dataGridViewMaintainance.DataMember = "Get_Maintainance_Active";
                LoadDataGridViewMaintainance();
            }
        }

        // TextBox 'Search' click event, empty placeholder text
        private void textBoxSearch_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBoxSearch.Text = "";
        }

        // DataGridViewMaintainance double click
        // Open specialized edit form
        private void dataGridViewMaintainance_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // TODO: Edit form
        }

        // Button 'New'
        private void buttonNewMaintainance_Click(object sender, EventArgs e)
        {
            // TODO: New form
        }

        // Button 'Edit'
        private void buttonEditMaintainance_Click(object sender, EventArgs e)
        {
            // TODO: Edit form
        }

        // Button 'Delete'
        private void buttonDeleteMaintainance_Click(object sender, EventArgs e)
        {
            // TODO: Mark post with isactive = 0
        }

        private void buttonSearchMaintainance_Click(object sender, EventArgs e)
        {
            string searchinput = @textBoxSearch.Text.Trim();

            // Fetch dataset
            DataSet maintainanceDS = DBGetData.GetMaintainanceDGVSearch(searchinput);

            if(maintainanceDS != null)
            {
                // No tables fetched
                if(maintainanceDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if(maintainanceDS.Tables[0].Rows.Count == 0)
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
                dataGridViewMaintainance.DataSource = maintainanceDS;
                dataGridViewMaintainance.DataMember = "Get_Maintainance_Search";
                LoadDataGridViewMaintainance();
            }
        }
    }
}
