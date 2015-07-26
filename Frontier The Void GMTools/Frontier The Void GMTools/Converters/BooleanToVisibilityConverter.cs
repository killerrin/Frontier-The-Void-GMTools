using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Frontier_The_Void_GMTools.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string b = ((string)value);
            if (b == "true" || b == "True" || b == "TRUE")
                return Visibility.Visible;
            else if (b == "false" || b == "False" || b == "FALSE")
                return Visibility.Collapsed;

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility v = ((Visibility)value);

            if (v == Visibility.Visible) return true;
            else if (v == Visibility.Collapsed) return false;
            return true;
        }
    }
}
