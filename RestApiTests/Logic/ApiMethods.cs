using RestApiTests.Tool;
using RestSharp;
using System.Collections.Generic;
using System.Net;


namespace RestApiTests.Logic
{
    public class ApiMethods : ApiBase
    {
        public KeyValuePair<HttpStatusCode, object> Login(string username, string password)
        {
            IRestRequest request = BuildPostMethod("login");
            request.AddOrUpdateParameter("name", username);
            request.AddOrUpdateParameter("password", password);
            IRestResponse response = SendRequest(request);
            var jsonV = DeserializeResponse(response);
            return new KeyValuePair<HttpStatusCode, object>(response.StatusCode, jsonV["content"]);
        }
    }
}
