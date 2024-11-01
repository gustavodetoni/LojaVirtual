using System.ComponentModel.DataAnnotations;

namespace MVPShop.ProductApi.DTOs;

public class CategoryRequestDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "The Name field is required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }
    
}