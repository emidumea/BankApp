/**************************************************************************
 *                                                                        *
 *  File:        SimplePasswordValidation.cs                             *
 *  Copyright:   (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 *  E-mail:      emilian.dumea@student.tuiasi.ro                         *
 *  Website:     https://github.com/emidumea/BankApp                     *
 *  Description: Implementare simplă de validare a parolei.              *
 *               Verifică doar lungimea minimă.                          *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify *
 *  it under the terms of the GNU General Public License as published by *
 *  the Free Software Foundation. This program is distributed in the     *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even  *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR  *
 *  PURPOSE. See the GNU General Public License for more details.        *
 *                                                                        *
 **************************************************************************/


using BankApp.Exceptions;

namespace BankApp.Validation
{

    /// <summary>
    /// Strategie simplă pentru validarea parolei (minim 3 caractere).
    /// </summary>
    public class SimplePasswordValidation : IValidationStrategy
    {
        public bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length < 3)
                throw new PasswordValidationException("Parola trebuie să aibă minim 3 caractere.");
            return true;
        }
    }
}
