using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankApp.Validation
{
    public class StrongPasswordValidation : IValidationStrategy
    {
        public bool IsValid(string input)
        {
            return !string.IsNullOrWhiteSpace(input) &&
                   input.Length >= 8 &&
                   input.Any(char.IsUpper) &&
                   input.Any(char.IsLower) &&
                   input.Any(char.IsDigit);
        }
    }
}
