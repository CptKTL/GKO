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
using Microsoft.Practices.Prism.Mvvm;
using MyllyPeliNamespace;


namespace Mylly
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Color color = Colors.Green;

        //Käyttöliittymän komennot
        public static RoutedCommand InsertPiece = new RoutedCommand();
        public static RoutedCommand MovePiece = new RoutedCommand();
        public static RoutedCommand RemovePiece = new RoutedCommand();
        public static RoutedCommand AboutCommand = new RoutedCommand();
        public static RoutedCommand SettingsCommand = new RoutedCommand();

        private MyllyPeli peli = new MyllyPeli();

        /// <summary>
        /// Kääntää yksiulotteiset pelipisteitä vastaavat pelikoordinaatit(0..23) 7x7-UIkoordinaateiksi({0,0}...{6,6})
        /// </summary>
        private static int[][] PeliKoordToUIKoordMap = new int[][]
        {
            new int[] {0,0},
            new int[] {3,0},
            new int[] {6,0},

            new int[] {1,1},
            new int[] {3,1},
            new int[] {5,1},

            new int[] {2,2},
            new int[] {3,2},
            new int[] {4,2},

            new int[] {0,3},
            new int[] {1,3},
            new int[] {2,3},
            new int[] {4,3},
            new int[] {5,3},
            new int[] {6,3},

            new int[] {2,4},
            new int[] {3,4},
            new int[] {4,4},

            new int[] {1,5},
            new int[] {3,5},
            new int[] {5,5},

            new int[] {0,6},
            new int[] {3,6},
            new int[] {6,6},
        };


        /// <summary>
        /// Antaa pelikoordinaatin UIKoordinaattien perusteella.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int UIKoordsToPeliKoord(int x, int y)
        {
            for (int i = 0; i < PeliKoordToUIKoordMap.Count(); i++)
            {
                if (PeliKoordToUIKoordMap[i][0] == x && PeliKoordToUIKoordMap[i][1] == y)
                    return i;
            }
            return -1;
        }


        /// <summary>
        /// Antaa out x ja out y parametreina UIkoordinaatit pelikoordinaatin perusteella.
        /// </summary>
        /// <param name="peliKoord"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void PeliKoordToUIKoords(int peliKoord, out int x, out int y)
        {
            x = PeliKoordToUIKoordMap[peliKoord][0];
            y = PeliKoordToUIKoordMap[peliKoord][1];
        }


        /// <summary>
        /// Voidaanko InsertPiece suorittaa. Voidaan jos Peli on Odota tilassa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanExecuteInsertPiece(object sender, CanExecuteRoutedEventArgs e)
        {
            if (peli.tila != Pelitila.Odota)
            {
                e.CanExecute = false;
                return;
            }
            e.CanExecute = true;
        }


        /// <summary>
        /// Suoritetaan InsertPiece eli vaihdetaan pelin tilaksi Lisaa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExecutedInsertPiece(object sender, ExecutedRoutedEventArgs e)
        {
            peli.tila = Pelitila.Lisaa;
        }


        /// <summary>
        /// Constructor. Sidotaan Commandid metodeihin.
        /// </summary>
        public MainWindow()
        {
            CommandBinding InsertPieceBinding = new CommandBinding(InsertPiece, ExecutedInsertPiece, CanExecuteInsertPiece);
            CommandBinding MovePieceBinding = new CommandBinding(MovePiece, ExecutedMovePiece, CanExecuteMovePiece);
            CommandBinding RemovePieceBinding = new CommandBinding(RemovePiece, ExecutedRemovePiece, CanExecuteRemovePiece);
            CommandBinding AboutBinding = new CommandBinding(AboutCommand, CommandBindingAbout_Executed);
            CommandBinding SettingsBinding = new CommandBinding(SettingsCommand, CommandBindingSettings_Executed);
            this.CommandBindings.Add(InsertPieceBinding);
            this.CommandBindings.Add(MovePieceBinding);
            this.CommandBindings.Add(RemovePieceBinding);
            this.CommandBindings.Add(AboutBinding);
            this.CommandBindings.Add(SettingsBinding);
            InitializeComponent();
        }


        /// <summary>
        /// Voidaanko RemovePiece suorittaa. Voidaan jos peli Odottaa ja joku nappula on valittuna.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanExecuteRemovePiece(object sender, CanExecuteRoutedEventArgs e)
        {
            if (peli.valittuNappula != null && peli.tila == Pelitila.Odota)
            {
                e.CanExecute = true;
                return;
            }
            e.CanExecute = false;
        }


        /// <summary>
        /// Suoritetaan RemovePiece. Eli laitetaan peli poistamaan valittu nappula.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExecutedRemovePiece(object sender, ExecutedRoutedEventArgs e)
        {
            peli.PoistaNappula();
        }


        /// <summary>
        /// Voidaanko MovePiece suorittaa. Voidaan jos on valittuna joku nappula ja peli odottaa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanExecuteMovePiece(object sender, CanExecuteRoutedEventArgs e)
        {
            if (peli.valittuNappula != null && peli.tila == Pelitila.Odota)
            {
                e.CanExecute = true;
                return;
            }
            e.CanExecute = false;
        }


        /// <summary>
        /// Suoritetaan MovePiece eli laitetaan peli siirtämään valittu nappula.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExecutedMovePiece(object sender, ExecutedRoutedEventArgs e)
        {
            peli.Siirra();
        }


        /// <summary>
        /// Pelipisteen klikkauksen kuuntelija. Tilasta riippuen asetetaan pelille kohteeksi painettu pelipiste.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_PelipisteClick(object sender, RoutedEventArgs e)
        {
            if (peli.tila == Pelitila.Lisaa)
            {
                var args = (PelilautaNamespace.PelilautaController.PelipisteClickEventArgs)e;

                Nappula uusi = peli.setTargetKoord(UIKoordsToPeliKoord(args.X, args.Y));

                if (uusi != null)
                {
                    UusiNappula(args.Alue, uusi);
                }
            }
            else if (peli.tila == Pelitila.Siirra)
            {
                if (peli.valittuNappula == null)
                    return;

                int x = 0;
                int y = 0;
                PeliKoordToUIKoords(peli.valittuNappula.Paikka, out x, out y);
                PelilautaNamespace.Pelialue pelialue = pelilautaalue.AnnaPelialue(x, y);
                var args = (PelilautaNamespace.PelilautaController.PelipisteClickEventArgs)e;

                Nappula siirretty = peli.setTargetKoord(UIKoordsToPeliKoord(args.X, args.Y));

                if (siirretty != null)
                {
                    pelialue.SiirraNappula(args.Alue);
                }
                else
                {
                    Tuloste.Text = "Ei validi kohde.";
                }
            }
        }


        /// <summary>
        /// PeliNappulan Click kuuntelija. Valitaan painettu nappula.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_PelinappulaClick(object sender, RoutedEventArgs e)
        {
            var args = (PelilautaNamespace.Pelialue.PelinappulaClickEventArgs)e;
            Nappula valinta = peli.NappulaPaikassa(UIKoordsToPeliKoord(args.X, args.Y));
            peli.ValitseNappula(valinta);
        }


        /// <summary>
        /// Lisätään PeliNappula.
        /// </summary>
        /// <param name="alue"></param>
        /// <param name="uusi"></param>
        private void UusiNappula(PelilautaNamespace.Pelialue alue, Nappula uusi)
        {
            PelinappulaNamespace.PeliNappula nappula = new PelinappulaNamespace.PeliNappula(uusi, color);
            alue.lisaaNappula(nappula);
        }


        /// <summary>
        /// Ikkunan klikkauksen kuuntelija. Saadaan jos ei ole klikattu jotain kontrollia joka tekee jotain.
        /// Poistetaan valinta nappulasta ja keskeytetään mitä oltiinkaan suorittamassa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            peli.ValitseNappula(null);
            peli.tila = Pelitila.Odota;
        }


        /// <summary>
        /// About komento. Avaa uuden About-ikkunan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandBindingAbout_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }


        /// <summary>
        /// Help komento. Avaa uuden Help-ikkunan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandBindingHelp_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            HelpWindow help = new HelpWindow();
            help.ShowDialog();
        }


        /// <summary>
        /// Settings komento. Avaa uuden settings-ikkunan. Asettaa color värin valitun mukaiseksi.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandBindingSettings_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SettingsWindow settings = new SettingsWindow();
            settings.color = color;
            settings.ShowDialog();
            color = settings.color;
        }


        /// <summary>
        /// Close Command. Sulkee ikkunan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandBindingClose_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
