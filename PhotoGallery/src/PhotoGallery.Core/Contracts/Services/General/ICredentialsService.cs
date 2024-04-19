using System;
using System.Threading.Tasks;

namespace PhotoGallery.Core.Contracts.Services.General
{
    /// <summary>
    /// User Credentials service.
    /// </summary>
    public interface ICredentialsService
    {
        Task SaveCredentialsAsync(string email, string password);

        bool DeleteCredentialsAsync();

        Task SaveBiometricGuidAsync(Guid biometricGuid);

        Task<(string Email, string Password)> GetCredentialsAsync();
    }
}