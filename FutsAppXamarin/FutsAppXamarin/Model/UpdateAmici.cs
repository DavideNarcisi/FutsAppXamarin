using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FutsAppXamarin.Model
{
    public interface IUpdateAmici
    {
        void UpdateFriends(IList<string> amici, Giocatore user);
    }
    public class UpdateAmici
    {
        UpdateAmici() { }
        private static IUpdateAmici update = DependencyService.Get<IUpdateAmici>();

        public static void UpdateFriends(IList<string> amici, Giocatore user)
        {
            
            update.UpdateFriends(amici, user);
        }

    }
}
