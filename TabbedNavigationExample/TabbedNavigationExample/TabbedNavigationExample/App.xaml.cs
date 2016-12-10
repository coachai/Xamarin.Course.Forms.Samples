using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TabbedNavigationExample
{
    public partial class App : Application
    {
        private TabbedPage myTabbedPage = new TabbedPage();
        private NavigationPage navigationPageForNumbers = new NavigationPage();
        private NavigationPage navigationPageForLetters = new NavigationPage();

        public App()
        {
            InitializeComponent();
            MainPage = myTabbedPage;

            navigationPageForLetters.Title = "Nav for Letters";
            navigationPageForNumbers.Title = "Nav for Numbers";

            //constructors cannot be async, hence we do first push pages to the
            //navigationstack in the OnStart method that _can_ be modified to be async
        }

        //Note that OnStart was modified to be async.
        protected override async void OnStart()
        {
            var page1 = new Page1();
            var pageA = new PageA();
            await navigationPageForNumbers.PushAsync(page1);
            await navigationPageForLetters.PushAsync(pageA);

            myTabbedPage.Children.Add(navigationPageForLetters);
            myTabbedPage.Children.Add(navigationPageForNumbers);
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
