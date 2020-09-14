using FutsAppXamarin.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace FutsAppXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuovaPartita : ContentPage
    {
        static TimeSpan time;
        static string place;
        static DateTime data;
        string ora;
        int y=0, m, g;
        public static string[] teamA;
        public static string[] teamB;

        public static List<Giocatore> listaA;
        public static List<Giocatore> listaB;

        public NuovaPartita()
        {
            InitializeComponent();
            time = TimeSpan.Zero;
            data = DateTime.Now;
            place = "";
            listaA = new List<Giocatore> { Giocatore.user,
            new Giocatore("aggiungi"),
            new Giocatore("aggiungi"),
            new Giocatore("aggiungi"),
            new Giocatore("aggiungi")
        };
            SquadraA.ItemsSource = listaA;
            listaB = new List<Giocatore>{
                new Giocatore("aggiungi"),
                new Giocatore("aggiungi"),
            new Giocatore("aggiungi"),
            new Giocatore("aggiungi"),
            new Giocatore("aggiungi")
        };
            SquadraB.ItemsSource = listaB;

        }

        public NuovaPartita(int j)
        {
            InitializeComponent();
            
            if(j==1)
                listaA= new List<Giocatore>{
                new Giocatore(teamA[0]),
                new Giocatore(teamA[1]),
                new Giocatore(teamA[2]),
                new Giocatore(teamA[3]),
                new Giocatore(teamA[4])};
            else
                listaB = new List<Giocatore>{
                new Giocatore(teamB[0]),
                new Giocatore(teamB[1]),
                new Giocatore(teamB[2]),
                new Giocatore(teamB[3]),
                new Giocatore(teamB[4])
                };

            SquadraA.ItemsSource = listaA;
            SquadraB.ItemsSource = listaB;
            if(place!="")
            luogo.Text = place;
            if (data != DateTime.Now)
                dataPick.Date = data;
            if(time!= TimeSpan.Zero)
                oraPick.Time=time;

        }


      

        private async void Giocatori_Clicked_A(object sender, ItemTappedEventArgs e)
        {
            
            await Navigation.PushAsync(new ChoosePlayer(Giocatore.user));
        }

        private void luogo_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            place = luogo.Text;
        }

        private void oraPick_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            time = oraPick.Time;
        }

        private void dataPick_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            data = dataPick.Date;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
           
                if (place.Equals(""))
                {
                    await DisplayAlert("ERRORE", "Riempire tutti i campi", "OK");
                    return;
                }

                if (teamA[4].Equals("aggiungi") || teamB[4].Equals("aggiungi"))
                {
                    await DisplayAlert("ERRORE", "Completa le squadre", "OK");
                    return;
                }
                foreach (var s in teamA)
                {

                    foreach (var s1 in teamB)
                    {
                        if (s1.Equals(s))
                        {
                            await DisplayAlert("ERRORE", "Stesso giocatore in due squadre", "OK");
                            return;
                        }

                    }
                }

                ora = oraPick.Time.ToString();
                y = dataPick.Date.Year;
                m = dataPick.Date.Month;
                g = dataPick.Date.Day;
                string[] arr = new string[10];
                teamA.CopyTo(arr, 0);
                teamB.CopyTo(arr, 5);
                if (await DataSave.SetMatch(luogo.Text, y * 10000 + m * 100 + g, ora, new List<string>(arr)))
                    Navigation.PopAsync();

                else await DisplayAlert("ERRORE", "Problema nel savataggio dati", "OK");
           
        }

        private async void Giocatori_Clicked_B(object sender, ItemTappedEventArgs e)
        {

            await Navigation.PushAsync(new ChoosePlayer());
        }

        
        
    }
}