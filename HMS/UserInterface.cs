using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HMS
{
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonMenu1_Click(object sender, EventArgs e)
        {
            Oversikt oversiktForm = new Oversikt();
            oversiktForm.Show();
            this.Hide();
        }

        private void buttonMenu2_Click(object sender, EventArgs e)
        {
            Booking bookingForm = new Booking();
            bookingForm.Show();
            this.Hide();
        }

        private void buttonMenu3_Click(object sender, EventArgs e)
        {
            Sjekkinnut sjekkinnutForm = new Sjekkinnut();
            sjekkinnutForm.Show();
            this.Hide();
        }

        private void buttonMenu4_Click(object sender, EventArgs e)
        {
            Folio folioForm = new Folio();
            folioForm.Show();
            this.Hide();
        }

        private void buttonMenu5_Click(object sender, EventArgs e)
        {
            Arkiv arkivForm = new Arkiv();
            arkivForm.Show();
            this.Hide();
        }

        private void buttonMenu6_Click(object sender, EventArgs e)
        {
            Gjoremal gjoremalForm = new Gjoremal();
            gjoremalForm.Show();
            this.Hide();
        }

        private void buttonMenu7_Click(object sender, EventArgs e)
        {
            Rengjoring rengjoringForm = new Rengjoring();
            rengjoringForm.Show();
            this.Hide();
        }

        private void buttonMenu8_Click(object sender, EventArgs e)
        {
            Vedlikehold vedlikeholdForm = new Vedlikehold();
            vedlikeholdForm.Show();
            this.Hide();
        }

        private void buttonMenu9_Click(object sender, EventArgs e)
        {
            Brukere brukereForm = new Brukere();
            brukereForm.Show();
            this.Hide();
        }

        private void buttonMenu10_Click(object sender, EventArgs e)
        {
            Planlosning planlosningForm = new Planlosning();
            planlosningForm.Show();
            this.Hide();
        }
    }
}
