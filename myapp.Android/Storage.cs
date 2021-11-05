using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Provider;
using Android.Util;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using myapp.Droid;
using myapp.Droid;
using myapp.Models;
using myapp.Services;
using myapp.ViewModels;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.CommunityToolkit.Core;
using Xamarin.Essentials;
using Xamarin.Forms;


[assembly: Xamarin.Forms.Dependency(typeof(Storage))]
namespace myapp.Droid
{
    class Storage : IStorage
    {
        public string public_path;
        public Storage()
        {
            checkOwnPublicDir(); 
        }

      
        [Obsolete]
        private void checkOwnPublicDir()
        {
            string path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim).AbsolutePath;
            path = System.IO.Path.Combine(path, "FISI");
           
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }

            public_path = path;
        }

        public string getOwnPublicDir()
        {
            return public_path;
        }

        public void requestMediaScan(string path)
        {
            MediaScannerConnection.ScanFile(Android.App.Application.Context, new string[] { path }, null, null);
        }

        public void openVideo(string file_path)
        {
            /*
            Java.IO.File file = new Java.IO.File(file_path);

            Intent intent = new Intent();
            intent.AddFlags(ActivityFlags.NewTask);
            intent.SetAction(Intent.ActionView);
            
            intent.SetDataAndType(Android.Net.Uri.FromFile(file), "video/mp4");
            Xamarin.Forms.Forms.Context.StartActivity(intent);
            */
            /*
            Launcher.OpenAsync
                           (new OpenFileRequest()
                           {
                               File = new ReadOnlyFile(file_path)
                           }
                       );
            */
            /*
            Java.IO.File file = new Java.IO.File(file_path);
            Android.Net.Uri uri = Android.Net.Uri.FromFile(file);


            Intent i = new Intent(Intent.ActionView);
            i.SetDataAndType(uri, "video/mp4");
            Xamarin.Forms.Forms.Context.StartActivity(i);
            
            */
            
        
            Java.IO.File file = new Java.IO.File(file_path);
            //Android.Net.Uri uri = Android.Net.Uri.FromFile(file);

            Android.Net.Uri photoURI = AndroidX.Core.Content.FileProvider.GetUriForFile(Android.App.Application.Context, Android.App.Application.Context.PackageName + ".provider", file);

            Android.Content.Intent intent = new Android.Content.Intent(Android.Content.Intent.ActionView);
            intent.SetDataAndType(photoURI, "video/*");
            Xamarin.Forms.Forms.Context.StartActivity(intent);
            
            /*
            var videoFile = new Java.IO.File(Java.Net.URI.Create($"file://{file}"));
            Android.Net.Uri fileUri = AndroidX.Core.Content.FileProvider.GetUriForFile(Android.App.Application.Context, $"{Android.App.Application.Context.PackageName}.fileprovider", videoFile);
            Android.Content.Intent intent = new Android.Content.Intent();

            intent.SetAction(Android.Content.Intent.ActionView);
            intent.AddFlags(ActivityFlags.NewTask);
            intent.AddFlags(ActivityFlags.GrantReadUriPermission);
            intent.SetDataAndType(fileUri, "video/*");
            Android.App.Application.Context.ApplicationContext.StartActivity(intent);
            */
        }


        public ObservableCollection<Video> getVideoPreviewList()
        {

          
            ObservableCollection <Video> list = new ObservableCollection<Video>();

            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(this.public_path);
            foreach (string fileName in fileEntries)
            {
                Video v = new Video();
                v.Name = System.IO.Path.GetFileName(fileName);
                v.File = fileName;

              
                list.Add(v);
            }

            return list;

        }
    }

    

}