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

[assembly: Dependency(typeof(FutsAppXamarin.Droid.UserLoad))]

namespace FutsAppXamarin.Droid
{
     
    
    class UpdateAmici : Java.Lang.Object, Model.IUpdateAmici
    {
        public UpdateAmici()
        {

        }

        public async void UpdateFriends(IList<string> amici, string user)
        {
            Java.Util.ArrayList nuovo = new Java.Util.ArrayList();
            foreach (var a in amici)
                nuovo.Add(a);
            await FirebaseFirestore.Instance.Collection("utenti").Document(user).Update("amici", nuovo);
        }


    }
}