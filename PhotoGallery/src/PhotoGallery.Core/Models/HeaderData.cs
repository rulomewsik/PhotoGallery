using PhotoGallery.Core.Utilities;
using Xamarin.Forms;

namespace PhotoGallery.Core.Models
{
    public class HeaderData : BindableBase
    {
        private ImageSource _pictureSource;
        public ImageSource PictureSource
        {
            get => _pictureSource;
            set => SetProperty(ref _pictureSource, value);
        }

        private string _nameFormat;
        public string NameFormat
        {
            get => _nameFormat;
            set => SetProperty(ref _nameFormat, value);
        }
    }
}