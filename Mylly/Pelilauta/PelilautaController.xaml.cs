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

namespace PelilautaNamespace
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class PelilautaController : UserControl
    {
        public PelilautaController()
        {
            InitializeComponent();
        }

        public void NappulaPisteMouseUp(object sender, MouseButtonEventArgs args)
        {
            Ellipse piste = (Ellipse)sender;

            Pelialue alue = (Pelialue) piste.Parent;

            alue.RaiseOmaEvent();
        }


    }


    public partial class Pelialue : Canvas
    {
        public Pelialue()
        {
            //InitializeComponent();
            HorizontalAlignment = HorizontalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Stretch;
            SizeChanged += onSizeChanged;
        }





        public static readonly RoutedEvent OmaEvent =
EventManager.RegisterRoutedEvent("Oma", RoutingStrategy.Bubble,
typeof(RoutedEventHandler), typeof(Pelialue));

        public event RoutedEventHandler Oma
        {
            add { AddHandler(OmaEvent, value); }
            remove { RemoveHandler(OmaEvent, value); }
        }

        public void RaiseOmaEvent()
        {   // huom. tässä pitää olla luontiparametrina UserControl1.OmaEvent. Tämä
            // erottaa eri eventit toisistaan
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Pelialue.OmaEvent);
            RaiseEvent(newEventArgs);
        }








        public double PuolikasLeveys
        {
            get { return (double)GetValue(PuolikasLeveysProperty); }
            set { SetValue(PuolikasLeveysProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PuolikasLeveys.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PuolikasLeveysProperty =
            DependencyProperty.Register("PuolikasLeveys", typeof(double), typeof(Pelialue), new PropertyMetadata(0.0));



        public double PuolikasKorkeus
        {
            get { return (double)GetValue(PuolikasKorkeusProperty); }
            set { SetValue(PuolikasKorkeusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PuolikasKorkeus.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PuolikasKorkeusProperty =
            DependencyProperty.Register("PuolikasKorkeus", typeof(double), typeof(Pelialue), new PropertyMetadata(0.0));


        void onSizeChanged(object sender, SizeChangedEventArgs args)
        {
            PuolikasKorkeus = ActualHeight / 2;
            PuolikasLeveys = ActualWidth / 2;
        }
    }
}