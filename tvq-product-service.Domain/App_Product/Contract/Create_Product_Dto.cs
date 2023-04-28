using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tvq_product_service.Domain.App_Product.Entity.Sub_Entity;
using Microsoft.EntityFrameworkCore;
using tvq_product_service.Domain.App_Product.Entity.Domain_Entity;

namespace tvq_product_service.Domain.App_Product.Contract
{
    public class Create_Product_Dto
    {
        [Key]
        public int Product_Id { get; set; }

        [Required]
        [StringLength(200)]
        public string? Product_Name { get; set; }

        [Required(ErrorMessage = "Product Description field is required.")]
        [StringLength(500)]
        public string? Product_Description { get; set; }

        [Required(ErrorMessage = "Product Category field is required.")]
        [ForeignKey("Category")]
        public int Category_Id { get; set; }
        public virtual Product_Category? Category_Name { get; set; }

        [Required(ErrorMessage = "Kindly State Product Quantity.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Product Price field is required.")]
        public decimal Price { get; set; }

        
        [Required(ErrorMessage = "Please State Product Expiration Date.")]
        public DateTime Expiry_Date { get; set; }
        public DateTime Created_At { get; set;}
        public DateTime Deleted_At { get; set; }
        public DateTime Modified_At { get; set; }
    }



}
