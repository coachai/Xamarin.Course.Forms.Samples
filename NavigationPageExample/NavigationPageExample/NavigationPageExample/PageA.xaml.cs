using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NavigationPageExample
{
    public partial class PageA : ContentPage
    {
        public PageA()
        {
            InitializeComponent();
           
        }

        private async void PopToRoot(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
