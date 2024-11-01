using ApiCatalogo.Repositories;
using Microsoft.EntityFrameworkCore;
using MVPShop.ProductApi.DTOs;
using MVPShop.ProductApi.Infrastructure;
using MVPShop.ProductApi.Models;
using MVPShop.ProductApi.Repositories;
using MVPShop.ProductApi.Repositories.Interfaces;
using MVPShop.ProductApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string mySqlConnectionStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IService<Product, ProductRequestDTO, ProductResponseDTO>, ProductService>();
builder.Services.AddScoped<IService<Category, CategoryRequestDTO, CategoryResponseDTO>, CategoryService>();



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
