using App26.Models;
using App26.Services;
using FFImageLoading.Forms;
using System;

using Xamarin.Forms;

namespace App26.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private string imageSource = "pngwing.png";
        private string description;
        public IDataPhotos<Photo> DataStorePhotos => DependencyService.Get<IDataPhotos<Photo>>();
        public CachedImage CachedImage { get; set; }
        public NewItemViewModel()
        {
            CachedImage = new CachedImage();
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
           return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public string ImageSource
        {
            get => imageSource;
            set => SetProperty(ref imageSource, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            //Item newItem = new Item()
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Text = Text,
            //    Description = Description
            //};
            await DataStorePhotos.AddPhotoAsync(CachedImage, Text);
        

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
