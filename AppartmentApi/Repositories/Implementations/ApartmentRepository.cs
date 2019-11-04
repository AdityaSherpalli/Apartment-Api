using AppartmentApi.Repositories.Entities;
using AppartmentApi.Repositories.Interfaces;

namespace AppartmentApi.Repositories.Implementations
{
    public class ApartmentRepository : Repository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}