using System;
using NUnit.Framework;
using RestApiTests.Logic;

namespace RestApiTests.Tests
{
    [TestFixture]
    public class APITests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void TestAPILogin()
        {
            ApiMethods api = new ApiMethods();
            string token= api.GetApiToken("admin", "qwerty");
            Console.Write("Show token/ " + token.ToString());
            Assert.AreEqual(token , "sdfsdfsdsfsdfsfefsfsdf");
        }

    }
}
