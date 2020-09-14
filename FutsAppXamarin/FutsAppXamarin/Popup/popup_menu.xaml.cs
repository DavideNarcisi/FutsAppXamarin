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
        }

      

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopPopupAsync();
            return true;
        }
        void Menu_Click(object sender, EventArgs e)
        {
            if (sender.Equals(profile))
                Navigation.PushAsync(new Profilo());
            else if (sender.Equals(aboutus))
                Navigation.PushAsync(new AboutUs());
            Navigation.PopPopupAsync();
        }
    }
}