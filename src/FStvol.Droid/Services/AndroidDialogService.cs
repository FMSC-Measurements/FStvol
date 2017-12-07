using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FStvol.Services;

namespace FStvol.Droid.Services
{
    //TODO class nolonger used
    public class AndroidDialogService : IDialogService
    {
        private const int READ_REQUEST_CODE = 42;

        public string SelectFile()
        { 
           
            Android.App.Activity context = (Android.App.Activity)Android.App.Application.Context;

            var intent = new Android.Content.Intent(Android.Content.Intent.ActionOpenDocument);
            intent.AddCategory(Android.Content.Intent.CategoryOpenable);
            intent.SetType("application/tvol");



            context.StartActivity(intent);
            return null;
        }
    }
}
