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
    public partial class Classifiche : ContentPage
    {
        List<Giocatore> classifica;
        public Classifiche()
        {
            InitializeComponent();
            classifica = new List<Giocatore>(Giocatore.players);
                        ClassificaListView.ItemsSource = classifica;
        }
       

    }
}