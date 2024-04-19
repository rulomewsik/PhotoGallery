namespace PhotoGallery.Core.Contracts.Services.General
{
    /// <summary>
    /// Settings service
    /// </summary>
    public interface ISettingsService
    {
        /// <summary>
        /// Get value or default
        /// </summary>
        /// <param name="key">Value key</param>
        /// <param name="value">Value</param>
        /// <returns>Value</returns>
        bool GetValueOrDefault(string key, bool value);

        /// <summary>
        /// Add or update value
        /// </summary>
        /// <param name="key">Value key</param>
        /// <param name="value">Value</param>
        void AddOrUpdateValue(string key, bool value);

        /// <summary>
        /// Clear values
        /// </summary>
        void Clear();
    }
}