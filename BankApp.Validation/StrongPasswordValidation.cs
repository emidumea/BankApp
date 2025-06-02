/**************************************************************************
 *                                                                        *
 *  File:        StrongPasswordValidation.cs                             *
 *  Copyright:   (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 *  E-mail:      emilian.dumea@student.tuiasi.ro                         *
 *  Website:     https://github.com/emidumea/BankApp                     *
 *  Description: Implementare avansată pentru validarea unei parole      *
 *               complexe (majuscule, minuscule, cifre, lungime).        *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify *
 *  it under the terms of the GNU General Public License as published by *
 *  the Free Software Foundation. This program is distributed in the     *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even  *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR  *
 *  PURPOSE. See the GNU General Public License for more details.        *
 *                                                                        *
 **************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Exceptions;

namespace BankApp.Validation
{

    /// <summary>
    /// Strategie strictă pentru validarea parolei (minim 8 caractere, litere mari, mici, cifre).
    /// </summary>
    public class StrongPasswordValidation : IValidationStrategy
    {
        public bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new PasswordValidationException("Parola nu poate fi goală.");

            if (input.Length < 8)
                throw new PasswordValidationException("Parola trebuie să aibă cel puțin 8 caractere.");

            if (!input.Any(char.IsUpper) || !input.Any(char.IsLower) || !input.Any(char.IsDigit))
                throw new PasswordValidationException("Parola trebuie să conțină litere mari, mici și cifre.");

            return true;
        }
    }
}
