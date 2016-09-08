using System;
using System.Globalization;
using Xamarin.Forms;

namespace UsingValueConverters
{
    public class MultiplyIntValueConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int multiplicator = 10;
            int outgoingInteger = (int)value;
            return outgoingInteger * multiplicator;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int divisor = 10;
            int outgoingInteger = (int)value;
            return outgoingInteger / divisor;
        }
    }
}
