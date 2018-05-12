using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HMS
{
    public partial class Payment : HMS.Content
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            LoadDataPaymentItem();
            this.AcceptButton = buttonSearchPaymentItem;
        }

        // Load dataGridViePaymentItem
        public void LoadDataGridViewPaymentItem()
        {
            // Hide ID and make readable table headers
            dataGridViewPaymentItem.Columns[0].Visible = false;
            dataGridViewPaymentItem.Columns[1].HeaderText = "Item name";
            dataGridViewPaymentItem.Columns[2].HeaderText = "Cost";
            dataGridViewPaymentItem.Columns[3].HeaderText = "Category";
            dataGridViewPaymentItem.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        // Load dataset to datagridview
        public void LoadDataPaymentItem()
        {
            // Fetch dataset
            DataSet paymentitemDS = DBGetData.GetPaymentItemDGVAll();

            if(paymentitemDS != null)
            {
                // No tables fetched
                if(paymentitemDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if(paymentitemDS.Tables[0].Rows.Count == 0)
                {
                    new StatusMessage("No datarows found in billing_item.");
                    return;
                }
                // Clear labelStatus for previous messages
                else
                {
                    new StatusMessage("");
                }

                // Set the dataset as source for datagridview and make sure its displayed
                dataGridViewPaymentItem.DataSource = paymentitemDS;
                dataGridViewPaymentItem.DataMember = "Get_PaymentItem_All";
                LoadDataGridViewPaymentItem();
            }
        }

        // Button 'Item'
        private void buttonSubMenu1_Click(object sender, EventArgs e)
        {
            LoadDataPaymentItem();
            this.AcceptButton = buttonSearchPaymentItem;
        }

        // Button 'Category'
        private void buttonSubMenu2_Click(object sender, EventArgs e)
        {

        }

        //
        // Item section
        //

        // DataGridViewPaymentItem double click
        // Open specialized edit form
        private void dataGridViewPaymentItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // TODO: Edit form
        }

        // Button 'New'
        private void buttonNewPaymentItem_Click(object sender, EventArgs e)
        {
            // TODO: New form
        }

        // Button 'Edit'
        private void buttonEditPaymentItem_Click(object sender, EventArgs e)
        {
            // TODO: Edit form
        }

        // Button 'Delete'
        private void buttonDeletePaymentItem_Click(object sender, EventArgs e)
        {
            // TODO: Delete item
        }

        // Button 'Search'
        private void buttonSearchPaymentItem_Click(object sender, EventArgs e)
        {
            string searchinput = @textBoxSearch.Text.Trim();

            // Fetch dataset
            DataSet paymentitemDS = DBGetData.GetPaymentItemDGVSearch(searchinput);

            if(paymentitemDS != null)
            {
                // No tables fetched
                if(paymentitemDS.Tables.Count == 0)
                {
                    new StatusMessage("No datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if(paymentitemDS.Tables[0].Rows.Count == 0)
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
                dataGridViewPaymentItem.DataSource = paymentitemDS;
                dataGridViewPaymentItem.DataMember = "Get_PaymentItem_Search";
                LoadDataGridViewPaymentItem();
            }
        }


        //
        // Category section
        //
    }
}
