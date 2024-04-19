using PhotoGallery.Core.Contracts.Validations;

namespace PhotoGallery.Core.Helpers.Validations
{
    public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            string str = $"{value}";
            return !string.IsNullOrWhiteSpace(str);
        }
    }
}