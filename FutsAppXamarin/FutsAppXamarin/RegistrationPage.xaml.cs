using FutsAppXamarin.Model;
using FutsAppXamarin.Pages;
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
    public partial class RegistrationPage : ContentPage
    {
        
        public RegistrationPage()
        {
            
            InitializeComponent();

        }

        public async void Btn_Registra_Clicked(object sender, System.EventArgs e)
        {
            if (username.Text.Length == 0 || txtMail.Text.Length == 0 || txtPass.Text.Length == 0)
                await DisplayAlert("Registrazione Fallita", "Riempire tutti i campi.", "OK");
            else
            {
                string result = await Auth.Register(username.Text, txtMail.Text, txtPass.Text);
                if (!(result.Equals("")))
                {
                    if (!result.Equals("userdoppio"))
                    {
                        Application.Current.MainPage = new Splash();
                        Navigation.RemovePage(this);
                    }
                    else
                        await DisplayAlert("Registrazione Fallita", "Username già scelto", "OK");
                }
                else
                    await DisplayAlert("Registrazione Fallita", "Riprova per favore", "OK");
            }
        }
    }
}