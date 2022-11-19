using RestSharp;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SeleniumFramework.APIRestSharp
{
    public class RestSharpHelper
    {
        private RestClient client;
        private RestRequest request;

        public RestClient SetURL(string baseUrl, string endpoint)
        {
            string url = Path.Combine(baseUrl, endpoint);
            using (RestClient client = new(url))
            {
                return client;
            }
        }

        public RestRequest CreateGetRequest()
        {
            request = new RestRequest()
            {
                Method = Method.Get
            };
            request.AddHeaders(new Dictionary<string, string>
            {
                { "Accept", "application/json" },
                { "Content-Type", "application/json" }

            });
            return request;
        }

        public RestRequest CreatePostRequest<T>(T payload) where T : class
        {
            request = new RestRequest()
            {
                Method = Method.Post
            };
            request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("application/json", payload, ParameterType.RequestBody);
            request.AddBody(payload);
            request.RequestFormat = DataFormat.Json;
            return request;
        }

        public RestRequest CreatePutRequest<T>(T payload) where T : class
        {
            request = new RestRequest()
            {
                Method = Method.Put
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", payload, ParameterType.RequestBody);
            request.AddBody(payload);
            request.RequestFormat = DataFormat.Json;
            return request;
        }

        public RestRequest CreateDeleteRequest()
        {
            request = new RestRequest()
            {
                Method = Method.Delete
            };
            request.AddHeader("Content-Type", "application/json");
            return request;
        }

        public async Task<RestResponse> GetResponseAsync(RestClient restClient, RestRequest restRequest)
        {
            return await restClient.ExecuteAsync(restRequest);
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
