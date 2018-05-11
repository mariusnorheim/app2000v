using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HMS
{
    public partial class NewFolio : HMS.PopupForm
    {
        Folio folioForm = (Folio)Application.OpenForms["Folio"];

        public NewFolio()
        {
            InitializeComponent();
            this.AcceptButton = buttonSearchGuest;
        }

        private void NewFolio_Load(object sender, EventArgs e)
        {
            LoadDataFolio();
        }

        // Load data from guest and billing_item tables into listboxes
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
        private void buttonNewFolioConfirm_Click(object sender, EventArgs e)
        {
            Boolean folioexists = false;

            // Validate that guest is selcted and folio has items
            if (listBoxGuest.SelectedIndex > -1 && listBoxFolioItem.Items.Count > 0)
            {
                // Reference variables
                int guestid = Convert.ToInt32(listBoxGuest.SelectedValue);
                string adminid = UserInfo.AdminID;

                // Check -> Folio does not exist
                if (DBGetData.GetFolioExists(guestid) > 0) { folioexists = true; }
                if (folioexists) { MessageBox.Show("Guest already has an active folio, add any changes to existing."); }

                if (!folioexists)
                {
                    // Create new folio
                    DBSetData.FolioAdd(guestid, adminid);
                    // Fetch newly created folioid
                    MySqlDataReader getFolioid = DBGetData.GetFolioid(guestid);
                    if (getFolioid.Read())
                    {
                        // Add folio items to folio
                        int folioid = getFolioid.GetInt32(0);

                        foreach (DataRowView drv in listBoxFolioItem.Items)
                        {
                            int billingitemid = int.Parse(drv.Row[listBoxFolioItem.ValueMember].ToString());
                            DBSetData.FolioItemAdd(folioid, billingitemid, adminid);
                        }
                    }
                    else { MessageBox.Show("Could not fetch newly created folioid, try again or contact administrator."); }
                    getFolioid.Dispose();

                    // Refresh datagridview, close form and display new StatusMessage
                    folioForm.LoadDataFolio();
                    folioForm.Refresh();
                    this.Close();
                    new StatusMessage("Folio with " + listBoxFolioItem.Items.Count + " items added.");
                }
            }
        }

        // Button 'Cancel'
        private void buttonNewFolioCancel_Click(object sender, EventArgs e)
        {
            folioForm.LoadDataFolio();
            this.Close();
        }
    }
}
