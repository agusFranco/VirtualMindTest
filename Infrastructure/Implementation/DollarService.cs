using Infrastructure.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Infrastructure.Implementation
{
    public class DollarService : IExchangeRateService
    {
        private HttpClient client { get; set; }

        /// <summary>
        /// Gets the Exchange Rate.
        /// </summary>
        /// <returns>HttpResponseMessage</returns>
        public HttpResponseMessage GetExchangeRate()
        {
            using (var client = GetHttpClient())
            {
                var response = client.GetAsync("Dolar").Result;

                return response;
            }
        }

        /// <summary>
        /// Gets the HttpClient
        /// </summary>
        /// <returns>HttpClient</returns>
        private HttpClient GetHttpClient()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri("http://www.bancoprovincia.com.ar/Principal/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
