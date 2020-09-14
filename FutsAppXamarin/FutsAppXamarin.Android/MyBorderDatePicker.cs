using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content.Res;
using Android.Views;
using Android.Widget;
using FutsAppXamarin.Droid;
using FutsAppXamarin.Model;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyDatePicker), typeof(MyBorderDatePicker))]
namespace FutsAppXamarin.Droid
{


    class MyBorderDatePicker : DatePickerRenderer
    {
        public MyBorderDatePicker(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackground(ResourcesCompat.GetDrawable(Resources, Resource.Drawable.border_text, null));
            }

        }
    }
}