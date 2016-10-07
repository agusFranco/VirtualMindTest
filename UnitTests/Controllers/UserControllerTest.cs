using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Results;
using Domain;
using Infrastructure.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VirtualMindRestfullApp.Controllers;
using VirtualMindRestfullApp.Models;

namespace UnitTests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        private static Mock<IUserService> _UserService;
        private static UserController _UserController;

        [ClassInitialize]
        public static void SetUp(TestContext testContext)
        {
            _UserService = new Mock<IUserService>();     
        }    
        
        [TestInitialize]
        public void TestInitialize()
        {
            _UserController = new UserController(_UserService.Object);
            _UserService.Reset();
            _UserService.ResetCalls();            
        }  
        
        [TestMethod]
        public void UserController_GetOne_NotFound()
        {
            _UserService.Setup(x => x.Get(It.IsAny<int>())).Returns((User)null);

            var response = _UserController.Get(1);

            Assert.IsTrue(response is NotFoundResult);            
        }

        [TestMethod]
        public void UserController_GetOne_Ok()
        {
            _UserService.Setup(x => x.Get(It.IsAny<int>())).Returns(new User());

            var response = _UserController.Get(1);

            Assert.IsTrue(response is OkNegotiatedContentResult<User>);
        }

        [TestMethod]
        public void UserController_GetAll_Ok()
        {
            _UserService.Setup(x => x.GetAll()).Returns(new List<User>());

            var response = _UserController.Get();

            Assert.IsTrue(response is OkNegotiatedContentResult<IList<User>>);
        }

        [TestMethod]
        public void UserController_Post_BadRequest()
        {
            _UserService.Setup(x => x.Post(It.IsAny<User>())).Returns(new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest));

            var user = new UserDTO()
            {
                Id = 0,
                Name = string.Empty,
                LastName = string.Empty,
                Email = string.Empty,
                Password = string.Empty
            };

            _UserController.Configuration = new System.Web.Http.HttpConfiguration();
            _UserController.Validate<UserDTO>(user);

            var response = _UserController.Post(user);        

            Assert.IsTrue(response is BadRequestErrorMessageResult);
        }

        [TestMethod]
        public void UserController_Post_Created()
        {
            _UserService.Setup(x => x.Post(It.IsAny<User>())).Returns(new HttpResponseMessage(System.Net.HttpStatusCode.Created));

            var user = new UserDTO()
            {
                Id = 1,
                Name = "Agustin",
                LastName = "Franco",
                Email = "agustinfranco@gmail.com",
                Password = "1234556"
            };

            _UserController.Configuration = new System.Web.Http.HttpConfiguration();
            _UserController.Validate<UserDTO>(user);

            var response = _UserController.Post(user);

            Assert.IsTrue(response is ResponseMessageResult);
            Assert.IsTrue((response as ResponseMessageResult).Response.StatusCode == System.Net.HttpStatusCode.Created);
        }

        [TestMethod]
        public void UserController_Put_BadRequest()
        {
            _UserService.Setup(x => x.Put(It.IsAny<User>())).Returns(new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest));

            var user = new UserDTO()
            {
                Id = 0,
                Name = string.Empty,
                LastName = string.Empty,
                Email = string.Empty,
                Password = string.Empty
            };

            _UserController.Configuration = new System.Web.Http.HttpConfiguration();
            _UserController.Validate<UserDTO>(user);

            var response = _UserController.Put(user);

            Assert.IsTrue(response is BadRequestErrorMessageResult);
        }

        [TestMethod]
        public void UserController_Put_Created()
        {
            _UserService.Setup(x => x.Put(It.IsAny<User>())).Returns(new HttpResponseMessage(System.Net.HttpStatusCode.Created));

            var user = new UserDTO()
            {
                Id = 1,
                Name = "Agustin",
                LastName = "Franco",
                Email = "agustinfranco@gmail.com",
                Password = "1234556"
            };

            _UserController.Configuration = new System.Web.Http.HttpConfiguration();
            _UserController.Validate<UserDTO>(user);

            var response = _UserController.Put(user);

            Assert.IsTrue(response is ResponseMessageResult);
            Assert.IsTrue((response as ResponseMessageResult).Response.StatusCode == System.Net.HttpStatusCode.Created);
        }

        [TestMethod]
        public void UserController_Delete_NotFound()
        {
            _UserService.Setup(x => x.Delete(It.IsAny<int>())).Returns(new HttpResponseMessage(System.Net.HttpStatusCode.NotFound));   

            var response = _UserController.Delete(2);

            Assert.IsTrue(response is ResponseMessageResult);
            Assert.IsTrue((response as ResponseMessageResult).Response.StatusCode == System.Net.HttpStatusCode.NotFound);
        }

        [TestMethod]
        public void UserController_Delete_Ok()
        {
            _UserService.Setup(x => x.Delete(It.IsAny<int>())).Returns(new HttpResponseMessage(System.Net.HttpStatusCode.OK));

            var response = _UserController.Delete(1);

            Assert.IsTrue(response is ResponseMessageResult);
            Assert.IsTrue((response as ResponseMessageResult).Response.StatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}
