using Exclaimer.Service.Customer.Application;
using Exclaimer.Service.Customer.Application.Abstract;
using Exclaimer.Service.Customer.Application.DTOs;
using Exclaimer.Service.Customer.Application.Mapping;
using Exclaimer.Service.Customer.Domain.Entities;
using Exclaimer.Service.Customer.Infrastructure;
using Exclaimer.Service.Customer.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Project dependencies
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

//Config
var cs = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<CustomerDbContext>(opt => opt.UseSqlServer(cs));

//MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

//AutoMapper
builder.Services.AddAutoMapper(typeof(PersonMappingProfile).GetTypeInfo().Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
