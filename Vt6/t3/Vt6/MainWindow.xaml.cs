using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Threading;

namespace Vt6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int lukuja = 3;
        int min = 1;
        int max = 10;
        int vastaus;
        DispatcherTimer laskuTimer = new DispatcherTimer();
        Stopwatch Timer = new Stopwatch();

        char[] operaattoreita = { '+', '-' };
        char[] operaattorit;
        int[] luvut;

        Random rand = new Random();


        public MainWindow()
        {
            InitializeComponent();
            AddHandler(DragAndDropBehaviour.RaahausEvent, new RoutedEventHandler(Dock_Raahaus));
            laskuTimer.IsEnabled = true;
            laskuTimer.Tick += UpdateTimer;
        }


        /// <summary>
        /// Päivitetään timer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateTimer(object sender, EventArgs e)
        {
            AikaLabel.Content = String.Format("{0:00}:{1:00}", Timer.Elapsed.Minutes, Timer.Elapsed.Seconds, Timer.Elapsed.Milliseconds);
        }


        /// <summary>
        /// Lasketaan raahauksien määrä.
        /// </summary>
        public int Raahaukset
        {
            get { return (int)GetValue(RaahauksetProperty); }
            set { SetValue(RaahauksetProperty, value); }
        }
        
        public static readonly DependencyProperty RaahauksetProperty =
            DependencyProperty.Register("Raahaukset", typeof(int), typeof(MainWindow), new PropertyMetadata(0));

        
        /// <summary>
        /// Arvotaan luvut ja operaattorit laskutoimitukseen.
        /// </summary>
        private void ArvoLuvut()
        {
            luvut = new int[lukuja];
            operaattorit = new char[lukuja - 1];

            for (int i = 0; i < lukuja; i++)
            {
                luvut[i] = rand.Next(min, max + 1);
            }

            for (int i = 0; i < lukuja - 1; i++)
            {
                operaattorit[i] = operaattoreita[rand.Next(0, 2)];
            }

            vastaus = laskeVastaus();
        }


        /// <summary>
        /// Lasketaan arvoituista luvuista oikea vastaus.
        /// </summary>
        /// <returns></returns>
        private int laskeVastaus()
        {
            int lasku = luvut[0];

            for (int i = 0; i < operaattorit.Length; i++)
            {
                switch (operaattorit[i])
                {
                    case ('+'):
                        lasku += luvut[i + 1];
                        break;
                    case ('-'):
                        lasku -= luvut[i + 1];
                        break;
                }
            }

            return lasku;
        }


        /// <summary>
        /// Luodaan luvuista ja operaattoreista labelit ikkunaan.
        /// </summary>
        private void LuoLabelit()
        {
            foreach (int luku in luvut)
            {
                LuoNumeroLabel(luku);
            }

            LuoNumeroLabel(vastaus);

            foreach (char operaattori in operaattorit)
            {
                LuoOperaattoriLabel(operaattori);
            }

            LuoOperaattoriLabel('=');
        }


        /// <summary>
        /// LuoLabelin jossa numero. Sisältää DragAndDropBehaviorin.
        /// </summary>
        /// <param name="luku"></param>
        private void LuoNumeroLabel(int luku)
        {
            Label label = new Label();
            label.Content = luku;
            label.Padding = new Thickness(10);
            label.Background = Brushes.SandyBrown;
            
            label.SetValue(DragAndDropBehaviour.DragAndDropProperty, true);
            
            Lukualue.Children.Add(label);
            Canvas.SetLeft(label, rand.NextDouble() * (Lukualue.ActualWidth - label.ActualWidth));
            Canvas.SetTop(label, rand.NextDouble() * (Lukualue.ActualHeight - label.ActualHeight));
        }


        /// <summary>
        /// LuoLabelin jossa numero. Sisältää DragAndDropBehaviorin.
        /// </summary>
        /// <param name="operaattori"></param>
        private void LuoOperaattoriLabel(char operaattori)
        {
            Label label = new Label();
            label.Content = operaattori;
            label.Padding = new Thickness(10);
            label.Background = Brushes.SandyBrown;
            
            label.SetValue(DragAndDropBehaviour.DragAndDropProperty, true);
            
            Lukualue.Children.Add(label);

            Canvas.SetLeft(label, rand.NextDouble() * (Lukualue.ActualWidth - 20));
            Canvas.SetTop(label, rand.NextDouble() * (Lukualue.ActualHeight - 20));
        }


        /// <summary>
        /// Tekee uuden pelin. Arpoo uudet luvut ja operaattorit ja nollaa Timerin.
        /// </summary>
        public void UusiPeli()
        {
            Lukualue.Children.Clear();
            Vastausalue.Children.Clear();
            ArvoLuvut();
            LuoLabelit();
            Timer.Reset();
            Timer.Start();
            Raahaukset = 0;
        }


        /// <summary>
        /// Tarkistaa annetun vastauksen.
        /// </summary>
        /// <returns></returns>
        public bool Tarkista()
        {
            string valimerkki = "";
            string vastausString = "";
            List<int> vastausLuvut = new List<int>();
            List<char> vastausOperaattorit = new List<char>();

            foreach (Label control in Vastausalue.Children)
            {
                vastausString += control.Content;
                if (control.Content is char)
                {
                    vastausOperaattorit.Add((char)control.Content);
                }
                else
                {
                    vastausLuvut.Add((int)control.Content);
                }
            }

            string luvutString = "";
            string operaattoritString = "";

            foreach (int luku in luvut)
            {
                luvutString += valimerkki;
                luvutString += luku;
                valimerkki = "|";
            }

            valimerkki = "";

            foreach (char operaattori in operaattorit)
            {
                operaattoritString += valimerkki;
                operaattoritString += "\\" + operaattori;
                valimerkki = "|";
            }

            Regex regex = new Regex("((" + luvutString + "|" + vastaus + ")(" + operaattoritString + "))+(" + luvutString + "|" + vastaus + ")=" + "(" + luvutString + "|" + vastaus + ")");

            if (!regex.IsMatch(vastausString))
                return false;

            int laskettuVastaus = Convert.ToInt32(vastausLuvut[0]);
            for (int i = 0; i < vastausOperaattorit.Count; i++)
            {
                switch (vastausOperaattorit[i])
                {
                    case ('+'):
                        laskettuVastaus += vastausLuvut[i + 1];
                        break;
                    case ('-'):
                        laskettuVastaus -= vastausLuvut[i + 1];
                        break;
                }
            }

            return laskettuVastaus == vastausLuvut[vastausLuvut.Count - 1];

        }


        /// <summary>
        /// Kun ladataan ikkuna, tehdään uusi peli.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UusiPeli();
        }


        /// <summary>
        /// Suoritetaan kun jotain raahataan ikkunassa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dock_Raahaus(object sender, RoutedEventArgs e)
        {

            Raahaukset++;
            if (Tarkista())
            {
                siirrotLabel.Background = Brushes.Green;
                Timer.Stop();
            }
            else
            {
                siirrotLabel.Background = Brushes.Red;
            }
        }


        /// <summary>
        /// Vaihdetaan Raahattavan controllin parent.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_Drop(object sender, DragEventArgs e)
        {
            base.OnDrop(e);

            if (e.Data.GetDataPresent("Label"))
            {
                Label raahattava = (Label)e.Data.GetData("Label");
                Panel alku = (Panel)raahattava.Parent;
                Panel loppu = (Panel)sender;

                alku.Children.Remove(raahattava);
                loppu.Children.Add(raahattava);
            }

            e.Handled = true;
        }


        /// <summary>
        /// Uusipeli Command.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UusiPeli();
        }
    }



    /// <summary>
    /// Raahauksen toteutus.
    /// </summary>
    public static class DragAndDropBehaviour
    {
        public static bool GetDragAndDrop(DependencyObject obj)
        {
            return (bool)obj.GetValue(DragAndDropProperty);
        }

        public static void SetDragAndDrop(DependencyObject obj, bool value)
        {
            obj.SetValue(DragAndDropProperty, value);
        }

        public static readonly DependencyProperty DragAndDropProperty =
          DependencyProperty.RegisterAttached("DragAndDrop",
          typeof(bool), typeof(DragAndDropBehaviour),
          new UIPropertyMetadata(false, OnDragAndDropChanged));
        

        private static void OnDragAndDropChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Control control = (Control)sender;
            bool isDragAndDrop = (bool)(e.NewValue);

            if (isDragAndDrop)
                control.MouseMove += DragAndDrop;
            else
                control.MouseMove -= DragAndDrop;
        }

        private static void DragAndDrop(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject data = new DataObject();
                data.SetData("Label", control);
                System.Windows.DragDrop.DoDragDrop(control, data, DragDropEffects.Copy | DragDropEffects.Move);
                RoutedEventArgs neweventargs = new RoutedEventArgs(RaahausEvent);
                (control).RaiseEvent(neweventargs);
            }
        }

        public static readonly RoutedEvent RaahausEvent = EventManager.RegisterRoutedEvent("Raahaus", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Control));
    }
}
