using FutsAppXamarin.Model;
using FutsAppXamarin.Popup;
using Rg.Plugins.Popup.Extensions;
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
    public partial class InserisciRisultato : ContentPage
    {
        List<Match> PartitaDaRegistrare;
        public InserisciRisultato()
        {
            InitializeComponent();
            PartitaDaRegistrare = new List<Match>(Match.daRegistrare);
            ListaDaRegistrare.ItemsSource = PartitaDaRegistrare;
        }

        private void ListaDaRegistrare_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (sender is ListView lv) lv.SelectedItem = null;
            var partita = e.Item as Match;
            Navigation.PushPopupAsync(new popup_inserisci_partita(partita));
        }
    }
}