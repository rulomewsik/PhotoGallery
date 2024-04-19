using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Navigation;
using PhotoGallery.Core.Contracts.Services.General;
using PhotoGallery.Core.Helpers;
using PhotoGallery.Core.Helpers.Validations;
using PhotoGallery.Core.Resources;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Xamarin.Forms;

namespace PhotoGallery.Core.ViewModels
{
    /// <summary>
    ///     Defines the <see cref="OnboardingViewModel" />.
    /// </summary>
    public class OnboardingViewModel : BaseViewModel
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="OnboardingViewModel" /> class.
        /// </summary>
        /// <param name="navigationService">The navigationService<see cref="IMvxNavigationService" />.</param>
        /// <param name="dialogService">The dialogService<see cref="IDialogService" />.</param>
        /// <param name="credentialsService"></param>
        public OnboardingViewModel(IMvxNavigationService navigationService, IDialogService dialogService, ICredentialsService credentialsService) :
            base(navigationService, dialogService)
        {
            _credentialsService = credentialsService;

            LoginAsyncCommand = new Command(async () => await LoginAsync());

            LoginBiometricsAsyncCommand = new Command(async () => await LoginWithBiometrics());
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the Email.
        /// </summary>
        public ValidatableObject<string> Email { get; set; } = new ValidatableObject<string>();

        /// <summary>
        ///     Gets or sets the Password.
        /// </summary>
        public ValidatableObject<string> Password { get; set; } = new ValidatableObject<string>();

        /// <summary>
        ///     Gets or sets the HeaderData.
        /// </summary>
        public bool IsRememberChecked
        {
            get => _isRememberChecked;
            set => SetProperty(ref _isRememberChecked, value);
        }

        /// <summary>
        ///     Gets the LoginAsyncCommand.
        /// </summary>
        public ICommand LoginAsyncCommand { get; }

        /// <summary>
        ///     Gets the LoginBiometricsAsyncCommand.
        /// </summary>
        public ICommand LoginBiometricsAsyncCommand { get; }

        #endregion

        #region Fields

        /// <summary>
        ///     Defines the _headerData.
        /// </summary>
        private bool _isRememberChecked;

        /// <summary>
        /// Defines the _credentialsService.
        /// </summary>
        private readonly ICredentialsService _credentialsService;

        #endregion

        #region Methods

        /// <summary>
        ///     The Initialize.
        /// </summary>
        /// <returns>The <see cref="Task" />.</returns>
        public override async Task Initialize()
        {
            await base.Initialize();
            
            Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = AppResources.GenericEmptyError });
            Email.Validations.Add(new IsValidEmailRule<string> { ValidationMessage = AppResources.EmailValidError });
            Password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = AppResources.GenericEmptyError });

            var savedCredentials = await _credentialsService.GetCredentialsAsync();
            Email.Value = savedCredentials.Email;
            Password.Value = savedCredentials.Password;
            IsRememberChecked = !string.IsNullOrEmpty(Email.Value) && !string.IsNullOrEmpty(Password.Value);
        }

        /// <summary>
        ///     The AreFieldsValid.
        /// </summary>
        /// <returns>The <see cref="bool" />.</returns>
        private bool AreFieldsValid()
        {
            var isEmailValid = Email.Validate();
            var isPasswordValid = Password.Validate();

            return isEmailValid && isPasswordValid;
        }

        /// <summary>
        ///     The LoginWithBiometrics.
        /// </summary>
        /// <returns>The <see cref="Task" />.</returns>
        private async Task LoginWithBiometrics()
        {
            var request = new AuthenticationRequestConfiguration("Enter your biometrics", "So you can access your photo gallery");
            var result = await CrossFingerprint.Current.AuthenticateAsync(request);

            if (result.Authenticated)
            {
                ShowLoading = true;

                UserSettings.IsLogged = true;
                await _credentialsService.SaveBiometricGuidAsync(new Guid());

                await NavigationService.Navigate<TabViewModel>();
            }

            ShowLoading = false;
        }

        /// <summary>
        ///     The LoginAsync.
        /// </summary>
        /// <returns>The <see cref="Task" />.</returns>
        private async Task LoginAsync()
        {
            if (AreFieldsValid())
            {
                ShowLoading = true;

                UserSettings.IsLogged = true;

                if (_isRememberChecked)
                {
                    await _credentialsService.SaveCredentialsAsync(Email.Value, Password.Value);
                }
                else
                {
                    _credentialsService.DeleteCredentialsAsync();
                }

                await NavigationService.Navigate<TabViewModel>();
            }

            ShowLoading = false;
        }

        #endregion
    }
}