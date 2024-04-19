using MvvmCross.Navigation;
using PhotoGallery.Core.Contracts.Services.General;

namespace PhotoGallery.Core.ViewModels
{
    /// <summary>
    /// Defines the <see cref="MainViewModel" />.
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">The navigationService<see cref="IMvxNavigationService"/>.</param>
        /// <param name="dialogService">The dialogService<see cref="IDialogService"/>.</param>
        public MainViewModel(IMvxNavigationService navigationService, IDialogService dialogService) : base(navigationService, dialogService)
        {
        }

        #endregion
    }
}