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
using WiimoteLib;
using System.Drawing;
using System.Threading;

namespace WhiteBoard.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        Wiimote wm;
        Boolean connected, recording;

        public Home()
        {
            connected = false;
            recording = false;
            wm = new Wiimote();
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wm.Connect();
                connected = true;
                recording = true;
                wm.WiimoteChanged += wm_WiimoteChanged;
                wm.SetLEDs(true, false, false, true);
                BtnConnect.IsEnabled = false;
            }
            catch (WiimoteNotFoundException ex)
            {
                Dialogs.ErrorDialog ed = new Dialogs.ErrorDialog();
                ed.SetMessage("A Wiimote could not be found, please connect it through Bluetooth and try again.");
                ed.ShowDialog();
            }
        }

        [STAThread]
        private void wm_WiimoteChanged(object sender, WiimoteChangedEventArgs args)
        {
            if (recording)
            {
                WiimoteState ws = args.WiimoteState;
                UpdateImage(ws.IRState);
            }
        }

        [STAThread]
        private void UpdateImage(IRState irState)
        {

            System.Drawing.Point p = new System.Drawing.Point((int)(irState.IRSensors[0].RawPosition.X / 4), (int)(irState.IRSensors[0].RawPosition.Y / 4));
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                System.Windows.Shapes.Rectangle rect = new System.Windows.Shapes.Rectangle();
                rect.Stroke = new SolidColorBrush(Colors.Blue);
                rect.Fill = new SolidColorBrush(Colors.Blue);
                rect.Width = 4;
                rect.Height = 4;
                Canvas.SetLeft(rect, p.X);
                Canvas.SetBottom(rect, p.Y);
                this.canvas.Children.Add(rect);
            });


        }


        private void demo(Canvas canvas)
        {
            System.Windows.Shapes.Rectangle rect = new System.Windows.Shapes.Rectangle();
            rect.Stroke = new SolidColorBrush(Colors.Blue);
            rect.Fill = new SolidColorBrush(Colors.Blue);
            rect.Width = 4;
            rect.Height = 4;
            Canvas.SetLeft(rect, 10);
            Canvas.SetTop(rect, 10);
            //this.canvas.Children.Add(rect);  
        }
    }
}
