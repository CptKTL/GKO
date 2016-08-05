using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PaceLabel
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class paceLabel : UserControl
    {
        private double slowMin = 6;
        private double fastMin = 4;
        private Color fastColor = Colors.Red;
        private Color color = Colors.Red;

        public Color Color
        {
            get
            {
                return color;
            }
            private set
            {
                color = value;
            }
        }

        public delegate void Fast(object sender, EventArgs e);
        public event Fast fast;

        public delegate void Average(object sender, EventArgs e);
        public event Average average;

        public delegate void Slow(object sender, EventArgs e);
        public event Slow slow;


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


        /// <summary>
        /// Pace-labelin aika.
        /// </summary>
        public TimeSpan Time
        {
            get { return (TimeSpan)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }


        // Using a DependencyProperty as the backing store for Time.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register("Time", typeof(TimeSpan), typeof(paceLabel), new FrameworkPropertyMetadata(TimeSpan.Zero, FrameworkPropertyMetadataOptions.AffectsRender, onTimeChanged, MuutaTime));


        /// <summary>
        /// Kun aikaa on muutettu, päivitetään itse Pace.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="args"></param>
        public static void onTimeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            paceLabel label = (paceLabel)obj;
            label.PaivitaPace();
        }


        /// <summary>
        /// Muutetaan annettu aika TimeSpaniksi.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="baseValue"></param>
        /// <returns></returns>
        private static object MuutaTime(DependencyObject d, object baseValue)
        {
            return (TimeSpan)baseValue;
        }


        /// <summary>
        /// PaceLabelin sisältämä Matka.
        /// </summary>
        public double Distance
        {
            get { return (double)GetValue(DistanceProperty); }
            set { SetValue(DistanceProperty, value); }
        }


        // Using a DependencyProperty as the backing store for Distance.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DistanceProperty =
            DependencyProperty.Register("Distance", typeof(double), typeof(paceLabel), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender, onDistanceChanged, MuutaDistance));


        /// <summary>
        /// Kun matkaa päivitetään, päivitetään myös Pace.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="args"></param>
        public static void onDistanceChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            paceLabel label = (paceLabel)obj;
            label.PaivitaPace();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <param name="baseValue"></param>
        /// <returns></returns>
        private static object MuutaDistance(DependencyObject d, object baseValue)
        {
            var culture = System.Globalization.CultureInfo.CurrentCulture;
            return Convert.ToDouble(baseValue, culture);
        }


        /// <summary>
        /// PaceLabelin Pace.
        /// </summary>
        public double Pace
        {
            get { return (double)GetValue(PaceProperty); }
            set { SetValue(PaceProperty, value); }
        }


        // Using a DependencyProperty as the backing store for Pace.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PaceProperty =
            DependencyProperty.Register("Pace", typeof(double), typeof(paceLabel), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender, onPaceChanged));


        /// <summary>
        /// Pacen muutoksen oikeellisuustarkistus.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="args"></param>
        public static void onPaceChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            double pace = (double)args.NewValue;
            paceLabel label = (paceLabel)obj;

            if (pace < label.FastMin)
            {
                if (label.fast != null)
                    label.fast(label, new EventArgs());
            }
            else if (label.SlowMin > pace && pace > label.FastMin)
            {
                if (label.average != null)
                    label.average(label, new EventArgs());
            }
            else
            {
                if (label.slow != null)
                    label.slow(label, new EventArgs());
            }
        }


        /// <summary>
        /// Päivitetään Pace oikeaan muotoon.
        /// </summary>
        public void PaivitaPace()
        {
            if (Distance != 0)
            {
                Pace = 1.0 * Time.TotalMinutes / Distance;
                return;
            }
            Pace = 0.0;
        }


        public paceLabel()
        {
            InitializeComponent();
        }
    }
}
