﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Entities
{
    public class Blacklist:IEntityBase
    {
        public int Id { get; set; }

        public string  Description { get; set; }

        public string  PhoneNumber { get; set; }

        public DateTime  DateAdd { get; set; }

    }
}
