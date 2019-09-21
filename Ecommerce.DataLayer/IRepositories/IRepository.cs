using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ecommerce.DataLayer.IRepositories
{
    public interface IRepository<T> where T : class
    {
        void Insert(T entity);
        void InsertRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(int id);
        void DeleteRange(IEnumerable<T> entities);
        T Find(Expression<Func<T, bool>> filter, string includeProperties = "");
        IEnumerable<T> FindAll(Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
    }
}
