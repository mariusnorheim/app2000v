using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HMS
{
    public partial class NewGuestForm : HMS.PopupForm
    {
        public NewGuestForm()
        {
            InitializeComponent();
        }

        private void buttonNewGuestConfirm_Click(object sender, EventArgs e)
        {

        }

        private void buttonNewGuestCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
