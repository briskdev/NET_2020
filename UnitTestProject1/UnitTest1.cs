using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebShop.Logic;
using WebShop.Logic.DB;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateUser()
        {
            string mail = GetRandomText(8);
            UserManager.Create(mail, "name", "pass");

            var user = UserManager.GetByEmail(mail);

            Assert.IsNotNull(user);
            Assert.AreEqual(user.Email, mail);
        }

        public static string GetRandomText(int maxLength)
        {
            return Guid.NewGuid().ToString("N").Substring(0, maxLength);
        }
    }
}
