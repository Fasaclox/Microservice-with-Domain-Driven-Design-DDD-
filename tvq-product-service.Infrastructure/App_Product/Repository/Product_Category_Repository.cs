
using Microsoft.EntityFrameworkCore;
using tvq_product_service.Domain.App_Product.Contract;
using tvq_product_service.Domain.App_Product.Entity.Sub_Entity;
using tvq_product_service.Domain.App_Product.Interface;
using tvq_product_service.Infrastructure.App_Product.Context;

namespace tvq_product_service.Infrastructure.App_Product.Repository
{
    public class Product_Category_Repository : IProduct_Category_Repository
    {
        private readonly Product_Context _context;
        public Product_Category_Repository(Product_Context context)
        {
            _context = context;
       

        }

        public async Task<List<Create_Category_Dto>> GetAllProductCategorysAsync()
        {
            var categorys = await _context.Product_Categories
                .Select(p => new Create_Category_Dto
                {
                    Category_Id = p.Category_Id,
                    Category_Name = p.Category_Name,
                    Created_At = p.Created_At
                })
                .ToListAsync();

            return categorys;
        }

        public async Task<Product_Category> GetProductCategoryByIdAsync(int category_Id)
        {
            var category = await _context.Product_Categories.FindAsync(category_Id);
            if (category == null)
            {
                throw new ArgumentException("Category not found", nameof(category_Id));
            }
            return category;
        }



        public async Task<int> CreateProductCategoryAsync(Create_Category_Dto create_Category_Dto)
        {
            var category = new Product_Category()
            {
                Category_Name = create_Category_Dto.Category_Name,
                Created_At = create_Category_Dto.Created_At = DateTime.Now

            };
            _context.Product_Categories.Add(category);
            await _context.SaveChangesAsync();
            return category.Category_Id;

        }

        public async Task<bool> UpdateProductCategoryAsync(Product_Category updatedProductCategory)
        {
            var category = await _context.Product_Categories.FindAsync(updatedProductCategory.Category_Id);
            if (category == null)
            {
                return false;
            }

            category.Category_Name = updatedProductCategory.Category_Name;
            category.Modified_At = updatedProductCategory.Modified_At = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductCategoryAsync(int category_Id)
        {
            var category = await _context.Product_Categories.FindAsync(category_Id);
            if (category == null)
            {
                return false;
            }

            category.Deleted_At = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
