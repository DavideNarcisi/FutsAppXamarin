using FutsAppXamarin.Model;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ImageCircle.Forms.Plugin;
using Xamarin.Forms.Internals;

namespace FutsAppXamarin.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class popup_giocatore : Rg.Plugins.Popup.Pages.PopupPage
    {
        Giocatore giocatore;
        IList<string> listamici = new List<string>();
        
        public popup_giocatore(Giocatore giocatore)
        {
            this.giocatore = giocatore;
            InitializeComponent();
            username.Text = giocatore.username;
            giocate.Text = giocatore.dati["partite giocate"].ToString();
            gol.Text = giocatore.dati["gol fatti"].ToString();
            pareggi.Text = giocatore.dati["pareggi"].ToString();
            vinte.Text = giocatore.dati["vittorie"].ToString();
            perse.Text = giocatore.dati["sconfitte"].ToString();
            
            var amici = (System.Collections.IList) giocatore.dati["amici"];
            
            foreach (Giocatore g in Giocatore.players)
            {
                if (amici.Contains(g.username))
                    listamici.Add(g.username);
            }
            if (listamici.Contains(Giocatore.user.username))
            {
                amico.IsToggled = true;
                amico.ThumbColor = Color.FromHex("#094ba3");
            }
            else
            { 
                amico.IsToggled = false;
                amico.ThumbColor = Color.White;
                
            }
            
            SetImmagine();            
        }

        private async void SetImmagine()
        {
            ImageSource img = await new ImageHelper().LoadImage(giocatore.username);
            if (!img.Equals(null))
                profile_image.Source = img;
           
        }

        private void amico_Toggled(object sender, ToggledEventArgs e)
        {
            if (amico.IsToggled)
            {                
                amico.ThumbColor = Color.FromHex("#094ba3");
            }
            else
            {                
                amico.ThumbColor = Color.White;
            }
        }

        private void Close(object sender, EventArgs e)
        {

            if ((amico.IsToggled && !listamici.Contains(Giocatore.user.username)) || (!amico.IsToggled && listamici.Contains(Giocatore.user.username)))
                UpdateAmici.UpdateFriends(listamici, giocatore);
            Navigation.PopPopupAsync();
        }
        protected override bool OnBackButtonPressed()
        {
            if ((amico.IsToggled && !listamici.Contains(Giocatore.user.username)) || (!amico.IsToggled && listamici.Contains(Giocatore.user.username)))
                UpdateAmici.UpdateFriends(listamici, giocatore);
            Navigation.PopPopupAsync();
            return true;
        }

        // Invoked when background is clicked
        protected override bool OnBackgroundClicked()
        {
            if ((amico.IsToggled && !listamici.Contains(Giocatore.user.username)) || (!amico.IsToggled && listamici.Contains(Giocatore.user.username)))
                UpdateAmici.UpdateFriends(listamici, giocatore);
            Navigation.PopPopupAsync();
            return false;
        }
    }
}