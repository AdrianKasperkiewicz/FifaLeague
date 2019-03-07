using System;
using System.Net.Http;

namespace FutbinService
{
    public class FutbinHttpClient
    {
        public FutbinHttpClient(HttpClient httpClient)
        {
            // TODO to settings
            httpClient.BaseAddress = new Uri("https://www.futbin.com/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            this.Client = httpClient;
        }

        public HttpClient Client { get; }
    }
}
