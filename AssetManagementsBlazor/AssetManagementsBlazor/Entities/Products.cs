using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementsBlazor.Entities
{
    public class Products
    {
        [Key]
        public Guid ProductOid { get; set; }
        [ForeignKey("CategoryOid")]
        public Guid CategoryOid { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int StockQuantity { get; set; }
        public string? ProductName { get; set; } // Foreign Ke
    }
}
