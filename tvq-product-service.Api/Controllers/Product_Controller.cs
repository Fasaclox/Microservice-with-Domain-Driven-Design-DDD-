using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using tvq_product_service.Domain.App_Product.Contract;
using tvq_product_service.Domain.App_Product.Entity.Domain_Entity;
using tvq_product_service.Domain.App_Product.Interface;

namespace tvq_product_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product_Controller : ControllerBase
    {
        private readonly IProduct_Repository _product_Repository;

        public Product_Controller(IProduct_Repository product_Repository)
        {
            _product_Repository = product_Repository;
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _product_Repository.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _product_Repository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("post")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateProduct(Create_Product_Dto createProductDto)
        {
            var product_Id = await _product_Repository.CreateProductAsync(createProductDto);
            return CreatedAtAction(nameof(GetProductById), new { id = product_Id }, product_Id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            if (id != updatedProduct.Product_Id)
            {
                return BadRequest();
            }

            var result = await _product_Repository.UpdateProductAsync(updatedProduct);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _product_Repository.DeleteProductAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
