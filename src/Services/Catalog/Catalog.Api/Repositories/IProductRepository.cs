﻿using Catalog.Api.Entities;

namespace Catalog.Api.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
    }
}
