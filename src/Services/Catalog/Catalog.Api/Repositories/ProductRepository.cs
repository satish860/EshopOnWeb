using Catalog.Api.Data;
using Catalog.Api.Entities;
using MongoDB.Driver;

namespace Catalog.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext catalogContext;

        public ProductRepository(ICatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await this.catalogContext
                          .Products
                          .Find(p => true)
                          .ToListAsync();
        }
    }
}
