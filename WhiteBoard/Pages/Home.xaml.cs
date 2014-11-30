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
using WhiteBoard.Business.Services;
using WhiteBoard.Models.Data;
using WiimoteLib;
using System.Drawing;
using System.Threading;
using System.IO;

namespace WhiteBoard.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        Wiimote wm;
        Boolean connected, recording;

        private readonly ImageService _imgService;

        public Home()
        {
            connected = false;
            recording = false;
            wm = new Wiimote();
            _imgService = new ImageService();
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

        private void wm_WiimoteChanged(object sender, WiimoteChangedEventArgs args)
        {
            if (recording)
            {
                WiimoteState ws = args.WiimoteState;
                UpdateImage(ws.IRState);
            }
        }

        private void UpdateImage(IRState irState)
        {

            System.Drawing.Point p = new System.Drawing.Point((int)(irState.IRSensors[0].RawPosition.X / 3), (int)(irState.IRSensors[0].RawPosition.Y / 3));
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                System.Windows.Media.Color color = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(Globals.color);
                System.Windows.Shapes.Rectangle rect = new System.Windows.Shapes.Rectangle();
                rect.Stroke = new SolidColorBrush(color);
                rect.Fill = new SolidColorBrush(color);
                rect.Width = 3;
                rect.Height = 3;
                Canvas.SetLeft(rect, p.X);
                Canvas.SetBottom(rect, p.Y);
                this.canvas.Children.Add(rect);
            });


        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap((int)canvas.Width, (int)canvas.Height, 96d, 69d, PixelFormats.Pbgra32);
            canvas.Measure(new System.Windows.Size((int)canvas.Width, (int)canvas.Height));
            canvas.Arrange(new Rect(new System.Windows.Size((int)canvas.Width, (int)canvas.Height)));
            renderBitmap.Render(canvas);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(renderBitmap));

            var imageName = string.Format("{0}{1}{2}{3}{4}{5}.png", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            var response = new Response();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                encoder.Save(memoryStream);

                response = _imgService.SaveImage(memoryStream.ToArray(), imageName);
            }
            Application.Current.MainWindow.Height++;
            Application.Current.MainWindow.Height--;
            if (response.Succesfull)
            {
                Dialogs.ErrorDialog ed = new Dialogs.ErrorDialog();
                ed.SetMessage("Imagen guardada exitosamente");
                ed.SetTitle("Success!");
                ed.ShowDialog();
            }
            else
            {
                Dialogs.ErrorDialog ed = new Dialogs.ErrorDialog();
                ed.SetMessage("Cannot connect to the server");
                ed.ShowDialog();
            }
            
        }

        private void BtnSetBoundaries_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Shapes.Rectangle rect = new System.Windows.Shapes.Rectangle();
            rect.Stroke = new SolidColorBrush(Colors.White);
            rect.Fill = new SolidColorBrush(Colors.White);
            rect.Width = canvas.Width;
            rect.Height = canvas.Height;
            Canvas.SetLeft(rect, 0);
            Canvas.SetBottom(rect, 0);
            this.canvas.Children.Add(rect);
        }
    }
}
