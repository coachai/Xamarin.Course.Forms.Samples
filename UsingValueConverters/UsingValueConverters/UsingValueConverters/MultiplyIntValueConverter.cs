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
            if (parameter != null)
            {
                multiplicator = Int32.Parse((string)parameter);
            }
            int outgoingInteger = (int)value;
            return outgoingInteger * multiplicator;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int divisor = 10;
            if (parameter != null)
            {
                divisor = Int32.Parse((string)parameter);
            }
            int outgoingInteger = (int)value;
            return outgoingInteger / divisor;
        }
    }
}
