using DLToolkit.Forms.Controls;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using myapp.ViewModels;

namespace myapp.Views
{
	public partial class GalleryPage : ContentPage
	{
		GalleryViewModel pageModel;

		public GalleryPage()
		{
			InitializeComponent();
			

			Title = "Gallery";

			pageModel = new GalleryViewModel(this);
			BindingContext = pageModel;

			FlowListView.Init();


		}


	}
}