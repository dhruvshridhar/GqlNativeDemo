using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GqlNativeDemo.Models
{
	public class Command
	{
		[Key]
		public int Id { get; set; }
		public string HowTo { get; set; }
		public string CommandLine { get; set; }

		[ForeignKey(nameof(Platform))]
		public int PlatformId { get; set; }
		public Platform? Platform { get; set; }
	}
}

