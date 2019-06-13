using System;
using System.IO;
using System.Threading.Tasks;
using Reunion2020.Models;
using Xamarin.Forms;
namespace Reunion2020.Services.Helpers
{
    public class ImageHelper
    {
     
        // Tranform a string Base64 to image object
        public static  Image ImageFromBase64 (string imageBase64)
        {
            if (string.IsNullOrEmpty(imageBase64))
            {
            Application.Current.MainPage.DisplayAlert("Error", "Something went wrong while getting Images", "Ok");

            }
            Image image = new Image();
            string formattedString = imageBase64.Replace ("data:image/jpeg;base64,", "");
            byte[] Base64Stream = Convert.FromBase64String(formattedString);
            image.Source = ImageSource.FromStream(() => new MemoryStream(Base64Stream));
            return image;
        }
    }
}
