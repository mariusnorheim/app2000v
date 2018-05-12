using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HMS
{
    public partial class Messages : HMS.Content
    {
        public Messages()
        {
            InitializeComponent();
        }

        private void Messages_Load(object sender, EventArgs e)
        {
            LoadDataMessage();
            this.AcceptButton = buttonSearchMessage;
        }

        // Load dataGridViewMessage
        public void LoadDataGridViewMessage()
        {
            // Hide ID and make readable table headers
            dataGridViewMessage.Columns[0].Visible = false;
            dataGridViewMessage.Columns[1].HeaderText = "Recipient";
            dataGridViewMessage.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMessage.Columns[2].HeaderText = "Sender";
            dataGridViewMessage.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMessage.Columns[3].HeaderText = "Message";
            dataGridViewMessage.Columns[4].HeaderText = "Priority";
            dataGridViewMessage.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMessage.Columns[5].HeaderText = "Created";
            dataGridViewMessage.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMessage.Columns[6].HeaderText = "Created by";
            dataGridViewMessage.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        // Load dataset to datagridview
        public void LoadDataMessage()
        {
            // Fetch dataset
            DataSet messageDS = DBGetData.GetMessageDGVActive();

            if(messageDS != null)
            {
                // No tables fetched
                if(messageDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if(messageDS.Tables[0].Rows.Count == 0)
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
                dataGridViewMessage.DataSource = messageDS;
                dataGridViewMessage.DataMember = "Get_Message_Active";
                LoadDataGridViewMessage();
            }
        }

        // TextBox 'Search' click event, empty placeholder text
        private void textBoxSearch_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBoxSearch.Text = "";
        }

        // DataGridViewTodo double click
        // Open specialized edit form
        private void dataGridViewMessage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // TODO: Edit form
        }

        // Button 'New'
        private void buttonNewMessage_Click(object sender, EventArgs e)
        {
            // TODO: New form
        }

        private void buttonEditMessage_Click(object sender, EventArgs e)
        {
            // TODO: Edit form
        }

        private void buttonReadMessage_Click(object sender, EventArgs e)
        {
            // TODO: Mark record with isactive = 0
        }

        // Button 'Search'
        private void buttonSearchMessage_Click(object sender, EventArgs e)
        {
            string searchinput = @textBoxSearch.Text.Trim();

            // Fetch dataset
            DataSet messageDS = DBGetData.GetTodoDGVSearch(searchinput);

            if(messageDS != null)
            {
                // No tables fetched
                if(messageDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if(messageDS.Tables[0].Rows.Count == 0)
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
                dataGridViewMessage.DataSource = messageDS;
                dataGridViewMessage.DataMember = "Get_Message_Search";
                LoadDataGridViewMessage();
            }
        }
    }
}
