using App26.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App26.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotosPage : ContentPage
    {
        public PhotosPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            await vm.GetAllPhotos();
        }

        private async void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            Frame frame = (Frame)sender;
            TapGestureRecognizer tapGesture = (TapGestureRecognizer)frame.GestureRecognizers[0];
            Photo photo = new Photo();
            photo = tapGesture.CommandParameter as Photo;
            await Navigation.PushAsync(new DetailPhoto(photo));
        }
    }
}