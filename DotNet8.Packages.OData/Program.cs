using DotNet8.Packages.OData.AppDbContextModels;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services.AddControllers()
    .AddOData(options =>
        options
            .AddRouteComponents("odata", GetEdmModel())
            .Select()
            .Expand()
            .Filter()
            .OrderBy()
            .Count()
            .SetMaxTop(100)
            .SkipToken()
    )
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
    opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
    },
    ServiceLifetime.Transient, ServiceLifetime.Transient
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static IEdmModel GetEdmModel()
{
    var odataBuilder = new ODataConventionModelBuilder();
    odataBuilder.EntitySet<Tbl_Blog>("Blog");
    return odataBuilder.GetEdmModel();
}