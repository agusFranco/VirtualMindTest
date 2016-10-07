using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Repository.Interfaces;

namespace Repository.Implementation
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }      

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }       

        public IList<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IList<T> GetByCriteria(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().Where(criteria).ToList();
        }     

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
