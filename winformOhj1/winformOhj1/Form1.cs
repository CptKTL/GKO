using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winformOhj1
{
    public partial class Form1 : Form
    {
        int henkiloautot = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void lisää_Click(object sender, EventArgs e)
        {
            henkiloautot++;
            paivitaLabel();
        }


        private void paivitaLabel()
        {
            laskuri.Text = Convert.ToString(henkiloautot);
        }
    }
}
