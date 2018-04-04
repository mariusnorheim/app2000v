using System;
using System.Data;
using System.Windows.Forms;

namespace HMS
{
    public partial class Guest : HMS.Content
    {
        public Guest()
        {
            InitializeComponent();
        }

        private void Gjest_Load(object sender, System.EventArgs e)
        {
            LoadDataGuest();
            this.AcceptButton = buttonSearchGuest;
        }

        // Load dataGridViewGuest
        public void LoadDataGridViewGuest()
        {
            // Hide ID and make readable table headers
            dataGridViewGuest.Columns[0].Visible = false;
            dataGridViewGuest.Columns[1].HeaderText = "Fornavn";
            dataGridViewGuest.Columns[2].HeaderText = "Etternavn";
            dataGridViewGuest.Columns[3].HeaderText = "Adresse";
            dataGridViewGuest.Columns[4].HeaderText = "Postkode";
            dataGridViewGuest.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewGuest.Columns[5].HeaderText = "By";
            dataGridViewGuest.Columns[6].HeaderText = "Telefon";
            dataGridViewGuest.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        // Load dataset
        public void LoadDataGuest()
        {
            // Fetch dataset
            DataSet guestDS = DBGetData.GetGuestsAll();

            if (guestDS != null)
            {
                // No tables fetched
                if (guestDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if (guestDS.Tables[0].Rows.Count == 0)
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
                dataGridViewGuest.DataSource = guestDS;
                dataGridViewGuest.DataMember = "GetGuests_All";
                LoadDataGridViewGuest();
            }
        }

        // DataGridViewRoom double click
        // Open specialized edit form
        private void dataGridViewGuest_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Set database record ID for reference
            DBGetData.QueryID = Convert.ToInt32(this.dataGridViewGuest.CurrentRow.Cells[0].Value);
            Form editForm = new EditGuest();
            editForm.ShowDialog();
        }

        // TextBox 'Search' click event, empty placeholder text
        private void textBoxSearch_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBoxSearch.Text = "";
        }

        // Button 'New'
        // Open specialized add form
        private void buttonNewGuest_Click(object sender, EventArgs e)
        {
            Form editForm = new NewGuest();
            editForm.ShowDialog();
        }

        // Button 'Edit'
        // Open specialized edit form
        private void buttonEditGuest_Click(object sender, EventArgs e)
        {
            // Set database record ID for reference
            DBGetData.QueryID = Convert.ToInt32(this.dataGridViewGuest.CurrentRow.Cells[0].Value);
            Form editForm = new EditGuest();
            editForm.ShowDialog();
        }

        // Button 'Search'
        // Searches result in guest table from textinput
        private void buttonSearchGuest_Click(object sender, EventArgs e)
        {
            string searchinput = @textBoxSearch.Text.Trim();

            // Fetch dataset
            DataSet guestDS = DBGetData.GetGuestsSearch(searchinput);

            if (guestDS != null)
            {
                // No tables fetched
                if (guestDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if (guestDS.Tables[0].Rows.Count == 0)
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
                dataGridViewGuest.DataSource = guestDS;
                dataGridViewGuest.DataMember = "GetGuests_Search";
                LoadDataGridViewGuest();
            }
        }
    }
}
