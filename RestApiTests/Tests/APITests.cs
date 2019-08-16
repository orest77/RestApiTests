using System;
using NUnit.Framework;
using RestApiTests.Logic;
using RestApiTests.Tool;
using RestSharp;

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
            ApiMethods _client = new ApiMethods();
            string name = "admin"; 
            string password = "qwerty";
            string passwordNew = "qwerty1";
            int SetCoolDownTime = 250000;
            int newTokenLifeTime = 500000;

            var response = _client.GetLoginedAdmins();

            Console.WriteLine("Text/ {0}/{1}/",response.Key ,response.Value);
        }

    }
}
