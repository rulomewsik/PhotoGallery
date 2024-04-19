using System.Net.Mail;
using PhotoGallery.Core.Contracts.Validations;

namespace PhotoGallery.Core.Helpers.Validations
{
    public class IsValidEmailRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            try
            {
                MailAddress addr = new MailAddress($"{value}");
                return addr.Address == $"{value}";
            }
            catch
            {
                return false;
            }
        }
    }
}