/**************************************************************************
 *                                                                        *
 *  File:        DuplicateUserException.cs                               *
 *  Copyright:   (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 *  E-mail:      emilian.dumea@student.tuiasi.ro                         *
 *  Website:     https://github.com/emidumea/BankApp                     *
 *  Description: Excepție aruncată când se încearcă adăugarea unui       *
 *               utilizator care există deja (după username sau IBAN).   *
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

namespace BankApp.Exceptions
{
    /// <summary>
    /// Excepție aruncată când există deja un utilizator cu același username sau IBAN...
    /// </summary>
    public class DuplicateUserException : Exception
    {
        public DuplicateUserException(string message) : base(message) { }
    }
}
