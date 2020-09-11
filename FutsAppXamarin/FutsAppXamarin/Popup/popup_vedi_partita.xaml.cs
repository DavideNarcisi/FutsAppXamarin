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
    public partial class popup_vedi_partita : PopupPage
    {
        public popup_vedi_partita(Match match)
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