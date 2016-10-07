using Infrastructure.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Infrastructure
{
    [TestClass]
    public class RealServiceTest
    {
        private static RealService _RealService;

        [ClassInitialize]
        public static void SetUp(TestContext testContext)
        {
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _RealService = new RealService();
        }

        [TestMethod]
        public void RealService_GetExchangeRate_Unauthorized()
        {
            var response = _RealService.GetExchangeRate();

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }
    }
}
