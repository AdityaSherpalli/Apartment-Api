using AppartmentApi.Repositories.Entities;
using AppartmentApi.Repositories.Interfaces;
using System.Linq;
using System.Web.Http;

namespace AppartmentApi.Controllers
{
    public class ApartmentController : ApiController
    {
        private readonly IApartmentRepository _apartmentRepository;
        public ApartmentController(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }
        public Apartment Get()
        {
            return _apartmentRepository.GetEntireTable().FirstOrDefault(x => x.Id == 1);
        }
        public void CreateUpdate(Apartment apartment)
        {
            var oldApartment = _apartmentRepository.GetEntireTable().FirstOrDefault(x => x.Id == 1);
            apartment.Id = 1;
            if (oldApartment == null)
            {
                _apartmentRepository.Add(apartment);
            }
            else
            {
                _apartmentRepository.Update(oldApartment, apartment);
            }
            _apartmentRepository.SaveChanges();
        }
    }
}