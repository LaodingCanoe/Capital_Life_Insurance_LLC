﻿using System;
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
            // Compare value and parameter, return true if they are equal
            return value != null && value.Equals(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Return the parameter if the value is true, otherwise return Binding.DoNothing
            return value != null && (bool)value ? parameter : Binding.DoNothing;
        }
    }

}