using AppartmentApi.Repositories.Entities;
using AppartmentApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AppartmentApi.Controllers
{
    public class MaintenenceController : ApiController
    {
        private IApartmentMaintenenceItemRepository _apartmentMaintenenceItemRepo;
        private IFlatMaintenenceRepository _flatMaintenenceRepository;
        private IMaintenenceRepository _maintenenceRepository;
        private IMaintenenceItemRepository _maintenenceItemRepository;
        private IFlatRepository _flatRepository;
        private IFlatMaintenenceItemRepository _flatMaintenenceItemRepository;

        public MaintenenceController(IApartmentMaintenenceItemRepository apartmentMaintenenceItemRepo,
            IFlatMaintenenceRepository flatMaintenenceRepository, IMaintenenceRepository maintenenceRepository,
            IMaintenenceItemRepository maintenenceItemRepository, IFlatRepository flatRepository, IFlatMaintenenceItemRepository flatMaintenenceItemRepository)
        {
            _apartmentMaintenenceItemRepo = apartmentMaintenenceItemRepo;
            _flatMaintenenceRepository = flatMaintenenceRepository;
            _maintenenceRepository = maintenenceRepository;
            _maintenenceItemRepository = maintenenceItemRepository;
            _flatRepository = flatRepository;
            _flatMaintenenceItemRepository = flatMaintenenceItemRepository;
        }

        public List<ApartmentMaintenenceItem> GetApartmentMaintenence(string maintenencePeriod)
        {
            var maintenence = _maintenenceRepository.GetEntireTable().FirstOrDefault(x => x.Period == maintenencePeriod);
            return (maintenence == null)
                ? null
                : _apartmentMaintenenceItemRepo
                        .GetEntireTable()
                        .Where(x => x.Maintenence.Id == maintenence.Id)
                        .ToList();
            
        }
        public List<FlatMaintenenceItem> GetFlatMaintenence(string maintenencePeriod, int flatId)
        {
            var maintenence = _maintenenceRepository.GetEntireTable().FirstOrDefault(x => x.Period == maintenencePeriod);

            if (maintenence == null)
                return null;
            var flatMaintenence = _flatMaintenenceRepository
                        .GetEntireTable()
                        .Where(x => x.Maintenence.Id == maintenence.Id && x.Flat.Id == flatId)
                        .FirstOrDefault();
            if (flatMaintenence == null) return null;

            return _flatMaintenenceItemRepository.GetEntireTable().Where(x => x.FlatMaintenence.Id == flatMaintenence.Id).ToList();

        }
    }
}