using Newtonsoft.Json;
using RestSharp;

namespace RestApiTests.Tool
{
    public class ApiBase
    {
        private static RestClient _client;

        public ApiBase()
        {
            _client = new RestClient("http://52.170.5.119:8080/");
        }

        public ApiBase(string serverUrl)
        {
            _client = new RestClient(serverUrl);
        }

        protected IRestRequest BuildPostMethod(string resource)
        {
            IRestRequest request = new RestRequest(Method.POST);
            request.Resource = resource;
            return request;
        }

        protected IRestRequest BuildGetMethod(string resource)
        {
            IRestRequest request = new RestRequest(Method.GET);
            request.Resource = resource;
            return request;
        }

        protected IRestRequest BuildPutMethod(string resource)
        {
            IRestRequest request = new RestRequest(Method.PUT);
            request.Resource = resource;
            return request;
        }

        protected IRestRequest BuildDeleteMethod(string resource)
        {
            IRestRequest request = new RestRequest(Method.DELETE);
            request.Resource = resource;
            return request;
        }

        protected IRestResponse SendRequest(IRestRequest request)
        {
            return _client.Execute(request);
        }

        protected dynamic DeserializeResponse(IRestResponse response)
        {
            dynamic jsonValue = JsonConvert.DeserializeObject<object>(response.Content);
            return  jsonValue;
        }
    }
}
