using Catalog.Api.Data;
using Catalog.Api.Entities;
using FastEndpoints;
using System.Linq;
using MongoDB.Driver;

namespace Catalog.Api.Api.GetProducts
{
    public class EndPoint : EndpointWithoutRequest<ProductResponse>
    {
        public ICatalogContext catalogContext { get; set; }

        public override void Configure()
        {
            Get("/api/v1/catalog");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var ProductList = await catalogContext.Products.Find(p => true).ToListAsync();
            Response = new ProductResponse
            {
                Products = ProductList.AsEnumerable(),
            };
        }
    }
}
