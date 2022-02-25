using Catalog.Api.Repositories;
using FastEndpoints;

namespace Catalog.Api.Api.GetProductsById
{
    public class Endpoint : Endpoint<Request, Response>
    {
        public IProductRepository ProductRepository { get; set; }

        public override void Configure()
        {
            Get("/api/v1/catalog/{Id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var product = await ProductRepository.GetProductByIdAsync(req.Id);
            if (product == null)
                await SendNotFoundAsync(ct);
            else
                Response = new Response
                {
                    Product = product,
                };
        }
    }
}
