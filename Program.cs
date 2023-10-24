using Microsoft.Extensions.Configuration;
using ZetechWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using ZetechWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ZetechDbContext>(options => options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ZETECH_DB;Trusted_Connection=True;TrustServerCertificate=True"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPizzaService,PizzaService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IBatchService, BatchService>();

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
