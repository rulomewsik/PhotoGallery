using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using PhotoGallery.Core.Contracts.Validations;

namespace PhotoGallery.Core.Helpers.Validations
{
    public class ValidatableObject<T> : IValidatable<T>
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<IValidationRule<T>> Validations { get; } = new List<IValidationRule<T>>();

        public List<string> Errors { get; set; } = new List<string>();

        public bool CleanOnChange { get; set; } = true;

        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Value)));

                if (CleanOnChange)
                {
                    IsValid = true;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(IsValid)));
                }
            }
        }

        public bool IsValid { get; set; } = true;

        public virtual bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> errors = Validations.Where(v => !v.Check(Value))
                .Select(v => v.ValidationMessage);

            Errors = errors.ToList();
            IsValid = !Errors.Any();

            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Errors)));
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(IsValid)));

            return IsValid;
        }

        public override string ToString()
        {
            return $"{Value}";
        }

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="args">The PropertyChangedEventArgs</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, args);
        }
    }
}