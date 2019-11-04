using AppartmentApi.Enums;
using AppartmentApi.Repositories.Entities;
using AppartmentApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AppartmentApi.Controllers
{
    public class PeopleController : ApiController
    {
        private IPeopleRepository _peopleRepository;
        public PeopleController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }
        public List<People> GetAll()
        {
            return _peopleRepository.GetEntireTable().ToList();
        }
        public List<People> GetPeopleBasedOnCategory(PersonType personType)
        {
            return _peopleRepository.GetEntireTable().Where(x => x.PersonType == personType).ToList();
        }
        public string Delete(int id)
        {
            try
            {
                var flatToDelete = _peopleRepository.GetEntireTable().Where(x => x.Id == id).FirstOrDefault();
                if (flatToDelete != null)
                {
                    _peopleRepository.Remove(flatToDelete);
                    _peopleRepository.SaveChanges();
                    return null;
                }
                return "Failed to find a Flat with Id:'" + id + "'";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string AddPerson(People people)
        {
            if (people.Id != 0)
            {
                return UpdatePerson(people.Id, people);
            }
            else
            {
                if (!_peopleRepository.GetEntireTable().Where(x => x.Name == people.Name).Any())
                {
                    _peopleRepository.Add(people);
                    _peopleRepository.SaveChanges();
                    return null;
                }
                return "Duplicate Name("+ people.Name +"). Please enter another name";
            }
        }

        private string UpdatePerson(int id, People people)
        {
            try
            {
                if (!_peopleRepository.GetEntireTable().Where(x => x.Name == people.Name && x.Id != id).Any())
                {
                    _peopleRepository.Update(_peopleRepository.GetEntireTable().Where(x => x.Id == id).First(), people);
                    _peopleRepository.SaveChanges();
                    return null;
                }
                return "Duplicate Name(" + people.Name + "). Please enter another name";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}