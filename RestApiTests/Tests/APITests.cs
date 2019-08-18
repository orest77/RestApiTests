using NUnit.Framework;
using RestApiTests.Logic;
using System;
using System.Net;

namespace RestApiTests.Tests
{
    [TestFixture]
    public class APITests
    {
        protected ApiMethods _client = new ApiMethods();


        [Test]
        public void LoginTest()
        {
            //Arrange
            string name = "admin";
            string password = "qwerty";
            //Act
            var result = _client.Login(name, password);
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Assert.IsNotEmpty(result.Value.ToString());
        }

        [Test]
        public void LogOutTest()
        {
            //Arrange
            string name = "admin";
            //Act
            var result = _client.LogOut(name);
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Assert.IsTrue(result.Value.ToString() == "True");
        }

        [Test]
        public void ChangePasswordTest()
        {
            //Arrange
            string oldPassword = "qwerty";
            string newPassword = "coolqwerty";
            //Act
            var result = _client.ChangePassword(oldPassword, newPassword);
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsTrue(result.Value.ToString() == "True");
        }

        [Test]
        public void GetUserNameTest()
        {
            //Arrange
            string name = "admin";
            //Act
            var result = _client.GetUserName();
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsNotEmpty(result.Value.ToString());

        }

        [Test]
        public void GetCoolDownTimeTest()
        {
            //Arrange
            string expectedResult = "1000";
            //Act
            var result = _client.GetCoolDownTime();
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.AreEqual(result.Value.ToString(), expectedResult);
        }

        [Test]
        public void GetTokenLifeTimeTest()
        {
            //Arrange
            string expectedResult = "1000";
            //Act
            var result = _client.GetTokenLifeTime();
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.AreEqual(result.Value.ToString(), expectedResult);
        }

        [Test]
        public void SetCoolDownTimeTest()
        {
            //Arrange
            int newCoolDownTime = 200000;
            //Act
            var result = _client.SetCoolDownTime(newCoolDownTime);
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsTrue(result.Value.ToString() == "True");
        }

        [Test]
        public void SetTokenLifeTimeTest()
        {
            //Arrange
            int newTokenLifeTime = 400000;
            //Act
            var result = _client.SetTokenLifeTime(newTokenLifeTime);
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsTrue(result.Value.ToString() == "True");
        }

        [Test]
        public void CreateUserTest()
        {
            //Arrange
            string newName = "Orest";
            string newPassword = "qwerty1";
            bool adminRights = true;
            //Act
            var result = _client.CreateUser(newName, newPassword, adminRights);
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsTrue(result.Value.ToString() == "True");
        }

        [Test]
        public void RemoveUserTest()
        {
            //Arrange
            string removedName = "Orest";
            //Act
            var result = _client.RemoveUser(removedName);
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsTrue(result.Value.ToString() == "True");
        }

        [Test]
        public void GetAllAdminsTest()
        {
            //Arrange
            string name = "admin";
            //Act
            var result = _client.GetAllAdmins();
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsTrue(result.Value.ToString().Contains(name));
        }

        [Test]
        public void GetLoginedAdminsTest()
        {
            //Arrange
            string loginedAdmin = "admin";
            //Act
            var result = _client.GetLoginedAdmins();
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsNotEmpty(result.Value.ToString());
        }

        [Test]
        public void GetLockedAdminsTest()
        {
            //Arrange
            string loginedAdmin = "admin";

            //Act
            var result = _client.GetLockedAdmins();
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsNotEmpty(result.Value.ToString());
        }

        [Test]
        public void GetAllUsersTest()
        {
            //Arrange
          
            //Act
            var result = _client.GetAllUsers();
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsNotNull(result.Value.ToString());
        }

        
        [Test]
        public void GetLoginedUsersTest()
        {
            //Arrange
          
            //Act
            var result = _client.GetLoginedUsers();
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsNotEmpty(result.Value.ToString());
        }

        [Test]
        public void GetAliveTockensTest()
        {
            //Arrange
          
            //Act
            var result = _client.GetAliveTockens();
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsNotEmpty(result.Value.ToString());
        }

        [Test]
        public void GetLockedUsersTest()
        {
            //Arrange
          
            //Act
            var result = _client.GetLockedUsers();
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsNotEmpty(result.Value.ToString());
        }

        [Test]
        public void LockUserTest()
        {
            //Arrange
            string name = "admin";
            //Act
            var result = _client.LockUser(name);
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsTrue(result.Value.ToString() == "True");
        }

        [Test]
        public void UnlockUserTest()
        {
            //Arrange
            string name = "admin";
            //Act
            var result = _client.UnlockUser(name);
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsTrue(result.Value.ToString() == "True");
        }

        [Test]
        public void UnlockAllUsersTest()
        {
            //Arrange
          
            //Act
            var result = _client.UnlockAllUsers();
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsTrue(result.Value.ToString() == "True");
        }

        [Test]
        public void GetUserItemsTest()
        {
            //Arrange
            string name = "admin";
            //Act
            var result = _client.GetUserItems(name);
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsNotEmpty(result.Value.ToString());
        }

        [Test]
        public void GetUserItemTest()
        {
            //Arrange
            string name = "admin";
            int index = 2;
            //Act
            var result = _client.GetUserItem(name, index);
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsNotEmpty(result.Value.ToString());
        }

        [Test]
        public void AddItemTest()
        {
            //Arrange
            string item = "phone";
            int index = 3;
            //Act
            var result = _client.AddItem(item, index);
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsNotEmpty(result.Value.ToString());
        }

        [Test]
        public void DeleteItemTest()
        {
            //Arrange
            int index = 2;
            //Act
            var result = _client.DeleteItem(index);
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsNotEmpty(result.Value.ToString());
        }

        [Test]
        public void UpdateItemTest()
        {
            //Arrange
            string item = "notebook";
            int index = 2;
            //Act
            var result = _client.UpdateItem(index, item);
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsNotEmpty(result.Value.ToString());
        }

        [Test]
        public void GetAllItemsTest()
        {
            //Arrange
          
            //Act
            var result = _client.GetAllItems();
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsNotEmpty(result.Value.ToString());
        }

        [Test]
        public void GetAllItemsIndexesTest()
        {
            //Arrange
          
            //Act
            var result = _client.GetAllItemsIndexes();
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsNotEmpty(result.Value.ToString());
        }

        [Test]
        public void GetItemTest()
        {
            //Arrange
            int index = 2;
            //Act
            var result = _client.GetItem(index);
            //Assert
            Assert.AreEqual(result.Key, HttpStatusCode.OK);
            Console.WriteLine($"{result.Value}");
            Assert.IsNotEmpty(result.Value.ToString());
        }
    }
}
