/**************************************************************************
 *                                                                        *
 *  File:        IValidationStrategy.cs                                  *
 *  Copyright:   (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 *  E-mail:      emilian.dumea@student.tuiasi.ro                         *
 *  Website:     https://github.com/emidumea/BankApp                     *
 *  Description: Interfață pentru strategii de validare a parolei.       *
 *               Permite implementări flexibile și interschimbabile.     *
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
