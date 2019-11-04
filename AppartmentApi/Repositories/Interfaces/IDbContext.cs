using AppartmentApi.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace AppartmentApi.Repositories.Interfaces
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        IQueryable<Apartment> Apartment { get; }
        IQueryable<Flat> Flat { get; }
        IQueryable<FlatMember> FlatMember { get; }
        IQueryable<People> People { get; }
        IQueryable<MaintenenceItem> MaintenenceItem { get; }
        IQueryable<Maintenence> Maintenence { get; }
        IQueryable<ApartmentMaintenenceItem> ApartmentMaintenenceItem { get; }
        IQueryable<FlatMaintenence> FlatMaintenence { get; }
        IQueryable<FlatMaintenenceItem> FlatMaintenenceItem { get; }
        IQueryable<WaterMaintenence> WaterMaintenence { get; }
    }
}