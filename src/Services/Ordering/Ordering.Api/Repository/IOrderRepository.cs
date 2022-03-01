using Ordering.Api.Domain;

namespace Ordering.Api.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);

        Task<Order> CreateOrder(Order order);
    }
}
