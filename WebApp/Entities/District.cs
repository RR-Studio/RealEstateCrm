﻿using System.Collections.Generic;

namespace WebApp.Entities
{
    public class District
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public List<Street> Streets { get; set; }

        public List<Building> Buildings { get; set; }

        public List<DistrictToСlient> DistrictToСlients { get; set; }

    }
}