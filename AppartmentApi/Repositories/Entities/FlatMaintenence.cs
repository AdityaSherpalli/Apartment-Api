﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppartmentApi.Repositories.Entities
{
    public class FlatMaintenence
    {
        public int Id { get; set; }
        public Maintenence Maintenence { get; set; }
        public Flat Flat { get; set; }
        public int Amount { get; set; }
    }
}