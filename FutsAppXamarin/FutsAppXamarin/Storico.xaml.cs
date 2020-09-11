using FutsAppXamarin.Model;
using FutsAppXamarin.Popup;
using Network;
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
    public partial class Storico : ContentPage
    {
        List<Match> PartitaStorico;
        public Storico()
        {
            InitializeComponent();
            PartitaStorico = new List<Match>(Match.giocate);
            ListaStorico.ItemsSource = PartitaStorico;
        }

        private void ListaStorico_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (sender is ListView lv) lv.SelectedItem = null;
            var partita = e.Item as Match;
            Navigation.PushPopupAsync(new popup_partita_giocata(partita));
        }
    }
}