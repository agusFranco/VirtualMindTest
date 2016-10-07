using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using Domain;
using Infrastructure.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repository.Interfaces;

namespace UnitTests.Infrastructure
{
    [TestClass]
    public class UserServiceTest
    {
        private static UserService _UserService;
        private static Mock<IUserRepository> _UserRepository;

        [ClassInitialize]
        public static void SetUp(TestContext testContext)
        {
            _UserRepository = new Mock<IUserRepository>();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _UserService = new UserService(_UserRepository.Object);
            _UserRepository.Reset();
            _UserRepository.ResetCalls();
        }

        [TestMethod]
        public void UserService_Post_Created()
        {
            _UserRepository.Setup(x => x.Add(It.IsAny<User>()));
            _UserRepository.Setup(x => x.SaveAll()).Returns(true);

            var response = _UserService.Post(new User());

            Assert.IsTrue(response is HttpResponseMessage);
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
        }

        [TestMethod]
        public void UserService_Put_Created()
        {
            _UserRepository.Setup(x => x.GetByCriteria(It.IsAny<Expression<Func<User,bool>>>())).Returns(new List<User>() { new User() });
            _UserRepository.Setup(x => x.SaveAll()).Returns(true);

            var response = _UserService.Put(new User());

            Assert.IsTrue(response is HttpResponseMessage);
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
        }

        [TestMethod]
        public void UserService_GetAll()
        {
            _UserRepository.Setup(x => x.GetAll()).Returns(new List<User>() { new User() });
            _UserRepository.Setup(x => x.SaveAll()).Returns(true);

            var response = _UserService.GetAll();

            Assert.IsTrue(response is List<User>);         
        }

        [TestMethod]
        public void UserService_GetOne()
        {
            _UserRepository.Setup(x => x.GetByCriteria(It.IsAny<Expression<Func<User, bool>>>())).Returns(new List<User>() { new User() });
            _UserRepository.Setup(x => x.SaveAll()).Returns(true);

            var response = _UserService.Get(1);

            Assert.IsTrue(response is User);
        }

        [TestMethod]
        public void UserService_Delete()
        {
            _UserRepository.Setup(x => x.GetByCriteria(It.IsAny<Expression<Func<User, bool>>>())).Returns(new List<User>() { new User() });
            _UserRepository.Setup(x => x.SaveAll()).Returns(true);
            _UserRepository.Setup(x => x.Delete(It.IsAny<User>()));

            var response = _UserService.Delete(1);

            Assert.IsTrue(response is HttpResponseMessage);
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}
