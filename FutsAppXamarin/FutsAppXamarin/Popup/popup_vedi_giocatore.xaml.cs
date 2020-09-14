using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutsAppXamarin.Model;
using Rg.Plugins.Popup.Extensions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FutsAppXamarin.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class popup_vedi_giocatore : PopupPage
    {
        public popup_vedi_giocatore(Giocatore giocatore)
        {
            InitializeComponent();
            username.Text = giocatore.username;
            giocate.Text = giocatore.dati["partite giocate"].ToString();
            gol.Text = giocatore.dati["gol fatti"].ToString();
            pareggi.Text = giocatore.dati["pareggi"].ToString();
            vinte.Text = giocatore.dati["vittorie"].ToString();
            perse.Text = giocatore.dati["sconfitte"].ToString();

            SetImmagine();
        }

        private async void SetImmagine()
        {
            ImageSource img = await new ImageHelper().LoadImage("milito");
            if (!img.Equals(null))
                profile_image.Source = img;

        }

        private void Close(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
        }
    }
}