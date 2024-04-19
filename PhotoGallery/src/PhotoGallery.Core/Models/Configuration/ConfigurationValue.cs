namespace PhotoGallery.Core.Models.Configuration
{
    /// <summary>
    /// Configuration values
    /// </summary>
    public class ConfigurationValue
    {
        public string DefaultTag { get; set; }

        #region Security

        /// <summary>
        /// Random photos method
        /// </summary>
        public string MethodPhotos { get; set; }
        
        /// <summary>
        /// Dummy profile method
        /// </summary>
        public string MethodProfile { get; set; }

        #endregion
        
    }
}