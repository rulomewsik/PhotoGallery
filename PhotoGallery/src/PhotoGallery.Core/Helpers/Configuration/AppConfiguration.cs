using System.IO;
using System.Reflection;
using MvvmCross;
using Newtonsoft.Json;
using PhotoGallery.Core.Models.Configuration;

namespace PhotoGallery.Core.Helpers.Configuration
{
    /// <summary>
    /// Application configuration
    /// </summary>
    [Preserve(AllMembers = true)]
    public static class AppConfiguration
    {
        #region Properties

        /// <summary>
        /// Configuration values
        /// </summary>
        public static ConfigurationValue Values { get; private set; }

        /// <summary>
        /// Configuration file name
        /// </summary>
        private const string ConfigFileName = "Configuration.json";

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        static AppConfiguration()
        {
            InitializeValues();
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Initialize Values
        /// </summary>
        private static void InitializeValues()
        {
            var assembly = typeof(AppConfiguration).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream($"PhotoGallery.Core.Helpers.Configuration.{ConfigFileName}");

            if (stream == null) return;
            using var reader = new StreamReader(stream);
            Values = JsonConvert.DeserializeObject<ConfigurationValue>(reader.ReadToEnd());
        }

        #endregion Methods
    }
}