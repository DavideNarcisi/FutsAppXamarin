using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using Java.Interop;
using Java.Util;
using Org.Json;

namespace FutsAppXamarin.Droid
{
    class FriendsLoad : Java.Lang.Object, IOnCompleteListener
    { 
        public FriendsLoad()
        {

        }

    public void CaricaAmici(string username)
    {
            FirebaseFirestore.Instance.Collection("utenti").Document(username).Get().AddOnCompleteListener(this);
    }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            List<Giocatore> listamici = new List<Giocatore>();

            if(task.IsSuccessful)
            {
                var snapshot = (DocumentSnapshot)task.Result;
                var nomi= (System.Collections.IList)snapshot.Get("amici");
             foreach(Giocatore g in Giocatore.players)
                {
                    if (nomi.Contains(g.username))
                        listamici.Add(g);
                }
            }
            Giocatore.amici = listamici.ToArray();
        }
    }
}