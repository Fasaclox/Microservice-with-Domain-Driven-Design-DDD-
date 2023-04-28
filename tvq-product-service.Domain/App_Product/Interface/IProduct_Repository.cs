using tvq_product_service.Domain.App_Product.Contract;
using tvq_product_service.Domain.App_Product.Entity.Domain_Entity;

namespace tvq_product_service.Domain.App_Product.Interface
{
    public interface IProduct_Repository
    {
        Task<int> CreateProductAsync(Create_Product_Dto create_Product_Dto);
        Task<List<Create_Product_Dto>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task<bool> UpdateProductAsync(Product updatedProduct);
        Task<bool> DeleteProductAsync(int product_Id);
    }
}
