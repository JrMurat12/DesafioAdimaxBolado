using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SuperDesafioAdimaxBolada.Data.DTOs;
using SuperDesafioAdimaxBolada.Data;
using SuperDesafioAdimaxBolada.Models;

namespace SuperDesafioAdimaxBolada.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private ProductContext _context;
    private IMapper _mapper;

    public CategoryController(ProductContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um produto ao banco de dados
    /// </summary>
    /// <param name="productDto">Objeto com os campos necessários para criação de um produto</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult InsertCategory([FromBody] CreateCategoryDTO categoryDto)
    {
        Category category = _mapper.Map<Category>(categoryDto);
        _context.Categories.Add(category);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetCategoryById),
            new { id = category.Id },
            category);
    }

    [HttpGet]
    public IEnumerable<ReadCategoryDTO> GetCategory([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadCategoryDTO>>(_context.Categories.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetCategoryById(int id)
    {
        var category = _context.Categories
            .FirstOrDefault(category => category.Id == id);
        if (category == null) return NotFound();
        var categoryDto = _mapper.Map<ReadCategoryDTO>(category);
        return Ok(categoryDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategory(int id, [FromBody] UpdateCategoryDTO categoryDto)
    {
        var category = _context.Categories.FirstOrDefault(
            category => category.Id == id);
        if (category == null) return NotFound();
        _mapper.Map(categoryDto, category);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        var category = _context.Categories.FirstOrDefault(
            category => category.Id == id);
        if (category == null) return NotFound();
        _context.Remove(category);
        _context.SaveChanges();
        return NoContent();
    }
}
