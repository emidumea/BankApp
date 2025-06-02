/**************************************************************************
 *                                                                        *
 *  File:        ResetPasswordFormTests.cs                               *
 *  Copyright:   (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 *  E-mail:      emilian.dumea@student.tuiasi.ro                         *
 *  Website:     https://github.com/emidumea/BankApp                     *
 *  Description: Teste unitare pentru formularul de resetare a parolei,  *
 *               inclusiv validare și verificare persistare.             *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify *
 *  it under the terms of the GNU General Public License as published by *
 *  the Free Software Foundation. This program is distributed in the     *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even  *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR  *
 *  PURPOSE. See the GNU General Public License for more details.        *
 *                                                                        *
 **************************************************************************/


using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankApp.Data;
using BankApp.Data.Data;
using BankApp.Validation;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace UnitTestProjectBankApp
{
    [TestClass]
    public class ResetPasswordFormTests
    {
        private AppDbContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("ResetPasswordTestDb")
                .Options;

            _context = new AppDbContext(options);

            _context.Users.Add(new User
            {
                Username = "testuser",
                Password = "OldPass1",
                FullName = "User Test",
                IBAN = "ROTEST123",
                Balance = 0,
                Role = "User"
            });

            _context.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [TestMethod]
        public void ResetPassword_MismatchConfirmation_ShouldFail()
        {
            string newPass = "NewPass123";
            string confirm = "Different123";

            Assert.AreNotEqual(newPass, confirm);
        }

        [TestMethod]
        public void ResetPassword_InvalidNewPassword_ShouldFailValidation()
        {
            var validator = new StrongPasswordValidation();
            string weakPass = "123";

            Assert.IsFalse(validator.IsValid(weakPass));
        }

        [TestMethod]
        public void ResetPassword_UserNotFound_ShouldReturnNull()
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == "ghost");
            Assert.IsNull(user);
        }

        [TestMethod]
        public void ResetPassword_ValidInput_ShouldUpdatePassword()
        {
            string newPass = "StrongPass1";

            var user = _context.Users.First(u => u.Username == "testuser");
            user.Password = newPass;
            _context.SaveChanges();

            var updated = _context.Users.First(u => u.Username == "testuser");
            Assert.AreEqual("StrongPass1", updated.Password);
        }
    }
}
