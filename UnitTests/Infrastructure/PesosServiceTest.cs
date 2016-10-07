using Infrastructure.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Infrastructure
{
    [TestClass]
    public class PesosServiceTest
    {
        private static PesosService _PesosService;

        [ClassInitialize]
        public static void SetUp(TestContext testContext)
        {
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _PesosService = new PesosService();
        }

        [TestMethod]
        public void PesosService_GetExchangeRate_Unauthorized()
        {
            var response = _PesosService.GetExchangeRate();

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }
    }
}
