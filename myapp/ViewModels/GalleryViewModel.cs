using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using myapp.Views;
using myapp.Services;
using myapp.Models;

namespace myapp.ViewModels
{
    public class GalleryViewModel :  BindableObject  
    {

        private GalleryPage mainPage;

        IStorage storage;

        public GalleryViewModel(GalleryPage mainPage)
        {

            this.mainPage = mainPage;
            storage = DependencyService.Get<IStorage>();

            AddItems();

        }

        private void AddItems()
        {
          
            this.Videos = storage.getVideoPreviewList();
                    
        }

        private ObservableCollection<Video> _items = new ObservableCollection<Video>();
        public ObservableCollection<Video> Videos
        {
            get
            {
                return _items;
            }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged(nameof(Videos));
                }
            }
        }

        public Command ItemTappedCommand
        {
            get
            {
                return new Command((data) =>
                {
                    Video v = (Video)data;
                    this.storage.openVideo(v.File);
                    
                    //mainPage.DisplayAlert("FlowListView", data + "", "Ok");
                });
            }
        }


        
    }
}