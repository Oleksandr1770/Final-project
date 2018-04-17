using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Final_project
{
    [ValueConversion(typeof(string), typeof(Brush))]
    public class AgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Brushes.Black;
            int i = int.Parse(value.ToString());
            if (i >= 18)
            {
                return Brushes.Green;
            }
            else if (i < 18)
            {
                return Brushes.Orange;
            }
            else
                return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
