using System.Threading.Tasks;
using PhotoGallery.Core.Models.Media;

namespace PhotoGallery.Core.Contracts.Services.General
{
    /// <summary>
    /// Media service interface
    /// </summary>
    public interface IMediaService
    {
        /// <summary>
        /// Take photo
        /// </summary>
        /// <returns>Photo stream</returns>
        Task<TakePictureResult> TakePictureAsync();

        /// <summary>
        /// Pick picture
        /// </summary>
        /// <returns>Photo stream</returns>
        Task<TakePictureResult> PickPictureAsync();

        /// <summary>
        /// Ask source and get image
        /// </summary>
        /// <returns>Picture result</returns>
        Task<TakePictureResult> GetImageAsync();
    }
}