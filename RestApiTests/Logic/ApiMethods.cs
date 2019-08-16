using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using RestApiTests.Date.MessageDate;


namespace RestApiTests.Logic
{
    public class ApiMethods
    {
        public string ApiUrl = "http://52.170.5.119:8080/";
        public string Name = "admin";
        public string Password = "qwerty";

        public KeyValuePair<HttpStatusCode, string> GetResponseContent(string refer, Method method,
            List<Parameter> parameters = null)
        {
            string referUrl = ApiUrl + refer;
            IRestClient client = new RestClient(referUrl);
            IRestRequest request = new RestRequest(method);

            if (parameters != null)
            {
                foreach (var currentParameter in parameters)
                {
                    request.AddParameter(currentParameter);
                }
            }

            IRestResponse response = client.Execute(request);
            return new KeyValuePair<HttpStatusCode, string>(response.StatusCode, response.Content);
        }

        public IMessage GetErrorMessage(dynamic item)
        {
            string content = "";
            try
            {
                content += item["error"];

            }
            catch
            {
                try
                {
                    content = item["error"];
                }
                catch
                {
                    content = "";
                }
            }
            return Message.Get()
                .SetMessage(content)
                .SetStatus("status")
                .Build();
        }

        public IMessage GetSuccessMessage(dynamic item)
        {
            string content = "";
            try
            {
                content += item["content"];
            }
            catch
            {
                try
                {
                    content = item["content"];
                }
                catch
                {
                    content = "";
                }

            }
            return Message.Get()
                .SetMessage(content)
                .SetStatus("true")
                .Build();
        }

        public string GetApiToken(string name, string password)
        {
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter("name", name, ParameterType.GetOrPost),
                new Parameter("password", password, ParameterType.GetOrPost)
            };

            var response = GetResponseContent("login", Method.POST, parameters);

            var item = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Value);
            return item["content"];
        }
    }
}
