using MvvmCross;
using PhotoGallery.Core.Contracts.Services.General;

namespace PhotoGallery.Core.Helpers
{
    /// <summary>
    /// User local settings data
    /// </summary>
    public static class UserSettings
    {
        /// <summary>
        /// Settings service
        /// </summary>
        private static ISettingsService SettingsService => Mvx.IoCProvider.Resolve<ISettingsService>();

        /// <summary>
        /// Clear all user settings
        /// </summary>
        public static void ClearSettings() => SettingsService.Clear();
        
        /// <summary>
        /// User is logged
        /// </summary>
        public static bool IsLogged
        {
            get => SettingsService.GetValueOrDefault(nameof(IsLogged), default(bool));
            set => SettingsService.AddOrUpdateValue(nameof(IsLogged), value);
        }
    }
}