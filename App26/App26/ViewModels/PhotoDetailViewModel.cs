using System.Linq;
using App26.Models;
using App26.Services;
using System.Threading.Tasks;
using Xamarin.Forms;
using FFImageLoading.Forms;
using App26.Views;

namespace App26.ViewModels
{
    public class PhotoDetailViewModel: BaseViewModel
    {
        public IDataPhotos<Photo> DataStorePhotos => DependencyService.Get<IDataPhotos<Photo>>();
        private int _id;
        public int Id { get { return _id; } set { _id = value; OnPropertyChanged("Id"); } }
        private string _uri;
        public string Uri { get { return _uri; } set { _uri = value; OnPropertyChanged("Uri"); } }
        private Photo _photo;
        public Photo Photo { get { return _photo; } set { _photo = value; OnPropertyChanged("Photo"); } }
        private int albumId;
        public int AlbumId { get { return albumId; } set { albumId = value; OnPropertyChanged("AlbumId"); } }

        private string titlePhoto;
        public string TitlePhoto { get { return titlePhoto; } set { titlePhoto = value; OnPropertyChanged("TitlePhoto"); } }
        private string url;
        public string Url { get { return url; } set { url = value; OnPropertyChanged("Url"); } }
        private CachedImage _imageCached;
        public CachedImage ImageCached { get { return _imageCached; } set { _imageCached = value; OnPropertyChanged("ImageCached"); } }
        private bool _imageIsVisible;
        public bool ImageIsVisible { get { return _imageIsVisible; } set { _imageIsVisible = value; OnPropertyChanged("ImageIsVisible"); } }
        private bool _thumbnailIsVisible;
        public bool ThumbnailIsVisible { get { return _thumbnailIsVisible; } set { _thumbnailIsVisible = value; OnPropertyChanged("ThumbnailIsVisible"); } }

        private bool _editMode;
        public bool EditMode { get { return _editMode; } set { _editMode = value; OnPropertyChanged("EditMode"); } }
        private bool _defaultMode = true;
        public bool DefaultMode { get { return _defaultMode; } set { _defaultMode = value; OnPropertyChanged("DefaultMode"); } }
        private string _entryEditText;
        public string EntryEditText { get { return _entryEditText; } set { _entryEditText = value; OnPropertyChanged("EntryEditText"); } }
        public PhotoDetailViewModel()
        {
            Photo = new Photo();
        }

        internal Task EditPhoto(string id, CachedImage cachedImage)
        {
            DataStorePhotos.EditPhotoAsync(id, cachedImage);
            return Task.CompletedTask;
        }

        internal async Task SaveEditText(string text)
        {
            TitlePhoto = text;
            EditMode = false;
            DefaultMode = true;
            var allPhotos = await DataStorePhotos.GetItemsAsync();
            allPhotos.ToList().FirstOrDefault(x => x.id == Photo.id).title = text;
           
        }
        internal async Task EditText()
        {
            EditMode = true;
            DefaultMode = false;
            var allPhotos = await DataStorePhotos.GetItemsAsync();
            string tectTitle = allPhotos.ToList().FirstOrDefault(x => x.id == Photo.id).title;
            EntryEditText = tectTitle;
        }

        internal async Task DeeletePhoto(int id)
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("Question", "Are you sure you want to delete this photo?", "Yes", "No");
            if (answer)
            {
                await DataStorePhotos.DeleteItemAsync(id.ToString());
                
            }
        }
        public void DataBindPhotoDetail(Photo photo)
        {
            Id = photo.id;
            Photo = photo;
            Url = photo.url;
            TitlePhoto = photo.title;
            Title = TitlePhoto;
            ImageCached = photo.ImageCached;
            ThumbnailIsVisible = photo.thumbnailIsVisible;
            ImageIsVisible = photo.imageIsVisible;
        }
    }
}
