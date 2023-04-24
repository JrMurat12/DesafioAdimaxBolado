using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SuperDesafioAdimaxBolada.Data;
using SuperDesafioAdimaxBolada.Data.DTOs;
using SuperDesafioAdimaxBolada.Models;

namespace SuperDesafioAdimaxBolada.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductCategoryController : ControllerBase
{
    private ProductContext _context;
    private IMapper _mapper;

    public ProductCategoryController(ProductContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult InsertRelationship(CreateProductCategoryDTO relationshipDTO)
    {
        ProductCategory relationship = _mapper.Map<ProductCategory>(relationshipDTO);
        _context.ProductsCategories.Add(relationship);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetRelationshipById), new { productId = relationship.ProductId, categoryId = relationship.CategoryId }, relationship);
    }

    [HttpGet]
    public IEnumerable<ReadProductCategoryDTO> GetRelationship()
    {
        return _mapper.Map<List<ReadProductCategoryDTO>>(_context.ProductsCategories.ToList());
    }

    [HttpGet("{productId}/{categoryId}")]
    public IActionResult GetRelationshipById(int productId, int categoryId)
    {
        ProductCategory relationship = _context.ProductsCategories.FirstOrDefault(relationship => relationship.ProductId == productId && relationship.CategoryId == categoryId);
        if (relationship != null)
        {
            ReadProductCategoryDTO relationshipDTO = _mapper.Map<ReadProductCategoryDTO>(relationship);

            return Ok(relationshipDTO);
        }
        return NotFound();
    }
}
