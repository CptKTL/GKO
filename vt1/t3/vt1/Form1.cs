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
        List<Label> Tekstit = new List<Label>();

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

            Label newLabel = new Label();
            newLabel.BackColor = Color.Cyan;
            newLabel.AutoSize = true;
            newLabel.Text = this.textBox1.Text.Trim();
            Size size = TextRenderer.MeasureText(newLabel.Text, newLabel.Font);
            newLabel.Width = size.Width;
            newLabel.Margin = new Padding(3, 0, 3, 0);
            newLabel.TextAlign = ContentAlignment.MiddleCenter;
            newLabel.BorderStyle = BorderStyle.Fixed3D;
            newLabel.Padding = new Padding(5, 5,5 ,5);

            Tekstit.Add(newLabel);
            this.flowLayoutPanel1.Controls.Add(newLabel);
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

        private void jarjesta_Click(object sender, EventArgs e)
        {
            Tekstit.Sort(delegate (Label a, Label b)
            {
                return a.Text.Length - b.Text.Length;
            }
            );

            this.flowLayoutPanel1.Controls.Clear();
            foreach (var teksti in Tekstit) {
                this.flowLayoutPanel1.Controls.Add(teksti);
            }
            flowLayoutPanel1.Refresh();
        }

        /// <summary>
        /// Poistaa tekstilistauksen viimeisen tekstin kun tuplaklikataan paneelia.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flowLayoutPanel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Tekstit.Count <= 0)
            {
                flowLayoutPanel1.Refresh();
                return;
            }

            Label viimeinen = Tekstit.Last<Label>();
            flowLayoutPanel1.Controls.Remove(viimeinen);
            Tekstit.RemoveAt(Tekstit.Count - 1);
            flowLayoutPanel1.Refresh();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
