
using Microsoft.EntityFrameworkCore;
using tvq_product_service.Domain.App_Product.Contract;
using tvq_product_service.Domain.App_Product.Entity.Domain_Entity;
using tvq_product_service.Domain.App_Product.Interface;
using tvq_product_service.Infrastructure.App_Product.Context;

namespace tvq_product_service.Infrastructure.App_Product.Repository
{
    public class Product_Repository : IProduct_Repository
    {
        private readonly Product_Context _context;
        public Product_Repository(Product_Context context)
        {
            _context = context;
       

        }

        public async Task<List<Create_Product_Dto>> GetAllProductsAsync()
        {
            var products = await _context.Products
                .Select(p => new Create_Product_Dto
                {
                    Product_Id = p.Product_Id,
                    Product_Name = p.Product_Name,
                    Product_Description = p.Product_Description,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Category_Name = p.Category_Name,
                    Expiry_Date = p.Expiry_Date
                })
                .ToListAsync();

            return products;
        }

        public async Task<Product> GetProductByIdAsync(int product_Id)
        {
            var product = await _context.Products.FindAsync(product_Id);
            if (product == null)
            {
                throw new ArgumentException("Product not found", nameof(product_Id));
            }
            return product;
        }



        public async Task<int> CreateProductAsync(Create_Product_Dto create_Product_Dto)
        {
            var product = new Product()
            {
                Product_Name = create_Product_Dto.Product_Name,
                Product_Description = create_Product_Dto.Product_Description,
                Category_Name = create_Product_Dto.Category_Name,
                Quantity = create_Product_Dto.Quantity,
                Price = create_Product_Dto.Price,
                Expiry_Date = create_Product_Dto.Expiry_Date,
                Created_At = create_Product_Dto.Created_At = DateTime.Now

            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Product_Id;

        }

        public async Task<bool> UpdateProductAsync(Product updatedProduct)
        {
            var product = await _context.Products.FindAsync(updatedProduct.Product_Id);
            if (product == null)
            {
                return false;
            }

            product.Product_Name = updatedProduct.Product_Name;
            product.Price = updatedProduct.Price;
            product.Quantity = updatedProduct.Quantity;
            product.Category_Name = updatedProduct.Category_Name;
            product.Expiry_Date = updatedProduct.Expiry_Date;
            product.Modified_At = updatedProduct.Modified_At = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductAsync(int product_Id)
        {
            var product = await _context.Products.FindAsync(product_Id);
            if (product == null)
            {
                return false;
            }

            product.Deleted_At = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
