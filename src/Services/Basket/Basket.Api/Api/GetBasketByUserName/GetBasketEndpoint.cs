using Basket.Api.Data;
using Basket.Api.Entities;
using FastEndpoints;

namespace Basket.Api.Api.GetBasketByUserName
{
    public class GetBasketEndpoint : Endpoint<Request, Response>
    {
        public IBasketRepository basketRepository { get; set; }
        public override void Configure()
        {
            Get("/api/v1/basket/{UserName}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var shoppingBasket = await basketRepository.GetShoppingCartAsync(req.UserName);
            if (shoppingBasket == null)
                await SendAsync(new Response
                {
                    ShoppingCart = new ShoppingCart(req.UserName),
                });
            else
                await SendAsync(new Response
                {
                    ShoppingCart = shoppingBasket,
                });
        }
    }
}
