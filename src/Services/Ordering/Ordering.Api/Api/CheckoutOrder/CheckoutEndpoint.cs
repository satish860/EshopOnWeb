using FastEndpoints;
using Ordering.Api.Domain;
using Ordering.Api.Repository;

namespace Ordering.Api.Api.CheckoutOrder
{
    public class CheckoutEndpoint : Endpoint<Order, Order>
    {
        private readonly IOrderRepository orderRepository;

        public CheckoutEndpoint(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public override void Configure()
        {
            Post("/api/v1/order");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Order req, CancellationToken ct)
        {
            Order order = await this.orderRepository.CreateOrder(req);
            await SendCreatedAtAsync($"/api/v1/order",req.UserName,order);
        }
    }
}
