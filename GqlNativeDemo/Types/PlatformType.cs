using System;
using GqlNativeDemo.Models;
using GraphQL.Types;

namespace GqlNativeDemo.Types
{
	public class PlatformType : ObjectGraphType<Platform>
	{
		public PlatformType()
		{
			//Here we expose our fields of model class
			Field(p => p.Id);
			Field(p => p.Name);
			Field(p => p.LicenseKey);
		}
	}
}

