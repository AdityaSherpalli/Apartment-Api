using AppartmentApi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppartmentApi.Repositories.Entities
{
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PersonType PersonType { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}