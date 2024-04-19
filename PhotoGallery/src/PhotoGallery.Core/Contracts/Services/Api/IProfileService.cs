using System.Threading.Tasks;
using PhotoGallery.Core.Models;

namespace PhotoGallery.Core.Contracts.Services.Api
{
    public interface IProfileService
    {
        /// <summary>
        /// Gets dummy user profile data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProfileData> GetProfileData();
    }
}