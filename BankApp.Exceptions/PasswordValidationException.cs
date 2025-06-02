/**************************************************************************
 *                                                                        *
 *  File:        PasswordValidationException.cs                          *
 * Copyright:    (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 * E-mail:       emilian.dumea@student.tuiasi.ro                         *
 * Website:      https://github.com/emidumea/BankApp                     *
 * Description:  Excepție aruncată dacă parola nu respectă regulile      *
 *               de validare (lungime, caractere etc.).                  *
 *                                                                        *
 * This program is free software; you can redistribute it and/or modify  *
 * it under the terms of the GNU General Public License as published by  *
 * the Free Software Foundation. This program is distributed in the      *
 * hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 * the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 * PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/


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
