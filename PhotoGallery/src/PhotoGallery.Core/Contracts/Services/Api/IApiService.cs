using System.Threading;
using System.Threading.Tasks;
using PhotoGallery.Core.Models.Enums;
using RestSharp;

namespace PhotoGallery.Core.Contracts.Services.Api
{
    /// <summary>
    /// Rest api service
    /// </summary>
    public interface IApiService
    {
        /// <summary>
        /// Start api service
        /// </summary>
        /// <param name="baseUrl">Base url</param>
        void Start(string baseUrl);

        /// <summary>
        /// Change base url
        /// </summary>
        /// <param name="newBaseUrl"></param>
        void ChangeBaseUrl(string newBaseUrl);

        /// <summary>
        /// Internal method to make a get request
        /// </summary>
        /// <typeparam name="T">Return object</typeparam>
        /// <param name="resource">Method</param>        
        /// <param name="cancellationTokenSource">Cancellation token source</param>
        /// <returns>Deserialized object</returns>
        Task<IRestResponse> GetAsync(string resource, CancellationTokenSource cancellationTokenSource);

        /// <summary>
        /// Internal method to make a get request
        /// </summary>
        /// <typeparam name="T">Return object</typeparam>
        /// <param name="resource">Method</param>
        /// <param name="dataFormat">Data format</param>
        /// <param name="parameter">string parameter</param>
        /// <param name="cancellationTokenSource">Cancellation token source</param>
        /// <returns>Deserialized object</returns>
        Task<IRestResponse> GetAsync(string resource, string parameter, CancellationTokenSource cancellationTokenSource, ApiDataFormat dataFormat);
    }
}