using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace WeatherApp
{
    public partial class MyWeatherPage : ContentPage
    {

        private ViewModel myViewModel;

        public MyWeatherPage(ViewModel viewModel)
        {
            InitializeComponent();
            this.myViewModel = viewModel;
            BindingContext = myViewModel.CurrentWeather;
        }

        private async void OnTapped(object sender, EventArgs e)
        {
            await myViewModel.UpdateAllWeather();
            BindingContext = myViewModel.CurrentWeather;
        }
    }
}
