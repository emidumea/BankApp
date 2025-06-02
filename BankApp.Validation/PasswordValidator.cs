/**************************************************************************
 *                                                                        *
 *  File:        PasswordValidator.cs                                    *
 *  Copyright:   (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 *  E-mail:      emilian.dumea@student.tuiasi.ro                         *
 *  Website:     https://github.com/emidumea/BankApp                     *
 *  Description: Clasă care aplică o strategie de validare a parolei     *
 *               folosind modelul Strategy.                              *
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

namespace BankApp.Validation
{
    /// <summary>
    /// Clasă care validează parolele folosind strategia aleasă.
    /// </summary>
    public class PasswordValidator
    {
        private readonly IValidationStrategy _strategy;

        public PasswordValidator(IValidationStrategy strategy)
        {
            _strategy = strategy;
        }


        /// <summary>
        /// Validează parola. Aruncă PasswordValidationException dacă nu e validă.
        /// </summary>
        /// <param name="input">Parola introdusă.</param>
        /// <returns>True dacă e validă.</returns>
        public bool Validate(string input)
        {
            return _strategy.IsValid(input);
        }
    }
}
