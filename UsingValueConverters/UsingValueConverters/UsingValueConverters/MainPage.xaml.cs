using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UsingValueConverters
{
    public partial class MainPage : ContentPage
    {
        private int myAnnoyingInteger = 5;
        private MultiplyIntValueConverter myValueConverter = new MultiplyIntValueConverter();

        public int MyAnnoyingInteger
        {
            get
            {
                return myAnnoyingInteger;
            }
            set
            {
                myAnnoyingInteger = value;
            }
        }



        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            myLabel.SetBinding(Label.TextProperty, "MyAnnoyingInteger", BindingMode.OneWay);
        }
    }
}
