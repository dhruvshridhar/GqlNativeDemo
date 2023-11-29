using System;
using GqlNativeDemo.Interfaces;
using GqlNativeDemo.Types;
using GraphQL;
using GraphQL.Types;

namespace GqlNativeDemo.Queries
{
	//This is the class which gets exposed to our client
	public class PlatformQuery : ObjectGraphType
	{
		public PlatformQuery(IPlatformService platformService)
		{
			//ListGraphType is equivalent of List in GQL
			Field<ListGraphType<PlatformType>>("platforms", resolve: context => { return platformService.GetAllPlatforms(); });

			//IntGraphType is equivalent of int in GQL
			Field<PlatformType>("platform"
				, arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" })
				, resolve: context => { return platformService.GetPlatformById(context.GetArgument<int>("id")); });

			Field<ListGraphType<PlatformType>>("platformss",
				arguments: new QueryArguments(new QueryArgument<ListGraphType<StringGraphType>> { Name = "search" },
				new QueryArgument<ListGraphType<StringGraphType>> { Name = "filter"}),
				resolve: context => {
					return platformService.SearchPlatforms(context.GetArgument<List<string>>("search"),
					context.GetArgument<List<string>>("filter"));
				});
		}
	}
}

