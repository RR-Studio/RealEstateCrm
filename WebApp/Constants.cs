﻿using WebApp.Entities;
using WebApp.Models;

namespace WebApp
{
    public static class RoleNames
    {
        public const string Admin = "Admin";
        public const string Employee = "Employee";
        public const string Customer = "Customer";

        public const string CreateHousing = "CreateHousing";
        public const string EditHousing = "EditHousing";
        public const string DeleteHousing = "DeleteHousing";

        public const string CreateCustomer = "CreateCustomer";
        public const string EditCustomer = "EditCustomer";
        public const string DeleteCustomer = "DeleteCustomer";

        public const string ManageUser = "ManageUser";

        public static string[] AllRoles = new[]
        {
            Admin, Employee, Customer, 
            CreateHousing, EditHousing, DeleteHousing,
            CreateCustomer, EditCustomer, DeleteCustomer, ManageUser
        };

        public static string[] PermissionRoles = new[]
        {
            CreateHousing, EditHousing, DeleteHousing,
            CreateCustomer, EditCustomer, DeleteCustomer, ManageUser
        };
    }

    public static class AuthPolicy
    {
        public const string Employees = "Employees";
        public const string CreateHousing = "CreateHousing";
        public const string EditHousing = "EditHousing";
        public const string DeleteHousing = "DeleteHousing";

        public const string CreateCustomer = "CreateCustomer";
        public const string EditCustomer = "EditCustomer";
        public const string DeleteCustomer = "DeleteCustomer";

        public const string ManageUser = "ManageUser";
    }

    public static class CacheKeys
    {
        public static readonly string City = typeof (City).FullName;
        public static readonly string District = typeof(District).FullName;
        public static readonly string User = typeof(ApplicationUser).FullName;
        public static readonly string HousingType = typeof(TypesHousing).FullName;
    }
}
