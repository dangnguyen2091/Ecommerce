using Ecommerce.DataLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Ecommerce.DataLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext context;
        protected readonly DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
        }

        public void Insert(T entity)
        {
            dbSet.Add(entity); 
        }

        public void InsertRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
        }

        public void Update(T entity)
        {
            //dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public T Find(Expression<Func<T, bool>> filter, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;
            foreach (var includeProperty in includeProperties.Split(
                new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query.FirstOrDefault(filter);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split(
                new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }
    }
}
