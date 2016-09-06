using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomComponent2
{
    public partial class MainPage : ContentPage
    {
        private IPersonViewModel personViewModel;

        public MainPage(IPersonViewModel personViewModel)
        {
            this.personViewModel = personViewModel;

            BindingContext = personViewModel;

            InitializeComponent();
            NewView newView = new NewView();

            newView.SetBinding(NewView.FirstNameProperty, "FirstName");
            newView.SetBinding(NewView.LastNameProperty, "LastName");

            myLayout.Children.Add(newView);
        }
    }
}
