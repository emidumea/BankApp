﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankApp.Data;
using BankApp.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProjectBankApp
{
    [TestClass]
    public class TransactionHistoryFormTests
    {
        private AppDbContext _context;
        private User user;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("TransactionHistoryTestDb")
                .Options;

            _context = new AppDbContext(options);

            user = new User
            {
                Username = "testuser",
                Password = "pass",
                FullName = "Test User",
                IBAN = "RO111",
                Balance = 500,
                Role = "User"
            };

            var other = new User
            {
                Username = "receiver",
                Password = "pass2",
                FullName = "Receiver User",
                IBAN = "RO222",
                Balance = 300,
                Role = "User"
            };

            _context.Users.AddRange(user, other);
            _context.SaveChanges();

            _context.Transactions.AddRange(
                new Transaction { FromUser = "RO111", ToUser = "RO222", Amount = 100, Timestamp = DateTime.Now },
                new Transaction { FromUser = "RO222", ToUser = "RO111", Amount = 50, Timestamp = DateTime.Now }
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
        public void Filter_All_ShouldReturnBoth()
        {
            var txs = _context.Transactions
                .Where(t => t.FromUser == user.IBAN || t.ToUser == user.IBAN)
                .ToList();

            Assert.AreEqual(2, txs.Count);
        }

        [TestMethod]
        public void Filter_Sent_ShouldReturnOne()
        {
            var txs = _context.Transactions
                .Where(t => t.FromUser == user.IBAN)
                .ToList();

            Assert.AreEqual(1, txs.Count);
        }

        [TestMethod]
        public void Filter_Received_ShouldReturnOne()
        {
            var txs = _context.Transactions
                .Where(t => t.ToUser == user.IBAN)
                .ToList();

            Assert.AreEqual(1, txs.Count);
        }

        [TestMethod]
        public void Filter_EmptyHistory_ShouldReturnNone()
        {
            var txs = _context.Transactions
                .Where(t => t.FromUser == "RO000" || t.ToUser == "RO000")
                .ToList();

            Assert.AreEqual(0, txs.Count);
        }
    }
}
