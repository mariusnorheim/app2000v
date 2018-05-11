using System;
using System.Data;
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
            dataGridViewFolio.Columns[1].HeaderText = "Firstname";
            dataGridViewFolio.Columns[2].HeaderText = "Lastname";
            dataGridViewFolio.Columns[3].HeaderText = "Total cost";
            dataGridViewFolio.Columns[4].HeaderText = "Due date";
            dataGridViewFolio.Columns[5].HeaderText = "Created by";
            dataGridViewFolio.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        // Load dataset to datagridview
        public void LoadDataFolio()
        {
            // Fetch dataset
            DataSet folioDS = DBGetData.GetFolioDGVAll();

            if(folioDS != null)
            {
                // No tables fetched
                if(folioDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if(folioDS.Tables[0].Rows.Count == 0)
                {
                    new StatusMessage("No datarows found in folio.");
                    return;
                }
                // Clear labelStatus for previous messages
                else
                {
                    new StatusMessage("");
                }

                // Set the dataset as source for datagridview and make sure its displayed
                dataGridViewFolio.DataSource = folioDS;
                dataGridViewFolio.DataMember = "Get_Folio_Active";
                LoadDataGridViewFolio();
            }
        }

        private void buttonDisplayAll_Click(object sender, EventArgs e)
        {
            LoadDataFolio();
        }

        private void buttonDisplayDue_Click(object sender, EventArgs e)
        {
            // Fetch dataset
            DataSet folioDS = DBGetData.GetFolioDGVDue();

            if(folioDS != null)
            {
                // No tables fetched
                if(folioDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if(folioDS.Tables[0].Rows.Count == 0)
                {
                    new StatusMessage("No datarows found in folio marked with due date.");
                    return;
                }
                // Clear labelStatus for previous messages
                else
                {
                    new StatusMessage("");
                }

                // Set the dataset as source for datagridview and make sure its displayed
                dataGridViewFolio.DataSource = folioDS;
                dataGridViewFolio.DataMember = "Get_Folio_Due";
                LoadDataGridViewFolio();
            }
        }

        // DataGridViewFolio double click
        // Open specialized edit form
        private void dataGridViewFolio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewFolio.SelectedRows.Count > 0 && dataGridViewFolio.CurrentRow != null)
            {
                // Set database record ID for reference
                int folioid = Convert.ToInt32(this.dataGridViewFolio.CurrentRow.Cells[0].Value);
                DBGetData.QueryID = folioid;
                Boolean duedate = false;

                MySqlDataReader getFolioDueStatus = DBGetData.GetFolioDueDate(folioid);
                if (getFolioDueStatus.Read()) { duedate = true; }
                getFolioDueStatus.Dispose();
                if (duedate) { new StatusMessage("Folio has existing due date, cant make changes."); }
                else
                {
                    Form editForm = new EditFolio();
                    editForm.ShowDialog();
                }
            }
        }

        // TextBox 'Search' click event, empty placeholder text
        private void textBoxSearch_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBoxSearch.Text = "";
        }

        // Button 'New'
        private void buttonNewFolio_Click(object sender, EventArgs e)
        {
            Form folioForm = new NewFolio();
            folioForm.ShowDialog();
        }

        // Button 'Edit'
        private void buttonEditFolio_Click(object sender, EventArgs e)
        {
            if (dataGridViewFolio.SelectedRows.Count > 0 && dataGridViewFolio.CurrentRow != null)
            {
                // Set database record ID for reference
                int folioid = Convert.ToInt32(this.dataGridViewFolio.CurrentRow.Cells[0].Value);
                DBGetData.QueryID = folioid;
                Boolean duedate = false;

                MySqlDataReader getFolioDueStatus = DBGetData.GetFolioDueDate(folioid);
                if (getFolioDueStatus.Read()) { duedate = true; }
                getFolioDueStatus.Dispose();
                if (duedate) { new StatusMessage("Folio has existing due date, cant make changes."); }
                else
                {
                    Form editForm = new EditFolio();
                    editForm.ShowDialog();
                }
            }
        }

        private void buttonSetDuedate_Click(object sender, EventArgs e)
        {
            Boolean duedate = false;
            Boolean roomreservation = false;
            Boolean hallreservation = false;

            if (dataGridViewFolio.SelectedRows.Count > 0 && dataGridViewFolio.CurrentRow != null)
            {
                int folioid = Convert.ToInt32(dataGridViewFolio.CurrentRow.Cells[0].Value);
                string firstname = Convert.ToString(dataGridViewFolio.CurrentRow.Cells[1].Value);
                string lastname = Convert.ToString(dataGridViewFolio.CurrentRow.Cells[2].Value);
                Decimal foliototal = Convert.ToDecimal(dataGridViewFolio.CurrentRow.Cells[3].Value);

                // Confirm setting due date
                DialogResult confirmDuedate = MessageBox.Show("Setting due date 21 days from today on folio that belongs to " + firstname + " " + lastname +
                                                              " with a total cost of kr " + foliototal +
                                                              "\nAre you sure you want to continue?", "Warning!", MessageBoxButtons.YesNo);

                if (confirmDuedate == DialogResult.Yes)
                {
                    // Checks -> Folio already has due date, Folio has room reservation active, Folio has hall reservation active
                    MySqlDataReader getFolioDueStatus = DBGetData.GetFolioDueDate(folioid);
                    if (getFolioDueStatus.Read()) { duedate = true; }
                    getFolioDueStatus.Dispose();
                    if (duedate) { new StatusMessage("Folio already has existing due date."); }

                    if (DBGetData.GetFolioRoomreservation(folioid) > 0) { roomreservation = true; }
                    if (roomreservation) { new StatusMessage("Folio owner has an active room reservation, cannot mark with due date until after checkout."); }

                    if (DBGetData.GetFolioHallreservation(folioid) > 0) { hallreservation = true; }
                    if (hallreservation) { new StatusMessage("Folio owner has an active hall reservation, cannot mark with due date until after checkout."); }

                    if (!duedate && !roomreservation && !hallreservation)
                    {
                        // Save entry to database
                        DBSetData.FolioDueDate(folioid);
                        LoadDataFolio();
                        dataGridViewFolio.Refresh();
                        new StatusMessage("Folio marked with due date 21 days from today.");
                    }
                }
            }
        }

        private void buttonSetPaid_Click(object sender, EventArgs e)
        {
            Boolean paiddate = false;
            Boolean roomreservation = false;
            Boolean hallreservation = false;

            if (dataGridViewFolio.SelectedRows.Count > 0 && dataGridViewFolio.CurrentRow != null)
            {
                int folioid = Convert.ToInt32(dataGridViewFolio.CurrentRow.Cells[0].Value);
                string firstname = Convert.ToString(dataGridViewFolio.CurrentRow.Cells[1].Value);
                string lastname = Convert.ToString(dataGridViewFolio.CurrentRow.Cells[2].Value);
                Decimal foliototal = Convert.ToDecimal(dataGridViewFolio.CurrentRow.Cells[3].Value);

                // Confirm setting due date
                DialogResult confirmPaiddate = MessageBox.Show("Setting paid date today on folio that belongs to " + firstname + " " + lastname +
                                                              " with a total cost of kr " + foliototal +
                                                              "\nAre you sure you want to continue?", "Warning!", MessageBoxButtons.YesNo);

                if (confirmPaiddate == DialogResult.Yes)
                {
                    // Checks -> Folio already has paid date, Folio has room reservation active, Folio has hall reservation active
                    MySqlDataReader getFolioPaidStatus = DBGetData.GetFolioPaidDate(folioid);
                    if (getFolioPaidStatus.Read()) { paiddate = true; }
                    getFolioPaidStatus.Dispose();
                    if (paiddate) { new StatusMessage("Folio has already been paid."); }

                    if (DBGetData.GetFolioRoomreservation(folioid) > 0) { roomreservation = true; }
                    if (roomreservation) { new StatusMessage("Folio owner has an active room reservation, cannot mark with paid date until after checkout."); }

                    if (DBGetData.GetFolioHallreservation(folioid) > 0) { hallreservation = true; }
                    if (hallreservation) { new StatusMessage("Folio owner has an active hall reservation, cannot mark with paid date until after checkout."); }

                    if (!paiddate && !roomreservation && !hallreservation)
                    {
                        // Save entry to database
                        DBSetData.FolioPaidDate(folioid);
                        LoadDataFolio();
                        dataGridViewFolio.Refresh();
                        new StatusMessage("Folio marked as paid today.");
                    }
                }
            }
        }

        // Button 'Search'
        private void buttonSearchFolio_Click(object sender, EventArgs e)
        {
            string searchinput = @textBoxSearch.Text.Trim();

            // Fetch dataset
            DataSet folioDS = DBGetData.GetFolioDGVSearch(searchinput);

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
                    new StatusMessage("No datarows found matching search.");
                    return;
                }
                // Clear labelStatus for previous messages
                else
                {
                    new StatusMessage("");
                }

                // Set the dataset as source for datagridview and make sure its displayed
                dataGridViewFolio.DataSource = folioDS;
                dataGridViewFolio.DataMember = "Get_Folio_Search";
                LoadDataGridViewFolio();
            }
        }
    }
}