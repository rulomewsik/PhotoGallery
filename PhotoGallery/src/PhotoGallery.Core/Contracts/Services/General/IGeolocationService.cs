using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PhotoGallery.Core.Contracts.Services.General
{
    /// <summary>
    /// Geolocation service
    /// </summary>
    public interface IGeolocationService
    {
        /// <summary>
        /// Get last known location
        /// </summary>
        /// <returns>Value</returns>
        Task<Location> GetLastKnownLocationAsync();
    }
}