﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Entities
{
    public class Call
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public DateTime  Date { get; set; }
        
        public int HousingId { get; set; }
        
        public Housing Housing { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser User { get; set; }

    }
}
