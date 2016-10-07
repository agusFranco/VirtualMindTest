using System.Net.Http;

namespace Infrastructure.Interfaces
{
    public interface ICurrencyService
    {
        /// <summary>
        /// Gets or sets the ExchangeRateService.
        /// </summary>
        IExchangeRateService ExchangeRateService { get; set; }

        /// <summary>
        /// Sets the current currency
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        bool SetCurrency(string currency);

        /// <summary>
        /// Gets the Exchange Rate for the current currency.
        /// </summary>
        /// <returns>HttpResponseMessage</returns>
        HttpResponseMessage GetExchangeRate();
    }
}
