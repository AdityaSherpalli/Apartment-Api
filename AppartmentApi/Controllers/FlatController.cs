using AppartmentApi.Repositories.Entities;
//using AppartmentApi.Dto;
using AppartmentApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AppartmentApi.Controllers
{
    public class FlatController : ApiController
    {
        private readonly IFlatRepository _flatRepository;
        private readonly IFlatMemberRepository _flatMemberRepository;

        public FlatController(IFlatRepository flatRepository, IFlatMemberRepository flatMemberRepository)
        {
            _flatRepository = flatRepository;
            _flatMemberRepository = flatMemberRepository;
        }

        public List<Flat> GetAll()
        {
            return _flatRepository.GetEntireTable().ToList();
        }

        public string Add(Flat flat)
        {
            try
            {
                if (flat.Id != 0)
                    return Update(flat.Id, flat);
                else
                {
                    var nameValidation = ValidateName(flat);
                    if (nameValidation != null) return nameValidation;

                    _flatRepository.Add(flat);
                    _flatRepository.SaveChanges();
                    return null;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private string ValidateName(Flat flat)
        {
            if (_flatRepository.GetEntireTable().Where(x => x.Name == flat.Name && x.Id != flat.Id).FirstOrDefault() != null)
                return "Duplicate Name. Please enter another name";
            return null;
        }

        public string Update(int id, Flat flat)
        {
            try
            {
                var nameValidation = ValidateName(flat);
                if (nameValidation != null) return nameValidation;
                var flatToUpdate = _flatRepository.GetEntireTable().Where(x => x.Id == id).FirstOrDefault();
                flat.Id = id;
                _flatRepository.Update(flatToUpdate, flat);
                _flatRepository.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                var flatToDelete = _flatRepository.GetEntireTable().Where(x => x.Id == id).FirstOrDefault();
                if (flatToDelete != null)
                {
                    _flatRepository.Remove(flatToDelete);
                    _flatRepository.SaveChanges();
                    return null;
                }
                return "Failed to find a Flat with Id:'" + id + "'";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}