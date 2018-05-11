using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HMS
{
    public partial class Housekeeping : HMS.Content
    {
        public Housekeeping()
        {
            InitializeComponent();
        }

        private void Housekeeping_Load(object sender, EventArgs e)
        {
            LoadDataHousekeeping();
            this.AcceptButton = buttonSearchHousekeeping;
        }

        // Load dataGridViewTodo
        public void LoadDataGridViewHousekeeping()
        {
            // Hide ID and make readable table headers
            dataGridViewHousekeeping.Columns[0].Visible = false;
            dataGridViewHousekeeping.Columns[1].HeaderText = "Room";
            dataGridViewHousekeeping.Columns[2].HeaderText = "Code";
            dataGridViewHousekeeping.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewHousekeeping.Columns[3].HeaderText = "Remark";
        }

        // Load dataset to datagridview
        public void LoadDataHousekeeping()
        {
            // Fetch dataset
            DataSet housekeepingDS = DBGetData.GetHousekeepingDGVActive();

            if(housekeepingDS != null)
            {
                // No tables fetched
                if(housekeepingDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if(housekeepingDS.Tables[0].Rows.Count == 0)
                {
                    new StatusMessage("No datarows found in housekeeping.");
                    return;
                }
                // Clear labelStatus for previous messages
                else
                {
                    new StatusMessage("");
                }

                // Set the dataset as source for datagridview and make sure its displayed
                dataGridViewHousekeeping.DataSource = housekeepingDS;
                dataGridViewHousekeeping.DataMember = "Get_Housekeeping_Active";
                LoadDataGridViewHousekeeping();
            }
        }

        // TextBox 'Search' click event, empty placeholder text
        private void textBoxSearch_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBoxSearch.Text = "";
        }

        // DataGridViewHousekeeping double click
        // Open specialized edit form
        private void dataGridViewHousekeeping_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // TODO: Edit form
        }

        // Button 'New'
        private void buttonNewHousekeeping_Click(object sender, EventArgs e)
        {
            // TODO: New form
        }

        // Button 'Edit'
        private void buttonEditHousekeeping_Click(object sender, EventArgs e)
        {
            // TODO: Edit form
        }

        // Button 'Completed'
        private void buttonDeleteHousekeeping_Click(object sender, EventArgs e)
        {
            // TODO: Mark post with inactive = 0
        }

        // Button 'Search'
        private void buttonSearchHousekeeping_Click(object sender, EventArgs e)
        {
            string searchinput = @textBoxSearch.Text.Trim();

            // Fetch dataset
            DataSet housekeepingDS = DBGetData.GetHousekeepingDGVSearch(searchinput);

            if(housekeepingDS != null)
            {
                // No tables fetched
                if(housekeepingDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if(housekeepingDS.Tables[0].Rows.Count == 0)
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
                dataGridViewHousekeeping.DataSource = housekeepingDS;
                dataGridViewHousekeeping.DataMember = "Get_Housekeeping_Search";
                LoadDataGridViewHousekeeping();
            }
        }
    }
}
