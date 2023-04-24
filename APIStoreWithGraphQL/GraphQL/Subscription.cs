using APIStoreWithGraphQL.Models;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace APIStoreWithGraphQL.GraphQL
{
    public class Subscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Product>> OnProductGet([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<Product>("ReturnedProduct", cancellationToken);
        }
        
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Product>> OnProductAdd([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<Product>("AddProduct", cancellationToken);
        }
    }
}
