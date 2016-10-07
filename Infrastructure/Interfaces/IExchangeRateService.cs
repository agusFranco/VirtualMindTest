using System.Net.Http;

namespace Infrastructure.Interfaces
{
    public interface IExchangeRateService
    {
        /// <summary>
        /// Gets the Exchange Rate for the current currency.
        /// </summary>
        /// <returns>HttpResponseMessage</returns>
        HttpResponseMessage GetExchangeRate();
    }
}
