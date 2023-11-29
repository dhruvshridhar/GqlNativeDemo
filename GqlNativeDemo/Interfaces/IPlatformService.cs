using System;
using GqlNativeDemo.Models;

namespace GqlNativeDemo.Interfaces
{
	public interface IPlatformService
	{
        public List<Platform> GetAllPlatforms();
        public Platform AddPlatform(Platform platform);
        public Platform UpdatePlatform(int id, Platform platform);
		public void DeletePlatform(int id);
		public Platform GetPlatformById(int id);
        public List<Platform> SearchPlatforms(List<string> searchItems, List<string> filterItems);
    }
}

