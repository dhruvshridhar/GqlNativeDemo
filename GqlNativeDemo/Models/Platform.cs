using System;
using GqlNativeDemo.Interfaces;

namespace GqlNativeDemo.Models
{
	public class Platform : IPlatform
	{
		public int Id { get; set; }
		public string Name { get; set; } = "";
		public string LicenseKey { get; set; }
		public ICollection<Command> Commands { get; set; }
	}
}

