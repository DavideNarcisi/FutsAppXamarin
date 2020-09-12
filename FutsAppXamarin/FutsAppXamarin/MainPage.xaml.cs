using FutsAppXamarin.Model;
using FutsAppXamarin.Popup;
using Rg.Plugins.Popup.Extensions;
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

    public partial class MainPage
    {
        public MainPage()
        {

            InitializeComponent();
            Xamarin.Forms.Application.Current.Properties["firstrun"] = "false";
            Xamarin.Forms.Application.Current.SavePropertiesAsync();
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            tabbed_page.CurrentPage = Children[1];
            SetImmagine();
        }

        private async void SetImmagine()
        {
            foreach (Match m in Match.daFare)
            {
                ImageSource img = await new ImageHelper().LoadImage("milito"); //m.teams[0].ToString()
                if (!img.Equals(null))
                    m.profile_image = img;
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new popup_menu());
        }
    }

}