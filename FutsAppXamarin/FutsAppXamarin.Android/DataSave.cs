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
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(FutsAppXamarin.Droid.DataSave))]
namespace FutsAppXamarin.Droid
{
    class DataSave : Java.Lang.Object, Model.IDataSave, IOnCompleteListener
    {
        int[] golgioc;
        int segno;
        IList<string> teams;
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
            catch (FirebaseFirestoreException exc)
            {
                exc.PrintStackTrace();
                return false;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.StackTrace);
                return false;
            }

            return true;
        }

        public async Task<int> SaveMatch(int totale_casa, int totale_ospiti, int[] golgiocA, int[] golgiocB, IList<string> teams, string id)
        {
            this.teams = teams;
            
            if (totale_casa > totale_ospiti)
            {
                segno = 1;
            }
            else if (totale_ospiti > totale_casa)
            {
                segno = 2;
            }
            else
                segno = 0;
            golgioc = new int[10];
            golgiocA.CopyTo(golgioc, 0);
            golgiocB.CopyTo(golgioc, 5);
            try
            {
                if (sommaArray(golgiocA) == totale_casa && sommaArray(golgiocB) == totale_ospiti)
                {
                    await FirebaseFirestore.Instance.Collection("partite").Document(id).Update("risultato", totale_casa + "-" + totale_ospiti,
                                                                        "golgioc", new Java.Util.ArrayList(golgioc)).AddOnCompleteListener(this);
                }
                else return 0;
            }catch(FirebaseFirestoreException exc)
            {
                exc.PrintStackTrace();
                return 2;
            }
            return 1;
        }

        private int sommaArray(int[] gol)
        {
            int somma = 0;
            foreach (int i in gol)
                somma += i;
            return somma;
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if(task.IsSuccessful)
            {
                SavePlayer(golgioc, teams, segno);
            }
        }

        private void SavePlayer(int[] golgioc, IList<string> teams, int segno)
        {
            var db = FirebaseFirestore.Instance;
            CollectionReference coll = db.Collection("utenti");
            int index;

            foreach (Giocatore d in Giocatore.amici) //cambiare qui!
            {
                if (teams.Contains(d.username))
                {
                    index = teams.IndexOf(d.username);
                    if ((index < 5 && segno == 1) || ((index > 4 && segno == 2)))
                    {
                        RegistraGiocatore(coll, "vittorie", d, golgioc[index]);
                    }
                    else if (segno == 0)
                    {
                        RegistraGiocatore(coll, "pareggi", d, golgioc[index]);
                    }
                    else
                    {
                        RegistraGiocatore(coll, "sconfitte", d, golgioc[index]);
                    }
                }
            }
        }

        private void RegistraGiocatore(CollectionReference coll, string esito, Giocatore d, int gol)
        {
            Dictionary<string, int> map = new Dictionary<string, int>()
            { 
                {"gol fatti",int.Parse(d.dati["gol fatti"].ToString())},
                { "pareggi", int.Parse(d.dati["pareggi"].ToString())},
                { "partite giocate", int.Parse(d.dati["partite giocate"].ToString())},
                { "vittorie", int.Parse(d.dati["vittorie"].ToString())},
                { "sconfitte", int.Parse(d.dati["sconfitte"].ToString())}               
            };
            
            coll.Document(d.username).Update("gol fatti", ((int)map["gol fatti"] + gol),
                    "partite giocate", ((int)map["partite giocate"] + 1),
                    esito, ((int)map[esito] + 1));
        }
    }
}