﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class HousingIndexModel
    {
        public List<HousingEditModel> Items { get; set; }

        [UIHint("dropdown")]
        [Display(Name="Вид жилья")]
        public DropDownViewModel HousingTypeList { get; set; }
        
        [UIHint("dropdown")]
        [Display(Name = "Город")]
        public DropDownViewModel City { get; set; }

        [UIHint("dropdown")]
        [Display(Name = "Район")]
        public DropDownViewModel District { get; set; }

        [Display(Name = "Цена от")]
        public int MinCost { get; set; }

        [Display(Name = "Цена до")]
        public int MaxCost { get; set; }

        [Display(Name = "ID объекта")]
        public int SelectedObjectId { get; set; }

        public HousingIndexModel()
        {
        }

        public HousingIndexModel(ApplicationDbContext context, int? typesHousingId, int? cityId, int? districtId)
        {
            var housing = context.TypesHousing.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name  }).ToList();
            housing.Insert(0, new SelectListItem { Value = "", Selected = true, Text = "Все виды жилья" });
            var houseTypeList = new DropDownViewModel
            {
                Id = typesHousingId ?? 0,
                Items = housing
            };

            HousingTypeList = houseTypeList;

            var allCities = context.Cities.Include(x => x.Districts).ToList();
            var cityList = allCities.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();
            cityList.Insert(0, new SelectListItem { Value = "", Selected = true, Text = "Все города" });
            City = new DropDownViewModel
            {
                Id = cityId ?? 0,
                Items = cityList
            };

            var districts = context.Districts.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = $"{x.Name} ({x.City.Name})" }).ToList();
            districts.Insert(0, new SelectListItem { Value = "", Selected = true, Text = "Все районы"});

            District = new DropDownViewModel()
            {
                Id =  districtId ?? 0,
                Items = districts
            };

        }
    }
}
