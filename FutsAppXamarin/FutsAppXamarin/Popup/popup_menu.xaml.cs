using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FutsAppXamarin.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class popup_menu : PopupPage
    {
        public popup_menu()
        {
            InitializeComponent();
        }

        private void SwipeView_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            Navigation.PopPopupAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopPopupAsync();
            return true;
        }
    }
}