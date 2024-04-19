using System.Globalization;
using System.Reflection;
using System.Xml.Serialization;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using PhotoGallery.Core.Contracts.Services.Api;
using PhotoGallery.Core.Contracts.Services.General;
using PhotoGallery.Core.Helpers;
using PhotoGallery.Core.Models;
using PhotoGallery.Core.Services.Api;
using PhotoGallery.Core.Services.General;
using PhotoGallery.Core.ViewModels;

namespace PhotoGallery.Core
{
    /// <summary>
    /// Defines the <see cref="App" />.
    /// </summary>
    public class App : MvxApplication
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Enviroment.
        /// </summary>
        private Environment Env { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The ReadEnvironmentFile.
        /// </summary>
        /// <param name="assembly">The assembly<see cref="Assembly"/>.</param>
        /// <returns>The <see cref="Models.Environment"/>.</returns>
        private static Environment ReadEnvironmentFile(Assembly assembly)
        {
            var stream = assembly.GetManifestResourceStream("PhotoGallery.Core.Environments.Environment.xml");
            var serializer = new XmlSerializer(typeof(Environment));
            if (stream == null) return null;
            var env = (Environment)serializer.Deserialize(stream);
            SetGlobalEnvironment(env);
            return env;
        }

        /// <summary>
        /// The Initialize.
        /// </summary>
        public override void Initialize()
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            Env = ReadEnvironmentFile(assembly);
            RegisterServices();

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NBaF5cXmZCe0x3TXxbf1x0ZFJMZV1bRHFPIiBoS35RckVnWHdfeXFURWBdVE1x");
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            RegisterAppStart<RootViewModel>();
        }

        /// <summary>
        /// The SetGlobalEnviroment.
        /// </summary>
        /// <param name="environment">The environment<see cref="Models.Environment"/>.</param>
        private static void SetGlobalEnvironment(Environment environment)
        {
            EnvironmentSingleton.SetEnvironment(() => environment);
        }

        /// <summary>
        /// The RegisterServices.
        /// </summary>
        private void RegisterServices()
        {
            Mvx.IoCProvider.RegisterSingleton<IApiService>(new ApiService());
            Mvx.IoCProvider.RegisterSingleton<ISettingsService>(new SettingsService());
            Mvx.IoCProvider.RegisterSingleton<IMediaService>(new MediaService());
            Mvx.IoCProvider.RegisterSingleton<ICredentialsService>(new CredentialsService());
            Mvx.IoCProvider.RegisterType<IPhotosService, PhotosService>();
            Mvx.IoCProvider.RegisterType<IProfileService, ProfileService>();
        }

        #endregion
    }
}