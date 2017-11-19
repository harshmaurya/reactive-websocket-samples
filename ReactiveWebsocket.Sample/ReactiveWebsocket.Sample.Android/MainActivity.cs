using Android.App;
using Android.Content.PM;
using Android.OS;
using ReactiveWebsocket.Model;
using ReactiveWebsocket.Public;
using ReactiveWebsocket.Samples.SharedViews;

namespace ReactiveWebsocket.Sample.Droid
{
    [Activity(Label = "ReactiveWebsocket.Sample", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);

            //This is all you need to do in android project
            WebsocketInitializer.SetPlatform(PlatformName.Android);

            LoadApplication(new App());
        }
    }
}

