using System;
using System.Globalization;
using PhotoGallery.Core.Converters.Base;

namespace PhotoGallery.Core.Converters
{
    /// <summary>
    /// Inverse bool value
    /// </summary>
    public class InverseBoolConverter : BaseConverter
    {
        /// <summary>
        /// Inverse boolean value
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="targetType">Target type</param>
        /// <param name="parameter">Parameter</param>
        /// <param name="culture">Culture</param>
        /// <returns>Inversed value</returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b)
                return !b;

            throw new ArgumentException("Not boolean value", nameof(value));
        }
    }
}