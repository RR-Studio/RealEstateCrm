﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Entities
{
    public class DistrictСustomer
    {
        public int ClientId { get; set; }

        public Client Clients { get; set; }

        public int DistrictId { get; set; }

        public District Districts { get; set; }
    }
}
