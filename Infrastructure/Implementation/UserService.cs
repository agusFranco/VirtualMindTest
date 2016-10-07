using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Domain;
using Infrastructure.Interfaces;
using Repository.Interfaces;

namespace Infrastructure.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;

        public UserService(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }

        /// <summary>
        /// Saves one user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(User user)
        {
            try
            {
                _UserRepository.Add(user);

                _UserRepository.SaveAll();

                return new HttpResponseMessage(System.Net.HttpStatusCode.Created);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError); 
            }    
        }

        /// <summary>
        /// Updates one user
        /// </summary>
        /// <param name="userUpdated"></param>
        /// <returns></returns>
        public HttpResponseMessage Put(User userUpdated)
        {
            try
            {
                var previusUser = _UserRepository.GetByCriteria(x => x.Id == userUpdated.Id).FirstOrDefault();

                userUpdated.ApplyTo(previusUser);

                _UserRepository.SaveAll();

                return new HttpResponseMessage(System.Net.HttpStatusCode.Created);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        public IList<User> GetAll()
        {
            return _UserRepository.GetAll();
        }

        /// <summary>
        /// Get one user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User Get(int id)
        {
            return _UserRepository.GetByCriteria(x => x.Id == id).FirstOrDefault();          
        }

        /// <summary>
        /// Delete one user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Delete(int id)
        {
            var result = _UserRepository.GetByCriteria(x => x.Id == id).FirstOrDefault();

            if (result != null)
            {
                _UserRepository.Delete(result);
                _UserRepository.SaveAll();
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
        }
    }
}
