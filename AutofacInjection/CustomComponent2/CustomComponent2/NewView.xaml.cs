using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CustomComponent2
{
    public partial class NewView : ViewCell
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

        public static BindableProperty ImagePathProperty = BindableProperty.Create(
            propertyName: "ImagePath",
            returnType: typeof(string),
            declaringType: typeof(NewView),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: HandleImagePathChanged);
        #endregion



        #region Handlers
        private static void HandleFirstNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var newView = (NewView)bindable;
            newView.firstNameLabel.Text = (string)newValue;
        }

        private static void HandleLastNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var newView = (NewView)bindable;
            newView.lastNameLabel.Text = (string)newValue;
        }

        private static void HandleImagePathChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var newView = (NewView)bindable;
            newView.myImage.Source = ImageSource.FromFile((string)newValue);
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

        public string ImagePath
        {
            get
            {
                return (string)GetValue(ImagePathProperty);
            }
            set
            {
                SetValue(ImagePathProperty, value);
            }
        }


        #endregion

        public NewView()
        {
            InitializeComponent();
        }
    }
}
