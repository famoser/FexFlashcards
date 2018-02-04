using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Famoser.FexFlashcards.WindowsPresentation.Converter
{
    class PathToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var path = value as string;
            if (!string.IsNullOrEmpty(path))
            {
                return path.Split(new[] { " → " }, StringSplitOptions.RemoveEmptyEntries).Aggregate((current, next) => current + "\n" + next);
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
