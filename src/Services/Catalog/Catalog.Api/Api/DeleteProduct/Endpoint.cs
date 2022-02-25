using Catalog.Api.Repositories;
using FastEndpoints;

namespace Catalog.Api.Api.DeleteProduct
{
    public class Endpoint : Endpoint<DeleteRequest, DeleteResponse>
    {
        public IProductRepository productRepository { get; set; }
        public override void Configure()
        {
            Delete("/api/v1/catalog/{Id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(DeleteRequest req, CancellationToken ct)
        {
            var isDeleted = await productRepository.DeleteProductAsync(req.Id);
            await SendAsync(new DeleteResponse
            {
                IsDeleted = isDeleted,
            });
        }
    }
}
