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


            //use for simple bindings with valueconverter
            //myLabel.SetBinding(Label.TextProperty, "MyAnnoyingInteger", BindingMode.OneWay, myValueConverter);

            //use if you need the converterparameter
            string myConverterParameter = "3";
            Binding myBinding = new Binding("MyAnnoyingInteger", BindingMode.OneWay, myValueConverter, myConverterParameter);
            myLabel.SetBinding(Label.TextProperty, myBinding);
        }
    }
}
