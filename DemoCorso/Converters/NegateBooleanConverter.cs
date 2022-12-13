using System;
using System.Globalization;
using System.Windows.Data;

namespace DemoCorso.Converters;

public class NegateBooleanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var result = !(bool)value;
        return result;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var result = !(bool)value;
        return result;
    }
}
