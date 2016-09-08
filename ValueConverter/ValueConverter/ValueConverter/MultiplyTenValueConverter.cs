using System;
using System.Globalization;
using Xamarin.Forms;

namespace ValueConverter
{
    public class MultiplyTenValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int outgoingInt = (int)value;
            return outgoingInt * 10;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int incomingInt = (int)value;
            return incomingInt / 10;
        }
    }
}
