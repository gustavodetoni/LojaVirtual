using LojaVirtual.ProductApi.Services.Interfaces;
using LojaVirtual.ProductApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.ProductApi.Models;

namespace LojaVirtual.ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IService<Category, CategoryDTO> _service;

        public CategoriesController(IService<Category, CategoryDTO> service)
        {
            _service = service;
        }

        [HttpPost("/criar")]
        public async Task<IActionResult> CreateAsync([FromBody] CategoryDTO dto)
        {
            if (dto == null)
                return BadRequest("Invalid data.");

            var createdCategory = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdCategory.CategoryId }, createdCategory);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var category = await _service.GetAsync(c => c.CategoryId == id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await _service.GetAllAsync();
            return Ok(categories);
        }

        [HttpPut("editar/{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CategoryDTO dto)
        {
            if (dto == null || dto.CategoryId != id)
                return BadRequest("Invalid data.");

            var updatedCategory = await _service.UpdateAsync(dto);
            return Ok(updatedCategory);
        }

        [HttpDelete("deletar/{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
