using System;
using WebShop.Logic;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestCreateUser()
        {
            string mail = GetRandomText(8);
            UserManager.Create(mail, "name", "pass");

            var user = UserManager.GetByEmail(mail);

            Assert.NotNull(user);
            Assert.Equal(user.Email, mail);
        }

        public static string GetRandomText(int maxLength)
        {
            return Guid.NewGuid().ToString("N").Substring(0, maxLength);
        }
    }
}
