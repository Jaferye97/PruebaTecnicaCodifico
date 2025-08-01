using Application.Ports;
using Application.UseCases.Employees;
using Application.UseCases.Orders;
using Microsoft.EntityFrameworkCore;
using ReporitorySqlServer.Context;
using ReporitorySqlServer.Dapper.Config;
using ReporitorySqlServer.Dapper.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Conexion Bd
builder.Services.AddDbContext<EntityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDb")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<SqlConnectionFactory>();

builder.Services.AddScoped<GetOrdersByCustIdUseCase>();
builder.Services.AddScoped<GetAllEmployeesUseCase>();

builder.Services.AddScoped<IOrdersRepositorySqlServerPort, OrdersDapperRepository>();
builder.Services.AddScoped<IEmployeesRepositorySqlServerPort, EmployeesDapperRepository>();

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
