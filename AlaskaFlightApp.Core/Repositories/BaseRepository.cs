using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AlaskaFlightApp.Core.Repositories
{
    public abstract class BaseRepository
    {
        public virtual string getBaseURL()
        {
            return "https://api.qa.alaskaair.net/aag/";
        }

        protected abstract string GetRequestPath();

        protected abstract HttpMethod HttpVerb { get; }

        private HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "0a4ce1ff48154b48b1b75cd6ae34e9f8");
            return httpClient;
        }

        protected async Task<T> GetAsync<T>(string url)
            where T : new()
        {
            HttpClient httpClient = CreateHttpClient();
            T result;

            try
            {
                var response = await httpClient.GetStringAsync(url);
                result = await Task.Run(() => JsonConvert.DeserializeObject<T>(response));
            }
            catch
            {
                result = new T();
            }

            return result;
        }
    }
}
