using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Kimmo Lappalainen.
/// Vt2.
/// </summary>
namespace Laskuri
{
    public partial class Laskuri : Form
    {
        public Laskuri()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Laskee nopeuden.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void laskeButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                System.Globalization.NumberFormatInfo format = new System.Globalization.NumberFormatInfo();
                format.NumberDecimalSeparator = ",";

                double d_nopeus = Double.Parse(matkaNumberTextBox1.Text) / Double.Parse(aikaNumberTextBox2.Text);
                nopeus.Text = string.Format(format, "{0:0.00} km/h", d_nopeus);
            }
        }

        private void NumberTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                laskeButton.Enabled = true;
            } else
            {
                laskeButton.Enabled = false;
            }
        }
    }

}
