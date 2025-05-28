using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Validation
{
    public class SimplePasswordValidation : IValidationStrategy
    {
        public bool IsValid(string input)
        {
            return !string.IsNullOrWhiteSpace(input) && input.Length >= 3;
        }
    }
}
