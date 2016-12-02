using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NavigationPageExample
{
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private async void PushPage2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page2());
        }
    }
}
