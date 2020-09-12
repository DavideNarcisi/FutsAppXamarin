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
    public partial class Marcatori : ContentPage
    {
        List<Giocatore> classifica;
        public Marcatori()
        {
            InitializeComponent();
            classifica = new List<Giocatore>(Giocatore.players);
            ClassificaListView.ItemsSource = classifica;
        }
    }
}