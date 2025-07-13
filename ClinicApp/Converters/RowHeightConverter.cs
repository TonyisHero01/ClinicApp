using System;
using System.Globalization;
using System.Windows.Data;

namespace ClinicApp.Converters
{
    public class RowHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double actualHeight)
            {
                return Math.Max((actualHeight - 80) / 6, 30);
            }
            return 30;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
