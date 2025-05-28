using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Exceptions
{
    /// <summary>
    /// Excepție aruncată când utilizatorul nu are suficiente fonduri pentru tranzacție.
    /// </summary>
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message) { }
    }
}
