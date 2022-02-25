using FastEndpoints;
using Catalog.Api.Repositories;

namespace Catalog.Api.Api.GetProducts
{
    public class EndPoint : EndpointWithoutRequest<ProductResponse>
    {
        public IProductRepository ProductRepository { get; set; }

        public override void Configure()
        {
            Get("/api/v1/catalog");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var ProductList = await ProductRepository.GetProductsAsync();
            Response = new ProductResponse
            {
                Products = ProductList.AsEnumerable(),
            };
        }
    }
}
