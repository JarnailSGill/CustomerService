using Exclaimer.Service.Customer.Application;
using Exclaimer.Service.Customer.Application.Abstract;
using Exclaimer.Service.Customer.Infrastructure;
using Exclaimer.Service.Customer.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var cs = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<CustomerDbContext>(opt => opt.UseSqlServer(cs)); 

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
