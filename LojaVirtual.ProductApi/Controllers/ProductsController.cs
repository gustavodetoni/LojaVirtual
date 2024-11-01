using LojaVirtual.ProductApi.DTOs;
using LojaVirtual.ProductApi.Models;
using LojaVirtual.ProductApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IService<Product, ProductDTO> _service;

        public ProductsController(IService<Product, ProductDTO> service)
        {
            _service = service;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> CreateAsync([FromBody] ProductDTO dto)
        {
            if (dto == null)
                return BadRequest("Invalid data.");

            var createdProduct = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var product = await _service.GetAsync(p => p.Id == id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }

        [HttpPut("editar/{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ProductDTO dto)
        {
            if (dto == null || dto.Id != id)
                return BadRequest("Invalid data.");

            var updatedProduct = await _service.UpdateAsync(dto);
            return Ok(updatedProduct);
        }

        [HttpDelete("deletar/{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
