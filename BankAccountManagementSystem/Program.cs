using BankAccountManagementSystem.Controllers;
using BankAccountManagementSystem.DBContext;
using BankAccountManagementSystem.Extenstions;
using BankAccountManagementSystem.Interface;
using BankAccountManagementSystem.Middleware;
using BankAccountManagementSystem.Model;
using BankAccountManagementSystem.Repository;
using BankAccountManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ContextClass>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});
// Add services to the container.

builder.Configuration.AddJsonFile("appsettings.json");
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddBankAccountServices(connectionString);

builder.Services.RegisterAutoMapper();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
