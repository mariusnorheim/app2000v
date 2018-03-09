using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HMS
{
    public partial class Sjekkinnut : HMS.UserInterface
    {
        public Sjekkinnut()
        {
            InitializeComponent();
            this.labelHeading.Text = "Sjekk inn";
        }
    }
}
