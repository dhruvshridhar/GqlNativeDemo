using System;
using GqlNativeDemo.Interfaces;
using GqlNativeDemo.Models;
using GqlNativeDemo.Types;
using GraphQL;
using GraphQL.Types;

namespace GqlNativeDemo.Mutations
{
	public class PlatformMutation : ObjectGraphType
	{
		public PlatformMutation(IPlatformService platformService)
		{
            Field<PlatformType>("createPlatform"
                , arguments: new QueryArguments(new QueryArgument<PlatformInputType> { Name = "platform" })
                , resolve: context => { return platformService.AddPlatform(context.GetArgument<Platform>("platform")); });

            Field<PlatformType>("updatePlatform"
                , arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id"},
                new QueryArgument<PlatformInputType> { Name = "platform" })
                , resolve: context => { return platformService.UpdatePlatform(context.GetArgument<int>("id")
                    ,context.GetArgument<Platform>("platform")); });

            Field<StringGraphType>("deletePlatform"
                , arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" })
                , resolve: context => { platformService.DeletePlatform(context.GetArgument<int>("id")); return "done"; });
        }
	}
}

