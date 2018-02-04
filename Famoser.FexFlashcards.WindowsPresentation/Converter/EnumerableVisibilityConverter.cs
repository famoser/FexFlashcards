using Famoser.FexFlashcards.WindowsPresentation.Business.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Famoser.FexFlashcards.WindowsPresentation.Converter
{
    class EnumerableVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = value as FlashCardCollectionModel;
            
            return val != null && val.FlashCardModels.Any(d => d.IsNew) ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
