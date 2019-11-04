using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppartmentApi.Repositories.Entities
{
    public class FlatMaintenenceItem
    {
        public int Id { get; set; }
        public FlatMaintenence FlatMaintenence { get; set; }
        public ApartmentMaintenenceItem ApartmentMaintenenceItem { get; set; }
        public double Amount { get; set; }
    }
}