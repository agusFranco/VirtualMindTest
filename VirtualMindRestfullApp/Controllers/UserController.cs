using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Domain;
using Infrastructure.Interfaces;
using Swashbuckle.Swagger.Annotations;
using VirtualMindRestfullApp.Models;

namespace VirtualMindRestfullApp.Controllers
{
    [RoutePrefix("api/Usuarios")]
    public class UserController : ApiController
    {
        private readonly IUserService _UserService;
        public UserController(IUserService userService)
        {
            this._UserService = userService;
        }

        [Route("{id}")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, "OK")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User not found")]
        // GET: api/Usuarios/5
        public IHttpActionResult Get(int id)
        {
            var result = _UserService.Get(id);

            if (result != null)
                return Ok(result);

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "Usuario no encontrado"));
        }

        [Route("")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, "OK")]
        // GET: api/Usuarios
        public IHttpActionResult Get()
        {
            var result = _UserService.GetAll();

            return Ok(result);
        }

        // POST: api/Usuarios
        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Internal Server Error")]
        public IHttpActionResult Post(UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                var errors = GetErrors(ModelState);
                return BadRequest(string.Join(" | ", errors.ToArray()));
            }

            User user = new User();

            userDTO.ApplyTo(user);

            var response = _UserService.Post(user);

            return ResponseMessage(response);
        }

        [HttpPut]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Internal Server Error")]
        // PUT: api/Usuario/5
        public IHttpActionResult Put(UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                var errors = GetErrors(ModelState);
                return BadRequest(string.Join(" | ", errors.ToArray()));
            }

            User user = new User();

            userDTO.ApplyTo(user);

            var response = _UserService.Put(user);

            return ResponseMessage(response);
        }

        // DELETE: api/User/5
        [Route("{id}")]
        [HttpDelete]
        [SwaggerResponse(HttpStatusCode.OK, "OK")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User not found")]
        public IHttpActionResult Delete(int id)
        {
            var response = _UserService.Delete(id);

            return ResponseMessage(response);
        }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <param name="modelState">State of the model.</param>
        /// <returns></returns>
        private string[] GetErrors(ModelStateDictionary modelState)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                                      .Where(u => u.ErrorMessage != string.Empty)
                                      .Select(e => e.ErrorMessage).ToList();

            var exceptions = ModelState.Values.SelectMany(v => v.Errors)
                                            .Where(u => u.Exception != null)
                                            .Select(e => e.Exception.Message).ToList();

            errors.AddRange(exceptions);

            return errors.ToArray();
        }
    }
}
