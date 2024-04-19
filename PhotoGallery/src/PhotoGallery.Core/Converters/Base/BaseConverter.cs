using System;
using System.Globalization;
using Xamarin.Forms;

namespace PhotoGallery.Core.Converters.Base
{
    /// <summary>
    /// Base class converter
    /// </summary>
    public abstract class BaseConverter : IValueConverter
    {
        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="targetType">Target type</param>
        /// <param name="parameter">Parameter</param>
        /// <param name="culture">Culture</param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// Convert back
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="targetType">System Type</param>
        /// <param name="parameter">Parameter</param>
        /// <param name="culture">Culture</param>
        /// <returns>Input value</returns>
        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
    }
}