using Basket.Api.Data;
using EventBus.Messages.Events;
using FastEndpoints;
using MassTransit;

namespace Basket.Api.Api.Checkout
{
    public class Endpoint : Endpoint<BasketCheckOutRequest>
    {
        private readonly IPublishEndpoint publishEndpoint;
        public readonly IBasketRepository basketRepository;

        public Endpoint(IBasketRepository basketRepository, IPublishEndpoint publishEndpoint)
        {
            this.basketRepository = basketRepository;
            this.publishEndpoint = publishEndpoint;
        }

        public override void Configure()
        {
            Post("/api/v1/basket/checkout");
            AllowAnonymous();
        }

        public override async Task HandleAsync(BasketCheckOutRequest req, CancellationToken ct)
        {
            var basket = await this.basketRepository.GetShoppingCartAsync(req.UserName);
            if(basket!=null)
            {
                await this.publishEndpoint.Publish(new BasketCheckoutEvent
                {
                    UserName = req.UserName,
                    AddressLine=req.AddressLine,
                    CardName=req.CardName,
                    CardNumber=req.CardNumber,
                    Country=req.Country,
                    CVV=req.CVV,
                    EmailAddress=req.EmailAddress,
                    Expiration=req.Expiration,
                    FirstName=req.FirstName,
                    LastName=req.LastName,
                    PaymentMethod =req.PaymentMethod,
                    State=req.State,
                    TotalPrice=basket.TotalPrice,
                    ZipCode=req.ZipCode,
                });
                await this.basketRepository.DeleteShoppingCart(req.UserName);
            }
        }
    }
}
