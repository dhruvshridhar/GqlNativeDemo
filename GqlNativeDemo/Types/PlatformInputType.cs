using System;
using GraphQL.Types;

namespace GqlNativeDemo.Types
{
	public class PlatformInputType : InputObjectGraphType
	{
		public PlatformInputType()
		{
			Field<IntGraphType>("Id");
			Field<StringGraphType>("Name");
			Field<StringGraphType>("LicenseKey");
		}
	}
}

