using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace KilometriNopeusLaskuri
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class kilometriNopeusLaskuri : UserControl
    {
        private int minAika;
        private int maxAika = 99999;
        private int minMatka;
        private int maxMatka = 99999;

        [Category("Arvot"),
            Description("Minimi aika."),
            DefaultValue(0),
            Browsable(true)]
        public int MinAika
        {
            get { return minAika; }
            set { minAika = value; }
        }

        [Category("Arvot"),
    Description("Maksimi aika."),
    DefaultValue(0),
    Browsable(true)]
        public int MaxAika
        {
            get { return maxAika; }
            set { maxAika = value; }
        }

        [Category("Arvot"),
    Description("Minimi matka."),
    DefaultValue(0),
    Browsable(true)]
        public int MinMatka
        {
            get { return minMatka; }
            set { minMatka = value; }
        }

        [Category("Arvot"),
    Description("Maksimi matka."),
    DefaultValue(0),
    Browsable(true)]
        public int MaxMatka
        {
            get { return maxMatka; }
            set { maxMatka = value; }
        }

        public string Nopeus
        {
            get { return (string)GetValue(NopeusProperty); }
            set { SetValue(NopeusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Nopeus.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NopeusProperty =
            DependencyProperty.Register("Nopeus", typeof(string), typeof(kilometriNopeusLaskuri), new PropertyMetadata("0"));



        public int Matka
        {
            get { return (int)GetValue(MatkaProperty); }
            set
            {
                SetValue(MatkaProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for Matka.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MatkaProperty =
            DependencyProperty.Register("Matka", typeof(int), typeof(kilometriNopeusLaskuri), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.AffectsRender, onMatkaChanged, MuutaMatka));

        private static object MuutaMatka(DependencyObject d, object baseValue)
        {
            int luku = Convert.ToInt32(baseValue);

            int min = ((kilometriNopeusLaskuri)d).MinMatka;
            int max = ((kilometriNopeusLaskuri)d).MaxMatka;

            if (luku < min || max < luku)
                throw new ArgumentOutOfRangeException();
            
            return luku;
        }

        private static void onMatkaChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            kilometriNopeusLaskuri laskuri = (kilometriNopeusLaskuri)obj;
            laskuri.PaivitaNopeus();
        }




        public int Aika
        {
            get { return (int)GetValue(AikaProperty); }
            set { SetValue(AikaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Aika.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AikaProperty =
            DependencyProperty.Register("Aika", typeof(int), typeof(kilometriNopeusLaskuri), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.AffectsRender, onAikaChanged, MuutaAika));


        private static void onAikaChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            kilometriNopeusLaskuri laskuri = (kilometriNopeusLaskuri)obj;
            laskuri.PaivitaNopeus();
        }

        private static object MuutaAika(DependencyObject d, object baseValue)
        {
            int aika = Convert.ToInt32(baseValue);
            int min = ((kilometriNopeusLaskuri)d).MinAika;
            int max = ((kilometriNopeusLaskuri)d).MaxAika;

            if (aika < min || max < aika)
                throw new ArgumentOutOfRangeException();
            return aika;
        }


        public void PaivitaNopeus()
        {
            if (Aika != 0)
            {
                Nopeus = string.Format("{0:0.00}",1.0 * Matka / Aika);
                return;
            }
            Nopeus = 0.ToString();
        }


        public kilometriNopeusLaskuri()
        {
            InitializeComponent();
        }

    }


    public class IntValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string text = (string)value;
            Regex regex = new Regex("[0-9]+");

            if (!regex.IsMatch(text))
            {
                return new ValidationResult(false, "Ei ole kokonaisluku.");
            }

            int luku = 0;
            try
            {
                luku = Convert.ToInt32(value);
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Ei ole kokonaisluku.");
            }



            return ValidationResult.ValidResult;
        }
    }
}
