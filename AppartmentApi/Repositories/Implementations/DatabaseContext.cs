using AppartmentApi.Repositories.Entities;
using AppartmentApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AppartmentApi.Repositories.Implementations
{
    public class DatabaseContext : DbContext, IDbContext
    {
        public DatabaseContext() : base("ConnectionString")
        {
        }

        public DatabaseContext(DbConnection connection) : base(connection, true)
        {
        }

        public DatabaseContext(string connection) : base(connection)
        {
        }

        public new virtual IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Apartment>();
            modelBuilder.Entity<Flat>();

            modelBuilder.Entity<FlatMember>()
                        .HasRequired(b => b.Flat)
                        .WithMany()
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<FlatMember>()
                        .HasOptional(b => b.PrimaryOwner)
                        .WithMany()
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<FlatMember>()
                        .HasOptional(b => b.SecondaryOwner)
                        .WithMany()
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<FlatMember>()
                        .HasOptional(b => b.PrimaryResident)
                        .WithMany()
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<FlatMember>()
                        .HasOptional(b => b.SecondaryResident)
                        .WithMany()
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<People>();
            modelBuilder.Entity<MaintenenceItem>();
            modelBuilder.Entity<Maintenence>();
            modelBuilder.Entity<ApartmentMaintenenceItem>()
                        .HasRequired(b => b.Maintenence)
                        .WithMany()
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<ApartmentMaintenenceItem>()
                        .HasRequired(b => b.MaintenenceItem)
                        .WithMany()
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<FlatMaintenence>()
                        .HasRequired(b => b.Maintenence)
                        .WithMany()
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<FlatMaintenence>()
                        .HasRequired(b => b.Flat)
                        .WithMany()
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<FlatMaintenenceItem>()
                        .HasRequired(b => b.ApartmentMaintenenceItem)
                        .WithMany()
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<FlatMaintenenceItem>()
                        .HasRequired(b => b.FlatMaintenence)
                        .WithMany()
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<WaterMaintenence>()
                        .HasRequired(b => b.Maintenence)
                        .WithMany()
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<WaterMaintenence>()
                        .HasRequired(b => b.Flat)
                        .WithMany()
                        .WillCascadeOnDelete(false);
        }
        public IQueryable<Apartment> Apartment
        {
            get
            {
                return Set<Apartment>();
            }
        }
        public IQueryable<Flat> Flat
        {
            get
            {
                return Set<Flat>();
            }
        }
        public IQueryable<FlatMember> FlatMember
        {
            get
            {
                return Set<FlatMember>()
                    .Include(x => x.PrimaryOwner)
                    .Include(x => x.SecondaryOwner)
                    .Include(x => x.PrimaryResident)
                    .Include(x => x.SecondaryResident)
                    .Include(x => x.Flat);
            }
        }
        public IQueryable<People> People
        {
            get
            {
                return Set<People>();
            }
        }
        public IQueryable<MaintenenceItem> MaintenenceItem
        {
            get
            {
                return Set<MaintenenceItem>();
            }
        }
        public IQueryable<Maintenence> Maintenence
        {
            get
            {
                return Set<Maintenence>();
            }
        }
        public IQueryable<ApartmentMaintenenceItem> ApartmentMaintenenceItem
        {
            get
            {
                return Set<ApartmentMaintenenceItem>();
            }
        }
        public IQueryable<FlatMaintenence> FlatMaintenence
        {
            get
            {
                return Set<FlatMaintenence>();
            }
        }
        public IQueryable<FlatMaintenenceItem> FlatMaintenenceItem
        {
            get
            {
                return Set<FlatMaintenenceItem>();
            }
        }
        public IQueryable<WaterMaintenence> WaterMaintenence
        {
            get
            {
                return Set<WaterMaintenence>();
            }
        }

    }
}