using AppartmentApi.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppartmentApi.Repositories.Interfaces
{
    public interface IFlatMemberRepository : IRepository<FlatMember>
    {
        void UpdateFlatMember(int id, FlatMember flatmember);
        void AddFlatMember(FlatMember flatmember);
        List<FlatMember> GetFlatMembers(int flatId);
        void Delete(int flatMemberId);
    }
}
