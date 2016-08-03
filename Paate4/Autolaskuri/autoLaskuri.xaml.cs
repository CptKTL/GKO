using System;
using System.Collections.Generic;
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

namespace Autolaskuri
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {



        public int Laskuri
        {
            get { return (int)GetValue(LaskuriProperty); }
            set
            {
                SetValue(LaskuriProperty, value);
            }
        }





        ////Using a DependencyProperty as the backing store for MyProperty.This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty LaskuriProperty =
        //    DependencyProperty.Register("Laskuri", typeof(int), typeof(UserControl1), new PropertyMetadata(0));



        // Using a DependencyProperty as the backing store for Laskuri.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LaskuriProperty =
            DependencyProperty.Register(
                "Laskuri",
                typeof(int),
                typeof(UserControl1),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    new PropertyChangedCallback(onValueChanged),
                    new CoerceValueCallback(MuutaLaskuria)));

        private static void onValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            UserControl1 o = (UserControl1)obj;
            //o.label.Content = args.NewValue;

        }

        private static object MuutaLaskuria(DependencyObject element, object value)
        {
            int luku = (int)value;
            if (luku < 0 || luku > 5)
                luku = 0;

            return luku;
        }

        public UserControl1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Laskuri++;
        }
    }
}
