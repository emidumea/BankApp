using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Validation
{
    /// <summary>
    /// Clasă care validează parolele folosind strategia aleasă.
    /// </summary>
    public class PasswordValidator
    {
        private readonly IValidationStrategy _strategy;

        public PasswordValidator(IValidationStrategy strategy)
        {
            _strategy = strategy;
        }


        /// <summary>
        /// Validează parola. Aruncă PasswordValidationException dacă nu e validă.
        /// </summary>
        /// <param name="input">Parola introdusă.</param>
        /// <returns>True dacă e validă.</returns>
        public bool Validate(string input)
        {
            return _strategy.IsValid(input);
        }
    }
}
