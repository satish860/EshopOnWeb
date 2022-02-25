using Catalog.Api.Entities;

namespace Catalog.Api.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();

        Task<Product> GetProductByIdAsync(string id);

        Task<List<Product>> GetProductByNameAsync(string name);

        Task<List<Product>> GetProductsByCategoryAsync(string categoryName);

        Task CreateProduct(Product product);
    }
}
