﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using WebApp.Entities;
using WebApp.Models;

namespace WebApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Blacklist> BlackLists { get; set; }

        public DbSet<Call> Calls { get; set; }

        public DbSet<Street> Streets { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Customer>Clients { get; set; }

        public DbSet<CustomerCall> CustomeCalls { get; set; } 

        public DbSet<District> Districts { get; set; }

        public DbSet<Housing> Housing { get; set; }

        public DbSet<HousingCall> HousingCalls { get; set; }

        public DbSet<Sms> Smses { get; set; }

        public DbSet<TypesHousing> TypesHousing { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Fluent Api
            builder.Entity<DistrictToСlient>()
                .HasKey(t => new {t.ClientId, t.DistrictId});

            builder.Entity<DistrictToСlient>()
                .HasOne(pt => pt.Clients)
                .WithMany(p => p.DistrictToСlients)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(p => p.ClientId);

            builder.Entity<DistrictToСlient>()
                .HasOne(pt => pt.Districts)
                .WithMany(p => p.DistrictToСlients)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(p => p.DistrictId);

            builder.Entity<District>()
                .HasOne(p => p.City)
                .WithMany(b => b.Districts)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Street>()
                .HasOne(p => p.City)
                .WithMany(b => b.Streets)
                .OnDelete(DeleteBehavior.Restrict);
          
             builder.Entity<ApplicationUser>()
                   .HasOne(p => p.City)
                   .WithMany(b => b.Users)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<HousingCall>();
            builder.Entity<CustomerCall>();
        }
    }
}
