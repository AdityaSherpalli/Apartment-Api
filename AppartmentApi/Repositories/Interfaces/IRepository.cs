using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AppartmentApi.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        IQueryable<T> GetEntireTable();
        void Add(T entity);
        void Update(T oldEntity, T newEntity);
        void Remove(T entity);
        long Count();
        bool Any();
        bool Any(Expression<Func<T, bool>> identifierExpression);
        T Single();
        int SaveChanges();
    }
}