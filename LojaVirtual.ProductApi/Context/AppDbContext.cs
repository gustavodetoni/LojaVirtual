﻿using Microsoft.EntityFrameworkCore;
using MVPShop.ProductApi.Models;

namespace LojaVirtual.ProductApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }


        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(c => c.Id);

            modelBuilder.Entity<Category>().
                            Property(c=> c.Name).
                            HasMaxLength(100). 
                                IsRequired();

            modelBuilder.Entity<Product>().
                            Property(c => c.Name).
                            HasMaxLength(100).
                                IsRequired();

            modelBuilder.Entity<Product>().
                            Property(c => c.Description).
                            HasMaxLength(255).
                                IsRequired();

            modelBuilder.Entity<Product>().
                            Property(c => c.ImageUrl).
                            HasMaxLength(255).
                                IsRequired();

            modelBuilder.Entity<Product>().
                            Property(c => c.Price).
                            HasPrecision(12, 2);

            modelBuilder.Entity<Category>().
                       HasMany(g => g.Products)
                       .WithOne(c => c.Category)
                       .IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Material Escolar",
                },
                new Category
                {
                    Id = 2,
                    Name = "Acessorios",
                });
        }
    }
}
