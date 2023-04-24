using APIStoreWithGraphQL.Data;
using APIStoreWithGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace APIStoreWithGraphQL.Repositories
{
    public class OrderRepository
    {
        private readonly StoreDbContext _dbContext;

        public OrderRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Order> GetAllOrderWithDetails()
        {
            return _dbContext.Orders.Include(a => a.Account).Include(ab => ab.orderDetails).ThenInclude(abc => abc.Product).ToList();
        }
    }
}
