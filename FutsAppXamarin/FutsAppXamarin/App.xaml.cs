using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FutsAppXamarin.Pages;

namespace FutsAppXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (Application.Current.Properties.ContainsKey("firstrun"))
            {
                if (Application.Current.Properties["firstrun"].ToString().Equals("false"))
                {
                    Console.WriteLine("si first");
                    MainPage = new NavigationPage(new MainPage());
                }
                else
                {
                    Console.WriteLine("si ma no first");
                    MainPage = new LoginPage();
                }

            }
            else
            {
                Console.WriteLine("no first");
                MainPage = new LoginPage();
            }
               
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
