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
using PelinappulaNamespace;

namespace PelilautaNamespace
{
    /// <summary>
    /// Pelilauta Mylly-pelille. Koostuu PeliAlueista.
    /// </summary>
    public partial class PelilautaController : UserControl
    {
        /// <summary>
        /// constructori.
        /// </summary>
        public PelilautaController()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Antaa yksittäisen pelialueen.
        /// </summary>
        /// <param name="x">koordinaatti x</param>
        /// <param name="y">koordinaatti y</param>
        /// <returns></returns>
        public Pelialue AnnaPelialue(int x, int y)
        {
            return (Pelialue)lauta.Children[7 * y + x];
        }


        /// <summary>
        /// Pelipisteen klikkauksen handler. Heittää PelipisteClickEvent.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void NappulaPisteMouseUp(object sender, MouseButtonEventArgs args)
        {
            Ellipse piste = (Ellipse)sender;
            Pelialue alue = (Pelialue)piste.Parent;
            args.Handled = true;
            RaisePelipisteClickEvent(alue.getXIndex(), alue.getYIndex(), alue);
        }


        /// <summary>
        /// Pelipisteen klikkauksen handler delegaatti.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void PelipisteClickEventHandler(object sender, PelipisteClickEventArgs e);

        /// <summary>
        /// RoutedEventArgs pelipisteen klikkauselle. Sisältää pelialueen koordinaatit ja pelialueen.
        /// </summary>
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

        
        /// <summary>
        /// RoutedEvent Pelipisteen klikkaukselle.
        /// </summary>
        public static readonly RoutedEvent PelipisteClickEvent =
            EventManager.RegisterRoutedEvent("PelipisteClickEventArgs", RoutingStrategy.Bubble,
            typeof(PelipisteClickEventHandler), typeof(PelilautaController));

        
        /// <summary>
        /// RoutedEvent handler.
        /// </summary>
        public event RoutedEventHandler PelipisteClick
        {
            add { AddHandler(PelipisteClickEvent, value); }
            remove { RemoveHandler(PelipisteClickEvent, value); }
        }


        /// <summary>
        /// Nostaa PelipisteClickEventin.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="alue"></param>
        void RaisePelipisteClickEvent(int x, int y, Pelialue alue)
        { // nyt luodaan oma args-luokan esiintymä, tarvitaan routeventin tyyppi (OmaArgsEvent! ei vahingossakaan sama kuin edellisessä!) ja varsinainen oma parametri
            PelipisteClickEventArgs newEventArgs = new PelipisteClickEventArgs(PelilautaController.PelipisteClickEvent, x, y, alue);
            RaiseEvent(newEventArgs);
        }
    }


    /// <summary>
    /// Pelialue Luokka.
    /// </summary>
    public partial class Pelialue : Canvas
    {
        /// <summary>
        /// Pelialueella mahdollisesti oleva nappula.
        /// </summary>
        private PeliNappula nappula;


        /// <summary>
        /// Constructor.
        /// </summary>
        public Pelialue()
        {
            //InitializeComponent();
            HorizontalAlignment = HorizontalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Stretch;
            SizeChanged += onSizeChanged;
        }


        /// <summary>
        /// Lisää pelinappulan tähän alueeseen ja kytkee nappulan eventtien kuuntelijat.
        /// </summary>
        /// <param name="nappula">Pelinappula joka halutaan lisätä.</param>
        public void lisaaNappula(PeliNappula nappula)
        {
            this.nappula = nappula;
            Children.Add(nappula);
            nappula.UpdateLayout();
            Canvas.SetLeft(nappula, PuolikasLeveys - (nappula.ActualWidth / 2));
            Canvas.SetTop(nappula, PuolikasKorkeus - (nappula.ActualHeight / 2));
            nappula.MouseLeftButtonUp += UserControl_MouseLeftButtonUp;
            nappula.nappula.ValittuPoistettuHandler += NappulaPoistettu;
        }


        /// <summary>
        /// Antaa alueella olevan nappulan.
        /// </summary>
        /// <returns></returns>
        public PeliNappula AnnaNappula()
        {
            return nappula;
        }


        /// <summary>
        /// NappulaPoistettu eventin handler. Poistaa Pelinappulan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NappulaPoistettu(object sender, EventArgs e)
        {
            Children.Remove(nappula);
            nappula.MouseLeftButtonUp -= UserControl_MouseLeftButtonUp;
            nappula.nappula.ValittuPoistettuHandler -= NappulaPoistettu;

            nappula = null;
        }


