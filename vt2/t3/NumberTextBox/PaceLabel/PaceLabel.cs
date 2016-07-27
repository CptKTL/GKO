using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaceLabel
{
    public partial class PaceLabel : Label
    {
        private TimeSpan time;
        private double distance;
        private double slowMin = 6;
        private double fastMin = 4;
        private double pace;

        public delegate void Fast(object sender, EventArgs e);
        public event Fast fast;

        public delegate void Average(object sender, EventArgs e);
        public event Average average;

        public delegate void Slow(object sender, EventArgs e);
        public event Slow slow;

        private double Pace
        {
            get
            {
                return pace;
            }
            set
            {
                pace = value;
                paivitaText();

                if (pace < FastMin)
                {
                    if (fast != null) fast(this, new EventArgs());
                } else if (SlowMin > pace && pace > FastMin)
                {
                    if (average != null) average(this, new EventArgs());
                } else
                {
                    if (slow != null) slow(this, new EventArgs());
                }
            }
        }


        [Category("Arvot"),
        Description("Aika"),
        Browsable(true),
            ]
        public TimeSpan Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
                paivitaPace();
            }
        }

        [Category("Arvot"),
        Description("Matka"),
        DefaultValue(0),
        Browsable(true)]
        public double Distance
        {
            get
            {
                return distance;
            }
            set
            {
                distance = value;
                paivitaPace();

            }
        }

        [Category("Arvot"),
        Description("Nopea vauhti min/km"),
        DefaultValue(4),
        Browsable(true)]
        public double FastMin
        {
            get
            {
                return fastMin;
            }
            set
            {
                fastMin = value;
            }
        }

        [Category("Arvot"),
        Description("Hidas vauhti min/km"),
        DefaultValue(6),
        Browsable(true)]
        public double SlowMin
        {
            get
            {
                return slowMin;
            }
            set
            {
                slowMin = value;
            }
        }
        
        public void ResetTime()
        {
            Time = TimeSpan.Zero;
        }

        public bool ShouldSerializeTime()
        {
            return Time != TimeSpan.Zero;
        }

        public PaceLabel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Päivittää Labelin tekstin.
        /// </summary>
        private void paivitaText()
        {
            this.Text = String.Format("{0:0.0} min/km", pace);
        }

        /// <summary>
        /// Päivittää tämän pacen.
        /// </summary>
        private void paivitaPace()
        {
            if (distance == 0)
            {
                this.Text = "";
                return;
            }
            Pace = time.TotalMinutes / distance;
        }
    }
}
