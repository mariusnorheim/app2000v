using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HMS
{
    public partial class Arkiv : HMS.UserInterface
    {
        public Arkiv()
        {
            InitializeComponent();
            this.labelHeading.Text = "Arkiv";
        }
    }
}
