﻿using LibraryWebAPI.Configurations;
using LibraryWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookDbContext>(options => options.UseInMemoryDatabase("BookDB"));
builder.Services.AddAutoMapper(typeof(AutomapperInitilizer));
builder.Services.AddHttpLogging(opt =>
{
    opt.LoggingFields = HttpLoggingFields.All;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
