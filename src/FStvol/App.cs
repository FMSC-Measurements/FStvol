﻿using FStvol.Pages;
using FStvol.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FStvol
{
    public class App : Application
    {
        public static IDialogService DialogService { get; set; }
        public static IFileSystemService FileSystemService { get; set; }
        public static IAlertService AlertService { get; set; }


        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new MainPage());



        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
