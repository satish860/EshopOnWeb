using FastEndpoints;
using Ordering.Api.Repository;

namespace Ordering.Api.Api.DeleteOrder
{
    public class DeleteEndpoint : Endpoint<DeleteEndpointRequest>
    {
        private readonly IOrderRepository orderRepository;

        public DeleteEndpoint(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public override void Configure()
        {
            Delete("/api/v1/order/{Id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(DeleteEndpointRequest req, CancellationToken ct)
        {
            await this.orderRepository.DeleteOrder(req.Id);
            await this.SendNoContentAsync();
        }
    }
}
