using Microsoft.EntityFrameworkCore;
using GeekShop.Products.Api.Data.ValueObjects;

namespace GeekShop.Products.Api.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(){}

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options){}

        public DbSet<Product> Products { get; set; }

        public DbSet<GeekShop.Products.Api.Data.ValueObjects.ProductVO> ProductVO { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(new Product()
            {
                Id = 1001,
                Name = "Seed Product",
                Price = 69,
                ImageUrl = "randomImg",
                Description = "Descrição Seed",
                CategoryName = "Roupas"
            });
        }

    }
}
