using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Counter.UI
{
    [ValueConversion(typeof(int), typeof(string))]
    public class IntToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }
            else
            {
                return value.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str &&
                int.TryParse(str, out int result))
            {
                return result;
            }

            return value;
        }
    }
}

