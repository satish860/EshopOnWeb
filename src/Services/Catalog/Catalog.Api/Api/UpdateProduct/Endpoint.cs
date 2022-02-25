using Catalog.Api.Repositories;
using FastEndpoints;

namespace Catalog.Api.Api.UpdateProduct
{
    public class Endpoint : Endpoint<UpdateProductRequest, UpdateProductResponse>
    {
        public IProductRepository ProductRepository { get; set; }

        public override async void Configure()
        {
            Put("/api/v1/catalog");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UpdateProductRequest req, CancellationToken ct)
        {
            await ProductRepository.UpdateProductAsync(req.Product);
            await SendNoContentAsync();
        }
    }
}
