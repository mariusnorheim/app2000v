using System;
using System.Data;
using System.Windows.Forms;

namespace HMS
{
    public partial class User : HMS.Content
    {
        public User()
        {
            InitializeComponent();
        }

        private void User_Load(object sender, EventArgs e)
        {
            LoadDataUser();
            this.AcceptButton = buttonSearchUser;
        }

        // Load dataGridViewUser
        public void LoadDataGridViewUser()
        {
            // Hide ID and make readable table headers
            dataGridViewUser.Columns[0].HeaderText = "Username";
            dataGridViewUser.Columns[1].HeaderText = "Firstname";
            dataGridViewUser.Columns[2].HeaderText = "Lastname";
            dataGridViewUser.Columns[3].HeaderText = "Superuser";
            dataGridViewUser.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        // Load dataset to datagridview
        public void LoadDataUser()
        {
            // Fetch dataset
            DataSet userDS = DBGetData.GetUserDGVActive();

            if(userDS != null)
            {
                // No tables fetched
                if(userDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if(userDS.Tables[0].Rows.Count == 0)
                {
                    new StatusMessage("No datarows found in admin.");
                    return;
                }
                // Clear labelStatus for previous messages
                else
                {
                    new StatusMessage("");
                }

                // Set the dataset as source for datagridview and make sure its displayed
                dataGridViewUser.DataSource = userDS;
                dataGridViewUser.DataMember = "Get_User_Active";
                LoadDataGridViewUser();
            }
        }

        // TextBox 'Search' click event, empty placeholder text
        private void textBoxSearch_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBoxSearch.Text = "";
        }

        // DataGridViewTodo double click
        // Open specialized edit form
        private void dataGridViewUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridViewUser.SelectedRows.Count > 0 && dataGridViewUser.CurrentRow != null)
            {
                // Set database record ID for reference
                DBGetData.UserID = Convert.ToString(this.dataGridViewUser.CurrentRow.Cells[0].Value);
                Form editForm = new EditUser();
                editForm.ShowDialog();
            }
        }

        // Button 'New'
        private void buttonNewUser_Click(object sender, EventArgs e)
        {
            Form userForm = new NewUser();
            userForm.ShowDialog();
        }

        // Button 'Edit'
        private void buttonEditUser_Click(object sender, EventArgs e)
        {
            if(dataGridViewUser.SelectedRows.Count > 0 && dataGridViewUser.CurrentRow != null)
            {
                // Set database record ID for reference
                DBGetData.UserID = Convert.ToString(this.dataGridViewUser.CurrentRow.Cells[0].Value);
                Form editForm = new EditUser();
                editForm.ShowDialog();
            }
        }

        // Button 'Delete'
        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            if(dataGridViewUser.SelectedRows.Count > 0 && dataGridViewUser.CurrentRow != null)
            {
                string adminid = Convert.ToString(dataGridViewUser.CurrentRow.Cells[0].Value);

                // Confirm delete
                DialogResult confirmDelete = MessageBox.Show("Deleting admin user with id " + adminid +
                                                             "\nAre you sure you want to continue?", "Warning!", MessageBoxButtons.YesNo);

                if(confirmDelete == DialogResult.Yes)
                {
                    // Save entry to database
                    DBSetData.UserDelete(adminid);
                    LoadDataUser();
                    new StatusMessage("Admin user removed from active list.");
                }
            }
        }

        // Button 'Search'
        private void buttonSearchUser_Click(object sender, EventArgs e)
        {
            string searchinput = @textBoxSearch.Text.Trim();

            // Fetch dataset
            DataSet userDS = DBGetData.GetUserDGVSearch(searchinput);

            if(userDS != null)
            {
                // No tables fetched
                if(userDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if(userDS.Tables[0].Rows.Count == 0)
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
                dataGridViewUser.DataSource = userDS;
                dataGridViewUser.DataMember = "Get_User_Search";
                LoadDataGridViewUser();
            }
        }
    }
}