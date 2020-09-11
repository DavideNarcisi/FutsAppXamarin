using FutsAppXamarin.Model;
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
    }
}