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
using System.Windows.Shapes;

namespace Mylly
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public Color color;

        public SettingsWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// avaa uuden ColorDialogin josta voi valita värin.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Vari_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialog =
                       new System.Windows.Forms.ColorDialog();
            colorDialog.AllowFullOpen = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
            colorDialog.ShowDialog();

            color.A = colorDialog.Color.A;
            color.B = colorDialog.Color.B;
            color.G = colorDialog.Color.G;
            color.R = colorDialog.Color.R;
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
