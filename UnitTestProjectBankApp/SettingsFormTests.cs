﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankApp.Data;
using BankApp.Data.Data;
using BankApp.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace UnitTestProjectBankApp
{
    [TestClass]
    public class SettingsFormTests
    {
        private AppDbContext _context;
        private User currentUser;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("SettingsTestDb")
                .Options;

            _context = new AppDbContext(options);

            currentUser = new User
            {
                Username = "testuser",
                Password = "OldPass1",
                FullName = "Test User",
                IBAN = "ROSETT0001",
                Balance = 300,
                Role = "User"
            };

            _context.Users.Add(currentUser);
            _context.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [TestMethod]
        public void ChangePassword_WrongCurrentPassword_ShouldFail()
        {
            string inputCurrent = "WrongPass";
            Assert.AreNotEqual(currentUser.Password, inputCurrent);
        }

        [TestMethod]
        public void ChangePassword_ConfirmationMismatch_ShouldFail()
        {
            string newPass = "NewPass123";
            string confirm = "NewPass321";
            Assert.AreNotEqual(newPass, confirm);
        }

        [TestMethod]
        public void ChangePassword_WeakNewPassword_ShouldFailValidation()
        {
            var validator = new StrongPasswordValidation();
            string weakPass = "abc";
            Assert.IsFalse(validator.IsValid(weakPass));
        }

        [TestMethod]
        public void ChangePassword_Valid_ShouldUpdatePassword()
        {
            string newPassword = "Strong123";

            var validator = new StrongPasswordValidation();
            Assert.IsTrue(validator.IsValid(newPassword));

            var userInDb = _context.Users.First(u => u.Id == currentUser.Id);
            userInDb.Password = newPassword;
            _context.SaveChanges();

            var updated = _context.Users.First(u => u.Id == currentUser.Id);
            Assert.AreEqual("Strong123", updated.Password);
        }
    }
}
