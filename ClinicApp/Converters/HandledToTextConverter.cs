using System;
using System.Globalization;
using System.Windows.Data;

namespace ClinicApp.Converters
{
    public class HandledToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "Handled" : "Unhandled";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
