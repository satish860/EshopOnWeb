using MongoDB.Driver;
using Ordering.Api.Domain;

namespace Ordering.Api.Data
{
    public class OrderContext : IOrderContext
    {
        public OrderContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client
                .GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            OrderCollection = database
                .GetCollection<Order>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        }

        public IMongoCollection<Order> OrderCollection { get; }
    }
}
