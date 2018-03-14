﻿using System;
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

            // Default form load
            Oversikt oversiktForm = new Oversikt();
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
            Form oversiktForm = new Oversikt();
            DisplayChildForm(oversiktForm);
            this.labelHeading.Text = "Oversikt";
        }

        private void buttonMenu2_Click(object sender, EventArgs e)
        {
            Form bookingForm = new Booking();
            DisplayChildForm(bookingForm);
            this.labelHeading.Text = "Booking";
        }

        private void buttonMenu3_Click(object sender, EventArgs e)
        {
            Form sjekkinnutForm = new Sjekkinnut();
            DisplayChildForm(sjekkinnutForm);
            this.labelHeading.Text = "Sjekk inn/ut";
        }

        private void buttonMenu4_Click(object sender, EventArgs e)
        {
            Form folioForm = new Folio();
            DisplayChildForm(folioForm);
            this.labelHeading.Text = "Folio";
        }

        private void buttonMenu5_Click(object sender, EventArgs e)
        {
            Form arkivForm = new Arkiv();
            DisplayChildForm(arkivForm);
            this.labelHeading.Text = "Arkiv";
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
