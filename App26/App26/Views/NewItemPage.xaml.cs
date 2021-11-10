using App26.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using Xamarin.Forms;

namespace App26.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
       
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Error", "This is not support on your device.", "OK");
                return;
            }
            else
            {
                var mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };
                Plugin.Media.Abstractions.MediaFile _mediaFile = await CrossMedia.Current.PickPhotoAsync();
                if (_mediaFile == null) return;
                newItem.Source = ImageSource.FromStream(() => _mediaFile.GetStream());
                vm.Description = "a";
                vm.CachedImage.Source = newItem.Source;
                //await vm.AddPhoto(vm.Photo.id.ToString(), newItem);
            }
        }
    }
}