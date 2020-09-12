using Android.Content;
using Android.Support.V4.Content.Res;
using FutsAppXamarin;
using FutsAppXamarin.Model;
using FutsAppXamarin.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyAndroidEntry))]
namespace FutsAppXamarin.Droid
{
 public class MyAndroidEntry:EntryRenderer
 {
   public MyAndroidEntry(Context context):base(context)
    {

    }

    protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
    {
        base.OnElementChanged(e);

        if(Control!=null)
        {
            Control.SetBackground(ResourcesCompat.GetDrawable(Resources, Resource.Drawable.edit_text_style, null) );
        }

    }
  }
}