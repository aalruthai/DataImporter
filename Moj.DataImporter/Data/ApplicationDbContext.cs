using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moj.DataImporter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moj.DataImporter.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<Color> Colors { get; set; }
        
        public DbSet<DeliveryPeriod> DeliveryPeriods { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Item>(entity => {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ItemCode).HasMaxLength(64);
                entity.Property(e => e.ColorCode).HasMaxLength(128);
                entity.Property(e => e.Description).HasMaxLength(512);
                entity.HasMany(e => e.Orders).WithOne(e => e.Item);
            });

            builder.Entity<Order>(entity => {
                entity.HasKey(e => e.ID);

            });

            builder.Entity<Color>(entity => {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ColorName).HasMaxLength(64);
                entity.HasMany(e => e.Orders).WithOne(e => e.Color);
            });
            builder.Entity<Category>(entity => {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.CategoryName).HasMaxLength(64);
                entity.HasMany(e => e.Orders).WithOne(e => e.Category);
            });

            builder.Entity<DeliveryPeriod>(entity => {
                entity.HasKey(e => e.ID);
                entity.HasMany(e => e.Orders).WithOne(e => e.DeliveryPeriod);
            });

            SeedData(builder);

            base.OnModelCreating(builder);
        }


        protected void SeedData(ModelBuilder builder)
        {
            builder.Entity<Color>().HasData(
                new Color { ColorName = "gray", ID = 1 },
                new Color { ColorName = "green", ID = 2 },
                new Color { ColorName = "White", ID = 3 },
                new Color { ColorName = "black", ID = 4 },
                new Color { ColorName = "brown", ID = 5 },
                new Color { ColorName = "beige", ID = 6 },
                new Color { ColorName = "red", ID = 7 },
                new Color { ColorName = "blue", ID = 8 });

            builder.Entity<DeliveryPeriod>().HasData(
                new DeliveryPeriod { Period = "1-3 WorkDay", ID = 1 },
                new DeliveryPeriod { Period = "1-8 WorkDay", ID = 2 });

            builder.Entity<Category>().HasData(
                new Category { CategoryName = "baby", ID = 1},
                new Category { CategoryName = "boy", ID = 2 },
                new Category { CategoryName = "girl", ID = 3 }
                );
            
        }
    }
}
