using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WhiteBoard.Business.Services;
using WhiteBoard.Models.Data;
using System.Linq;
namespace WhiteBoard.Pages
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Images : UserControl
    {

        private readonly ImageService _imgService;
        public Images()
        {
            InitializeComponent();
            _imgService = new ImageService();
            LoadImages();
        }

        private void LoadImages()
        {
            var response = _imgService.ObatainSavedimages();

            if (response.Succesfull)
            {
                if (response.Data.ToList().Count <= 0)
                {
                    LBLMsg.Visibility = Visibility.Visible;
                }
                else
                {
                    lvImages.ItemsSource = new ObservableCollection<Dataimage>(response.Data);
                    LBLMsg.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Dialogs.ErrorDialog ed= new Dialogs.ErrorDialog();
                ed.SetMessage("Cannot connect to the server");
                ed.ShowDialog();
            }
        }
    }
}
