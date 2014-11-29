using System.Collections.ObjectModel;
using WhiteBoard.Models.Data;

namespace WhiteBoard.ViewModels
{
    public class ImagesViewModel
    {
        public ObservableCollection<Dataimage> Model { get; set; }

        public ImagesViewModel()
        {
            Model=new ObservableCollection<Dataimage>();
        }

    }
}
