using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Validation
{
    public class PasswordValidator
    {
        private readonly IValidationStrategy _strategy;

        public PasswordValidator(IValidationStrategy strategy)
        {
            _strategy = strategy;
        }

        public bool Validate(string input)
        {
            return _strategy.IsValid(input);
        }
    }
}
