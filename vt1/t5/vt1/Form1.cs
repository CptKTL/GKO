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
        List<Control> UndoList = new List<Control>();
        List<Control> RedoList = new List<Control>();
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
            newLabel.Click += new System.EventHandler(this.Muokkaa);
            
            Tekstit.Add(newLabel);
            this.flowLayoutPanel1.Controls.Add(newLabel);

            UndoList.Add(newLabel);
            RedoList.Clear();
        }

        /// <summary>
        /// Kumoaa poista tai lisää toiminnot.
        /// </summary>
        private void Undo()
        {
            if (UndoList.Count <= 0) return;

            Control control = UndoList.Last<Control>();
            RedoList.Add(control);
            UndoList.RemoveAt(UndoList.LastIndexOf(control));

            if (control.Parent == null)
            {
                this.flowLayoutPanel1.Controls.Add(control);
            }
            else
            {
                control.Parent.Controls.Remove(control);
            }
            flowLayoutPanel1.Refresh();
        }

        /// <summary>
        /// Tekee uudelleen kumotun toiminnon.
        /// </summary>
        private void Redo()
        {
            if (RedoList.Count <= 0) return;

            Control control = RedoList.Last<Control>();
            UndoList.Add(control);
            RedoList.RemoveAt(RedoList.LastIndexOf(control));

            if (control.Parent == null)
            {
                this.flowLayoutPanel1.Controls.Add(control);
            }
            else
            {
                control.Parent.Controls.Remove(control);
            }
            flowLayoutPanel1.Refresh();

        }

        /// <summary>
        /// Vaihtaa Tekstin muokattavaksi TextBoxiksi.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Muokkaa(object sender, EventArgs e)
        {
            Label teksti = (Label)sender;
            MuutosTextBox muokkaus = new MuutosTextBox();

            // Uudesta MuutosTextBoxista samanlainen kuin Labelista.
            muokkaus.Text = teksti.Text;
            muokkaus.Size = teksti.Size;
            muokkaus.LostFocus += new System.EventHandler(this.LopetaMuokkaa);
            muokkaus.muutettavaLabel = teksti;

            // Korvataan Labeli uudella MuutosTextBoxilla
            int labelIndex = this.flowLayoutPanel1.Controls.IndexOf(teksti);
            this.flowLayoutPanel1.Controls.Remove(teksti);
            flowLayoutPanel1.Controls.Add(muokkaus);
            flowLayoutPanel1.Controls.SetChildIndex(muokkaus, labelIndex);
            muokkaus.Focus();
            this.flowLayoutPanel1.Refresh();
        }

        /// <summary>
        /// Palauttaa Tekstin muokkauksen jälkeen TextBoxin labeliksi ja muuttaa tekstiä.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LopetaMuokkaa(object sender, EventArgs e)
        {
            MuutosTextBox muokkaus = (MuutosTextBox)sender;

            if (!(muokkaus.Text?.Length > 0)) return;

            muokkaus.muutettavaLabel.Text = muokkaus.Text;

            int labelIndex = this.flowLayoutPanel1.Controls.IndexOf(muokkaus);
            this.flowLayoutPanel1.Controls.Remove(muokkaus);
            flowLayoutPanel1.Controls.Add(muokkaus.muutettavaLabel);
            flowLayoutPanel1.Controls.SetChildIndex(muokkaus.muutettavaLabel, labelIndex);
            this.flowLayoutPanel1.Refresh();

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

        /// <summary>
        /// Järjestää tekstit pituusjärjestykseen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jarjesta_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count <= 0) return;

            Tekstit.Clear();
            foreach (Label teksti in flowLayoutPanel1.Controls) {
                Tekstit.Add(teksti);
            }

            Tekstit.Sort(delegate (Label a, Label b)
            {
                if (a.Text.Length - b.Text.Length != 0) {
                    return a.Text.Length - b.Text.Length;
                }
                return a.Text.CompareTo(b.Text);
            }
            );

            bool sorted = true;
            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {
                if (!((Control)Tekstit[i]).Equals(flowLayoutPanel1.Controls[i]))
                {
                    sorted = false;
                    break;
                }
            }

            if (!sorted)
            {
            foreach (Label teksti in Tekstit)
                {

                    this.flowLayoutPanel1.Controls.Add(teksti);
                }
            } else {
                for (int i = Tekstit.Count -1; i >=0; i--)
                {
                    this.flowLayoutPanel1.Controls.Add(Tekstit[i]);
                }
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
            if (flowLayoutPanel1.Controls.Count <= 0)
            {
                flowLayoutPanel1.Refresh();
                return;
            }

            Control viimeinen = flowLayoutPanel1.Controls[flowLayoutPanel1.Controls.Count - 1];
            flowLayoutPanel1.Controls.Remove(viimeinen);
            UndoList.Add(viimeinen);
            RedoList.Clear();
            flowLayoutPanel1.Refresh();
        }

        /// <summary>
        /// Ohjelmasta poistuminen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Undo toiminto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        /// <summary>
        /// Redo  toiminto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
        }
    }

    /// <summary>
    /// TextBox joka muistaa minkä controllin on korvannut.
    /// </summary>
    class MuutosTextBox : TextBox
    {
        public Label muutettavaLabel;
    }
    
}
