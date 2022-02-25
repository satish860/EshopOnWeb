using Catalog.Api.Repositories;
using FastEndpoints;

namespace Catalog.Api.Api.CreateProduct
{
    public class Endpoint : Endpoint<CreateProductRequest, CreateProductResponse>
    {
        public IProductRepository ProductRepository { get; set; }

        public override void Configure()
        {
            Post("api/v1/catalog");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateProductRequest req, CancellationToken ct)
        {
            await ProductRepository.CreateProduct(req.Product);
            await SendCreatedAtAsync("/api/v1/catalog", null,new CreateProductResponse());
        }
    }
}
