using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.App;
using Android.Runtime;


using CustomRendererExample;
using CustomRendererExample.Droid;

using Java.Text;

//Must export the ExtendedTimePicker in the PCL AND the ExtendedTimePickerRenderer given below.
[assembly: ExportRenderer(typeof(ExtendedTimePicker), typeof(ExtendedTimePickerRenderer))]

namespace CustomRendererExample.Droid
{
    public class ExtendedTimePickerRenderer : Xamarin.Forms.Platform.Android.TimePickerRenderer, TimePickerDialog.IOnTimeSetListener
    {
        private TimePickerDialog dialog = null;

        //Is called when the visual elements physical properties are changed (instantiation, screenrotation, resizing etc.)
        //It is the usual place to setup stuff.
        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.TimePicker> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                this.SetNativeControl(new Android.Widget.EditText(Forms.Context));
            }

            if (e.OldElement != null)
            {
                this.Control.Click -= Control_Click; //Upon click show the timepicker
                this.Control.FocusChange -= Control_FocusChange; //React to broadcast Focuschanges.
            }

            if (e.NewElement != null)
            {
                this.Control.Click += Control_Click; //Upon click show the timepicker
                this.Control.FocusChange += Control_FocusChange; //React to broadcast Focuschanges.

                TimeSpan newTime = e.NewElement.Time; //Get current time from Xamarin.Forms
                this.Control.Text = GetTimeAsString(newTime); //Set default time value
            }

            this.Control.KeyListener = null; //Turn off keylistening. User may not write in the EditText.
        }

        //Fired whenever properties of Xamarin.Forms element behind is changed.
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(Xamarin.Forms.TimePicker.TimeProperty.PropertyName))
            {
                var timeSpan = this.Element.Time;
                this.Control.Text = GetTimeAsString(timeSpan);
                //Appearently Xamarin Controls does (usually) not retain focused when their task is done.
                //Nor does the original TimePicker
                this.Control.ClearFocus();
            }
        }

        void Control_FocusChange(object sender, Android.Views.View.FocusChangeEventArgs e)
        {
            if (e.HasFocus)
                ShowTimePicker();
        }

        void Control_Click(object sender, EventArgs e)
        {
            ShowTimePicker();
        }

        private void ShowTimePicker()
        {
            if (dialog == null)
            {
                //Construct dialog with initial values for now, set for 12h or 24h format.

                dialog = new TimePickerDialog(Forms.Context, this,
                    Element.Time.Hours, Element.Time.Minutes,
                    Is24hFormat());
            }
            dialog.Show();
        }

        //Fired whenever the TimePicker changes value.
        public void OnTimeSet(Android.Widget.TimePicker view, int hourOfDay, int minute)
        {
            //change Element value for binding purposes (also causes triggering of OnElementPropertyChanged)
            var timeSpan = new TimeSpan(hourOfDay, minute, 0);

            //Though we could set Element values like this: this.Element.SetValue(Xamarin.Forms.TimePicker.TimeProperty, timeSpan);
            //And virtually alle simple examples works like that, it is frowned upon as it can break OneWay-bindings.
            //An alternative was therefore implemented in later Xamarin versions which is especially designed for this situation:
            ((IElementController)Element).SetValueFromRenderer(Xamarin.Forms.TimePicker.TimeProperty, timeSpan);
        }

        #region HelperMethods
        private string GetTimeAsString(TimeSpan timeSpan)
        {
            //Android does not natively have the 'TimeSpan', and therefore does not supply
            //string-formatting for them. In order to prettyprint the format on the TextEdit, we have to
            //create a DateTime, which can be formatted using standard Android formatting.

            DateTime dateTime = DateTime.Today.Add(timeSpan);
            //DOC: This only works because DateTime.Add does not take DST into account and DateTime does not throw
            //errors for non-existant times (such as 27-03-2016 02:30 in the central european timezone CET,
            //due to the clock moving from 02:00 -> 03:00 that night).
            return dateTime.ToString(GetShortTimeFormat());
        }

        public string GetShortTimeFormat()
        {
            var ctx = Forms.Context;
            var timeFormat = Android.Text.Format.DateFormat.GetTimeFormat(ctx);
            string timef = ((SimpleDateFormat)timeFormat).ToLocalizedPattern();
            return timef.Replace("a", "tt"); //c# and android format differes in java using 'a' for AM/PM and C# using "tt";
        }

        public bool Is24hFormat()
        {
            var format = GetShortTimeFormat();
            return format.StartsWith("H"); //valid 24h formats are H and HH, depending if we want prepended zero for <10h or not.
        }
        #endregion
    }
}