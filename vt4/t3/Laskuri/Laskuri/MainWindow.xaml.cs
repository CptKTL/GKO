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

namespace Laskuri
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// New komento suoritetaan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            UusiTreeniLaskuri();
        }


        /// <summary>
        /// New komento voidaan suorittaa aina.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }


        /// <summary>
        /// Luo uuden treenilaskurin ikkunaan.
        /// </summary>
        private void UusiTreeniLaskuri()
        {
            Treenilaskuri.treenilaskuri laskuri = new Treenilaskuri.treenilaskuri();

            TreeniLaskurit.Children.Add(laskuri);
        }
    }
}
