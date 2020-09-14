using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Extensions;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

[assembly: Dependency(typeof(FutsAppXamarin.Droid.UpdateAmici))]

namespace FutsAppXamarin.Droid
{
     
    
    class UpdateAmici : Model.IUpdateAmici
    {
        public UpdateAmici()
        {

        }

        public async void UpdateFriends(IList<string> amici, Giocatore user)
        {
            if (amici.Contains(Giocatore.user.username))
                amici.Remove(Giocatore.user.username);
            else
                amici.Add(Giocatore.user.username);
            Java.Util.ArrayList nuovo = new Java.Util.ArrayList();
            foreach (var a in amici)
             nuovo.Add(a);
                        
            await FirebaseFirestore.Instance.Collection("utenti").Document(user.username).Update("amici", nuovo);
            Giocatore.players[Giocatore.players.IndexOf(user)].setAmici((List<string>)amici);
            
        }


    }
}