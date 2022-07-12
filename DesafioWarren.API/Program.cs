using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using DomainServices;
using Infrastructure.Data.Context;
using AppServices.ServicesApplication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var assemblies = new[] { Assembly.Load("AppServices")};
builder.Services
    .AddDbContext<DatabaseDbContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("Default");
        options.UseMySql(connectionString,
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"),
        b => b.MigrationsAssembly("Infrastructure.Data"));
    })
    .AddControllers()
    .AddFluentValidation(config => config.RegisterValidatorsFromAssembly(assemblies.First()));

builder.Services.AddMemoryCache();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddTransient<ICustomerAppService, CustomerAppService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper((_, config) => config.AddMaps(assemblies), assemblies);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();