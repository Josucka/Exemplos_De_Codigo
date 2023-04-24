using APIStoreWithGraphQL.Models;
using APIStoreWithGraphQL.Repositories;
using HotChocolate.Subscriptions;

namespace APIStoreWithGraphQL.GraphQL
{
    public class Query
    {
        public List<Product> GetAllProduct([Service] ProductRepository productRepository)
        {
            return productRepository.GetAllProducts();
        }

        public async Task<Product> GetProductById([Service] ProductRepository productRepository, [Service] ITopicEventSender eventSender, int id)
        {
            Product product = productRepository.GetProductById(id);
            await eventSender.SendAsync("ReturnedProduct", product);
            return product;
        }

        public List<OrderDetail> GetAllOrderDetails([Service] OrderDetailRepository orderDetailRepository)
        {
            return orderDetailRepository.GetAllOrderDetails();
        }

        public List<Order> GetAllOrderWithDetails([Service] OrderRepository orderRepository)
        {
            return orderRepository.GetAllOrderWithDetails();
        }
    }
}
