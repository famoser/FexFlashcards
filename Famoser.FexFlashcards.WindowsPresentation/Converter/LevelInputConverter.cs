using System;
using System.Globalization;
using System.Windows.Data;

namespace Famoser.FexFlashcards.WindowsPresentation.Converter
{
    class StringIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = value as string;
            if (int.TryParse(val, out int result))
            {
                return result;
            }
            return 0;
        }
    }
}
