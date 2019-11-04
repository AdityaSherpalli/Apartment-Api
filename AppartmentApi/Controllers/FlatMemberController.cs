using AppartmentApi.Repositories.Entities;
using AppartmentApi.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AppartmentApi.Controllers
{
    public class FlatMemberController : ApiController
    {
        private readonly IFlatMemberRepository _flatMemberRepository;
        public FlatMemberController(IFlatMemberRepository flatMemberRepository)
        {
            _flatMemberRepository = flatMemberRepository;
        }
        public void UpdateFlatMember(int id, FlatMember flatmember)
        {
            _flatMemberRepository.UpdateFlatMember(id, flatmember);
        }
        public void AddFlatMember(FlatMember flatmember)
        {
            if (flatmember.Id != 0)
                UpdateFlatMember(flatmember.Id, flatmember);
            else
                _flatMemberRepository.AddFlatMember(flatmember);
        }
        public void DeleteFlatMember(int flatMemberId)
        {
            _flatMemberRepository.Delete(flatMemberId);
        }
        public FlatMember GetFlatMembers(int flatId)
        {
            return _flatMemberRepository.GetEntireTable().Where(x => x.Flat.Id == flatId).FirstOrDefault();
        }
        public List<FlatMember> GetAll()
        {
            return _flatMemberRepository.GetAll();
        }
    }
}