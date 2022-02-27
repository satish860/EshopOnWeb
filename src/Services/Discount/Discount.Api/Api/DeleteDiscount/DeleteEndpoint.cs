using Discount.Api.Repository;
using FastEndpoints;

namespace Discount.Api.Api.DeleteDiscount
{
    public class DeleteEndpoint : Endpoint<DeleteRequest>
    {
        private readonly IRepository repository;

        public DeleteEndpoint(IRepository repository)
        {
            this.repository = repository;
        }

        public override void Configure()
        {
            Delete("/api/v1/discount/{productname}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(DeleteRequest req, CancellationToken ct)
        {
            await this.repository.DeleteCoupon(req.ProductName);
            await SendOkAsync(ct);
        }
    }
}
