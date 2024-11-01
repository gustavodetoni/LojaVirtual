using Microsoft.EntityFrameworkCore;
using MVPShop.ProductApi.Models;

namespace MVPShop.ProductApi.Infrastructure;

public class AppDbContext : DbContext
{
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    protected override void OnModelCreating(ModelBuilder mb)
    {
        // Category
        mb.Entity<Category>().HasKey(c => c.Id);
        mb.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(100);
        
        // Product
        mb.Entity<Product>().HasKey(p => p.Id);
        mb.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        mb.Entity<Product>().Property(p => p.Description).HasMaxLength(200).IsRequired();
        mb.Entity<Product>().Property(p => p.ImageUrl).HasMaxLength(200).IsRequired();
        mb.Entity<Product>().Property(p => p.Price).HasPrecision(10, 2);

        mb.Entity<Category>()
            .HasMany(g => g.Products)
            .WithOne(p => p.Category)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);


        mb.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Material Escolar"
            },
            new Category
            {
                Id = 2,
                Name = "Acessórios"
            }); 
    }
}