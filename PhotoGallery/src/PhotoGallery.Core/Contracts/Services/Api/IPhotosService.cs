using System.Collections.Generic;
using System.Threading.Tasks;
using PhotoGallery.Core.Models.Photos;

namespace PhotoGallery.Core.Contracts.Services.Api
{
    public interface IPhotosService
    {
        /// <summary>
        /// Get all the photos from the server
        /// </summary>
        /// <returns></returns>
        Task<List<PhotoItem>> GetAllPhotos();
        
        /// <summary>
        /// Get a photo by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PhotoItem> GetPhotoById(string id);
        
        /// <summary>
        /// Delete a photo by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PhotoItem> DeletePhotoById(int id);
    }
}