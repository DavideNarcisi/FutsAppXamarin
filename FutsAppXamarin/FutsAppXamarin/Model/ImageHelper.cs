using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FutsAppXamarin.Model
{
    public class ImageHelper
    {
        private FirebaseStorage firebaseStorage = new FirebaseStorage("futsapp-b520f.appspot.com");

        public ImageHelper() { }

        public async Task<string> SaveImage(Stream fileStream, string fileName)
        {
            var imageUrl = await firebaseStorage
                .Child("images")
                .Child(fileName)
                .PutAsync(fileStream);
            
            return imageUrl;
        }

        public async Task<ImageSource> LoadImage(string fileName)
        {
            try
            {
                var webClient = new WebClient();
                var storageImage = await firebaseStorage
                    .Child("images")
                    .Child(fileName)
                    .GetDownloadUrlAsync();
                string imgurl = storageImage;
                byte[] imgBytes = webClient.DownloadData(imgurl);
                //string img = Convert.ToBase64String(imgBytes);
                var img = ImageSource.FromStream(() => new MemoryStream(imgBytes));
                
                
                return img;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }
    }
}
