using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repository.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity); 
       
        void Delete(T entity);

        IList<T> GetAll();

        IList<T> GetByCriteria(Expression<Func<T, bool>> criteria);      

        bool SaveAll();
    }
}
