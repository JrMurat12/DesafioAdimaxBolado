using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SuperDesafioAdimaxBolada.Data;
using SuperDesafioAdimaxBolada.Data.DTOs;
using SuperDesafioAdimaxBolada.Models;
using System;
using System.Data.Entity;

namespace SuperDesafioAdimaxBolada.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductLogController : ControllerBase
{
    private ProductContext _context;
    private IMapper _mapper;

    public ProductLogController(ProductContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("[action]")]
    public IActionResult LogUpdate()
    {
        RecurringJob.AddOrUpdate(() => SaveLog(), Cron.Minutely);
        return Ok("Log gravado!");
    }

    [NonAction]
    public void SaveLog()
    {
        var listproduct = _mapper.Map<List<ReadProductDTO>>(_context.Products.Where(productsToUpdate => productsToUpdate.HasPendingLogUpdate == true).ToList());

        foreach (var product in listproduct)
        {
            var productToUpdate = _context.Products.Find(product.Id);

            string productJson = JsonConvert.SerializeObject(product);

            _context.ProductLogs.Add(new ProductLog
            {
                ProductId = productToUpdate.Id,
                UpdatedAt = DateTime.Now,
                ProductJson = productJson
            });

            productToUpdate.HasPendingLogUpdate = false;
        }

        _context.SaveChanges();
    }
}
