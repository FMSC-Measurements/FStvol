using Android.Widget;
using FStvol.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FStvol.Droid.Services
{
    public class AndroidAlertService : IAlertService
    {
        public void ShowAlert(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }
    }
}
