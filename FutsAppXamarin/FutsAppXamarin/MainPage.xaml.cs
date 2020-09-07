using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace FutsAppXamarin
{
    
    public partial class MainPage: MasterDetailPage
    {
        public MainPage()
        {
            
            InitializeComponent();
            Xamarin.Forms.Application.Current.Properties["firstrun"] = "false";
            Xamarin.Forms.Application.Current.SavePropertiesAsync();
            
        }

       
    }

}