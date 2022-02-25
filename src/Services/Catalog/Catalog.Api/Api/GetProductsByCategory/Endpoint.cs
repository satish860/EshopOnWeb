using Catalog.Api.Repositories;
using FastEndpoints;

namespace Catalog.Api.Api.GetProductsByCategory
{
    public class Endpoint : Endpoint<Request, Response>
    {
        public IProductRepository ProductRepository { get; set; }

        public override void Configure()
        {
            Get("/api/v1/catalog/getproductsbyCategory/{CategoryName}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var products = await ProductRepository
                                .GetProductsByCategoryAsync(req.CategoryName);
            Response = new Response { Products = products };
        }
    }
}
