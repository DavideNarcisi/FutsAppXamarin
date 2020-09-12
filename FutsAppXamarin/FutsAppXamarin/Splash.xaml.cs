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
    public partial class Splash : ContentPage
    {
        string user;
        public Splash()
        {
            InitializeComponent();            
            user = Application.Current.Properties["username"].ToString();
            Load();
        }

        public async void Load()
        {
            if (!(await UserLoad.LoadUser(user) && await DataLoad.LoadMatch(user)))
            {
                await DisplayAlert("ERRORE", "Connessione debole o assente", "CHIUDI APP");
                Navigation.PopAsync();
            }

            else
            {
                Application.Current.MainPage = new NavigationPage(new MainPage());
                Navigation.RemovePage(this);
               
            }
        }
    }
}