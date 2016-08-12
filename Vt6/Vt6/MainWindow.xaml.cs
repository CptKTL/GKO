using System;
using System.Collections.Generic;
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

namespace Vt6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int lukuja = 2;
        int min = 1;
        int max = 10;
        int vastaus;

        char[] operaattoreita = { '+', '-' };
        char[] operaattorit;
        int[] luvut;

        Random rand = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }



        public int Raahaukset
        {
            get { return (int)GetValue(RaahauksetProperty); }
            set { SetValue(RaahauksetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Raahaukset.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RaahauksetProperty =
            DependencyProperty.Register("Raahaukset", typeof(int), typeof(MainWindow), new PropertyMetadata(0));



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

        private void LuoNumeroLabel(int luku)
        {
            RaahausLabel label = new RaahausLabel();
            label.Content = luku;
            label.Padding = new Thickness(10);
            label.Background = Brushes.SandyBrown;

            //label.MouseMove += Label_MouseMove;


            Lukualue.Children.Add(label);
            Canvas.SetLeft(label, rand.NextDouble() * (Lukualue.ActualWidth - label.ActualWidth));
            Canvas.SetTop(label, rand.NextDouble() * (Lukualue.ActualHeight - label.ActualHeight));
        }


        private void LuoOperaattoriLabel(char operaattori)
        {
            RaahausLabel label = new RaahausLabel();
            label.Content = operaattori;
            label.Padding = new Thickness(10);
            label.Background = Brushes.SandyBrown;

            //label.MouseMove += Label_MouseMove;


            Lukualue.Children.Add(label);

            Canvas.SetLeft(label, rand.NextDouble() * (Lukualue.ActualWidth - 20));
            Canvas.SetTop(label, rand.NextDouble() * (Lukualue.ActualHeight - 20));
        }

        public void UusiPeli()
        {
            Lukualue.Children.Clear();
            Vastausalue.Children.Clear();
            ArvoLuvut();
            LuoLabelit();
        }


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
                } else
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

            Regex regex = new Regex("((" + luvutString + "|" + vastaus + ")(" + operaattoritString + "))+(" + luvutString + "|" + vastaus  + ")=" + "(" + luvutString + "|" +  vastaus + ")");

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UusiPeli();

        }

        private void Dock_Raahaus(object sender, RoutedEventArgs e)
        {

            Raahaukset++;
            if (Tarkista())
            {
                siirrotLabel.Background = Brushes.Green;
            }
            else
            {
                siirrotLabel.Background = Brushes.Red;
            }
        }


        private void Label_Drop(object sender, DragEventArgs e)
        {
            base.OnDrop(e);

            if (e.Data.GetDataPresent("Label"))
            {
                RaahausLabel raahattava = (RaahausLabel)e.Data.GetData("Label");
                Panel alku = (Panel)raahattava.Parent;
                Panel loppu = (Panel)sender;

                alku.Children.Remove(raahattava);
                loppu.Children.Add(raahattava);
            }

            e.Handled = true;
        }

        private void New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UusiPeli();
        }
    }

    public class RaahausLabel : Label
    {
        public static readonly RoutedEvent RaahausEvent = EventManager.RegisterRoutedEvent("Raahaus", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RaahausLabel));

        public event RoutedEventHandler Raahaus
        {
            add { AddHandler(RaahausEvent, value); }
            remove { RemoveHandler(RaahausEvent, value); }
        }

        void RaiseRaahausEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(RaahausLabel.RaahausEvent);
            RaiseEvent(newEventArgs);
        }

        private void Drag(object sender, DragEventArgs e)
        {
            RaiseRaahausEvent();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject data = new DataObject();
                // Omadata, Double ja Label ovat ihan mitä tahansa itsekeksittyjä tunnisteita
                // jos halutaan, että raahattava data toimii muissakin ohjelmissa niin on
                // käytettävä DataFormatsin sisältämiä vaihtoehtoja

                //data.SetData("OmaData", 10);
                //data.SetData(DataFormats.StringFormat, "merkkijono");
                //data.SetData("Double", 5.5);
                data.SetData("Label", this);


                // Aloitetaan raahaus
                //((Panel)((RaahausLabel)sender).Parent).Children.Remove((RaahausLabel)sender);

                System.Windows.DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
                RaiseRaahausEvent();
            }
        }

    }
}
