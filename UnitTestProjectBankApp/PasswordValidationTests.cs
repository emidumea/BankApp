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
