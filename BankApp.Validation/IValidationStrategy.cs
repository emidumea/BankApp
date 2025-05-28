using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Validation
{
    /// <summary>
    /// Interfață pentru strategii de validare (ex: parole).
    /// </summary>
    public interface IValidationStrategy
    {

        /// <summary>
        /// Verifică dacă valoarea este validă.
        /// </summary>
        /// <param name="input">Valoarea de validat.</param>
        /// <returns>True dacă este validă, altfel false.</returns>
        bool IsValid(string input);
    }
}
