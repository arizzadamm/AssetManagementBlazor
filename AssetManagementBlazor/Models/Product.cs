using System.ComponentModel.DataAnnotations;

namespace AssetManagementBlazor.Models
{
    public class Product
    {
        [Key]
        public Guid ProductOid { get; set; }
        public Guid CategoryOid { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int ProductName { get; set; } // Foreign Key
    }
}
