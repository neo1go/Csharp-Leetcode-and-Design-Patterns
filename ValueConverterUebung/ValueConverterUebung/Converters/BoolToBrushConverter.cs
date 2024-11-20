using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ValueConverterUebung.Converters
{
    public class BoolToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            

            var onlineCheck = (bool)value;
            if (onlineCheck == true)
            {
                return Brushes.Green;
            }
            else
            {
                return Brushes.Red;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            

            var onlineCheck = (bool)value;
            if (onlineCheck != true)
            {
                return Brushes.Red;
            }
            else
            {
                return Brushes.Green;
            }
        }
    }
}
