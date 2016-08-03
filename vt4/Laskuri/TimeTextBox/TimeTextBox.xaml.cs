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

namespace TimeTextBox
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class timeTextBox : UserControl
    {


        public TimeSpan Time
        {
            get { return (TimeSpan)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Time.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register("Time", typeof(TimeSpan), typeof(timeTextBox), new FrameworkPropertyMetadata(TimeSpan.Zero, FrameworkPropertyMetadataOptions.AffectsRender, onTimeChanged, changeTime));

        public static object changeTime(DependencyObject obj, object value)
        {
            TimeSpan time = (TimeSpan)value;

            if (time.CompareTo(new TimeSpan(24, 0 , 0) ) >= 0)
            {
                throw new Exception("Suurempi kuin 24h.");
            } else if (time.CompareTo(new TimeSpan(0,0,0)) < 0)
            {
                throw new Exception("Pienenpi kuin 0.");
            }

            return time;
        }

        public static void onTimeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {

        }


        public timeTextBox()
        {
            InitializeComponent();
        }
    }
}
