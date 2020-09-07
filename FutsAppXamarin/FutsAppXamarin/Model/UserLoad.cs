using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FutsAppXamarin.Model
{
    public interface IUserLoad
    {
        Task<bool> LoadUser(string username);
    }
    class UserLoad
    {
        private static IUserLoad load = DependencyService.Get<IUserLoad>();

        public static Task<bool> LoadUser(string username)
        {
            return load.LoadUser(username);

        }
    }
}
