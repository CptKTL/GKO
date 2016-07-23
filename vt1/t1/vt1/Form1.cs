using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vt1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lisää annetusta tekstistä textBoxin.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLisaa_Click(object sender, EventArgs e)
        {
            if ("".Equals(textBox1.Text.Trim())) return;

            Label newTextBox = new Label();
            newTextBox.BackColor = Color.Cyan;
            newTextBox.AutoSize = true;
            newTextBox.Text = this.textBox1.Text.Trim();
            Size size = TextRenderer.MeasureText(newTextBox.Text, newTextBox.Font);
            newTextBox.Width = size.Width;
            newTextBox.Margin = new Padding(3, 0, 3, 0);
            newTextBox.TextAlign = ContentAlignment.MiddleCenter;
            newTextBox.BorderStyle = BorderStyle.Fixed3D;
            newTextBox.Padding = new Padding(5, 5,5 ,5);

            this.flowLayoutPanel1.Controls.Add(newTextBox);
        }

        /// <summary>
        /// Avaa About ikkunan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}
