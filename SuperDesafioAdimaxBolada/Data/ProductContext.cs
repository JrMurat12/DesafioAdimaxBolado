using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using SuperDesafioAdimaxBolada.Models;
using System.Collections.Generic;
namespace SuperDesafioAdimaxBolada.Data;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> opts)
        : base(opts)
    {

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}
