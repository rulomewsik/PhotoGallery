using System;
using System.Collections;
using System.Globalization;
using MvvmCross.Binding.Extensions;
using PhotoGallery.Core.Converters.Base;

namespace PhotoGallery.Core.Converters
{
    /// <summary>
    ///     Is null or empty value
    /// </summary>
    public class IsNullOrEmptyConverter : BaseConverter
    {
        /// <summary>
        ///     Is Null or empty value
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="targetType">Target type</param>
        /// <param name="parameter">Parameter</param>
        /// <param name="culture">Culture</param>
        /// <returns>If value is null</returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                null => true,
                IEnumerable enumerable => enumerable.Count() == 0,
                _ => false
            };
        }
    }
}