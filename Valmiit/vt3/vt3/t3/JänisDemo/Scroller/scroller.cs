using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scroller
{
    public partial class scroller : UserControl
    {
        private int nopeus = 3;
        Graphics canvas;
        int lev = 0;
        int kor = 0;

        List<Point> koords;
        int max = 200;
        int koord = 0;
        Point sijainti;

        public Point Sijainti
        {
            get
            {
                return sijainti;
            }
            set
            {
                sijainti = value;
                PaivitaKoordinaatit();
            }
        }

        public string Teksti
        {
            get
            {
                return Text;
            }
            set
            {
                Text = value;
                PaivitaKoordinaatit();
            }
        }
        public int Nopeus
        {
            get
            {
                return nopeus;
            }
            set
            {
                nopeus = value;
                max = 10000 / nopeus;
                PaivitaKoordinaatit();
            }
        }

        public scroller()
        {
            InitializeComponent();
            koords = new List<Point>();
            Teksti = "";
            PaivitaKoordinaatit();
            ForeColor = Color.Blue;
        }

        /// <summary>
        /// Piirrellään.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            canvas = e.Graphics;
            canvas.DrawString(this.Text, SystemFonts.DefaultFont, Brushes.White, new Point(0, 0));

        //    base.OnPaint(e);
        }

        /// <summary>
        /// Liikutellaan tekstiä.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            koord++;
            if (koord >= max) koord = 0;

            Location = koords[koord];
            Invalidate();
        }

        /// <summary>
        /// Päivitetään koordinaatit vastaamaan ikkunan kokoa
        /// </summary>
        private void PaivitaKoordinaatit()
        {
            Size = TextRenderer.MeasureText(Text, Font);
            koords.Clear();
            for (int i = 0; i < max; i++)
            {
                int kor = 150;
                
                int x = (int)((lev + TextRenderer.MeasureText(Text, Font).Width) - (1.0 * i / max) * (lev + 2 * TextRenderer.MeasureText(Text, Font).Width));
                int y = (int)(Math.Sin(2.0 * Math.PI * lev / 300 * i / max) * (kor / 6) + Sijainti.Y);
                koords.Add(new Point(x, y));
            }
        }

        /// <summary>
        /// Jos koko muuttuu niin piirretään uudelleen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scroller_SizeChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// Jos vanhempi muuttuu niin lisätään kuuntelija Parent.Rezizelle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scroller_ParentChanged(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                Parent.Resize += new EventHandler(Parent_Resize);

                this.lev = Parent.ClientSize.Width;
                this.kor = Parent.ClientSize.Height;
                PaivitaKoordinaatit();
            }
        }

        /// <summary>
        /// Päivitetään ikkunan kokotiedot oikeiksi.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Parent_Resize(object sender, EventArgs e)
        {
            this.kor = Parent.ClientSize.Height;
            this.lev = Parent.ClientSize.Width;
            PaivitaKoordinaatit();
        }
    }
}
