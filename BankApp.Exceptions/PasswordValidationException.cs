using System;

namespace BankApp.Exceptions
{
    /// <summary>
    /// Excepție pentru parole care nu respectă regulile impuse.
    /// </summary>
    public class PasswordValidationException : Exception
    {
        public PasswordValidationException(string message) : base(message) { }
    }
}
