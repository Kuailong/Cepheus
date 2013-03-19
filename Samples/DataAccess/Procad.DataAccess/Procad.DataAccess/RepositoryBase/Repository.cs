using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Procad.DataAccess.Interfaces;
using System.Linq.Expressions;
using System.Data;
using System.Data.Entity;

namespace Procad.DataAccess.RepositoryBase
{
    public class Repository<T> : IRepository<T>
            where T : class
    {

        #region Properties

        // Se precisar herdar
        private readonly DbContext _context;
        private IDbSet<T> _dbSet;

        #endregion

        #region Constructor

        public Repository(IUnitOfWork context)
        {
            this._context = context as DbContext;
            this._dbSet = this._context.Set<T>();
        }

        #endregion

        #region IRepository<T> Members

        public T Find(params object[] keyValues)
        {
            return this._dbSet.Find(keyValues);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter)
        {
            return this._dbSet.Where(filter);
        }
        public IQueryable<T> Get()
        {
            return this._dbSet;
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            var query = this._dbSet.Where(filter);

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
        public IQueryable<T> Get(params Expression<Func<T, object>>[] includes)
        {
            var query = this._dbSet.AsQueryable();

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }

        public void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this._dbSet.Add(entity);
        }

        public void Update<U>(U entity) where U : class
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this._context.Entry<U>(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this._dbSet.Remove(entity);
        }

        #endregion
    }
}
