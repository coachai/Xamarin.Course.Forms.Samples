﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace NavigationPageExample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var tabbedPage = new TabbedPage();
            var firstNavigationPage = new NavigationPage();
            var secondNavigationPage = new NavigationPage();

            tabbedPage.Children.Add(firstNavigationPage);
            tabbedPage.Children.Add(secondNavigationPage);

            var page1 = new Page1();

            /*var navPage = new NavigationPage();
            var page1 = new Page1();
            navPage.PushAsync(page1);
            MainPage = navPage;
            /*
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
