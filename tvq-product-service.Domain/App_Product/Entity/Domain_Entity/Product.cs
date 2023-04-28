using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tvq_product_service.Domain.App_Product.Entity.Sub_Entity;
namespace tvq_product_service.Domain.App_Product.Entity.Domain_Entity

{

   

public class Product {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Product_Id { get; set; }

    [Required]
    [StringLength(200)]
    public string? Product_Name { get; set; }

    [StringLength(500)]
    public string? Product_Description { get; set; }

    [ForeignKey("Category")]
    public int Category_Id { get; set; }
    public virtual Product_Category? Category_Name { get; set; }

    public int Quantity { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }


    [DataType(DataType.Date)]
    public DateTime Expiry_Date { get; set; }

    [DataType(DataType.Date)]
    public DateTime Created_At { get; set;}

    [DataType(DataType.Date)]
    public DateTime Deleted_At { get; set; }

    [DataType(DataType.Date)]
    public DateTime Modified_At { get; set; }
    
}

    
}
   

    
