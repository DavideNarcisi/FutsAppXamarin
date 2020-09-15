using FutsAppXamarin.Model;
using FutsAppXamarin.Pages;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace FutsAppXamarin.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class popup_menu : PopupPage
    {
        public popup_menu()
        {
            InitializeComponent();
            username.Text = Giocatore.user.username;
            SetImmagine();
        }

        private async void SetImmagine()
        {
            ImageSource img = await new ImageHelper().LoadImage(Giocatore.user.username);
            if (!img.Equals(null))
                profile_image.Source = img;

        }


        protected override bool OnBackButtonPressed()
        {
            Navigation.PopPopupAsync();
            return true;
        }
        async void Menu_Click(object sender, EventArgs e)
        {
            if (sender.Equals(profile))
                await Navigation.PushAsync(new Profilo());
            else if (sender.Equals(aboutus))
                await Navigation.PushAsync(new AboutUs());
            else if(sender.Equals(logout))
            {
                await Auth.Logout();
                Xamarin.Forms.Application.Current.Properties["firstrun"] = "true";               
                await Xamarin.Forms.Application.Current.SavePropertiesAsync();
                await Navigation.PopToRootAsync();
                Xamarin.Forms.Application.Current.MainPage = new LoginPage();
            }
            Navigation.PopPopupAsync();
        }
    }
}