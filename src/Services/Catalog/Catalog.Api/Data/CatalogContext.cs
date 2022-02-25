using Catalog.Api.Entities;
using MongoDB.Driver;

namespace Catalog.Api.Data
{
    /// <summary>
    /// Catalog Context.
    /// </summary>
    public class CatalogContext : ICatalogContext
    {
        /// <summary>
        /// Catalog Context with the Configuration.
        /// </summary>
        /// <param name="configuration">Configuration.</param>
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client
                .GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Products = database
                .GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
