using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MVPShop.ProductApi.Models;

namespace MVPShop.ProductApi.DTOs;

public class CategoryResponseDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Product>? Products { get; set; }
}