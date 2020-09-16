using FutsAppXamarin.Popup;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
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
    public partial class search : ContentPage
    {
        List<Giocatore> Searchresult;
        List<Giocatore> giocatori;
        public search()
        {
            InitializeComponent();
            //giocatori = new List<Giocatore>(Giocatore.players);
            //GiocatoriListView.ItemsSource =  new List<Giocatore>();
        }
        private async void Giocatori_ItemTapped(object sender, EventArgs e)
        {
            if (sender is ListView lv) lv.SelectedItem = null;
            var but = sender as Button ;
            var s = but.Text;
            foreach (Giocatore g in Searchresult)
                if (g.username.Equals(s))
                {
                    await Navigation.PushPopupAsync(new popup_giocatore(g));
                    break;
                }
            //await DisplayAlert("Giocatore premuto", "Giocatore : " + giocatore.username, "OK");


        }
        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            Searchresult = new List<Giocatore>();
                       string keyword = SearchBar.Text;
            //IEnumerable<string> searchResult = giocatori.Where(giocatori => giocatori.ToLower().Contains(keyword.ToLower());
            
            giocatori = new List<Giocatore>(Giocatore.players);
           
            foreach (var g in giocatori)
            {
                if (g.username.ToLower().Contains(keyword.ToLower()) && !g.username.Equals(Giocatore.user.username))
                { Searchresult.Add(g);
               
                }
            }

            foreach (var i in Searchresult)
                Console.WriteLine(i.username);

            GiocatoriListView.ItemsSource = Searchresult;
         }

    }
}
