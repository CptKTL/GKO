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

namespace vt7
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
        /// Avaa tulostus valikon ja tulostaa ikkunan sisällön.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Print_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PrintDialog diag = new PrintDialog();

            if (diag.ShowDialog() == true)
            {
                diag.PrintVisual(canvas, "Tulostus");
            }
        }
    }
}
