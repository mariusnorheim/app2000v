using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HMS
{
    public partial class Planlosning : HMS.UserInterface
    {
        public Planlosning()
        {
            InitializeComponent();
            this.labelHeading.Text = "Planløsning";
        }
    }
}
