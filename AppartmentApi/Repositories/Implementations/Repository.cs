using AppartmentApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AppartmentApi.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IDbContext DbContext;

        public Repository(IDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected virtual IQueryable<T> GetQueryable()
        {
            // Setting query time out to 180 seconds
            ((IObjectContextAdapter)DbContext).ObjectContext.CommandTimeout = 180;

            var queryable = typeof(IDbContext).GetProperties()
                .Single(property => property.PropertyType == typeof(IQueryable<T>));

            return (IQueryable<T>)queryable.GetValue(DbContext);
        }

        protected IDbSet<T> GetDbSet()
        {
            var dbSet = typeof(IDbContext)
                .GetMethod("Set")
                ?.MakeGenericMethod(typeof(T))
                .Invoke(DbContext, new object[] { }) as IQueryable<T>;

            return dbSet as IDbSet<T>;
        }

        public IQueryable<T> GetEntireTable()
        {
            return GetQueryable();
        }

        public void Add(T entity)
        {
            GetDbSet().Add(entity);
        }
        public void Update(T oldEntity, T newEntity)
        {
            DbContext.Entry(oldEntity).State = EntityState.Modified;
            DbContext.Entry(oldEntity).CurrentValues.SetValues(newEntity);
        }

        public void Remove(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Deleted;
            GetDbSet().Remove(entity);
        }

        public long Count()
        {
            return GetQueryable().LongCount();
        }

        public bool Any()
        {
            return GetQueryable().Any();
        }

        public bool Any(Expression<Func<T, bool>> identifierExpression)
        {
            return GetQueryable().Any(identifierExpression);
        }

        public T Single()
        {
            return GetQueryable().Single();
        }

        public List<T> GetAll()
        {
            return GetEntireTable().ToList();
        }
        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }
    }
}