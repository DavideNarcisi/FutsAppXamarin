using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FutsAppXamarin.Model
{
    public interface IDataSave
    {
        Task<bool> SetMatch(string luogo, int data, string ora, IList<string> giocatori);
        Task<int> SaveMatch(int totale_casa, int totale_ospiti, int[] golgiocA, int[] golgiocB, IList<string> teams, string id);
    }
    public class DataSave
    {
        private static IDataSave save = DependencyService.Get<IDataSave>();

        public static Task<bool> SetMatch(string luogo, int data, string ora, IList<string> giocatori)
        {
            return save.SetMatch(luogo,data,ora,giocatori);
        }

        public static Task<int> SaveMatch(int totale_casa, int totale_ospiti, int[] golgiocA, int[] golgiocB, IList<string> teams, string id)
        {
            return save.SaveMatch(totale_casa, totale_ospiti, golgiocA, golgiocB, teams, id);
        }

    }
}
