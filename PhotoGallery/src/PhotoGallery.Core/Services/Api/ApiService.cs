using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PhotoGallery.Core.Contracts.Services.Api;
using PhotoGallery.Core.Helpers.Extensions;
using PhotoGallery.Core.Models.Enums;
using PhotoGallery.Core.Models.Service;
using RestSharp;

namespace PhotoGallery.Core.Services.Api
{
    /// <summary>
    /// Rest sharp api service
    /// </summary>
    public class ApiService : IApiService
    {
        /// <summary>
        /// Rest client
        /// </summary>
        private IRestClient _client;

        /// <summary>
        /// Default data format
        /// </summary>
        private ApiDataFormat _defaultDataFormat;

        /// <summary>
        /// Start api service
        /// </summary>
        /// <param name="baseUrl">Base url</param>
        public void Start(string baseUrl)
        {
            _client = new RestClient(baseUrl);
            _defaultDataFormat = ApiDataFormat.Json;
        }

        /// <summary>
        /// Change base url
        /// </summary>
        /// <param name="newBaseUrl"></param>
        public void ChangeBaseUrl(string newBaseUrl)
        {
            _client = new RestClient(newBaseUrl);
        }

        /// <summary>
        /// Internal method to make a get request
        /// </summary>
        /// <typeparam name="T">Return object</typeparam>
        /// <param name="resource">Method</param>        
        /// <param name="cancellationTokenSource">Cancellation token source</param>
        /// <returns>Deserialized object</returns>
        public async Task<IRestResponse> GetAsync(string resource, CancellationTokenSource cancellationTokenSource)
        {
            return await InternalGetAsync(resource, _defaultDataFormat, cancellationTokenSource);
        }

        /// <summary>
        /// Internal method to make a get request
        /// </summary>
        /// <typeparam name="T">Return object</typeparam>
        /// <param name="resource">Method</param>
        /// <param name="dataFormat">Data format</param>
        /// <param name="parameter">Url parameter</param>
        /// <param name="cancellationTokenSource">Cancellation token source</param>
        /// <returns>Deserialized object</returns>
        public async Task<IRestResponse> GetAsync(string resource, string parameter, CancellationTokenSource cancellationTokenSource,
            ApiDataFormat dataFormat)
        {
            return await InternalGetAsync($"{resource}/{parameter}", dataFormat, cancellationTokenSource);
        }

        /// <summary>
        /// Internal method to make a get request
        /// </summary>
        /// <typeparam name="T">Return object</typeparam>
        /// <param name="resource">Method</param>
        /// <param name="dataFormat">Data format</param>
        /// <param name="parameter">Url parameter</param>
        /// <param name="cancellationTokenSource">Cancellation token source</param>
        /// <returns>Deserialized object</returns>
        private async Task<IRestResponse> InternalGetAsync(string resource, ApiDataFormat dataFormat, CancellationTokenSource cancellationTokenSource)
        {
            var request = new RestRequest(resource, Method.GET, GetDataFormat(dataFormat));

            try
            {
                var response = await _client.ExecuteAsync(request, cancellationTokenSource.Token);
                return response;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return default;
            }
        }

        /// <summary>
        /// Transform ApiDataFormat into RestSharp data format
        /// </summary>
        /// <param name="apiDataFormat">Data format</param>
        /// <returns>Rest sharp data format</returns>
        private static DataFormat GetDataFormat(ApiDataFormat apiDataFormat)
        {
            return apiDataFormat switch
            {
                ApiDataFormat.Json => DataFormat.Json,
                ApiDataFormat.Xml => DataFormat.Xml,
                _ => DataFormat.None
            };
        }
    }
}