using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Gms.Tasks;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Firebase.Firestore;
using Android.Gms.Extensions;
using Xamarin.Forms;
using System.Threading.Tasks;

[assembly: Dependency(typeof(FutsAppXamarin.Droid.UserLoad))]

namespace FutsAppXamarin.Droid
{
    class UserLoad : Java.Lang.Object, Model.IUserLoad, IOnCompleteListener
    {
        string username;
        int hasRead;
        
        public UserLoad()
        {

        }

        public async Task<bool> LoadUser(string username)
        {
            hasRead = 0;
            this.username = username;
            FirebaseFirestore.Instance.Collection("utenti").Get().AddOnCompleteListener(this);
            for (int i = 0; i < 25; i++)
            {
                await System.Threading.Tasks.Task.Delay(100);
                if (hasRead!=0)
                    break;
            }
            if (hasRead == 1)
                return true;
            else
                return false;
            
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            List<Giocatore> lista = new List<Giocatore>();

            if (task.IsSuccessful)
            {
                var snapshot = (QuerySnapshot)task.Result;
                if (!snapshot.IsEmpty)
                {
                    foreach (var doc in snapshot.Documents)
                    {
                        Dictionary<string, object> map = new Dictionary<string, object>
                        {
                            {"gol fatti",(int) (long) doc.Get("gol fatti") },
                            { "pareggi", (int) (long) doc.Get("pareggi")},
                            { "partite giocate", (int) (long) doc.Get("partite giocate")},
                            { "vittorie", (int) (long) doc.Get("vittorie")},
                            { "sconfitte", (int) (long) doc.Get("sconfitte")},
                            { "amici", doc.Get("amici")}
                        };
                        Giocatore g = new Giocatore(doc.Get("username").ToString(), map);
                        lista.Add(g);
                        if (doc.Get("username").Equals(username))
                            Giocatore.user = g;
                    }
                }
                hasRead = 1;
            }
            else
            {
                Console.WriteLine(task.Exception);
                hasRead = 2;
            }

            Giocatore.players = lista.ToArray();
            new FriendsLoad().CaricaAmici(username);
        }
    }
}