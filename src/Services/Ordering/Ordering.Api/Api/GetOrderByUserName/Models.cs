using Ordering.Api.Domain;

namespace Ordering.Api.Api.GetOrderByUserName
{
    public class GetOrderRequest
    {
        public string? UserName { get; set; }
    }

    public class GetOrderResponse
    {
        public IEnumerable<Order> Orders { get; set; } = Enumerable.Empty<Order>();
    }
}
