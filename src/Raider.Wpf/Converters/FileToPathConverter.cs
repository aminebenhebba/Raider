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
            if (value == null || parameter == null)
            {
                return null;
            }

            var fileName = (string)value;
            
            var fileType = (IconType)parameter;

            // TODO: Probably default to :pepe_finger: icon ;)
            var path = string.Empty;
            switch (fileType)
            {
                case IconType.Class:
                    path = $"/Resources/Classes/{fileName}";
                    break;
                case IconType.Specialisation:
                    path = $"/Resources/Specialisations/{fileName}";
                    break;
                case IconType.Role:
                    path = $"/Resources/Roles/{fileName}";
                    break;
            }

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