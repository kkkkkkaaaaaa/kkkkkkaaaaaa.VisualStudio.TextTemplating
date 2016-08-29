using System;
using System.CodeDom;
using System.Globalization;
using System.Windows.Data;

namespace TextTemplating.Windows.Data
{
    /// <summary>
    /// 
    /// </summary>
    [ValueConversion(typeof(MemberAttributes), typeof(bool))]
    public class MemberAttributesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.Equals(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.Equals(true) ? parameter : Binding.DoNothing;
        }
    }
}