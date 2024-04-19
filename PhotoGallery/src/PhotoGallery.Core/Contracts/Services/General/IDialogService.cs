using System.Threading.Tasks;

namespace PhotoGallery.Core.Contracts.Services.General
{
    #region Interfaces

    /// <summary>
    /// User dialog service.
    /// </summary>
    public interface IDialogService
    {
        #region Methods

        /// <summary>
        /// Show alert.
        /// </summary>
        /// <param name="message">Alert message.</param>
        /// <returns>Awaitable.</returns>
        Task ShowAlertAsync(string message);

        /// <summary>
        /// Show alert.
        /// </summary>
        /// <param name="message">Alert message.</param>
        /// <param name="title">Title.</param>
        /// <returns>Awaitable.</returns>
        Task ShowAlertAsync(string message, string title);

        /// <summary>
        /// Show alert.
        /// </summary>
        /// <param name="message">Alert message.</param>
        /// <param name="title">Title.</param>
        /// <param name="buttonText">Button text.</param>
        /// <returns>Awaitable.</returns>
        Task ShowAlertAsync(string message, string title, string buttonText);
        
        /// <summary>
        /// Show action sheet async.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="options">Options.</param>
        /// <returns>Awaitable.</returns>
        Task<string> ShowActionSheetAsync(string title, params string[] options);

        /// <summary>
        /// Show ask.
        /// </summary>
        /// <param name="ask">Ask.</param>
        /// <returns>Confirmed.</returns>
        Task<bool> ShowAsk(string ask);

        /// <summary>
        /// show loading.
        /// </summary>
        /// <param name="show">Show.</param>
        void ShowLoading(bool show);

        #endregion
    }

    #endregion
}