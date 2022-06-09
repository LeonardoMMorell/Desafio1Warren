using AppServices;
using AppServices.Validators;
using DomainServices;
using FluentValidation.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var assemblies = new[] { Assembly.Load("AppServices") };
builder.Services
    .AddControllers()
    .AddFluentValidation(config => config.RegisterValidatorsFromAssembly(assemblies.First()));

builder.Services.AddMemoryCache();
builder.Services.AddSingleton<ICustomerServices, CustomerServices>();
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