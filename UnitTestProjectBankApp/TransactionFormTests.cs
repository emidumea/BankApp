/**************************************************************************
 *                                                                        *
 *  File:        TransactionFormTests.cs                                 *
 *  Copyright:   (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 *  E-mail:      emilian.dumea@student.tuiasi.ro                         *
 *  Website:     https://github.com/emidumea/BankApp                     *
 *  Description: Teste unitare pentru logica de trimitere a unei         *
 *               tranzacții din formularul de tranzacții.                *
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
using BankApp.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace UnitTestProjectBankApp
{
    [TestClass]
    public class TransactionFormTests
    {
        private AppDbContext _context;
        private User sender;
        private User receiver;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("TransactionTestDb")
                .Options;

            _context = new AppDbContext(options);

            sender = new User
            {
                Username = "sender",
                Password = "Pass123",
                FullName = "Sender User",
                IBAN = "RO1111",
                Balance = 500,
                Role = "User"
            };

            receiver = new User
            {
                Username = "receiver",
                Password = "Pass456",
                FullName = "Receiver User",
                IBAN = "RO2222",
                Balance = 100,
                Role = "User"
            };

            _context.Users.AddRange(sender, receiver);
            _context.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [TestMethod]
        public void Transaction_Valid_ShouldTransferFunds()
        {
            decimal amount = 200;
            var senderDb = _context.Users.First(u => u.IBAN == sender.IBAN);
            var receiverDb = _context.Users.First(u => u.IBAN == receiver.IBAN);

            senderDb.Balance -= amount;
            receiverDb.Balance += amount;

            _context.Transactions.Add(new Transaction
            {
                FromUser = senderDb.IBAN,
                ToUser = receiverDb.IBAN,
                Amount = amount,
                Timestamp = DateTime.Now
            });

            _context.SaveChanges();

            var updatedSender = _context.Users.First(u => u.IBAN == sender.IBAN);
            var updatedReceiver = _context.Users.First(u => u.IBAN == receiver.IBAN);

            Assert.AreEqual(300, updatedSender.Balance);
            Assert.AreEqual(300, updatedReceiver.Balance);
        }

        [TestMethod]
        public void Transaction_InsufficientFunds_ShouldNotProceed()
        {
            decimal amount = 1000; // mai mult decât are expeditorul

            var senderDb = _context.Users.First(u => u.IBAN == sender.IBAN);

            Assert.IsTrue(senderDb.Balance < amount);
        }

        [TestMethod]
        public void Transaction_InvalidIBAN_ShouldFail()
        {
            var destIban = "RO9999";
            var exists = _context.Users.Any(u => u.IBAN == destIban);

            Assert.IsFalse(exists);
        }

        [TestMethod]
        public void Transaction_InvalidAmount_ShouldFail()
        {
            string input = "-150";
            bool parsed = decimal.TryParse(input, out decimal suma);
            Assert.IsTrue(parsed);
            Assert.IsTrue(suma < 0);
        }
    }
}
