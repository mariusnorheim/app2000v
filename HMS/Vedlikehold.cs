using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HMS
{
    public partial class Vedlikehold : HMS.UserInterface
    {
        public Vedlikehold()
        {
            InitializeComponent();
            this.labelHeading.Text = "Vedlikehold";
        }
    }
}
