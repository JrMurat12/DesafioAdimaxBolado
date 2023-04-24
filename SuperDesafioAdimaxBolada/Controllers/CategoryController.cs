using AutoMapper;
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
    /// Adiciona uma categoria ao banco de dados
    /// </summary>
    /// <param name="categoryDto">Objeto com os campos necessários para criação de uma categoria</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult InsertCategory([FromBody] CreateCategoryDTO categoryDto)
    {
        Category category = _mapper.Map<Category>(categoryDto);
        _context.Categories.Add(category);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetCategoryById),new { id = category.Id },categoryDto);
    }

    [HttpGet]
    public IEnumerable<ReadCategoryDTO> GetCategory([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadCategoryDTO>>(_context.Categories.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetCategoryById(int id)
    {
        Category category = _context.Categories.FirstOrDefault(category => category.Id == id);
        if (category != null)
        {
            var categoryDto = _mapper.Map<ReadCategoryDTO>(category);
            return Ok(categoryDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategory(int id, [FromBody] UpdateCategoryDTO categoryDto)
    {
        Category category = _context.Categories.FirstOrDefault(category => category.Id == id);
        if (category == null)
        {
            return NotFound();
        }
        _mapper.Map(categoryDto, category);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        Category category = _context.Categories.FirstOrDefault(category => category.Id == id);
        if (category == null)
        {
            return NotFound();
        }
        _context.Remove(category);
        _context.SaveChanges();
        return NoContent();
    }
}
