using System.ComponentModel.DataAnnotations;

namespace MVPShop.ProductApi.DTOs;

public class ProductRequestDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "The Name field is required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "The Price field is required")]
    public decimal Price { get; set; }
    
    [Required(ErrorMessage = "The Description field is required")]
    [MinLength(5)]
    [MaxLength(200)]
    public string? Description { get; set; }
    
    [Required(ErrorMessage = "The Stock field is required")]
    [Range(1, 9999)]
    public long Stock { get; set; }
    
    public string? ImageUrl { get; set; }

    // CategoryId é necessário para vincular o produto a uma categoria
    [Required(ErrorMessage = "The CategoryId field is required")]
    public int CategoryId { get; set; }
}   