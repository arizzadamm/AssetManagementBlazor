using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementsBlazor.Entities
{
    public class OrderDetail
    {
        [Key]
        public Guid OrderDetailOid { get; set; }
        [ForeignKey("OrderOid")]
        public Guid OrderOid { get; set; }
        [ForeignKey("ProductOid")]
        public Guid ProductOid { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }
    }
}
