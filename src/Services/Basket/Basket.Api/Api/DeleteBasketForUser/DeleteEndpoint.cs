using Basket.Api.Data;
using FastEndpoints;

namespace Basket.Api.Api.DeleteBasketForUser
{
    public class DeleteEndpoint : Endpoint<Request>
    {
        public IBasketRepository? BasketRepository { get; set; }

        public override void Configure()
        {
            Delete("/api/v1/basket/{username}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            await this.BasketRepository.DeleteShoppingCart(req.UserName);
            await SendAsync(new {});
        }
    }
}
