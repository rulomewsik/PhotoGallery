using Acr.UserDialogs;
using System.Threading.Tasks;
using PhotoGallery.Core.Contracts.Services.General;
using PhotoGallery.Core.Resources;
using Xamarin.Forms;

namespace PhotoGallery.Core.Services.General
{
    /// <summary>
    /// User dialog service.
    /// </summary>
    public class DialogService : IDialogService
    {
        #region Fields

        /// <summary>
        /// App is loading.
        /// </summary>
        private bool _loading;

        #endregion

        #region Methods

        /// <summary>
        /// Show alert.
        /// </summary>
        /// <param name="message">Alert message.</param>
        /// <returns>Awaitable.</returns>
        public Task ShowAlertAsync(string message)
        {
            return InternalShowAlertAsync(message,
                AppResources.ApplicationName,
                AppResources.Accept);
        }

        /// <summary>
        /// Show alert.
        /// </summary>
        /// <param name="message">Alert message.</param>
        /// <param name="title">Title.</param>
        /// <returns>Awaitable.</returns>
        public Task ShowAlertAsync(string message, string title)
        {
            return InternalShowAlertAsync(message,
                title,
                AppResources.Accept);
        }

        /// <summary>
        /// Show alert.
        /// </summary>
        /// <param name="message">Alert message.</param>
        /// <param name="title">Title.</param>
        /// <param name="buttonText">Button text.</param>
        /// <returns>Awaitable.</returns>
        public Task ShowAlertAsync(string message, string title, string buttonText)
        {
            return InternalShowAlertAsync(message,
                title,
                buttonText);
        }

        /// <summary>
        /// Show ask.
        /// </summary>
        /// <param name="ask">Ask.</param>
        /// <returns>Confirmed.</returns>
        public async Task<bool> ShowAsk(string ask)
        {
            if (_loading)
            {
                ShowLoading(false);

                var result = await UserDialogs.Instance.ConfirmAsync(new ConfirmConfig
                {
                    Message = ask,
                    Title = AppResources.ApplicationName,
                    OkText = AppResources.Yes,
                    CancelText = AppResources.No
                });

                ShowLoading(false);

                return result;
            }

            return await UserDialogs.Instance.ConfirmAsync(new ConfirmConfig
            {
                Message = ask,
                Title = AppResources.ApplicationName,
                OkText = AppResources.Yes,
                CancelText = AppResources.No
            });
        }

        /// <summary>
        /// show loading.
        /// </summary>
        /// <param name="show">Show.</param>
        public void ShowLoading(bool show)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (show)
                {
                    UserDialogs.Instance.ShowLoading(AppResources.Loading,
                        MaskType.Black);
                    _loading = true;
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    _loading = false;
                }
            });
        }

        /// <summary>
        /// Show action sheet.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="options">Options.</param>
        /// <returns>Selected option.</returns>
        public Task<string> ShowActionSheetAsync(string title, params string[] options)
        {
            return InternalShowActionSheetAsync(title,
                AppResources.Cancel,
                null,
                options);
        }

        /// <summary>
        /// Show alert.
        /// </summary>
        /// <param name="message">Alert message.</param>
        /// <param name="title">Title.</param>
        /// <param name="buttonText">Button text.</param>
        /// <returns>Awaitable.</returns>
        private async Task InternalShowAlertAsync(string message, string title, string buttonText)
        {
            if (_loading)
            {
                ShowLoading(false);

                await UserDialogs.Instance.AlertAsync(message,
                    title,
                    buttonText);

                ShowLoading(true);
            }
            else
            {
                await UserDialogs.Instance.AlertAsync(message,
                    title,
                    buttonText);
            }
        }

        /// <summary>
        /// Show action sheet async.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="cancel">Cancel.</param>
        /// <param name="destructive">Destructive.</param>
        /// <param name="options">Options.</param>
        /// <returns>Selected option.</returns>
        private async Task<string> InternalShowActionSheetAsync(string title, string cancel, string destructive, params string[] options)
        {
            if (_loading)
            {
                ShowLoading(false);

                var result = await UserDialogs.Instance.ActionSheetAsync(title,
                    cancel,
                    destructive,
                    null,
                    options);

                ShowLoading(true);

                return result;
            }

            return await UserDialogs.Instance.ActionSheetAsync(title,
                cancel,
                destructive,
                null,
                options);
        }

        #endregion
    }
}