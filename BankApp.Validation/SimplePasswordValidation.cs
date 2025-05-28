using BankApp.Exceptions;

namespace BankApp.Validation
{

    /// <summary>
    /// Strategie simplă pentru validarea parolei (minim 3 caractere).
    /// </summary>
    public class SimplePasswordValidation : IValidationStrategy
    {
        public bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length < 3)
                throw new PasswordValidationException("Parola trebuie să aibă minim 3 caractere.");
            return true;
        }
    }
}
