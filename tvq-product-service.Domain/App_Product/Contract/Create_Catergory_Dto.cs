using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace tvq_product_service.Domain.App_Product.Contract
{
    public class Create_Category_Dto{

    [Key]
    public int Category_Id { get; set; }
    [Required]
    [StringLength(100)]
    public string? Category_Name { get; set; }
    public DateTime Created_At { get; set;}
    public DateTime Deleted_At { get; set; }
    public DateTime Modified_At { get; set; }

    }
    
}