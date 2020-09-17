using FutsAppXamarin.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FutsAppXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChoosePlayer : ContentPage
    {
        List<Giocatore> squadra= new List<Giocatore>();
        List<String> squad = new List<String>();
        int sq;
        public ChoosePlayer()
        {
            InitializeComponent();
            sq = 2;
            Giocatori.ItemsSource = Inserisci(Giocatore.amici);
            
        }
        public ChoosePlayer(Giocatore user)
        {
            InitializeComponent();
            sq = 1;
            Giocatori.ItemsSource = Inserisci(Giocatore.amici); //da cambiare
            squadra.Add(user);
            squad.Add(user.username);
            
            
        }

        private Giocatore[] Inserisci(Giocatore[] amici)
        {
            Giocatore[] nuovo = new Giocatore[Giocatore.amici.Length - 1];
            int j=0;
            
            for(int i=0; i<Giocatore.amici.Length;i++)
            {
                if (!Giocatore.amici[i].Equals(Giocatore.user))
                    nuovo[i - j] = Giocatore.amici[i];
                else j = 1;
            }
            return nuovo;
        }

        private void Giocatore_Clicked(object sender, EventArgs e)
        {
            
            var v = sender as Button;
            var s= v.Text;
            //var giocatore = new Giocatore(s);
            if (!s.Equals(Giocatore.user.username))
            {
                if (!squad.Contains(s))
                {
                    squad.Add(s);                    
                    v.BackgroundColor = Color.FromHex("#fdd017");
                    v.BorderColor = Color.White;
                }
                else
                {
                    squad.Remove(s);
                    v.BackgroundColor = Color.FromHex("#fffc95");
                    v.BorderColor = Color.FromHex("#fdd017");
                }
            }
        }

        public async void Handle_Clicked(object sender, EventArgs e)
        {
            if (squad.Count < 5)
                await DisplayAlert("ERRORE", "Mancano dei giocatori", "OK");
            else if (squad.Count > 5)
                await DisplayAlert("ERRORE", "Troppi giocatori scelti", "OK");
            else
            {
                if (sq == 1)
                    NuovaPartita.teamA = squad.ToArray();
                else
                    NuovaPartita.teamB = squad.ToArray();
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
                await Navigation.PushAsync(new NuovaPartita(sq));
                Navigation.RemovePage(this);
            }

        }

        private void Giocatori_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (sender is ListView lv) lv.SelectedItem = null;
        }

        
    }
}