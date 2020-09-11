using FutsAppXamarin.Model;
using Network;
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
    }
}