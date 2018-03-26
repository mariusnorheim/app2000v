using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HMS
{
    public partial class Folio : HMS.Content
    {
        string query;

        public Folio()
        {
            InitializeComponent();
        }

        private void Folio_Load(object sender, System.EventArgs e)
        {
            //LoadDataFaktura();
        }

        private void buttonSubMenu1_Click(object sender, EventArgs e)
        {

        }

        private void buttonSubMenu2_Click(object sender, EventArgs e)
        {

        }

        private void buttonNewFolio_Click(object sender, EventArgs e)
        {

        }

        private void buttonEditFolio_Click(object sender, EventArgs e)
        {

        }

        private void buttonSearchFolio_Click(object sender, EventArgs e)
        {

        }

        // TextBox 'Search' click event, empty placeholder text
        private void textBoxSearch_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBoxSearch.Text = "";
        }
    }
}
