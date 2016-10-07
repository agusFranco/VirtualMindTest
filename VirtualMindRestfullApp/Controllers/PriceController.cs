using Infrastructure.Interfaces;
using Swashbuckle.Swagger.Annotations;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace VirtualMindRestfullApp.Controllers
{
    [RoutePrefix("api/Cotizacion")]
    public class PriceController : ApiController
    {
        private readonly ICurrencyService _CurrencyService;

        public PriceController(ICurrencyService currencyService)
        {
            this._CurrencyService = currencyService;
        }                

        [HttpGet]
        [Route("{currency}")]
        [Description("Get the Exchange Rate for specified currency")]  
        [ResponseType(typeof(HttpResponseMessage))]
        [SwaggerResponse(HttpStatusCode.OK, "OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Incorrect Currency")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Unauthorized")]
        // GET: api/Cotization/Dolar
        public IHttpActionResult Get(string currency)
        {
            if (string.IsNullOrEmpty(currency) || !(_CurrencyService.SetCurrency(currency)))
            {
                return BadRequest("La moneda ingresada es incorrecta");
            }

            var response = _CurrencyService.GetExchangeRate();

            return ResponseMessage(response);
        }

        [HttpPost]
        [Route("")] 
        [ResponseType(typeof(HttpResponseMessage))]
        [SwaggerResponse(HttpStatusCode.OK, "OK")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Not Found")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Unauthorized")]
        // GET: api/Cotization/Dolar
        public IHttpActionResult Post()
        {
            return NotFound();
        }

        [HttpDelete]
        [Route("")]
        [ResponseType(typeof(HttpResponseMessage))]
        [SwaggerResponse(HttpStatusCode.OK, "OK")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Not Found")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Unauthorized")]
        // GET: api/Cotization/Dolar
        public IHttpActionResult Delete()
        {
            return NotFound();
        }

        [HttpPut]
        [Route("")]
        [ResponseType(typeof(HttpResponseMessage))]
        [SwaggerResponse(HttpStatusCode.OK, "OK")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Not Found")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Unauthorized")]
        // GET: api/Cotization/Dolar
        public IHttpActionResult Put()
        {
            return NotFound();
        }
    }
}
