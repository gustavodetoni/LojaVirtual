using LojaVirtual.ProductApi.Context;
using LojaVirtual.ProductApi.DTOs;
using LojaVirtual.ProductApi.DTOs.Mappings;
using LojaVirtual.ProductApi.Models;
using LojaVirtual.ProductApi.Repositories;
using LojaVirtual.ProductApi.Repositories.Interfaces;
using LojaVirtual.ProductApi.Services;
using LojaVirtual.ProductApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped(typeof(IService<,>), typeof(Service<,>));

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
