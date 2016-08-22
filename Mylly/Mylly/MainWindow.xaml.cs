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


namespace Mylly
{
    public enum Pelitila
    {
        Odota,
        Insert
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static RoutedCommand InsertPiece = new RoutedCommand();

        public static Pelitila tila = new Pelitila();

        private void CanExecuteInsertPiece(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExecutedInsertPiece(object sender, ExecutedRoutedEventArgs e)
        {
            tila = Pelitila.Insert;
        }

        public MainWindow()
        {
            CommandBinding InsertPieceBinding = new CommandBinding(InsertPiece, ExecutedInsertPiece, CanExecuteInsertPiece);
            this.CommandBindings.Add(InsertPieceBinding);
            InitializeComponent();


        }

        private void Window_Oma(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Oma event ikkuna");

            Ellipse piste = (Ellipse)e.OriginalSource;

        }
    }





}
