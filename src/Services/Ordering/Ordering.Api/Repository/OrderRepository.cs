using MongoDB.Driver;
using Ordering.Api.Data;
using Ordering.Api.Domain;

namespace Ordering.Api.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IOrderContext orderContext;

        public OrderRepository(IOrderContext orderContext)
        {
            this.orderContext = orderContext;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            await this.orderContext.OrderCollection.InsertOneAsync(order);
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            FilterDefinition<Order> filter = Builders<Order>
                .Filter
                .Eq(p => p.UserName, userName);
            return await this.orderContext.OrderCollection
                 .Find(filter)
                 .ToListAsync();
        }

        
    }
}
