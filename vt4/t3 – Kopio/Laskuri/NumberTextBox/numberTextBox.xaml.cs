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


namespace NumberTextBox
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class numberTextBox : UserControl
    {
        private double min;
        private double max = 99999;


        [Category("Arvot"),
        Description("Minimi."),
        DefaultValue(0.0),
        Browsable(true)]
        public double Min
        {
            get { return min; }
            set { min = value; }
        }


        [Category("Arvot"),
        Description("Maksimi."),
        DefaultValue(99999.0),
        Browsable(true)]
        public double Max
        {
            get { return max; }
            set { max = value; }
        }


        public numberTextBox()
        {
            InitializeComponent();
        }


        /// <summary>
        /// numberTextBoxin sisältämä validi numero.
        /// </summary>
        public double Number
        {
            get { return (double)GetValue(NumberProperty); }
            set
            {
                SetValue(NumberProperty, value);
            }
        }


        // Using a DependencyProperty as the backing store for Matka.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(double), typeof(numberTextBox), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender, onNumberChanged, MuutaNumber));


        /// <summary>
        /// Numeron syöttämisen oikeellisuustarkistus.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="baseValue"></param>
        /// <returns></returns>
        private static object MuutaNumber(DependencyObject d, object baseValue)
        {
            var culture = System.Globalization.CultureInfo.CurrentCulture;
            double luku = Convert.ToDouble(baseValue, culture);

            double min = ((numberTextBox)d).Min;
            double max = ((numberTextBox)d).Max;

            if (luku < min || max < luku)
                throw new ArgumentOutOfRangeException();

            return luku;
        }


        /// <summary>
        /// Jos tarvitsee tehdä jotain kun numeroa on muutettu.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="args"></param>
        private static void onNumberChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            // tyhjä
        }
    }
}
