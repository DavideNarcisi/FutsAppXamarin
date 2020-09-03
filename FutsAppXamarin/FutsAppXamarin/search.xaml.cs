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
        List<Giocatore> giocatori;
        public search()
        {
            InitializeComponent();
             giocatori = new List<Giocatore>
             {
                new Giocatore
                {
                    Id = 1,
                    Fullname = "Momo",
                    Speciality = "Attaccante"
                },
                {
                    new Giocatore
                    {
                        Id =2 ,
                        Fullname = "Tosky",
                        Speciality = "Portiere"
                    }
                },
                  new Giocatore
                    {
                        Id =3 ,
                        Fullname = "Fiore",
                        Speciality = "Centrocampista"
                    }

            };
            GiocatoriListView.ItemsSource =  new List<Giocatore>();
        }
        private async void Giocatori_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var giocatore = e.Item as Giocatore;
            await DisplayAlert("Giocatore premuto", "Giocatore : " + giocatore.Fullname, "OK");


        }
        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {

                       string keyword = SearchBar.Text;
            //IEnumerable<string> searchResult = giocatori.Where(giocatori => giocatori.ToLower().Contains(keyword.ToLower());
            List<Giocatore> Searchresult = new List<Giocatore> ();
          foreach (var g in giocatori)
            {

                if (g.Fullname.ToLower().Contains(keyword.ToLower()))
                   Searchresult.Add(g);
            }


            GiocatoriListView.ItemsSource =  Searchresult;
         }

    }
}
