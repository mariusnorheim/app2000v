using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HMS
{
    public partial class Booking : HMS.UserInterface
    {
        public Booking()
        {
            InitializeComponent();
            this.labelHeading.Text = "Booking";
        }

        private void Booking_Load(object sender, EventArgs e)
        {
            //ThreadPool.QueueUserWorkItem(new DBConn());
        }
    }
}
