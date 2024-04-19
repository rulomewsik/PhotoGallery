using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using PhotoGallery.Core.Contracts.Services.Api;
using PhotoGallery.Core.Helpers;
using PhotoGallery.Core.Helpers.Configuration;
using PhotoGallery.Core.Helpers.Extensions;
using PhotoGallery.Core.Models;
using PhotoGallery.Core.Models.Enums;

namespace PhotoGallery.Core.Services.Api
{
    public class ProfileService : IProfileService
    {
        /// <summary>
        ///     Api service
        /// </summary>
        private readonly IApiService _apiService;

        /// <summary>
        ///     Cancellation Token
        /// </summary>
        private readonly CancellationTokenSource _cancellationTokenSource;

        public ProfileService(IApiService apiService)
        {
            _apiService = apiService;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        /// <summary>
        /// Get dummy user profile data
        /// </summary>
        /// <returns>Profile data</returns>
        public async Task<ProfileData> GetProfileData()
        {
            _apiService.ChangeBaseUrl(EnvironmentSingleton.GetEnvironment().ProfileBaseUrl);
            var random = new Random();
            var randomNumber = random.Next(1, 41);
            
            var result = await _apiService.GetAsync
            (
                AppConfiguration.Values.MethodProfile,
                randomNumber.ToString(),
                _cancellationTokenSource,
                ApiDataFormat.Json
            );

            if (result.IsSuccessful)
            {
                return result.ConvertTo<ProfileData>();
            }

            if (result.ErrorException != null) Debug.WriteLine(result.ErrorException.Message);
            return new ProfileData();
        }
    }
}