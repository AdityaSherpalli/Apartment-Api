using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppartmentApi.Repositories.Entities
{
    public class FlatMember
    {
        public int Id { get; set; }
        public int FlatId { get; set; }
        public int? PrimaryOwnerId { get; set; }
        public int? SecondaryOwnerId { get; set; }
        public int? SecondaryResidentId { get; set; }
        public int? PrimaryResidentId { get; set; }
        public virtual Flat Flat { get; set; }
        public virtual People PrimaryOwner { get; set; }
        public virtual People SecondaryOwner { get; set; }
        public virtual People PrimaryResident { get; set; }
        public virtual People SecondaryResident { get; set; }
    }
}