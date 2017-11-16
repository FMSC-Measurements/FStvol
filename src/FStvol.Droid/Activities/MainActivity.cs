using Android.App;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using FStvol.Droid.Services;

namespace FStvol.Droid.Activities
{
    [Activity(Label = "FStvol.Droid", MainLauncher = true)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);

            FStvol.App.DialogService = new AndroidDialogService();
            FStvol.App.FileSystemService = new AndroidFileSystemService();

            var app = new App();
            

            LoadApplication(app);
        }
    }
}

