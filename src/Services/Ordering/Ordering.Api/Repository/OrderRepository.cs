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

        public async Task<bool> DeleteOrder(Order order)
        {
            FilterDefinition<Order> filterDefinition = Builders<Order>
                                                       .Filter
                                                       .Eq(p => p.Id, order.Id);
            var deleteResult = await this.orderContext
                                         .OrderCollection
                                         .DeleteOneAsync(filterDefinition);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
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

        public async Task<bool> UpdateOrder(Order order)
        {
            var updateResult = await this.orderContext
                                       .OrderCollection
                                       .ReplaceOneAsync(filter: g => g.Id == order.Id, replacement: order);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;

        }
    }
}
