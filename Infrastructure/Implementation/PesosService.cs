using Infrastructure.Interfaces;
using System.Net.Http;

namespace Infrastructure.Implementation
{
    public class PesosService : IExchangeRateService
    {       
        /// <summary>
        /// Gets the ExchangeRate
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetExchangeRate()
        {
            return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
        }
    }
}
