using myapp.Models;
using myapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Sockets;
using System.Text;
using Xamarin.CommunityToolkit.Core;
using static myapp.ViewModels.GalleryViewModel;

namespace myapp.Services
{
    public interface IStorage
    {     

        ObservableCollection<Video> getVideoPreviewList();

        void openVideo(string file);
    }
}
