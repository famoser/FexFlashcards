using System;
using System.Globalization;
using System.Windows.Data;

namespace Famoser.FexFlashcards.WindowsPresentation.Converter
{
    class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dataTime = (DateTime) value;
            return dataTime.ToShortDateString() + " " + dataTime.ToShortDateString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
