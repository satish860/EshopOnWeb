using Catalog.Api.Entities;

namespace Catalog.Api.Api.GetProducts
{
    public class ProductResponse
    {
        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
    }
}
