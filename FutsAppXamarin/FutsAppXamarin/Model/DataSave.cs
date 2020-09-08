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
    }
    public class DataSave
    {
        private static IDataSave save = DependencyService.Get<IDataSave>();

        public static Task<bool> SetMatch(string luogo, int data, string ora, IList<string> giocatori)
        {
            return save.SetMatch(luogo,data,ora,giocatori);
        }
    }
}
