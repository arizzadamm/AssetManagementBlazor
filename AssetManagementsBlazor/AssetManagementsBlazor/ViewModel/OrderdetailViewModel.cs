using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementsBlazor.ViewModel
{
    public class OrderdetailViewModel
    {
        public Guid OrderDetailOid { get; set; }
        public Guid OrderOid { get; set; }
        public Guid ProductOid { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }
        public required string ProductName { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
