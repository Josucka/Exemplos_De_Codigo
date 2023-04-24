using APIStoreWithGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace APIStoreWithGraphQL.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> opt): base(opt)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
