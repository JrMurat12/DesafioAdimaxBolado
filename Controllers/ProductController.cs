﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SuperDesafioAdimaxBolada.Data;
using SuperDesafioAdimaxBolada.Data.DTOs;
using SuperDesafioAdimaxBolada.Models;

namespace SuperDesafioAdimaxBolada.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private ProductContext _context;
    private IMapper _mapper;

    public ProductController(ProductContext context, IMapper mapper)
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
    public IActionResult InsertProduct([FromBody]CreateProductDTO productDto)
    {
        Product product = _mapper.Map<Product>(productDto);
        _context.Products.Add(product);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetProductById),
            new { id = product.Id },
            product);
    }

    [HttpGet]
    public IEnumerable<ReadProductDTO> GetProduct([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadProductDTO>>(_context.Products.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        var product = _context.Products
            .FirstOrDefault(product => product.Id == id);
        if (product == null) return NotFound();
        var productDto = _mapper.Map<ReadProductDTO>(product);
        return Ok(productDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, [FromBody] UpdateProductDTO productDto)
    {
        var product = _context.Products.FirstOrDefault(
            product => product.Id == id);
        if (product == null) return NotFound();
        _mapper.Map(productDto, product);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdatePartialProduct(int id, JsonPatchDocument<UpdateProductDTO> patch)
    {
        var product = _context.Products.FirstOrDefault(
            product => product.Id == id);
        if (product == null) return NotFound();

        var productForUpdate = _mapper.Map<UpdateProductDTO>(product);

        patch.ApplyTo(productForUpdate, ModelState);

        if (!TryValidateModel(productForUpdate))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(productForUpdate, product);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = _context.Products.FirstOrDefault(
            product => product.Id == id);
        if (product == null) return NotFound();
        _context.Remove(product);
        _context.SaveChanges();
        return NoContent();
    }
}
