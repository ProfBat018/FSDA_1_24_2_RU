using System.Reflection;
using Auth.API.Services.Classes;
using Auth.API.Services.Interfaces;
using Auth.Data.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<AuthDbContext>(ops => 
    ops.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapScalarApiReference();
app.UseHttpsRedirection();
app.MapControllers();


app.Run();

