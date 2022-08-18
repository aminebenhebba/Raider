using System;
using System.Globalization;
using System.Windows.Data;
using System.IO;

namespace Raider.Wpf.Converters
{
    public class FileToPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            var fileName = (string)value;
            var path = $"/Resources/Classes/{fileName}";
            return path;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            var path = (string)value;
            var fileName = Path.GetFileName(path);
            return fileName;
        }
    }
}