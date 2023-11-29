using System;
using GqlNativeDemo.Mutations;
using GqlNativeDemo.Queries;

namespace GqlNativeDemo.Schema
{
	public class PlatformSchema : GraphQL.Types.Schema
	{
		public PlatformSchema(PlatformQuery platformQuery, PlatformMutation platformMutation)
		{
			//In case we have multiple queries
			//e.g. Platforms, commands, then we need to create one root query and then register here.
			//Watch udemy course sec7 44
			Query = platformQuery;
			Mutation = platformMutation;
		}
	}
}

