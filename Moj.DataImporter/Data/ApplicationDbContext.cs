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
        //public DbSet<ColorCode> ColorCodes { get; set; }
        public DbSet<DeliveryPeriod> DeliveryPeriods { get; set; }
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            
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

            //builder.Entity<ColorCode>().HasData(
            //    new ColorCode { Code = "pants", ID = 1 },
            //    new ColorCode { Code = "Kniepants Jorge", ID = 2 },
            //    new ColorCode { Code = "Jeans", ID = 3 },
            //    new ColorCode { Code = "Jeans Willy", ID = 4 },
            //    new ColorCode { Code = "Kniepants Maria", ID = 5 },
            //    new ColorCode { Code = "Top Wilma", ID = 6 },
            //    new ColorCode { Code = "Top Annie", ID = 7 },
            //    new ColorCode { Code = "Top Bill", ID = 8 },
            //    new ColorCode { Code = "Steve Irwin", ID = 9 },
            //    new ColorCode { Code = "Jeans Willy Boys", ID = 10 },
            //    new ColorCode { Code = "Short Billy & Bobble", ID = 11 },
            //    new ColorCode { Code = "jacket", ID = 12 },
            //    new ColorCode { Code = "test", ID = 13 });
        }
    }
}
