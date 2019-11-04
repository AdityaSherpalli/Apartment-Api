using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppartmentApi.Repositories.Entities
{
    public class MaintenenceItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsWater { get; set; }
    }
}