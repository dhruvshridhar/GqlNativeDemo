using System;
using GqlNativeDemo.Database;
using GqlNativeDemo.Interfaces;
using GqlNativeDemo.Models;

namespace GqlNativeDemo.Services
{
	public class PlatformService : IPlatformService
	{
        private readonly AppDbContext _dbContext;
		public PlatformService(AppDbContext dbContext)
		{
            _dbContext = dbContext;
		}

        public Platform AddPlatform(Platform platform)
        {
            _dbContext.Platforms.Add(platform);
            _dbContext.SaveChanges();
            return platform;
        }

        public void DeletePlatform(int id)
        {
            var platform = _dbContext.Platforms.FirstOrDefault(item => item.Id == id);
            if(platform is not null)
            {
                _dbContext.Platforms.Remove(platform);
                _dbContext.SaveChanges();
            }
        }

        public List<Platform> GetAllPlatforms()
        {
            return _dbContext.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            var platform = _dbContext.Platforms.FirstOrDefault(item => item.Id == id);
            if (platform is not null)
            {
                return platform;
            }
            else
                return new Platform();
        }

        public Platform UpdatePlatform(int id, Platform platform)
        {
            var platformFromDb = _dbContext.Platforms.FirstOrDefault(item => item.Id == id);
            if (platformFromDb is not null)
            {
                platformFromDb.LicenseKey = platform.LicenseKey;
                platformFromDb.Name = platform.Name;
                _dbContext.Platforms.Update(platformFromDb);
                _dbContext.SaveChanges();
                return platformFromDb;
            }
            else
                return new Platform();
        }

        public List<Platform> SearchPlatforms(List<string> searchItems, List<string> filterItems)
        {
            bool search(Platform item)
            {
                if (searchItems is null)
                    return true;

                var props = item.GetType().GetProperties();
                bool flag = false;
                foreach (var prop in props)
                {
                    var propValue = prop.GetValue(item)?.ToString();
                    if (propValue is not null)
                        flag = flag || searchItems.Contains(propValue);
                }
                return flag;
            }

            bool filter(Platform item)
            {
                if (filterItems is null)
                    return true;

                var props = item.GetType().GetProperties();
                bool flag = false;
                foreach (var prop in props)
                {
                    var propValue = prop.GetValue(item)?.ToString();
                    if (propValue is not null)
                        flag = flag || filterItems.Contains(propValue);
                }
                return flag;
            }

            return _dbContext.Platforms.ToList().Where(search).ToList();
            //return _dbContext.Platforms.Select<Platform>(search).ToList<Platform>();
        }
    }
}

