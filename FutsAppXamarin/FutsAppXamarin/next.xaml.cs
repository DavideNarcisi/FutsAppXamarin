using FutsAppXamarin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ImageCircle.Forms.Plugin;
using Rg.Plugins.Popup.Extensions;
using FutsAppXamarin.Popup;
using Rg.Plugins.Popup.Services;

namespace FutsAppXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class next : ContentPage
    {
        List<Match> partite;

        public next()
        {
            InitializeComponent();
            partite = new List<Match>(Match.daFare);
            PartiteListView.ItemsSource = partite;
            
            SetImmagine();

        }

         private async void SetImmagine()
         {
            foreach (Match m in partite)
            {
                ImageSource img = await new ImageHelper().LoadImage("milito"); //m.teams[0].ToString()
                if (!img.Equals(null))
                    m.profile_image = img;                                  
            }

            PartiteListView.ItemsSource = partite;


        }

        private void PartiteListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            
            if (sender is ListView lv) lv.SelectedItem = null;
            var partita = e.Item as Match;
            Navigation.PushPopupAsync(new popup_vedi_partita(partita));
        }
    }
}
