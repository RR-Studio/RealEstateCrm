﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using WebApp.Entities;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class HousingEditModel
    {
        [Display(Name = "ID объекта")]
        public int EditId { get; set; }
        
        [Display(Name = "Фамилия")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string MidleName { get; set; }
        
        [Display(Name = "Отчество")]
        public string LastName { get; set; }

        [Display(Name = "Описание")]
        public string Comment { get; set; }

        [Display(Name = "Цена")]
        public double Cost { get; set; }
       
        [UIHint("city-selector")]
        [Required]
        [Display(Name = "Город")]
        public int CityId { get; set; }

        [UIHint("dropdown")]
        [Required]
        [Display(Name = "Район")]
        public int DistrictId { get; set; }

        [UIHint("dropdown")]
        [Required]
        [Display(Name = "Улица")]
        public int StreetId { get; set; }
        
        [Required]
        [Display(Name = "Номер дома")]
        public string HouseNumber { get; set; }

        [Display(Name = "Строение")]
        public string HouseBuilding { get; set; }

        [Display(Name = "Номер квартиры")]
        public string Room { get; set; }

        [UIHint("phone")]
        [Required]
        [Display(Name = "Телефон 1 для связи")]
        public string Phone1 { get; set; }

        [UIHint("phone")]
        [Display(Name = "Телефон 2 для связи")]
        public string Phone2 { get; set; }

        [UIHint("phone")]
        [Display(Name = "Телефон 3 для связи")]
        public string Phone3 { get; set; }
  
        [Display(Name = "Тип жилья")]
        public int HouseTypeId { get; set; }

        [Display(Name = "Дата освобождения объекта")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Полный адрес")]
        public string FullAddress { get; set; }

        [UIHint("checkbox")]
        [Display(Name = "В архиве")]
        public bool IsArchived { get; set; }

        [UIHint("checkbox")]
        [Display(Name = "Партнерство")]
        public bool IsPartnerShip { get; set; }

        [Display(Name = "Тип жилья")]
        public string HouseType { get; set; }

        public List<HousingCallViewModel> Calls { get; set; }

        public HousingEditModel()
        {
        }

        public static HousingEditModel Create(ApplicationDbContext context, Housing housing,  ClaimsPrincipal user)
        {
            var typesHousings = context.TypesHousing.ToList();
            return Create(housing, typesHousings, user);
        }

        public static HousingEditModel Create(Housing housing, 
            List<TypesHousing> typesHousings, 
            ClaimsPrincipal user)
        {
            var item = new HousingEditModel
            {
                EditId = housing.Id,
                Comment = housing.Comment,
                FirstName = housing.FirstName,
                LastName = housing.LastName,
                MidleName = housing.MidleName,
                Cost = housing.Sum,
                EndDate = housing.EndDate,
                Phone1 = housing.Phones.SingleOrDefault(x => x.Order == 0)?.Number,
                Phone2 = housing.Phones.SingleOrDefault(x => x.Order == 1)?.Number,
                Phone3 = housing.Phones.SingleOrDefault(x => x.Order == 2)?.Number,
                HouseNumber = housing?.House,
                HouseBuilding = housing?.Building,
                Room = housing?.Room,
                IsArchived = housing.IsArchive,
                IsPartnerShip = housing.PartherShip,
                HouseType = housing.TypesHousing?.Name ?? "Не указано",
                HouseTypeId = housing.TypesHousingId,
                CityId = housing.CityId,
                DistrictId = housing.DistrictId,
                StreetId = housing.StreetId,
                Calls = housing.Calls.Select(HousingCallViewModel.Create).ToList()
            };
            
            var addressParts = new List<string>();
            if (housing.City != null)
            {
                addressParts.Add(housing.City.Name);
            }

            if (housing.District != null)
            {
                addressParts.Add(housing.District.Name);
            }

            if (housing.Street != null)
            {
                addressParts.Add(housing.Street.Name);
            }

            addressParts.Add(housing.House);
            addressParts.Add(housing.Building);
            addressParts.Add(housing.Room);
            
            item.FullAddress = addressParts.Where(x => !string.IsNullOrEmpty(x)).Aggregate("", (x, y) => x + ", " + y).Trim(',');

            return item;
        }


        public void UpdateEntity(Housing item)
        {
            item.FirstName = FirstName;
            item.MidleName = MidleName;
            item.LastName = LastName;
            item.Sum = Cost;
            item.Comment = Comment;
            item.CityId = CityId;
            item.DistrictId = DistrictId;
            item.StreetId = StreetId;
            item.House = HouseNumber;
            item.Building = HouseBuilding;
            item.Room = Room;
            item.TypesHousingId = HouseTypeId;
            item.EndDate = EndDate;
            item.IsArchive = IsArchived;
            item.PartherShip = IsPartnerShip;

            UpdatePhone(item, 0, Phone1);
            UpdatePhone(item, 1, Phone2);
            UpdatePhone(item, 2, Phone3);
        }

        private static void UpdatePhone(Housing item, int order, string phone)
        {
            var housingPhone = item.Phones.SingleOrDefault(x => x.Order == order);
            if (housingPhone != null)
            {
                housingPhone.Number = phone;
            }
            else if(!string.IsNullOrEmpty(phone))
            {
                housingPhone = new HousingPhone { Number = phone, Order = order };
                item.Phones.Add(housingPhone);
            }
        }
    }
}
