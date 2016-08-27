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
using MyllyPeliNamespace;
//using PelilautaNamespace;

namespace PelinappulaNamespace
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class PeliNappula : UserControl
    {
        public Nappula nappula = null;
//        private Pelialue parent;
       

        public Brush color
        {
            get { return (Brush)GetValue(colorProperty); }
            set { SetValue(colorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for color.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty colorProperty =
            DependencyProperty.Register("color", typeof(Brush), typeof(PeliNappula), new FrameworkPropertyMetadata(Brushes.SaddleBrown,FrameworkPropertyMetadataOptions.AffectsRender));

        

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(PeliNappula), new PropertyMetadata(false));





        public PeliNappula(Nappula nappula, Color color)
        {
            InitializeComponent();
            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Center;
            this.color = new SolidColorBrush(color);
            this.nappula = nappula;

            nappula.ValittuChangedHandler += NappulaValittu;
            nappula.ValittuPoistettuHandler += NappulaPoistettu;
            //nappula.ValittuSiirrettyHandler += NappulaSiirretty;
            //Loaded += Load;

        }

        //private void Load(object sender, RoutedEventArgs e)
        //{
        //    parent = (Pelialue)Parent;
        //    parent.SizeChanged += Aseta;
        //}

        //private void Aseta(object sender, SizeChangedEventArgs e)
        //{
        //    AsetaKeskelle();
        //}

        //private void NappulaSiirretty(object sender, EventArgs e)
        //{
        //    parent.Children.Remove(this);
        //}

        //private void AsetaKeskelle()
        //{
        //    UpdateLayout();
        //    Canvas.SetLeft(this, parent.PuolikasLeveys - ActualWidth / 2);
        //    Canvas.SetTop(this, parent.PuolikasKorkeus - ActualHeight / 2);
        //}

        private void NappulaPoistettu(object sender, EventArgs e)
        {
            ((Panel)Parent).Children.Remove(this);
        }

        private void NappulaValittu(object sender, EventArgs e)
        {
            if (nappula.Valittu)
            {
                ympyra.Stroke = Brushes.Red;
            } else
            {
                ympyra.Stroke = Brushes.Transparent;
            }
        }

        //        //private void control_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //        //{
        //        //    RaisePelipisteClickEvent(parent.getXIndex(), parent.getYIndex(), parent);

        //        //    e.Handled = true;
        //        //}


        //        public delegate void PelinappulaClickEventHandler(object sender, PelinappulaClickEventArgs e);
        //        // oma luokka oman datan siirtelyyn
        //        public class PelinappulaClickEventArgs : RoutedEventArgs
        //        {
        //            private int _x = -1;
        //            private int _y = -1;
        ////            private Pelialue _alue;

        //            public int X
        //            {
        //                get { return _x; }
        //                set { _x = value; }
        //            }
        //            public int Y
        //            {
        //                get { return _y; }
        //                set { _y = value; }
        //            }
        //            //public Pelialue Alue
        //            //{
        //            //    get { return _alue; }
        //            //    set { _alue = value; }
        //            //}
        //            public PelinappulaClickEventArgs(RoutedEvent routedEvent, int x, int y) : base(routedEvent)
        //            {
        //                X = x;
        //                Y = y;
        //            }
        //        }

        //        // määritellään routedevent. Huomatkaa typeof pitää olla nyt OmaArgsRoutedEventHandler eli 
        //        // sama mitä yllä luotiin
        //        public static readonly RoutedEvent PelinappulaClickEvent =
        //EventManager.RegisterRoutedEvent("OmaArgs", RoutingStrategy.Bubble,
        //typeof(PelinappulaClickEventHandler), typeof(PeliNappula));

        //        public event RoutedEventHandler PelinappulaClick
        //        {
        //            add { AddHandler(PelinappulaClickEvent, value); }
        //            remove { RemoveHandler(PelinappulaClickEvent, value); }
        //        }

        //        void RaisePelipisteClickEvent(int x, int y)
        //        { // nyt luodaan oma args-luokan esiintymä, tarvitaan routeventin tyyppi (OmaArgsEvent! ei vahingossakaan sama kuin edellisessä!) ja varsinainen oma parametri
        //            PelinappulaClickEventArgs newEventArgs = new PelinappulaClickEventArgs(PeliNappula.PelinappulaClickEvent, x, y);
        //            RaiseEvent(newEventArgs);
        //        }
    }
}
