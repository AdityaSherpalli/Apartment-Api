using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppartmentApi.Dto
{
    public class Flat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPhoneNumber{get;set;}
        public bool IsOwnerResident { get; set; }
        public string ResidentName { get; set; }
        public string ResidentPhoneNumber { get; set; }
        //public List<Flat> ConvertFromEntity(List<Repositories.Entities.Flat> flats, List<Repositories.Entities.FlatMember> flatMembers)
        //{
        //    var retVal = new List<Flat>();
        //    foreach(var flat in flats)
        //    {
        //        var flatMember = flatMembers.FirstOrDefault(x => x.Flat.Id == flat.Id);
        //        var flatToAdd = new Flat()
        //        {
        //            Id = flat.Id,
        //            Name = flat.Name
        //        };
        //        if(flatMember != null)
        //        {
        //            flatToAdd.OwnerName = flatMember.OwnerName;
        //            flatToAdd.OwnerPhoneNumber = flatMember.OwnerPhoneNumber;
        //            flatToAdd.IsOwnerResident = flatMember.IsOwnerResident;
        //            flatToAdd.ResidentName = flatMember.ResidentName;
        //            flatToAdd.ResidentPhoneNumber = flatMember.ResidentPhoneNumber;
        //        }
        //        retVal.Add(flatToAdd);
        //    }

        //    return retVal;
        //}
        //public Flat ConvertFromEntity(Repositories.Entities.Flat flat, Repositories.Entities.FlatMember flatMember)
        //{
        //    return new Flat()
        //    {
        //        Id = flat.Id,
        //        Name = flat.Name,
        //        OwnerName = flatMember.OwnerName,
        //        IsOwnerResident = flatMember.IsOwnerResident,
        //        OwnerPhoneNumber = flatMember.OwnerPhoneNumber,
        //        ResidentName = flatMember.ResidentName,
        //        ResidentPhoneNumber = flatMember.ResidentPhoneNumber
        //    };
        //}

    }
}