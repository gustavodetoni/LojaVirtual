using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVPShop.ProductApi.DTOs;
using MVPShop.ProductApi.Models;

namespace MVPShop.ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : GenericController<Product, ProductRequestDTO, ProductResponseDTO>
{
    public ProductsController(IService<Product, ProductRequestDTO, ProductResponseDTO> service, IMapper mapper) : base(service, mapper)
    {
    }
}