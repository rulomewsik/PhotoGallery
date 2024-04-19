using System;
using System.Threading.Tasks;
using PhotoGallery.Core.Contracts.Services.General;
using Xamarin.Essentials;

namespace PhotoGallery.Core.Services.General
{
    public class GeolocationService : IGeolocationService
    {
        public async Task<Location> GetLastKnownLocationAsync()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    return location;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

            return new Location();
        }
    }
}