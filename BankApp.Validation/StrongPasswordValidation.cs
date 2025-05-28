using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Exceptions;

namespace BankApp.Validation
{

    /// <summary>
    /// Strategie strictă pentru validarea parolei (minim 8 caractere, litere mari, mici, cifre).
    /// </summary>
    public class StrongPasswordValidation : IValidationStrategy
    {
        public bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new PasswordValidationException("Parola nu poate fi goală.");

            if (input.Length < 8)
                throw new PasswordValidationException("Parola trebuie să aibă cel puțin 8 caractere.");

            if (!input.Any(char.IsUpper) || !input.Any(char.IsLower) || !input.Any(char.IsDigit))
                throw new PasswordValidationException("Parola trebuie să conțină litere mari, mici și cifre.");

            return true;
        }
    }
}
