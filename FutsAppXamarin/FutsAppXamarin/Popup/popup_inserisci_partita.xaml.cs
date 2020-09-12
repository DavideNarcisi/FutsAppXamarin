using FutsAppXamarin.Model;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
    public partial class popup_inserisci_partita : PopupPage
    {
        Match match;
        public popup_inserisci_partita(Match match)
        {
            InitializeComponent();
            this.match = match;
            giocatoreA0.Text = match.teams[0].ToString();
            giocatoreA1.Text = match.teams[1].ToString();
            giocatoreA2.Text = match.teams[2].ToString();
            giocatoreA3.Text = match.teams[3].ToString();
            giocatoreA4.Text = match.teams[4].ToString();

            giocatoreB0.Text = match.teams[5].ToString();
            giocatoreB1.Text = match.teams[6].ToString();
            giocatoreB2.Text = match.teams[7].ToString();
            giocatoreB3.Text = match.teams[8].ToString();
            giocatoreB4.Text = match.teams[9].ToString();         


            luogo.Text = match.luogo;
            ora.Text = match.orario;
            data.Text = match.data;
        }

        private async void Salva(object sender, EventArgs e)
        {
            int totcasa, totosp;
            int[] golc, golo;
            try
            {
                totcasa = int.Parse(golCasa.Text);
                totosp = int.Parse(golOspite.Text);
                golc = new int[5] { int.Parse(golA0.Text), int.Parse(golA1.Text), int.Parse(golA2.Text), int.Parse(golA3.Text), int.Parse(golA4.Text) };
                golo = new int[5] { int.Parse(golB0.Text), int.Parse(golB1.Text), int.Parse(golB2.Text), int.Parse(golB3.Text), int.Parse(golB4.Text) };
            }
            catch(Exception err)
            { 
                Console.WriteLine(err.StackTrace);
                await DisplayAlert("ERRORE", "Riempire tutti i campi con valori numerici", "OK");
                return;
            }
            IList<string> squadra = new List<string>();
            foreach (var t in match.teams)
                squadra.Add(t.ToString());
            var result = await DataSave.SaveMatch(totcasa, totosp, golc, golo, squadra, match.risultato);
            if (result==1)
                Navigation.PopPopupAsync(); 
            else if(result==0)
                await DisplayAlert("ERRORE", "La somma dei gol fatti è diversa dai gol totali", "OK"); 
            else
                await DisplayAlert("ERRORE", "Problema nel salvataggio dati", "OK");

        }

        private void Close(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
        }
    }
}