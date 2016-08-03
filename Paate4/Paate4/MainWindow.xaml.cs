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
using Microsoft.Win32;

namespace Paate4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int laskuri;


        void SaveCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            MainWindow window = (MainWindow)sender;

            if (window.autolaskuri1.Laskuri > 0 || window.autolaskuri2.Laskuri > 0  )
            {
                e.CanExecute = true;
            } else
            {
                e.CanExecute = false;
            }
        }

        void SaveCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            
            SaveFileDialog saveDialog = new SaveFileDialog();

            if (saveDialog.ShowDialog() == true)
            { }
        }

        public int Laskuri
        {
            get
            {
                return laskuri;
            }
            set
            {
                laskuri = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();


            CommandBinding SaveCmdBinding = new CommandBinding(ApplicationCommands.Save, SaveCmdExecuted, SaveCmdCanExecute);

            this.CommandBindings.Add(SaveCmdBinding);
        }


        private void Laske_Click(object sender, RoutedEventArgs e)
        {
            laskuri++;
            Label.Content = Laskuri;
        }
    }
}
