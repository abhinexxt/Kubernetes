
using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data;
public static class PrepareDb
{
    public static void PreparePopulation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }
    }

    private static void SeedData(AppDbContext dbContext)
    {
        if (dbContext == null)
            return;

        if(!dbContext.Platforms.Any())
        {
            Console.WriteLine("--> Generating data....");
            dbContext.Platforms.AddRange(
                    new Platform {Name = "Dot Net", Publisher="Microsoft", Cost = "Free"},
                    new Platform { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new Platform { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
                );
            dbContext.SaveChanges();
        }
        else
        {
            Console.WriteLine("--> We already have data");
        }

    }
}
