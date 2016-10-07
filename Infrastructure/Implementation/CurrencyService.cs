using Infrastructure.Interfaces;
using System.Net.Http;

namespace Infrastructure.Implementation
{
    public class CurrencyService : ICurrencyService
    {
        private const string DOLAR = "DOLAR";
        private const string PESOS = "PESOS";
        private const string REAL = "REAL";

        /// <summary>
        /// Gets or sets the Exchange rate service
        /// </summary>
        public IExchangeRateService ExchangeRateService { get; set; }

        /// <summary>
        /// Gets or sets the currency
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Sets the current currency
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        public bool SetCurrency(string currency)
        {
            currency = currency.ToUpper();

            if (currency.Equals(DOLAR))
            {
                this.ExchangeRateService = new DollarService();
                this.Currency = DOLAR;
                return true;
            }

            if (currency.Equals(PESOS))
            {
                this.ExchangeRateService = new PesosService();
                this.Currency = PESOS;
                return true;
            }

            if (currency.Equals(REAL))
            {
                this.ExchangeRateService = new RealService();
                this.Currency = REAL;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the Exchange Rate for the current currency.
        /// </summary>
        /// <returns>HttpResponseMessage</returns>
        public HttpResponseMessage GetExchangeRate()
        {
            var result = ExchangeRateService.GetExchangeRate();   

            return result;
        }
    }
}

