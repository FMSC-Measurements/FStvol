using Android.App;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using FStvol.Droid.Services;

namespace FStvol.Droid.Activities
{
    [Activity(Label = "FStvol", MainLauncher = true, Icon = "@drawable/LauncherIcon")]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);

            FStvol.App.DialogService = new AndroidDialogService();
            FStvol.App.FileSystemService = new AndroidFileSystemService();
            FStvol.App.AlertService = new AndroidAlertService();

            var app = new App();

            LoadApplication(app);
        }
    }
}

