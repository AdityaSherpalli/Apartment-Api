using AppartmentApi.Repositories.Entities;
using AppartmentApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AppartmentApi.Controllers
{
    public class MaintenenceItemController : ApiController
    {
        private IMaintenenceItemRepository _maintenenceItemRepository;
        public MaintenenceItemController(IMaintenenceItemRepository maintenenceItemRepository)
        {
            _maintenenceItemRepository = maintenenceItemRepository;
        }
        public List<MaintenenceItem> GetAll()
        {
            return _maintenenceItemRepository.GetEntireTable().ToList();
        }
        public void Add(MaintenenceItem maintenenceItem)
        {
            _maintenenceItemRepository.Add(maintenenceItem);
            _maintenenceItemRepository.SaveChanges();
        }
        public void Delete(int id)
        {
            _maintenenceItemRepository.Remove(_maintenenceItemRepository.GetEntireTable().Where(x => x.Id == id).First());
            _maintenenceItemRepository.SaveChanges();
        }
    }
}