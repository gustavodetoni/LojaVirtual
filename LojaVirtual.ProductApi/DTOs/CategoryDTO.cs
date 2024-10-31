using LojaVirtual.ProductApi.Models;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.ProductApi.DTOs
{
    public class CategoryDTO 
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "The name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
