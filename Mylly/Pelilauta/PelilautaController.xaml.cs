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

            Pelialue alue = (Pelialue)piste.Parent;
            MessageBox.Show("ympyrä click");
            args.Handled = true;
            RaisePelipisteClickEvent(alue.getXIndex(), alue.getYIndex(), alue);
        }

        public delegate void PelipisteClickEventHandler(object sender, PelipisteClickEventArgs e);
        // oma luokka oman datan siirtelyyn
        public class PelipisteClickEventArgs : RoutedEventArgs
        {
            private int _x = -1;
            private int _y = -1;
            private Pelialue _alue;

            public int X
            {
                get { return _x; }
                set { _x = value; }
            }
            public int Y
            {
                get { return _y; }
                set { _y = value; }
            }
            public Pelialue Alue
            {
                get { return _alue; }
                set { _alue = value; }
            }
            public PelipisteClickEventArgs(RoutedEvent routedEvent, int x, int y, Pelialue alue) : base(routedEvent)
            {
                X = x;
                Y = y;
                Alue = alue;
            }
        }

        // määritellään routedevent. Huomatkaa typeof pitää olla nyt OmaArgsRoutedEventHandler eli 
        // sama mitä yllä luotiin
        public static readonly RoutedEvent PelipisteClickEvent =
EventManager.RegisterRoutedEvent("OmaArgs", RoutingStrategy.Bubble,
typeof(PelipisteClickEventHandler), typeof(PelilautaController));

        public event RoutedEventHandler PelipisteClick
        {
            add { AddHandler(PelipisteClickEvent, value); }
            remove { RemoveHandler(PelipisteClickEvent, value); }
        }

        void RaisePelipisteClickEvent(int x, int y, Pelialue alue)
        { // nyt luodaan oma args-luokan esiintymä, tarvitaan routeventin tyyppi (OmaArgsEvent! ei vahingossakaan sama kuin edellisessä!) ja varsinainen oma parametri
            PelipisteClickEventArgs newEventArgs = new PelipisteClickEventArgs(PelilautaController.PelipisteClickEvent, x, y, alue);
            RaiseEvent(newEventArgs);
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


        public int getXIndex()
        {
            return ((Panel)this.Parent).Children.IndexOf(this) % 7;
        }
        public int getYIndex()
        {
            return ((Panel)this.Parent).Children.IndexOf(this) / 7;
        }


        //public static readonly RoutedEvent PelipisteClickEvent =
        //    EventManager.RegisterRoutedEvent("Oma", RoutingStrategy.Bubble,
        //    typeof(RoutedEventHandler), typeof(Pelialue));

        //public event RoutedEventHandler PelipisteClick
        //{
        //    add { AddHandler(PelipisteClickEvent, value); }
        //    remove { RemoveHandler(PelipisteClickEvent, value); }
        //}

        //public void RaiseOmaEvent()
        //{   // huom. tässä pitää olla luontiparametrina UserControl1.OmaEvent. Tämä
        //    // erottaa eri eventit toisistaan
        //    RoutedEventArgs newEventArgs = new RoutedEventArgs(Pelialue.PelipisteClickEvent);
        //    RaiseEvent(newEventArgs);
        //}








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