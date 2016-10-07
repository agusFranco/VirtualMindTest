using System.Collections.Generic;
using System.Net.Http;
using Domain;

namespace Infrastructure.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Post one user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        HttpResponseMessage Post(User user);

        /// <summary>
        /// Updates one user
        /// </summary>
        /// <param name="userUpdated"></param>
        /// <returns></returns>
        HttpResponseMessage Put(User userUpdated);

        /// <summary>
        /// Get all the users
        /// </summary>
        /// <returns></returns>
        IList<User> GetAll();

        /// <summary>
        /// Get one user by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User Get(int id);

        /// <summary>
        /// Delete one user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        HttpResponseMessage Delete(int id);
    }
}
