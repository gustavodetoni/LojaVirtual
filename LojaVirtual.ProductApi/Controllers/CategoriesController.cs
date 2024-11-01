using ApiCatalogo.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVPShop.ProductApi.DTOs;
using MVPShop.ProductApi.Models;
using MVPShop.ProductApi.Services;

namespace MVPShop.ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : GenericController<Category, CategoryRequestDTO, CategoryResponseDTO>
{ 
    private readonly  ICategoryService _categoryService;
    public CategoriesController(ICategoryService categoryService, IService<Category, CategoryRequestDTO, CategoryResponseDTO> service, IMapper mapper) : base(service, mapper)
        {
            _categoryService = categoryService;
        }
   
    
    
    
    
    [HttpGet("products/{id}")]
    public async Task<ActionResult<CategoryResponseDTO>> GetCategoriesProducts(int id)
    {
        var category = await _categoryService.GetCategoryProducts(id);
        if (category == null)
        {
            return NotFound("No category with products found");
        }
    
        return Ok(category); 
    }


    
}

