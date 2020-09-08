using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Gms.Extensions;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(FutsAppXamarin.Droid.DataSave))]
namespace FutsAppXamarin.Droid
{
    class DataSave : Java.Lang.Object, Model.IDataSave
    {
        public DataSave() { }

        public async Task<bool> SetMatch(string luogo, int data, string ora, IList<string> giocatori)
        {
            try
            {
                Java.Util.ArrayList nuovo = new Java.Util.ArrayList();
                foreach (var g in giocatori)
                    nuovo.Add(g);
                

                
                var docRef = Firebase.Firestore.FirebaseFirestore.Instance.Collection("partite").Document();
                Dictionary<string, Java.Lang.Object> map = new Dictionary<string, Java.Lang.Object>();
                map.Add("risultato", docRef.Id);
                map.Add("luogo", luogo);
                map.Add("data", data);
                map.Add("ora", ora);
                map.Add("giocatori", nuovo);
                await docRef.Set(map);                           
            }
            catch(FirebaseFirestoreException exc)
            {
                exc.PrintStackTrace();
                return false;
            }
            catch(Exception err)
            {
                Console.WriteLine(err.StackTrace);
                return false;
            }

            return true;
        }
    }
}