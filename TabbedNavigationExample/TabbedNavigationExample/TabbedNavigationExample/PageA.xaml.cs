﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TabbedNavigationExample
{
    public partial class PageA : ContentPage
    {
        public PageA()
        {
            InitializeComponent();
        }

        private async void OnClicked(object sender, EventArgs e)
        {
            var pageB = new PageB();
            await Navigation.PushAsync(pageB);
        }
    }
}
