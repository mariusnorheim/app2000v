using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace HMS
{
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();

            // Default form load
            Overview oversiktForm = new Overview();
            DisplayChildForm(oversiktForm);
            this.labelHeading.Text = "Oversikt";
        }

        // Display child form in a panel
        private void DisplayChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.Parent = panelContent;
            panelContent.Parent = this;
            childForm.Activate();
            childForm.BringToFront();
            childForm.Show();
        }

        // Enable top panel dragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // Click handler for exit button
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        // Click handler for minimize button
        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Click handler for menu buttons
        private void buttonMenu1_Click(object sender, EventArgs e)
        {
            Form overviewForm = new Overview();
            DisplayChildForm(overviewForm);
            this.labelHeading.Text = "Overview";
        }

        private void buttonMenu2_Click(object sender, EventArgs e)
        {
            Form bookingForm = new Booking();
            DisplayChildForm(bookingForm);
            this.labelHeading.Text = "Booking";
        }

        private void buttonMenu3_Click(object sender, EventArgs e)
        {
            Form guestForm = new Guest();
            DisplayChildForm(guestForm);
            this.labelHeading.Text = "Guest";
        }

        private void buttonMenu4_Click(object sender, EventArgs e)
        {
            Form folioForm = new Folio();
            DisplayChildForm(folioForm);
            this.labelHeading.Text = "Folio";
        }

        private void buttonMenu5_Click(object sender, EventArgs e)
        {

        }

        private void buttonMenu6_Click(object sender, EventArgs e)
        {

        }

        private void buttonMenu7_Click(object sender, EventArgs e)
        {

        }

        private void buttonMenu8_Click(object sender, EventArgs e)
        {

        }

        private void buttonMenu9_Click(object sender, EventArgs e)
        {

        }

        private void buttonMenu10_Click(object sender, EventArgs e)
        {

        }
    }
}
