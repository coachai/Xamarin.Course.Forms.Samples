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

            InitializeComponent();

            myListView.ItemsSource = personViewModel.AllPersons;

            #region Magic
            BindingContext = personViewModel;
            
            var newViewDataTemplate = new DataTemplate(typeof(NewView));
            newViewDataTemplate.SetBinding(NewView.FirstNameProperty, "FirstName");
            newViewDataTemplate.SetBinding(NewView.LastNameProperty, "LastName");
            newViewDataTemplate.SetBinding(NewView.ImagePathProperty, "ImagePath");
            myListView.ItemTemplate = newViewDataTemplate;
            
            #endregion
        }
    }
}
