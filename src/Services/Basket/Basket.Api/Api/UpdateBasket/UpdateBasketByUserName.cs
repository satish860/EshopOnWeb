using Basket.Api.Data;
using Discount.Grpc;
using FastEndpoints;
using Grpc.Core;
using static Discount.Grpc.DiscountProtoService;

namespace Basket.Api.Api.UpdateBasket
{
    public class UpdateBasketByUserName : Endpoint<Request, Response>
    {
        public IBasketRepository BasketRepository { get; set; }

        public DiscountProtoServiceClient discountProtoServiceClient { get; set; }

        public override void Configure()
        {
            Post("/api/v1/basket");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            foreach (var item in req.ShoppingCart.Items)
            {
                try
                {
                    var discount = await discountProtoServiceClient.GetDiscountAsync
                     (
                        new GetDiscountRequest
                        {
                            ProductName = item.ProductName,
                        }
                     );
                    item.Price = item.Price - discount.Amount;
                }
                catch (RpcException exception) when (exception.StatusCode == StatusCode.NotFound)
                {
                    Console.WriteLine($"Discount Not found for the Product {req.ShoppingCart.Items[0].ProductName}");

                }
            }
            

            await this.BasketRepository.UpdateShoppingCart(req.ShoppingCart);
            await SendAsync(new Response
            {
                ShoppingCart = req.ShoppingCart,
            });
        }
    }
}
