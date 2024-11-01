using System.Text.Json.Serialization;
using MVPShop.ProductApi.Models;

namespace MVPShop.ProductApi.DTOs;

public class ProductResponseDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public long Stock { get; set; }
    public string? ImageUrl { get; set; }
    public Category? Category { get; set; }

    // CategoryId apenas para referência
    public int CategoryId { get; set; }
}