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
        public static RoutedCommand InsertPiece = new RoutedCommand();
        public static RoutedCommand MovePiece = new RoutedCommand();
        public static RoutedCommand RemovePiece = new RoutedCommand();
        public static RoutedCommand AboutCommand = new RoutedCommand();
        //public static RoutedCommand About = new RoutedCommand();

        private MyllyPeli peli = new MyllyPeli();
        //private static Dictionary<int, Tuple<int, int>> PeliKoordToUIKoordMap = new Dictionary<int, Tuple<int, int>>();
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

        private int UIKoordsToPeliKoord(int x, int y)
        {
            for (int i = 0; i < PeliKoordToUIKoordMap.Count(); i++)
            {
                if (PeliKoordToUIKoordMap[i][0] == x && PeliKoordToUIKoordMap[i][1] == y)
                    return i;
            }
            return -1;
        }

        private void PeliKoordToUIKoords(int peliKoord, out int x, out int y)
        {
            x = PeliKoordToUIKoordMap[peliKoord][0];
            y = PeliKoordToUIKoordMap[peliKoord][1];
        }

        private void CanExecuteInsertPiece(object sender, CanExecuteRoutedEventArgs e)
        {
            if (peli.tila == Pelitila.Lisaa)
            {
                e.CanExecute = false;
                return;
            }
            e.CanExecute = true;
        }

        private void ExecutedInsertPiece(object sender, ExecutedRoutedEventArgs e)
        {
            peli.tila = Pelitila.Lisaa;
        }

        public MainWindow()
        {
            CommandBinding InsertPieceBinding = new CommandBinding(InsertPiece, ExecutedInsertPiece, CanExecuteInsertPiece);
            CommandBinding MovePieceBinding = new CommandBinding(MovePiece, ExecutedMovePiece, CanExecuteMovePiece);
            CommandBinding RemovePieceBinding = new CommandBinding(RemovePiece, ExecutedRemovePiece, CanExecuteRemovePiece);
            CommandBinding AboutBinding =       new CommandBinding(AboutCommand, CommandBindingAbout_Executed);
            this.CommandBindings.Add(InsertPieceBinding);
            this.CommandBindings.Add(MovePieceBinding);
            this.CommandBindings.Add(RemovePieceBinding);
            this.CommandBindings.Add(AboutBinding);
            InitializeComponent();
            peli.Changed += PaivitaUI;
        }

        private void CanExecuteRemovePiece(object sender, CanExecuteRoutedEventArgs e)
        {
            if (peli.valittuNappula != null)
            {
                e.CanExecute = true;
                return;
            }
            e.CanExecute = false;
        }

        private void ExecutedRemovePiece(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CanExecuteMovePiece(object sender, CanExecuteRoutedEventArgs e)
        {
            if (peli.valittuNappula != null)
            {
                e.CanExecute = true;
                return;
            }
            e.CanExecute = false;
        }

        private void ExecutedMovePiece(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PaivitaUI(object sender, EventArgs e)
        {
            for (int i = 0; i < PeliKoordToUIKoordMap.Length; i++)
            {

            }
        }

        private void Window_PelipisteClick(object sender, RoutedEventArgs e)
        {
            if (peli.tila == Pelitila.Lisaa)
            {
                var args = (PelilautaNamespace.PelilautaController.PelipisteClickEventArgs)e;

                Nappula uusi = peli.setTargetKoord(UIKoordsToPeliKoord(args.X, args.Y));

                //peli.Lisaa(alue)
                UusiNappula(args.Alue, uusi);

                peli.tila = Pelitila.Odota;
            }
        }

        private void UusiNappula(PelilautaNamespace.Pelialue alue, Nappula uusi)
        {
            PelinappulaNamespace.PeliNappula nappula = new PelinappulaNamespace.PeliNappula(uusi);
            alue.Children.Add(nappula);
            nappula.UpdateLayout();
            Canvas.SetLeft(nappula, alue.PuolikasLeveys - (nappula.ActualWidth / 2));
            Canvas.SetTop(nappula, alue.PuolikasKorkeus - (nappula.ActualHeight / 2));
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Window click");
            peli.tila = Pelitila.Odota;
        }
        
        private void CommandBindingAbout_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            About about = new About(); ;
            about.ShowDialog();
        }

        private void CommandBindingHelp_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            HelpWindow help = new HelpWindow();
            help.ShowDialog();
        }
    }





}
