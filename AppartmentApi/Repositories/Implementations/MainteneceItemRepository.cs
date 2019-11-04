using AppartmentApi.Repositories.Entities;
using AppartmentApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppartmentApi.Repositories.Implementations
{
    public class MaintenenceItemRepository : Repository<MaintenenceItem>, IMaintenenceItemRepository
    {
        public MaintenenceItemRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}