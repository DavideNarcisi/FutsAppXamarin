using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FutsAppXamarin.Model
{
    public interface IAuth
    {
        Task<string> Login(string E, string P);
        Task<string> Register(string N, string E, string P);
        
        Task<bool> Logout();
      
    }


    public class Auth
    {

        private static IAuth auth = DependencyService.Get<IAuth>();


        public static async Task<string> Register(string N, string E, string P)
        {
            try
            {
                return await auth.Register(N, E, P);
            }
            catch (Exception ex)
            {
                //await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return "";
            }

        }

        public static async Task<string> Login(string E, string P)
        {
            try
            {
                return await auth.Login(E, P);
            }
            catch (Exception ex)
            {
                
                return "";
            }

        }

        public static async Task<bool> Logout()
        {
            try
            {
                return await auth.Logout();

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return false;
            }
        }

       
    }
}
