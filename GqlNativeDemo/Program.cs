using GqlNativeDemo.Database;
using GqlNativeDemo.Interfaces;
using GqlNativeDemo.Queries;
using GqlNativeDemo.Schema;
using GqlNativeDemo.Services;
using GqlNativeDemo.Types;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using GraphQL;
using GqlNativeDemo.Mutations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add db
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("default"));
});

//Add Service, Type, Query, Schema and enable GQL
builder.Services.AddTransient<IPlatformService, PlatformService>();
builder.Services.AddScoped<PlatformType>();
builder.Services.AddScoped<PlatformQuery>();
builder.Services.AddScoped<PlatformMutation>();
builder.Services.AddScoped<ISchema,PlatformSchema>();
builder.Services.AddGraphQL(options =>
{
    options.AddSystemTextJson();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseGraphQLGraphiQL("/graphql");
app.UseGraphQL<ISchema>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

