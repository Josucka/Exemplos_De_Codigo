using APIStoreWithGraphQL.Data;
using APIStoreWithGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace APIStoreWithGraphQL.Repositories
{
    public class OrderDetailRepository
    {
        private readonly StoreDbContext _dbContext;

        public OrderDetailRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<OrderDetail> GetAllOrderDetails()
        {
            return _dbContext.OrderDetails.Include(a => a.Order).ThenInclude(ab => ab.Account).Include(abc => abc.Product).ToList();
        }
    }
}
