using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankApp.Data.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BankApp.Data;

namespace UnitTestProjectBankApp.Tests
{
    [TestClass]
    public class LoginFormTests
    {
        private AppDbContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "LoginTestDb")
                .Options;

            _context = new AppDbContext(options);

            _context.Users.AddRange(
                new User { Username = "testuser", Password = "pass1234", Role = "User" },
                new User { Username = "admin", Password = "admin123", Role = "Admin" }
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
        public void Login_ValidUser_ReturnsUser()
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == "testuser" && u.Password == "pass1234");
            Assert.IsNotNull(user);
            Assert.AreEqual("testuser", user.Username);
        }

        [TestMethod]
        public void Login_InvalidUser_ReturnsNull()
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == "invalid" && u.Password == "wrongpass");
            Assert.IsNull(user);
        }
    }
}
