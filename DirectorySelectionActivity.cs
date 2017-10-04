using System;
using Android.OS;
using Android.Support.V4.App;
using Android.App;

namespace FS_AddVolAndroid
{
	[Activity (Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon")]

	public class DirectorySelectionActivity : FragmentActivity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.activity_directory_selection);
			if (savedInstanceState == null) {
				SupportFragmentManager.BeginTransaction ()
					.Add (Resource.Id.container, DirectorySelectionFragment.NewInstance ())
					.Commit ();
			}
		}
	}
}

