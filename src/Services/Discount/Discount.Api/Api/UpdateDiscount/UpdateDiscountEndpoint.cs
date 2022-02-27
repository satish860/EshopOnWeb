using Discount.Api.Repository;
using FastEndpoints;

namespace Discount.Api.Api.UpdateDiscount
{
    public class UpdateDiscountEndpoint : Endpoint<Request, Response>
    {
        private readonly IRepository repository;

        public UpdateDiscountEndpoint(IRepository repository)
        {
            this.repository = repository;
        }
        public override void Configure()
        {
            Put("/api/v1/discount");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            await this.repository.UpdateCoupon(req.Coupon);
            await SendOkAsync(ct);
        }
    }
}
