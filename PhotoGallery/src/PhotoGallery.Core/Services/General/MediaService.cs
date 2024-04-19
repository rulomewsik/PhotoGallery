using System;
using MvvmCross;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.Threading.Tasks;
using PhotoGallery.Core.Contracts.Services.General;
using PhotoGallery.Core.Models.Media;
using PhotoGallery.Core.Resources;

namespace PhotoGallery.Core.Services.General
{
    /// <summary>
    /// Media service
    /// </summary>
    public class MediaService : IMediaService
    {
        /// <summary>
        /// dialog service
        /// </summary>
        private IDialogService dialogService => Mvx.IoCProvider.Resolve<IDialogService>();

        /// <summary>
        /// Default max width height photo 
        /// </summary>
        private const int DEFAULT_MAX_WIDTH_HEIGHT = 300;

        /// <summary>
        /// Take picture
        /// </summary>
        /// <returns>Picture result</returns>
        public async Task<TakePictureResult> TakePictureAsync() => await InternalTakePictureAsync(false, true, DEFAULT_MAX_WIDTH_HEIGHT);

        /// <summary>
        /// Pick picture
        /// </summary>
        /// <returns>Picture result</returns>
        public async Task<TakePictureResult> PickPictureAsync() => await InternalPickPhotoAsync(DEFAULT_MAX_WIDTH_HEIGHT);

        /// <summary>
        /// Ask source and get image
        /// </summary>
        /// <returns>Picture result</returns>
        public async Task<TakePictureResult> GetImageAsync()
        {
            var pictureResult = new TakePictureResult();
            var selectedOption = await dialogService.ShowActionSheetAsync(AppResources.TakePhoto,
                AppResources.Camera,
                AppResources.Gallery);

            if (selectedOption == AppResources.Camera)
                pictureResult = await InternalTakePictureAsync(false, true, DEFAULT_MAX_WIDTH_HEIGHT);

            if (selectedOption == AppResources.Gallery)
                pictureResult = await InternalPickPhotoAsync(DEFAULT_MAX_WIDTH_HEIGHT);

            return pictureResult;
        }

        /// <summary>
        /// Take picture
        /// </summary>
        /// <param name="allowCropping">Allow croping</param>
        /// <param name="saveToAlbum">Save to album</param>
        /// <param name="maxWidthHeight">Max width height</param>
        /// <returns>Picture result</returns>
        private async Task<TakePictureResult> InternalTakePictureAsync(bool allowCropping, bool saveToAlbum, int? maxWidthHeight)
        {
            var result = new TakePictureResult();

            if (CrossMedia.IsSupported
                && CrossMedia.Current.IsCameraAvailable
                && CrossMedia.Current.IsTakePhotoSupported)
            {
                try
                {
                    if (await CrossMedia.Current.Initialize())
                    {
                        var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                        {
                            AllowCropping = allowCropping,
                            SaveToAlbum = saveToAlbum,
                            MaxWidthHeight = maxWidthHeight,
                            PhotoSize = maxWidthHeight is null ? PhotoSize.Full : PhotoSize.MaxWidthHeight,
                            CompressionQuality = 80
                        });

                        result.Success = true;
                        result.Error = string.Empty;
                        result.PictureStream = file?.GetStream();
                    }
                    else
                    {
                        result.Error = "The camera could not be initialized";
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    result.Error = "Camera error";
                }
            }
            else
            {
                result.Error = "Camera no available";
            }

            return result;
        }

        /// <summary>
        /// Internal pick photo async 
        /// </summary>
        /// <param name="maxWidthHeight">Max width height</param>
        /// <returns>Picture result</returns>
        private async Task<TakePictureResult> InternalPickPhotoAsync(int? maxWidthHeight)
        {
            var result = new TakePictureResult();

            if (CrossMedia.IsSupported
                && CrossMedia.Current.IsPickPhotoSupported)
            {
                try
                {
                    var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                    {
                        MaxWidthHeight = maxWidthHeight,
                        PhotoSize = maxWidthHeight is null ? PhotoSize.Full : PhotoSize.MaxWidthHeight,
                        CompressionQuality = 80
                    });

                    result.Success = true;
                    result.Error = string.Empty;
                    result.PictureStream = file?.GetStream();
                }
                catch
                {
                    result.Error = "Pick picture error";
                }
            }
            else
            {
                result.Error = "Pick picture not suported";
            }

            return result;
        }
    }
}