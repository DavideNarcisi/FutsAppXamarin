using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FutsAppXamarin.Model
{
    public interface IDataLoad
    {
        Task<bool> LoadMatch(string username);
    }

    public class DataLoad
    {
        private static IDataLoad load = DependencyService.Get<IDataLoad>();

        public static Task<bool> LoadMatch(string username)
        {
            return load.LoadMatch(username);
        }
    }
}
