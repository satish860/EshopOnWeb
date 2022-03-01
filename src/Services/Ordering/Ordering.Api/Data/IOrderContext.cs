using MongoDB.Driver;
using Ordering.Api.Domain;

namespace Ordering.Api.Data
{
    public interface IOrderContext
    {
        IMongoCollection<Order> OrderCollection { get; }
    }
}
