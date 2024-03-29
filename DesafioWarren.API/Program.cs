using DomainServices;
using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Infrastructure.Data.Context;
using Application.Services;
using Application.Interfaces;
using DomainServices.Interfaces;
using EntityFrameworkCore.UnitOfWork.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var assembly = Assembly.Load("Application");
builder.Services
    .AddControllers(); 

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("Default"),
        ServerVersion.Parse("8.0.29-mysql"),
        config => config.MigrationsAssembly("Infrastructure.Data"));
});

builder.Services.AddFluentValidation(config => config.RegisterValidatorsFromAssembly(assembly));

builder.Services.AddTransient<ICustomerServices, CustomerServices>();
builder.Services.AddTransient<DbContext, DatabaseContext>();
builder.Services.AddTransient<ICustomerAppService, CustomerAppService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(mapperConfig => mapperConfig.AddMaps(assembly), assembly);
builder.Services.AddUnitOfWork<DatabaseContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();