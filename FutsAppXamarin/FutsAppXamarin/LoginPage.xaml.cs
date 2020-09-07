using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FutsAppXamarin.ViewModels;
using FutsAppXamarin.Model;

namespace FutsAppXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            Console.WriteLine("iiiiiiiiiiiiiiiiiiiiiii");
            InitializeComponent();
        }

        public async void btn_Log(object sender, System.EventArgs e)
        {
            if (!(await Auth.Login(Email.Text, Password.Text)).Equals(""))
            {
                Application.Current.MainPage= new NavigationPage(new MainPage());
                Navigation.RemovePage(this);
            }
            else
                await DisplayAlert("Registrazione Fallita", "Riprova per favore", "OK");
        }

        public async void btn_Reg(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
            Navigation.RemovePage(this);
        }
    }
}