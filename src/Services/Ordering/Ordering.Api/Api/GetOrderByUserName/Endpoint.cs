using FastEndpoints;
using Ordering.Api.Domain;
using Ordering.Api.Repository;

namespace Ordering.Api.Api.GetOrderByUserName
{
    public class Endpoint : Endpoint<GetOrderRequest, GetOrderResponse>
    {
        private readonly IOrderRepository orderRepository;

        public Endpoint(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public override void Configure()
        {
            Get("/api/v1/order/{username}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetOrderRequest req, CancellationToken ct)
        {
            IEnumerable<Order> orders = await orderRepository.GetOrdersByUserName(req.UserName);
            await this.SendAsync(new GetOrderResponse
            {
                Orders = orders,
            });
        }
    }
}
