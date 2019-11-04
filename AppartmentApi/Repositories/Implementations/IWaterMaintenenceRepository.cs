using AppartmentApi.Repositories.Entities;
using AppartmentApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppartmentApi.Repositories.Implementations
{
    public class WaterMaintenenceRepository : Repository<WaterMaintenence>, IWaterMaintenenceRepository
    {
        public WaterMaintenenceRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
