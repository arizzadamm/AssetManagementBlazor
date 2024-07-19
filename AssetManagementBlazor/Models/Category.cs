using System.ComponentModel.DataAnnotations;

namespace AssetManagementBlazor.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryOid { get; set; }
        public string? Name { get; set; }
    }
}
