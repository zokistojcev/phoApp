using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Globalization;
using Xamarin.Forms;
using static Android.Graphics.ImageDecoder;

namespace App26
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value == null)
            {
                
                Plugin.Media.Abstractions.MediaFile _mediaFile = CrossMedia.Current.PickPhotoAsync().Result;

                value = ImageSource.FromStream(() => _mediaFile.GetStream());


                return "";
            }

            else return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
