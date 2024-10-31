using LojaVirtual.ProductApi.Models;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.ProductApi.DTOs
{
    public class ProductDTO
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "The name is Required")]
        [StringLength(100, MinimumLength = 3)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "The price is Required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The description is Required")]
        [StringLength(100, MinimumLength = 5)]
        public string? Description { get; set; }
        [Required(ErrorMessage = "The stock is Required")]
        [Range(1, 999)]
        public long Stock { get; set; }
        public string? ImageUrl { get; set; }

        public Category? Category { get; set; }
        public int CategoryId { get; set; }
    }
}
