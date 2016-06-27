﻿using System.IO;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc.Rendering;
using WebApp.Models;
using Microsoft.Data.Entity;
using Microsoft.Extensions.WebEncoders;
using WebApp.ViewModels;
using Newtonsoft.Json;

namespace WebApp.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly ApplicationDbContext _context;

        protected ApplicationUser CurrentUser
        {
            get { return _context.Users.Include(x => x.City).Include(x => x.City.Districts).FirstOrDefault(x => x.Id == User.GetUserId()); }
        }

        protected CustomerUser CustomerUser
        {
            get { return CustomerUser.FromSession(HttpContext.Session); }
            set { CustomerUser.ToSession(value, HttpContext.Session); }
        }
        
        protected bool IsCustomer => CustomerUser != null;

        protected BaseController(ApplicationDbContext context)
        {
            _context = context;
        }


        protected void SuccessMessage(string message)
        {
            TempData["CrmSuccessMessage"] = message;
        }

        protected void ErrorMessage(string message)
        {
            TempData["CrmErrorMessage"] = message;
        }

    }
}
