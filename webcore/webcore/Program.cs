using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using webcore.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<UserContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DbCon")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Add CORS configuration here
app.UseCors(options =>
{
    options.WithOrigins("http://localhost:3000") // Thay localhost:3000 bằng địa chỉ nguồn gốc thực tế của ứng dụng ReactJS
           .AllowAnyMethod()
           .AllowAnyHeader();
});


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
