using App26.Models;
using FFImageLoading.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace App26.Services
{
    public class PhotosListDataStore : IDataPhotos<Photo>
    {
        HttpClient client;
        List<Photo> items;
        
        public PhotosListDataStore()
        {
            items = new List<Photo>();
            client = new HttpClient();
        }
        public async Task<List<Photo>> GetItemsAsync()
        {
            if (App.initalCall==0)
            {
                var response = await client.GetStringAsync("http://jsonplaceholder.typicode.com/photos");
                var allPhotos = JsonConvert.DeserializeObject<IEnumerable<Photo>>(response);
                items = allPhotos.Take(50).ToList();
                App.initalCall = 1;

                return items;
            }
            else
            {
                return items;
            }
        }
        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Photo arg) => arg.id.ToString() == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public bool EditPhotoAsync(string id, CachedImage i)
        {
            var editItem = items.Where((Photo arg) => arg.id.ToString() == id).FirstOrDefault();
            if (editItem != null)
            {
                //editItem.thumbnailUrl = dir;
                items.FirstOrDefault(x => x.id.ToString() == id).thumbnailUrl = null;
                items.FirstOrDefault(x => x.id.ToString() == id).imageIsVisible = true;
                items.FirstOrDefault(x => x.id.ToString() == id).thumbnailIsVisible = false;
                items.FirstOrDefault(x => x.id.ToString() == id).ImageCached = i;
                return true;
            }
            else return false;
         
        }

        public Task<bool> AddPhotoAsync(CachedImage i, string text)
        {
            Photo lastItem =  items.LastOrDefault();
            Photo p = new Photo { id = lastItem.id + 1, albumId = lastItem.albumId + 1, ImageCached = i, thumbnailUrl = null, url = null, title = text, imageIsVisible = true, thumbnailIsVisible = false };

            items.Add(p);
            return Task.FromResult(true);
        }
    }
}
