using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Gms.Extensions;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Firebase.Firestore;
using FutsAppXamarin.Model;
using Java.Util;
using Xamarin.Forms;

[assembly: Dependency(typeof(FutsAppXamarin.Droid.DataLoad))]
namespace FutsAppXamarin.Droid
{
    class DataLoad : Java.Lang.Object, Model.IDataLoad, IOnCompleteListener
    {
        string username;
        int hasRead;
        public DataLoad()
        {

        }

        public async Task<bool> LoadMatch(string username)
        {
            hasRead = 0;
            this.username = username;
            Firebase.Firestore.FirebaseFirestore.Instance.Collection("partite")
                .WhereArrayContains("giocatori", username)
                .OrderBy("data",Query.Direction.Ascending).Get().AddOnCompleteListener(this);
            for (int i = 0; i < 25; i++)
            {
                await System.Threading.Tasks.Task.Delay(100);
                if (hasRead != 0)
                    break;
            }
            if (hasRead == 1)
                return true;
            else
                return false;
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            List<Match> giocate = new List<Match>();
            List<Match> dafare = new List<Match>();
            List<Match> daregistrare = new List<Match>();
            Calendar calendario;
            calendario = Calendar.Instance;
            int day = calendario.Get(CalendarField.DayOfMonth);
            int month = calendario.Get(CalendarField.Month) + 1;
            int y = calendario.Get(CalendarField.Year);
            if (task.IsSuccessful)
            {
                var snapshot = (QuerySnapshot)task.Result;
                if (!snapshot.IsEmpty)
                {
                    foreach (var doc in snapshot.Documents)
                    {
                        System.Collections.IList giocatori = (System.Collections.IList)doc.Get("giocatori");
                        Match m = new Match(giocatori, ConvertData((int)(long)doc.Get("data")), doc.Get("ora").ToString(), doc.Get("luogo").ToString(), doc.Get("risultato").ToString());

                        if ((int)(long)doc.Get("data") >= (y * 10000 + (month) * 100 + day))
                            dafare.Add(m);
                        else if (m.teams[0].Equals(username) && m.risultato.Equals(doc.Id))
                            daregistrare.Add(m);
                        else if (!m.risultato.Equals(doc.Id))
                        {
                            m.golgioc = (System.Collections.IList)doc.Get("golgioc");
                            giocate.Add(m);
                        }
                    }
                }
                hasRead = 1;
            }
            else
            {
                Console.WriteLine(task.Exception);
                hasRead = 2;
            }
            Match.daFare = dafare.ToArray();
            Match.giocate = giocate.ToArray();
            Match.daRegistrare = daregistrare.ToArray();
        }
        private String ConvertData(int data)
        {
            int giorno = data % 100;
            int mese = (data - giorno) / 100 % 100;
            int anno = (data - (mese * 100) - giorno) / 10000 % 10000;
            return giorno + "-" + mese + "-" + anno;
        }

    }
}
