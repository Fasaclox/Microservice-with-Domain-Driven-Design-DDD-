using tvq_product_service.Domain.App_Product.Contract;
using tvq_product_service.Domain.App_Product.Entity.Sub_Entity;

namespace tvq_product_service.Domain.App_Product.Interface
{
    public interface IProduct_Category_Repository
    {
        Task<int> CreateProductCategoryAsync(Create_Category_Dto create_Category_Dto);
        Task<List<Create_Category_Dto>> GetAllProductCategorysAsync();
        Task<Product_Category> GetProductCategoryByIdAsync(int category_Id);
        Task<bool> UpdateProductCategoryAsync(Product_Category updatedCategory);
        Task<bool> DeleteProductCategoryAsync(int category_Id);
    }
}
