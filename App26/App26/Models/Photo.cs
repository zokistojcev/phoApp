
using FFImageLoading.Forms;

namespace App26.Models
{
    public class Photo
    {
        public int albumId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }
        public CachedImage ImageCached { get; set; }
        public bool imageIsVisible { get; set; }
        public bool thumbnailIsVisible { get; set; } = true;

    }
}
