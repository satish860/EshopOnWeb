using Discount.Api.Repository;
using FastEndpoints;
using System.Linq;

namespace Discount.Api.Api.GetDiscountByProductName
{
    public class GetDiscountEndpoint : Endpoint<Request, Response>
    {
        private readonly IRepository repository;

        public GetDiscountEndpoint(IRepository repository)
        {
            this.repository = repository;
        }

        public override void Configure()
        {
            Get("/api/v1/discount/{productname}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var coupons = await this.repository.GetCouponsByProductName(req.ProductName);
            await SendAsync(new Response
            {
                Coupons = coupons,
            });
        }
    }
}
