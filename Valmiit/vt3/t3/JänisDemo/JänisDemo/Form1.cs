//using Scroller;
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
/// Käyttöliitymäohjelmointi
/// Kimmo Lappalainen
/// viikkotehtävä 3
/// </summary>
namespace JänisDemo
{
    public partial class Form1 : Form
    {
        Image kuva;
        Color alku;
        Color loppu;
        List<int> JanisKoords; // kuvan koordinaatit
        int JanisKoord = 0;
        int maxJanisKoords = 200;
        int bars = 6;
        int barSkip = 5;

        List<HorizontalBar.horizontalBar> Bars; 
        List<int> BarKoords;
        int BarKoord = 0;
        int maxBarKoords = 300;

        HorizontalBar.horizontalBar alaBar = new HorizontalBar.horizontalBar();
        Scroller.scroller scrolleri = new Scroller.scroller();

        Graphics canvas;

        public Form1()
        {
            InitializeComponent();
            kuva = Image.FromFile("Janis.png");
            alku = Color.Black;
            loppu = Color.Red;

            JanisKoords = new List<int>();
            BarKoords = new List<int>();
            Bars = new List<HorizontalBar.horizontalBar>();
            
            timer1.Interval = 20;
            timer1.Enabled = true;

            // Alalaidassa oleva palkki
            alaBar.Width = ClientRectangle.Width;
            alaBar.Height = 150;
            alaBar.Paksuus = 150;
            alaBar.Loppu = Color.Black;
            alaBar.Location = new Point(0, ClientRectangle.Height - alaBar.Paksuus);

            //Rullaava teksti
            scrolleri.Text = "Tämä on Graafisten käyttöliittymien ohjelmointi (TIEA212) -kurssin viikkotehtävä 3.";
            scrolleri.Sijainti = new Point(0, alaBar.Location.Y + alaBar.Paksuus / 2);
            scrolleri.Nopeus = 30;
            Controls.Add(scrolleri);

            paivitaKoordinaatit();

            // liikkuvat palkit
            for (int i = 0; i < bars; i++)
            {
                HorizontalBar.horizontalBar newBar = new HorizontalBar.horizontalBar();
                newBar.Width = ClientRectangle.Width;
                
                newBar.Paksuus = 50;
                //newBar.Height = newBar.Paksuus;
                Bars.Add(newBar);
                Controls.Add(newBar);
            }

            this.Controls.Add(alaBar);
            timer1_Tick(this, null);
            alaBar.BringToFront();
            scrolleri.BringToFront();
        }

        /// <summary>
        /// Piirretään näyttöön
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            canvas = e.Graphics;
            canvas.DrawImageUnscaled(kuva, new Point(JanisKoords[JanisKoord], 0));
            
            //base.OnPaint(e);
        }

        /// <summary>
        /// Liikutetaan kaikkia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            JanisKoord++;
            BarKoord++;

            if (JanisKoord >= maxJanisKoords) JanisKoord = 0;
            if (BarKoord >= maxBarKoords) BarKoord = 0;
            int p = BarKoord;

            foreach (var bar in Bars)
            {
                if (p >= maxBarKoords) p = 0;
                bar.Sijainti = new Point(0,BarKoords[p]);
                p += barSkip;
                if (p >= maxBarKoords)
                {
                    p = p - maxBarKoords;
                }
            }
            
            Invalidate();
        }

        /// <summary>
        /// Asetetaan asiat paikoilleen kun ikkunan kokoa muokataan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Resize(object sender, EventArgs e)
        {
            paivitaKoordinaatit();
            alaBar.Location = new Point(0, ClientRectangle.Height - alaBar.Paksuus);
            scrolleri.Sijainti = new Point(0, ClientRectangle.Height - alaBar.Paksuus / 2);
        }

        /// <summary>
        /// Päivitetään Liikkuvien objektien lasketut koordinaatit uudelleen.
        /// </summary>
        private void paivitaKoordinaatit()
        {
            JanisKoords.Clear();
            for (int i = 0; i < maxJanisKoords; i++)
            {
                JanisKoords.Add((int)(Math.Sin(2.0 * Math.PI * i / maxJanisKoords) * (this.ClientRectangle.Width / 10) + this.ClientSize.Width / 2 - kuva.Width / (ClientSize.Width / kuva.HorizontalResolution)));
            }

            BarKoords.Clear();
            for (int i = 0; i < maxBarKoords; i++)
            {
                BarKoords.Add((int)(Math.Sin(2.0 * Math.PI * i / maxBarKoords) * (this.ClientRectangle.Height / 2) + ClientRectangle.Height / 2));
            }
        }
    }
}
