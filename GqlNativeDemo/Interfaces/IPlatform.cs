using System;
namespace GqlNativeDemo.Interfaces
{
	public interface IPlatform
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string LicenseKey { get; set; }
    }
}

