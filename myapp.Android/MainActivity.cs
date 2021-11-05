using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Essentials;
using AndroidX.Core.Content;
using Android;
using AndroidX.Core.App;
using Xamarin.Forms;
using myapp.Services;
using Android.Content;
using Android.Views;
using myapp;

namespace myapp.Droid
{
    [Activity(Label = "myapp", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Landscape)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        public static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            requestPermissions();

            Window.AddFlags(WindowManagerFlags.Fullscreen);


            //detectIntent();

            Instance = this;

        }

        protected override void OnStart()
        {
            base.OnStart();
        }


        protected override void OnResume()
        {
            //detectIntent();

            base.OnResume();
        }

        protected override void OnStop()
        {
            base.OnStop();
        }


 

        async void requestPermissions()
        {
            var status = await Permissions.RequestAsync<Permissions.StorageRead>();
            var status2 = await Permissions.RequestAsync<Permissions.StorageWrite>();


        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

       
    }
}