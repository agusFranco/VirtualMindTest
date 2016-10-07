using Infrastructure.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Infrastructure
{
    [TestClass]
    public class CurrencyServiceTest
    {
        private static CurrencyService _CurrencyService;

        [ClassInitialize]
        public static void SetUp(TestContext testContext)
        {
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _CurrencyService = new CurrencyService();
        }

        [TestMethod]
        public void CurrencyService_SetCurrency_Pesos()
        {
            _CurrencyService.SetCurrency("Pesos");

            Assert.IsTrue(_CurrencyService.Currency.Equals("PESOS"));
        }

        [TestMethod]
        public void CurrencyService_SetCurrency_Real()
        {
            _CurrencyService.SetCurrency("Real");

            Assert.IsTrue(_CurrencyService.Currency.Equals("REAL"));
        }

        [TestMethod]
        public void CurrencyService_SetCurrency_Dolar()
        {
            _CurrencyService.SetCurrency("Dolar");

            Assert.IsTrue(_CurrencyService.Currency.Equals("DOLAR"));
        }

        [TestMethod]
        public void CurrencyService_SetCurrency_FalseCurrency()
        {
            var result = _CurrencyService.SetCurrency("False");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CurrencyService_GetExchangeRate_WithDollar()
        {
            _CurrencyService.SetCurrency("Dolar");

            var response = _CurrencyService.GetExchangeRate();

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}
