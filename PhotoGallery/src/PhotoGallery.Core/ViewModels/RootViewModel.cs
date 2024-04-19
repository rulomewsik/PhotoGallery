using MvvmCross.Navigation;
using PhotoGallery.Core.Contracts.Services.General;
using PhotoGallery.Core.Helpers;

namespace PhotoGallery.Core.ViewModels
{
    /// <summary>
    ///     Defines the <see cref="RootViewModel" />.
    /// </summary>
    public class RootViewModel : BaseViewModel
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="RootViewModel" /> class.
        /// </summary>
        /// <param name="navigationService">The navigationService<see cref="IMvxNavigationService" />.</param>
        /// <param name="dialogService">The dialogService<see cref="IDialogService" />.</param>
        public RootViewModel(IMvxNavigationService navigationService, IDialogService dialogService) : base(navigationService, dialogService)
        {
        }

        #endregion


        #region Methods

        public override async void ViewAppearing()
        {
            await base.Initialize();

            if (UserSettings.IsLogged)
            {
                _ = await NavigationService.Navigate<TabViewModel>();
            }
            else
            {
                _ = await NavigationService.Navigate<OnboardingViewModel>();
            }
        }

        #endregion
    }
}