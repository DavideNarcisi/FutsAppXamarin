using FutsAppXamarin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FutsAppXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class next : ContentPage
     {
        List<Match> partite;

        public next()
        {
            InitializeComponent();
            partite = new List<Match>(Match.daFare);
            PartiteListView.ItemsSource = partite;
             
             
          

        }
    }
}