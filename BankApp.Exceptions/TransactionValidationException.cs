using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Exceptions
{
    /// <summary>
    /// Excepție pentru tranzacții care nu respectă regulile (ex: IBAN invalid).
    /// </summary>
    public class TransactionValidationException : Exception
    {
        public TransactionValidationException(string message) : base(message) { }
    }
}
