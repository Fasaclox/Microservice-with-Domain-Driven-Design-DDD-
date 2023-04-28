using Microsoft.EntityFrameworkCore;
using tvq_product_service.Domain.App_Product.Entity.Domain_Entity;
using tvq_product_service.Domain.App_Product.Entity.Sub_Entity;

namespace tvq_product_service.Infrastructure.App_Product.Context
{
    public class Product_Context:DbContext
    {
        public Product_Context(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_Category> Product_Categories { get; set; }

    }

    
}
