using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementsBlazor.ViewModel
{
    public class OrderViewModel
    {
        public Guid OrderOid { get; set; }
        public Guid CustomerOid { get; set; }
        public Guid OrderDetailOid { get; set; }
        public Guid ProductOid { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string OrderNumber { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }
    }
}
