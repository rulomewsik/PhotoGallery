using System.IO;

namespace PhotoGallery.Core.Models.Media
{
    /// <summary>
    /// Take picture process result
    /// </summary>
    public class TakePictureResult
    {
        /// <summary>
        /// Success
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Message if error
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Picture stream
        /// </summary>
        public Stream PictureStream { get; set; }
    }
}