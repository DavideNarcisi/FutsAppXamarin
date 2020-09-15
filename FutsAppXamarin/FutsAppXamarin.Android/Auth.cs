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
    public class Auth : Java.Lang.Object,FutsAppXamarin.Model.IAuth,IOnCompleteListener
    {
        bool presente=false;
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
                var result = await RegisterUser(N);
                if (result == 1)
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
                else if (result == 0)
                    return "userdoppio";
                else return "";
            }
            catch (Exception err)
            {
                Console.WriteLine(err.StackTrace);
                return "";
            }

        }

        private async Task<int> RegisterUser(string user)
        {
            Dictionary<string, Java.Lang.Object> map = new Dictionary<string, Java.Lang.Object>();
            
                Java.Util.ArrayList amici = new Java.Util.ArrayList();
                amici.Add(user);
                
                map.Add("username", user);
                map.Add("partite giocate", 0);
                map.Add("vittorie", 0);
                map.Add("pareggi", 0);
                map.Add("sconfitte", 0);
                map.Add("gol fatti", 0);
                map.Add("amici", amici);

            await FirebaseFirestore.Instance.Collection("utenti").WhereEqualTo("username",user).Get().AddOnCompleteListener(this);
            
            if (!presente)
            {
                try
                {
                    
                    await Firebase.Firestore.FirebaseFirestore.Instance.Collection("utenti").Document(user).Set(map);
                }
                catch (FirebaseFirestoreException exc)
                {
                    exc.PrintStackTrace();
                    
                    return 2;
                }
            }
            else return 0;

            return 1;
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                var snapshot = (QuerySnapshot)task.Result;
                if (!snapshot.IsEmpty)
                {
                    presente = true;
                    
                }
                else
                {
                    presente = false;
                   
                }
            }
        }
    }
}
