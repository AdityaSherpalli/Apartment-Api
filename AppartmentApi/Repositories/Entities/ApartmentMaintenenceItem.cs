using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppartmentApi.Repositories.Entities
{
    public class ApartmentMaintenenceItem
    {
        public int Id { get; set; }
        public Maintenence Maintenence { get; set; }
        public MaintenenceItem MaintenenceItem { get;set;}
        public string Notes { get; set; }
        public double Amount { get; set; }
    }
}