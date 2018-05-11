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
    public partial class Todo : HMS.Content
    {
        public Todo()
        {
            InitializeComponent();
        }

        private void Todo_Load(object sender, EventArgs e)
        {
            LoadDataTodo();
            this.AcceptButton = buttonSearchTodo;
        }

        // Load dataGridViewTodo
        public void LoadDataGridViewTodo()
        {
            // Hide ID and make readable table headers
            dataGridViewTodo.Columns[0].Visible = false;
            dataGridViewTodo.Columns[1].HeaderText = "Hall name";
            dataGridViewTodo.Columns[2].HeaderText = "Halltype";
            dataGridViewTodo.Columns[3].HeaderText = "Event start";
            dataGridViewTodo.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTodo.Columns[4].HeaderText = "Event end";
            dataGridViewTodo.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTodo.Columns[5].HeaderText = "Description";
            dataGridViewTodo.Columns[6].HeaderText = "Created by";
            dataGridViewTodo.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        // Load dataset to datagridview
        public void LoadDataTodo()
        {
            // Fetch dataset
            DataSet todoDS = DBGetData.GetTodoDGVActive();

            if (todoDS != null)
            {
                // No tables fetched
                if (todoDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if (todoDS.Tables[0].Rows.Count == 0)
                {
                    new StatusMessage("No datarows found in todo.");
                    return;
                }
                // Clear labelStatus for previous messages
                else
                {
                    new StatusMessage("");
                }

                // Set the dataset as source for datagridview and make sure its displayed
                dataGridViewTodo.DataSource = todoDS;
                dataGridViewTodo.DataMember = "Get_Todo_Active";
                LoadDataGridViewTodo();
            }
        }

        // TextBox 'Search' click event, empty placeholder text
        private void textBoxSearch_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBoxSearch.Text = "";
        }

        // DataGridViewTodo double click
        // Open specialized edit form
        private void dataGridViewTodo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // TODO: Same as 'edit' button
        }

        // Button 'New'
        private void buttonNewTodo_Click(object sender, EventArgs e)
        {
            // TODO: Open new form
        }

        // Button 'Edit'
        private void buttonEditTodo_Click(object sender, EventArgs e)
        {
            // TODO: Open edit form
        }

        // Button 'Delete'
        private void buttonTodoDelete_Click(object sender, EventArgs e)
        {
            // TODO: Mark database entry with 'isactive = 0'
        }

        // Button 'Search'
        private void buttonSearchTodo_Click(object sender, EventArgs e)
        {
            string searchinput = @textBoxSearch.Text.Trim();

            // Fetch dataset
            DataSet todoDS = DBGetData.GetTodoDGVSearch(searchinput);

            if (todoDS != null)
            {
                // No tables fetched
                if (todoDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if (todoDS.Tables[0].Rows.Count == 0)
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
                dataGridViewTodo.DataSource = todoDS;
                dataGridViewTodo.DataMember = "Get_Todo_Search";
                LoadDataGridViewTodo();
            }
        }
    }
}
