using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Capital_Life_Insurance_LLC
{
    public class EqualityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int selectedAnswer = System.Convert.ToInt32(value);
            int targetValue = System.Convert.ToInt32(parameter);
            return selectedAnswer == targetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return System.Convert.ToInt32(parameter);
            }
            return null;
        }
    }
}