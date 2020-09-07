using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

using Firebase.Auth;
using Firebase.Firestore;
using Xamarin.Forms;
using Android.Gms.Tasks;
using Android.Gms.Extensions;
using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(FutsAppXamarin.Droid.Auth))]
namespace FutsAppXamarin.Droid
{
    public class Auth : FutsAppXamarin.Model.IAuth
    {
        
        public Auth()
        {
        }
        public async Task<string> Login(string E, string P)
        {          
            try
            {

                 var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(E, P);
                 var token = await user.User.GetIdTokenAsync(false);
                 Application.Current.Properties["username"] = FirebaseAuth.Instance.CurrentUser.DisplayName;
                 await Application.Current.SavePropertiesAsync();
                return token.Token;
            }
            catch (FirebaseAuthInvalidUserException notFound)
            {
       
                notFound.PrintStackTrace();              
                return "";


            }
            catch (Exception err)
            {
                Console.WriteLine(err.StackTrace);
                return "";
            }

            
        }

       
     
    



public async Task<bool> Logout()
        {
            try
            {
                Firebase.Auth.FirebaseAuth.Instance.SignOut();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }
  
       
        public async Task<string> Register(string N, string E, string P) 
        {
            try
            {
                var create = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(E, P);
                var profileUpdates = new Firebase.Auth.UserProfileChangeRequest.Builder().SetDisplayName(N);
                profileUpdates.SetDisplayName(N);
                var build = profileUpdates.Build();

                var user = Firebase.Auth.FirebaseAuth.Instance.CurrentUser;
                await user.UpdateProfileAsync(build);
                var token = await create.User.GetIdTokenAsync(false);
                Application.Current.Properties["username"] = N;
                await Application.Current.SavePropertiesAsync();
                return token.Token;

            }
            catch (Exception err)
            {
                Console.WriteLine(err.StackTrace);
                return "";
            }

        }


    }
}
