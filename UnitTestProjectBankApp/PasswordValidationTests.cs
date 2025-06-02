/**************************************************************************
 *                                                                        *
 *  File:        PasswordValidationTests.cs                              *
 *  Copyright:   (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 *  E-mail:      emilian.dumea@student.tuiasi.ro                         *
 *  Website:     https://github.com/emidumea/BankApp                     *
 *  Description: Teste unitare pentru validarea parolelor simple și      *
 *               complexe, folosind strategii diferite.                  *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify *
 *  it under the terms of the GNU General Public License as published by *
 *  the Free Software Foundation. This program is distributed in the     *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even  *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR  *
 *  PURPOSE. See the GNU General Public License for more details.        *
 *                                                                        *
 **************************************************************************/

using BankApp.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProjectBankApp
{
    [TestClass]
    public class PasswordValidationTests
    {
        [TestMethod]
        public void StrongPassword_ShouldBeValid_WhenRequirementsAreMet()
        {
            var validator = new StrongPasswordValidation();
            Assert.IsTrue(validator.IsValid("Test1234"));
        }

        [TestMethod]
        public void StrongPassword_ShouldFail_WhenTooShort()
        {
            var validator = new StrongPasswordValidation();
            Assert.IsFalse(validator.IsValid("T1a"));
        }

        [TestMethod]
        public void SimplePassword_ShouldBeValid_WhenAtLeastThreeCharacters()
        {
            var validator = new SimplePasswordValidation();
            Assert.IsTrue(validator.IsValid("abc"));
        }

        [TestMethod]
        public void SimplePassword_ShouldFail_WhenEmpty()
        {
            var validator = new SimplePasswordValidation();
            Assert.IsFalse(validator.IsValid(""));
        }
    }
}
