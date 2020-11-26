﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace LOTTERIA_Kiosk.View
{
    public class BackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? Brushes.Red : Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
