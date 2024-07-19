using System.ComponentModel.DataAnnotations;

namespace AssetManagementsBlazor.Entities
{
    public class Category
    {
        [Key]
        public Guid CategoryOid { get; set; }
        public string? Name { get; set; }
    }
}
