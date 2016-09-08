using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ValueConverter
{
    public partial class MainPage : ContentPage
    {
        int someAnnoyingInteger = 5;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            MultiplyTenValueConverter myValueConverter = new MultiplyTenValueConverter();
            myLabel.SetBinding(Label.TextProperty, "SomeAnnoyingInteger", BindingMode.OneWay, myValueConverter);
        }

        public int SomeAnnoyingInteger
        {
            get
            {
                return someAnnoyingInteger;
            }
            set
            {
                this.someAnnoyingInteger = value;
            }
        }
    }
}
