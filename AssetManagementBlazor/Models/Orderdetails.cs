using System.ComponentModel.DataAnnotations;

namespace AssetManagementBlazor.Models
{
    public class Orderdetails
    {
        [Key]
        public Guid OrderDetailOid { get; set; }
        public Guid OrderOid { get; set; }
        public Guid ProductOid { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }
    }
}
