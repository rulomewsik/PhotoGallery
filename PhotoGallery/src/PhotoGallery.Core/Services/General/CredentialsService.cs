using System;
using System.Threading.Tasks;
using PhotoGallery.Core.Contracts.Services.General;
using Xamarin.Essentials;

namespace PhotoGallery.Core.Services.General
{
    public class CredentialsService : ICredentialsService
    {
        public async Task SaveCredentialsAsync(string email, string password)
        {
            await SecureStorage.SetAsync("email", email);
            await SecureStorage.SetAsync("password", password);
        }


        public bool DeleteCredentialsAsync()
        {
            return SecureStorage.Remove("email") && SecureStorage.Remove("password");
        }

        public async Task SaveBiometricGuidAsync(Guid biometricGuid)
        {
            await SecureStorage.SetAsync("biometricGuid", biometricGuid.ToString());
        }

        public async Task<(string Email, string Password)> GetCredentialsAsync()
        {
            var email = await SecureStorage.GetAsync("email");
            var password = await SecureStorage.GetAsync("password");
            return (email, password);
        }
    }
}