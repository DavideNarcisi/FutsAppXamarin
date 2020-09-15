using FutsAppXamarin.Popup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FutsAppXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Classifiche : ContentPage
    {
        List<Giocatore> classifica;
        public Classifiche()
        {
            InitializeComponent();
            classifica = new List<Giocatore>(Giocatore.amici);
            Ordina();
            classifica[0].medal = "gold.jpg";
            classifica[1].medal = "silver.jpg";
            classifica[2].medal = "bronzo.jpg";

            ClassificaListView.ItemsSource = classifica;
        }


        public void Ordina()
        {
            Giocatore temp;
            
            for (int i = 0; i < classifica.Count-1; i++)
            {
               
                for (int j = 1; j < classifica.Count; j++)
                {
                    if (((int)classifica[j].dati["vittorie"] > (int)classifica[j - 1].dati["vittorie"]) ||
                        ((int)classifica[j].dati["vittorie"] == (int)classifica[j - 1].dati["vittorie"] &&
                                (int)classifica[j].dati["partite giocate"] < (int)classifica[j - 1].dati["partite giocate"]))
                    {
                        temp = classifica[j - 1];
                        classifica[j - 1] = classifica[j];
                        classifica[j] = temp;
                        
                    }
                }
                
            }
            for (int i = 0; i < classifica.Count; i++)
                classifica[i].position = (i + 1).ToString();

        }

        private void ClassificaListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (sender is ListView lv) lv.SelectedItem = null;
            var giocatore = e.Item as Giocatore;
            Navigation.PushPopupAsync(new popup_vedi_giocatore(giocatore));
        }
    }
}