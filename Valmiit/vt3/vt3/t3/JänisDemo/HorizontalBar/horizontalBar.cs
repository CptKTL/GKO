using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorizontalBar
{
    public partial class horizontalBar : UserControl
    {
        Color alku;
        Color loppu;
        Color alkuDefault = Color.Black;
        Color loppuDefault = Color.Red;
        int paksuus;
        Point sijainti;

        Graphics canvas;

        private Brush pensseli1;
        private Brush pensseli2;

        [Category("Ominaisuudet"),
            Description("Gradientin alkuväri"),
            Browsable(true)]
        public Color Alku
        {
            get
            {
                return alku;
            }
            set
            {
                alku = value;
                Gradient_SizeChanged(this, null);
            }
        }

        [Category("Ominaisuudet"),
            Description("Gradientin loppuväri"),
            Browsable(true)]
        public Color Loppu
        {
            get
            {
                return loppu;
            }
            set
            {
                loppu = value;
                Gradient_SizeChanged(this, null);
            }
        }

        [Category("Ominaisuudet"),
            Description("Gradientin paksuus"),
            DefaultValue(0),
            Browsable(true)]
        public int Paksuus
        {
            get { return paksuus; }
            set
            {
                paksuus = value;
                Height = value;
                Gradient_SizeChanged(this, null);
            }
        }

        [Category("Ominaisuudet"),
            Description("Gradientin sijainti"),
            Browsable(true)]
        public Point Sijainti
        {
            get { return Location; }
            set { Location = value; Gradient_SizeChanged(this, null); }
        }


        public void ResetAlku()
        {
            Alku = alkuDefault;
        }

        public void ResetLoppu()
        {
            Loppu = loppuDefault;
        }

        public bool ShouldSerializeAlku()
        {
            return alku != alkuDefault;
        }

        public bool ShouldSerializeLoppu()
        {
            return loppu != loppuDefault;
        }

        public horizontalBar()
        {
            alku = alkuDefault;
            loppu = loppuDefault;
            paksuus = 30;
            BackColor = Color.FromArgb(0, 0, 0, 0);
            InitializeComponent();

            pensseli1 = new System.Drawing.Drawing2D.LinearGradientBrush(new PointF(0, 0), new PointF(0, paksuus / 2.0f), alku, loppu);
            pensseli2 = new System.Drawing.Drawing2D.LinearGradientBrush(new PointF(0, paksuus / 2), new PointF(sijainti.X, sijainti.Y + paksuus), loppu, alku);
        }

        /// <summary>
        /// Muutetaan vastaamaan ikkunan leveyttä.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Gradient_SizeChanged(object sender, EventArgs e)
        {
            pensseli1.Dispose();
            pensseli2.Dispose();
            pensseli1 = new System.Drawing.Drawing2D.LinearGradientBrush(new PointF(sijainti.X, sijainti.Y), new PointF(0, sijainti.Y + paksuus / 2), alku, loppu);
            pensseli2 = new System.Drawing.Drawing2D.LinearGradientBrush(new PointF(sijainti.X, sijainti.Y + paksuus / 2), new PointF(sijainti.X, sijainti.Y + paksuus), loppu, alku);

            Invalidate();
        }

        /// <summary>
        /// Piirrellään uudelleen. Joku off-by-one virhe?
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            canvas = e.Graphics;
            canvas.FillRectangle(pensseli1, 0, sijainti.Y + 1, this.ClientSize.Width, (paksuus / 2.0f));
            canvas.FillRectangle(pensseli2, 0, sijainti.Y + 1 + paksuus / 2.0f, this.ClientSize.Width, paksuus / 2.0f);

            base.OnPaint(e);
        }

        /// <summary>
        /// Muutetaan leveyttä vastaamaan ikkunan leveyttä.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void horizontalBar_ParentChanged(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                Parent.Resize += new EventHandler(Parent_Resize);
                if (AutoSize)
                {
                    this.Width = Parent.ClientSize.Width;
                }
            }
        }

        /// <summary>
        /// Muutetaan leveyttä vastaamaan ikkunan leveyttä.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Parent_Resize(object sender, EventArgs e)
        {
            if (AutoSize)
            {
                this.Width = Parent.ClientSize.Width;
            }
        }

    }
}
