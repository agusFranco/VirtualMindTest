using Infrastructure.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Infrastructure
{
    [TestClass]
    public class DollarServiceTest
    {       
        private static DollarService _DollarService;

        [ClassInitialize]
        public static void SetUp(TestContext testContext)
        {         
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _DollarService = new DollarService();            
        }

        [TestMethod]
        public void DollarService_GetExchangeRate_Ok()
        {
            var response = _DollarService.GetExchangeRate();

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);          
        }        
    }
}
