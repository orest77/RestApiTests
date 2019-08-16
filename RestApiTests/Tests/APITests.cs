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

            var response = _client.Login(name, password);

            Console.WriteLine("Text/ {0}/{1}",response.Key ,response.Value);
        }

    }
}
