/**************************************************************************
 *                                                                        *
 *  File:        TransactionValidationException.cs                       *
 * Copyright:    (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 * E-mail:       emilian.dumea@student.tuiasi.ro                         *
 * Website:      https://github.com/emidumea/BankApp                     *
 * Description:  Excepție aruncată când datele tranzacției sunt invalide *
 *               (ex: IBAN gol, sumă negativă, utilizator inexistent).   *
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
