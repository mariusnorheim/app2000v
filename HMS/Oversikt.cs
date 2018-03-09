using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HMS
{
    public partial class Oversikt : HMS.UserInterface
    {
        public Oversikt()
        {
            InitializeComponent();
            this.labelHeading.Text = "Oversikt";
        }
    }
}
