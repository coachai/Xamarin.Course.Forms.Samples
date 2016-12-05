using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NavigationPageExample
{
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
        }

        private async void PopPage2(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void PushTabbedAB(object sender, EventArgs e)
        {
            var tabbedPage = new TabbedPage();
            var pageA = new PageA();
            var pageB = new PageB();
            tabbedPage.Children.Add(pageA);
            tabbedPage.Children.Add(pageB);

            await Navigation.PushAsync(tabbedPage);
        }
    }
}
