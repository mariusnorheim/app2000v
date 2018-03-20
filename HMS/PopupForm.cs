using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS
{
    public partial class PopupForm : Form
    {
        public PopupForm()
        {
            InitializeComponent();
            // Prevent opening more than one popup form
            /*
            if (Application.OpenForms.OfType<PopupForm>().Count() == 1)
            {
                Application.OpenForms.OfType<PopupForm>().First().Close();
            }
            */
        }
    }
}
