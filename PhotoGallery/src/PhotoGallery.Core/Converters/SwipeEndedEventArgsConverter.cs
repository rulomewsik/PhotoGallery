using System;
using System.Globalization;
using Xamarin.Forms;

namespace PhotoGallery.Core.Converters
{
    public class SwipeEndedEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventArgs = value as Syncfusion.ListView.XForms.SwipeEndedEventArgs;
            return eventArgs?.ItemData;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}