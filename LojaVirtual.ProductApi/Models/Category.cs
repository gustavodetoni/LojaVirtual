using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LojaVirtual.ProductApi.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }

    [JsonIgnore]
    public ICollection<Product>? Products { get; set; }
}
