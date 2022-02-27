﻿using Discount.Api.Repository;
using FastEndpoints;

namespace Discount.Api.Api.CreateDiscount
{
    public class CreateDiscountEndpoint : Endpoint<Request, Response>
    {
        private readonly IRepository repository;

        public CreateDiscountEndpoint(IRepository repository)
        {
            this.repository = repository;
        }

        public override void Configure()
        {
            Post("/api/v1/discount");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var coupon = await repository.CreateCoupon(req.Coupon);
            await SendAsync(new Response
            {
                Coupon = coupon,
            });

        }
    }
}
