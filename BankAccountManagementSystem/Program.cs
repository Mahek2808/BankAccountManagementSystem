using BankAccountManagementSystem.Controllers;
using BankAccountManagementSystem.DBContext;
using BankAccountManagementSystem.Interface;
using BankAccountManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ContextClass>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IBankAccount, AccountDetailsService>();
builder.Services.AddTransient<ITransaction, TransactionDetailsService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
