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
    public partial class EditFolio : HMS.PopupForm
    {
        Folio folioForm = (Folio)Application.OpenForms["Folio"];
        int folioid = DBGetData.QueryID;

        public EditFolio()
        {
            InitializeComponent();
            this.AcceptButton = buttonSearchGuest;
        }

        private void EditFolio_Load(object sender, EventArgs e)
        {
            LoadDataFolio();
        }

        // Load data from guest, billing_item and folio_item tables into listboxes
        private void LoadDataFolio()
        {
            // Fetch dataset for guestlist
            DataSet guestListDS = DBGetData.GetGuestList();

            if (guestListDS != null)
            {
                // No tables fetched
                if (guestListDS.Tables.Count == 0)
                {
                    MessageBox.Show("No guest datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if (guestListDS.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No datarows found in guest table.");
                    return;
                }

                // Set the dataset as source for listbox
                listBoxGuest.ValueMember = "guestid";
                listBoxGuest.DisplayMember = "guest_name";
                listBoxGuest.DataSource = guestListDS.Tables[0];
            }

            // Fetch dataset for billingitems
            DataSet billingitemListDS = DBGetData.GetBillingItemList();

            if (billingitemListDS != null)
            {
                // No tables fetched
                if (billingitemListDS.Tables.Count == 0)
                {
                    MessageBox.Show("No billing_item datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if (billingitemListDS.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No datarows found in billing_item table.");
                    return;
                }

                // Set the dataset as source for listbox
                listBoxBillingItem.ValueMember = "billing_itemid";
                listBoxBillingItem.DisplayMember = "billing_itemname";
                listBoxBillingItem.DataSource = billingitemListDS.Tables[0];
            }

            // Set value and display member for listBoxFolioItem
            listBoxFolioItem.ValueMember = "billing_itemid";
            listBoxFolioItem.DisplayMember = "billing_itemname";

            // Highlight existing values
            MySqlDataReader getValues = DBGetData.GetFolioData(folioid);
            if (getValues.Read())
            {
                listBoxGuest.SelectedValue = Convert.ToInt32(getValues[0]);
            }

            getValues.Dispose();
        }

        // Button 'Search'
        // Search guest archive
        private void buttonSearchGuest_Click(object sender, EventArgs e)
        {
            string searchinput = @textBoxSearch.Text.Trim();

            // Fetch dataset
            DataSet guestListDS = DBGetData.GetGuestListSearch(searchinput);

            if (guestListDS != null)
            {
                // No tables fetched
                if (guestListDS.Tables.Count == 0)
                {
                    MessageBox.Show("No guest datatable found, contact administrator.");
                    return;
                }
                // No rows fetched
                else if (guestListDS.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No search result found in guest table.");
                    return;
                }

                // Set the dataset as source for listbox
                listBoxGuest.ValueMember = "guestid";
                listBoxGuest.DisplayMember = "guest_name";
                listBoxGuest.DataSource = guestListDS.Tables[0];
            }
        }

        // Button 'Add Item'
        // Add item from listBoxBillingItem to listBoxFolioItem
        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            if (listBoxBillingItem.SelectedIndex > -1)
            {
                listBoxFolioItem.Items.Add(listBoxBillingItem.SelectedItem);
            }
        }

        // Button 'Remove Item'
        // Remove item from listBoxFolioItem
        private void buttonRemoveItem_Click(object sender, EventArgs e)
        {
            if (listBoxFolioItem.SelectedIndex > -1)
            {
                listBoxFolioItem.Items.Remove(listBoxFolioItem.SelectedItem);
            }
        }

        // Button 'Save'
        // Validate input and insert into database
        private void buttonEditFolioConfirm_Click(object sender, EventArgs e)
        {
            // Validate that guest is selcted and folio has items
            if (listBoxGuest.SelectedIndex > -1 && listBoxFolioItem.Items.Count > 0)
            {
                // Reference variables
                Boolean guestchanged = false;
                Boolean guestconfirm = true;
                int guestid = Convert.ToInt32(listBoxGuest.SelectedValue);
                string adminid = UserInfo.AdminID;

                // Check if guestid has changed
                MySqlDataReader getFolioGuest = DBGetData.GetFolioGuest(folioid, guestid);
                if (getFolioGuest.Read()) { guestchanged = true; }
                getFolioGuest.Dispose();

                // Give warning if guest has changed and ask for confirmation
                if (!guestchanged)
                {
                    DialogResult guestDifferent = MessageBox.Show("You have changed the guest for this folio" +
                                                                  "\nAre you sure you want to continue?", "Warning!", MessageBoxButtons.YesNo);
                    if (guestDifferent == DialogResult.No)
                    {
                        // Cancel edit and reload data
                        guestconfirm = false;
                        LoadDataFolio();
                    }
                }

                if (guestconfirm)
                {
                    // Add new folio items to folio
                    foreach (DataRowView drv in listBoxFolioItem.Items)
                    {
                        int billingitemid = int.Parse(drv.Row[listBoxFolioItem.ValueMember].ToString());
                        DBSetData.FolioItemAdd(folioid, billingitemid, adminid);
                    }

                    // Refresh datagridview, close form and display new StatusMessage
                    folioForm.LoadDataFolio();
                    folioForm.Refresh();
                    this.Close();
                    new StatusMessage("Folio populated with " + listBoxFolioItem.Items.Count + " additional items.");
                }
            }
        }

        // Button 'Cancel'
        private void buttonEditFolioCancel_Click(object sender, EventArgs e)
        {
            folioForm.LoadDataFolio();
            this.Close();
        }
    }
}
