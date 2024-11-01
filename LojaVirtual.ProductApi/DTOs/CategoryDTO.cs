using LojaVirtual.ProductApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LojaVirtual.ProductApi.DTOs
{
    public class CategoryDTO : IEntityDto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }
        //[JsonIgnore]
        public ICollection<Product>? Products { get; set; }
    }
}
