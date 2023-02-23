using LibraryWebAPI.Configurations;
using LibraryWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.HttpLogging;
using LibraryWebAPI.Data.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookDbContext>(options => options.UseInMemoryDatabase("BookDB"));
builder.Services.AddAutoMapper(typeof(AutomapperInitilizer));
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddHttpLogging(opt =>
{
    opt.LoggingFields = HttpLoggingFields.All;
});
var app = builder.Build();

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
