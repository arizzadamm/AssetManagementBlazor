using AssetManagementsBlazor.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementsBlazor.Data
{
    public class AssetDataContext : DbContext
    {
        public AssetDataContext(DbContextOptions<AssetDataContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
