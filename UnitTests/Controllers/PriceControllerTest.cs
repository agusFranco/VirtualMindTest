using System.Net.Http;
using System.Web.Http.Results;
using Infrastructure.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VirtualMindRestfullApp.Controllers;

namespace UnitTests.Controllers
{
    [TestClass]
    public class PriceControllerTest
    {
        private static Mock<ICurrencyService> _CurrencyService;
        private static PriceController _PriceController;

        [ClassInitialize]
        public static void SetUp(TestContext testContext)
        {
            _CurrencyService = new Mock<ICurrencyService>();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _PriceController = new PriceController(_CurrencyService.Object);
            _CurrencyService.Reset();
            _CurrencyService.ResetCalls();
        }

        [TestMethod]
        public void PriceController_Get_BadRequest_WithStringEmpty()
        {
            _CurrencyService.Setup(x => x.SetCurrency(It.IsAny<string>())).Returns(true);

            var response = _PriceController.Get(string.Empty);

            Assert.IsTrue(response is BadRequestErrorMessageResult);
        }

        [TestMethod]
        public void PriceController_Get_BadRequest_WithWrongCurrency()
        {
            _CurrencyService.Setup(x => x.SetCurrency(It.IsAny<string>())).Returns(false);

            var response = _PriceController.Get("Guarani");

            Assert.IsTrue(response is BadRequestErrorMessageResult);
        }

        [TestMethod]
        public void PriceController_Get_Ok()
        {
            _CurrencyService.Setup(x => x.SetCurrency(It.IsAny<string>())).Returns(true);
            _CurrencyService.Setup(x => x.GetExchangeRate()).Returns(new HttpResponseMessage(System.Net.HttpStatusCode.OK));

            var response = _PriceController.Get("Dolar");

            Assert.IsTrue(response is ResponseMessageResult);
            Assert.IsTrue((response as ResponseMessageResult).Response.StatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}
