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

        public async Task CreateProduct(Product product)
        {
            await this.catalogContext.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProductAsync(string id)
        {
            FilterDefinition<Product> filterDefinition = Builders<Product>
                                                        .Filter
                                                        .Eq(p => p.Id, id);
            var deleteResult = await this.catalogContext
                                         .Products
                                         .DeleteOneAsync(filterDefinition);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;

        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            return await this.catalogContext
                              .Products
                              .Find(x => x.Id == id)
                              .FirstOrDefaultAsync();

        }

        public async Task<List<Product>> GetProductByNameAsync(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>
                .Filter
                .Eq(p => p.Name, name);
            return await this.catalogContext
                          .Products
                          .Find(filter)
                          .ToListAsync();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await this.catalogContext
                          .Products
                          .Find(p => true)
                          .ToListAsync();
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>
               .Filter
               .Eq(p => p.Category, categoryName);

            return await this.catalogContext
                          .Products
                          .Find(filter)
                          .ToListAsync();
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var updateResult = await catalogContext
                                       .Products
                                       .ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
