using App26.ViewModels;
using App26.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace App26
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(DetailPhoto), typeof(DetailPhoto));
            Routing.RegisterRoute(nameof(PhotosPage), typeof(PhotosPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
