using AppartmentApi.Repositories.Entities;
using AppartmentApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppartmentApi.Repositories.Implementations
{
    public class FlatMaintenenceRepository : Repository<FlatMaintenence>, IFlatMaintenenceRepository
    {
        public FlatMaintenenceRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}