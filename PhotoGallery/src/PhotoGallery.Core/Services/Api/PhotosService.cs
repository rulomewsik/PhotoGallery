using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using PhotoGallery.Core.Contracts.Services.Api;
using PhotoGallery.Core.Helpers;
using PhotoGallery.Core.Helpers.Configuration;
using PhotoGallery.Core.Helpers.Extensions;
using PhotoGallery.Core.Models.Enums;
using PhotoGallery.Core.Models.Photos;

namespace PhotoGallery.Core.Services.Api
{
    public class PhotosService : IPhotosService
    {
        /// <summary>
        ///     Api service
        /// </summary>
        private readonly IApiService _apiService;

        /// <summary>
        ///     Cancellation Token
        /// </summary>
        private readonly CancellationTokenSource _cancellationTokenSource;

        public PhotosService(IApiService apiService)
        {
            _apiService = apiService;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        /// <summary>
        /// Get all the photos from the server
        /// </summary>
        /// <returns>List of photo items</returns>
        public async Task<List<PhotoItem>> GetAllPhotos()
        {
            _apiService.ChangeBaseUrl(EnvironmentSingleton.GetEnvironment().PhotosBaseUrl);
            
            var result = await _apiService.GetAsync
            (
                AppConfiguration.Values.MethodPhotos,
                _cancellationTokenSource
            );

            if (result.IsSuccessful)
            {
                return result.ConvertTo<List<PhotoItem>>();    
            }

            if (result.ErrorException != null) Debug.WriteLine(result.ErrorException.Message);
            return new List<PhotoItem>();
        }

        /// <summary>
        /// Get a photo by its ID
        /// </summary>
        /// <returns>Single photo item</returns>
        public async Task<PhotoItem> GetPhotoById(string id)
        {
            _apiService.ChangeBaseUrl(EnvironmentSingleton.GetEnvironment().PhotosBaseUrl);
            
            var result = await _apiService.GetAsync
            (
                AppConfiguration.Values.MethodPhotos,
                id,
                _cancellationTokenSource,
                ApiDataFormat.Json
            );
            
            if (result.IsSuccessful)
            {
                result.ConvertTo<PhotoItem>();   
            }

            if (result.ErrorException != null) Debug.WriteLine(result.ErrorException.Message);
            return new PhotoItem();
        }

        /// <summary>
        /// Delete a photo by its ID
        /// </summary>
        /// <returns>Delete a single photo item</returns>
        public async Task<PhotoItem> DeletePhotoById(int id)
        {
            _apiService.ChangeBaseUrl(EnvironmentSingleton.GetEnvironment().PhotosBaseUrl);
            
            var result = await _apiService.GetAsync
            (
                AppConfiguration.Values.MethodPhotos,
                id.ToString(),
                _cancellationTokenSource,
                ApiDataFormat.Json
            );

            if (result.IsSuccessful)
            {
                result.ConvertTo<PhotoItem>();   
            }

            if (result.ErrorException != null) Debug.WriteLine(result.ErrorException.Message);
            return new PhotoItem();
        }
    }
}