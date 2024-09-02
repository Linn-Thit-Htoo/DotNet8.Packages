using DotNet8.Packages.DbService;
using DotNet8.Packages.GraphQL.Queries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
}, ServiceLifetime.Transient, ServiceLifetime.Transient);

builder.Services.AddGraphQLServer().AddQueryType<BlogQuery>();

var app = builder.Build();

app.MapGraphQL("/");

app.UseHttpsRedirection();

app.Run();
