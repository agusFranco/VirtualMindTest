using Infrastructure.Interfaces;
using System.Net.Http;

namespace Infrastructure.Implementation
{
    public class RealService : IExchangeRateService
    {
        /// <summary>
        /// Gets the exchangeRate
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetExchangeRate()
        {
            return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
        }
    }
}
