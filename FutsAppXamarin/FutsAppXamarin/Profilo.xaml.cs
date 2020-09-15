using FutsAppXamarin.Model;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FutsAppXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profilo : ContentPage
    {
        public Profilo()
        {
            InitializeComponent();
            username.Text = Giocatore.user.username;
            giocate.Text = Giocatore.user.dati["partite giocate"].ToString();
            gol.Text = Giocatore.user.dati["gol fatti"].ToString();
            pareggi.Text = Giocatore.user.dati["pareggi"].ToString();
            vinte.Text = Giocatore.user.dati["vittorie"].ToString();
            perse.Text = Giocatore.user.dati["sconfitte"].ToString();
            SetImmagine();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("ERRORE", "Formato non supportato", "OK");
                return;
            }
            else 
            {
                var img = await CrossMedia.Current.PickPhotoAsync();
                if (img != null)
                {
                    Console.WriteLine("aaaaaaaaa");
                    profile_image.Source = ImageSource.FromStream(() => img.GetStream());
                    Console.WriteLine("oooooooooo");
                    var result = await new ImageHelper().SaveImage(img.GetStream(), Giocatore.user.username);
                    if (result.Equals(""))
                        await DisplayAlert("ERRORE","Problema nel caricamento","OK");
                }
            }
        }
        private async void SetImmagine()
        {
            ImageSource img = await new ImageHelper().LoadImage(Giocatore.user.username);
            if (!img.Equals(null))
                profile_image.Source = img;

        }

    }
}