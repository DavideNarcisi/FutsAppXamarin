using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using FutsAppXamarin.Popup;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FutsAppXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Marcatori : ContentPage
    {
        List<Giocatore> marcatori;
     
        public Marcatori()
        {
            InitializeComponent();
            marcatori = new List<Giocatore>(Giocatore.amici); //cambiare con amici            
            Ordina();

            try
            {
                marcatori[0].medalm = "gold.jpg";
                marcatori[1].medalm = "silver.jpg";
                marcatori[2].medalm = "bronzo.jpg";
            }
            catch(Exception e)
            { }
            

            ClassificaListView.ItemsSource = marcatori;
            
        }

        public void Ordina() {
            Giocatore temp;
            
            for (int i = 0; i < marcatori.Count-1; i++)
            {
                
                for (int j = 1; j < marcatori.Count; j++) {
                    if (((int)marcatori[j].dati["gol fatti"] > (int)marcatori[j - 1].dati["gol fatti"]) ||
                        ((int)marcatori[j].dati["gol fatti"] == (int)marcatori[j - 1].dati["gol fatti"] &&
                                (int)marcatori[j].dati["partite giocate"] < (int)marcatori[j - 1].dati["partite giocate"]))
                    {
                        temp = marcatori[j - 1];
                        marcatori[j - 1] = marcatori[j];
                        marcatori[j] = temp;
                        
                    }
                }
                
            }
            for (int i = 0; i < marcatori.Count - 1; i++)
                marcatori[i].positionm = (i + 1).ToString();


        }
        private void ClassificaListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (sender is ListView lv) lv.SelectedItem = null;
            var giocatore = e.Item as Giocatore;
            Navigation.PushPopupAsync(new popup_vedi_giocatore(giocatore));
        }
    }
}