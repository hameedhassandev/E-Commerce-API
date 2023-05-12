using E_Commerce_API.Entities;
using E_Commerce_API.Entities.Order;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options): base(options)
        {

        }
        public DbSet<Product> Products { get; set; }    
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }



    }
}
