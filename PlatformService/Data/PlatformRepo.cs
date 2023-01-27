using System;
using System.Collections.Generic;
using System.Linq;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext dbContext;

        public PlatformRepo(AppDbContext context)
        {
            this.dbContext = context;
        }
        public void CreatePlatform(Platform platform)
        {
            if(platform==null)
                throw new ArgumentNullException(nameof(platform));

            this.dbContext.Platforms.Add(platform);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return this.dbContext.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return this.dbContext.Platforms.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (this.dbContext.SaveChanges() >= 0);
        }
    }
}