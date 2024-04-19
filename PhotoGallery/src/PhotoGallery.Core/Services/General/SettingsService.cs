using PhotoGallery.Core.Contracts.Services.General;
using Xamarin.Essentials;

namespace PhotoGallery.Core.Services.General
{
    /// <summary>
    /// Settings service implementation
    /// </summary>
    public class SettingsService : ISettingsService
    {
        /// <summary>
        /// Add or update value
        /// </summary>
        /// <param name="key">Value key</param>
        /// <param name="value">Value</param>
        public void AddOrUpdateValue(string key, bool value) => Preferences.Set(key, value);

        /// <summary>
        /// Get value or default
        /// </summary>
        /// <param name="key">Value key</param>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public bool GetValueOrDefault(string key, bool value) => Preferences.Get(key, value);

        /// <summary>
        /// Clear values
        /// </summary>
        public void Clear() => Preferences.Clear();
    }
}