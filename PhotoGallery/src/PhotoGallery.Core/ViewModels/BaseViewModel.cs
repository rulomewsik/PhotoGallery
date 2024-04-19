using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using PhotoGallery.Core.Contracts.Services.General;

namespace PhotoGallery.Core.ViewModels
{
    /// <summary>
    ///     Defines the <see cref="BaseViewModel" />.
    /// </summary>
    public abstract class BaseViewModel : MvxViewModel
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseViewModel" /> class.
        /// </summary>
        /// <param name="navigationService">The navigationService<see cref="IMvxNavigationService" />.</param>
        /// <param name="dialogService">The dialogService<see cref="IDialogService" />.</param>
        protected BaseViewModel(IMvxNavigationService navigationService, IDialogService dialogService)
        {
            NavigationService = navigationService;
            DialogService = dialogService;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets a value indicating whether IsBusy
        ///     The app is busy.
        /// </summary>
        public bool IsBusy
        {
            get => _isBusy;

            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating to show the loader indicator
        ///     The app is busy.
        /// </summary>
        protected bool ShowLoading
        {
            get => _showLoading;

            set
            {
                _showLoading = value;
                RaisePropertyChanged(() => ShowLoading);
                DialogService.ShowLoading(_showLoading);
            }
        }
        
        /// <summary>
        ///     Gets or sets a value indicating whether IsRefreshing.
        /// </summary>
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }
        
        #endregion

        #region Fields

        /// <summary>
        ///     Dialog service.
        /// </summary>
        protected readonly IDialogService DialogService;

        /// <summary>
        ///     Navigation service.
        /// </summary>
        protected readonly IMvxNavigationService NavigationService;

        /// <summary>
        ///     The app is busy.
        /// </summary>
        private bool _isBusy;

        /// <summary>
        ///     The app is showing the loading indicator.
        /// </summary>
        private bool _showLoading;
        
        /// <summary>
        ///     Defines the _isRefreshing.
        /// </summary>
        private bool _isRefreshing;

        #endregion
    }
}