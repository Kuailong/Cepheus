using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Procad.DataAccess.Interfaces
{
    public interface IRepository
    {
        void Update<U>(U entity) where U : class;
    }

    public interface IRepository<T> : IRepository
        where T : class
    {
        IQueryable<T> Get(Expression<Func<T, bool>> filter);
        IQueryable<T> Get();
        IQueryable<T> Get(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        IQueryable<T> Get(params Expression<Func<T, object>>[] includes);
        T Find(params object[] keyValues);
        void Add(T entity);
        void Remove(T entity);
    }
}
