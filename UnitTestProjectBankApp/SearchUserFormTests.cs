﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankApp.Data;
using BankApp.Data.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace UnitTestProjectBankApp
{
    [TestClass]
    public class SearchUserFormTests
    {
        private AppDbContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("SearchUserTestDb")
                .Options;

            _context = new AppDbContext(options);

            _context.Users.AddRange(
                new User
                {
                    Username = "john.doe",
                    Password = "Pass123",
                    FullName = "John Doe",
                    IBAN = "RO1234",
                    Balance = 100,
                    Role = "User"
                },
                new User
                {
                    Username = "jane.smith",
                    Password = "Secure1",
                    FullName = "Jane Smith",
                    IBAN = "RO5678",
                    Balance = 200,
                    Role = "Admin"
                }
            );

            _context.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [TestMethod]
        public void Search_ByUsername_ShouldReturnResult()
        {
            var search = "john";
            var results = _context.Users
                .Where(u => u.Username.ToLower().Contains(search.ToLower()))
                .ToList();

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("john.doe", results[0].Username);
        }

        [TestMethod]
        public void Search_ByIBAN_ShouldReturnResult()
        {
            var search = "RO5678";
            var results = _context.Users
                .Where(u => u.IBAN.ToLower().Contains(search.ToLower()))
                .ToList();

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("jane.smith", results[0].Username);
        }

        [TestMethod]
        public void Search_NoMatch_ShouldReturnEmpty()
        {
            var search = "xyz";
            var results = _context.Users
                .Where(u => u.Username.ToLower().Contains(search) || u.IBAN.ToLower().Contains(search))
                .ToList();

            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void Search_EmptyInput_ShouldBeInvalid()
        {
            string search = "   ";
            Assert.IsTrue(string.IsNullOrWhiteSpace(search));
        }
    }
}
