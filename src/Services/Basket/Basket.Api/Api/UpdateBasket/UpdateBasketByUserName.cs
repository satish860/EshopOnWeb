using Basket.Api.Data;
using FastEndpoints;

namespace Basket.Api.Api.UpdateBasket
{
    public class UpdateBasketByUserName : Endpoint<Request, Response>
    {
        public IBasketRepository BasketRepository { get; set; }
        public override void Configure()
        {
            Post("/api/v1/basket");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            await this.BasketRepository.UpdateShoppingCart(req.ShoppingCart);
            await SendAsync(new Response
            {
                ShoppingCart = req.ShoppingCart,
            });
        }
    }
}
