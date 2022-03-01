using FastEndpoints;
using Ordering.Api.Domain;
using Ordering.Api.Repository;

namespace Ordering.Api.Api.ModifyOrder
{
    public class ModifyOrderEndpoint : Endpoint<Order, Order>
    {
        private readonly IOrderRepository orderRepository;

        public ModifyOrderEndpoint(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public override void Configure()
        {
            Put("/api/v1/order");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Order req, CancellationToken ct)
        {
            await this.orderRepository.UpdateOrder(req);
            await this.SendAsync(req);
        }
    }
}
