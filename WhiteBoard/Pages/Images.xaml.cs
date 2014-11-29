using System.Windows.Controls;
using WhiteBoard.Business.Services;

namespace WhiteBoard.Pages
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Images : UserControl
    {

        private readonly ImageService imgService;
        public Images()
        {
            InitializeComponent();
            imgService = new ImageService();
            LoadImages();
        }

        private void LoadImages()
        {
            var images = imgService.ObatainSavedimages();
        }
    }
}
