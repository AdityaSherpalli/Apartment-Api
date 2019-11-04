using AppartmentApi.Repositories.Entities;
using AppartmentApi.Repositories.Interfaces;

namespace AppartmentApi.Repositories.Implementations
{
    public class FlatRepository : Repository<Flat>, IFlatRepository
    {
        public FlatRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}