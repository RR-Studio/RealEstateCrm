﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Entities
{
    public class Call:IEntityBase 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime  Date { get; set; }

        
    }
}
