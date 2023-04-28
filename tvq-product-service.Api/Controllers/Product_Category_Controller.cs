using Microsoft.AspNetCore.Mvc;
using tvq_product_service.Domain.App_Product.Contract;
using tvq_product_service.Domain.App_Product.Entity.Sub_Entity;
using tvq_product_service.Domain.App_Product.Interface;

namespace tvq_product_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product_Category_Controller : ControllerBase
    {
        private readonly IProduct_Category_Repository _product_Category_Repository;

        public Product_Category_Controller(IProduct_Category_Repository product_Category_Repository)
        {
            _product_Category_Repository = product_Category_Repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductCategories()
        {
            var categories = await _product_Category_Repository.GetAllProductCategorysAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product_Category>> GetProductCategoryById(int id)
        {
            var category = await _product_Category_Repository.GetProductCategoryByIdAsync(id);
            return Ok(category);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateProductCategory(Create_Category_Dto create_Category_Dto)
        {
            var category_Id = await _product_Category_Repository.CreateProductCategoryAsync(create_Category_Dto);
            return CreatedAtAction(nameof(GetAllProductCategories), new { id = category_Id }, category_Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductCategory(int id, [FromBody] Product_Category updatedProductCategory)
        {
            if (id != updatedProductCategory.Category_Id)
            {
                return BadRequest();
            }

            var result = await _product_Category_Repository.UpdateProductCategoryAsync(updatedProductCategory);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategory(int id)
        {
            var result = await _product_Category_Repository.DeleteProductCategoryAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
