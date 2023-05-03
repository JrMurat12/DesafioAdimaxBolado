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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ProductCategory>()
            .HasKey(productCategory => new { productCategory.ProductId, productCategory.CategoryId });

        builder.Entity<ProductCategory>()
            .HasOne(productCategory => productCategory.Category)
            .WithMany(category => category.ProductsCategories)
            .HasForeignKey(productCategory => productCategory.CategoryId)
            .OnDelete(DeleteBehavior.Restrict); ;

        builder.Entity<ProductCategory>()
            .HasOne(productCategory => productCategory.Product)
            .WithMany(product => product.ProductsCategories)
            .HasForeignKey(productCategory => productCategory.ProductId)
            .OnDelete(DeleteBehavior.Restrict); ;

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductsCategories { get; set; }
    public DbSet<ProductLog> ProductLogs { get; set; }  
}
