using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.Converter
{
    public class DateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((DateTime)value).ToString("d", new CultureInfo("de-DE"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return DateTime.ParseExact((string)value, "dd.MM.yyyy", new CultureInfo("de-DE"));
        }
    }
}
