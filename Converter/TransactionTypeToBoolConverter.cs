using Haushaltsbuch.Model;
using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.Converter
{
    public class TransactionTypeToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool result = (TransactionType)value == TransactionType.Income ? false : true;

            if (parameter != null && parameter.Equals("Invert"))
                return !result;
            else
                return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (parameter != null && parameter.Equals("Invert"))
                return (bool)value ? TransactionType.Income : TransactionType.Expense;
            else
                return (bool)value ? TransactionType.Expense : TransactionType.Income;

        }
    }
}
