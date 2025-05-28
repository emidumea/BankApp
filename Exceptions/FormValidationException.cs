using System;

namespace BankApp.Exceptions
{
    /// <summary>
    /// Excepție aruncată când datele introduse în formular sunt invalide.
    /// </summary>
    public class FormValidationException : Exception
    {
        public FormValidationException(string message) : base(message) { }
    }
}
