using FutsAppXamarin.Model;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
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
    public partial class popup_partita_giocata : PopupPage
    {
        public popup_partita_giocata(Match match)
        {
            InitializeComponent();

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

            golA0.Text = match.golgioc[0].ToString();
            golA1.Text = match.golgioc[1].ToString();
            golA2.Text = match.golgioc[2].ToString();
            golA3.Text = match.golgioc[3].ToString();
            golA4.Text = match.golgioc[4].ToString();

            golB0.Text = match.golgioc[5].ToString();
            golB1.Text = match.golgioc[6].ToString();
            golB2.Text = match.golgioc[7].ToString();
            golB3.Text = match.golgioc[8].ToString();
            golB4.Text = match.golgioc[9].ToString();

            luogo.Text = match.luogo;
            ora.Text = match.orario;
            data.Text = match.data;
        }

        private void Close(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
        }
    }
}