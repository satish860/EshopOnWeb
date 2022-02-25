using Catalog.Api.Repositories;
using FastEndpoints;

namespace Api.GetProductsByName
{
    public class Endpoint : Endpoint<Request, Response>
    {
        public IProductRepository ProductRepository { get; set; }

        public override void Configure()
        {
            Post("/api/v1/catalog/getproductbyname/{Name}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var products = await ProductRepository.GetProductByNameAsync(r.Name);
            Response = new Response
            {
                Products = products
            };
        }
    }
}