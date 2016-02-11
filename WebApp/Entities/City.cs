﻿using System.Collections.Generic;

namespace WebApp.Entities
{
    public class City
    {
        public int Id { get; set; }

        public string  Name  { get; set; }

        public List<District> Districts { get; set; }

        public List<Client> Clients { get; set; }

        public int BuildingId { get; set; }

        public virtual Building Building { get; set; }


    }
}