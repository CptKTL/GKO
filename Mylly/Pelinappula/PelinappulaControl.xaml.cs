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

namespace PelinappulaNamespace
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class PeliNappula : UserControl
    {


        //public double KeskiX
        //{
        //    get { return (double)GetValue(KeskiXProperty); }
        //    set { SetValue(KeskiXProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for KeskiX.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty KeskiXProperty =
        //    DependencyProperty.Register("KeskiX", typeof(double), typeof(PeliNappula), new PropertyMetadata(0));



        //public double KeskiY
        //{
        //    get { return (double)GetValue(KeskiYProperty); }
        //    set { SetValue(KeskiYProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for KeskiY.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty KeskiYProperty =
        //    DependencyProperty.Register("KeskiY", typeof(double), typeof(PeliNappula), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.AffectsRender, KeskiYChanged));

        //private static object KeskiYChanged(DependencyObject d, object baseValue)
        //{

        //    return (double)baseValue - (((PeliNappula)d).nappula.ActualHeight / 2);
        //}

        public PeliNappula()
        {
            InitializeComponent();
            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Center;
        }
    }
}
