using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeniLaskuri
{
    public partial class Treenilaskuri : Form
    {
        public Treenilaskuri()
        {
            InitializeComponent();
        }

        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                LaskeButton.Enabled = true;
                return;
            }
            LaskeButton.Enabled = false;
        }

        /// <summary>
        /// Laskenappia klikatessa syötetään syötteeet paceLabelille.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                double matka;
                System.Globalization.NumberFormatInfo format = new System.Globalization.NumberFormatInfo();
                format.NumberDecimalSeparator = ",";
                try
                {
                    TimeSpan aika = TimeSpan.Parse(timeTextBox.Text);
                    try
                    {
                        matka = double.Parse(matkaNumberTextbox.Text, format);
                    }
                    catch (Exception exc)
                    {
                        format.NumberDecimalSeparator = ".";
                        matka = double.Parse(matkaNumberTextbox.Text, format);
                    }
                    double pace = aika.TotalMinutes / matka;
                    paceLabel.Time = aika;
                    paceLabel.Distance = matka;

                }
                catch (Exception ex)
                {

                }
            }
        }

        private void paceLabel_average(object sender, EventArgs e)
        {
            BackColor = Color.Yellow;
        }

        private void paceLabel_fast(object sender, EventArgs e)
        {
            BackColor = Color.Red;
        }

        private void paceLabel_slow(object sender, EventArgs e)
        {
            BackColor = Color.Green;
        }
    }
}
