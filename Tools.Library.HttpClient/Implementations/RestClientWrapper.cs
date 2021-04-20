using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Tools.Library.HttpClient.Abstractions;
using Tools.Library.HttpClient.Exceptions;

namespace Tools.Library.HttpClient.Implementations
{
    public class RestClientWrapper : ICustomHttpWrapper
    {
        private readonly RestClient httpClient = new RestClient();

        public RestClientWrapper(string baseUrl)
        {
            if (string.IsNullOrEmpty(baseUrl))
                throw new ArgumentException("Base url is required", nameof(baseUrl));
            this.httpClient.BaseUrl = new Uri(baseUrl);
        }
        
        public async Task<TReturnType> MakeJsonPostRequestAsync<TReturnType, TRequestType>(
            TRequestType requestBody, string resourcePath)
        {
            var request = new RestRequest(Method.POST);
            var serializedBody = JsonConvert.SerializeObject(requestBody);
            request.AddParameter("application/json", serializedBody, ParameterType.RequestBody);
            // TODO: Move to configuration starts here
            
            request.AddHeader("User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) screenmeter/3.5.3 Chrome/80.0.3987.158 Electron/8.2.0 Safari/537.36");
            
            //TODO: Move to configuration ends here
            request.Resource = resourcePath;
            var response = await this.httpClient.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<TReturnType>(response.Content);
            }

            throw new HttpRequestException($"Request failed", new HttpLevelException(response));
        }

        public async Task MakeJsonPutRequestAsync(byte[] requestBody, string fullConfiguredPath)
        {
            var request = new RestRequest(Method.PUT);
            
            request.AddParameter("binary/octet-stream", requestBody, ParameterType.RequestBody);
            // TODO: Move to configuration starts here
            
            request.AddHeader("User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) screenmeter/3.5.3 Chrome/80.0.3987.158 Electron/8.2.0 Safari/537.36");

            //TODO: Move to configuration ends here

            request.Resource = fullConfiguredPath;
            var response = await this.httpClient.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return;
            }

            throw new HttpRequestException($"Request failed", new HttpLevelException(response));
        }
    }
}