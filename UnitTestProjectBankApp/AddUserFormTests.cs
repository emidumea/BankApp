using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankApp.Data;
using BankApp.Data.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProjectBankApp
{
    [TestClass]
    public class AddUserFormTests
    {
        private AppDbContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("AddUserTestDb")
                .Options;

            _context = new AppDbContext(options);

            // Seed user
            _context.Users.Add(new User
            {
                Username = "existing",
                Password = "Pass1234",
                FullName = "Exist User",
                IBAN = "ROEXIST00001",
                Balance = 500,
                Role = "User"
            });
            _context.SaveChanges();
        }

        [TestMethod]
        public void AddUser_ValidUser_ShouldAddToDatabase()
        {
            var user = new User
            {
                Username = "newuser",
                Password = "Pass1234",
                FullName = "New User",
                IBAN = "RO1234567890",
                Balance = 100,
                Role = "User"
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            var addedUser = _context.Users.FirstOrDefault(u => u.Username == "newuser");
            Assert.IsNotNull(addedUser);
            Assert.AreEqual("New User", addedUser.FullName);
        }

        [TestMethod]
        public void AddUser_DuplicateUsername_ShouldFail()
        {

            var existingUser = new User
            {
                Username = "existing",
                Password = "Password1",
                FullName = "First User",
                IBAN = "ROEXIST0001",
                Balance = 100,
                Role = "User"
            };
            _context.Users.Add(existingUser);
            _context.SaveChanges();

            var duplicateUser = new User
            {
                Username = "existing",
                Password = "AnotherPass1",
                FullName = "Duplicate User",
                IBAN = "ROEXIST0002",
                Balance = 50,
                Role = "User"
            };

            try
            {
                _context.Users.Add(duplicateUser);
                _context.SaveChanges();

                Assert.Fail("S-a adăugat un utilizator cu username.");
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void AddUser_DuplicateIBAN_ShouldFail()
        {
            var duplicateIBANUser = new User
            {
                Username = "ibanuser",
                Password = "SomePass1",
                FullName = "IBAN Duplicate",
                IBAN = "ROEXIST00001", // IBAN-ul deja există din Setup()
                Balance = 150,
                Role = "User"
            };

            try
            {
                _context.Users.Add(duplicateIBANUser);
                _context.SaveChanges();

                Assert.Fail("S-a adăugat un utilizator cu IBAN duplicat.");
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                Assert.IsTrue(true);
            }
        }


        [TestMethod]
        public void AddUser_NegativeBalance_ShouldFailValidation()
        {
            var user = new User
            {
                Username = "neguser",
                Password = "ValidPass1",
                FullName = "Negative Balance",
                IBAN = "RONEGATIVE0001",
                Balance = -100,
                Role = "User"
            };
            // aaa

            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(user);
            var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(
                user, validationContext, validationResults, validateAllProperties: true);

            Assert.IsFalse(isValid, "Sold negativ");
        }


    }
}
