using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CustomComponent2
{
    public partial class NewView : StackLayout
    {
        #region Bindable Properties
        public static BindableProperty FirstNameProperty = BindableProperty.Create(
            propertyName: "FirstName",
            returnType: typeof(string),
            declaringType: typeof(NewView),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: HandleFirstNameChanged);

        public static BindableProperty LastNameProperty = BindableProperty.Create(
            propertyName: "LastName",
            returnType: typeof(string),
            declaringType: typeof(NewView),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: HandleLastNameChanged);
        #endregion



        #region Handlers
        private static void HandleFirstNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var newView = (NewView)bindable;
            newView.firstName.Text = (string)newValue;
        }

        private static void HandleLastNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var newView = (NewView)bindable;
            newView.lastName.Text = (string)newValue;
        }
        #endregion

        #region Properties
        public string FirstName
        {
            get
            {
                return (string)GetValue(FirstNameProperty);
            }
            set
            {
                SetValue(FirstNameProperty, value);
            }
        }

        public string LastName
        {
            get
            {
                return (string)GetValue(LastNameProperty);
            }
            set
            {
                SetValue(LastNameProperty, value);
            }
        }
        #endregion

        public NewView()
        {
            InitializeComponent();
        }
    }
}
