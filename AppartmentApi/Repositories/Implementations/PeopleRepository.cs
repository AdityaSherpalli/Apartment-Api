using AppartmentApi.Repositories.Entities;
using AppartmentApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppartmentApi.Repositories.Implementations
{
    public class PeopleRepository : Repository<People>, IPeopleRepository
    {
        public PeopleRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}