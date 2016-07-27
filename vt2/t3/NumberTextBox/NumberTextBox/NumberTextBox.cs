using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberTextBox
{
    public partial class NumberTextBox : TextBox
    {
        ErrorProvider error = new ErrorProvider();
        private double min;
        private double max;

        [Category("Arvot"),
        Description("Kentän minimi arvo"),
        DefaultValue(0),
        Browsable(true)]
        public double Min
        {
            get
            { return min; }
            set
            {
                min = value;
            }
        }

        [Category("Arvot"),
        Description("Kentän maksimi arvo"),
        DefaultValue(0),
        Browsable(true)]
        public double Max
        {
            get
            {
                return max;
            }
            set
            {
                max = value;
            }
        }

        public NumberTextBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Validointi tarkastaa että teksti on desimaaliluku väliltä [Min; Max].
        /// </summary>
        /// <param name="e"></param>
        protected override void OnValidating(CancelEventArgs e)
        {
            System.Globalization.NumberFormatInfo format = new System.Globalization.NumberFormatInfo();
            format.NumberDecimalSeparator = ",";
            try
            {
                

                double arvo = Double.Parse(this.Text, format);
                if (arvo < Min || Max < arvo)
                {
                    error.SetError(this, "Ei ole oikealla välillä.");
                    e.Cancel = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                try
                {
                    format.NumberDecimalSeparator = ".";
                    double arvo = Double.Parse(this.Text, format);
                    if (arvo < Min || Max < arvo)
                    {
                        error.SetError(this, "Ei ole oikealla välillä.");
                        e.Cancel = true;
                        return;
                    }
                }
                catch (Exception exc)
                {
                    error.SetError(this, "Ei ole oikeaa muotoa.");
                    e.Cancel = true;
                    this.BackColor = Color.Red;
                }
            }
            base.OnValidating(e);
        }


        private void NumberTextBox_Validated(object sender, EventArgs e)
        {
            error.SetError(this, null);
            this.BackColor = Color.White;
        }
        
    }
}
