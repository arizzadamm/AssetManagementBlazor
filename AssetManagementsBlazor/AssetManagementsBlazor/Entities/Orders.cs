using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementsBlazor.Entities
{
    public class Orders
    {
        [Key]
        public Guid OrderOid { get; set; }
        [ForeignKey("CustomerOid")]
        public Guid CustomerOid { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
