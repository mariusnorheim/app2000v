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
    public partial class Folio : HMS.Content
    {
        public Folio()
        {
            InitializeComponent();
        }

        private void Folio_Load(object sender, System.EventArgs e)
        {
            LoadDataFolio();
            this.AcceptButton = buttonSearchFolio;
        }

        // Load dataGridViewFolio
        public void LoadDataGridViewFolio()
        {
            // Hide ID and make readable table headers
            dataGridViewFolio.Columns[0].Visible = false;
            dataGridViewFolio.Columns[1].HeaderText = "Fornavn";
            dataGridViewFolio.Columns[2].HeaderText = "Etternavn";
            dataGridViewFolio.Columns[3].HeaderText = "Romnummer";
            dataGridViewFolio.Columns[4].HeaderText = "Total kostnad";
            dataGridViewFolio.Columns[5].HeaderText = "Forfallsdato";
            dataGridViewFolio.Columns[6].HeaderText = "Laget av";
            dataGridViewFolio.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        // Load dataset to datagridview
        public void LoadDataFolio()
        {
            // Fetch dataset
            DataSet folioDS = DBGetData.GetFoliosAll(1);

            if (folioDS != null)
            {
                // No tables fetched
                if (folioDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if (folioDS.Tables[0].Rows.Count == 0)
                {
                    new StatusMessage("No datarows found for this month.");
                    return;
                }
                // Clear labelStatus for previous messages
                else
                {
                    new StatusMessage("");
                }

                // Set the dataset as source for datagridview and make sure its displayed
                dataGridViewFolio.DataSource = folioDS;
                dataGridViewFolio.DataMember = "GetFolios_Active";
                LoadDataGridViewFolio();
            }
        }

        // DataGridViewRoom double click
        // Open specialized edit form
        private void dataGridViewGuest_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Set database record ID for reference
            DBGetData.QueryID = Convert.ToInt32(this.dataGridViewFolio.CurrentRow.Cells[0].Value);
            Form editForm = new EditGuest();
            editForm.ShowDialog();
        }

        // TextBox 'Search' click event, empty placeholder text
        private void textBoxSearch_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBoxSearch.Text = "";
        }

        // Button 'New'
        private void buttonNewFolio_Click(object sender, EventArgs e)
        {

        }

        // Button 'Edit'
        private void buttonEditFolio_Click(object sender, EventArgs e)
        {

        }

        // Button 'Search'
        private void buttonSearchFolio_Click(object sender, EventArgs e)
        {
            string searchinput = @textBoxSearch.Text.Trim();

            // Fetch dataset
            DataSet folioDS = DBGetData.GetFoliosSearch(searchinput);

            if (folioDS != null)
            {
                // No tables fetched
                if (folioDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if (folioDS.Tables[0].Rows.Count == 0)
                {
                    new StatusMessage("No datarows found for this month.");
                    return;
                }
                // Clear labelStatus for previous messages
                else
                {
                    new StatusMessage("");
                }

                // Set the dataset as source for datagridview and make sure its displayed
                dataGridViewFolio.DataSource = folioDS;
                dataGridViewFolio.DataMember = "GetFolios_Search";
                LoadDataGridViewFolio();
            }
        }
    }
}
