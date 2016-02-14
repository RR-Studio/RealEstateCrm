﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities;

namespace WebApp.DAL
{
    public class BuildingRepository
    {
        public List<Building> GetBuildings(int? page, int[] houseTypeId, int? cityId)
        {
            var list = new List<Building>();
            for (int i = 0; i < 50; i++)
            {
                list.Add(CreateRadnom());
            }
            
            if (houseTypeId.Length > 0)
            {
                list = list.Where(x => houseTypeId.Contains(x.TypesHousing.Id)).ToList();
            }

            if (cityId.HasValue)
            {
                list = list.Where(x => x.CityId == cityId.Value).ToList();
            }

            const int pageSize = 10;
            int totalPages = list.Count / pageSize;
            if (page.HasValue)
            {
                if (page > totalPages)
                {
                    throw new ArgumentOutOfRangeException(nameof(page));
                }
                int start = page.Value * pageSize;
                list = list.GetRange(start, pageSize);
            }

            return list;
        }

        private Building CreateRadnom()
        {
            
            var random = new Random();
            var houseType = MockData.GetRandomHouseType();
            var city = MockData.GetRandomCity();
            var district = MockData.GetRandomDistrict();
            var street = MockData.GetRandomStreet();

            Building item = new Building()
            {
                Id = random.Next(10000),
                CityId = city.Id,
                City = city,
                Street = street,
                StreetId = street.Id,
                District = district,
                DistrictId = district.Id,
                TypesHousing = houseType,
                Comment = MockData.GetRandomDescription(),
                Sum = random.Next(5000, 30000),
                Phone1 = "+123456789"
            };
            return item;
        }
    }
}
