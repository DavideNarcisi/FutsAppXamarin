using FutsAppXamarin.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FutsAppXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class home : ContentPage
    {
        public home()
        {
      
            InitializeComponent();
            Application.Current.Properties["logged"] = "true";
            Application.Current.SavePropertiesAsync();

            try
            {
                if (Match.giocate.Length != 0)
                    risultato.Text = Match.giocate[0].risultato;
                else
                {
                    prima.IsVisible = true;
                    normale.IsVisible = false;
                }
            }
            catch(Exception exc)
            {
                prima.IsVisible = true;
                normale.IsVisible = false;
            }

            try
            {
                if (Match.daFare.Length != 0 && Match.daFare.Length != 1)
                {
                    inserisci.Text = Match.daFare.Length + " risultati da inserire";
                    inserisci.BackgroundColor = Color.FromHex("#f12213");
                }
                else if (Match.daFare.Length == 1)
                {
                    inserisci.Text = Match.daFare.Length + " risultato da inserire";
                    inserisci.BackgroundColor = Color.FromHex("#f12213");
                }
            }
            catch (Exception err)
            {
                
            }


        }

        

        void gestisci_click(object sender, System.EventArgs e)
        {
            if (sender.Equals(inserisci))                        
                Navigation.PushAsync(new InserisciRisultato());            
            else if (sender.Equals(storico))
                Navigation.PushAsync(new Storico());
            else if (sender.Equals(nuova_partita))
                Navigation.PushAsync(new NuovaPartita());
            else if (sender.Equals(classifiche))
                Navigation.PushAsync(new Classifiche());
        }
    }
}