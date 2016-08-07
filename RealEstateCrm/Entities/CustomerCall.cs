﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Entities
{
    public class CustomerCall
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
