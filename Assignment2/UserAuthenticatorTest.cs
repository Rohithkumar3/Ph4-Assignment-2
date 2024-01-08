using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    [TestFixture]
    public class UserAuthenticatorTests
    {
        private UserAuthenticator userAuthenticator;

        [SetUp]
        public void Setup()
        {
            userAuthenticator = new UserAuthenticator();
        }

        [Test]
        public void TestUserRegistration()
        {
            string username = "Rohith";
            string password = "password123";

            bool registrationResult = userAuthenticator.RegisterUser(username, password);
            Assert.IsTrue(registrationResult);
        }
        [Test]
        public void RegisterUser_FailedRegistration_DuplicateUser()
        {
            userAuthenticator.RegisterUser("existinguser", "password");

            bool result = userAuthenticator.RegisterUser("existinguser", "newpassword");
            Assert.IsFalse(result);
        }


        [Test]
        public void TestUserLogin_ValidCredentials_ReturnsTrue()
        {
            string username = "Rohith";
            string password = "password123";

            userAuthenticator.RegisterUser(username, password);

            bool loginResult = userAuthenticator.LoginUser(username, password);

            Assert.IsTrue(loginResult);
        }

        [Test]
        public void TestUserLogin_InvalidCredentials_ReturnsFalse()
        {
            string username = "Rohith";
            string password = "password123";

            userAuthenticator.RegisterUser(username, password);

            bool loginResult = userAuthenticator.LoginUser(username, "wrongpassword");
            Assert.IsFalse(loginResult);
        }
    }
}
