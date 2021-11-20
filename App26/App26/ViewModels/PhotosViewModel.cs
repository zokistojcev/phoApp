using App26.Models;
using App26.Services;
using App26.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App26.ViewModels
{
    public class PhotosViewModel : BaseViewModel
    {
        public IDataPhotos<Photo> DataStorePhotos => DependencyService.Get<IDataPhotos<Photo>>();
        public static List<Photo> AllPhotosStatic { get; set; }

    private ObservableCollection<Photo> _allPhotos;
        public ObservableCollection<Photo> AllPhotos
        {
            get
            {
                return _allPhotos;
            }
            set
            {
                SetProperty(ref _allPhotos, value);
            }
        }
        public Command AddItemCommand { get; }
        public PhotosViewModel()
        {
            AllPhotos = new ObservableCollection<Photo>();
            AddItemCommand = new Command(OnAddItem);
            //Task.Run(async () => await DataStorePhotos.GetItemsAsync());
        }

        internal async void ExecuteNaviteToMatchDetails()
        {
             await Shell.Current.GoToAsync(nameof(MatchDetailsPage));
        }

        public async Task GetAllPhotos()
        {
            IsBusy = true;
            var ttAllPhotosStatic = await DataStorePhotos.GetItemsAsync();
            AllPhotosStatic = ttAllPhotosStatic.ToList();
            AllPhotos = new ObservableCollection<Photo>(ttAllPhotosStatic);
            IsBusy = false;
        }
        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }
    }
}
