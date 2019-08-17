using RestApiTests.Tool;
using RestSharp;
using System.Collections.Generic;
using System.Net;


namespace RestApiTests.Logic
{
    public class ApiMethods : ApiBase
    {
        public object ApiToken => Login("admin", "qwerty").Value;

        //Post Method for login test. If API test is success then Method get API token
        public  KeyValuePair<HttpStatusCode, object> Login(string userName, string password)
        {
            IRestRequest request = BuildPostMethod("login");
            request.AddOrUpdateParameter("name", userName);
            request.AddOrUpdateParameter("password", password);
            IRestResponse response = SendRequest(request); 
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        //Post Methods for logout test. If Api test success then will be return True or False
        public KeyValuePair<HttpStatusCode, object> LogOut(string userName)
        {
            IRestRequest request = BuildPostMethod("logout");
            request.AddOrUpdateParameter("name", userName);
            request.AddOrUpdateParameter("token", ApiToken);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        //Put Methods for Change Password test. If Api test success then will be return True or False
        public KeyValuePair<HttpStatusCode, object> ChangePassword(string oldPassword, string newPassword)
        {
            IRestRequest request = BuildPutMethod("user");
            request.AddOrUpdateParameter("token", ApiToken);
            request.AddOrUpdateParameter("oldPassword", oldPassword);
            request.AddOrUpdateParameter("newPassword", newPassword);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        //Get Method for get user name. Will return names or empty string 
        public KeyValuePair<HttpStatusCode, object> GetUserName()
        {
            IRestRequest request = BuildGetMethod("user");
            request.AddOrUpdateParameter("token", ApiToken);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        //Get Cool Down Time don't have any parameters only response, how many many seconds
        public KeyValuePair<HttpStatusCode, object> GetCoolDownTime()
        {
            IRestRequest request = BuildGetMethod("cooldowntime");
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        public KeyValuePair<HttpStatusCode, object> GetTokenLifeTime()
        {
            IRestRequest request = BuildGetMethod("tokenlifetime");
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        //Put set Cool Down Time. If test OK than will get true
        public KeyValuePair<HttpStatusCode, object> SetCoolDownTime(int newCoolDownTime)
        {
            IRestRequest request = BuildPutMethod("cooldowntime");
            request.AddOrUpdateParameter("token",ApiToken);
            request.AddOrUpdateParameter("newTokenLifeTime", newCoolDownTime);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        //Put Set Token Life Time. If success test then will get True 
        public KeyValuePair<HttpStatusCode, object> SetTokenLifeTime(int newTokenLifeTime)
        {
            IRestRequest request = BuildPutMethod("tokenlifetime");
            request.AddOrUpdateParameter("token", ApiToken);
            request.AddOrUpdateParameter("newTokenLifeTime", newTokenLifeTime);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }
        //POST method create user /
        public KeyValuePair<HttpStatusCode, object> CreateUser(string newName, string newPassword,bool adminRights)
        {
            IRestRequest request = BuildPostMethod("user");
            request.AddOrUpdateParameter("token",ApiToken);
            request.AddOrUpdateParameter("newName", newName);
            request.AddOrUpdateParameter("newPassword", newPassword);
            request.AddOrUpdateParameter("adminRights", adminRights);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        //Delete method delete user / If success test then will get True or false
        public KeyValuePair<HttpStatusCode, object> RemoveUser(string removedName)
        {
            IRestRequest request = BuildDeleteMethod("user");
            request.AddOrUpdateParameter("token", ApiToken);
            request.AddOrUpdateParameter("newName", removedName);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        //Get all admins
        public KeyValuePair<HttpStatusCode, object> GetAllAdmins()
        {
            IRestRequest request = BuildGetMethod("admins");
            request.AddOrUpdateParameter("token", ApiToken);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        public KeyValuePair<HttpStatusCode, object> GetLoginedAdmins()
        {
            IRestRequest request = BuildGetMethod("login/admins");
            request.AddOrUpdateParameter("token",ApiToken);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        public KeyValuePair<HttpStatusCode, object> GetLockedAdmins()
        {
            IRestRequest request = BuildGetMethod("locked/admins");
            request.AddOrUpdateParameter("token", ApiToken);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        public KeyValuePair<HttpStatusCode, object> GetAllUsers()
        {
            IRestRequest request = BuildGetMethod("users");
            request.AddOrUpdateParameter("token", ApiToken);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        public KeyValuePair<HttpStatusCode, object> GetLoginedUsers()
        {
            IRestRequest request = BuildGetMethod("login/users");
            request.AddOrUpdateParameter("token", ApiToken);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        public KeyValuePair<HttpStatusCode, object> GetAliveTockens()
        {
            IRestRequest request = BuildGetMethod("login/tockens");
            request.AddOrUpdateParameter("token", ApiToken);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        public KeyValuePair<HttpStatusCode, object> GetLockedUsers()
        {
            IRestRequest request = BuildGetMethod("locked/users");
            request.AddOrUpdateParameter("token", ApiToken);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        //Post method search user
        public KeyValuePair<HttpStatusCode, object> LockUser(string name)
        {
            IRestRequest request = BuildPostMethod($"locked/user/{name}");
            request.AddOrUpdateParameter("token",ApiToken);
            request.AddOrUpdateParameter("name", name);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        //Methods Put
        public KeyValuePair<HttpStatusCode, object> UnlockUser(string name)
        {
            IRestRequest request = BuildPutMethod($"locked/user/{name}");
            request.AddOrUpdateParameter("token", ApiToken);
            request.AddOrUpdateParameter("name", name);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        public KeyValuePair<HttpStatusCode, object> UnlockAllUsers()
        {
            IRestRequest request = BuildPutMethod("locked/reset");
            request.AddOrUpdateParameter("token", ApiToken);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        //Get method user items
        public KeyValuePair<HttpStatusCode, object> GetUserItems(string name)
        {
            IRestRequest request = BuildGetMethod($"item/user/{name}");
            request.AddOrUpdateParameter("token", ApiToken);
            request.AddOrUpdateParameter("name", name);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        //
        public KeyValuePair<HttpStatusCode, object> GetUserItem(string name, int index)
        {
            IRestRequest request = BuildGetMethod($"item/{index}/user/{name}");
            request.AddOrUpdateParameter("token", ApiToken);
            request.AddOrUpdateParameter("name", name);
            request.AddOrUpdateParameter("index", index);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        //Method POST ADD Item
        public KeyValuePair<HttpStatusCode, object> AddItem(string item, int index)
        {
            IRestRequest request = BuildPostMethod($"item/{index}");
            request.AddOrUpdateParameter("token", ApiToken);
            request.AddOrUpdateParameter("item", item);
            request.AddOrUpdateParameter("index", index);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        //Method Delete  Item
        public KeyValuePair<HttpStatusCode, object> DeleteItem(int index)
        {
            IRestRequest request = BuildDeleteMethod($"item/{index}");
            request.AddOrUpdateParameter("token", Login("admin","qwerty").Value);
            request.AddOrUpdateParameter("index", index);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        //
        public KeyValuePair<HttpStatusCode, object> UpdateItem(int index,string item)
        {
            IRestRequest request = BuildPutMethod($"item/{index}");
            request.AddOrUpdateParameter("token", Login("admin","qwerty").Value);
            request.AddOrUpdateParameter("index", index);
            request.AddOrUpdateParameter("item", item);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        //
        public KeyValuePair<HttpStatusCode, object> GetAllItems()
        {
            IRestRequest request = BuildGetMethod("items");
            request.AddOrUpdateParameter("token", Login("admin","qwerty").Value);
           
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        //
        public KeyValuePair<HttpStatusCode, object> GetAllItemsIndexes()
        {
            IRestRequest request = BuildGetMethod("itemindexes");
            request.AddOrUpdateParameter("token", Login("admin","qwerty").Value);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }

        //
        public KeyValuePair<HttpStatusCode, object> GetItem(int index)
        {
            IRestRequest request = BuildGetMethod($"item/{index}");
            request.AddOrUpdateParameter("token", Login("admin","qwerty").Value);
            request.AddOrUpdateParameter("index", index);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }
    }
}
