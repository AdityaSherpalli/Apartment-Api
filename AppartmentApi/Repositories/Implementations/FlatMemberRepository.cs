using AppartmentApi.Repositories.Entities;
using AppartmentApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppartmentApi.Repositories.Implementations
{
    public class FlatMemberRepository : Repository<FlatMember>, IFlatMemberRepository
    {
        public FlatMemberRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public void AddFlatMember(FlatMember flatmember)
        {
            Add(flatmember);
            SaveChanges();
        }

        public List<FlatMember> GetFlatMembers(int flatId)
        {
            return GetEntireTable().Where(x=>x.FlatId==flatId).ToList();
        }

        public void UpdateFlatMember(int id, FlatMember flatmember)
        {
            var oldEntity = GetEntireTable().Where(x => x.Id == id).First();
            Update(oldEntity, flatmember);
            SaveChanges();
        }

        public void Delete(int flatMemberId)
        {
            Remove(GetEntireTable().First(x => x.Id == flatMemberId));
            SaveChanges();
        }
    }
}