        /// <summary>
        /// Pelinappulan Klikkauksen handler. Nostaa PelipisteClickEventin.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            RaisePeliNappulaClickEvent(this.getXIndex(), getYIndex(), this);
        }


        /// <summary>
        /// Tämän alueen x koordinaatti gridissä.
        /// </summary>
        /// <returns></returns>
        public int getXIndex()
        {
            return ((Panel)this.Parent).Children.IndexOf(this) % 7;
        }


        /// <summary>
        /// Tämän alueen x koordinaatti gridissä.
        /// </summary>
        /// <returns></returns>
        public int getYIndex()
        {
            return ((Panel)this.Parent).Children.IndexOf(this) / 7;
        }


        /// <summary>
        /// Siiirtää ja poistaa Pelinappulan tästä alueesta toiseen uuteen alueeseen.
        /// </summary>
        /// <param name="alue"></param>
        public void SiirraNappula(Pelialue alue)
        {
            Children.Remove(nappula);
            nappula.MouseLeftButtonUp -= UserControl_MouseLeftButtonUp;
            nappula.nappula.ValittuPoistettuHandler -= NappulaPoistettu;

            alue.lisaaNappula(nappula);
            nappula = null;
        }


        /// <summary>
        /// Alueen leveyden puolikas.
        /// </summary>
        public double PuolikasLeveys
        {
            get { return (double)GetValue(PuolikasLeveysProperty); }
            set { SetValue(PuolikasLeveysProperty, value); }
        }


        // Using a DependencyProperty as the backing store for PuolikasLeveys.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PuolikasLeveysProperty =
            DependencyProperty.Register("PuolikasLeveys", typeof(double), typeof(Pelialue), new PropertyMetadata(0.0));


        /// <summary>
        /// Alueen korkeuden puolikas.
        /// </summary>
        public double PuolikasKorkeus
        {
            get { return (double)GetValue(PuolikasKorkeusProperty); }
            set { SetValue(PuolikasKorkeusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PuolikasKorkeus.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PuolikasKorkeusProperty =
            DependencyProperty.Register("PuolikasKorkeus", typeof(double), typeof(Pelialue), new PropertyMetadata(0.0));

        
        /// <summary>
        /// Muuttaa PuolikasLeveyden ja PuolikasKorkeuden kun Alueen koko muuttuu.
        /// Sijoittaa mahdollisen Pelinappulan myös keskelle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void onSizeChanged(object sender, SizeChangedEventArgs args)
        {
            PuolikasKorkeus = ActualHeight / 2;
            PuolikasLeveys = ActualWidth / 2;
            if (nappula != null)
            {
                nappula.UpdateLayout();
                Canvas.SetLeft(nappula, PuolikasLeveys - nappula.ActualWidth / 2);
                Canvas.SetTop(nappula, PuolikasKorkeus - nappula.ActualHeight / 2);
            }
        }


        /// <summary>
        /// PelinappulanClickEventHandler. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void PelinappulaClickEventHandler(object sender, PelinappulaClickEventArgs e);


        /// <summary>
        /// Pelinappulan klikkaus eventin argumentit. Sisältää x ja y koordinaatit sekä alueen millä nappula on.
        /// </summary>
        public class PelinappulaClickEventArgs : RoutedEventArgs
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
            public PelinappulaClickEventArgs(RoutedEvent routedEvent, int x, int y, Pelialue alue) : base(routedEvent)
            {
                X = x;
                Y = y;
                Alue = alue;
            }
        }


        /// <summary>
        /// Pelinappulan klikkaus tapahtuma.
        /// </summary>
        public static readonly RoutedEvent PelinappulaClickEvent =
EventManager.RegisterRoutedEvent("PelinappulaClickEvent", RoutingStrategy.Bubble,
typeof(PelinappulaClickEventHandler), typeof(Pelialue));


        /// <summary>
        /// 
        /// </summary>
        public event RoutedEventHandler PelinappulaClick
        {
            add { AddHandler(PelinappulaClickEvent, value); }
            remove { RemoveHandler(PelinappulaClickEvent, value); }
        }


        /// <summary>
        /// nostaa Peli
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="alue"></param>
        void RaisePeliNappulaClickEvent(int x, int y, Pelialue alue)
        { // nyt luodaan oma args-luokan esiintymä, tarvitaan routeventin tyyppi (OmaArgsEvent! ei vahingossakaan sama kuin edellisessä!) ja varsinainen oma parametri
            PelinappulaClickEventArgs newEventArgs = new PelinappulaClickEventArgs(Pelialue.PelinappulaClickEvent, x, y, alue);
            RaiseEvent(newEventArgs);
        }
    }
}