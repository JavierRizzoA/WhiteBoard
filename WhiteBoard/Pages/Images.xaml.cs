using System.Windows;
using System.Windows.Controls;
using WhiteBoard.Business.Services;
using WhiteBoard.ViewModels;

namespace WhiteBoard.Pages
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Images : UserControl
    {

        private readonly ImageService _imgService;
        private readonly ImagesViewModel _imagesViewModel;
        public Images()
        {
            InitializeComponent();
            _imgService = new ImageService();
            _imagesViewModel = new ImagesViewModel();
            DataContext = _imagesViewModel;
            LoadImages();
        }

        private void LoadImages()
        {
            var response = _imgService.ObatainSavedimages();

            if (response.Succesfull)
            {
                lvImages.ItemsSource = response.Data;
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }
    }
}
