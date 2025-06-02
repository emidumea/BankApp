/**************************************************************************
 *                                                                        *
 *  File:        User.cs                                                 *
 *  Copyright:   (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 *  E-mail:      emilian.dumea@student.tuiasi.ro                         *
 *  Website:     https://github.com/emidumea/BankApp                     *
 *  Description: Modelul de date pentru un utilizator al aplicației.     *
 *               Conține informații precum username, IBAN, rol și sold.  *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify *
 *  it under the terms of the GNU General Public License as published by *
 *  the Free Software Foundation. This program is distributed in the     *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even  *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR  *
 *  PURPOSE. See the GNU General Public License for more details.        *
 *                                                                        *
 **************************************************************************/


using System.ComponentModel.DataAnnotations;

namespace BankApp.Data
{
    /// <summary>
    /// Reprezintă un utilizator al aplicației bancare (client sau administrator).
    /// </summary>
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string FullName { get; set; }
        public string Role { get; set; }
        public string IBAN { get; set; }
        public decimal Balance { get; set; }
    }
}
