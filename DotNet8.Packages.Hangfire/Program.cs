using DotNet8.Packages.Hangfire.AppDbContextModels;
using DotNet8.Packages.Hangfire.Dependencies;
using DotNet8.Packages.Hangfire.DTOs;
using DotNet8.Packages.Hangfire.Repositories;
using Hangfire;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDependencyInjection(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHangfireDashboard();

BackgroundJob.Schedule<IBlogRepository>(x => x.AddBlogAsync(new BlogRequestDto
{
    BlogTitle = "Hangfire Title",
    BlogAuthor = "Hangfire Author",
    BlogContent = "Hangfire Content"
}, new CancellationToken()), TimeSpan.FromMinutes(1));

app.UseAuthorization();

app.MapControllers();

app.Run();
