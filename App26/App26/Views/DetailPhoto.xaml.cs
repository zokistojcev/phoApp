using App26.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace App26.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPhoto : ContentPage
    {
     
        public DetailPhoto(Photo photo)
        {
            InitializeComponent();
            vm.DataBindPhotoDetail(photo);
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            Button b = sender as Button;
            var p = b.CommandParameter;
            await vm.DeeletePhoto(Convert.ToInt32(p));
            await Navigation.PopToRootAsync(true);



        }
        private async void btnSelectPic_Clicked(object sender, EventArgs e)
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
                detailImage.Source = ImageSource.FromStream(() => _mediaFile.GetStream());
                await vm.EditPhoto(vm.Photo.id.ToString(), detailImage);
            }
        }

        private async  void Button_Clicked_1(object sender, System.EventArgs e)
        {
            await vm.EditText();
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            await vm.SaveEditText(entryEdit.Text);
            
        }
    }
}