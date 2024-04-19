using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using FFImageLoading.Forms;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using PhotoGallery.Core.Contracts.Services.Api;
using PhotoGallery.Core.Contracts.Services.General;
using PhotoGallery.Core.Helpers;
using PhotoGallery.Core.Models;
using PhotoGallery.Core.Models.Media;
using PhotoGallery.Core.Models.Photos;
using PhotoGallery.Core.Resources;
using Syncfusion.SfCarousel.XForms;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PhotoGallery.Core.ViewModels
{
    /// <summary>
    /// Defines the <see cref="TabViewModel" />.
    /// </summary>
    public class TabViewModel : BaseViewModel
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TabViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">The navigationService<see cref="IMvxNavigationService"/>.</param>
        /// <param name="dialogService">The dialogService<see cref="IDialogService"/>.</param>
        /// /// <param name="photosService">The photosService<see cref="IPhotosService" />.</param>
        /// <param name="profileService">The profile service</param>
        /// <param name="mediaService">The media service</param>
        /// <param name="geolocationService">The geolocation service</param>
        public TabViewModel(IMvxNavigationService navigationService, IDialogService dialogService, IPhotosService photosService,
            IProfileService profileService, IMediaService mediaService, IGeolocationService geolocationService) : base(
            navigationService, dialogService)
        {
            _photosService = photosService;
            _profileService = profileService;
            _mediaService = mediaService;
            _geolocationService = geolocationService;

            RefreshDataAsyncCommand = new Command(
                async () => await RefreshDataAsync(),
                () => !IsRefreshing
            );

            DeletePhotoCommand = new MvxCommand<PhotoItem>(DeletePhoto);

            ChangeProfilePictureAsyncCommand = new Command(
                async () => await ChangeProfilePictureAsync(),
                () => !IsRefreshing
            );
            
            SignOutAsyncCommand =  new Command(
                async () => await SignOutAsync(),
                () => !IsRefreshing
            );
        }

        #endregion

        #region Commands

        /// <summary>
        ///     Gets the RefreshDataAsyncCommand.
        /// </summary>
        public ICommand RefreshDataAsyncCommand { get; }

        /// <summary>
        ///     Gets the DeletePhotoAsyncCommand.
        /// </summary>
        public IMvxCommand<PhotoItem> DeletePhotoCommand { get; }

        /// <summary>
        ///     Gets the ChangeProfilePictureAsyncCommand.
        /// </summary>
        public ICommand ChangeProfilePictureAsyncCommand { get; }
        
        /// <summary>
        ///  Gets the SignOutAsyncCommand.
        /// </summary>
        public ICommand SignOutAsyncCommand { get; }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the CarouselItems
        /// </summary>
        public ObservableCollection<SfCarouselItem> CarouselItems
        {
            get => _carouselItems;
            set => SetProperty(ref _carouselItems, value);
        }

        /// <summary>
        ///     Gets or sets the PhotoItems
        /// </summary>
        public ObservableCollection<PhotoItem> PhotoItems
        {
            get => _photoItems;
            set => SetProperty(ref _photoItems, value);
        }

        /// <summary>
        ///     Gets or sets the HeaderData.
        /// </summary>
        public HeaderData HeaderData
        {
            get => _headerData;
            set => SetProperty(ref _headerData, value);
        }

        /// <summary>
        ///     Gets or sets the HeaderData.
        /// </summary>
        public ProfileData ProfileData
        {
            get => _profileData;
            set => SetProperty(ref _profileData, value);
        }

        /// <summary>
        ///     Gets the ProfilePictureBytes
        /// </summary>
        public byte[] ProfilePictureBytes { get; private set; }

        /// <summary>
        /// Gets the DeviceInfo.
        /// </summary>
        public string DeviceModel => DeviceInfo.Model;

        public string DeviceManufacturer => DeviceInfo.Manufacturer;
        public string DeviceName => DeviceInfo.Name;
        public string DeviceVersion => DeviceInfo.VersionString;
        public DevicePlatform DevicePlatform => DeviceInfo.Platform;

        #endregion

        #region Fields

        /// <summary>
        /// Defines the photosService.
        /// </summary>
        private readonly IPhotosService _photosService;

        /// <summary>
        /// Defines the profileService.
        /// </summary>
        private readonly IProfileService _profileService;

        /// <summary>
        /// Defines the _mediaService.
        /// </summary>
        private readonly IMediaService _mediaService;

        /// <summary>
        /// Defines the _geolocationService.
        /// </summary>
        private readonly IGeolocationService _geolocationService;

        /// <summary>
        ///     Defines the _carouselItems.
        /// </summary>
        private ObservableCollection<SfCarouselItem> _carouselItems;

        /// <summary>
        ///     Defines the _photoItems.
        /// </summary>
        private ObservableCollection<PhotoItem> _photoItems;

        /// <summary>
        ///     Defines the _headerData.
        /// </summary>
        private HeaderData _headerData;

        /// <summary>
        ///     Defines the _profileData.
        /// </summary>
        private ProfileData _profileData;

        #endregion

        #region Methods

        public override async Task Initialize()
        {
            await base.Initialize();

            await GetRandomPhotosAsync(3);
            await GetPhotosAsync();
            await GetProfileData();
        }

        private async Task GetPhotosAsync()
        {
            IsBusy = true;

            var photosResponse = await _photosService.GetAllPhotos();

            if (photosResponse.Count != 0)
            {
                var random = new Random();
                PhotoItems = new ObservableCollection<PhotoItem>(photosResponse.OrderBy(x => random.Next()).Take(20));
            }

            IsBusy = false;
        }

        private async Task GetRandomPhotosAsync(int count)
        {
            IsBusy = true;

            var photosResponse = await _photosService.GetAllPhotos();

            if (photosResponse.Count != 0)
            {
                CarouselItems = new ObservableCollection<SfCarouselItem>();

                var random = new Random();
                var randomPhotos = photosResponse.OrderBy(x => random.Next()).Take(count).ToList();

                foreach (var randomPhoto in randomPhotos)
                {
                    CarouselItems.Add(new SfCarouselItem
                    {
                        ItemContent = new StackLayout
                        {
                            Children =
                            {
                                new CachedImage
                                {
                                    Source = randomPhoto.Url,
                                    LoadingPlaceholder = "gallery.png",
                                    HeightRequest = 300,
                                    WidthRequest = 300,
                                    Aspect = Aspect.AspectFit
                                },
                                new Label
                                {
                                    Margin = new Thickness(10, 0, 10, 0),
                                    Text = randomPhoto.Title,
                                    TextColor = Color.FromHex("#1C1C28"),
                                    HorizontalTextAlignment = TextAlignment.Center,
                                    VerticalTextAlignment = TextAlignment.Center,
                                    FontSize = 28
                                }
                            }
                        }
                    });
                }
            }

            IsBusy = false;
        }

        private async Task RefreshDataAsync()
        {
            IsRefreshing = true;

            await GetPhotosAsync();

            IsRefreshing = false;
        }

        private void DeletePhoto(PhotoItem photoToDelete)
        {
            IsBusy = true;

            if (photoToDelete != null)
            {
                PhotoItems.Remove(photoToDelete);
            }

            IsBusy = false;
        }

        private async Task GetProfileData()
        {
            IsBusy = true;

            ProfileData = new ProfileData();
            var profileResponse = await _profileService.GetProfileData();

            if (profileResponse == null) return;

            HeaderData = new HeaderData
            {
                NameFormat = $"{profileResponse.FirstName} {profileResponse.LastName}",
                PictureSource = profileResponse.Image
            };

            ProfileData = profileResponse;

            var geolocationData = await _geolocationService.GetLastKnownLocationAsync();

            ProfileData.Address.Coordinates = new Coordinates
            {
                Lat = geolocationData.Latitude,
                Lng = geolocationData.Longitude,
                Alt = geolocationData.Altitude ?? 0.0
            };

            IsBusy = false;
        }

        private async Task ChangeProfilePictureAsync()
        {
            var pictureResult = new TakePictureResult();

            var selectedOption =
                await DialogService.ShowActionSheetAsync(AppResources.TakePhoto, AppResources.Camera,
                    AppResources.Gallery);

            if (selectedOption == AppResources.Camera)
                pictureResult = await _mediaService.TakePictureAsync();
            else if (selectedOption == AppResources.Gallery) pictureResult = await _mediaService.PickPictureAsync();

            if (pictureResult.Success && pictureResult.PictureStream != null)
            {
                var picture = new byte[pictureResult.PictureStream.Length];
                _ = await pictureResult.PictureStream.ReadAsync(picture, default, (int)pictureResult.PictureStream.Length);

                ProfilePictureBytes = picture;

                HeaderData.PictureSource = ImageSource.FromStream(() => new MemoryStream(picture));
            }
        }
        
        private async Task SignOutAsync()
        {
            UserSettings.ClearSettings();
            await NavigationService.Navigate<OnboardingViewModel>();
        }

        #endregion
    }
}