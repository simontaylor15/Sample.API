using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sample.API.Entities
{
    public class ProductInfoContext : DbContext
    {
        public ProductInfoContext(DbContextOptions<ProductInfoContext> options) : base(options)
        {
        }

        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SalesLT");
            modelBuilder.Entity<ProductModel>().ToTable("ProductModel");
            modelBuilder.Entity<Product>().ToTable("Product");
        }
    }
}
