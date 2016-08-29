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

namespace PelinappulaNamespace
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class PeliNappula : UserControl
    {
        public Nappula nappula = null;

        /// <summary>
        /// Nappulan pohjaväri.
        /// </summary>
        public Brush color
        {
            get { return (Brush)GetValue(colorProperty); }
            set { SetValue(colorProperty, value); }
        }


        /// <summary>
        /// Värin Dependency property.
        /// </summary>
        public static readonly DependencyProperty colorProperty =
            DependencyProperty.Register("color", typeof(Brush), typeof(PeliNappula), 
                new FrameworkPropertyMetadata(Brushes.SaddleBrown, FrameworkPropertyMetadataOptions.AffectsRender));
        

        /// <summary>
        /// Constructor Pelinappulalle.
        /// </summary>
        /// <param name="nappula">Nappula johon halutaan kytkeä.</param>
        /// <param name="color">Nappulan väri.</param>
        public PeliNappula(Nappula nappula, Color color)
        {
            InitializeComponent();
            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Center;
            this.color = new SolidColorBrush(color);
            this.nappula = nappula;

            nappula.ValittuChangedHandler += NappulaValittu;
        }
        

        /// <summary>
        /// nappulan valitsemis kuuntelija.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NappulaValittu(object sender, EventArgs e)
        {
            if (nappula.Valittu)
            {
                ympyra.Stroke = Brushes.Red;
            }
            else
            {
                ympyra.Stroke = Brushes.Transparent;
            }
        }
    }
}
