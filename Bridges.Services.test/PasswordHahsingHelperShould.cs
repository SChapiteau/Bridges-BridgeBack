using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Services.test
{
    [TestClass]
    public class PasswordHahsingHelperShould
    {
        [TestMethod]
        public void Return_EncryptedPassword_When_HashPassword()
        {
            string password = "motdepassetest";
            string hashedPassword = PasswordHahsingHelper.HashPassword(password);

            Assert.AreNotEqual(password, hashedPassword);
        }

        [TestMethod]
        public void Return_True_When_Validete_Good_Password()
        {
            string password = "motdepassetest";
            string hashedPassword = PasswordHahsingHelper.HashPassword(password);

            Assert.IsTrue(PasswordHahsingHelper.ValidatePassword(password, hashedPassword));
        }

        [TestMethod]
        public void Return_False_When_Validete_Bad_Password()
        {
            string password = "goodPassword";
            string hashedPassword = PasswordHahsingHelper.HashPassword(password);

            Assert.IsFalse(PasswordHahsingHelper.ValidatePassword("BadPassword", hashedPassword));
        }
    }
}
