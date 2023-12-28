using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KursCode.tests
{
    [TestClass]
    public class UserTests
    {
        private string GenerateRandomString(int length = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [TestMethod]
        public void Registration_WithValidCredentials_ReturnsTrue()
        {
            string Login = GenerateRandomString();
            string Password = GenerateRandomString();

            IUser userInstance = new User(Login, Password);

            bool result = userInstance.Registration();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Registration_WithEmptyLogin_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new User("", "valid_password").Registration());
        }

        [TestMethod]
        public void Registration_WithSpaceInLogin_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new User("login with space", "valid_password").Registration());
        }

        [TestMethod]
        public void Enter_WithValidCredentials_ReturnsTrue()
        {
            string Login = "Admin";
            string Password = "Admin";
            IUser userInstance = new User(Login, Password);

            bool result = userInstance.Enter();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Enter_WithInvalidPassword_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new User("existing_user", "invalid_password").Enter());
        }

        [TestMethod]
        public void Enter_WithNonExistentUser_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new User("nonexistent_user", "some_password").Enter());
        }

    }
}