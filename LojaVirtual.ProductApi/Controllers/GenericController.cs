using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVPShop.ProductApi.Services;

namespace MVPShop.ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenericController<T, TRequestDto, TResponseDto> : ControllerBase where T : class
{
    private readonly IService<T, TRequestDto, TResponseDto> _service;
    private readonly IMapper _mapper;
    
    public GenericController(IService<T, TRequestDto, TResponseDto> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TResponseDto>>> GetAll()
    {
        var entities = await _service.GetAllAsync();
        if (entities == null || entities.Count() == 0)
        {
            return NotFound("No entities found");
        }
        
        return Ok(_mapper.Map<IEnumerable<TResponseDto>>(entities));
    }
    
    [HttpGet("{id:int:min(1)}")]
    public async Task<ActionResult<TResponseDto>> GetById(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null)
        {
            return NotFound($"Entity with id {id} not found");
        }
        return Ok(_mapper.Map<TResponseDto>(entity));
    }
    
    
    [HttpPost]
    public async Task<ActionResult<TResponseDto>> Post([FromBody]TRequestDto dto)
    {
        if (dto == null)
        {
            return BadRequest("Entity cannot be null");
        }
        var newEntity = await _service.PostAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = ((dynamic)newEntity).Id }, newEntity);
    }
    
    [HttpPut("{id:int:min(1)}")]
    public async Task<ActionResult<TResponseDto>> Put(int id, [FromBody]TRequestDto dto)
    {
        var dtoId = (int)typeof(TRequestDto).GetProperty("Id")?.GetValue(dto);
        if (dtoId != id)
        {
            return BadRequest("ID in URL does not match ID in body");
        }

        var entity = await _service.GetByIdAsync(id);
        if (entity == null)
        {
            return NotFound($"Entity with id {id} not found");
        }

        var updatedEntity = await _service.PutAsync(dto);
        return Ok(updatedEntity);
    }

    
    [HttpDelete("{id:int:min(1)}")]
    public async Task<ActionResult<TResponseDto>> Delete(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null)
        {
            return NotFound($"Entity with id {id} not found");
        }
        var deletedEntity = await _service.DeleteAsync(id);
        return Ok(deletedEntity);
    }
    
}