using System;
using System.Collections.Generic;
using System.Linq;
using Dominos.Services.DbWrite.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Dominos.Services.DbWrite.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<LocationDbContext>();
            context.Database.EnsureCreated();
            if (!context.Locations.Any())
            {
                var products = new List<Location>()
                {
                    new Location { src_long = 22.33212, src_lat = 44.23812, des_long = 22.43212,des_lat =44.13812 },
                };

                context.Locations.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}
