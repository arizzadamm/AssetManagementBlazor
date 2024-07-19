using System.ComponentModel.DataAnnotations;

namespace AssetManagementBlazor.Models
{
    public class Orders
    {
        [Key]
        public Guid OrderOid { get; set; }
        public Guid CustomerOid { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
